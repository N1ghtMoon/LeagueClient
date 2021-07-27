using System;
using System.Diagnostics;
using System.Windows.Forms;
using AutoAccept.LCU;
using Newtonsoft.Json.Linq;
using RestSharp;
using SystemColor = System.Drawing.Color;

namespace AutoAccept
{
    public partial class Form1 : Form
    {
        private RunStatus _runStatus;

        public Form1()
        {
            InitializeComponent();

            _runStatus = RunStatus.None;
        }

        private void _startButton_Click(object sender, EventArgs e)
        {
            _runStatus = RunStatus.Start;

            _lcuTimer_Tick(null, null);
            _systemTimer_Tick(null, null);
        }

        private void _stopButtom_Click(object sender, EventArgs e)
        {
            _runStatus = RunStatus.Stop;

            _lcuTimer_Tick(null, null);
            _systemTimer_Tick(null, null);
        }

        private async void _lcuTimer_Tick(object sender, EventArgs e)
        {
            string text = "Wait for Start - 等待启动";

            if (_runStatus == RunStatus.Start)
            {
                text = "Running - 开始自动接受对局";
                _timeLabel.ForeColor = _textLable.ForeColor = SystemColor.DodgerBlue;
            }
            else if (_runStatus == RunStatus.Stop)
            {
                text = "Stop - 已停止运行";
                _timeLabel.ForeColor = _textLable.ForeColor = SystemColor.OrangeRed;
            }
            else
            {
                _timeLabel.ForeColor = _textLable.ForeColor = SystemColor.Black;
            }

            if (_runStatus != RunStatus.Start)
            {
                _textLable.Text = text;
                return;
            }

            Process[] leagueProcess = Process.GetProcessesByName("LeagueClientUx");
            if (leagueProcess.Length == 0)
            {
                _textLable.Text = text;
                return;
            }

            LCUResult summonerInfo = await LCUClient.SendRequest(leagueProcess, Method.GET, "/lol-summoner/v1/current-summoner");
            if (!summonerInfo.IsValid)
            {
                _textLable.Text = text + " (未检测到召唤师信息)";
                return;
            }

            JObject summonerInfoJObject = JObject.Parse(summonerInfo.Contect);
            JToken userName = summonerInfoJObject["displayName"];

            if (userName == null)
            {
                _textLable.Text = text + " (获取召唤师信息失败)";
                return;
            }

            _textLable.Text = text + $" ({userName} - Lv{summonerInfoJObject["summonerLevel"]})";

            LCUResult acceptRequest = await LCUClient.SendRequest(leagueProcess, Method.GET, "/lol-matchmaking/v1/ready-check");
            if (!acceptRequest.IsValid)
            {
                return;
            }

            JToken requestState = JObject.Parse(acceptRequest.Contect)["state"];
            if (requestState == null || requestState.ToString() != "InProgress")
            {
                Debug.WriteLine(requestState.ToString());
                return;
            }

            await LCUClient.SendRequest(leagueProcess, Method.POST, "/lol-matchmaking/v1/ready-check/accept");
        }

        private void _systemTimer_Tick(object sender, EventArgs e)
        {
            if (_runStatus == RunStatus.Start)
            {
                _timeLabel.ForeColor = SystemColor.DodgerBlue;
            }
            else if (_runStatus == RunStatus.Stop)
            {
                _timeLabel.ForeColor = SystemColor.OrangeRed;
            }
            else
            {
                _timeLabel.ForeColor = SystemColor.Black;
            }

            _timeLabel.Text = $"LocalTime - 当前时间: [{DateTime.Now}]";
        }
    }
}

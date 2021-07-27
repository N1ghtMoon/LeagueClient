using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace AutoAccept.LCU
{
    public class LCUClient
    {
        private static Regex _tokenRegex = new Regex("\"--remoting-auth-token=(?'token'.*?)\"", RegexOptions.Multiline);
        private static Regex _portRegex = new Regex("\"--app-port=(?'port'|.*?)\"", RegexOptions.Multiline);

        public static async Task<LCUResult> SendRequest(Process[] leagueProcess, Method method, string url, string api = null)
        {
            Tuple<string, string> lcuInfo = GetLCUInfo(leagueProcess);
            string token = lcuInfo.Item1;
            string port = lcuInfo.Item2;

            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(port))
            {
                return new LCUResult();
            }

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;// | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) => true;

            RestClient restClient = new RestClient($"https://127.0.0.1:{port}") { Authenticator = new HttpBasicAuthenticator("riot", token) }; 
            RestRequest restRequest = new RestRequest(url, method, DataFormat.None);

            if (api != null)
            {
                restRequest.AddJsonBody(api);
            }

            IRestResponse result = await restClient.ExecuteAsync(restRequest);
            LCUResult req = new LCUResult { Contect = result.Content, Status = result.StatusCode };
            return req;
        }

        private static Tuple<string, string> GetLCUInfo(Process[] leagueProcess)
        {
            string port = string.Empty;
            string token = string.Empty;

            foreach (var p in leagueProcess)
            {
                using (var mos = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + p.Id))
                using (var moc = mos.Get())
                {
                    try
                    {
                        string commandLine = (string)moc.OfType<ManagementObject>().First()["CommandLine"];
                        token = _tokenRegex.Match(commandLine).Groups[1].Value;
                        port = _portRegex.Match(commandLine).Groups[1].Value;
                        break;
                    }
                    catch
                    {
                        // ignore
                    }
                }
            }

            return new Tuple<string, string>(token, port);
        }
    }
}

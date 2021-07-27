
namespace AutoAccept
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._startButton = new System.Windows.Forms.Button();
            this._stopButtom = new System.Windows.Forms.Button();
            this._textLable = new System.Windows.Forms.Label();
            this._lcuTimer = new System.Windows.Forms.Timer(this.components);
            this._timeLabel = new System.Windows.Forms.Label();
            this._systemTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // _startButton
            // 
            this._startButton.Location = new System.Drawing.Point(10, 67);
            this._startButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._startButton.Name = "_startButton";
            this._startButton.Size = new System.Drawing.Size(172, 50);
            this._startButton.TabIndex = 0;
            this._startButton.Text = "Start - 启动";
            this._startButton.UseVisualStyleBackColor = true;
            this._startButton.Click += new System.EventHandler(this._startButton_Click);
            // 
            // _stopButtom
            // 
            this._stopButtom.Location = new System.Drawing.Point(186, 67);
            this._stopButtom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._stopButtom.Name = "_stopButtom";
            this._stopButtom.Size = new System.Drawing.Size(172, 50);
            this._stopButtom.TabIndex = 1;
            this._stopButtom.Text = "Stop - 停止";
            this._stopButtom.UseVisualStyleBackColor = true;
            this._stopButtom.Click += new System.EventHandler(this._stopButtom_Click);
            // 
            // _textLable
            // 
            this._textLable.Location = new System.Drawing.Point(7, 11);
            this._textLable.Name = "_textLable";
            this._textLable.Size = new System.Drawing.Size(349, 26);
            this._textLable.TabIndex = 2;
            this._textLable.Text = "Wait for Start - 等待启动";
            this._textLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lcuTimer
            // 
            this._lcuTimer.Enabled = true;
            this._lcuTimer.Interval = 2000;
            this._lcuTimer.Tick += new System.EventHandler(this._lcuTimer_Tick);
            // 
            // _timeLabel
            // 
            this._timeLabel.Location = new System.Drawing.Point(7, 38);
            this._timeLabel.Name = "_timeLabel";
            this._timeLabel.Size = new System.Drawing.Size(351, 26);
            this._timeLabel.TabIndex = 3;
            this._timeLabel.Text = "LocalTime - 当前时间: ";
            this._timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _systemTimer
            // 
            this._systemTimer.Enabled = true;
            this._systemTimer.Interval = 500;
            this._systemTimer.Tick += new System.EventHandler(this._systemTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 124);
            this.Controls.Add(this._timeLabel);
            this.Controls.Add(this._textLable);
            this.Controls.Add(this._stopButtom);
            this.Controls.Add(this._startButton);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AutoAccept - 英雄联盟自动接受对局";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _startButton;
        private System.Windows.Forms.Button _stopButtom;
        private System.Windows.Forms.Label _textLable;
        private System.Windows.Forms.Timer _lcuTimer;
        private System.Windows.Forms.Label _timeLabel;
        private System.Windows.Forms.Timer _systemTimer;
    }
}


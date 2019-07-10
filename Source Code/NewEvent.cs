using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VMUN_4
{
    public partial class NewEvent : UserControl
    {
        public int sessionHour;
        public int sessionMinute;
        public int languageIndex;
        public NewEvent()
        {
            InitializeComponent();
            languageIndex = 0;

        }

        private void tblAll_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void LanguageUpdate(int languageIndex)
        {
            this.languageIndex = languageIndex;
            switch (languageIndex)
            {
                case 0:
                    cmdStart.Text = "Start";
                    cmdPause.Text = "Pause";
                    cmdNext.Text = "Next";
                    cmdExpire.Text = "Expire";
                    cmdMotion.Text = "Raise a Motion";
                    cmdRollCall.Text = "Roll Call";
                    cmdSpeaker.Text = "Set Speaker's List";
                    cmdFile.Text = "Submit File";
                    cmdSave.Text = "Save Conference Events";
                    cmdTimerReminder.Text = "Set Timer and Reminder";
                    cmdSettings.Text = "Settings";

                    lblNewEvent.Text = "New Event";                   
                break;
                case 1:
                    cmdStart.Text = "开始";
                    cmdPause.Text = "暂停";
                    cmdNext.Text = "下一位";
                    cmdExpire.Text = "结束动议";
                    cmdMotion.Text = "提交动议";
                    cmdRollCall.Text = "点名程序";
                    cmdSpeaker.Text = "主发言名单";
                    cmdFile.Text = "提交文件";
                    cmdSave.Text = "保存会场动态";
                    cmdTimerReminder.Text = "计时器和备忘录";
                    cmdSettings.Text = "设置";

                    lblNewEvent.Text = "创建动态";
                    break;
                case 2:

                break;


            }
        }

        private void cmdSettings_Click(object sender, EventArgs e)
        { 
            
        }

        private void timerSystemTime_Tick(object sender, EventArgs e)
        {
            lblSystemTime.Text = $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}";
        }

        private void timerSessionTime_Tick(object sender, EventArgs e)
        {
            if (sessionMinute > 0)
            {
                sessionMinute--;

            }
            else
            {
                if (sessionHour > 0)
                {
                    sessionMinute = 59;
                    sessionHour--;
                }
                else
                {
                    timerSessionTime.Enabled = false;

                }

            }
            string Hour = sessionHour.ToString();
            string Minute = sessionMinute.ToString();
            if (Hour.Length < 2)
            {
                Hour = $"0{sessionHour.ToString()}";
            }
            if (Minute.Length < 2)
            {
                Minute = $"0{sessionMinute.ToString()}";
            }
            if (languageIndex == 0)
            {

                lblSessionCountDown.Text = $"{Hour}:{Minute} to End";
            }
            if (languageIndex == 1)
            {
                lblSessionCountDown.Text = $"剩余{Hour}:{Minute}";
            }
        }
    }
}

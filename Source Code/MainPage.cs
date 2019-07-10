using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace VMUN_4
{
    public partial class MainPage : Form
    {        
        public int languageIndex;
        public bool doNotAsk = false;
        public bool closed = false;
        public bool occupied()
        {
            if (lblContent.Text == "" && lblTitle.Text=="")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void contentUpdate(string title = "", string content ="" )
        {
            
            lblTitle.Text = title;
            lblContent.Text = content;
            
        }

        public void contentUpdate2(string engTitle = "", string engContent = "", string chnTitle = "", string chnContent = "")
        {
            switch(languageIndex)
            {
                case 0:
                    lblTitle.Text = engTitle;
                    lblContent.Text = engContent;
                    break;
                case 1:
                    lblTitle.Text = chnTitle;
                    lblContent.Text = chnContent;
                    break;
            }
           

        }
        public void timeUpdate(string bigTime = "", string smallTime = "")
        {
            lblBigTime.Text = bigTime;
            lblSmallTime.Text = smallTime;
        }

        public void nowNextUpdate(string nowCountry = "", string nextCountry = "")
        {
            lblNowCountry.Text = nowCountry;
            lblNextCountry.Text = nextCountry;
        }
        public void nowUpdate(string nowCountry)
        {
            
            lblNowCountry.Text = nowCountry;
        }
        public void nextUpdate(string nextCountry)
        {
            switch (languageIndex)
            {
                case 0:
                    lblNextCountry.Text = $"Next: {nextCountry}";
                    break;
                case 1:
                    lblNextCountry.Text = $"下一位：{nextCountry}";
                    break;
            }
        }
        public void listAdd(string Country)
        {
            listCountry.Items.Add(Country);
        }
        public void listRemove(string Country)
        {
            listCountry.Items.Remove(Country);
        }
        public MainPage(int languageIndex)
        {
            InitializeComponent();

            this.languageIndex = languageIndex;
            languageUpdate(languageIndex);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {




        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainPage_Load(object sender, EventArgs e)
        {
                 
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void MainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            closed = true;
            Application.Exit();
        }

        private void txtConferenceName_MouseEnter(object sender, EventArgs e)
        {
            txtConferenceName.BackColor = Color.DarkGray;

        }

        private void txtConferenceName_MouseLeave(object sender, EventArgs e)
        {
            txtConferenceName.BackColor = Color.FromArgb(64,64,64);
        }

        private void txtCommitteeName_MouseEnter(object sender, EventArgs e)
        {
            txtCommitteeName.BackColor = Color.DarkGray;
        }

        private void txtCommitteeName_MouseLeave(object sender, EventArgs e)
        {
            txtCommitteeName.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void txtTopicName_MouseEnter(object sender, EventArgs e)
        {
            txtTopicName.BackColor = Color.DarkGray;
        }

        private void txtTopicName_MouseLeave(object sender, EventArgs e)
        {
            txtTopicName .BackColor = Color.FromArgb(64, 64, 64);
        }

        private void timerSystemTime_Tick(object sender, EventArgs e)
        {
            lblSystemTime.Text = $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}";
        }

        private void cmdConfirm_Click(object sender, EventArgs e)
        { 
                tblInstruction.Enabled = false;
                tblInstruction.Visible = false;
                tblAll.Enabled = true;
                updateConferenceInfo();
                this.TopMost = false;
        }

        private void autoAdjust()
        {
            this.WindowState = FormWindowState.Normal;
            Screen[] screens = Screen.AllScreens;
            Location = screens[0].WorkingArea.Location;
            this.WindowState = FormWindowState.Maximized;
        }

        private void cannotFindSecondScreen()
        {
            PopUp popUp = new PopUp(languageIndex, "Error", "Cannot find a second monitor (projector)", "错误", "无法找到第二显示器（投影仪）",lblLowerDash.BackColor);
            popUp.ShowDialog();

        }

        private void SetDisplayMode(DisplayMode mode)
        {
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "DisplaySwitch.exe";
            switch (mode)
            {
                case DisplayMode.External:
                    proc.StartInfo.Arguments = "/external";
                    break;
                case DisplayMode.Internal:
                    proc.StartInfo.Arguments = "/internal";
                    break;
                case DisplayMode.Extend:
                    proc.StartInfo.Arguments = "/extend";
                    break;
                case DisplayMode.Duplicate:
                    proc.StartInfo.Arguments = "/clone";
                    break;
            }
            proc.Start();
            
        }
        enum DisplayMode
        {
            Internal,
            External,
            Extend,
            Duplicate
        }
        public void languageUpdate(int languageIndex)
        {
            switch (languageIndex)
            {
                case 0:
                    lblGuide.Text = "Please connect to a second monitor in Extend mode.";
                    cmdConfirm.Text = "I have connected";
                    cmdOneMonitor.Text = "Help me with it";
                    textBox1.Text = "Conference Abbreviation";
                    textBox2.Text = "Committee Name";
                    textBox3.Text = "Topic";
                    break;
                case 1:
                    lblGuide.Text = "请以扩展模式连接第二显示器。";
                    cmdConfirm.Text = "我已连接";
                    cmdOneMonitor.Text = "请求帮助";
                    textBox1.Text = "会议名称缩写";
                    textBox2.Text = "委员会名称";
                    textBox3.Text = "议题";
                    break;

            }
        }

        private void cmdOneMonitor_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            Guide gui = new Guide(languageIndex, 0);
            gui.Show();
            gui.Focus();

        }

        private void updateConferenceInfo()
        {
            if (textBox1.Text !="Conference Abbreviation" && textBox1.Text !="会议名称缩写")
                txtConferenceName.Text = textBox1.Text;
            if (textBox2.Text != "Committee Name" && textBox2.Text != "委员会名称")
                txtCommitteeName.Text = textBox2.Text;
            if (textBox3.Text != "Topic" && textBox3.Text != "议题")
                txtTopicName.Text = textBox3.Text;
        }

        public void listUpdate (List<string> countryList)
        {
            listCountry.Items.Clear();
            for (int i = 0;i<countryList.Count; i++)
            {
                listCountry.Items.Add(countryList[i]);
            }
        }

        public void attendanceUpdate(int sm, int am)
        {
            switch(languageIndex)
            {
                case 0:
                    lblSM.Text = $"Simple Majority: {sm.ToString()}";
                    lblAM.Text = $"Absolute Majority: {am.ToString()}";
                    break;
                case 1:
                    lblSM.Text = $"简单多数：{sm.ToString()}";
                    lblAM.Text = $"绝对多数：{am.ToString()}";
                    break;

            }
        }


        public void DrawPieChartOnForm(int whitePercent, int greyPercent)
        {
            //Take Total Five Values & Draw Chart Of These Values.
            int[] myPiePercent = {whitePercent, greyPercent};

            //Take Colors To Display Pie In That Colors Of Taken Five Values.
            Color[] myPieColors = { Color.White,Color.DimGray };

            using (Graphics myPieGraphic = this.CreateGraphics())
            {
                //Give Location Which Will Display Chart At That Location.
                Point myPieLocation = new Point(10, 10);

                //Set Here Size Of The Chart.
                Size myPieSize = new Size(150, 150);

                //Call Function Which Will Draw Pie of Values.
                DrawPieChart(myPiePercent, myPieColors, myPieGraphic, myPieLocation, myPieSize);
            }
        }


        // Draws a pie chart.
        public void DrawPieChart(int[] myPiePerecents, Color[] myPieColors, Graphics myPieGraphic, Point
      myPieLocation, Size myPieSize)
        {          
            int PiePercentTotal = 0;
            for (int PiePercents = 0; PiePercents < myPiePerecents.Length; PiePercents++)
            {
                using (SolidBrush brush = new SolidBrush(myPieColors[PiePercents]))
                {

                    //Here it Will Convert Each Value Into 360, So Total Into 360 & Then It Will Draw A Full Pie Chart.
                    myPieGraphic.FillPie(brush, new Rectangle(new Point(10, 10), myPieSize), Convert.ToSingle(PiePercentTotal * 360 / 100), Convert.ToSingle(myPiePerecents[PiePercents] * 360 / 100));
                }

                PiePercentTotal += myPiePerecents[PiePercents];
            }
            return;
        }

        private void barSession_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox1.SelectAll();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Focus();
            textBox2.SelectAll();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Focus();
            textBox3.SelectAll();
        }

        public void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (!doNotAsk)
            {
                MessageBoxButtons but = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(multilingual("Are you sure to quit? All unsaved conference progress will be lost.", "确认退出？未保存的会议进程将会丢失。"), multilingual("Warning", "警告"), but);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            doNotAsk = false;
            closed = false;
        }
        private string multilingual(string eng, string simchn)
        {
            switch(languageIndex)
            {
                case 0:
                    return eng;
                case 1:
                    return simchn;
                default:
                    return eng;
            }
        }
    }

}

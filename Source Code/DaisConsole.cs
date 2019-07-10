using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
namespace VMUN_4
{
    public partial class DaisConsole : Form
    {
        MainPage mainP;
        Lists allLists;
        Voting nowVoting;
        public int languageIndex;//决定页面语言
        public int sessionLength;//会期长度
        public int sessionHour;//会期小时
        public int sessionMinute;//会期分钟
        public double[,] data;//代表数据数组
        public Motion currentmotion;//当前的动议
        public int buttonFunctionIndex;//决定界面上时间控制按钮的功能范围
        public bool motionInProgress;//决定当前是否有正在进行的动议
        public bool rollCallInProgress;
        public int mcSpeakerNumber;
        public int mcSpeakerLeft;
        public bool SLinProgress;
        public bool votingInProgress;
        
        int SLTime;
        int SLEachTime;
        int SLLeft;
        int mainTotalTime;
        int mainEachTime;
        int mcNowIndex;
        int mcNextIndex;
        int rcNowIndex;
        int rcNextIndex;
        int numberAllowedMore;
        bool allowMore;
        int mcEventListLocation;
        int present = 0;
        int absent = 0;
        int sm = 0;
        int am = 0;
        int num20 = 0;
        int rate = 0;
        int unknown = 0;
        int flashTime = 0;
        bool firstRound = true;
        int timer1Sec = 0;
        int timer1Min = 0;
        int timer2Sec = 0;
        int timer2Min = 0;
        int timePassed = 0;
        double[] preservedRecord;
        string preservedPrompt = "";

        public DaisConsole(Lists list, int languageIndex, int sessionLength)
        {
            mainP = new MainPage(languageIndex);
            this.languageIndex = languageIndex;
            InitializeComponent();
            this.sessionLength = sessionLength;
            sessionMinute = (this.sessionLength % 60) + 1;
            sessionHour = (this.sessionLength - sessionMinute + 1) / 60;
            doOneTick();
            timerSessionTime.Enabled = true;

            this.allLists = list;

            data = new double[list.allCountry.Count, 9];
            for (int i = 0; i < list.allCountry.Count; i++)//Read all the countries.
            {
                data[i, 0] = i;
                motionSelection1.combCountry.Items.Add(list.allCountry[i]);
                motionSelection2.combCountry.Items.Add(list.allCountry[i]);
                motionSelection3.combCountry.Items.Add(list.allCountry[i]);
                listRCCountry.Items.Add("? " + list.allCountry[i]);
                listMCCountry.Items.Add(list.allCountry[i]);
                listSLCountry.Items.Add(list.allCountry[i]);
                combFileSponsor.Items.Add(list.allCountry[i]);
                combFileSignatory.Items.Add(list.allCountry[i]);
                combDataCountry.Items.Add(list.allCountry[i]);
                for (int j = 1; j < 9; j++)
                {
                    data[i, j] = allLists.data[i,j];
                }
                data[i, 5] = 0;
                data[i, 6] = 0;
            }
            allLanguageUpdate();//Update the language of every UserControl and Form.
            mainP.Show();
            mainP.TopMost = true;
            buttonFunctionIndex = -1;//No Function
            rollCallInProgress = false;
            motionInProgress = false;
            SLinProgress = false;
            votingInProgress = false;
            SLTime = 120;
            SLEachTime = 120;
            SLLeft = 0;
            assignPush(4, "Speaker's List", "Not Set", "主发言名单", "未确立");
            listSLCountry.SelectedIndex = 0;
            combHelpLanguage.SelectedIndex = languageIndex;
            List<string> eventList = allLists.readEvent(languageIndex);
            if (eventList.Count>0)
            {
                for (int i =0;i<eventList.Count;i++)
                {
                    listEvents.Items.Add(eventList[i]);
                }
                listEvents.SelectedIndex = listEvents.Items.Count - 2;
            }
            allLists.papers = allLists.readFile(languageIndex);
            if (allLists.papers.Count >0)
            {
                for (int i =0;i<allLists.papers.Count;i++)
                {
                    listFile.Items.Add(allLists.papers[i].paperName);
                    if (allLists.papers[i].sponsors.Count > 0)
                    {
                        for (int j = 0; j < allLists.papers[i].sponsors.Count; j++)
                        {
                            if (allLists.allCountry.IndexOf(allLists.papers[i].sponsors[j]) != -1)
                            {
                                writeToData(allLists.allCountry.IndexOf(allLists.papers[i].sponsors[j]), 5, "+");
                            }
                        }
                    }
                    if (allLists.papers[i].signatories.Count > 0)
                    {
                        for (int j = 0; j < allLists.papers[i].signatories.Count; j++)
                        {
                            if (allLists.allCountry.IndexOf(allLists.papers[i].signatories[j]) != -1)
                            {
                                writeToData(allLists.allCountry.IndexOf(allLists.papers[i].signatories[j]), 6, "+");
                            }
                        }
                    }
                }
            }
            preservedRecord = new double[allLists.allCountry.Count];
            txtReminder1.Text = allLists.reminder1;
            txtReminder2.Text = allLists.reminder2;
        }

        private void allLanguageUpdate()
        {
            languageUpdate();
            helpPageLanguageUpdate(languageIndex);
            motionSelection1.languageUpdate(languageIndex);
            motionSelection2.languageUpdate(languageIndex);
            motionSelection3.languageUpdate(languageIndex);
            switch (languageIndex)
            {
                case 0:
                    motionSelection1.lblTitle.Text = "Motion I";
                    motionSelection2.lblTitle.Text = "Motion II";
                    motionSelection3.lblTitle.Text = "Motion III";
                    break;
                case 1:
                    motionSelection1.lblTitle.Text = "动议一";
                    motionSelection2.lblTitle.Text = "动议二";
                    motionSelection3.lblTitle.Text = "动议三";
                    break;
            }
        }

        private void tblDashboard_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tblDashEvents_Paint(object sender, PaintEventArgs e)
        {

        }

        private void push1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void DaisConsole_Load(object sender, EventArgs e)
        {
        }

        private void DaisConsole_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void bigPanel_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timerInterupt_Tick(object sender, EventArgs e)
        {
            if (motionSelection1.hasEvent)
                handleMotion1Event();
            if (motionSelection2.hasEvent)
                handleMotion2Event();
            if (motionSelection3.hasEvent)
                handleMotion3Event();

            if (push1.clicked)
                push1_Click_1(sender, e);
            if (push2.clicked)
                push2_Click_1(sender, e);
            if (push3.clicked)
                push3_Click_1(sender, e);
            if (push4.clicked)
                push4_Click_1(sender, e);


        }
        private void updateEventList(int eventListLocation, List<string> countryList)
        {

            string temp = "";
            for (int i = 0; i < countryList.Count; i++)
            {
                temp += countryList[i];
                if (i < countryList.Count - 1)
                {
                    temp += ", ";
                }
            }
            listEvents.Items[mcEventListLocation] = $"          {temp}";
            listEvents.SelectedIndex = listEvents.Items.Count - 2;
        }
        private void updateEventList(Voting votingResult)
        {
            string yesVotes = "";
            string noVotes = "";
            string abstainVotes = "";
            string time = DateTime.Now.ToShortTimeString();
            for (int i = 0; i < votingResult.choices.GetLength(0); i++)
            {
                switch (votingResult.choices[i])
                {
                    case 1:
                        yesVotes += $"{allLists.allCountry[votingResult.presentCountryIndex[i]]}, ";
                        break;
                    case 2:
                        noVotes += $"{allLists.allCountry[votingResult.presentCountryIndex[i]]}, ";
                        break;
                    case 3:
                        abstainVotes += $"{allLists.allCountry[votingResult.presentCountryIndex[i]]}, ";
                        break;
                }
                if (yesVotes.Length >= 2)
                {
                    yesVotes.Remove(yesVotes.Length - 2);
                }
                if (noVotes.Length >= 2)
                {
                    noVotes.Remove(noVotes.Length - 2);
                }
                if (abstainVotes.Length >= 2)
                {
                    abstainVotes.Remove(abstainVotes.Length - 2);
                }

            }

            switch (languageIndex)
            {
                case 0:
                    listEvents.Items.Add($"{time} [Voting] {votingResult.fileName} Yes: {votingResult.yes.ToString()} No: {votingResult.no.ToString()}, Abstain: {votingResult.abstain.ToString()}, Favor Rate: {votingResult.favorRate.ToString()}%");
                    listEvents.Items.Add($"          Yes: {yesVotes}");
                    listEvents.Items.Add($"          No: {noVotes}");
                    listEvents.Items.Add($"          Abstain: {abstainVotes}");
                    listEvents.Items.Add("");
                    break;
                case 1:
                    listEvents.Items.Add($"{time} [投票] {votingResult.fileName} 赞成：{votingResult.yes.ToString()}，反对：{votingResult.no.ToString()}，弃权：{votingResult.abstain.ToString()}，赞成率：{votingResult.favorRate.ToString()}%");
                    listEvents.Items.Add($"          赞成：{yesVotes}");
                    listEvents.Items.Add($"          反对：{noVotes}");
                    listEvents.Items.Add($"          弃权：{abstainVotes}");
                    listEvents.Items.Add("");
                    break;
            }
            listEvents.SelectedIndex = listEvents.Items.Count - 2;
        }
        private void updateEventList(int present, int absent)
        {
            string time = DateTime.Now.ToShortTimeString();
            string temp = "";
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (data[i, 8] == -1)
                {
                    temp += allLists.allCountry[i] + multilingual(", ", "，");
                }
            }
            switch (languageIndex)
            {

                case 0:
                    listEvents.Items.Add($"{time} [Roll Call] Present: {present.ToString()}, Absent: {absent.ToString()}");
                    listEvents.Items.Add("          Absent: " + temp);
                    listEvents.Items.Add("");
                    break;
                case 1:
                    listEvents.Items.Add($"{time} [点名] 出席：{present.ToString()}，缺席：{absent.ToString()}");
                    listEvents.Items.Add("          缺席：" + temp);
                    listEvents.Items.Add("");
                    break;
            }
            listEvents.SelectedIndex = listEvents.Items.Count - 2;
        }
        private void updateEventList(Motion motion)
        {
            string time = motion.submitTime.ToShortTimeString();
            string status;
            string raisedby = allLists.allCountry[motion.raisedBy];
            switch (languageIndex)
            {
                case 0:
                    if (motion.passed)
                    {
                        status = "[Pass Motion]";
                    }
                    else
                    {
                        status = "[Fail Motion]";
                    }

                    switch (motion.motionIndex)
                    {
                        case 0:
                            listEvents.Items.Add($"{time} {status} MC: {motion.topic} ({motion.totalTime}min, {motion.eachTime}sec, {raisedby})");
                            break;
                        case 1:
                            listEvents.Items.Add($"{time} {status} UMC ({motion.totalTime}min, {raisedby})");
                            break;
                        case 2:
                            listEvents.Items.Add($"{time} {status} Free Debate ({motion.totalTime}min, {raisedby})");

                            break;
                        case 3:
                            listEvents.Items.Add($"{time} {status} Meeting Suspension");
                            break;
                        case 4:
                            listEvents.Items.Add($"{time} {status} Close Debate");
                            break;
                        case 5:
                            listEvents.Items.Add($"{time} {status} Motion: {motion.topic}");
                            break;
                    }
                    break;

                case 1:
                    if (motion.passed)
                    {
                        status = "[通过动议]";
                    }
                    else
                    {
                        status = "[未通过动议]";
                    }

                    switch (motion.motionIndex)
                    {
                        case 0:
                            listEvents.Items.Add($"{time} {status} 有主持核心磋商：{motion.topic}（{motion.totalTime}分钟，{motion.eachTime}秒，{raisedby}）");
                            break;
                        case 1:
                            listEvents.Items.Add($"{time} {status} 自由磋商（{motion.totalTime}分钟，{raisedby}）");
                            break;
                        case 2:
                            listEvents.Items.Add($"{time} {status} 自由辩论 （{motion.totalTime}分钟，{raisedby}）");

                            break;
                        case 3:
                            listEvents.Items.Add($"{time} {status} 暂停会议");
                            break;
                        case 4:
                            listEvents.Items.Add($"{time} {status} 结束辩论");
                            break;
                        case 5:
                            listEvents.Items.Add($"{time} {status} 动议：{motion.topic}");
                            break;
                    }
                    break;
            }
            listEvents.SelectedIndex = listEvents.Items.Count - 2;
        }

        public void languageUpdate()
        {
            switch (languageIndex)
            {
                case 0:
                    cmdStart.Text = "Start";
                    cmdPause.Text = "Pause";
                    cmdNext.Text = "Next";
                    cmdExpire.Text = "Expire";
                    cmdMotion.Text = "Motion";
                    cmdRollCall.Text = "Roll Call";
                    cmdSpeaker.Text = "Speaker's List";
                    cmdData.Text = "File and Data";
                    cmdVoting.Text = "Voting Procedure";
                    cmdTimerReminder.Text = "Timer and Reminder";
                    cmdHelp.Text = "Help";
                    lblDashboard.Text = "Dashboard";
                    lblEvents.Text = "Events";

                    lblMCTips.Text = "Use Up, Down, or Enter keys to navigate or enter. Use buttons on the top-left corner to moderate the caucus.";
                    lblMCSpeakers.Text = "Speakers";
                    lblEnterGuide.Text = "Search:";
                    cmdMCAdd.Text = "Add >>>";
                    cmdMCClearInput.Text = "Clear Input";
                    cmdMCRemove.Text = "<<< Remove";
                    cmdMCBack.Text = "Back";

                    lblRC20.Text = "20% of the Number:";
                    lblRCAM.Text = "Absolute Majority:";
                    lblRCAttendance.Text = "Attendance Rate";
                    lblRCGuide.Text = "Choose Attendance Status";
                    lblRCSM.Text = "Simple Majority:";
                    lblRCStatus.Text = "Roll Call not Completed";
                    cmdRCAbsent.Text = "Absent";
                    cmdRCBack.Text = "Back";
                    cmdRCPresent.Text = "Present";
                    cmdDoRC.Text = "Start Roll Call";
                    lblRCPresent.Text = "Present";
                    lblRCAbsent.Text = "Absent";

                    cmdSLAdd.Text = "Add >>>";
                    cmdSLBack.Text = "Back";
                    cmdSLClearInput.Text = "Clear Input";
                    cmdSLContinue.Text = "Resume List";
                    cmdSLRemove.Text = "<<< Remove";
                    lblSLLeft.Text = "0 Delegate Left";

                    lblSLSearch.Text = "Search:";
                    lblSLSec.Text = "Sec";
                    lblSLSetTime.Text = "Speaking Time:";
                    lblSLGuide.Text = "Use Up, Down, or Enter keys to navigate or enter. Use buttons on the left column to time.";

                    cmdVotingYes.Text = "Yes";
                    cmdVotingNo.Text = "No";
                    cmdVotingAbstain.Text = "Abstain";
                    cmdVotingPass.Text = "Pass";
                    cmdVotingBack.Text = "Back";
                    cmdStartVoting.Text = "Start Voting";
                    lblVotingFavor.Text = "Yes";
                    lblVotingAgainst.Text = "No";
                    lblVotingYes.Text = "Yes:";
                    lblVotingNo.Text = "No:";
                    lblVotingAbstain.Text = "Abstain:";
                    lblVotingRate.Text = "Favor Rate:";
                    txtPaperName.Text = "Enter Paper Name";

                    lblTimer1.Text = "Timer 1";
                    lblTimer1Min.Text = "min";
                    lblTimer1Sec.Text = "sec";
                    cmdTimer1Run.Text = "Run";
                    cmdTimer1Pause.Text = "Pause";
                    cmdTimer1Reset.Text = "Reset";
                    cmdTimer1Clear.Text = "Clear";
                    txtTimer1Title.Text = "Title";
                    lblTimer2.Text = "Timer 2";
                    lblTimer2Min.Text = "min";
                    lblTimer2Sec.Text = "sec";
                    cmdTimer2Run.Text = "Run";
                    cmdTimer2Pause.Text = "Pause";
                    cmdTimer2Reset.Text = "Reset";
                    cmdTimer2Clear.Text = "Clear";
                    txtTimer2Title.Text = "Title";
                    lblReminder1.Text = "Reminder 1";
                    cmdReminder1Clear.Text = "Clear";
                    lblReminder2.Text = "Reminder 2";
                    cmdReminder2Clear.Text = "Clear";
                    cmdTimerBack.Text = "Back";


                    lblFile.Text = "File Management";
                    cmdFileCreate.Text = "Create New";
                    cmdFileDelete.Text = "Delete";
                    cmdFileAddSignatory.Text = "Add";
                    cmdFileAddSponsor.Text = "Add";
                    cmdFileRemoveSignatory.Text = "Remove";
                    cmdFileRemoveSponsor.Text = "Remove";
                    cmdFileLocation.Text = "Location";
                    cmdFileBrowse.Text = "Browse";
                    cmdDataBack.Text = "Back";                  
                    lblData.Text = "Data";
                    lblDataMotion.Text = "Motion Raised";
                    lblDataPass.Text = "-Passed";
                    lblDataFail.Text = "-Failed";
                    lblDataSpeaking.Text = "Speaking Time";
                    lblDataSponsor.Text = "Paper Sponsored";
                    lblDataSignatory.Text = "Paper Signed";
                    cmdDataClear.Text = "Clear";
                    cmdDataText.Text = "Output Conference Progress";
                    cmdDataSaveEvents.Text = "Save Conference Progress";
                    combDataCountry.Text = "Delegate Data";

                    cmdBack.Text = "Back";




                    break;
                case 1:
                    cmdStart.Text = "开始";
                    cmdPause.Text = "暂停";
                    cmdNext.Text = "下一位";
                    cmdExpire.Text = "结束";
                    cmdMotion.Text = "动议";
                    cmdRollCall.Text = "点名程序";
                    cmdSpeaker.Text = "主发言名单";
                    cmdData.Text = "文件与数据";
                    cmdVoting.Text = "投票程序";
                    cmdTimerReminder.Text = "计时器和便笺";
                    cmdHelp.Text = "帮助";
                    lblDashboard.Text = "正在进行";
                    lblEvents.Text = "动态";

                    lblMCTips.Text = "使用方向键和回车键快速选择和添加国家，使用左上角的按钮主持磋商。";
                    lblMCSpeakers.Text = "发言名单";
                    lblEnterGuide.Text = "检索：";
                    cmdMCAdd.Text = "添加 >>>";
                    cmdMCClearInput.Text = "清空输入";
                    cmdMCRemove.Text = "<<< 移除";
                    cmdMCBack.Text = "返回";

                    lblRC20.Text = "百分之二十数：";
                    lblRCAM.Text = "绝对多数：";
                    lblRCAttendance.Text = "出席率：";
                    lblRCGuide.Text = "选择出席状态";
                    lblRCSM.Text = "简单多数：";
                    lblRCStatus.Text = "尚未完成全部点名";
                    cmdRCAbsent.Text = "缺席";
                    cmdRCBack.Text = "返回";
                    cmdRCPresent.Text = "出席";
                    cmdDoRC.Text = "开始点名";
                    lblRCPresent.Text = "出席";
                    lblRCAbsent.Text = "缺席";

                    cmdSLAdd.Text = "添加 >>>";
                    cmdSLBack.Text = "返回";
                    cmdSLClearInput.Text = "清空输入";
                    cmdSLContinue.Text = "回到名单";
                    cmdSLRemove.Text = "<<< 移除";
                    lblSLLeft.Text = "剩余0位代表";
                    lblSLSearch.Text = "检索：";
                    lblSLSec.Text = "秒";
                    lblSLSetTime.Text = "发言时间：";
                    lblSLGuide.Text = "使用方向键或回车键选择或输入，使用左上角的按钮计时。";

                    cmdVotingYes.Text = "赞成";
                    cmdVotingNo.Text = "反对";
                    cmdVotingAbstain.Text = "弃权";
                    cmdVotingPass.Text = "过";
                    cmdVotingBack.Text = "返回";
                    cmdStartVoting.Text = "开始投票";
                    lblVotingFavor.Text = "赞成";
                    lblVotingAgainst.Text = "反对";
                    lblVotingYes.Text = "赞成：";
                    lblVotingNo.Text = "反对：";
                    lblVotingAbstain.Text = "弃权：";
                    lblVotingRate.Text = "赞成率：";
                    txtPaperName.Text = "输入文件名";

                    lblTimer1.Text = "计时器1";
                    lblTimer1Min.Text = "分";
                    lblTimer1Sec.Text = "秒";
                    cmdTimer1Run.Text = "运行";
                    cmdTimer1Pause.Text = "暂停";
                    cmdTimer1Reset.Text = "重置";
                    cmdTimer1Clear.Text = "清除";
                    txtTimer1Title.Text = "标题";
                    lblTimer2.Text = "计时器2";
                    lblTimer2Min.Text = "分";
                    lblTimer2Sec.Text = "秒";
                    cmdTimer2Run.Text = "运行";
                    cmdTimer2Pause.Text = "暂停";
                    cmdTimer2Reset.Text = "重置";
                    cmdTimer2Clear.Text = "清除";
                    txtTimer2Title.Text = "标题";
                    lblReminder1.Text = "备忘录1";
                    cmdReminder1Clear.Text = "清除";
                    lblReminder2.Text = "备忘录2";
                    cmdReminder2Clear.Text = "清除";
                    cmdTimerBack.Text = "返回";


                    lblFile.Text = "文件管理";
                    cmdFileCreate.Text = "新文件";
                    cmdFileDelete.Text = "删除文件";
                    cmdFileAddSignatory.Text = "添加";
                    cmdFileAddSponsor.Text = "添加";
                    cmdFileRemoveSignatory.Text = "移除";
                    cmdFileRemoveSponsor.Text = "移除";
                    cmdFileLocation.Text = "文件位置";
                    cmdFileBrowse.Text = "浏览";
                    cmdDataBack.Text = "返回";
                    lblData.Text = "数据";
                    lblDataMotion.Text = "动议数";
                    lblDataPass.Text = "-通过数";
                    lblDataFail.Text = "-未通过数";
                    lblDataSpeaking.Text = "发言次数";
                    lblDataSponsor.Text = "文件起草数";
                    lblDataSignatory.Text = "文件附议数";
                    cmdDataClear.Text = "清空";
                    cmdDataText.Text = "导出会议进度";
                    cmdDataSaveEvents.Text = "保存会议进度";
                    combDataCountry.Text = "代表数据";

                    cmdBack.Text = "返回";
                    break;
                case 2:

                    break;


            }
        }
        private void helpPageLanguageUpdate(int givenLanguageIndex)
        {
            switch (givenLanguageIndex)
            {
                case 0:
                    helpLoad.Text = "Load Countries and Data";
                    helpAbout.Text = "About";
                    helpFile.Text = "File Management";
                    helpMC.Text = "Moderated Caucus";
                    helpMonitor.Text = "Monitor Settings";
                    helpRaise.Text = "Raise a Motion";
                    helpRoll.Text = "Roll Call";
                    helpSave.Text = "Save Data";
                    helpSpeaker.Text = "Speaker's List";
                    helpLanguage.Text = "Languages";
                    helpTimer.Text = "Timer and Reminder";
                    helpUMC.Text = "Unmoderated Caucus";
                    helpVoting.Text = "Voting Procedure";
                    lblHelp.Text = "Help";
                    break;
                case 1:
                    helpLoad.Text = "加载国家和数据";
                    helpAbout.Text = "关于";
                    helpFile.Text = "文件管理";
                    helpMC.Text = "有主持核心磋商";
                    helpMonitor.Text = "显示器设置";
                    helpRaise.Text = "提起动议";
                    helpRoll.Text = "点名程序";
                    helpSave.Text = "保存数据";
                    helpSpeaker.Text = "主发言名单";
                    helpLanguage.Text = "语言";
                    helpTimer.Text = "计时器和便笺";
                    helpUMC.Text = "自由磋商";
                    helpVoting.Text = "投票程序";
                    lblHelp.Text = "帮助";
                    break;
            }
        }

        private void timerSystemTime_Tick(object sender, EventArgs e)
        {
            lblSystemTime.Text = $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}";

        }

        private void timerSessionTime_Tick(object sender, EventArgs e)
        {
            doOneTick();
        }

        private void doOneTick()
        {
            if (timePassed < sessionLength)
            {
                timePassed++;
                mainP.barSession.Value = timePassed * 100 / sessionLength;
            }
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

        private void cmdMotion_Click(object sender, EventArgs e)
        {
            if (!votingInProgress)
            {
                if (!motionInProgress)
                {
                    if (!rollCallInProgress)
                    {
                        if (!timerSLTime.Enabled)
                        {
                            lblDash.BackColor = Color.Cyan;
                            tabControl.SelectTab(tabMotionSelection);
                        }
                        else
                        {
                            SLinProgressError();
                        }
                    }
                    else
                    {
                        rollCallInProgressError();
                    }
                }
                else
                {
                    motionInProgressError();
                }
            }
            else
            {
                votingInProgressError();
            }
        }

        private void SLinProgressError()
        {
            PopUp popUp = new PopUp(this.languageIndex, "Procedural Matter", "Pause the Timer to Continue", "程序性事项", "暂停计时器以继续", lblDash.BackColor);
            popUp.ShowDialog();
        }

        private void rollCallInProgressError()
        {
            PopUp popUp = new PopUp(this.languageIndex, "Procedural Matter", "Finish Roll Call Procedure to Continue", "程序性事项", "结束点名程序以继续", lblDash.BackColor);
            popUp.ShowDialog();
        }

        private void motionInProgressError()
        {
            PopUp popUp = new PopUp(this.languageIndex, "Procedural Matter", "Expire the Current Motion to Continue", "程序性事项", "结束当前动议以继续", lblDash.BackColor);
            popUp.ShowDialog();
        }

        private void updateContent(Motion motion)
        {
            int motionIndex = motion.motionIndex;
            string totalTime = motion.totalTime.ToString();
            string eachTime = motion.eachTime.ToString();
            string topic = motion.topic;
            switch (this.languageIndex)
            {
                case 0:
                    switch (motionIndex)
                    {
                        case 0:
                            mainP.contentUpdate("Moderated Caucus", $"{topic} ({totalTime}min, {eachTime}sec)");
                            break;
                        case 1:
                            mainP.contentUpdate("Motion", $"Unmoderated Caucus, {totalTime}min");
                            break;
                        case 2:
                            mainP.contentUpdate("Motion", $"Free Debate, {totalTime}min");
                            break;
                        case 3:
                            mainP.contentUpdate("Motion", "Suspend the Meeting");
                            break;
                        case 4:
                            mainP.contentUpdate("Motion", "Close Debate");
                            break;
                        case 5:
                            mainP.contentUpdate("Motion", topic);

                            break;
                    }
                    break;
                case 1:
                    switch (motionIndex)
                    {
                        case 0:
                            mainP.contentUpdate("有主持核心磋商", $"{ topic}（{totalTime}分钟，{eachTime}秒）");
                            break;
                        case 1:
                            mainP.contentUpdate("动议", $"自由磋商，{totalTime }分钟");
                            break;
                        case 2:
                            mainP.contentUpdate("动议", $"自由辩论，{totalTime }分钟");
                            break;
                        case 3:
                            mainP.contentUpdate("动议", "暂停会议");
                            break;
                        case 4:
                            mainP.contentUpdate("动议", "结束辩论");
                            break;
                        case 5:
                            mainP.contentUpdate("动议", topic);
                            break;
                    }
                    break;
            }
            motionSelection1.hasContentToDisplay = false;//倒下Flag
        }

        private void clearMainPage()
        {
            mainP.contentUpdate();
            mainP.nowNextUpdate();
            mainP.timeUpdate("00", "00:00");
            mainP.listCountry.Items.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabMain);
            lblDash.BackColor = Color.GreenYellow;
        }

        public void writeToData(int countryIndex, int actionIndex, string plusOrMinus)
        {
            if (countryIndex >= 0 && countryIndex<allLists.allCountry.Count && actionIndex >=0 && actionIndex <9)
            switch (plusOrMinus)
            {
                case "+":
                    data[countryIndex, actionIndex]++;
                    break;
                case "-":
                    data[countryIndex, actionIndex]--;
                    break;
            }

        }

        public void overwriteData(int countryIndex, int actionIndex, int data)
        {
            this.data[countryIndex, actionIndex] = data;
        }





        private void handleMotion1Event()
        {
            if (motionSelection1.hasContentToDisplay)
            {
                clearMainPage();
                updateContent(motionSelection1.newMotion);
                motionSelection1.hasContentToDisplay = false;
            }

            if (motionSelection1.clearTheScreen)
            {
                clearMainPage();
                motionSelection1.clearTheScreen = false;
            }

            if (motionSelection1.hasMotionToFail)
            {
                writeToData(motionSelection1.newMotion.raisedBy, 3, "+");//Failed Motion +1
                writeToData(motionSelection1.newMotion.raisedBy, 1, "+");//All Motion +1
                updateEventList(motionSelection1.newMotion);
                //重置控件
                motionSelection1.clearAndNotVisible();
                motionSelection1.combCountry.Visible = false;
                motionSelection1.languageUpdate(languageIndex);
                motionSelection1.hasMotionToFail = false;
            }

            if (motionSelection1.hasMotionToPass)
            {
                currentmotion = motionSelection1.newMotion;
                writeToData(currentmotion.raisedBy, 2, "+"); //Passed Motion +1
                writeToData(currentmotion.raisedBy, 1, "+"); //All Motion +1
                updateEventList(currentmotion);
                mcEventListLocation = listEvents.Items.Count;
                listEvents.Items.Add("");
                motionInProgress = true;
                SLinProgress = false;
                turnToRelativePage(currentmotion);

                //重置控件    
                motionSelection1.combMotionType.SelectedIndex = -1;
                motionSelection1.hasMotionToPass = false;

            }
            motionSelection1.hasEvent = false;
        }

        private void turnToRelativePage(Motion motion)
        {
            clearMainPage();
            updateContent(currentmotion);
            switch (motion.motionIndex)
            {
                case 0:
                    initializeMC(currentmotion);
                    listEvents.Items.Add("");
                    tabControl.SelectTab(tabMC);
                    lblDash.BackColor = Color.Yellow;
                    assignPush(0, "Moderated Caucus", $"{listMCSpeakers.Items.Count.ToString()} Delegate(s) Left", "有主持核心磋商", $"剩余{listMCSpeakers.Items.Count.ToString()}位代表");
                    break;
                case 1:
                    assignPush(1, "Unmoderated Caucus", $"{currentmotion.totalTime.ToString()} min", "自由磋商", $"{currentmotion.totalTime.ToString()}分钟");
                    buttonFunctionIndex = 1;
                    mainTotalTime = int.Parse((currentmotion.totalTime * 60).ToString());
                    changeTime(1, mainTotalTime);
                    tabControl.SelectTab(tabMain);
                    flashTime = 4;
                    timerFlash.Enabled = true;
                    lblDash.BackColor = Color.GreenYellow;
                    break;
                case 2:
                    assignPush(2, "Free Debate", $"{currentmotion.totalTime.ToString()} min", "自由辩论", $"{currentmotion.totalTime.ToString()}分钟");
                    buttonFunctionIndex = 2;
                    mainTotalTime = int.Parse((currentmotion.totalTime * 60).ToString());
                    changeTime(2, mainTotalTime);
                    tabControl.SelectTab(tabMain);
                    flashTime = 4;
                    timerFlash.Enabled = true;
                    lblDash.BackColor = Color.GreenYellow;
                    break;
                case 3:
                    tabControl.SelectTab(tabMain);
                    lblDash.BackColor = Color.GreenYellow;
                    motionInProgress = false;
                    break;
                case 4:
                    tabControl.SelectTab(tabMain);
                    lblDash.BackColor = Color.GreenYellow;
                    motionInProgress = false;
                    break;
                case 5:
                    tabControl.SelectTab(tabMain);
                    lblDash.BackColor = Color.GreenYellow;
                    motionInProgress = false;
                    break;
            }
        }

        private void handleMotion2Event()
        {
            if (motionSelection2.hasContentToDisplay)
            {
                clearMainPage();
                updateContent(motionSelection2.newMotion);
                motionSelection2.hasContentToDisplay = false;
            }

            if (motionSelection2.clearTheScreen)
            {
                clearMainPage();
                motionSelection2.clearTheScreen = false;
            }
            if (motionSelection2.hasMotionToFail)
            {
                writeToData(motionSelection2.newMotion.raisedBy, 3, "+");//Failed Motion +1
                writeToData(motionSelection2.newMotion.raisedBy, 1, "+");//All Motion +1
                updateEventList(motionSelection2.newMotion);
                //重置控件
                motionSelection2.clearAndNotVisible();
                motionSelection2.combCountry.Visible = false;
                motionSelection2.languageUpdate(languageIndex);
                motionSelection2.hasMotionToFail = false;
            }
            if (motionSelection2.hasMotionToPass)
            {
                currentmotion = motionSelection2.newMotion;
                writeToData(currentmotion.raisedBy, 2, "+"); //Passed Motion +1
                writeToData(currentmotion.raisedBy, 1, "+"); //All Motion +1
                updateEventList(currentmotion);
                mcEventListLocation = listEvents.Items.Count;
                listEvents.Items.Add("");
                motionInProgress = true;
                SLinProgress = false;
                turnToRelativePage(currentmotion);

                //重置控件    
                motionSelection2.combMotionType.SelectedIndex = -1;
                motionSelection2.hasMotionToPass = false;

            }
            motionSelection2.hasEvent = false;
        }
        private void handleMotion3Event()
        {
            if (motionSelection3.hasContentToDisplay)
            {
                clearMainPage();
                updateContent(motionSelection3.newMotion);
                motionSelection3.hasContentToDisplay = false;

            }

            if (motionSelection3.clearTheScreen)
            {
                clearMainPage();
                motionSelection3.clearTheScreen = false;
            }
            if (motionSelection3.hasMotionToFail)
            {
                writeToData(motionSelection3.newMotion.raisedBy, 3, "+");//Failed Motion +1
                writeToData(motionSelection3.newMotion.raisedBy, 1, "+");//All Motion +1
                updateEventList(motionSelection3.newMotion);
                //重置控件
                motionSelection3.clearAndNotVisible();
                motionSelection3.combCountry.Visible = false;
                motionSelection3.languageUpdate(languageIndex);
                motionSelection3.hasMotionToFail = false;

            }
            if (motionSelection3.hasMotionToPass)
            {
                currentmotion = motionSelection3.newMotion;
                writeToData(currentmotion.raisedBy, 2, "+"); //Passed Motion +1
                writeToData(currentmotion.raisedBy, 1, "+"); //All Motion +1
                updateEventList(currentmotion);
                mcEventListLocation = listEvents.Items.Count;
                listEvents.Items.Add("");
                motionInProgress = true;
                SLinProgress = false;
                turnToRelativePage(currentmotion);

                //重置控件    
                motionSelection3.combMotionType.SelectedIndex = -1;
                motionSelection3.hasMotionToPass = false;

            }
            motionSelection3.hasEvent = false;
        }
        private void assignPush(int linkedEventIndex, string engPrompt, string engContent, string chnPrompt, string chnContent)
        {
            if (push1.occupied)
            {
                if (push2.occupied)
                {
                    if (push3.occupied)
                    {
                        if (push4.occupied)
                        {
                            releasePush();
                            assignPush(linkedEventIndex, engPrompt, engContent, chnPrompt, chnContent);

                        }
                        else
                        {
                            push4.linkedEventIndex = linkedEventIndex;
                            push4.contentUpdate(languageIndex, engPrompt, engContent, chnPrompt, chnContent);
                        }
                    }
                    else
                    {
                        push3.linkedEventIndex = linkedEventIndex;
                        push3.contentUpdate(languageIndex, engPrompt, engContent, chnPrompt, chnContent);
                    }
                }
                else
                {
                    push2.linkedEventIndex = linkedEventIndex;
                    push2.contentUpdate(languageIndex, engPrompt, engContent, chnPrompt, chnContent);

                }
            }
            else
            {
                push1.linkedEventIndex = linkedEventIndex;
                push1.contentUpdate(languageIndex, engPrompt, engContent, chnPrompt, chnContent);
            }
        }
        public void clearMC()
        {
            listMCSpeakers.Items.Clear();
            lblMCTopic.Text = "";
            lblMCNumberLeft.Text = "";
            lblBigTime.Text = "00";
            lblSmallTime.Text = "00:00";
            lblNowNext.Text = "";
        }
        public void initializeMC(Motion motion)
        {
            clearMC();
            switch (languageIndex)
            {
                case 0:
                    lblMCTopic.Text = $"{currentmotion.topic} ({currentmotion.totalTime.ToString()}min, {currentmotion.eachTime.ToString()}sec)";
                    break;
                case 1:
                    lblMCTopic.Text = $"{currentmotion.topic}（{currentmotion.totalTime.ToString()}分钟，{currentmotion.eachTime.ToString()}秒）";

                    break;

            }
            mcSpeakerNumber = int.Parse((motion.totalTime * 60 / motion.eachTime).ToString());
            mcSpeakerLeft = mcSpeakerNumber + 1;
            mcChangeNumberLeft("-");
            mainTotalTime = int.Parse((motion.totalTime * 60).ToString());
            mainEachTime = motion.eachTime;
            changeTime(0, mainTotalTime, mainEachTime);
            buttonFunctionIndex = 0;//MC
            mcNowIndex = 0;
            mcNextIndex = 1;
            mcNowNextUpdate(mcNowIndex, mcNextIndex);
            allowMore = false;
            numberAllowedMore = 0;
            lblDash.BackColor = Color.Yellow;
        }
        private void mcChangeNumberLeft(string plusOrMinus)
        {
            if (listMCSpeakers.Items.Count >= mcSpeakerNumber)
            {
                mcSpeakerLeft = 0;
            }
            else
            {
                switch (plusOrMinus)
                {
                    case "+":
                        mcSpeakerLeft++;
                        break;
                    case "-":
                        mcSpeakerLeft--;
                        break;

                }
            }

            switch (languageIndex)
            {
                case 0:
                    lblMCNumberLeft.Text = $"{mcSpeakerLeft}/{mcSpeakerNumber} Delegate(s) Left";
                    break;
                case 1:
                    lblMCNumberLeft.Text = $"剩余{mcSpeakerLeft}/{mcSpeakerNumber}位代表";
                    break;

            }
        }

        private void changeTime(int motionIndex, int totalTimeSec = 0, int eachTimeSec = 0)
        {
            string bigTime = "";
            string smallTime = "";
            int minute = totalTimeSec / 60;
            int second = totalTimeSec % 60;
            switch (motionIndex)
            {
                case 0:
                    if (eachTimeSec < 10)
                    {
                        bigTime = $"0{eachTimeSec.ToString()}";
                    }
                    else
                    {
                        bigTime = eachTimeSec.ToString();
                    }

                    if (minute < 10)
                        smallTime += $"0{minute.ToString()}:";
                    else
                        smallTime += $"{minute.ToString()}:";
                    if (second < 10)
                        smallTime += $"0{second.ToString()}";
                    else
                        smallTime += second.ToString();


                    break;
                case 1:
                    bigTime = "00";
                    lblNowNext.Text = multilingual("Unmoderated Caucus", "自由磋商");
                    if (minute < 10)
                        smallTime = $"0{minute.ToString()}";
                    else
                        smallTime = minute.ToString();

                    if (second < 10)
                        smallTime += $":0{second.ToString()}";
                    else
                        smallTime += $":{second.ToString()}";


                    break;
                case 2:
                    bigTime = "00";
                    lblNowNext.Text = multilingual("Free Debate", "自由辩论");
                    if (minute < 10)
                        smallTime = $"0{minute.ToString()}";
                    else
                        smallTime = minute.ToString();

                    if (second < 10)
                        smallTime += $":0{second.ToString()}";
                    else
                        smallTime += $":{second.ToString()}";


                    break;


            }
            lblBigTime.Text = bigTime;
            lblSmallTime.Text = smallTime;
            mainP.timeUpdate(lblBigTime.Text, lblSmallTime.Text);
        }

        private void timerMainTime_Tick(object sender, EventArgs e)
        {

            if (currentmotion.motionIndex == 0)
            {
                if (mainEachTime > 0)
                {
                    mainTotalTime--;
                    mainEachTime--;
                    changeTime(currentmotion.motionIndex, mainTotalTime, mainEachTime);
                }
                else
                {
                    timerMainTime.Enabled = false;
                    timeIsUp(0);
                    
                }
            }
            else
            {
                if (mainTotalTime > 0)
                {
                    mainTotalTime--;
                    changeTime(currentmotion.motionIndex, mainTotalTime);
                }
                else
                {
                    timerMainTime.Enabled = false;
                    timeIsUp(currentmotion.motionIndex);                  
                }
            }

        }

        private void timeIsUp(int actionIndex)
        {
            switch (actionIndex)
            {
                case 0:
                    break;
                case 1:
                    PopUp pop = new PopUp(languageIndex, "Unmoderated Caucus", "Time is up. Click on Expire to expire the motion.", "自由磋商", "时间到。单击“结束”以结束。", lblDash.BackColor);
                    pop.ShowDialog();
                    break;
                case 2:
                    PopUp pop2 = new PopUp(languageIndex, "Free Debate", "Time is up. Click on Expire to expire the motion.", "自由辩论", "时间到。单击“结束”以结束。", lblDash.BackColor);
                    pop2.ShowDialog();
                    break;

            }
        }

        private void cmdMCClearInput_Click(object sender, EventArgs e)
        {
            txtEnterToMC.Text = "";
        }

        private void cmdMCAdd_Click(object sender, EventArgs e)
        {
            if ((mcSpeakerLeft > 0) | (allowMore && numberAllowedMore > 0))
            {
                int temp = allLists.allCountry.IndexOf(listMCCountry.SelectedItem.ToString());
                writeToData(temp, 4, "+");
                allLists.mcCountryName.Add(listMCCountry.SelectedItem.ToString());
                listMCSpeakers.Items.Add(listMCCountry.SelectedItem.ToString());
                mcNowNextUpdate(mcNowIndex, mcNextIndex);
                updatePush(0, "Moderated Caucus", $"{(listMCSpeakers.Items.Count - mcNowIndex).ToString()} Delegate(s) Left", "有主持核心磋商", $"剩余{(listMCSpeakers.Items.Count - mcNowIndex).ToString()}位代表");
                
                mainP.listAdd(listMCCountry.SelectedItem.ToString());
                mainP.listCountry.SelectedIndex = mcNowIndex;
                mcChangeNumberLeft("-");
                if (numberAllowedMore > 0)
                {
                    numberAllowedMore--;

                }
            }
            else
            {
                PopUp popUp = new PopUp(languageIndex, "Procedural Matter", "Number of speakers has reached maximum. Cannot add more delegate currently.", "程序性事项", "人数已达上限，暂时无法添加更多代表。", lblMCDash.BackColor);
                popUp.ShowDialog();
            }
        }



        private void cmdMCRemove_Click(object sender, EventArgs e)
        {
            if (listMCSpeakers.SelectedIndex >= mcNowIndex)
            {
                if (!(listMCSpeakers.SelectedItem.ToString() == mainP.lblNowCountry.Text && int.Parse(lblBigTime.Text) < currentmotion.eachTime))
                {
                    allLists.mcCountryName.RemoveAt(listMCSpeakers.SelectedIndex);
                    int temp = allLists.allCountry.IndexOf(listMCSpeakers.SelectedItem.ToString());
                    writeToData(temp, 4, "-");
                    mainP.listRemove(listMCSpeakers.SelectedItem.ToString());
                    listMCSpeakers.Items.Remove(listMCSpeakers.SelectedItem);
                    mcNowNextUpdate(mcNowIndex, mcNextIndex);
                    mcChangeNumberLeft("+");
                    updatePush(0, "Moderated Caucus", $"{(listMCSpeakers.Items.Count - mcNowIndex).ToString()} Delegate(s) Left", "有主持核心磋商", $"剩余{(listMCSpeakers.Items.Count - mcNowIndex).ToString()}位代表");


                }
                else
                {
                    PopUp popUp = new PopUp(languageIndex, "Procedural Matter", "Cannot remove a delegate holding the floor.", "程序性事项", "无法移除发言中的代表。", lblMCDash.BackColor);
                    popUp.ShowDialog();
                }
            }
            else
            {
                PopUp popUp = new PopUp(languageIndex, "Procedural Matter", "Cannot remove a delegate who has addressed to the committee in this moderated caucus.", "程序性事项", "无法移除在该有主持核心磋商中已经发言完毕的代表。", lblMCDash.BackColor);
                popUp.ShowDialog();
            }
        }

        private void checkAvailableTime()
        {
            if ((mainTotalTime >= mainEachTime) && !allowMore)
            {
                allowMore = true;
                numberAllowedMore = mainTotalTime / mainEachTime;
                PopUp popUp = new PopUp(languageIndex, "Procedural Matter", $"Time is available for {numberAllowedMore} more delegate(s)", "程序性事项", $"时间可再供{mainTotalTime / mainEachTime}位代表发言", lblMCDash.BackColor);
                popUp.ShowDialog();
                tabControl.SelectTab(tabMC);


            }
            else
            {
                expireCurrentMotion();
            }

        }



        private void listMCCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listMCCountry.SelectedIndex != -1)
            {
                cmdMCAdd.Enabled = true;
            }
            else
            {
                cmdMCAdd.Enabled = false;
            }
        }

        private void txtEnterToMC_TextChanged(object sender, EventArgs e)
        {
            if (txtEnterToMC.Text == "")//When the input is clear, show a list of all countries
            {
                listMCCountry.Items.Clear();
                for (int i = 0; i < allLists.allCountry.Count; i++)
                {
                    listMCCountry.Items.Add(allLists.allCountry[i]);
                }
                listMCCountry.SelectedIndex = -1;
            }
            else
            {
                listMCCountry.Items.Clear();
                string match1 = txtEnterToMC.Text.ToUpper(); //Convert all letters to upper for comparison.
                for (int i = 0; i < allLists.allCountryUpper.Count; i++)//Find all match with input
                {
                    if (allLists.allCountryUpper[i].Length >= match1.Length)
                    {
                        if (allLists.allCountryUpper[i].Substring(0, match1.Length) == match1)
                        {
                            listMCCountry.Items.Add(allLists.allCountry[i]);
                        }
                    }
                }
                if (listMCCountry.Items.Count > 0)
                {
                    listMCCountry.SelectedIndex = 0;//Set focus on the first country to wait for user's further selection
                }
                else
                {
                    listMCCountry.SelectedIndex = -1;
                    cmdMCAdd.Enabled = false;
                }
            }
        }

        private void txtEnterToMC_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void listMCSpeakers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listMCSpeakers.SelectedIndex > -1)
            {
                cmdMCRemove.Enabled = true;

            }
            else
            {
                cmdMCRemove.Enabled = false;
            }
        }

        private void listMCCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            if (notingInProgress())
            {
                switch (buttonFunctionIndex)
                {
                    case 0:
                        timerMainTime.Enabled = false;

                        mainEachTime = currentmotion.eachTime;
                        changeTime(0, mainTotalTime, mainEachTime);

                        mcNowIndex++;
                        mcNextIndex++;
                        
                        updatePush(0, "Moderated Caucus", $"{(listMCSpeakers.Items.Count - mcNowIndex).ToString()} Delegate(s) Left", "有主持核心磋商", $"剩余{(listMCSpeakers.Items.Count - mcNowIndex).ToString()}位代表");
                        if (mcNowIndex < listMCSpeakers.Items.Count)
                        {
                            mcNowNextUpdate(mcNowIndex, mcNextIndex);
                            mainP.listCountry.SelectedIndex = mcNowIndex;
                            listMCSpeakers.SelectedIndex = mcNowIndex;
                        }
                        else
                        {
                            mcNowNextUpdate();
                            checkAvailableTime();
                        }
                        break;
                    case 3:
                        timerSLTime.Enabled = false;
                        if (listSLSpeakers.Items.Count > 0)
                        {
                            SLLeft--;
                            SLLeftUpdate();
                            writeToData(allLists.allCountry.IndexOf(listSLSpeakers.Items[0].ToString()), 4, "+");
                            allLists.speakersList.RemoveAt(0);
                            listSLSpeakers.Items.RemoveAt(0);
                            updatePush(4, "Speaker's List", lblSLLeft.Text, "主发言名单", lblSLLeft.Text);
                            SLEachTime = SLTime;
                            if (SLinProgress)
                            {
                                SLNowNextUpdate();
                                lblBigTime.Text = SLEachTime.ToString();
                                mainP.lblBigTime.Text = lblBigTime.Text;

                            }
                            if (listSLSpeakers.Items.Count == 0)
                            {
                                PopUp popUp = new PopUp(languageIndex, "List Over", "No more speakers in the speaker's list", "名单结束", "主发言名单中已无更多国家", lblDash.BackColor);
                                popUp.ShowDialog();
                            }
                            else
                            {

                            }
                        }
                        break;
                    case -1:
                        flashTime = 4;
                        timerFlash.Enabled = true;
                        break;
                }
            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabMain);
            lblDash.BackColor = Color.GreenYellow;
        }

        private void mcNowNextUpdate(int now = -1, int next = -1)
        {
            if ((listMCSpeakers.Items.Count > now) && (now < next))
            {
                switch (languageIndex)
                {
                    case 0:
                        lblNowNext.Text = "Now: " + listMCSpeakers.Items[now].ToString() + Environment.NewLine + "Next: ";
                        break;
                    case 1:
                        lblNowNext.Text = "当前：" + listMCSpeakers.Items[now].ToString() + Environment.NewLine + "下一位：";
                        break;
                }
                mainP.nowUpdate(listMCSpeakers.Items[now].ToString());
            }
            else
            {
                switch (languageIndex)
                {
                    case 0:
                        lblNowNext.Text = "Now: " + Environment.NewLine + "Next: ";
                        break;
                    case 1:
                        lblNowNext.Text = "当前：" + Environment.NewLine + "下一位：";
                        break;
                }
                mainP.nowNextUpdate();
            }

            if ((listMCSpeakers.Items.Count > next) && (next != -1))
            {
                lblNowNext.Text += listMCSpeakers.Items[next].ToString();
                mainP.nextUpdate(listMCSpeakers.Items[next].ToString());
            }
            else
            {
                mainP.lblNextCountry.Text = "";
            }
        }

        private void cmdPause_Click(object sender, EventArgs e)
        {
            if (notingInProgress())
            {
                switch (buttonFunctionIndex)
                {
                    case 3:
                        timerSLTime.Enabled = false;
                        break;
                    default:
                        timerMainTime.Enabled = false;
                        break;


                }
            }

        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            if (notingInProgress())
            {
                timerFlash.Enabled = false;
                cmdStart.BackColor = Color.FromArgb(64, 64, 64);
                switch (buttonFunctionIndex)
                {
                    case 0://MC
                        if (mcNowIndex < listMCSpeakers.Items.Count)
                        {
                            timerMainTime.Enabled = true;
                            mainP.listCountry.SelectedIndex = mcNowIndex;
                        }
                        break;
                    case 1://UMC
                        timerMainTime.Enabled = true;
                        break;
                    case 2://FD
                        timerMainTime.Enabled = true;
                        break;
                    case 3://SL
                        if (listSLSpeakers.Items.Count > 0)
                        {
                            mainP.lblBigTime.Text = SLEachTime.ToString();
                            timerSLTime.Enabled = true;
                            SLinProgress = true;
                            SLNowNextUpdate();

                        }
                        break;
                    case -1:
                        if (tabControl.SelectedTab ==tabSpeaker)
                        {
                            flashTime = 4;
                            timerFlash.Enabled = true;
                        }
                        break;
                }
            }

        }

        private bool notingInProgress()
        {
            if (!votingInProgress && !rollCallInProgress && tabControl.SelectedTab != tabMotionSelection)
            {
                return true;
            }
            else
            {
                if (votingInProgress)
                {
                    votingInProgressError();
                    return false;
                }
                if (rollCallInProgress)
                {
                    rollCallInProgressError();
                    return false;
                }
                if (tabControl.SelectedTab == tabMotionSelection)
                {
                    tabControl.SelectTab(tabMain);
                    clearMainPage();
                    motionSelection1.languageUpdate(languageIndex);
                    motionSelection1.combMotionType.SelectedIndex = -1;
                    motionSelection2.languageUpdate(languageIndex);
                    motionSelection2.combMotionType.SelectedIndex = -1;
                    motionSelection3.languageUpdate(languageIndex);
                    motionSelection3.combMotionType.SelectedIndex = -1;

                    lblDash.BackColor = Color.GreenYellow;
                    return true;
                }
                return false;
            }
        }

        private void expireCurrentMotion()
        {
            if (motionInProgress)
            {
                motionInProgress = false;
                clearMainPage();
                switch (currentmotion.motionIndex)
                {
                    case 0:
                        clearMC();
                        updateEventList(mcEventListLocation, allLists.mcCountryName);
                        timerMainTime.Enabled = false;
                        clearMainPage();
                        changeTime(0);
                        mcNowNextUpdate();
                        allLists.mcCountryName.Clear();
                        allowMore = false;
                        numberAllowedMore = 0;
                        reassignPush(0);
                        break;
                    case 1:
                        clearMainPage();
                        timerMainTime.Enabled = false;
                        reassignPush(1);
                        changeTime(0);
                        mainTotalTime = 0;
                        cmdStart.Enabled = true;
                        break;
                    case 2:
                        clearMainPage();
                        timerMainTime.Enabled = false;
                        reassignPush(2);
                        changeTime(0);
                        mainTotalTime = 0;
                        cmdStart.Enabled = true;
                        break;

                }
                tabControl.SelectTab(tabMain);
                lblDash.BackColor = Color.GreenYellow;
                buttonFunctionIndex = -1;

                lblNowNext.Text = "VMUN";
            }
        }

        private void cmdExpire_Click(object sender, EventArgs e)
        {
            if (motionInProgress)
            {
                if (currentmotion.motionIndex == 0 | mainTotalTime !=0)
                {
                    MessageBoxButtons msgb = MessageBoxButtons.YesNo;
                    switch (languageIndex)
                    {
                        case 0:
                            DialogResult resultEng = MessageBox.Show("Are you sure to expire the current motion?", "Warning", msgb);
                            if (resultEng == DialogResult.Yes)
                            {
                                expireCurrentMotion();
                            }

                            break;
                        case 1:
                            DialogResult resultChn = MessageBox.Show("是否结束当前动议？", "警告", msgb);
                            if (resultChn == DialogResult.Yes)
                            {
                                expireCurrentMotion();
                            }
                            break;
                    }
                }
                else
                {
                    if (!timerMainTime.Enabled && mainTotalTime ==0)
                    {
                        expireCurrentMotion();
                    }
                }
            }
        }

        private void txtEnterToMC_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
            {
                if (listMCCountry.SelectedIndex > -1)
                {
                    cmdMCAdd.Enabled = true;
                    cmdMCAdd_Click(sender, e);
                    txtEnterToMC.Text = "";
                }
                else
                {
                    cmdMCAdd.Enabled = false;
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (listMCCountry.SelectedIndex > 0)
                {
                    listMCCountry.SelectedIndex--;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (listMCCountry.Items.Count > listMCCountry.SelectedIndex + 1)
                {
                    listMCCountry.SelectedIndex++;
                }
            }
            
        }

        private void listMCCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                /*if (listMCCountry.SelectedIndex > -1)
                {
                    cmdMCAdd.Enabled = true;
                    cmdMCAdd_Click(sender, e);
                    txtEnterToMC.Text = "";
                }
                else
                {
                    cmdMCAdd.Enabled = false;
                */
                txtEnterToMC_KeyDown(sender, e);
            }
            /*if (e.KeyCode == Keys.Up)
            {
                if (listMCCountry.SelectedIndex > 0)
                {
                    listMCCountry.SelectedIndex--;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (listMCCountry.Items.Count > listMCCountry.SelectedIndex + 1)
                {
                    listMCCountry.SelectedIndex++;
                }
            }
            */
        }

        private void updatePush(int linkedEventIndex, string engPrompt, string engContent, string chnPrompt, string chnContent)
        {
            if (push1.linkedEventIndex == linkedEventIndex)
            {
                push1.contentUpdate(this.languageIndex, engPrompt, engContent, chnPrompt, chnContent);
            }
            else
            {
                if (push2.linkedEventIndex == linkedEventIndex)
                {
                    push2.contentUpdate(this.languageIndex, engPrompt, engContent, chnPrompt, chnContent);
                }
                else
                {
                    if (push3.linkedEventIndex == linkedEventIndex)
                    {
                        push3.contentUpdate(this.languageIndex, engPrompt, engContent, chnPrompt, chnContent);
                    }
                    else
                    {
                        push4.contentUpdate(this.languageIndex, engPrompt, engContent, chnPrompt, chnContent);
                    }
                }
            }
        }

        private void push1_Load(object sender, EventArgs e)
        {

        }




        private void reassignPush(int linkedEventIndex)
        {
            if (push1.linkedEventIndex == linkedEventIndex)
            {
                push1.reset();
            }
            else
            {
                if (push2.linkedEventIndex == linkedEventIndex)
                {
                    push2.reset();
                }
                else
                {
                    if (push3.linkedEventIndex == linkedEventIndex)
                    {
                        push3.reset();
                    }
                    else
                    {
                        push4.reset();
                    }
                }
            }

            if (push1.occupied)
            {
                if (push2.occupied)
                {
                    if (push3.occupied)
                    {
                        if (push4.occupied)
                        {

                        } else
                        {
                            push4.reset();
                        }

                    }
                    else
                    {
                        push3.occupied = push4.occupied;
                        push3.linkedEventIndex = push4.linkedEventIndex;
                        push3.lblEventName.Text = push4.lblEventName.Text;
                        push3.lblContent.Text = push4.lblContent.Text;
                        push4.reset();
                        push3.changePushVisibility();
                    }
                }
                else
                {
                    push2.occupied = push3.occupied;
                    push2.linkedEventIndex = push3.linkedEventIndex;
                    push2.lblEventName.Text = push3.lblEventName.Text;
                    push2.lblContent.Text = push3.lblContent.Text;
                    push3.occupied = push4.occupied;
                    push3.linkedEventIndex = push4.linkedEventIndex;
                    push3.lblEventName.Text = push4.lblEventName.Text;
                    push3.lblContent.Text = push4.lblContent.Text;
                    push4.reset();
                    push2.changePushVisibility();
                    push3.changePushVisibility();
                }
            }
            else
            {
                push1.occupied = push2.occupied;
                push1.linkedEventIndex = push2.linkedEventIndex;
                push1.lblEventName.Text = push2.lblEventName.Text;
                push1.lblContent.Text = push2.lblContent.Text;
                push2.occupied = push3.occupied;
                push2.linkedEventIndex = push3.linkedEventIndex;
                push2.lblEventName.Text = push3.lblEventName.Text;
                push2.lblContent.Text = push3.lblContent.Text;
                push3.occupied = push4.occupied;
                push3.linkedEventIndex = push4.linkedEventIndex;
                push3.lblEventName.Text = push4.lblEventName.Text;
                push3.lblContent.Text = push4.lblContent.Text;
                push4.reset();
                push1.changePushVisibility();
                push2.changePushVisibility();
                push3.changePushVisibility();
            }
        }



        private void releasePush()
        {
            if (push1.linkedEventIndex == 5 | push1.linkedEventIndex == 6)
            {
                push1.reset();
            }
            else
            {
                if (push2.linkedEventIndex == 5 | push2.linkedEventIndex == 6)
                {
                    push2.reset();
                }
                else
                {
                    if (push3.linkedEventIndex == 5 | push3.linkedEventIndex == 6)
                    {
                        push3.reset();
                    }
                    else
                    {
                        push4.reset();
                    }
                }
            }
        }

        private void push1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void push1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void push1_Load_1(object sender, EventArgs e)
        {

        }

        private void push1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void push1_Click_1(object sender, EventArgs e)
        {
            switch (push1.linkedEventIndex)
            {
                case 0://MC
                    tabControl.SelectTab(tabMC);
                    lblDash.BackColor = Color.Yellow;
                    break;
                case 1://UMC
                    PopUp popUpUMC = new PopUp(languageIndex, $"Unmoderated Caucus ({currentmotion.totalTime.ToString()}min)", $"Raised by: {allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}Submit Time: {currentmotion.submitTime.ToShortTimeString()}", $"自由磋商（{currentmotion.totalTime.ToString()}分钟）", $"动议者：{allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}提交时间：{currentmotion.submitTime.ToShortTimeString()}", lblDash.BackColor);
                    popUpUMC.Show();
                    break;
                case 2://FD
                    PopUp popUpFD = new PopUp(languageIndex, $"Free Debate ({currentmotion.totalTime.ToString()}min)", $"Raised by: {allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}Submit Time: {currentmotion.submitTime.ToShortTimeString()}", $"自由辩论（{currentmotion.totalTime.ToString()}分钟）", $"动议者：{allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}提交时间：{currentmotion.submitTime.ToShortTimeString()}", lblDash.BackColor);
                    popUpFD.Show();
                    break;
                case 3://Others
                    PopUp popUpOthers = new PopUp(languageIndex, currentmotion.topic, $"Raised by: {allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}Submit Time: {currentmotion.submitTime.ToShortTimeString()}", currentmotion.topic, $"动议者：{allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}提交时间：{currentmotion.submitTime.ToShortTimeString()}", lblDash.BackColor);
                    popUpOthers.Show();
                    break;
                case 4://SL
                    tabControl.SelectTab(tabSpeaker);
                    lblDash.BackColor = lblSLLowerDash.BackColor;
                    if (!SLinProgress && !motionInProgress && !rollCallInProgress && !votingInProgress)
                    {
                        flashTime = 4;
                        timerFlash.Enabled = true;
                    }
                    break;
                case 5://MemoTimer 1
                    tabControl.SelectTab(tabTimerMemo);
                    lblDash.BackColor = lblTimerDash.BackColor;
                    break;
                case 6://MemoTimer 2
                    tabControl.SelectTab(tabTimerMemo);
                    lblDash.BackColor = lblTimerDash.BackColor;
                    break;
                case 7://RC
                    tabControl.SelectTab(tabRollCall);
                    lblDash.BackColor = lblRCDash.BackColor;
                    break;
                case 8:
                    tabControl.SelectTab(tabVoting);
                    lblDash.BackColor = lblVotingDash.BackColor;
                    break;
            }
            push1.clicked = false;
        }

        private void push2_Click_1(object sender, EventArgs e)
        {
            switch (push2.linkedEventIndex)
            {
                case 0://MC
                    tabControl.SelectTab(tabMC);
                    lblDash.BackColor = Color.Yellow;
                    break;
                case 1://UMC
                    PopUp popUpUMC = new PopUp(languageIndex, $"Unmoderated Caucus ({currentmotion.totalTime.ToString()}min)", $"Raised by: {allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}Submit Time: {currentmotion.submitTime.ToShortTimeString()}", $"自由磋商（{currentmotion.totalTime.ToString()}分钟）", $"动议者：{allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}提交时间：{currentmotion.submitTime.ToShortTimeString()}", lblDash.BackColor);
                    popUpUMC.Show();
                    break;
                case 2://FD
                    PopUp popUpFD = new PopUp(languageIndex, $"Free Debate ({currentmotion.totalTime.ToString()}min)", $"Raised by: {allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}Submit Time: {currentmotion.submitTime.ToShortTimeString()}", $"自由辩论（{currentmotion.totalTime.ToString()}分钟）", $"动议者：{allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}提交时间：{currentmotion.submitTime.ToShortTimeString()}", lblDash.BackColor);
                    popUpFD.Show();
                    break;
                case 3://Others
                    PopUp popUpOthers = new PopUp(languageIndex, currentmotion.topic, $"Raised by: {allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}Submit Time: {currentmotion.submitTime.ToShortTimeString()}", currentmotion.topic, $"动议者：{allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}提交时间：{currentmotion.submitTime.ToShortTimeString()}", lblDash.BackColor);
                    popUpOthers.Show();
                    break;
                case 4://SL
                    tabControl.SelectTab(tabSpeaker);
                    lblDash.BackColor = lblSLLowerDash.BackColor;
                    if (!SLinProgress && !motionInProgress && !rollCallInProgress && !votingInProgress)
                    {
                        flashTime = 4;
                        timerFlash.Enabled = true;
                    }
                    break;
                case 5://MemoTimer 1
                    tabControl.SelectTab(tabTimerMemo);
                    lblDash.BackColor = lblTimerDash.BackColor;
                    break;
                case 6://MemoTimer 2
                    tabControl.SelectTab(tabTimerMemo);
                    lblDash.BackColor = lblTimerDash.BackColor;
                    break;
                case 7://RC
                    tabControl.SelectTab(tabRollCall);
                    lblDash.BackColor = lblRCDash.BackColor;
                    break;
                case 8:
                    tabControl.SelectTab(tabVoting);
                    lblDash.BackColor = lblVotingDash.BackColor;
                    break;
            }
            push2.clicked = false;
        }

        private void push3_Click_1(object sender, EventArgs e)
        {
            switch (push3.linkedEventIndex)
            {
                case 0://MC
                    tabControl.SelectTab(tabMC);
                    lblDash.BackColor = Color.Yellow;
                    break;
                case 1://UMC
                    PopUp popUpUMC = new PopUp(languageIndex, $"Unmoderated Caucus ({currentmotion.totalTime.ToString()}min)", $"Raised by: {allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}Submit Time: {currentmotion.submitTime.ToShortTimeString()}", $"自由磋商（{currentmotion.totalTime.ToString()}分钟）", $"动议者：{allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}提交时间：{currentmotion.submitTime.ToShortTimeString()}", lblDash.BackColor);
                    popUpUMC.Show();
                    break;
                case 2://FD
                    PopUp popUpFD = new PopUp(languageIndex, $"Free Debate ({currentmotion.totalTime.ToString()}min)", $"Raised by: {allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}Submit Time: {currentmotion.submitTime.ToShortTimeString()}", $"自由辩论（{currentmotion.totalTime.ToString()}分钟）", $"动议者：{allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}提交时间：{currentmotion.submitTime.ToShortTimeString()}", lblDash.BackColor);
                    popUpFD.Show();
                    break;
                case 3://Others
                    PopUp popUpOthers = new PopUp(languageIndex, currentmotion.topic, $"Raised by: {allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}Submit Time: {currentmotion.submitTime.ToShortTimeString()}", currentmotion.topic, $"动议者：{allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}提交时间：{currentmotion.submitTime.ToShortTimeString()}", lblDash.BackColor);
                    popUpOthers.Show();
                    break;
                case 4://SL
                    tabControl.SelectTab(tabSpeaker);
                    lblDash.BackColor = lblSLLowerDash.BackColor;
                    if (!SLinProgress && !motionInProgress && !rollCallInProgress && !votingInProgress)
                    {
                        flashTime = 4;
                        timerFlash.Enabled = true;
                    }
                    break;
                case 5://MemoTimer 1
                    tabControl.SelectTab(tabTimerMemo);
                    lblDash.BackColor = lblTimerDash.BackColor;
                    break;
                case 6://MemoTimer 2
                    tabControl.SelectTab(tabTimerMemo);
                    lblDash.BackColor = lblTimerDash.BackColor;
                    break;
                case 7://RC
                    tabControl.SelectTab(tabRollCall);
                    lblDash.BackColor = lblRCDash.BackColor;
                    break;
                case 8:
                    tabControl.SelectTab(tabVoting);
                    lblDash.BackColor = lblVotingDash.BackColor;
                    break;
            }
            push3.clicked = false;
        }

        private void push4_Click_1(object sender, EventArgs e)
        {
            switch (push4.linkedEventIndex)
            {
                case 0://MC
                    tabControl.SelectTab(tabMC);
                    lblDash.BackColor = Color.Yellow;
                    break;
                case 1://UMC
                    PopUp popUpUMC = new PopUp(languageIndex, $"Unmoderated Caucus ({currentmotion.totalTime.ToString()}min)", $"Raised by: {allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}Submit Time: {currentmotion.submitTime.ToShortTimeString()}", $"自由磋商（{currentmotion.totalTime.ToString()}分钟）", $"动议者：{allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}提交时间：{currentmotion.submitTime.ToShortTimeString()}", lblDash.BackColor);
                    popUpUMC.Show();
                    break;
                case 2://FD
                    PopUp popUpFD = new PopUp(languageIndex, $"Free Debate ({currentmotion.totalTime.ToString()}min)", $"Raised by: {allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}Submit Time: {currentmotion.submitTime.ToShortTimeString()}", $"自由辩论（{currentmotion.totalTime.ToString()}分钟）", $"动议者：{allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}提交时间：{currentmotion.submitTime.ToShortTimeString()}", lblDash.BackColor);
                    popUpFD.Show();
                    break;
                case 3://Others
                    PopUp popUpOthers = new PopUp(languageIndex, currentmotion.topic, $"Raised by: {allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}Submit Time: {currentmotion.submitTime.ToShortTimeString()}", currentmotion.topic, $"动议者：{allLists.allCountry[currentmotion.raisedBy]}{Environment.NewLine}提交时间：{currentmotion.submitTime.ToShortTimeString()}", lblDash.BackColor);
                    popUpOthers.Show();
                    break;
                case 4://SL
                    if (!SLinProgress && !motionInProgress && !rollCallInProgress && !votingInProgress)
                    {
                        flashTime = 4;
                        timerFlash.Enabled = true;
                    }
                    break;
                case 5://MemoTimer 1
                    tabControl.SelectTab(tabTimerMemo);
                    lblDash.BackColor = lblTimerDash.BackColor;
                    break;
                case 6://MemoTimer 2
                    tabControl.SelectTab(tabTimerMemo);
                    lblDash.BackColor = lblTimerDash.BackColor;
                    break;
                case 7://RC
                    tabControl.SelectTab(tabRollCall);
                    lblDash.BackColor = lblRCDash.BackColor;
                    break;
                case 8:
                    tabControl.SelectTab(tabVoting);
                    lblDash.BackColor = lblVotingDash.BackColor;
                    break;
            }
            push4.clicked = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmdDoRC_Click(object sender, EventArgs e)
        {
            timerFlash.Enabled = false;
            cmdDoRC.BackColor = Color.FromArgb(64, 64, 64);
            if (!votingInProgress)
            {
                if (!motionInProgress)
                {
                    if (!timerSLTime.Enabled)
                    {
                        if (!rollCallInProgress)
                        {                           
                            for (int i = 0;i<preservedRecord.GetLength(0);i++)
                            {
                                preservedRecord[i] = data[i, 8];
                                listRCCountry.Items[i] = $"? {allLists.allCountry[i]}";
                            }
                            preservedPrompt = lblRCStatus.Text;

                            clearMainPage();
                            SLinProgress = false;
                            listRCCountry.SelectionMode = SelectionMode.One;
                            mainP.listUpdate(allLists.allCountry);
                            rollCallInProgress = true;
                            assignPush(7, "Roll Call", $"{listRCCountry.Items.Count} Delegate(s) Left", "点名程序", $"剩余{listRCCountry.Items.Count}位代表");
                            listRCCountry.SelectedIndex = 0;
                            rcTitleUpdate("Roll Call in Progress", "点名进行中");
                            rcNowIndex = 0;
                            rcNextIndex = 1;
                            present = 0;
                            absent = 0;
                            unknown = 0;
                            mainP.nowNextUpdate(allLists.allCountry[rcNowIndex], allLists.allCountry[rcNextIndex]);
                            mainP.contentUpdate2("Roll Call", "Roll Call In Progress", "点名程序", "点名进行中");
                            cmdRCPresent.Enabled = true;
                            cmdRCAbsent.Enabled = true;
                            mainP.nowUpdate(allLists.allCountry[rcNowIndex]);
                            mainP.nextUpdate(allLists.allCountry[rcNextIndex]);
                            lblRCGuide.Text = multilingual("Choose Attendence Status", "选择出席情况");
                            cmdDoRC.Text = multilingual("Cancel Roll Call", "取消点名");
                        }
                        else
                        {
                            rollCallInProgress = false;
                            clearMainPage();
                            rcNowIndex = 0;
                            rcNextIndex = 1;
                            
                            reassignPush(7);
                            for (int i = 0;i<preservedRecord.GetLength(0);i++)
                            {
                                data[i, 8] = preservedRecord[i];
                            }
                            calculate();
                            for (int i = 0;i<listRCCountry.Items.Count;i++)
                            {
                                switch (data[i,8])
                                {
                                    case -1:
                                        listRCCountry.Items[i] = $"× {allLists.allCountry[i]}";
                                        break;
                                    case 0:
                                        listRCCountry.Items[i] = $"? {allLists.allCountry[i]}";
                                        break;
                                    case 1:
                                        listRCCountry.Items[i] = $"√ {allLists.allCountry[i]}";
                                        break;
                                }
                            }
                            listRCCountry.SelectedIndex = 0;
                            cmdDoRC.Text = multilingual("Start Roll Call", "开始点名");
                            lblRCStatus.Text = preservedPrompt;
                        }
                    }
                    else
                    {
                        SLinProgressError();
                    }
                }
                else
                {
                    motionInProgressError();
                }
            }
            else
            {
                votingInProgressError();
            }
        }

        private void rcTitleUpdate(string eng, string chn)
        {
            switch (languageIndex)
            {
                case 0:
                    lblRCStatus.Text = eng;
                    break;
                case 1:
                    lblRCStatus.Text = chn;
                    break;

            }
        }

        private void listRCCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listRCCountry.SelectedIndex > -1)
            {
                lblRCCountry.Text = allLists.allCountry[listRCCountry.SelectedIndex];
                switch (data[listRCCountry.SelectedIndex, 8])
                {
                    case 0:
                        lblRCStatusSign.Text = "?";
                        break;
                    case 1:
                        lblRCStatusSign.Text = "✔";
                        break;
                    case -1:
                        lblRCStatusSign.Text = "✘";
                        break;

                }
                if (!rollCallInProgress)
                {
                    switch (languageIndex)
                    {
                        case 0:
                            switch (data[listRCCountry.SelectedIndex, 8])
                            {
                                case 0:
                                    lblRCGuide.Text = "Unknown Status";
                                    cmdRCPresent.Enabled = true;
                                    cmdRCAbsent.Enabled = true;
                                    break;
                                case 1:
                                    lblRCGuide.Text = "Now Present";
                                    cmdRCPresent.Enabled = false;
                                    cmdRCAbsent.Enabled = true;
                                    break;
                                case -1:
                                    lblRCGuide.Text = "Now Absent";
                                    cmdRCPresent.Enabled = true;
                                    cmdRCAbsent.Enabled = false;
                                    break;

                            }
                            break;
                        case 1:
                            switch (data[listRCCountry.SelectedIndex, 8])
                            {
                                case 0:
                                    lblRCGuide.Text = "出席情况未知";
                                    cmdRCPresent.Enabled = true;
                                    cmdRCAbsent.Enabled = true;
                                    break;
                                case 1:
                                    lblRCGuide.Text = "现已出席";
                                    cmdRCPresent.Enabled = false;
                                    cmdRCAbsent.Enabled = true;
                                    break;
                                case -1:
                                    lblRCGuide.Text = "现正缺席";
                                    cmdRCPresent.Enabled = true;
                                    cmdRCAbsent.Enabled = false;
                                    break;

                            }
                            break;
                    }
                }
                else
                {
                    cmdRCPresent.Enabled = true;
                    cmdRCAbsent.Enabled = true;
                    mainP.listCountry.SelectedIndex = listRCCountry.SelectedIndex;
                }
            }
        }

        private bool rollCallCompleted()
        {
            if (rcNowIndex == listRCCountry.Items.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void cmdRCPresent_Click(object sender, EventArgs e)
        {
            if (listRCCountry.SelectedIndex > -1)
            {

                overwriteData(listRCCountry.SelectedIndex, 8, 1);
                calculate();
                listRCCountry.Items[listRCCountry.SelectedIndex] = $"√ {allLists.allCountry[listRCCountry.SelectedIndex]}";
                if (rollCallInProgress && listRCCountry.SelectedIndex == rcNowIndex)
                {
                    rcNowIndex++;
                    rcNextIndex++;
                    if (rollCallCompleted())
                    {
                        finishRollCall();
                    }
                    else
                    {
                        updatePush(7, "Roll Call", $"{listRCCountry.Items.Count - rcNowIndex} Delegate(s) Left", "点名程序", $"剩余{listRCCountry.Items.Count - rcNowIndex}位代表");

                        listRCCountry.SelectedIndex = rcNowIndex;
                        mainP.nowUpdate(allLists.allCountry[rcNowIndex]);
                        if (rcNowIndex < (listRCCountry.Items.Count - 1))
                        {
                            mainP.nextUpdate(allLists.allCountry[rcNextIndex]);
                        }
                    }
                }
            }
        }

        private void finishRollCall()
        {
            rcNowIndex = 0;
            rcNextIndex = 1;
            clearMainPage();
            calculate();
            rollCallInProgress = false;
            cmdDoRC.Enabled = true;
            if (data[allLists.allCountry.Count - 1, 8] == 1)
            {
                cmdRCPresent.Enabled = false;

            }
            if (data[allLists.allCountry.Count - 1, 8] == -1)
            {
                cmdRCAbsent.Enabled = false;
            }
            PopUp popUp = new PopUp(languageIndex, "Roll Call Compeleted", $"Present: {present.ToString()}, Absent: {absent.ToString()}", "点名完成", $"出席：{present.ToString()}，缺席：{absent.ToString()}", lblDash.BackColor);
            popUp.ShowDialog();
            updateEventList(this.present, this.absent);
            reassignPush(7);
            cmdDoRC.Text = multilingual("Start Roll Call", "开始点名");
            listRCCountry.SelectedIndex = 0;
        }

        private void calculate()
        {
            present = 0;
            absent = 0;
            unknown = 0;
            for (int i = 0; i < allLists.allCountry.Count; i++)
            {

                if (data[i, 8] == 1)
                {
                    present++;
                }
                else if (data[i, 8] == -1)
                {
                    absent++;
                }
                else if (data[i, 8] == 0)
                {
                    unknown++;
                }

            }

            rate = (present * 100) / (present + absent + unknown);
            DrawPieChartOnPanel(rate, 100 - rate);
            sm = int.Parse(Math.Ceiling((double.Parse(present.ToString()) + 1) / 2).ToString());
            am = int.Parse(Math.Ceiling(double.Parse(present.ToString()) / 3 * 2).ToString());
            num20 = int.Parse(Math.Ceiling(double.Parse(present.ToString()) * 0.2).ToString());
            switch (languageIndex)
            {
                case 0:
                    lblRCSM.Text = $"Simple Majority: {sm.ToString()}";
                    lblRCAM.Text = $"Absolute Majority: {am.ToString()}";
                    lblRC20.Text = $"20% of the Number: {num20.ToString()}";
                    lblRCAttendance.Text = $"Attendance Rate: {rate.ToString()}%";
                    break;
                case 1:
                    lblRCSM.Text = $"简单多数：{sm.ToString()}";
                    lblRCAM.Text = $"绝对多数：{am.ToString()}";
                    lblRC20.Text = $"百分之二十数：{num20.ToString()}";
                    lblRCAttendance.Text = $"出席率：{rate.ToString()}%";
                    break;
            }
            rcTitleUpdate($"Present: {present.ToString()}, Absent: {absent.ToString()}", $"出席：{present.ToString()}，缺席：{absent.ToString()}");
            mainP.attendanceUpdate(sm, am);
        }

        private void cmdRCAbsent_Click(object sender, EventArgs e)
        {
            if (listRCCountry.SelectedIndex > -1)
            {

                overwriteData(listRCCountry.SelectedIndex, 8, -1);
                calculate();
                listRCCountry.Items[listRCCountry.SelectedIndex] = $"× {allLists.allCountry[listRCCountry.SelectedIndex]}";
                if (rollCallInProgress && listRCCountry.SelectedIndex == rcNowIndex)
                {
                    rcNowIndex++;
                    rcNextIndex++;
                    if (rollCallCompleted())
                    {
                        finishRollCall();
                    }
                    else
                    {
                        updatePush(7, "Roll Call", $"{listRCCountry.Items.Count - rcNowIndex} Delegate(s) Left", "点名程序", $"剩余{listRCCountry.Items.Count - rcNowIndex}位代表");

                        listRCCountry.SelectedIndex = rcNowIndex;
                        mainP.nowUpdate(allLists.allCountry[rcNowIndex]);
                        if (rcNowIndex < (listRCCountry.Items.Count - 1))
                        {
                            mainP.nextUpdate(allLists.allCountry[rcNextIndex]);
                        }
                    }
                }
            }
        }

        private void cmdRollCall_Click(object sender, EventArgs e)
        {

            tabControl.SelectTab(tabRollCall);
            lblDash.BackColor = lblRCDash.BackColor;
            if (lblRCStatus.Text == "Roll Call not Completed" | lblRCStatus.Text == "尚未完成全部点名")
            {
                flashTime = 4;
                timerFlash.Enabled = true;
            }


        }

        private void cmdRCBack_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabMain);
            lblDash.BackColor = Color.GreenYellow;
        }

        public void DrawPieChartOnPanel(int whitePercent, int greyPercent)
        {
            int[] myPiePercent = { whitePercent, greyPercent };
            Color[] myPieColors = { Color.White, Color.DimGray };
            using (Graphics myPieGraphic = panPieChart.CreateGraphics())
            {
                Point myPieLocation = new Point(panPieChart.Width / 2 - 165, panPieChart.Height / 2 - 165);
                Size myPieSize = new Size(350, 350);
                DrawPieChart(myPiePercent, myPieColors, myPieGraphic, myPieLocation, myPieSize);
            }
        }
        public void DrawPieChart(int[] myPiePerecents, Color[] myPieColors, Graphics myPieGraphic, Point
      myPieLocation, Size myPieSize)
        {
            int PiePercentTotal = 0;

            for (int PiePercents = 0; PiePercents < myPiePerecents.Length; PiePercents++)
            {
                using (SolidBrush brush = new SolidBrush(myPieColors[PiePercents]))
                {
                    myPieGraphic.FillPie(brush, new Rectangle(new Point(panPieChart.Width / 2 - 165, panPieChart.Height / 2 - 165), myPieSize), Convert.ToSingle(PiePercentTotal * 360 / 100), Convert.ToSingle(myPiePerecents[PiePercents] * 360 / 100));
                }

                PiePercentTotal += myPiePerecents[PiePercents];
            }
            return;
        }

        private void panPieChart_Paint(object sender, PaintEventArgs e)
        {
            DrawPieChartOnPanel(rate, 100 - rate);
        }

        private void cmdSpeaker_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabSpeaker);
            lblDash.BackColor = lblSLLowerDash.BackColor;

            if (!motionInProgress && !rollCallInProgress && !SLinProgress && !votingInProgress)
            {
                flashTime = 4;
                timerFlash.Enabled = true;
            }
        }



        private void cmdSLBack_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabMain);
            lblDash.BackColor = Color.GreenYellow;
        }

        private void cmdSLContinue_Click(object sender, EventArgs e)
        {
            timerFlash.Enabled = false;
            cmdSLContinue.BackColor = Color.FromArgb(64, 64, 64);
            if (motionInProgress)
            {
                motionInProgressError();
            }
            else
            {
                if (rollCallInProgress)
                {
                    rollCallInProgressError();
                }
                else
                {
                    if (votingInProgress)
                    {
                        votingInProgressError();
                    }
                    else
                    {
                        SLinProgress = true;

                        buttonFunctionIndex = 3;
                        SLNowNextUpdate();
                        lblBigTime.Text = SLEachTime.ToString();
                        mainP.lblBigTime.Text = lblBigTime.Text;
                    }
                }

            }
        }

        private void numSLLength_ValueChanged(object sender, EventArgs e)
        {


            SLTime = int.Parse(numSLLength.Value.ToString());
            SLEachTime = SLTime;
            if (SLinProgress)
            {
                lblBigTime.Text = SLEachTime.ToString();
                mainP.lblBigTime.Text = SLEachTime.ToString();
            }
        }

        private void txtEnterToSL_TextChanged(object sender, EventArgs e)
        {
            if (txtEnterToSL.Text == "")//When the input is clear, show a list of all countries
            {
                listSLCountry.Items.Clear();
                for (int i = 0; i < allLists.allCountry.Count; i++)
                {
                    listSLCountry.Items.Add(allLists.allCountry[i]);
                }
                listSLCountry.SelectedIndex = -1;
            }
            else
            {
                listSLCountry.Items.Clear();
                string match1 = txtEnterToSL.Text.ToUpper(); //Convert all letters to upper for comparison.
                for (int i = 0; i < allLists.allCountryUpper.Count; i++)//Find all match with input
                {
                    if (allLists.allCountryUpper[i].Length >= match1.Length)
                    {
                        if (allLists.allCountryUpper[i].Substring(0, match1.Length) == match1)
                        {
                            listSLCountry.Items.Add(allLists.allCountry[i]);
                        }
                    }
                }
                if (listSLCountry.Items.Count > 0)
                {
                    listSLCountry.SelectedIndex = 0;//Set focus on the first country to wait for user's further selection
                    cmdSLAdd.Enabled = true;
                }
                else
                {
                    listSLCountry.SelectedIndex = -1;
                    cmdSLAdd.Enabled = false;
                }
            }
        }

        private void cmdSLClearInput_Click(object sender, EventArgs e)
        {
            txtEnterToSL.Text = "";

        }

        private void listSLCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSLCountry.SelectedIndex == -1)
            {
                cmdSLAdd.Enabled = false;

            }
            else
            {
                cmdSLAdd.Enabled = true;
            }
        }

        private void cmdSLAdd_Click(object sender, EventArgs e)
        {
            if (listSLCountry.SelectedIndex > -1)
            {
                listSLSpeakers.Items.Add(listSLCountry.SelectedItem);
                allLists.speakersList.Add(listSLCountry.Items[listSLCountry.SelectedIndex].ToString());

                txtEnterToSL.Text = "";

                SLLeft++;
                SLLeftUpdate();
                updatePush(4, "Speaker's List", lblSLLeft.Text, "主发言名单", lblSLLeft.Text);
                if (SLinProgress)
                {
                    SLNowNextUpdate();
                    cmdStart.Enabled = true;
                }
            }
        }

        private void SLLeftUpdate()
        {
            switch (languageIndex)
            {
                case 0:
                    lblSLLeft.Text = $"{SLLeft.ToString()} Delegate(s) Left";
                    break;
                case 1:
                    lblSLLeft.Text = $"剩余{SLLeft.ToString()}位代表";
                    break;
            }
        }

        private void SLNowNextUpdate()
        {
            mainP.listUpdate(allLists.speakersList);
            mainP.contentUpdate2("Formal Debate", "Speaker's List", "正式辩论", "主发言名单");
            switch (languageIndex)
            {
                case 0:
                    if (listSLSpeakers.Items.Count == 0)
                    {
                        lblNowNext.Text = $"Now:{Environment.NewLine}Next:";
                        mainP.nowUpdate("");
                        mainP.lblNextCountry.Text = ""; ;
                    }
                    else
                    {
                        lblNowNext.Text = $"Now: {listSLSpeakers.Items[0].ToString()}";
                        mainP.nowUpdate(listSLSpeakers.Items[0].ToString());
                        if (listSLSpeakers.Items.Count > 1)
                        {
                            lblNowNext.Text += $"{Environment.NewLine}Next: {listSLSpeakers.Items[1].ToString()}";
                            mainP.nextUpdate(listSLSpeakers.Items[1].ToString());
                        }
                        else
                        {
                            lblNowNext.Text += $"{Environment.NewLine}Next: ";
                            mainP.lblNextCountry.Text = "";
                        }
                    }
                    break;
                case 1:
                    if (listSLSpeakers.Items.Count == 0)
                    {
                        lblNowNext.Text = $"当前：{Environment.NewLine}下一位：";
                    }
                    else
                    {
                        lblNowNext.Text = $"当前：{listSLSpeakers.Items[0].ToString()}";
                        mainP.nowUpdate(listSLSpeakers.Items[0].ToString());
                        if (listSLSpeakers.Items.Count > 1)
                        {
                            lblNowNext.Text += $"{Environment.NewLine}下一位：{listSLSpeakers.Items[1].ToString()}";
                            mainP.nextUpdate(listSLSpeakers.Items[1].ToString());
                        }
                        else
                        {
                            lblNowNext.Text += $"{Environment.NewLine}下一位：";
                            mainP.lblNextCountry.Text = "";
                        }
                    }
                    break;

            }

        }

        private void cmdSLClearList_Click(object sender, EventArgs e)
        {
            listSLSpeakers.Items.Clear();
            if (SLinProgress)
            {
                SLNowNextUpdate();
            }

        }

        private void listSLSpeakers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSLSpeakers.SelectedIndex == -1)
            {
                cmdSLRemove.Enabled = false;

            }
            else
            {
                cmdSLRemove.Enabled = true;
            }
        }

        private void cmdSLRemove_Click(object sender, EventArgs e)
        {
            if (listSLSpeakers.SelectedIndex == 0 && SLEachTime != SLTime)
            {
                PopUp pop = new PopUp(languageIndex, "Procedural Matter", "Cannot remove the delegate holding the floor", "程序性事项", "不能移除正在发言的代表", lblSLLowerDash.BackColor);
                pop.ShowDialog();
            }
            else if (listSLSpeakers.SelectedIndex > -1)
            {
                SLLeft--;
                allLists.speakersList.RemoveAt(listSLSpeakers.SelectedIndex);
                listSLSpeakers.Items.RemoveAt(listSLSpeakers.SelectedIndex);

                SLLeftUpdate();
                updatePush(4, "Speaker's List", lblSLLeft.Text, "主发言名单", lblSLLeft.Text);
            }

            if (SLinProgress)
            {
                SLNowNextUpdate();
            }
        }

        private void timerSLTime_Tick(object sender, EventArgs e)
        {
            if (SLEachTime > 0)
            {
                lblBigTime.Text = (--SLEachTime).ToString();
                mainP.lblBigTime.Text = lblBigTime.Text;
            }
            else
            {
                timerSLTime.Enabled = false;
            }
        }

        private void timerFlash_Tick(object sender, EventArgs e)
        {
            if (flashTime > 0)
            {
                flashTime--;
                switch (tabControl.SelectedIndex)
                {
                    case 3:
                        if (cmdSLContinue.BackColor == Color.CornflowerBlue)
                        {
                            cmdSLContinue.BackColor = Color.FromArgb(64, 64, 64);
                        }
                        else
                        {
                            cmdSLContinue.BackColor = Color.CornflowerBlue;
                        }
                        break;
                    case 0:

                        if (cmdStart.BackColor == Color.GreenYellow)
                        {
                            cmdStart.BackColor = Color.FromArgb(64, 64, 64);
                        }
                        else
                        {
                            cmdStart.BackColor = Color.GreenYellow;
                        }
                        break;
                    case 7:
                        if (cmdDoRC.BackColor == Color.Aquamarine)
                        {
                            cmdDoRC.BackColor = Color.FromArgb(64, 64, 64);

                        }
                        else
                        {
                            cmdDoRC.BackColor = Color.Aquamarine;
                        }
                        break;
                    case 5:
                        if (cmdStartVoting.BackColor == Color.MediumSpringGreen)
                        {
                            cmdStartVoting.BackColor = Color.FromArgb(64, 64, 64);
                        }
                        else
                        {
                            cmdStartVoting.BackColor = Color.MediumSpringGreen;
                        }
                        break;
                }
            }
            else
            {
                cmdStart.BackColor = Color.FromArgb(64, 64, 64);
                cmdSLContinue.BackColor = Color.FromArgb(64, 64, 64);
                cmdDoRC.BackColor = Color.FromArgb(64, 64, 64);
                cmdStartVoting.BackColor = Color.FromArgb(64, 64, 64);
                timerFlash.Enabled = false;
            }
        }


        public List<int> generateAttendingIndexList()
        {
            List<int> output = new List<int>();
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (data[i, 8] == 1)
                {
                    output.Add(i);
                }

            }
            return output;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (motionInProgress)
            {
                motionInProgressError();
            }
            else
            {
                if (rollCallInProgress)
                {
                    rollCallInProgressError();
                }
                else
                {
                    if (SLinProgress && timerSLTime.Enabled)
                    {
                        SLinProgressError();
                    }
                    else
                    {


                        if (txtPaperName.Text != "" && txtPaperName.Text != "Enter Paper Name" && txtPaperName.Text != "输入文件名")
                        {
                            if (lblRCStatus.Text != "Roll Call not Completed" && lblRCStatus.Text != "尚未完成全部点名")
                            {
                                if (cmdStartVoting.Text == "Start Voting" | cmdStartVoting.Text == "开始投票")
                                {
                                    SLinProgress = false;
                                    votingInProgress = true;
                                    clearMainPage();
                                    switch (languageIndex)
                                    {
                                        case 0:
                                            cmdStartVoting.Text = "Cancel Voting";
                                            break;
                                        case 1:
                                            cmdStartVoting.Text = "取消投票";
                                            break;
                                    }
                                    assignPush(8, "Voting", txtPaperName.Text, "投票表决", txtPaperName.Text);
                                    listVotingList.Items.Clear();
                                    mainP.listCountry.Items.Clear();
                                    nowVoting = new Voting(txtPaperName.Text, this.allLists, this.data);

                                    List<string> presentList = new List<string>();
                                    for (int i = 0; i < data.GetLength(0); i++)
                                    {
                                        if (data[i, 8] == 1)//If present then add to list
                                        {
                                            listVotingList.Items.Add($"? {allLists.allCountry[i]}");
                                            mainP.listCountry.Items.Add($"? {allLists.allCountry[i]}");
                                            presentList.Add(allLists.allCountry[i]);
                                        }
                                    }
                                    if (presentList.Count > 2)
                                    {
                                        listVotingList.SelectedIndex = 0;
                                        mainP.listCountry.SelectedIndex = 0;
                                        mainP.nowUpdate(presentList[0]);
                                        mainP.nextUpdate(presentList[1]);
                                        mainP.contentUpdate2("Voting Procedure", nowVoting.fileName, "投票程序", nowVoting.fileName);
                                    }
                                    else
                                    {
                                        nowVoting.endVoting();
                                        resetVoting();
                                        PopUp pop = new PopUp(languageIndex, "Procedural Matter", "Number of delegates present is smaller than 3.", "程序性事项", "出席人数小于3。", lblVotingDash.BackColor);
                                        pop.ShowDialog();
                                    }
                                }
                                else if (cmdStartVoting.Text == "Cancel Voting" | cmdStartVoting.Text == "取消投票")
                                {
                                    nowVoting.cancel();
                                    resetVoting();
                                }
                                else if (cmdStartVoting.Text == "Start 2nd Round" | cmdStartVoting.Text == "开始第二轮投票")
                                {
                                    firstRound = false;
                                    nowVoting.nowIndex = 0;
                                    listVotingList.SelectedIndex = 0;
                                    mainP.listCountry.SelectedIndex = 0;
                                    while (nowVoting.choices[nowVoting.nowIndex] != 4 && !endOfTheVotingList())
                                    {
                                        nowVoting.nowIndex++;
                                        listVotingList.SelectedIndex++;
                                        mainP.listCountry.SelectedIndex++;
                                    }
                                    if (endOfTheVotingList() && nowVoting.choices[nowVoting.presentCountryIndex.Count - 1] != 4)
                                    {
                                        nowVoting.endVoting();
                                        confirmResult();

                                    }
                                    else
                                    {
                                        switch (languageIndex)
                                        {
                                            case 0:
                                                cmdStartVoting.Text = "Cancel Voting";
                                                break;
                                            case 1:
                                                cmdStartVoting.Text = "取消投票";
                                                break;
                                        }
                                        mainP.nowNextUpdate();
                                        mainP.nowUpdate(allLists.allCountry[nowVoting.presentCountryIndex[mainP.listCountry.SelectedIndex]]);
                                    }
                                }
                                else if (cmdStartVoting.Text == "Confirm Result" | cmdStartVoting.Text == "确认投票结果")
                                {
                                    nowVoting.endVoting();
                                    updateEventList(nowVoting);

                                    PopUp pop = new PopUp(languageIndex, "Voting Result", $"Yes: {nowVoting.yes.ToString()}, No: {nowVoting.no.ToString()}{Environment.NewLine}Abstain: {nowVoting.abstain.ToString()}, Favor Rate: {nowVoting.favorRate.ToString()}%{Environment.NewLine}Check Event List for details.", "投票结果", $"赞成：{nowVoting.yes.ToString()}，反对：{nowVoting.no.ToString()}{Environment.NewLine}弃权：{nowVoting.abstain.ToString()}，赞成率：{nowVoting.favorRate.ToString()}%{Environment.NewLine}详情参考动态。", lblVotingDash.BackColor);
                                    pop.ShowDialog();

                                    resetVoting();
                                }
                            }
                            else
                            {
                                PopUp pop = new PopUp(languageIndex, "Procedural Matter", "Please do Roll Call prior to voting.", "程序性事项", "请在投票前首先点名", lblVotingDash.BackColor);
                                pop.ShowDialog();
                            }
                        }
                        else
                        {
                            PopUp pop = new PopUp(languageIndex, "Paper Name Missing", "Please enter the name of the paper.", "文件名未输入", "请输入要表决的文件名称", lblDash.BackColor);
                            pop.ShowDialog();


                        }
                    }
                }
            }

        }

        private void confirmResult()
        {
            switch (languageIndex)
            {
                case 0:
                    cmdStartVoting.Text = "Confirm Result";
                    break;
                case 1:
                    cmdStartVoting.Text = "确认投票结果";
                    break;

            }
            flashTime = 4;
            timerFlash.Enabled = true;
        }

        private void resetVoting()
        {
            listVotingList.Items.Clear();
            mainP.listCountry.Items.Clear();
            mainP.nowNextUpdate();
            mainP.contentUpdate();
            lblVotingStatus.Text = "";
            lblVotingNowCountry.Text = "";
            txtPaperName.Text = multilingual("Enter Paper Name", "输入文件名");
            votingInProgress = false;
            reassignPush(8);
            cmdStartVoting.Text = multilingual("Start Voting", "开始投票");
            firstRound = true;
            DrawPieChartOnVoting(0, 100);
            lblVotingYes.Text = multilingual("Yes: ", "赞成：");
            lblVotingNo.Text = multilingual("No: ", "反对：");
            lblVotingAbstain.Text = multilingual("Abstain: ", "弃权：");
            lblVotingRate.Text = multilingual("Favor Rate: ", "赞成率：");
        }

        private void doFirstRound()
        {

        }

        public void votingInProgressError()
        {
            PopUp pop = new PopUp(languageIndex, "Procedural Matter", "Finish Voting to Continue", "程序性事项", "结束投票以继续", lblDash.BackColor);
            pop.ShowDialog();
        }

        private void radSetOnly_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listVotingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listVotingList.SelectedIndex != -1)
            {
                lblVotingNowCountry.Text = allLists.allCountry[nowVoting.presentCountryIndex[listVotingList.SelectedIndex]];
                switch (nowVoting.choices[listVotingList.SelectedIndex])
                {
                    case 0:
                        lblVotingStatus.Text = "?";
                        break;
                    case 1:
                        lblVotingStatus.Text = multilingual("Yes", "赞成");
                        break;
                    case 2:
                        lblVotingStatus.Text = multilingual("No", "反对");
                        break;
                    case 3:
                        lblVotingStatus.Text = multilingual("Abstain", "弃权");
                        break;
                    case 4:
                        lblVotingStatus.Text = multilingual("Pass", "过");
                        break;
                }




            }
            else
            {
                lblVotingNowCountry.Text = "";
                lblVotingStatus.Text = "";
            }
        }

        private void cmdVotingYes_Click(object sender, EventArgs e)
        {
            if (votingInProgress)
            {
                nowVoting.choose(listVotingList.SelectedIndex, 1);
                nowVoting.calculate();
                DrawPieChartOnVoting(nowVoting.favorRate, 100 - nowVoting.favorRate);
                listVotingList.Items[listVotingList.SelectedIndex] = $"√ {allLists.allCountry[nowVoting.presentCountryIndex[listVotingList.SelectedIndex]]}";
                mainP.listCountry.Items[listVotingList.SelectedIndex] = $"√ {allLists.allCountry[nowVoting.presentCountryIndex[listVotingList.SelectedIndex]]}";

                updateVotingData();
                switch (languageIndex)
                {
                    case 0:
                        lblVotingStatus.Text = "Yes";
                        break;
                    case 1:
                        lblVotingStatus.Text = "赞成";
                        break;

                }
                if (listVotingList.SelectedIndex == nowVoting.nowIndex && !endOfTheVotingList())//Jump to the next unvoted country (usually just the next one in the first round, but not in the second round)
                {
                    if (firstRound)
                    {
                        do
                        {
                            nowVoting.nowIndex++;
                            listVotingList.SelectedIndex++;
                            mainP.listCountry.SelectedIndex++;
                        }
                        while (nowVoting.choices[nowVoting.nowIndex] > 0 && !endOfTheVotingList());
                        mainP.nowUpdate(allLists.allCountry[nowVoting.presentCountryIndex[mainP.listCountry.SelectedIndex]]);
                        if (!endOfTheVotingList())
                        {
                            mainP.nextUpdate(allLists.allCountry[nowVoting.presentCountryIndex[mainP.listCountry.SelectedIndex + 1]]);
                        }
                        else
                        {
                            mainP.lblNextCountry.Text = "";
                        }
                    }
                    else
                    {
                        do
                        {
                            nowVoting.nowIndex++;
                        }
                        while (nowVoting.choices[nowVoting.nowIndex] != 4 && !endOfTheVotingList());
                        if (!endOfTheVotingList() | nowVoting.choices[nowVoting.presentCountryIndex.Count - 1] == 4)
                        {
                            listVotingList.SelectedIndex = nowVoting.nowIndex;
                            mainP.listCountry.SelectedIndex = nowVoting.nowIndex;
                            mainP.nowUpdate(allLists.allCountry[nowVoting.presentCountryIndex[mainP.listCountry.SelectedIndex]]);

                        }
                    }


                }
                testIfEnd();
            }
        }

        private void updateVotingData()
        {
            lblVotingYes.Text = multilingual("Yes: ", "赞成：");
            lblVotingNo.Text = multilingual("No: ", "反对：");
            lblVotingAbstain.Text = multilingual("Abstain: ", "弃权：");
            lblVotingRate.Text = multilingual("Favor Rate: ", "赞成率：");
            lblVotingYes.Text += nowVoting.yes.ToString();
            lblVotingNo.Text += nowVoting.no.ToString();
            lblVotingAbstain.Text += nowVoting.abstain.ToString();
            lblVotingRate.Text += $"{nowVoting.favorRate.ToString()}%";
        }

        private bool endOfTheVotingList()
        {
            if (nowVoting.nowIndex < listVotingList.Items.Count - 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void cmdVotingNo_Click(object sender, EventArgs e)
        {
            if (votingInProgress)
            {
                nowVoting.choose(listVotingList.SelectedIndex, 2);
                nowVoting.calculate();
                DrawPieChartOnVoting(nowVoting.favorRate, 100 - nowVoting.favorRate);
                listVotingList.Items[listVotingList.SelectedIndex] = $"× {allLists.allCountry[nowVoting.presentCountryIndex[listVotingList.SelectedIndex]]}";
                mainP.listCountry.Items[listVotingList.SelectedIndex] = $"× {allLists.allCountry[nowVoting.presentCountryIndex[listVotingList.SelectedIndex]]}";

                updateVotingData();
                switch (languageIndex)
                {
                    case 0:
                        lblVotingStatus.Text = "No";
                        break;
                    case 1:
                        lblVotingStatus.Text = "反对";
                        break;

                }
                if (listVotingList.SelectedIndex == nowVoting.nowIndex && !endOfTheVotingList())//Jump to the next unvoted country (usually just the next one in the first round, but not in the second round)
                {
                    if (firstRound)
                    {
                        do
                        {
                            nowVoting.nowIndex++;
                            listVotingList.SelectedIndex++;
                            mainP.listCountry.SelectedIndex++;
                        }
                        while (nowVoting.choices[nowVoting.nowIndex] > 0 && !endOfTheVotingList() && nowVoting.choices[nowVoting.nowIndex] != 4);
                        mainP.nowNextUpdate();
                        mainP.nowUpdate(allLists.allCountry[nowVoting.presentCountryIndex[mainP.listCountry.SelectedIndex]]);
                        if (!endOfTheVotingList())
                        {
                            mainP.nextUpdate(allLists.allCountry[nowVoting.presentCountryIndex[mainP.listCountry.SelectedIndex + 1]]);
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        do
                        {
                            nowVoting.nowIndex++;
                        }
                        while (nowVoting.choices[nowVoting.nowIndex] != 4 && !endOfTheVotingList());
                        if (!endOfTheVotingList() | nowVoting.choices[nowVoting.presentCountryIndex.Count - 1] == 4)
                        {
                            listVotingList.SelectedIndex = nowVoting.nowIndex;
                            mainP.listCountry.SelectedIndex = nowVoting.nowIndex;
                            mainP.nowUpdate(allLists.allCountry[nowVoting.presentCountryIndex[mainP.listCountry.SelectedIndex]]);

                        }
                    }
                }

                testIfEnd();



            }
        }

        private void testIfEnd()
        {
            bool allChosen = true;
            for (int i = 0; i < nowVoting.choices.GetLength(0); i++)
            {
                if (nowVoting.choices[i] == 0)
                {
                    allChosen = false;
                    break;
                }
                if (!firstRound)
                {
                    if (nowVoting.choices[i] == 4)
                    {
                        allChosen = false;
                        break;
                    }
                }
            }
            if (allChosen)
            {
                if (firstRound)
                {
                    switch (languageIndex)
                    {
                        case 0:
                            cmdStartVoting.Text = "Start 2nd Round";
                            break;
                        case 1:
                            cmdStartVoting.Text = "开始第二轮投票";
                            break;
                    }
                    flashTime = 4;
                    timerFlash.Enabled = true;
                }
                else
                {
                    confirmResult();
                }
            }
        }

        private void cmdVotingPass_Click(object sender, EventArgs e)
        {
            if (votingInProgress)
            {
                if (firstRound)
                {
                    nowVoting.choose(listVotingList.SelectedIndex, 4);
                    listVotingList.Items[listVotingList.SelectedIndex] = $"? {allLists.allCountry[nowVoting.presentCountryIndex[listVotingList.SelectedIndex]]}";
                    mainP.listCountry.Items[listVotingList.SelectedIndex] = $"? {allLists.allCountry[nowVoting.presentCountryIndex[listVotingList.SelectedIndex]]}";

                    nowVoting.calculate();
                    DrawPieChartOnVoting(nowVoting.favorRate, 100 - nowVoting.favorRate);

                    updateVotingData();
                    switch (languageIndex)
                    {
                        case 0:
                            lblVotingStatus.Text = "Pass";
                            break;
                        case 1:
                            lblVotingStatus.Text = "过";
                            break;

                    }
                    if (listVotingList.SelectedIndex == nowVoting.nowIndex && !endOfTheVotingList())//Jump to the next unvoted country (usually just the next one in the first round, but not in the second round)
                    {
                        if (firstRound)
                        {
                            do
                            {
                                nowVoting.nowIndex++;
                                listVotingList.SelectedIndex++;
                                mainP.listCountry.SelectedIndex++;
                            }

                            while (nowVoting.choices[nowVoting.nowIndex] > 0 && !endOfTheVotingList());
                            mainP.nowUpdate(allLists.allCountry[nowVoting.presentCountryIndex[mainP.listCountry.SelectedIndex]]);
                            if (!endOfTheVotingList())
                            {
                                mainP.nextUpdate(allLists.allCountry[nowVoting.presentCountryIndex[mainP.listCountry.SelectedIndex + 1]]);
                            }
                            else
                            {
                                mainP.lblNextCountry.Text = "";
                            }
                        }
                        else
                        {
                            do
                            {
                                nowVoting.nowIndex++;
                            }
                            while (nowVoting.choices[nowVoting.nowIndex] != 4 && !endOfTheVotingList());
                            if (!endOfTheVotingList())
                            {
                                listVotingList.SelectedIndex = nowVoting.nowIndex;
                                mainP.listCountry.SelectedIndex = nowVoting.nowIndex;
                            }
                        }


                    }
                    testIfEnd();
                }
                else
                {
                    PopUp pop = new PopUp(languageIndex, "Procedural Matter", "Cannot choose Pass in the 2nd round.", "程序性事项", "不能在二轮投票中选择过。", lblVotingDash.BackColor);
                    pop.ShowDialog();
                }
            }
        }

        private void cmdVotingAbstain_Click(object sender, EventArgs e)
        {
            if (votingInProgress)
            {
                if (firstRound)
                {
                    nowVoting.choose(listVotingList.SelectedIndex, 3);
                    listVotingList.Items[listVotingList.SelectedIndex] = $"- {allLists.allCountry[nowVoting.presentCountryIndex[listVotingList.SelectedIndex]]}";
                    mainP.listCountry.Items[listVotingList.SelectedIndex] = $"- {allLists.allCountry[nowVoting.presentCountryIndex[listVotingList.SelectedIndex]]}";
                    nowVoting.calculate();
                    DrawPieChartOnVoting(nowVoting.favorRate, 100 - nowVoting.favorRate);

                    updateVotingData();
                    switch (languageIndex)
                    {
                        case 0:
                            lblVotingStatus.Text = "Abstain";
                            break;
                        case 1:
                            lblVotingStatus.Text = "弃权";
                            break;

                    }
                    if (listVotingList.SelectedIndex == nowVoting.nowIndex && !endOfTheVotingList())//Jump to the next unvoted country (usually just the next one in the first round, but not in the second round)
                    {

                        do
                        {
                            nowVoting.nowIndex++;
                            listVotingList.SelectedIndex++;
                            mainP.listCountry.SelectedIndex++;
                        }
                        while (nowVoting.choices[nowVoting.nowIndex] > 0 && !endOfTheVotingList());
                        mainP.nowUpdate(allLists.allCountry[nowVoting.presentCountryIndex[mainP.listCountry.SelectedIndex]]);
                        if (!endOfTheVotingList())
                        {
                            mainP.nextUpdate(allLists.allCountry[nowVoting.presentCountryIndex[mainP.listCountry.SelectedIndex + 1]]);
                        }
                        else
                        {
                            mainP.lblNextCountry.Text = "";
                        }



                    }
                    testIfEnd();
                }
                else
                {
                    PopUp pop = new PopUp(languageIndex, "Procedural Matter", "Cannot choose Abstain in the 2nd round.", "程序性事项", "不能在二轮投票中选择弃权。", lblVotingDash.BackColor);
                    pop.ShowDialog();
                }
            }
        }


        private void cmdVoting_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabVoting);
            lblDash.BackColor = Color.SpringGreen;
        }
        public string multilingual(string english = "", string simChinese = "")
        {
            switch (languageIndex)
            {
                case 0:
                    return english;

                case 1:
                    return simChinese;

                default:
                    return english;


            }

        }

        private void cmdVotingBack_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabMain);
            lblDash.BackColor = Color.GreenYellow;
        }

        private void txtEnterToSL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listSLCountry.SelectedIndex > -1)
                {
                    cmdSLAdd.Enabled = true;
                    cmdSLAdd_Click(sender, e);
                    txtEnterToSL.Text = "";
                }
                else
                {
                    cmdSLAdd.Enabled = false;
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (listSLCountry.SelectedIndex > 0)
                {
                    listSLCountry.SelectedIndex--;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (listSLCountry.Items.Count > listSLCountry.SelectedIndex + 1)
                {
                    listSLCountry.SelectedIndex++;
                }
            }
        }
        public void DrawPieChartOnVoting(int whitePercent, int greyPercent)
        {
            int[] myPiePercent = { whitePercent, greyPercent };
            Color[] myPieColors = { Color.White, Color.DimGray };
            using (Graphics myPieGraphic = panVotingPie.CreateGraphics())
            {
                Point myPieLocation = new Point(panVotingPie.Width / 2 - 165, panVotingPie.Height / 2 - 165);
                Size myPieSize = new Size(350, 350);
                DrawPieChartVoting(myPiePercent, myPieColors, myPieGraphic, myPieLocation, myPieSize);
            }
        }
        public void DrawPieChartVoting(int[] myPiePerecents, Color[] myPieColors, Graphics myPieGraphic, Point
      myPieLocation, Size myPieSize)
        {
            int PiePercentTotal = 0;

            for (int PiePercents = 0; PiePercents < myPiePerecents.Length; PiePercents++)
            {
                using (SolidBrush brush = new SolidBrush(myPieColors[PiePercents]))
                {
                    myPieGraphic.FillPie(brush, new Rectangle(new Point(panVotingPie.Width / 2 - 165, panVotingPie.Height / 2 - 165), myPieSize), Convert.ToSingle(PiePercentTotal * 360 / 100), Convert.ToSingle(myPiePerecents[PiePercents] * 360 / 100));
                }

                PiePercentTotal += myPiePerecents[PiePercents];
            }
            return;
        }

        private void panVotingPie_Paint(object sender, PaintEventArgs e)
        {
            if (votingInProgress)
            {
                DrawPieChartOnVoting(nowVoting.favorRate, 100 - nowVoting.favorRate);
            }
            else
            {
                DrawPieChartOnVoting(0, 100);
            }
        }

        private void txtPaperName_Click(object sender, EventArgs e)
        {
            txtPaperName.Focus();
            txtPaperName.SelectAll();
        }

        private void tableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTimer1Title_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTimer1Title_Click(object sender, EventArgs e)
        {
            txtTimer1Title.Focus();
            txtTimer1Title.SelectAll();
        }

        private void txtTimer2Title_Click(object sender, EventArgs e)
        {
            txtTimer2Title.Focus();
            txtTimer2Title.SelectAll();
        }

        private void cmdTimer1Run_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled && (numTimer1Min.Value != 0 | numTimer1Sec.Value != 0))
            {
                timer1Min = int.Parse(numTimer1Min.Value.ToString());
                timer1Sec = int.Parse(numTimer1Sec.Value.ToString());
                lblTimer1Time.Text = timeFormat(timer1Min, timer1Sec);
                numTimer1Min.Enabled = false;
                numTimer1Sec.Enabled = false;
                timer1.Enabled = true;
                if (push1.linkedEventIndex != 5 && push2.linkedEventIndex != 5 && push3.linkedEventIndex != 5 && push4.linkedEventIndex != 5)
                    assignPush(5, "Timer 1", timeFormat(timer1Min, timer1Sec), "计时器1", timeFormat(timer1Min, timer1Sec));
            }
        }

        private string timeFormat(int min, int sec)
        {
            string output = "";
            if (min < 10)
            {
                output += $"0{min.ToString()}:";
            }
            else
            {
                output += $"{min.ToString()}:";
            }
            if (sec < 10)
            {
                output += $"0{sec.ToString()}";
            }
            else
            {
                output += sec.ToString();
            }
            return output;
        }

        private void cmdTimer2Run_Click(object sender, EventArgs e)
        {
            if (!timer2.Enabled && (numTimer2Min.Value != 0 | numTimer2Sec.Value != 0))
            {
                timer2Min = int.Parse(numTimer2Min.Value.ToString());
                timer2Sec = int.Parse(numTimer2Sec.Value.ToString());
                lblTimer2Time.Text = timeFormat(timer2Min, timer2Sec);
                numTimer2Min.Enabled = false;
                numTimer2Sec.Enabled = false;
                timer2.Enabled = true;
                if (push1.linkedEventIndex != 6 && push2.linkedEventIndex != 6 && push3.linkedEventIndex != 6 && push4.linkedEventIndex != 6)
                    assignPush(6, "Timer 2", timeFormat(timer2Min, timer2Sec), "计时器2", timeFormat(timer2Min, timer2Sec));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1Sec == 0)
            {
                if (timer1Min == 0)
                {
                    timer1.Enabled = false;
                    PopUp pop = new PopUp(languageIndex, "Timer 1", "Time is up", "计时器1", "时间到", lblDash.BackColor);
                    pop.ShowDialog();
                }
                else
                {
                    timer1Min--;
                    timer1Sec = 59;
                }
            }
            else
            {
                timer1Sec--;
            }
            lblTimer1Time.Text = timeFormat(timer1Min, timer1Sec);
            updatePush(5, "Timer 1", timeFormat(timer1Min, timer1Sec), "计时器1", timeFormat(timer1Min, timer1Sec));

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timer2Sec == 0)
            {
                if (timer2Min == 0)
                {
                    timer2.Enabled = false;
                    PopUp pop = new PopUp(languageIndex, "Timer 2", "Time is up", "计时器2", "时间到", lblDash.BackColor);
                    pop.ShowDialog();
                }
                else
                {
                    timer2Min--;
                    timer2Sec = 59;
                }
            }
            else
            {
                timer2Sec--;
            }
            lblTimer2Time.Text = timeFormat(timer2Min, timer2Sec);
            updatePush(6, "Timer 2", timeFormat(timer2Min, timer2Sec), "计时器2", timeFormat(timer2Min, timer2Sec));
        }

        private void cmdTimer1Pause_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
            }
        }

        private void cmdTimer2Pause_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled)
            {
                timer2.Enabled = false;
            }
        }

        private void cmdTimer1Reset_Click(object sender, EventArgs e)
        {
            if (!numTimer1Min.Enabled)
            {
                timer1.Enabled = false;
                timer1Min = int.Parse(numTimer1Min.Value.ToString());
                timer1Sec = int.Parse(numTimer1Sec.Value.ToString());
                lblTimer1Time.Text = timeFormat(timer1Min, timer1Sec);
                updatePush(5, "Timer 1", timeFormat(timer1Min, timer1Sec), "计时器1", timeFormat(timer1Min, timer1Sec));

            }
        }

        private void cmdTimer2Reset_Click(object sender, EventArgs e)
        {
            if (!numTimer2Min.Enabled)
            {
                timer2.Enabled = false;
                timer2Min = int.Parse(numTimer2Min.Value.ToString());
                timer2Sec = int.Parse(numTimer2Sec.Value.ToString());
                lblTimer2Time.Text = timeFormat(timer2Min, timer2Sec);
                updatePush(6, "Timer 2", timeFormat(timer2Min, timer2Sec), "计时器2", timeFormat(timer2Min, timer2Sec));
            }
        }

        private void cmdTimer1Clear_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1Min = 0;
            timer1Sec = 0;
            numTimer1Min.Value = 0;
            numTimer1Sec.Value = 0;
            numTimer1Min.Enabled = true;
            numTimer1Sec.Enabled = true;
            txtTimer1Title.Text = multilingual("Title", "标题");
            reassignPush(5);
            lblTimer1Time.Text = "00:00";
        }

        private void cmdTimer2Clear_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            timer2Min = 0;
            timer2Sec = 0;
            numTimer2Min.Value = 0;
            numTimer2Sec.Value = 0;
            numTimer2Min.Enabled = true;
            numTimer2Sec.Enabled = true;
            txtTimer2Title.Text = multilingual("Title", "标题");
            reassignPush(6);
            lblTimer2Time.Text = "00:00";
        }

        private void cmdReminder1Clear_Click(object sender, EventArgs e)
        {
            txtReminder1.Clear();
        }

        private void txtReminder2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdReminder2Clear_Click(object sender, EventArgs e)
        {
            txtReminder2.Clear();
        }

        private void cmdTimerReminder_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabTimerMemo);
            lblDash.BackColor = Color.DeepPink;
        }

        private void cmdTimerBack_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabMain);
            lblDash.BackColor = Color.GreenYellow;
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            timerFlash.Enabled = false;
            cmdStart.BackColor = Color.FromArgb(64, 64, 64);
            cmdSLContinue.BackColor = Color.FromArgb(64, 64, 64);
            cmdDoRC.BackColor = Color.FromArgb(64, 64, 64);
            cmdStartVoting.BackColor = Color.FromArgb(64, 64, 64);

        }

        private void cmdData_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabData);
            lblDash.BackColor = Color.Orange;
        }

        private void cmdSettings_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabSettings);
            lblDash.BackColor = Color.GreenYellow;
        }

        private void cmdHelpBack_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabMain);
            lblDash.BackColor = Color.GreenYellow;
        }

        private void combHelpLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combHelpLanguage.SelectedIndex != -1)
            {
                helpPageLanguageUpdate(combHelpLanguage.SelectedIndex);
            }
            else
            {
                combHelpLanguage.Text = "Language / 语言";
            }
        }

        private void cmdDataBack_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabMain);
            lblDash.BackColor = Color.GreenYellow;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listFile.SelectedIndex == -1)
            {
                cmdFileDelete.Enabled = false;
                txtFileName.Text = "";
                txtFileName.Enabled = false;

                combFileSignatory.SelectedIndex = -1;
                combFileSponsor.SelectedIndex = -1;

                combFileSponsor.Text = multilingual("Sponsors", "起草国");
                combFileSignatory.Text = multilingual("Signatories", "附议国");
                combFileSignatory.Enabled = false;
                combFileSponsor.Enabled = false;


                listFileSignatory.Items.Clear();
                listFileSponsor.Items.Clear();

                cmdFileAddSignatory.Enabled = false;
                cmdFileAddSponsor.Enabled = false;
                cmdFileRemoveSignatory.Enabled = false;
                cmdFileRemoveSponsor.Enabled = false;

                cmdFileLocation.Enabled = false;
                cmdFileBrowse.Enabled = false;
            }
            else
            {
                cmdFileDelete.Enabled = true;
                txtFileName.Enabled = true;
                combFileSponsor.SelectedIndex = -1;
                cmdFileLocation.Enabled = true ;
                cmdFileBrowse.Enabled = true ;

                combFileSponsor.Text = multilingual("Sponsors", "起草国");
                combFileSignatory.Text = multilingual("Signatories", "附议国");
                combFileSignatory.Enabled = true;
                combFileSponsor.Enabled = true;
 
                txtFileName.Text = listFile.Items[listFile.SelectedIndex].ToString();
                listFileSignatory.Items.Clear();
                listFileSponsor.Items.Clear();
                if (allLists.papers[listFile.SelectedIndex].sponsors.Count > 0)
                {
                    for (int i = 0; i < allLists.papers[listFile.SelectedIndex].sponsors.Count; i++)
                    {
                        listFileSponsor.Items.Add(allLists.papers[listFile.SelectedIndex].sponsors[i]);
                    }

                }
                if (allLists.papers[listFile.SelectedIndex].signatories.Count > 0)
                {
                    for (int i = 0; i < allLists.papers[listFile.SelectedIndex].signatories.Count; i++)
                    {
                        listFileSignatory.Items.Add(allLists.papers[listFile.SelectedIndex].signatories[i]);
                    }
                }
                if (allLists.papers[listFile.SelectedIndex].filePath=="na")
                {
                    cmdFileLocation.Text = multilingual("Location", "文档位置");
                }
                else
                {
                    cmdFileLocation.Text = allLists.papers[listFile.SelectedIndex].filePath;
                }
                txtFileName.Focus();
                txtFileName.Select(txtFileName.TextLength, 0);
            }
        }

        private void cmdFileCreate_Click(object sender, EventArgs e)
        {
            paper newpaper = new paper();
            newpaper.paperName = multilingual("New Paper", "新文件");
            listFile.Items.Add(multilingual("New Paper", "新文件"));
            allLists.papers.Add(newpaper);
            listFile.SelectedIndex = listFile.Items.Count - 1;
        }

        private void cmdFileDelete_Click(object sender, EventArgs e)
        {
            allLists.papers.RemoveAt(listFile.SelectedIndex);
            listFile.Items.RemoveAt(listFile.SelectedIndex);
            listFile.SelectedIndex = -1;
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            if (listFile.SelectedIndex != -1)
            {
                listFile.Items[listFile.SelectedIndex] = txtFileName.Text;
                allLists.papers[listFile.SelectedIndex].paperName = txtFileName.Text;
            }
        }



        private void combFileSponsor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combFileSponsor.SelectedIndex != -1)
            {
                cmdFileAddSponsor.Enabled = true;
            }
            else
            {
                cmdFileAddSponsor.Enabled = false;
            }
        }

        private void cmdFileAddSignatory_Click(object sender, EventArgs e)
        {
            if (combFileSignatory.SelectedIndex != -1 && listFile.SelectedIndex != -1)
            {
                listFileSignatory.Items.Add(combFileSignatory.SelectedItem.ToString());
                allLists.papers[listFile.SelectedIndex].signatories.Add(combFileSignatory.SelectedItem.ToString());
                writeToData(combFileSignatory.SelectedIndex, 6, "+");

                combFileSignatory.SelectedIndex = -1;
                combFileSignatory.Text = multilingual("Signatories", "附议国");
            }
        }

        private void combFileSignatory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combFileSignatory.SelectedIndex != -1)
            {
                cmdFileAddSignatory.Enabled = true;
            }
            else
            {
                cmdFileAddSignatory.Enabled = false;
            }
        }

        private void listFileSponsor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listFileSponsor.SelectedIndex != -1)
            {
                cmdFileRemoveSponsor.Enabled = true;
            }
            else
            {
                cmdFileRemoveSponsor.Enabled = false;
            }

        }

        private void listFileSignatory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listFileSignatory.SelectedIndex != -1)
            {
                cmdFileRemoveSignatory.Enabled = true;
            }
            else
            {
                cmdFileRemoveSignatory.Enabled = false;
            }
        }

        private void cmdFileAddSponsor_Click(object sender, EventArgs e)
        {
            if (combFileSponsor.SelectedIndex != -1 && listFile.SelectedIndex != -1)
            {
                listFileSponsor.Items.Add(combFileSponsor.SelectedItem.ToString());
                allLists.papers[listFile.SelectedIndex].sponsors.Add(combFileSponsor.SelectedItem.ToString());
                writeToData(combFileSponsor.SelectedIndex, 5, "+");
                combFileSponsor.SelectedIndex = -1;
                combFileSponsor.Text = multilingual("Sponsors", "起草国");
            }
        }

        private void cmdFileRemoveSponsor_Click(object sender, EventArgs e)
        {
            if (listFileSponsor.SelectedIndex != -1 && listFile.SelectedIndex != -1)
            {

                allLists.papers[listFile.SelectedIndex].sponsors.RemoveAt(listFileSponsor.SelectedIndex);
                int countryIndex = allLists.allCountry.IndexOf(listFileSponsor.SelectedItem.ToString());
                if (countryIndex != -1)
                {
                    writeToData(combFileSponsor.FindStringExact(listFileSponsor.SelectedItem.ToString()), 5, "-");
                }
                listFileSponsor.Items.RemoveAt(listFileSponsor.SelectedIndex);
                listFileSponsor.SelectedIndex = -1;
                cmdFileRemoveSponsor.Enabled = false;
            }
        }

        private void cmdFileRemoveSignatory_Click(object sender, EventArgs e)
        {
            if (listFileSignatory.SelectedIndex != -1 && listFile.SelectedIndex != -1)
            {
                allLists.papers[listFile.SelectedIndex].signatories.RemoveAt(listFileSignatory.SelectedIndex);
                int countryIndex = allLists.allCountry.IndexOf(listFileSignatory.SelectedItem.ToString());
                if (countryIndex != -1)
                {
                    writeToData(combFileSignatory.FindStringExact(listFileSignatory.SelectedItem.ToString()), 6, "-");
                }
                listFileSignatory.Items.RemoveAt(listFileSignatory.SelectedIndex);
                listFileSignatory.SelectedIndex = -1;
                cmdFileRemoveSignatory.Enabled = false;
            }
        }

        private void combDataCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combDataCountry.SelectedIndex == -1)
            {
                updateDataDisplay(new double[8] { -1, -1, -1, -1, -1, -1,-1,-1 });
            }
            else
            {
                double[] singleData = new double[8];
                for (int i =0;i <8;i++)
                {
                    singleData[i] = data[combDataCountry.SelectedIndex, i];
                }
                updateDataDisplay(singleData);
            }
        }
        private void updateDataDisplay(double[] singleData)
        {
            foreach (double i in singleData)
            {
                if (i ==-1)
                {
                    lblDataNumMotion.Text = "--";
                    lblDataNumPass.Text = "--";
                    lblDataNumFail.Text = "--";
                    lblDataNumSignatory.Text = "--";
                    lblDataNumSpeaking.Text = "--";
                    lblDataNumSponsor.Text = "--";
                    goto skipData;
                }               
            }
            lblDataNumMotion.Text = addZero(singleData[1]);
            lblDataNumPass.Text = addZero(singleData[2]);;
            lblDataNumFail.Text = addZero(singleData[3]);
            lblDataNumSignatory.Text = addZero(singleData[6]);
            lblDataNumSpeaking.Text = addZero(singleData[4]);
            lblDataNumSponsor.Text = addZero(singleData[5]);
        skipData:;

        }

        private string addZero(double number)
        {
            if (number >= 10)
            {
                return number.ToString();
            }
            else
            { 
            return "0" + number.ToString();
            }
        }

        private void cmdDataClear_Click(object sender, EventArgs e)
        {
            combDataCountry.SelectedIndex = -1;
            combDataCountry.Text = multilingual("Delegate Data", "代表数据");

        }

        private void listSLCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                /*if (listSLCountry.SelectedIndex > -1)
                {
                    cmdSLAdd.Enabled = true;
                    cmdSLAdd_Click(sender, e);
                    txtEnterToSL.Text = "";
                }
                else
                {
                    cmdSLAdd.Enabled = false;
                }*/
                txtEnterToSL_KeyDown(sender, e);
            }
            /*if (e.KeyCode == Keys.Up)
            {
                if (listSLCountry.SelectedIndex > 0)
                {
                    listSLCountry.SelectedIndex--;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (listSLCountry.Items.Count > listSLCountry.SelectedIndex + 1)
                {
                    listSLCountry.SelectedIndex++;
                }
            }*/
        }

        private void cmdFileLocation_Click(object sender, EventArgs e)
        {
            if (allLists.papers[listFile.SelectedIndex].filePath == "na")
            {
                cmdFileBrowse_Click(sender, e);
            }
            else
            {
                if (File.Exists(allLists.papers[listFile.SelectedIndex].filePath))
                {
                    Process.Start(allLists.papers[listFile.SelectedIndex].filePath);
                }
                else
                {
                    PopUp pop = new PopUp(languageIndex, "Warning", "File does not exist", "警告", "文件不存在", lblFileDash.BackColor);
                    pop.ShowDialog();
                }
            }
        }

        private void cmdFileBrowse_Click(object sender, EventArgs e)
        {      
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {

            }
            cmdFileLocation.Text = open.FileName;
            allLists.papers[listFile.SelectedIndex].filePath = open.FileName;
        }


        private void saveData_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            PopUp pop = new PopUp(languageIndex, "Notice", "Data output is human-readable, but could not be reloaded into the software.", "提示", "导出的数据是人类可读的，但不能被重新载入。",lblFileDash.BackColor);
            pop.ShowDialog();
            saveDataText.ShowDialog();
        }

        private void saveDataText_FileOk(object sender, CancelEventArgs e)
        {
            PopUp popText = new PopUp(languageIndex, "Processing", "Please wait while we are saving...", "处理中", "正在保存，请等待...", lblFileDash.BackColor);
            popText.Show();
            if (saveDataToReadableText())
            {
                popText.Dispose();
                PopUp complete = new PopUp(languageIndex, "Completed", "Output Success", "完成", "导出成功", lblFileDash.BackColor);
                complete.ShowDialog();
            }
            else
            {
                popText.Dispose();
                PopUp error = new PopUp(languageIndex, "Failed", "An error occured while outputing data.", "失败", "导出数据出错", lblFileDash.BackColor);
                error.ShowDialog();
            }
            
        }

        private bool saveDataToReadableText()
        {
            if (saveDataText.FileName != "")
            {
                StreamWriter writer = new StreamWriter(saveDataText.FileName, false, Encoding.GetEncoding("GB2312"));
                try
                {               
                    writer.WriteLine($"{mainP.txtCommitteeName.Text}: {mainP.txtTopicName.Text}, {mainP.txtConferenceName.Text}");
                    writer.WriteLine(multilingual("Save Time: ", "保存时间：") + DateTime.Now.ToShortTimeString());
                    writer.WriteLine("");
                    for (int i =0;i<listEvents.Items.Count;i++)
                    {
                        writer.WriteLine(listEvents.Items[i].ToString());
                    }
                    writer.WriteLine("");
                    writer.WriteLine(multilingual("Sequence: Motion Raised, Motion Passed, Motion Failed, Speaking Time, Paper Sponsored, Paper Signed", "顺序：动议数、动议通过数、动议反对数、发言次数、文件起草数、文件附议数"));
                    writer.WriteLine("");

                    for (int i = 0; i < allLists.allCountry.Count; i++)
                    {
                        writer.WriteLine(allLists.allCountry[i]);
                        writer.WriteLine($"{data[i, 1].ToString()}, {data[i, 2].ToString()}, {data[i, 3].ToString()}, {data[i, 4].ToString()}, {data[i, 5].ToString()}, {data[i, 6].ToString()}");
                        writer.WriteLine("");
                    }
                    writer.WriteLine("");
                    for (int i =0;i<allLists.papers.Count;i++)
                    {
                        writer.WriteLine(allLists.papers[i].paperName);
                        writer.WriteLine(allLists.papers[i].filePath);
                        writer.Write(multilingual("Sponsors: ","起草国："));
                        for (int j =0;j< allLists.papers[i].sponsors.Count;j++)
                        {
                            writer.Write(allLists.papers[i].sponsors[j] + ", ");
                        }
                        writer.WriteLine("");
                        writer.Write(multilingual("Signatories: ", "附议国："));
                        for (int j = 0; j < allLists.papers[i].signatories.Count; j++)
                        {
                            writer.Write(allLists.papers[i].signatories[j] + ", ");
                        }
                    }
                    writer.WriteLine("");
                    writer.WriteLine("Reminder 1:");
                    writer.WriteLine(txtReminder1.Text);
                    writer.WriteLine("");
                    writer.WriteLine("Reminder 2:");
                    writer.WriteLine(txtReminder2.Text);
                    writer.Dispose();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    writer.Dispose();
                    return false;
                }
                finally
                {
                    writer.Dispose();
                }
            }
            else
            {

                return false;
            }
        }

        private void helpGenerate_Click(object sender, EventArgs e)
        {

        }


        private bool saveFileToText()
        {
            StreamWriter writer = new StreamWriter($"{Application.StartupPath}/File.txt", false, Encoding.GetEncoding("GB2312")); ;
            try
            {
                for (int i =0;i<allLists.papers.Count;i++)
                {
                    writer.WriteLine("{");
                    writer.WriteLine(allLists.papers[i].paperName);
                    writer.WriteLine(allLists.papers[i].filePath);
                    writer.WriteLine("/%/");
                    for (int j=0;j<allLists.papers[i].sponsors.Count;j++)
                    {
                        writer.WriteLine(allLists.papers[i].sponsors[j]);
                    }
                    writer.WriteLine("/%/");
                    for (int j = 0; j < allLists.papers[i].signatories.Count; j++)
                    {
                        writer.WriteLine(allLists.papers[i].signatories[j]);
                    }
                    writer.WriteLine("/%/");
                    writer.WriteLine("}");
                }
                writer.Dispose();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "File.txt");
                writer.Dispose();
                return false;
            }

        }

        private void cmdDataSaveEvents_Click(object sender, EventArgs e)
        {
            PopUp pop = new PopUp(languageIndex, "Notice", "Conference progress will be saved in Text Files under the software path, and will be reloaded into the software next time. Original records will be overwrittten.", "提示", "会议进度将会被保存在软件根目录下的文本文档中，并将在下次启动软件时被重新载入。原记录将被覆盖。", lblFileDash.BackColor);
            pop.ShowDialog();
            MessageBoxButtons messcmd = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(multilingual("Are you sure to save conference progress?", "确认保存会议进度？"), multilingual("Warning", "警告"), messcmd);
            if (result == DialogResult.Yes)
            {
                PopUp popText = new PopUp(languageIndex, "Processing", "Please wait while we are saving...", "处理中", "正在保存，请等待...", lblFileDash.BackColor);
                popText.Show();
                if (saveEventToText() && saveFileToText() && saveDataToText())
                {
                    popText.Dispose();
                    PopUp complete = new PopUp(languageIndex, "Completed", "Progress Saved", "完成", "进度已保存", lblFileDash.BackColor);
                    complete.ShowDialog();
                }
                else
                {
                    popText.Dispose();
                    PopUp error = new PopUp(languageIndex, "Failed", "An error occured while we are saving the progress.", "失败", "保存进度出错。", lblFileDash.BackColor);
                    error.ShowDialog();
                }
            }
        }

        private bool saveEventToText()
        {
            StreamWriter writer = new StreamWriter($"{Application.StartupPath}/Event.txt", false, Encoding.GetEncoding("GB2312")); ;
            try
            {
                for (int i =0;i<listEvents.Items.Count;i++)
                {
                    writer.WriteLine(listEvents.Items[i].ToString());
                }
                writer.WriteLine();
                writer.WriteLine("--------");
                writer.Dispose();
                return true;
            }
            catch(Exception ex2)
            {
                MessageBox.Show(ex2.Message + "Event.txt");
                writer.Dispose();
                return false;
            }
        }

        private bool saveDataToText()
        {
            StreamWriter writer = new StreamWriter($"{Application.StartupPath}/Data.txt",false, Encoding.GetEncoding("GB2312"));
            try
            {
                for (int i=0;i<data.GetLength(0);i++)
                {
                    writer.WriteLine("//");
                    writer.WriteLine(allLists.allCountry[i]);
                    for (int j =1;j<8;j++)
                    {
                        writer.WriteLine(data[i,j].ToString());
                    }
                    
                    writer.WriteLine("//");
                }
                writer.WriteLine("/Reminder1/");
                writer.WriteLine(txtReminder1.Text);
                writer.WriteLine("/Reminder2/");
                writer.Write(txtReminder2.Text);
                writer.Dispose();
                return true;
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message + "Data.txt");
                writer.Dispose();
                return false;
            }
            finally
            {
                writer.Dispose();
            }
        }

        private void helpMonitor_Click(object sender, EventArgs e)
        {
            if (combHelpLanguage.SelectedIndex != -1)
            {
                Guide gui = new Guide(combHelpLanguage.SelectedIndex, 0);
                gui.Show();
            }
            else
            {
                Guide gui = new Guide(languageIndex, 0);
                gui.Show();
            }
        }

        private void listEvents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void helpLoad_Click(object sender, EventArgs e)
        {
            if (combHelpLanguage.SelectedIndex != -1)
            {
                Guide gui = new Guide(combHelpLanguage.SelectedIndex, 2);
                gui.Show();
            }
            else
            {
                Guide gui = new Guide(languageIndex, 2);
                gui.Show();
            }
        }

        private void helpLanguage_Click(object sender, EventArgs e)
        {
            if (combHelpLanguage.SelectedIndex != -1)
            {
                Guide gui = new Guide(combHelpLanguage.SelectedIndex, 1);
                gui.Show();
            }
            else
            {
                Guide gui = new Guide(languageIndex, 1);
                gui.Show();
            }
        }

        private void helpRaise_Click(object sender, EventArgs e)
        {
            if (combHelpLanguage.SelectedIndex != -1)
            {
                Guide gui = new Guide(combHelpLanguage.SelectedIndex, 3);
                gui.Show();
            }
            else
            {
                Guide gui = new Guide(languageIndex, 3);
                gui.Show();
            }
        }

        private void helpMC_Click(object sender, EventArgs e)
        {
            if (combHelpLanguage.SelectedIndex != -1)
            {
                Guide gui = new Guide(combHelpLanguage.SelectedIndex, 4);
                gui.Show();
            }
            else
            {
                Guide gui = new Guide(languageIndex, 4);
                gui.Show();
            }
        }

        private void helpUMC_Click(object sender, EventArgs e)
        {
            if (combHelpLanguage.SelectedIndex != -1)
            {
                Guide gui = new Guide(combHelpLanguage.SelectedIndex, 5);
                gui.Show();
            }
            else
            {
                Guide gui = new Guide(languageIndex, 5);
                gui.Show();
            }
        }

        private void helpSpeaker_Click(object sender, EventArgs e)
        {
            if (combHelpLanguage.SelectedIndex != -1)
            {
                Guide gui = new Guide(combHelpLanguage.SelectedIndex, 6);
                gui.Show();
            }
            else
            {
                Guide gui = new Guide(languageIndex, 6);
                gui.Show();
            }
        }

        private void helpSave_Click(object sender, EventArgs e)
        {
            if (combHelpLanguage.SelectedIndex != -1)
            {
                Guide gui = new Guide(combHelpLanguage.SelectedIndex, 9);
                gui.Show();
            }
            else
            {
                Guide gui = new Guide(languageIndex, 9);
                gui.Show();
            }
        }

        private void helpRoll_Click(object sender, EventArgs e)
        {
            if (combHelpLanguage.SelectedIndex != -1)
            {
                Guide gui = new Guide(combHelpLanguage.SelectedIndex, 7);
                gui.Show();
            }
            else
            {
                Guide gui = new Guide(languageIndex, 7);
                gui.Show();
            }
        }

        private void helpVoting_Click(object sender, EventArgs e)
        {
            if (combHelpLanguage.SelectedIndex != -1)
            {
                Guide gui = new Guide(combHelpLanguage.SelectedIndex, 8);
                gui.Show();
            }
            else
            {
                Guide gui = new Guide(languageIndex, 8);
                gui.Show();
            }
        }

        private void helpFile_Click(object sender, EventArgs e)
        {
            if (combHelpLanguage.SelectedIndex != -1)
            {
                Guide gui = new Guide(combHelpLanguage.SelectedIndex, 10);
                gui.Show();
            }
            else
            {
                Guide gui = new Guide(languageIndex, 10);
                gui.Show();
            }
        }

        private void helpTimer_Click(object sender, EventArgs e)
        {
            if (combHelpLanguage.SelectedIndex != -1)
            {
                Guide gui = new Guide(combHelpLanguage.SelectedIndex, 11);
                gui.Show();
            }
            else
            {
                Guide gui = new Guide(languageIndex, 11);
                gui.Show();
            }
        }

        private void helpAbout_Click(object sender, EventArgs e)
        {
            About abo = new About();
            abo.Show();
        }

        private void DaisConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainP.TopMost = false;
            if (!mainP.closed)
            {
                this.Focus();
                MessageBoxButtons but = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(multilingual("Are you sure to quit? All unsaved conference progress will be lost.", "确认退出？未保存的会议进程将会丢失。"), multilingual("Warning", "警告"), but);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    mainP.doNotAsk = true;
                }
                
            }
            mainP.closed = false;
        }
    }
    }

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
    public partial class MotionSelection : UserControl
    {
        public bool hasContentToDisplay;
        public bool hasMotionToPass;
        public bool hasMotionToFail;
        public bool clearTheScreen;
        public bool hasEvent;
        public int motionIndex = 0;
        public int languageIndex;
        public Motion newMotion;
        public MotionSelection()
        {
            InitializeComponent();
            hasContentToDisplay = false;
            hasMotionToPass = false;
            hasMotionToFail = false;
            clearTheScreen = false;
            hasEvent = false;          
        }

        public bool timeVerification(int motionIndex)//输入时间是否能整除
        {
            if (motionIndex == 0)
            {
                try
                {
                    int tryNumber = int.Parse((double.Parse(txtTTime.Text) * 60).ToString());//输入总时长是否有整数秒
                    if (txtTTime.Text != "" && txtSTime.Text != "" && (double.Parse(txtTTime.Text))*60 % double.Parse(txtSTime.Text) == 0.0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else if (motionIndex<3)
            {
                try
                {
                    int tryNumber = int.Parse((double.Parse(txtTTime.Text) * 60).ToString());//输入总时长是否有整数秒
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public void clearAndNotVisible()
        {
            txtTTime.Text = "";
            txtSTime.Text = "";
            txtTopic.Text = "";
            txtTTime.Visible = false;
            txtSTime.Visible = false;
            txtTopic.Visible = false;
            lblSTime.Visible = false;
            lblTTime.Visible = false;
            lblTopic.Visible = false;
            cmdDisplay.Enabled = false;
            cmdPass.Enabled = false;
            cmdFail.Enabled = false;
                
        }
        public bool speakingTimeTooShort()
        {
            if (motionIndex == 0)
            {
                if (double.Parse(txtSTime.Text) < 20)//防止发言时长误输入为分钟
                {
                    MessageBoxButtons messbutton = MessageBoxButtons.YesNo;
                    if (languageIndex == 0)
                    {
                        DialogResult result = MessageBox.Show($"Do you confirm to set speaking time to {txtSTime.Text} seconds?", "", messbutton);
                        if (result == DialogResult.Yes)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (languageIndex == 1)
                    {
                        DialogResult result = MessageBox.Show($"是否确认设置发言时间为{txtSTime.Text}秒？", "", messbutton);
                        if (result == DialogResult.Yes)
                        {
                            return true;

                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        
        public void inputError()
        {
            PopUp popUp = new PopUp(languageIndex, "Error", "Please Check Input Time", "错误", "请检查输入的时间", lblDash.BackColor);
            popUp.ShowDialog();
        }


        private void Display_Click(object sender, EventArgs e)
        {
            if (cmdDisplay.Text == "Display to Screen" | cmdDisplay.Text == "展示到屏幕")
            {
                if (combCountry.SelectedIndex != -1)
                {
                    if (timeVerification(motionIndex))//输入无误则立Flag通知Dais Console获取控件内容
                    {
                        if (speakingTimeTooShort())//防止分钟和秒混淆
                        {
                            newMotion = new Motion(combMotionType.SelectedIndex, combCountry.SelectedIndex, txtTTime.Text, txtSTime.Text, txtTopic.Text, false);
                            hasContentToDisplay = true;
                            hasEvent = true;
                            if (languageIndex == 0)//更新按钮
                            {
                                cmdDisplay.Text = "Remove from Screen";
                            }
                            if (languageIndex == 1)
                            {
                                cmdDisplay.Text = "从屏幕移除";
                            }
                        }
                    }
                    else
                    {
                        inputError();
                    }
                }
                else
                {
                    PopUp pop = new PopUp(languageIndex, "Content Missing", "Choose motion type and country to complete the motion", "内容缺失", "选择动议类型和国家以完成动议", lblDash.BackColor);
                    pop.ShowDialog();
                }
            }
            else//撤回屏幕上输出的内容
            {
                if (languageIndex == 0)//更新按钮
                {
                    cmdDisplay.Text = "Display to Screen";
                }
                if (languageIndex == 1)
                {
                    cmdDisplay.Text = "展示到屏幕";
                }
                clearTheScreen = true;//通知Dais Console清屏
                hasEvent = true;
            }
        }

        public void languageUpdate(int languageIndex)
        {
            this.languageIndex = languageIndex;
            switch (languageIndex)
            {
                case 0://英语
                    lblSTime.Text = "Speaking Time (sec):";
                    lblTTime.Text = "Total Time (min):";
                    lblTitle.Text = "New Motion";
                    lblTopic.Text = "Topic:";

                    cmdPass.Text = "Pass";
                    cmdFail.Text = "Fail";
                    cmdDisplay.Text = "Display to Screen";

                        combMotionType.Text = "Motion Type";
                        combCountry.Text = "Country";

                    break;
                case 1://简体中文
                    lblSTime.Text = "发言时长（秒）：";
                    lblTTime.Text = "总时长（分）：";
                    lblTitle.Text = "新动议";
                    lblTopic.Text = "主题：";

                    cmdPass.Text = "通过";
                    cmdFail.Text = "未通过";
                    cmdDisplay.Text = "展示到屏幕";


                        combMotionType.Text = "动议类型";
                        combCountry.Text = "国家";

                    combMotionType.Items.Clear();
                    combMotionType.Items.Add("有主持核心磋商");
                    combMotionType.Items.Add("自由磋商");
                    combMotionType.Items.Add("自由辩论");
                    combMotionType.Items.Add("暂休");
                    combMotionType.Items.Add("结束辩论");
                    combMotionType.Items.Add("其他");
                    break;
                case 2:

                    break;
            }
        }

        private void combMotionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combMotionType.SelectedIndex != -1)//随着不同的motion被选定，更改motionIndex
            {
                motionIndex = combMotionType.SelectedIndex;
                combCountry.Visible = true;
                clearAndNotVisible();//先不显示并清空所有的输入控件，再根据Case有选择性显示
                switch (motionIndex)
                {
                    case 0://MC
                        lblTopic.Visible = true;
                        txtTopic.Visible = true;
                        lblTTime.Visible = true;
                        txtTTime.Visible = true;
                        lblSTime.Visible = true;
                        txtSTime.Visible = true;
                        break;
                    case 1://UMC
                        lblTTime.Visible = true;
                        txtTTime.Visible = true;
                        break;
                    case 2://Free Debate
                        lblTTime.Visible = true;
                        txtTTime.Visible = true;
                        break;
                    case 3://Meeting Suspension

                        break;
                    case 4://Close Debate and Vote

                        break;
                    case 5://Other
                        lblTopic.Visible = true;
                        txtTopic.Visible = true;
                        break;
                }
                cmdDisplay.Enabled = true;
                cmdPass.Enabled = true;
                cmdFail.Enabled = true;
            }
            else
            {
                combCountry.Visible = false;
                combCountry.SelectedIndex = -1;
                clearAndNotVisible();
                languageUpdate(languageIndex);
            }
        }

        private void cmdPass_Click(object sender, EventArgs e)
        {
            if (combCountry.SelectedIndex != -1 && combMotionType.SelectedIndex != -1)
            {
                if (timeVerification(motionIndex))//输入无误则立Flag通知Dais Console获取控件内容
                {
                    if (speakingTimeTooShort())//防止分钟和秒混淆
                    {
                        newMotion = new Motion(combMotionType.SelectedIndex, combCountry.SelectedIndex, txtTTime.Text, txtSTime.Text, txtTopic.Text, true);
                        hasContentToDisplay = true;
                        hasMotionToPass = true;
                        hasEvent = true;
                    }
                }
                else
                {
                    inputError();
                }
            }
            else
            {
                PopUp pop = new PopUp(languageIndex, "Content Missing", "Choose motion type and country to complete the motion", "内容缺失", "选择动议类型和国家以完成动议", lblDash.BackColor);
                pop.ShowDialog();
            }
        }

        private void cmdFail_Click(object sender, EventArgs e)
        {
            if (combCountry.SelectedIndex != -1 && combMotionType.SelectedIndex != -1)
            {
                if (timeVerification(motionIndex))//输入无误则立Flag通知Dais Console获取控件内容
                {
                    if (speakingTimeTooShort())//防止分钟和秒混淆
                    {
                        if (cmdDisplay.Text == "Remove From Screen" | cmdDisplay.Text == "从屏幕移除")
                        {
                            clearTheScreen = true;
                        }
                        newMotion = new Motion(combMotionType.SelectedIndex, combCountry.SelectedIndex, txtTTime.Text, txtSTime.Text, txtTopic.Text, false);
                        hasMotionToFail = true;
                        hasEvent = true;

                    }
                }
                else
                {
                    inputError();
                }
            }
            else
            {
                PopUp pop = new PopUp(languageIndex, "Content Missing", "Choose motion type and country to complete the motion", "内容缺失", "选择动议类型和国家以完成动议", lblDash.BackColor);
                pop.ShowDialog();
            }
        }

        private void txtTopic_TextChanged(object sender, EventArgs e)
        {

        }

        private void combCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

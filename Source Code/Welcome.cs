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
    public partial class Welcome : Form
    {
        public DaisConsole daisC;
        public Lists lists;
        public Welcome()
        {
            InitializeComponent();
            lists = new Lists();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            
           
        }

        private void Welcome_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Welcome_Leave(object sender, EventArgs e)
        {
        }

        private void Welcome_Click(object sender, EventArgs e)
        {
        }

        private void cmdEnglish_Click(object sender, EventArgs e)
        {
            loadCountry(0);
            lblStatus.Text = "Done" + Environment.NewLine + "完成";
            lists.reloadData();
            double temp = double.Parse(numSessionLength.Value.ToString()) * 60;
            daisC = new DaisConsole(lists, 0, int.Parse(temp.ToString()));       
            daisC.Show();
            this.Visible = false;
        }

        private void loadCountry(int languageIndex)
        {
            string countryPath = Application.StartupPath;
            
            if (File.Exists($"{countryPath}/Country.txt"))
            {
                lblStatus.Text = "Loading Country.txt..." + Environment.NewLine + "正在读取 Country.txt...";
                lists.readFromTxt(languageIndex);


            }
            else
            {
                MessageBox.Show("Please create Country.txt under the application path, and enter countries line by line." + '\n' + "请在软件根目录创建 Country.txt，并逐行输入国家名。", "Can not find country list 找不到国家列表");
                Application.Exit();                
            }                          
            if (lists.allCountry.Count < 3)
            {
                MessageBox.Show("Please creat a list of over 2 countries." + '\n' + "请创建多于2个国家的国家列表。", "Error 错误");
                Application.Exit();
            }
        }

        private void cmdChinese_Click(object sender, EventArgs e)
        {
            loadCountry(1);           
            lblStatus.Text = "Done" + Environment.NewLine + "完成";
            lists.reloadData();
            double temp = double.Parse(numSessionLength.Value.ToString()) * 60;
            daisC = new DaisConsole(lists, 1, int.Parse(temp.ToString()));
            daisC.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timerDelay_Tick(object sender, EventArgs e)
        {
            
        }
    }
}

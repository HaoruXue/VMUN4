using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VMUN_4
{
    public partial class Guide : Form
    {
        int languageIndex;
        public Guide(int languageIndex, int guideIndex)
        {
            InitializeComponent();
            this.languageIndex = languageIndex;
            cmdC1.Text = multilingual("Close", "关闭");
            cmdC2.Text = multilingual("Close", "关闭");
            cmdC3.Text = multilingual("Close", "关闭");
            cmdC4.Text = multilingual("Close", "关闭");
            cmdP1.Text = multilingual("<<< Previous", "<<< 上一页");
            cmdP2.Text = multilingual("<<< Previous", "<<< 上一页");
            cmdP3.Text = multilingual("<<< Previous", "<<< 上一页");
            cmdP4.Text = multilingual("<<< Previous", "<<< 上一页");
            cmdN1.Text = multilingual("Next >>>", "下一页 >>>");
            cmdN2.Text = multilingual("Next >>>", "下一页 >>>");
            cmdN3.Text = multilingual("Next >>>", "下一页 >>>");
            cmdN4.Text = multilingual("Next >>>", "下一页 >>>");
            pullOutGuide(guideIndex);
            
        }

        private void pullOutGuide(int guideIndex)
        {
            
            switch (guideIndex)
            {
                case 0:
                    enableTabs(3);
                    this.Text = multilingual(Resource.h0TEng, Resource.h0TSimChn);
                    updateTitles(multilingual(Resource.h0P1TEng, Resource.h0P1TSimChn), multilingual(Resource.h0P2TEng, Resource.h0P2TSimChn), multilingual(Resource.h0P3TEng, Resource.h0P3TSimChn));
                    updateContents(multilingual(Resource.h0P1Eng, Resource.h0P1SimChn), multilingual(Resource.h0P2Eng, Resource.h0P2SimChn), multilingual(Resource.h0P3Eng, Resource.h0P3SimChn));
                    break;
                case 1:
                    enableTabs(1);
                    this.Text = multilingual(Resource.h1teng, Resource.h1tsimchn);
                    updateTitles(multilingual(Resource.h1p1teng, Resource.h1p1tschn));
                    updateContents(multilingual(Resource.h1p1eng, Resource.h1p1schn));
                    break;
                case 2:
                    enableTabs(2);
                    this.Text = multilingual(Resource.h2teng, Resource.h2tsimchn);
                    updateTitles(multilingual(Resource.h2p1teng, Resource.h2p1tsimchn),multilingual(Resource.h2p2teng, Resource.h2p2tsimchn));
                    updateContents(multilingual(Resource.h2p1eng, Resource.h2p1simchn), multilingual(Resource.h2p2eng, Resource.h2p2simchn));
                    break;
                case 3:
                    enableTabs(2);
                    this.Text = multilingual(Resource.h3teng, Resource.h3tschn);
                    updateTitles(multilingual(Resource.h3p1teng, Resource.h3p1tschn), multilingual(Resource.h3p2teng, Resource.h3p2tschn));
                    updateContents(multilingual(Resource.h3p1eng, Resource.h3p1schn), multilingual(Resource.h3p2eng, Resource.h3p2schn));
                    break;
                case 4:
                    enableTabs(3);
                    this.Text = multilingual(Resource.h4teng, Resource.h4tschn);
                    updateTitles(multilingual(Resource.h4p1teng, Resource.h4p1tschn), multilingual(Resource.h4p2teng, Resource.h4p2tschn), multilingual(Resource.h4p3teng, Resource.h4p3tschn));
                    updateContents(multilingual(Resource.h4p1eng, Resource.h4p1schn), multilingual(Resource.h4p2eng, Resource.h4p2schn), multilingual(Resource.h4p3eng, Resource.h4p3schn));
                    break;
                case 5:
                    enableTabs(1);
                    this.Text = multilingual(Resource.h5teng, Resource.h5tschn);
                    updateTitles(multilingual(Resource.h5p1teng, Resource.h5p1tschn));
                    updateContents(multilingual(Resource.h5p1eng, Resource.h5p1schn));
                    break;
                case 6:
                    enableTabs(2);
                    this.Text = multilingual(Resource.h6teng, Resource.h6tschn);
                    updateTitles(multilingual(Resource.h6p1teng, Resource.h6p1tschn), multilingual(Resource.h6p2teng, Resource.h6p2tschn));
                    updateContents(multilingual(Resource.h6p1eng, Resource.h6p1schn), multilingual(Resource.h6p2eng, Resource.h6p2schn));
                    break;
                case 7:
                    enableTabs(3);
                    this.Text = multilingual(Resource.h7teng, Resource.h7tschn);
                    updateTitles(multilingual(Resource.h7p1teng, Resource.h7p1tschn), multilingual(Resource.h7p2teng, Resource.h7p2tschn), multilingual(Resource.h7p3teng, Resource.h7p3tschn));
                    updateContents(multilingual(Resource.h7p1eng, Resource.h7p1schn), multilingual(Resource.h7p2eng, Resource.h7p2schn), multilingual(Resource.h7p3eng, Resource.h7p3schn));

                    break;
                case 8:
                    enableTabs(4);
                    this.Text = multilingual(Resource.h8teng, Resource.h8tschn);
                    updateTitles(multilingual(Resource.h8p1teng, Resource.h8p1tschn), multilingual(Resource.h8p2teng, Resource.h8p2tschn), multilingual(Resource.h8p3teng, Resource.h8p3tschn), multilingual(Resource.h8p4teng, Resource.h8p4tschn));
                    updateContents(multilingual(Resource.h8p1eng, Resource.h8p1schn), multilingual(Resource.h8p2eng, Resource.h8p2schn), multilingual(Resource.h8p3eng, Resource.h8p3schn), multilingual(Resource.h8p4eng, Resource.h8p4schn));
                    break;
                case 9:
                    enableTabs(2);
                    this.Text = multilingual(Resource.h9teng, Resource.h9tschn);
                    updateTitles(multilingual(Resource.h9p1teng, Resource.h9p1tschn), multilingual(Resource.h9p2teng, Resource.h9p2tschn));
                    updateContents(multilingual(Resource.h9p1eng, Resource.h9p1schn), multilingual(Resource.h9p2eng, Resource.h9p2schn));
                    break;
                case 10:
                    enableTabs(1);
                    this.Text = multilingual(Resource.h10teng, Resource.h10tschn);
                    updateTitles(multilingual(Resource.h10p1teng, Resource.h10p1tschn));
                    updateContents(multilingual(Resource.h10p1eng, Resource.h10p1schn));
                    break;
                case 11:
                    enableTabs(2);
                    this.Text = multilingual(Resource.h11teng, Resource.h11tschn);
                    updateTitles(multilingual(Resource.h11p1teng, Resource.h11p1tschn), multilingual(Resource.h11p2teng, Resource.h11p2tschn));
                    updateContents(multilingual(Resource.h11p1eng, Resource.h11p1schn), multilingual(Resource.h11p2eng, Resource.h11p2schn));
                    break;
                case 12:
                    enableTabs(1);

                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
            }
        }

        private void updateContents(string c1, string c2 = "", string c3 = "", string c4 = "")
        {
            txt1.Text = c1;
            txt2.Text = c2;
            txt3.Text = c3;
            txt4.Text = c4;
        }

        private void updateTitles(string t1, string t2 = "", string t3 = "",string t4 = "")
        {
            lblT1.Text = t1;
            lblT2.Text = t2;
            lblT3.Text = t3;
            lblT4.Text = t4;

        }

        private void enableTabs(int used)
        {
            if (used == 1)
            {
                cmdN1.Enabled = false;
                lblNum1.Text = "1/1";
            }
            else if (used ==2)
            {
                cmdN2.Enabled = false;
                lblNum1.Text = "1/2";
                lblNum2.Text = "2/2";
            }
            else if (used == 3)
            {
                cmdN3.Enabled = false;
                lblNum1.Text = "1/3";
                lblNum2.Text = "2/3";
                lblNum3.Text = "3/3";

            }
            else if (used ==4)
            {
                cmdN4.Enabled = false;
                lblNum1.Text = "1/4";
                lblNum2.Text = "2/4";
                lblNum3.Text = "3/4";
                tabMain.Text = "4/4";
            }
        }

        private void cmdN1_Click(object sender, EventArgs e)
        {
            tabMain.SelectTab(p2);
        }

        private void cmdP2_Click(object sender, EventArgs e)
        {
            tabMain.SelectTab(p1);
        }

        private void cmdN2_Click(object sender, EventArgs e)
        {
            tabMain.SelectTab(p3);
        }

        private void cmdP3_Click(object sender, EventArgs e)
        {
            tabMain.SelectTab(p2);
        }

        private void cmdN3_Click(object sender, EventArgs e)
        {
            tabMain.SelectTab(p4);
        }

        private void cmdP4_Click(object sender, EventArgs e)
        {
            tabMain.SelectTab(p3);
        }

        private string multilingual(string eng = "", string simCHN = "")
        {
            switch (this.languageIndex)
            {
                case 0:
                    return eng;                    
                case 1:
                    return simCHN;
                default:
                    return eng;
            }
        }

        private void p3_Click(object sender, EventArgs e)
        {

        }

        private void cmdC4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmdC1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmdC2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmdC3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

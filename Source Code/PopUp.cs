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
    public partial class PopUp : Form
    {
        public PopUp(int languageIndex, string promptEng, string contentEng, string promptSimChn, string contentSimChn, Color dashColor, string buttonEng = "", string buttonSimChn = "")
        {
            InitializeComponent();
            switch(languageIndex)
            {
                case 0:
                    if (buttonEng == "")
                        cmdConfirm.Text = "Got it";
                    else
                        cmdConfirm.Text = buttonEng;
                    lblPrompt.Text = promptEng;
                    lblContent.Text = contentEng;
                    break;
                case 1:
                    if (buttonSimChn == "")
                        cmdConfirm.Text = "我知道了";
                    else
                        cmdConfirm.Text = buttonSimChn;
                    lblPrompt.Text = promptSimChn;
                    lblContent.Text = contentSimChn;
                    break;
                        

            }
            this.TopMost = true; 

            lblDash.BackColor = dashColor;
        }

        private void cmdConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

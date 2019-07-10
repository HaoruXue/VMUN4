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
    public partial class Push : UserControl
    {
        public bool occupied;
        public int linkedEventIndex;
        public bool clicked;
        public Push()
        {
            InitializeComponent();
            occupied = false;
            linkedEventIndex = -1;
            clicked = false;
        }
        public void contentUpdate(int languageIndex, string engPrompt , string engContent, string chnPrompt, string chnContent)
        {
            this.Visible = true;
            occupied = true;
            switch (languageIndex)
            {
                case 0:
                    lblEventName.Text = engPrompt;
                    lblContent.Text = engContent;
                    break;

                case 1:
                    lblEventName.Text = chnPrompt;
                    lblContent.Text = chnContent;
                    break;           
            }
            
        }
        public void reset()
        {
            occupied = false;
            linkedEventIndex = -1;
            this.Visible = false;
            lblEventName.Text = "";
            lblContent.Text = "";
        }

        public void changePushVisibility()
        {
            if (lblContent.Text != "" | lblEventName.Text != "")
            {
               this.Visible = true;
            }
            else
            {
                this.Visible = false;
            }
        }
        private void Push_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void tblAll_MouseEnter(object sender, EventArgs e)
        {
        }

        private void tblAll_MouseLeave(object sender, EventArgs e)
        {
        }

        private void tblAll_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblEventName_MouseEnter(object sender, EventArgs e)
        {

        }

        private void Push_Load(object sender, EventArgs e)
        {
        }

        private void lblEventName_Click(object sender, EventArgs e)
        {
            Push_Click(sender, e);
        }

        private void Push_Click(object sender, EventArgs e)
        {
            clicked = true;
        }

        private void lblContent_Click(object sender, EventArgs e)
        {
            Push_Click(sender, e);
        }
    }
}

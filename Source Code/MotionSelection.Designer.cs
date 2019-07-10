namespace VMUN_4
{
    partial class MotionSelection
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.combMotionType = new System.Windows.Forms.ComboBox();
            this.tblAll = new System.Windows.Forms.TableLayoutPanel();
            this.cmdDisplay = new System.Windows.Forms.Button();
            this.lblTTime = new System.Windows.Forms.Label();
            this.lblTopic = new System.Windows.Forms.Label();
            this.combCountry = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTopic = new System.Windows.Forms.TextBox();
            this.txtTTime = new System.Windows.Forms.TextBox();
            this.lblSTime = new System.Windows.Forms.Label();
            this.txtSTime = new System.Windows.Forms.TextBox();
            this.tblPassFail = new System.Windows.Forms.TableLayoutPanel();
            this.cmdFail = new System.Windows.Forms.Button();
            this.cmdPass = new System.Windows.Forms.Button();
            this.lblDash = new System.Windows.Forms.Label();
            this.tblAll.SuspendLayout();
            this.tblPassFail.SuspendLayout();
            this.SuspendLayout();
            // 
            // combMotionType
            // 
            this.combMotionType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.combMotionType.BackColor = System.Drawing.Color.DimGray;
            this.combMotionType.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combMotionType.ForeColor = System.Drawing.Color.White;
            this.combMotionType.FormattingEnabled = true;
            this.combMotionType.IntegralHeight = false;
            this.combMotionType.Items.AddRange(new object[] {
            "Moderated Caucus",
            "Unmoderated Caucus",
            "Free Debate",
            "Meeting Suspension",
            "Close Debate",
            "Other"});
            this.combMotionType.Location = new System.Drawing.Point(6, 70);
            this.combMotionType.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.combMotionType.Name = "combMotionType";
            this.combMotionType.Size = new System.Drawing.Size(299, 39);
            this.combMotionType.TabIndex = 6;
            this.combMotionType.Text = "Motion Type";
            this.combMotionType.SelectedIndexChanged += new System.EventHandler(this.combMotionType_SelectedIndexChanged);
            // 
            // tblAll
            // 
            this.tblAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblAll.ColumnCount = 2;
            this.tblAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblAll.Controls.Add(this.cmdDisplay, 0, 10);
            this.tblAll.Controls.Add(this.lblTTime, 0, 5);
            this.tblAll.Controls.Add(this.lblTopic, 0, 3);
            this.tblAll.Controls.Add(this.combCountry, 0, 2);
            this.tblAll.Controls.Add(this.combMotionType, 0, 1);
            this.tblAll.Controls.Add(this.lblTitle, 0, 0);
            this.tblAll.Controls.Add(this.txtTopic, 0, 4);
            this.tblAll.Controls.Add(this.txtTTime, 0, 6);
            this.tblAll.Controls.Add(this.lblSTime, 0, 7);
            this.tblAll.Controls.Add(this.txtSTime, 0, 8);
            this.tblAll.Controls.Add(this.tblPassFail, 0, 9);
            this.tblAll.Controls.Add(this.lblDash, 1, 0);
            this.tblAll.Location = new System.Drawing.Point(6, 0);
            this.tblAll.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.tblAll.Name = "tblAll";
            this.tblAll.RowCount = 11;
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblAll.Size = new System.Drawing.Size(331, 638);
            this.tblAll.TabIndex = 2;
            // 
            // cmdDisplay
            // 
            this.cmdDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDisplay.Enabled = false;
            this.cmdDisplay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDisplay.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDisplay.ForeColor = System.Drawing.Color.White;
            this.cmdDisplay.Location = new System.Drawing.Point(6, 579);
            this.cmdDisplay.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cmdDisplay.Name = "cmdDisplay";
            this.cmdDisplay.Size = new System.Drawing.Size(299, 52);
            this.cmdDisplay.TabIndex = 5;
            this.cmdDisplay.Text = "Display to Screen";
            this.cmdDisplay.UseVisualStyleBackColor = true;
            this.cmdDisplay.Click += new System.EventHandler(this.Display_Click);
            // 
            // lblTTime
            // 
            this.lblTTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTTime.AutoSize = true;
            this.lblTTime.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTTime.ForeColor = System.Drawing.Color.White;
            this.lblTTime.Location = new System.Drawing.Point(6, 324);
            this.lblTTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTTime.Name = "lblTTime";
            this.lblTTime.Size = new System.Drawing.Size(299, 32);
            this.lblTTime.TabIndex = 10;
            this.lblTTime.Text = "Total Time (min)";
            this.lblTTime.Visible = false;
            // 
            // lblTopic
            // 
            this.lblTopic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopic.AutoSize = true;
            this.lblTopic.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopic.ForeColor = System.Drawing.Color.White;
            this.lblTopic.Location = new System.Drawing.Point(6, 171);
            this.lblTopic.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTopic.Name = "lblTopic";
            this.lblTopic.Size = new System.Drawing.Size(299, 32);
            this.lblTopic.TabIndex = 9;
            this.lblTopic.Text = "Topic";
            this.lblTopic.Visible = false;
            // 
            // combCountry
            // 
            this.combCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.combCountry.BackColor = System.Drawing.Color.DimGray;
            this.combCountry.DropDownHeight = 400;
            this.combCountry.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combCountry.ForeColor = System.Drawing.Color.White;
            this.combCountry.FormattingEnabled = true;
            this.combCountry.IntegralHeight = false;
            this.combCountry.Location = new System.Drawing.Point(6, 121);
            this.combCountry.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.combCountry.Name = "combCountry";
            this.combCountry.Size = new System.Drawing.Size(299, 39);
            this.combCountry.TabIndex = 7;
            this.combCountry.Text = "Country";
            this.combCountry.Visible = false;
            this.combCountry.SelectedIndexChanged += new System.EventHandler(this.combCountry_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(6, 4);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(163, 59);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Motion";
            // 
            // txtTopic
            // 
            this.txtTopic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTopic.BackColor = System.Drawing.Color.DimGray;
            this.txtTopic.ForeColor = System.Drawing.Color.White;
            this.txtTopic.Location = new System.Drawing.Point(3, 206);
            this.txtTopic.Multiline = true;
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.Size = new System.Drawing.Size(305, 96);
            this.txtTopic.TabIndex = 0;
            this.txtTopic.Visible = false;
            this.txtTopic.TextChanged += new System.EventHandler(this.txtTopic_TextChanged);
            // 
            // txtTTime
            // 
            this.txtTTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTTime.BackColor = System.Drawing.Color.DimGray;
            this.txtTTime.ForeColor = System.Drawing.Color.White;
            this.txtTTime.Location = new System.Drawing.Point(3, 360);
            this.txtTTime.Name = "txtTTime";
            this.txtTTime.Size = new System.Drawing.Size(305, 43);
            this.txtTTime.TabIndex = 1;
            this.txtTTime.Visible = false;
            // 
            // lblSTime
            // 
            this.lblSTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSTime.AutoSize = true;
            this.lblSTime.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTime.ForeColor = System.Drawing.Color.White;
            this.lblSTime.Location = new System.Drawing.Point(6, 426);
            this.lblSTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSTime.Name = "lblSTime";
            this.lblSTime.Size = new System.Drawing.Size(299, 32);
            this.lblSTime.TabIndex = 11;
            this.lblSTime.Text = "Speaking Time (sec)";
            this.lblSTime.Visible = false;
            // 
            // txtSTime
            // 
            this.txtSTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSTime.BackColor = System.Drawing.Color.DimGray;
            this.txtSTime.ForeColor = System.Drawing.Color.White;
            this.txtSTime.Location = new System.Drawing.Point(3, 462);
            this.txtSTime.Name = "txtSTime";
            this.txtSTime.Size = new System.Drawing.Size(305, 43);
            this.txtSTime.TabIndex = 2;
            this.txtSTime.Visible = false;
            // 
            // tblPassFail
            // 
            this.tblPassFail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblPassFail.ColumnCount = 2;
            this.tblPassFail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPassFail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPassFail.Controls.Add(this.cmdFail, 1, 0);
            this.tblPassFail.Controls.Add(this.cmdPass, 0, 0);
            this.tblPassFail.Location = new System.Drawing.Point(3, 512);
            this.tblPassFail.Name = "tblPassFail";
            this.tblPassFail.RowCount = 1;
            this.tblPassFail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPassFail.Size = new System.Drawing.Size(305, 57);
            this.tblPassFail.TabIndex = 13;
            // 
            // cmdFail
            // 
            this.cmdFail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFail.Enabled = false;
            this.cmdFail.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdFail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFail.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFail.ForeColor = System.Drawing.Color.White;
            this.cmdFail.Location = new System.Drawing.Point(158, 7);
            this.cmdFail.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cmdFail.Name = "cmdFail";
            this.cmdFail.Size = new System.Drawing.Size(141, 43);
            this.cmdFail.TabIndex = 4;
            this.cmdFail.Text = "Fail";
            this.cmdFail.UseVisualStyleBackColor = true;
            this.cmdFail.Click += new System.EventHandler(this.cmdFail_Click);
            // 
            // cmdPass
            // 
            this.cmdPass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPass.Enabled = false;
            this.cmdPass.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPass.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPass.ForeColor = System.Drawing.Color.White;
            this.cmdPass.Location = new System.Drawing.Point(6, 7);
            this.cmdPass.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cmdPass.Name = "cmdPass";
            this.cmdPass.Size = new System.Drawing.Size(140, 43);
            this.cmdPass.TabIndex = 3;
            this.cmdPass.Text = "Pass";
            this.cmdPass.UseVisualStyleBackColor = true;
            this.cmdPass.Click += new System.EventHandler(this.cmdPass_Click);
            // 
            // lblDash
            // 
            this.lblDash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDash.BackColor = System.Drawing.Color.Cyan;
            this.lblDash.Location = new System.Drawing.Point(323, 0);
            this.lblDash.Name = "lblDash";
            this.tblAll.SetRowSpan(this.lblDash, 11);
            this.lblDash.Size = new System.Drawing.Size(5, 638);
            this.lblDash.TabIndex = 14;
            this.lblDash.Text = "label6";
            // 
            // MotionSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.tblAll);
            this.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "MotionSelection";
            this.Size = new System.Drawing.Size(343, 638);
            this.tblAll.ResumeLayout(false);
            this.tblAll.PerformLayout();
            this.tblPassFail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTTime;
        private System.Windows.Forms.Label lblTopic;
        private System.Windows.Forms.Label lblSTime;
        private System.Windows.Forms.TableLayoutPanel tblPassFail;
        private System.Windows.Forms.Button cmdFail;
        private System.Windows.Forms.Button cmdPass;
        public System.Windows.Forms.ComboBox combMotionType;
        public System.Windows.Forms.ComboBox combCountry;
        public System.Windows.Forms.TextBox txtTopic;
        public System.Windows.Forms.TextBox txtTTime;
        public System.Windows.Forms.TextBox txtSTime;
        private System.Windows.Forms.Label lblDash;
        private System.Windows.Forms.Button cmdDisplay;
        public System.Windows.Forms.TableLayoutPanel tblAll;
        public System.Windows.Forms.Label lblTitle;
    }
}

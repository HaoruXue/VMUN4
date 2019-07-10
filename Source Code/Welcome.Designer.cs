namespace VMUN_4
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.cmdEnglish = new System.Windows.Forms.Button();
            this.cmdChinese = new System.Windows.Forms.Button();
            this.lblWorkingLanguage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSessionLength = new System.Windows.Forms.Label();
            this.numSessionLength = new System.Windows.Forms.NumericUpDown();
            this.lblHour = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.timerDelay = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSessionLength)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdEnglish
            // 
            this.cmdEnglish.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEnglish.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdEnglish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdEnglish.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEnglish.ForeColor = System.Drawing.Color.White;
            this.cmdEnglish.Location = new System.Drawing.Point(104, 397);
            this.cmdEnglish.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmdEnglish.Name = "cmdEnglish";
            this.cmdEnglish.Size = new System.Drawing.Size(171, 52);
            this.cmdEnglish.TabIndex = 4;
            this.cmdEnglish.Text = "English";
            this.cmdEnglish.UseVisualStyleBackColor = true;
            this.cmdEnglish.Click += new System.EventHandler(this.cmdEnglish_Click);
            // 
            // cmdChinese
            // 
            this.cmdChinese.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdChinese.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdChinese.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdChinese.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdChinese.ForeColor = System.Drawing.Color.White;
            this.cmdChinese.Location = new System.Drawing.Point(297, 397);
            this.cmdChinese.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmdChinese.Name = "cmdChinese";
            this.cmdChinese.Size = new System.Drawing.Size(171, 52);
            this.cmdChinese.TabIndex = 5;
            this.cmdChinese.Text = "简体中文";
            this.cmdChinese.UseVisualStyleBackColor = true;
            this.cmdChinese.Click += new System.EventHandler(this.cmdChinese_Click);
            // 
            // lblWorkingLanguage
            // 
            this.lblWorkingLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWorkingLanguage.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkingLanguage.ForeColor = System.Drawing.Color.White;
            this.lblWorkingLanguage.Location = new System.Drawing.Point(16, 304);
            this.lblWorkingLanguage.Name = "lblWorkingLanguage";
            this.lblWorkingLanguage.Size = new System.Drawing.Size(537, 75);
            this.lblWorkingLanguage.TabIndex = 6;
            this.lblWorkingLanguage.Text = "Select working language.\r\n选择工作语言。";
            this.lblWorkingLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-2, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(565, 202);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lblSessionLength
            // 
            this.lblSessionLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSessionLength.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessionLength.ForeColor = System.Drawing.Color.White;
            this.lblSessionLength.Location = new System.Drawing.Point(98, 212);
            this.lblSessionLength.Name = "lblSessionLength";
            this.lblSessionLength.Size = new System.Drawing.Size(242, 75);
            this.lblSessionLength.TabIndex = 8;
            this.lblSessionLength.Text = "Set session length:\r\n设置会期长度：";
            this.lblSessionLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSessionLength
            // 
            this.numSessionLength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numSessionLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numSessionLength.DecimalPlaces = 1;
            this.numSessionLength.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSessionLength.ForeColor = System.Drawing.Color.White;
            this.numSessionLength.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numSessionLength.Location = new System.Drawing.Point(326, 228);
            this.numSessionLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numSessionLength.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numSessionLength.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numSessionLength.Name = "numSessionLength";
            this.numSessionLength.Size = new System.Drawing.Size(76, 43);
            this.numSessionLength.TabIndex = 9;
            this.numSessionLength.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblHour
            // 
            this.lblHour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHour.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHour.ForeColor = System.Drawing.Color.White;
            this.lblHour.Location = new System.Drawing.Point(407, 212);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(132, 75);
            this.lblHour.TabIndex = 10;
            this.lblHour.Text = "Hour(s)\r\n小时";
            this.lblHour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(519, 417);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 42);
            this.button1.TabIndex = 11;
            this.button1.Text = "×";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(196, 160);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(367, 41);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Welcome to VMUN 4\r\n欢迎使用 VMUN 4";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerDelay
            // 
            this.timerDelay.Interval = 1000;
            this.timerDelay.Tick += new System.EventHandler(this.timerDelay_Tick);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(564, 459);
            this.ControlBox = false;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblHour);
            this.Controls.Add(this.numSessionLength);
            this.Controls.Add(this.lblSessionLength);
            this.Controls.Add(this.lblWorkingLanguage);
            this.Controls.Add(this.cmdChinese);
            this.Controls.Add(this.cmdEnglish);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Welcome";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virtual Model United Nations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Welcome_FormClosing);
            this.Load += new System.EventHandler(this.Welcome_Load);
            this.Click += new System.EventHandler(this.Welcome_Click);
            this.Leave += new System.EventHandler(this.Welcome_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSessionLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdEnglish;
        private System.Windows.Forms.Button cmdChinese;
        private System.Windows.Forms.Label lblWorkingLanguage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSessionLength;
        private System.Windows.Forms.NumericUpDown numSessionLength;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer timerDelay;
    }
}
namespace VMUN_4
{
    partial class MainPage
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.tblAll = new System.Windows.Forms.TableLayoutPanel();
            this.barSession = new System.Windows.Forms.ProgressBar();
            this.tblAttendance = new System.Windows.Forms.TableLayoutPanel();
            this.lblSystemTime = new System.Windows.Forms.Label();
            this.lblSM = new System.Windows.Forms.Label();
            this.lblAM = new System.Windows.Forms.Label();
            this.tblCommitteeAndTopic = new System.Windows.Forms.TableLayoutPanel();
            this.txtTopicName = new System.Windows.Forms.TextBox();
            this.txtCommitteeName = new System.Windows.Forms.TextBox();
            this.txtConferenceName = new System.Windows.Forms.TextBox();
            this.lblUpperDash = new System.Windows.Forms.Label();
            this.lblLowerDash = new System.Windows.Forms.Label();
            this.tblTimeAndList = new System.Windows.Forms.TableLayoutPanel();
            this.lblBigTime = new System.Windows.Forms.Label();
            this.lblSmallTime = new System.Windows.Forms.Label();
            this.listCountry = new System.Windows.Forms.ListBox();
            this.tblProgress = new System.Windows.Forms.TableLayoutPanel();
            this.lblNextCountry = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.lblNowCountry = new System.Windows.Forms.Label();
            this.timerSystemTime = new System.Windows.Forms.Timer(this.components);
            this.tblInstruction = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmdOneMonitor = new System.Windows.Forms.Button();
            this.lblGuide = new System.Windows.Forms.Label();
            this.cmdConfirm = new System.Windows.Forms.Button();
            this.tblAll.SuspendLayout();
            this.tblAttendance.SuspendLayout();
            this.tblCommitteeAndTopic.SuspendLayout();
            this.tblTimeAndList.SuspendLayout();
            this.tblProgress.SuspendLayout();
            this.tblInstruction.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblAll
            // 
            this.tblAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tblAll.ColumnCount = 2;
            this.tblAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 694F));
            this.tblAll.Controls.Add(this.barSession, 0, 4);
            this.tblAll.Controls.Add(this.tblAttendance, 1, 4);
            this.tblAll.Controls.Add(this.tblCommitteeAndTopic, 1, 0);
            this.tblAll.Controls.Add(this.txtConferenceName, 0, 0);
            this.tblAll.Controls.Add(this.lblUpperDash, 0, 1);
            this.tblAll.Controls.Add(this.lblLowerDash, 0, 3);
            this.tblAll.Controls.Add(this.tblTimeAndList, 0, 2);
            this.tblAll.Controls.Add(this.tblProgress, 1, 2);
            this.tblAll.Enabled = false;
            this.tblAll.Location = new System.Drawing.Point(22, -1);
            this.tblAll.Name = "tblAll";
            this.tblAll.RowCount = 5;
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblAll.Size = new System.Drawing.Size(961, 710);
            this.tblAll.TabIndex = 0;
            this.tblAll.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // barSession
            // 
            this.barSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.barSession.Location = new System.Drawing.Point(3, 665);
            this.barSession.Name = "barSession";
            this.barSession.Size = new System.Drawing.Size(261, 17);
            this.barSession.TabIndex = 1;
            this.barSession.Click += new System.EventHandler(this.barSession_Click);
            // 
            // tblAttendance
            // 
            this.tblAttendance.ColumnCount = 2;
            this.tblAttendance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblAttendance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblAttendance.Controls.Add(this.lblSystemTime, 0, 0);
            this.tblAttendance.Controls.Add(this.lblSM, 1, 0);
            this.tblAttendance.Controls.Add(this.lblAM, 1, 1);
            this.tblAttendance.Location = new System.Drawing.Point(270, 640);
            this.tblAttendance.Name = "tblAttendance";
            this.tblAttendance.RowCount = 2;
            this.tblAttendance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblAttendance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblAttendance.Size = new System.Drawing.Size(688, 67);
            this.tblAttendance.TabIndex = 0;
            // 
            // lblSystemTime
            // 
            this.lblSystemTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSystemTime.AutoSize = true;
            this.lblSystemTime.Location = new System.Drawing.Point(3, 0);
            this.lblSystemTime.Name = "lblSystemTime";
            this.tblAttendance.SetRowSpan(this.lblSystemTime, 2);
            this.lblSystemTime.Size = new System.Drawing.Size(338, 67);
            this.lblSystemTime.TabIndex = 0;
            this.lblSystemTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSM
            // 
            this.lblSM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSM.AutoSize = true;
            this.lblSM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSM.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSM.Location = new System.Drawing.Point(347, 0);
            this.lblSM.Name = "lblSM";
            this.lblSM.Size = new System.Drawing.Size(338, 33);
            this.lblSM.TabIndex = 2;
            this.lblSM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAM
            // 
            this.lblAM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAM.AutoSize = true;
            this.lblAM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAM.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAM.Location = new System.Drawing.Point(347, 33);
            this.lblAM.Name = "lblAM";
            this.lblAM.Size = new System.Drawing.Size(338, 34);
            this.lblAM.TabIndex = 6;
            this.lblAM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tblCommitteeAndTopic
            // 
            this.tblCommitteeAndTopic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblCommitteeAndTopic.ColumnCount = 1;
            this.tblCommitteeAndTopic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCommitteeAndTopic.Controls.Add(this.txtTopicName, 0, 1);
            this.tblCommitteeAndTopic.Controls.Add(this.txtCommitteeName, 0, 0);
            this.tblCommitteeAndTopic.Location = new System.Drawing.Point(270, 3);
            this.tblCommitteeAndTopic.Name = "tblCommitteeAndTopic";
            this.tblCommitteeAndTopic.RowCount = 2;
            this.tblCommitteeAndTopic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.26415F));
            this.tblCommitteeAndTopic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.73585F));
            this.tblCommitteeAndTopic.Size = new System.Drawing.Size(688, 128);
            this.tblCommitteeAndTopic.TabIndex = 1;
            // 
            // txtTopicName
            // 
            this.txtTopicName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTopicName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTopicName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTopicName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTopicName.ForeColor = System.Drawing.Color.White;
            this.txtTopicName.Location = new System.Drawing.Point(3, 83);
            this.txtTopicName.Name = "txtTopicName";
            this.txtTopicName.Size = new System.Drawing.Size(682, 40);
            this.txtTopicName.TabIndex = 5;
            this.txtTopicName.Text = "Topic";
            this.txtTopicName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTopicName.MouseEnter += new System.EventHandler(this.txtTopicName_MouseEnter);
            this.txtTopicName.MouseLeave += new System.EventHandler(this.txtTopicName_MouseLeave);
            // 
            // txtCommitteeName
            // 
            this.txtCommitteeName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommitteeName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCommitteeName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCommitteeName.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommitteeName.ForeColor = System.Drawing.Color.White;
            this.txtCommitteeName.Location = new System.Drawing.Point(3, 10);
            this.txtCommitteeName.Name = "txtCommitteeName";
            this.txtCommitteeName.Size = new System.Drawing.Size(682, 58);
            this.txtCommitteeName.TabIndex = 4;
            this.txtCommitteeName.Text = "Committee";
            this.txtCommitteeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCommitteeName.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txtCommitteeName.MouseEnter += new System.EventHandler(this.txtCommitteeName_MouseEnter);
            this.txtCommitteeName.MouseLeave += new System.EventHandler(this.txtCommitteeName_MouseLeave);
            // 
            // txtConferenceName
            // 
            this.txtConferenceName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConferenceName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConferenceName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConferenceName.Font = new System.Drawing.Font("Segoe UI", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConferenceName.ForeColor = System.Drawing.Color.White;
            this.txtConferenceName.Location = new System.Drawing.Point(3, 20);
            this.txtConferenceName.Name = "txtConferenceName";
            this.txtConferenceName.Size = new System.Drawing.Size(261, 94);
            this.txtConferenceName.TabIndex = 3;
            this.txtConferenceName.Text = "VMUN";
            this.txtConferenceName.MouseEnter += new System.EventHandler(this.txtConferenceName_MouseEnter);
            this.txtConferenceName.MouseLeave += new System.EventHandler(this.txtConferenceName_MouseLeave);
            // 
            // lblUpperDash
            // 
            this.lblUpperDash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpperDash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tblAll.SetColumnSpan(this.lblUpperDash, 2);
            this.lblUpperDash.Location = new System.Drawing.Point(3, 142);
            this.lblUpperDash.Name = "lblUpperDash";
            this.lblUpperDash.Size = new System.Drawing.Size(955, 5);
            this.lblUpperDash.TabIndex = 4;
            // 
            // lblLowerDash
            // 
            this.lblLowerDash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLowerDash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tblAll.SetColumnSpan(this.lblLowerDash, 2);
            this.lblLowerDash.Location = new System.Drawing.Point(3, 624);
            this.lblLowerDash.Name = "lblLowerDash";
            this.lblLowerDash.Size = new System.Drawing.Size(955, 5);
            this.lblLowerDash.TabIndex = 5;
            // 
            // tblTimeAndList
            // 
            this.tblTimeAndList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblTimeAndList.ColumnCount = 1;
            this.tblTimeAndList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblTimeAndList.Controls.Add(this.lblBigTime, 0, 0);
            this.tblTimeAndList.Controls.Add(this.lblSmallTime, 0, 2);
            this.tblTimeAndList.Controls.Add(this.listCountry, 0, 4);
            this.tblTimeAndList.Location = new System.Drawing.Point(3, 158);
            this.tblTimeAndList.Name = "tblTimeAndList";
            this.tblTimeAndList.RowCount = 5;
            this.tblTimeAndList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tblTimeAndList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tblTimeAndList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.tblTimeAndList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tblTimeAndList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56F));
            this.tblTimeAndList.Size = new System.Drawing.Size(261, 455);
            this.tblTimeAndList.TabIndex = 6;
            // 
            // lblBigTime
            // 
            this.lblBigTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBigTime.AutoSize = true;
            this.lblBigTime.BackColor = System.Drawing.Color.DimGray;
            this.lblBigTime.Font = new System.Drawing.Font("Segoe UI", 64F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBigTime.Location = new System.Drawing.Point(3, 0);
            this.lblBigTime.Name = "lblBigTime";
            this.lblBigTime.Size = new System.Drawing.Size(255, 122);
            this.lblBigTime.TabIndex = 5;
            this.lblBigTime.Text = "00";
            this.lblBigTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSmallTime
            // 
            this.lblSmallTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSmallTime.AutoSize = true;
            this.lblSmallTime.BackColor = System.Drawing.Color.DimGray;
            this.lblSmallTime.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSmallTime.Location = new System.Drawing.Point(3, 135);
            this.lblSmallTime.Name = "lblSmallTime";
            this.lblSmallTime.Size = new System.Drawing.Size(255, 50);
            this.lblSmallTime.TabIndex = 8;
            this.lblSmallTime.Text = "00:00";
            this.lblSmallTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listCountry
            // 
            this.listCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listCountry.BackColor = System.Drawing.Color.DimGray;
            this.listCountry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listCountry.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listCountry.ForeColor = System.Drawing.Color.White;
            this.listCountry.FormattingEnabled = true;
            this.listCountry.IntegralHeight = false;
            this.listCountry.ItemHeight = 41;
            this.listCountry.Location = new System.Drawing.Point(3, 201);
            this.listCountry.Name = "listCountry";
            this.listCountry.Size = new System.Drawing.Size(255, 251);
            this.listCountry.TabIndex = 9;
            // 
            // tblProgress
            // 
            this.tblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblProgress.ColumnCount = 1;
            this.tblProgress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 688F));
            this.tblProgress.Controls.Add(this.lblNextCountry, 0, 4);
            this.tblProgress.Controls.Add(this.lblTitle, 0, 0);
            this.tblProgress.Controls.Add(this.lblContent, 0, 1);
            this.tblProgress.Controls.Add(this.lblNowCountry, 0, 3);
            this.tblProgress.Location = new System.Drawing.Point(270, 158);
            this.tblProgress.Name = "tblProgress";
            this.tblProgress.RowCount = 5;
            this.tblProgress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.27451F));
            this.tblProgress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.65686F));
            this.tblProgress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.186275F));
            this.tblProgress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.93137F));
            this.tblProgress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.95098F));
            this.tblProgress.Size = new System.Drawing.Size(688, 455);
            this.tblProgress.TabIndex = 7;
            // 
            // lblNextCountry
            // 
            this.lblNextCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNextCountry.AutoSize = true;
            this.lblNextCountry.BackColor = System.Drawing.Color.DimGray;
            this.lblNextCountry.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextCountry.Location = new System.Drawing.Point(3, 385);
            this.lblNextCountry.Name = "lblNextCountry";
            this.lblNextCountry.Size = new System.Drawing.Size(682, 70);
            this.lblNextCountry.TabIndex = 10;
            this.lblNextCountry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Gray;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(682, 51);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblContent
            // 
            this.lblContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContent.AutoSize = true;
            this.lblContent.BackColor = System.Drawing.Color.DimGray;
            this.lblContent.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContent.Location = new System.Drawing.Point(3, 51);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(682, 134);
            this.lblContent.TabIndex = 8;
            this.lblContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNowCountry
            // 
            this.lblNowCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNowCountry.AutoSize = true;
            this.lblNowCountry.BackColor = System.Drawing.Color.DimGray;
            this.lblNowCountry.Font = new System.Drawing.Font("Segoe UI", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNowCountry.Location = new System.Drawing.Point(3, 199);
            this.lblNowCountry.Name = "lblNowCountry";
            this.lblNowCountry.Size = new System.Drawing.Size(682, 186);
            this.lblNowCountry.TabIndex = 9;
            this.lblNowCountry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerSystemTime
            // 
            this.timerSystemTime.Enabled = true;
            this.timerSystemTime.Interval = 1000;
            this.timerSystemTime.Tick += new System.EventHandler(this.timerSystemTime_Tick);
            // 
            // tblInstruction
            // 
            this.tblInstruction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tblInstruction.Controls.Add(this.textBox3);
            this.tblInstruction.Controls.Add(this.textBox2);
            this.tblInstruction.Controls.Add(this.textBox1);
            this.tblInstruction.Controls.Add(this.cmdOneMonitor);
            this.tblInstruction.Controls.Add(this.lblGuide);
            this.tblInstruction.Controls.Add(this.cmdConfirm);
            this.tblInstruction.Location = new System.Drawing.Point(73, 184);
            this.tblInstruction.Name = "tblInstruction";
            this.tblInstruction.Size = new System.Drawing.Size(869, 389);
            this.tblInstruction.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.DimGray;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(55, 199);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(775, 43);
            this.textBox3.TabIndex = 11;
            this.textBox3.Tag = "";
            this.textBox3.Click += new System.EventHandler(this.textBox3_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.DimGray;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(468, 118);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(362, 43);
            this.textBox2.TabIndex = 10;
            this.textBox2.Tag = "";
            this.textBox2.Click += new System.EventHandler(this.textBox2_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DimGray;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(55, 118);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(362, 43);
            this.textBox1.TabIndex = 9;
            this.textBox1.Tag = "";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cmdOneMonitor
            // 
            this.cmdOneMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOneMonitor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdOneMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOneMonitor.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOneMonitor.ForeColor = System.Drawing.Color.White;
            this.cmdOneMonitor.Location = new System.Drawing.Point(498, 301);
            this.cmdOneMonitor.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cmdOneMonitor.Name = "cmdOneMonitor";
            this.cmdOneMonitor.Size = new System.Drawing.Size(328, 60);
            this.cmdOneMonitor.TabIndex = 8;
            this.cmdOneMonitor.Text = "Help me with it";
            this.cmdOneMonitor.UseVisualStyleBackColor = true;
            this.cmdOneMonitor.Click += new System.EventHandler(this.cmdOneMonitor_Click);
            // 
            // lblGuide
            // 
            this.lblGuide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGuide.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuide.ForeColor = System.Drawing.Color.White;
            this.lblGuide.Location = new System.Drawing.Point(48, 16);
            this.lblGuide.Name = "lblGuide";
            this.lblGuide.Size = new System.Drawing.Size(778, 80);
            this.lblGuide.TabIndex = 7;
            this.lblGuide.Text = "Please connect second monitor (projector).\r\n请连接第二显示器（投影仪）。";
            this.lblGuide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdConfirm
            // 
            this.cmdConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdConfirm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdConfirm.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdConfirm.ForeColor = System.Drawing.Color.White;
            this.cmdConfirm.Location = new System.Drawing.Point(54, 301);
            this.cmdConfirm.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Size = new System.Drawing.Size(328, 60);
            this.cmdConfirm.TabIndex = 5;
            this.cmdConfirm.Text = "Confirm";
            this.cmdConfirm.UseVisualStyleBackColor = true;
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.tblInstruction);
            this.Controls.Add(this.tblAll);
            this.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virtual Model United Nations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPage_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainPage_FormClosed);
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.tblAll.ResumeLayout(false);
            this.tblAll.PerformLayout();
            this.tblAttendance.ResumeLayout(false);
            this.tblAttendance.PerformLayout();
            this.tblCommitteeAndTopic.ResumeLayout(false);
            this.tblCommitteeAndTopic.PerformLayout();
            this.tblTimeAndList.ResumeLayout(false);
            this.tblTimeAndList.PerformLayout();
            this.tblProgress.ResumeLayout(false);
            this.tblProgress.PerformLayout();
            this.tblInstruction.ResumeLayout(false);
            this.tblInstruction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblAll;
        private System.Windows.Forms.TableLayoutPanel tblAttendance;
        private System.Windows.Forms.TableLayoutPanel tblCommitteeAndTopic;
        private System.Windows.Forms.Label lblUpperDash;
        private System.Windows.Forms.Label lblLowerDash;
        private System.Windows.Forms.Label lblSM;
        private System.Windows.Forms.Label lblAM;
        private System.Windows.Forms.Label lblSystemTime;
        private System.Windows.Forms.TableLayoutPanel tblTimeAndList;
        private System.Windows.Forms.TableLayoutPanel tblProgress;
        public System.Windows.Forms.Label lblBigTime;
        public System.Windows.Forms.Label lblSmallTime;
        public System.Windows.Forms.ListBox listCountry;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Label lblContent;
        public System.Windows.Forms.Label lblNowCountry;
        private System.Windows.Forms.Timer timerSystemTime;
        private System.Windows.Forms.Panel tblInstruction;
        private System.Windows.Forms.Button cmdConfirm;
        private System.Windows.Forms.Label lblGuide;
        private System.Windows.Forms.Button cmdOneMonitor;
        public System.Windows.Forms.ProgressBar barSession;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox txtConferenceName;
        public System.Windows.Forms.TextBox txtCommitteeName;
        public System.Windows.Forms.TextBox txtTopicName;
        public System.Windows.Forms.Label lblNextCountry;
    }
}


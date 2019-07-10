namespace VMUN_4
{
    partial class NewEvent
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
            this.components = new System.ComponentModel.Container();
            this.tblAll = new System.Windows.Forms.TableLayoutPanel();
            this.cmdFile = new System.Windows.Forms.Button();
            this.cmdSpeaker = new System.Windows.Forms.Button();
            this.cmdMotion = new System.Windows.Forms.Button();
            this.tblTimeControl = new System.Windows.Forms.TableLayoutPanel();
            this.tblTime = new System.Windows.Forms.TableLayoutPanel();
            this.lblSmallTime = new System.Windows.Forms.Label();
            this.lblBigTime = new System.Windows.Forms.Label();
            this.tblButtons = new System.Windows.Forms.TableLayoutPanel();
            this.cmdPause = new System.Windows.Forms.Button();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdExpire = new System.Windows.Forms.Button();
            this.lblNewEvent = new System.Windows.Forms.Label();
            this.lblDash = new System.Windows.Forms.Label();
            this.tblSystemTimeAndSettings = new System.Windows.Forms.TableLayoutPanel();
            this.cmdSettings = new System.Windows.Forms.Button();
            this.lblSystemTime = new System.Windows.Forms.Label();
            this.lblSessionCountDown = new System.Windows.Forms.Label();
            this.cmdRollCall = new System.Windows.Forms.Button();
            this.cmdTimerReminder = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.timerSystemTime = new System.Windows.Forms.Timer(this.components);
            this.timerSessionTime = new System.Windows.Forms.Timer(this.components);
            this.tblAll.SuspendLayout();
            this.tblTimeControl.SuspendLayout();
            this.tblTime.SuspendLayout();
            this.tblButtons.SuspendLayout();
            this.tblSystemTimeAndSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblAll
            // 
            this.tblAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblAll.ColumnCount = 2;
            this.tblAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblAll.Controls.Add(this.cmdFile, 0, 5);
            this.tblAll.Controls.Add(this.cmdSpeaker, 0, 4);
            this.tblAll.Controls.Add(this.cmdMotion, 0, 2);
            this.tblAll.Controls.Add(this.tblTimeControl, 0, 0);
            this.tblAll.Controls.Add(this.lblNewEvent, 0, 1);
            this.tblAll.Controls.Add(this.lblDash, 1, 0);
            this.tblAll.Controls.Add(this.tblSystemTimeAndSettings, 0, 9);
            this.tblAll.Controls.Add(this.cmdRollCall, 0, 3);
            this.tblAll.Controls.Add(this.cmdTimerReminder, 0, 6);
            this.tblAll.Controls.Add(this.cmdSave, 0, 7);
            this.tblAll.Location = new System.Drawing.Point(3, 3);
            this.tblAll.Name = "tblAll";
            this.tblAll.RowCount = 10;
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.tblAll.Size = new System.Drawing.Size(403, 684);
            this.tblAll.TabIndex = 0;
            this.tblAll.Paint += new System.Windows.Forms.PaintEventHandler(this.tblAll_Paint);
            // 
            // cmdFile
            // 
            this.cmdFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFile.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFile.Location = new System.Drawing.Point(3, 442);
            this.cmdFile.Name = "cmdFile";
            this.cmdFile.Size = new System.Drawing.Size(377, 48);
            this.cmdFile.TabIndex = 5;
            this.cmdFile.Text = "Submit File";
            this.cmdFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdFile.UseVisualStyleBackColor = true;
            // 
            // cmdSpeaker
            // 
            this.cmdSpeaker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSpeaker.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdSpeaker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSpeaker.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSpeaker.Location = new System.Drawing.Point(3, 388);
            this.cmdSpeaker.Name = "cmdSpeaker";
            this.cmdSpeaker.Size = new System.Drawing.Size(377, 48);
            this.cmdSpeaker.TabIndex = 4;
            this.cmdSpeaker.Text = "Set Speaker\'s List";
            this.cmdSpeaker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSpeaker.UseVisualStyleBackColor = true;
            // 
            // cmdMotion
            // 
            this.cmdMotion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMotion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdMotion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMotion.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMotion.Location = new System.Drawing.Point(3, 280);
            this.cmdMotion.Name = "cmdMotion";
            this.cmdMotion.Size = new System.Drawing.Size(377, 48);
            this.cmdMotion.TabIndex = 3;
            this.cmdMotion.Text = "Raise a Motion";
            this.cmdMotion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdMotion.UseVisualStyleBackColor = true;
            // 
            // tblTimeControl
            // 
            this.tblTimeControl.ColumnCount = 2;
            this.tblTimeControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tblTimeControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblTimeControl.Controls.Add(this.tblTime, 0, 0);
            this.tblTimeControl.Controls.Add(this.tblButtons, 1, 0);
            this.tblTimeControl.Location = new System.Drawing.Point(3, 3);
            this.tblTimeControl.Name = "tblTimeControl";
            this.tblTimeControl.RowCount = 1;
            this.tblTimeControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblTimeControl.Size = new System.Drawing.Size(377, 162);
            this.tblTimeControl.TabIndex = 0;
            // 
            // tblTime
            // 
            this.tblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblTime.ColumnCount = 1;
            this.tblTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblTime.Controls.Add(this.lblSmallTime, 0, 1);
            this.tblTime.Controls.Add(this.lblBigTime, 0, 0);
            this.tblTime.Location = new System.Drawing.Point(3, 3);
            this.tblTime.Name = "tblTime";
            this.tblTime.RowCount = 2;
            this.tblTime.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.20202F));
            this.tblTime.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.79798F));
            this.tblTime.Size = new System.Drawing.Size(220, 156);
            this.tblTime.TabIndex = 0;
            // 
            // lblSmallTime
            // 
            this.lblSmallTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSmallTime.AutoSize = true;
            this.lblSmallTime.BackColor = System.Drawing.Color.DimGray;
            this.lblSmallTime.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSmallTime.Location = new System.Drawing.Point(3, 109);
            this.lblSmallTime.Name = "lblSmallTime";
            this.lblSmallTime.Size = new System.Drawing.Size(214, 47);
            this.lblSmallTime.TabIndex = 1;
            this.lblSmallTime.Text = "Speaker\'s List";
            this.lblSmallTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBigTime
            // 
            this.lblBigTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBigTime.AutoSize = true;
            this.lblBigTime.BackColor = System.Drawing.Color.DimGray;
            this.lblBigTime.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBigTime.Location = new System.Drawing.Point(3, 0);
            this.lblBigTime.Name = "lblBigTime";
            this.lblBigTime.Size = new System.Drawing.Size(214, 109);
            this.lblBigTime.TabIndex = 0;
            this.lblBigTime.Text = "104";
            this.lblBigTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblButtons
            // 
            this.tblButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblButtons.ColumnCount = 1;
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblButtons.Controls.Add(this.cmdPause, 0, 1);
            this.tblButtons.Controls.Add(this.cmdStart, 0, 0);
            this.tblButtons.Controls.Add(this.cmdNext, 0, 2);
            this.tblButtons.Controls.Add(this.cmdExpire, 0, 3);
            this.tblButtons.Location = new System.Drawing.Point(229, 3);
            this.tblButtons.Name = "tblButtons";
            this.tblButtons.RowCount = 4;
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblButtons.Size = new System.Drawing.Size(145, 156);
            this.tblButtons.TabIndex = 1;
            // 
            // cmdPause
            // 
            this.cmdPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPause.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPause.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPause.Location = new System.Drawing.Point(3, 42);
            this.cmdPause.Name = "cmdPause";
            this.cmdPause.Size = new System.Drawing.Size(139, 33);
            this.cmdPause.TabIndex = 2;
            this.cmdPause.Text = "Pause";
            this.cmdPause.UseVisualStyleBackColor = true;
            // 
            // cmdStart
            // 
            this.cmdStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdStart.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdStart.Location = new System.Drawing.Point(3, 3);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(139, 33);
            this.cmdStart.TabIndex = 0;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            // 
            // cmdNext
            // 
            this.cmdNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNext.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNext.Location = new System.Drawing.Point(3, 81);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(139, 33);
            this.cmdNext.TabIndex = 1;
            this.cmdNext.Text = "Next";
            this.cmdNext.UseVisualStyleBackColor = true;
            // 
            // cmdExpire
            // 
            this.cmdExpire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExpire.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdExpire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExpire.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExpire.Location = new System.Drawing.Point(3, 120);
            this.cmdExpire.Name = "cmdExpire";
            this.cmdExpire.Size = new System.Drawing.Size(139, 33);
            this.cmdExpire.TabIndex = 3;
            this.cmdExpire.Text = "Expire";
            this.cmdExpire.UseVisualStyleBackColor = true;
            // 
            // lblNewEvent
            // 
            this.lblNewEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNewEvent.AutoSize = true;
            this.lblNewEvent.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewEvent.Location = new System.Drawing.Point(3, 181);
            this.lblNewEvent.Name = "lblNewEvent";
            this.lblNewEvent.Size = new System.Drawing.Size(377, 96);
            this.lblNewEvent.TabIndex = 1;
            this.lblNewEvent.Text = "New Event";
            this.lblNewEvent.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblDash
            // 
            this.lblDash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDash.BackColor = System.Drawing.Color.GreenYellow;
            this.lblDash.Location = new System.Drawing.Point(395, 0);
            this.lblDash.Name = "lblDash";
            this.tblAll.SetRowSpan(this.lblDash, 10);
            this.lblDash.Size = new System.Drawing.Size(5, 684);
            this.lblDash.TabIndex = 9;
            this.lblDash.Text = "label6";
            // 
            // tblSystemTimeAndSettings
            // 
            this.tblSystemTimeAndSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblSystemTimeAndSettings.ColumnCount = 2;
            this.tblSystemTimeAndSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tblSystemTimeAndSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblSystemTimeAndSettings.Controls.Add(this.cmdSettings, 1, 0);
            this.tblSystemTimeAndSettings.Controls.Add(this.lblSystemTime, 0, 0);
            this.tblSystemTimeAndSettings.Controls.Add(this.lblSessionCountDown, 0, 1);
            this.tblSystemTimeAndSettings.Location = new System.Drawing.Point(3, 621);
            this.tblSystemTimeAndSettings.Name = "tblSystemTimeAndSettings";
            this.tblSystemTimeAndSettings.RowCount = 2;
            this.tblSystemTimeAndSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSystemTimeAndSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblSystemTimeAndSettings.Size = new System.Drawing.Size(377, 60);
            this.tblSystemTimeAndSettings.TabIndex = 8;
            // 
            // cmdSettings
            // 
            this.cmdSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSettings.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSettings.Location = new System.Drawing.Point(229, 3);
            this.cmdSettings.Name = "cmdSettings";
            this.tblSystemTimeAndSettings.SetRowSpan(this.cmdSettings, 2);
            this.cmdSettings.Size = new System.Drawing.Size(145, 54);
            this.cmdSettings.TabIndex = 8;
            this.cmdSettings.Text = "Settings";
            this.cmdSettings.UseVisualStyleBackColor = true;
            this.cmdSettings.Click += new System.EventHandler(this.cmdSettings_Click);
            // 
            // lblSystemTime
            // 
            this.lblSystemTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSystemTime.AutoSize = true;
            this.lblSystemTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSystemTime.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemTime.Location = new System.Drawing.Point(3, 0);
            this.lblSystemTime.Name = "lblSystemTime";
            this.lblSystemTime.Size = new System.Drawing.Size(220, 30);
            this.lblSystemTime.TabIndex = 2;
            this.lblSystemTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSessionCountDown
            // 
            this.lblSessionCountDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSessionCountDown.AutoSize = true;
            this.lblSessionCountDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSessionCountDown.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessionCountDown.Location = new System.Drawing.Point(3, 30);
            this.lblSessionCountDown.Name = "lblSessionCountDown";
            this.lblSessionCountDown.Size = new System.Drawing.Size(220, 30);
            this.lblSessionCountDown.TabIndex = 3;
            this.lblSessionCountDown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdRollCall
            // 
            this.cmdRollCall.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRollCall.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdRollCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRollCall.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRollCall.Location = new System.Drawing.Point(3, 334);
            this.cmdRollCall.Name = "cmdRollCall";
            this.cmdRollCall.Size = new System.Drawing.Size(377, 48);
            this.cmdRollCall.TabIndex = 10;
            this.cmdRollCall.Text = "Roll Call";
            this.cmdRollCall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRollCall.UseVisualStyleBackColor = true;
            // 
            // cmdTimerReminder
            // 
            this.cmdTimerReminder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTimerReminder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdTimerReminder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTimerReminder.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTimerReminder.Location = new System.Drawing.Point(3, 496);
            this.cmdTimerReminder.Name = "cmdTimerReminder";
            this.cmdTimerReminder.Size = new System.Drawing.Size(377, 48);
            this.cmdTimerReminder.TabIndex = 7;
            this.cmdTimerReminder.Text = "Timer and Reminder";
            this.cmdTimerReminder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdTimerReminder.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSave.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(3, 550);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(377, 48);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.Text = "Save Conference Events";
            this.cmdSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSave.UseVisualStyleBackColor = true;
            // 
            // timerSystemTime
            // 
            this.timerSystemTime.Enabled = true;
            this.timerSystemTime.Interval = 1000;
            this.timerSystemTime.Tick += new System.EventHandler(this.timerSystemTime_Tick);
            // 
            // timerSessionTime
            // 
            this.timerSessionTime.Interval = 60000;
            this.timerSessionTime.Tick += new System.EventHandler(this.timerSessionTime_Tick);
            // 
            // NewEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 45F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.tblAll);
            this.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "NewEvent";
            this.Size = new System.Drawing.Size(409, 690);
            this.tblAll.ResumeLayout(false);
            this.tblAll.PerformLayout();
            this.tblTimeControl.ResumeLayout(false);
            this.tblTime.ResumeLayout(false);
            this.tblTime.PerformLayout();
            this.tblButtons.ResumeLayout(false);
            this.tblSystemTimeAndSettings.ResumeLayout(false);
            this.tblSystemTimeAndSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblAll;
        private System.Windows.Forms.TableLayoutPanel tblTimeControl;
        private System.Windows.Forms.TableLayoutPanel tblButtons;
        private System.Windows.Forms.Button cmdExpire;
        private System.Windows.Forms.Button cmdPause;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Label lblBigTime;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdFile;
        private System.Windows.Forms.Button cmdSpeaker;
        private System.Windows.Forms.Button cmdMotion;
        private System.Windows.Forms.Label lblNewEvent;
        private System.Windows.Forms.Button cmdTimerReminder;
        private System.Windows.Forms.TableLayoutPanel tblSystemTimeAndSettings;
        private System.Windows.Forms.Label lblSystemTime;
        private System.Windows.Forms.Label lblSessionCountDown;
        private System.Windows.Forms.Button cmdSettings;
        private System.Windows.Forms.Label lblDash;
        private System.Windows.Forms.TableLayoutPanel tblTime;
        private System.Windows.Forms.Label lblSmallTime;
        private System.Windows.Forms.Button cmdRollCall;
        private System.Windows.Forms.Timer timerSystemTime;
        public System.Windows.Forms.Timer timerSessionTime;
    }
}

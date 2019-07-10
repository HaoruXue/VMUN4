namespace VMUN_4
{
    partial class Push
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
            this.tblAll = new System.Windows.Forms.TableLayoutPanel();
            this.lblEventName = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.tblAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblAll
            // 
            this.tblAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tblAll.ColumnCount = 1;
            this.tblAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblAll.Controls.Add(this.lblEventName, 0, 0);
            this.tblAll.Controls.Add(this.lblContent, 0, 1);
            this.tblAll.Location = new System.Drawing.Point(-1, 8);
            this.tblAll.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.tblAll.Name = "tblAll";
            this.tblAll.RowCount = 2;
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.39216F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.60784F));
            this.tblAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblAll.Size = new System.Drawing.Size(283, 255);
            this.tblAll.TabIndex = 0;
            this.tblAll.Paint += new System.Windows.Forms.PaintEventHandler(this.tblAll_Paint);
            this.tblAll.MouseEnter += new System.EventHandler(this.tblAll_MouseEnter);
            this.tblAll.MouseLeave += new System.EventHandler(this.tblAll_MouseLeave);
            // 
            // lblEventName
            // 
            this.lblEventName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEventName.AutoSize = true;
            this.lblEventName.BackColor = System.Drawing.Color.DimGray;
            this.lblEventName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventName.ForeColor = System.Drawing.Color.White;
            this.lblEventName.Location = new System.Drawing.Point(10, 0);
            this.lblEventName.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(263, 103);
            this.lblEventName.TabIndex = 10;
            this.lblEventName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEventName.Click += new System.EventHandler(this.lblEventName_Click);
            this.lblEventName.MouseEnter += new System.EventHandler(this.lblEventName_MouseEnter);
            // 
            // lblContent
            // 
            this.lblContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContent.AutoSize = true;
            this.lblContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblContent.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContent.ForeColor = System.Drawing.Color.White;
            this.lblContent.Location = new System.Drawing.Point(10, 103);
            this.lblContent.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(263, 152);
            this.lblContent.TabIndex = 9;
            this.lblContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblContent.Click += new System.EventHandler(this.lblContent_Click);
            // 
            // Push
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tblAll);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "Push";
            this.Size = new System.Drawing.Size(281, 271);
            this.Load += new System.EventHandler(this.Push_Load);
            this.Click += new System.EventHandler(this.Push_Click);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Push_MouseMove);
            this.tblAll.ResumeLayout(false);
            this.tblAll.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblAll;
        public System.Windows.Forms.Label lblEventName;
        public System.Windows.Forms.Label lblContent;
    }
}

namespace Server
{
    partial class F_Server
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
            this.gb_1 = new System.Windows.Forms.GroupBox();
            this.btn_download = new System.Windows.Forms.Button();
            this.txt_file = new System.Windows.Forms.TextBox();
            this.gb_2 = new System.Windows.Forms.GroupBox();
            this.btn_Srefresh = new System.Windows.Forms.Button();
            this.btn_Sinsert = new System.Windows.Forms.Button();
            this.lb_Sshow = new System.Windows.Forms.ListBox();
            this.gb_0 = new System.Windows.Forms.GroupBox();
            this.lbl_Server = new System.Windows.Forms.Label();
            this.btn_Server_Start = new System.Windows.Forms.Button();
            this.gb_3 = new System.Windows.Forms.GroupBox();
            this.btn_Crefresh = new System.Windows.Forms.Button();
            this.btn_Cinsert = new System.Windows.Forms.Button();
            this.lb_Cshow = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_pass = new System.Windows.Forms.GroupBox();
            this.lbl_warning = new System.Windows.Forms.Label();
            this.btn_pass = new System.Windows.Forms.Button();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.gb_1.SuspendLayout();
            this.gb_2.SuspendLayout();
            this.gb_0.SuspendLayout();
            this.gb_3.SuspendLayout();
            this.gb_pass.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_1
            // 
            this.gb_1.Controls.Add(this.btn_download);
            this.gb_1.Controls.Add(this.txt_file);
            this.gb_1.Location = new System.Drawing.Point(12, 207);
            this.gb_1.Name = "gb_1";
            this.gb_1.Size = new System.Drawing.Size(776, 100);
            this.gb_1.TabIndex = 6;
            this.gb_1.TabStop = false;
            this.gb_1.Text = "允许用户下载所选文件";
            // 
            // btn_download
            // 
            this.btn_download.Location = new System.Drawing.Point(348, 67);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(86, 27);
            this.btn_download.TabIndex = 6;
            this.btn_download.Text = "下载";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // txt_file
            // 
            this.txt_file.Location = new System.Drawing.Point(6, 37);
            this.txt_file.Name = "txt_file";
            this.txt_file.Size = new System.Drawing.Size(764, 25);
            this.txt_file.TabIndex = 5;
            // 
            // gb_2
            // 
            this.gb_2.Controls.Add(this.btn_Srefresh);
            this.gb_2.Controls.Add(this.btn_Sinsert);
            this.gb_2.Controls.Add(this.lb_Sshow);
            this.gb_2.Location = new System.Drawing.Point(12, 313);
            this.gb_2.Name = "gb_2";
            this.gb_2.Size = new System.Drawing.Size(776, 320);
            this.gb_2.TabIndex = 7;
            this.gb_2.TabStop = false;
            this.gb_2.Text = "服务器文件目录";
            // 
            // btn_Srefresh
            // 
            this.btn_Srefresh.Location = new System.Drawing.Point(573, 39);
            this.btn_Srefresh.Name = "btn_Srefresh";
            this.btn_Srefresh.Size = new System.Drawing.Size(86, 27);
            this.btn_Srefresh.TabIndex = 8;
            this.btn_Srefresh.Text = "刷新";
            this.btn_Srefresh.UseVisualStyleBackColor = true;
            this.btn_Srefresh.Click += new System.EventHandler(this.btn_Srefresh_Click);
            // 
            // btn_Sinsert
            // 
            this.btn_Sinsert.Location = new System.Drawing.Point(76, 34);
            this.btn_Sinsert.Name = "btn_Sinsert";
            this.btn_Sinsert.Size = new System.Drawing.Size(86, 27);
            this.btn_Sinsert.TabIndex = 7;
            this.btn_Sinsert.Text = "添加文件";
            this.btn_Sinsert.UseVisualStyleBackColor = true;
            this.btn_Sinsert.Click += new System.EventHandler(this.btn_Sinsert_Click);
            // 
            // lb_Sshow
            // 
            this.lb_Sshow.FormattingEnabled = true;
            this.lb_Sshow.ItemHeight = 15;
            this.lb_Sshow.Location = new System.Drawing.Point(6, 72);
            this.lb_Sshow.Name = "lb_Sshow";
            this.lb_Sshow.Size = new System.Drawing.Size(764, 229);
            this.lb_Sshow.TabIndex = 6;
            this.lb_Sshow.SelectedIndexChanged += new System.EventHandler(this.lb_Sshow_SelectedIndexChanged);
            // 
            // gb_0
            // 
            this.gb_0.Controls.Add(this.lbl_Server);
            this.gb_0.Controls.Add(this.btn_Server_Start);
            this.gb_0.Location = new System.Drawing.Point(16, 111);
            this.gb_0.Name = "gb_0";
            this.gb_0.Size = new System.Drawing.Size(772, 90);
            this.gb_0.TabIndex = 9;
            this.gb_0.TabStop = false;
            this.gb_0.Text = "开启服务器";
            // 
            // lbl_Server
            // 
            this.lbl_Server.AutoSize = true;
            this.lbl_Server.Location = new System.Drawing.Point(239, 42);
            this.lbl_Server.Name = "lbl_Server";
            this.lbl_Server.Size = new System.Drawing.Size(127, 15);
            this.lbl_Server.TabIndex = 1;
            this.lbl_Server.Text = "当前状态：未开启";
            // 
            // btn_Server_Start
            // 
            this.btn_Server_Start.Location = new System.Drawing.Point(384, 36);
            this.btn_Server_Start.Name = "btn_Server_Start";
            this.btn_Server_Start.Size = new System.Drawing.Size(86, 27);
            this.btn_Server_Start.TabIndex = 0;
            this.btn_Server_Start.Text = "启动服务器";
            this.btn_Server_Start.UseVisualStyleBackColor = true;
            this.btn_Server_Start.Click += new System.EventHandler(this.btn_Server_Start_Click);
            // 
            // gb_3
            // 
            this.gb_3.Controls.Add(this.btn_Crefresh);
            this.gb_3.Controls.Add(this.btn_Cinsert);
            this.gb_3.Controls.Add(this.lb_Cshow);
            this.gb_3.Location = new System.Drawing.Point(803, 111);
            this.gb_3.Name = "gb_3";
            this.gb_3.Size = new System.Drawing.Size(776, 522);
            this.gb_3.TabIndex = 10;
            this.gb_3.TabStop = false;
            this.gb_3.Text = "客户服务目录";
            // 
            // btn_Crefresh
            // 
            this.btn_Crefresh.Location = new System.Drawing.Point(587, 39);
            this.btn_Crefresh.Name = "btn_Crefresh";
            this.btn_Crefresh.Size = new System.Drawing.Size(86, 27);
            this.btn_Crefresh.TabIndex = 8;
            this.btn_Crefresh.Text = "刷新";
            this.btn_Crefresh.UseVisualStyleBackColor = true;
            this.btn_Crefresh.Click += new System.EventHandler(this.btn_Crefresh_Click);
            // 
            // btn_Cinsert
            // 
            this.btn_Cinsert.Location = new System.Drawing.Point(76, 34);
            this.btn_Cinsert.Name = "btn_Cinsert";
            this.btn_Cinsert.Size = new System.Drawing.Size(86, 27);
            this.btn_Cinsert.TabIndex = 7;
            this.btn_Cinsert.Text = "添加文件";
            this.btn_Cinsert.UseVisualStyleBackColor = true;
            this.btn_Cinsert.Click += new System.EventHandler(this.btn_Cinsert_Click);
            // 
            // lb_Cshow
            // 
            this.lb_Cshow.FormattingEnabled = true;
            this.lb_Cshow.ItemHeight = 15;
            this.lb_Cshow.Location = new System.Drawing.Point(6, 72);
            this.lb_Cshow.Name = "lb_Cshow";
            this.lb_Cshow.Size = new System.Drawing.Size(764, 439);
            this.lb_Cshow.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(910, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(592, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "客户服务目录仅供客户下载，请前往客户端下载，服务端可以添加新的文件供客户端下载";
            // 
            // gb_pass
            // 
            this.gb_pass.Controls.Add(this.lbl_warning);
            this.gb_pass.Controls.Add(this.btn_pass);
            this.gb_pass.Controls.Add(this.txt_pass);
            this.gb_pass.Location = new System.Drawing.Point(16, 13);
            this.gb_pass.Name = "gb_pass";
            this.gb_pass.Size = new System.Drawing.Size(766, 82);
            this.gb_pass.TabIndex = 12;
            this.gb_pass.TabStop = false;
            this.gb_pass.Text = "退出验证";
            // 
            // lbl_warning
            // 
            this.lbl_warning.AutoSize = true;
            this.lbl_warning.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_warning.ForeColor = System.Drawing.Color.Crimson;
            this.lbl_warning.Location = new System.Drawing.Point(224, 54);
            this.lbl_warning.Name = "lbl_warning";
            this.lbl_warning.Size = new System.Drawing.Size(0, 15);
            this.lbl_warning.TabIndex = 16;
            // 
            // btn_pass
            // 
            this.btn_pass.Location = new System.Drawing.Point(447, 24);
            this.btn_pass.Name = "btn_pass";
            this.btn_pass.Size = new System.Drawing.Size(86, 27);
            this.btn_pass.TabIndex = 15;
            this.btn_pass.Text = "确认";
            this.btn_pass.UseVisualStyleBackColor = true;
            this.btn_pass.Click += new System.EventHandler(this.btn_pass_Click);
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(227, 24);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(191, 25);
            this.txt_pass.TabIndex = 14;
            // 
            // F_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1591, 642);
            this.Controls.Add(this.gb_pass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gb_3);
            this.Controls.Add(this.gb_0);
            this.Controls.Add(this.gb_2);
            this.Controls.Add(this.gb_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "F_Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F_Server_FormClosing);
            this.Load += new System.EventHandler(this.F_Server_Load);
            this.gb_1.ResumeLayout(false);
            this.gb_1.PerformLayout();
            this.gb_2.ResumeLayout(false);
            this.gb_0.ResumeLayout(false);
            this.gb_0.PerformLayout();
            this.gb_3.ResumeLayout(false);
            this.gb_pass.ResumeLayout(false);
            this.gb_pass.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gb_1;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.TextBox txt_file;
        private System.Windows.Forms.GroupBox gb_2;
        private System.Windows.Forms.Button btn_Srefresh;
        private System.Windows.Forms.Button btn_Sinsert;
        private System.Windows.Forms.ListBox lb_Sshow;
        private System.Windows.Forms.GroupBox gb_0;
        private System.Windows.Forms.Button btn_Server_Start;
        private System.Windows.Forms.Label lbl_Server;
        private System.Windows.Forms.GroupBox gb_3;
        private System.Windows.Forms.Button btn_Crefresh;
        private System.Windows.Forms.Button btn_Cinsert;
        private System.Windows.Forms.ListBox lb_Cshow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_pass;
        private System.Windows.Forms.Button btn_pass;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.Label lbl_warning;
    }
}


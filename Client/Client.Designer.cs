namespace Client
{
    partial class F_Client
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
            this.lbl_connect = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gb_list = new System.Windows.Forms.GroupBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.lb_file = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_download = new System.Windows.Forms.Button();
            this.txt_download = new System.Windows.Forms.TextBox();
            this.gb_pic = new System.Windows.Forms.GroupBox();
            this.pic_show = new System.Windows.Forms.PictureBox();
            this.gb_cache = new System.Windows.Forms.GroupBox();
            this.gb_data = new System.Windows.Forms.GroupBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.lb_data = new System.Windows.Forms.ListBox();
            this.gb_daily = new System.Windows.Forms.GroupBox();
            this.lb_cache = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.gb_list.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gb_pic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_show)).BeginInit();
            this.gb_cache.SuspendLayout();
            this.gb_data.SuspendLayout();
            this.gb_daily.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_connect
            // 
            this.lbl_connect.AutoSize = true;
            this.lbl_connect.Location = new System.Drawing.Point(63, 44);
            this.lbl_connect.Name = "lbl_connect";
            this.lbl_connect.Size = new System.Drawing.Size(52, 15);
            this.lbl_connect.TabIndex = 0;
            this.lbl_connect.Text = "未连接";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_connect);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接状态";
            // 
            // gb_list
            // 
            this.gb_list.Controls.Add(this.btn_refresh);
            this.gb_list.Controls.Add(this.lb_file);
            this.gb_list.Location = new System.Drawing.Point(12, 118);
            this.gb_list.Name = "gb_list";
            this.gb_list.Size = new System.Drawing.Size(868, 320);
            this.gb_list.TabIndex = 2;
            this.gb_list.TabStop = false;
            this.gb_list.Text = "文件列表";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(6, 45);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(850, 42);
            this.btn_refresh.TabIndex = 4;
            this.btn_refresh.Text = "刷新";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // lb_file
            // 
            this.lb_file.FormattingEnabled = true;
            this.lb_file.ItemHeight = 15;
            this.lb_file.Location = new System.Drawing.Point(6, 93);
            this.lb_file.Name = "lb_file";
            this.lb_file.Size = new System.Drawing.Size(850, 214);
            this.lb_file.TabIndex = 3;
            this.lb_file.SelectedIndexChanged += new System.EventHandler(this.lb_file_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_download);
            this.groupBox2.Controls.Add(this.txt_download);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(998, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择文件下载";
            // 
            // btn_download
            // 
            this.btn_download.Location = new System.Drawing.Point(892, 32);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(75, 39);
            this.btn_download.TabIndex = 1;
            this.btn_download.Text = "下载";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // txt_download
            // 
            this.txt_download.Location = new System.Drawing.Point(6, 38);
            this.txt_download.Name = "txt_download";
            this.txt_download.Size = new System.Drawing.Size(880, 25);
            this.txt_download.TabIndex = 0;
            // 
            // gb_pic
            // 
            this.gb_pic.Controls.Add(this.pic_show);
            this.gb_pic.Location = new System.Drawing.Point(886, 118);
            this.gb_pic.Name = "gb_pic";
            this.gb_pic.Size = new System.Drawing.Size(330, 320);
            this.gb_pic.TabIndex = 4;
            this.gb_pic.TabStop = false;
            this.gb_pic.Text = "图片预览";
            // 
            // pic_show
            // 
            this.pic_show.BackColor = System.Drawing.Color.GhostWhite;
            this.pic_show.Location = new System.Drawing.Point(6, 24);
            this.pic_show.Name = "pic_show";
            this.pic_show.Size = new System.Drawing.Size(316, 282);
            this.pic_show.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_show.TabIndex = 0;
            this.pic_show.TabStop = false;
            // 
            // gb_cache
            // 
            this.gb_cache.Controls.Add(this.gb_data);
            this.gb_cache.Controls.Add(this.gb_daily);
            this.gb_cache.Location = new System.Drawing.Point(13, 445);
            this.gb_cache.Name = "gb_cache";
            this.gb_cache.Size = new System.Drawing.Size(1203, 349);
            this.gb_cache.TabIndex = 5;
            this.gb_cache.TabStop = false;
            this.gb_cache.Text = "缓存管理";
            // 
            // gb_data
            // 
            this.gb_data.Controls.Add(this.btn_clear);
            this.gb_data.Controls.Add(this.lb_data);
            this.gb_data.Location = new System.Drawing.Point(812, 24);
            this.gb_data.Name = "gb_data";
            this.gb_data.Size = new System.Drawing.Size(384, 318);
            this.gb_data.TabIndex = 4;
            this.gb_data.TabStop = false;
            this.gb_data.Text = "缓存数据";
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(6, 29);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(372, 38);
            this.btn_clear.TabIndex = 4;
            this.btn_clear.Text = "仅清除缓存数据";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // lb_data
            // 
            this.lb_data.FormattingEnabled = true;
            this.lb_data.ItemHeight = 15;
            this.lb_data.Location = new System.Drawing.Point(6, 73);
            this.lb_data.Name = "lb_data";
            this.lb_data.Size = new System.Drawing.Size(372, 229);
            this.lb_data.TabIndex = 3;
            // 
            // gb_daily
            // 
            this.gb_daily.Controls.Add(this.lb_cache);
            this.gb_daily.Location = new System.Drawing.Point(7, 24);
            this.gb_daily.Name = "gb_daily";
            this.gb_daily.Size = new System.Drawing.Size(799, 318);
            this.gb_daily.TabIndex = 3;
            this.gb_daily.TabStop = false;
            this.gb_daily.Text = "缓存日志";
            // 
            // lb_cache
            // 
            this.lb_cache.FormattingEnabled = true;
            this.lb_cache.ItemHeight = 15;
            this.lb_cache.Location = new System.Drawing.Point(6, 28);
            this.lb_cache.Name = "lb_cache";
            this.lb_cache.Size = new System.Drawing.Size(787, 274);
            this.lb_cache.TabIndex = 1;
            // 
            // F_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 799);
            this.Controls.Add(this.gb_cache);
            this.Controls.Add(this.gb_pic);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_list);
            this.Controls.Add(this.groupBox1);
            this.Name = "F_Client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.F_Client_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_list.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gb_pic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_show)).EndInit();
            this.gb_cache.ResumeLayout(false);
            this.gb_data.ResumeLayout(false);
            this.gb_daily.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_connect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gb_list;
        private System.Windows.Forms.ListBox lb_file;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_download;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.GroupBox gb_pic;
        private System.Windows.Forms.PictureBox pic_show;
        private System.Windows.Forms.GroupBox gb_cache;
        private System.Windows.Forms.GroupBox gb_daily;
        private System.Windows.Forms.ListBox lb_cache;
        private System.Windows.Forms.GroupBox gb_data;
        private System.Windows.Forms.ListBox lb_data;
        private System.Windows.Forms.Button btn_clear;
    }
}


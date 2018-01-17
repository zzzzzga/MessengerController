namespace ManagenrController
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            // this.columnUsb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSocket = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label_1 = new System.Windows.Forms.Label();
            this.maxFriendsNum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.minFriendsNum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SendNumTbx = new System.Windows.Forms.TextBox();
            this.SelectImgBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clearTxtBtn = new System.Windows.Forms.Button();
            this.SendTxtBtn = new System.Windows.Forms.Button();
            this.SendTxtTbx = new System.Windows.Forms.TextBox();
            this.SendImgBtn = new System.Windows.Forms.Button();
            this.ClearImgBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.installApkBtn = new System.Windows.Forms.Button();
            this.openApkBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNum,
            this.columnSN,
            //this.columnUsb,
            this.columnSocket});
            this.listView1.Location = new System.Drawing.Point(2, 1);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(322, 641);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnNum
            // 
            this.columnNum.Text = "序号";
            this.columnNum.Width = 40;
            // 
            // columnSN
            // 
            this.columnSN.Text = "设备号";
            this.columnSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnSN.Width = 80;
            // 
            // columnUsb
            // 
            //this.columnUsb.Text = "USB连接";
            //this.columnUsb.Width = 80;
            // 
            // columnSocket
            // 
            this.columnSocket.Text = "Socket连接";
            this.columnSocket.Width = 80;
            // 
            // label_1
            // 
            this.label_1.AutoSize = true;
            this.label_1.Location = new System.Drawing.Point(341, 13);
            this.label_1.Name = "label_1";
            this.label_1.Size = new System.Drawing.Size(113, 12);
            this.label_1.TabIndex = 1;
            this.label_1.Text = "拥有最多的好友数：";
            this.label_1.Visible = false;
            // 
            // maxFriendsNum
            // 
            this.maxFriendsNum.AutoSize = true;
            this.maxFriendsNum.Location = new System.Drawing.Point(461, 13);
            this.maxFriendsNum.Name = "maxFriendsNum";
            this.maxFriendsNum.Size = new System.Drawing.Size(11, 12);
            this.maxFriendsNum.TabIndex = 2;
            this.maxFriendsNum.Text = "0";
            this.maxFriendsNum.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(341, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "拥有最少的好友数：";
            this.label1.Visible = false;
            // 
            // minFriendsNum
            // 
            this.minFriendsNum.AutoSize = true;
            this.minFriendsNum.Location = new System.Drawing.Point(461, 36);
            this.minFriendsNum.Name = "minFriendsNum";
            this.minFriendsNum.Size = new System.Drawing.Size(11, 12);
            this.minFriendsNum.TabIndex = 4;
            this.minFriendsNum.Text = "0";
            this.minFriendsNum.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "每台设备发送的数量：";
            // 
            // SendNumTbx
            // 
            this.SendNumTbx.Location = new System.Drawing.Point(466, 55);
            this.SendNumTbx.Name = "SendNumTbx";
            this.SendNumTbx.Size = new System.Drawing.Size(95, 21);
            this.SendNumTbx.TabIndex = 6;
            // 
            // SelectImgBtn
            // 
            this.SelectImgBtn.Location = new System.Drawing.Point(342, 92);
            this.SelectImgBtn.Name = "SelectImgBtn";
            this.SelectImgBtn.Size = new System.Drawing.Size(113, 28);
            this.SelectImgBtn.TabIndex = 7;
            this.SelectImgBtn.Text = "选择图片";
            this.SelectImgBtn.UseVisualStyleBackColor = true;
            this.SelectImgBtn.Click += new System.EventHandler(this.SelectImgBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox9);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox8);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(343, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 420);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::ManagenrController.Properties.Resources._3;
            this.pictureBox9.Location = new System.Drawing.Point(391, 291);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(184, 126);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 0;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::ManagenrController.Properties.Resources._3;
            this.pictureBox6.Location = new System.Drawing.Point(391, 147);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(184, 126);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 0;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ManagenrController.Properties.Resources._3;
            this.pictureBox3.Location = new System.Drawing.Point(391, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(184, 126);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::ManagenrController.Properties.Resources._3;
            this.pictureBox8.Location = new System.Drawing.Point(197, 291);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(184, 126);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 0;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::ManagenrController.Properties.Resources._3;
            this.pictureBox5.Location = new System.Drawing.Point(197, 147);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(184, 126);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ManagenrController.Properties.Resources._3;
            this.pictureBox2.Location = new System.Drawing.Point(197, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(184, 126);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::ManagenrController.Properties.Resources._3;
            this.pictureBox7.Location = new System.Drawing.Point(3, 291);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(184, 126);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 0;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::ManagenrController.Properties.Resources._3;
            this.pictureBox4.Location = new System.Drawing.Point(3, 147);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(184, 126);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ManagenrController.Properties.Resources._3;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 126);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clearTxtBtn);
            this.groupBox1.Controls.Add(this.SendTxtBtn);
            this.groupBox1.Controls.Add(this.SendTxtTbx);
            this.groupBox1.Location = new System.Drawing.Point(342, 566);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 120);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发送文本";
            // 
            // clearTxtBtn
            // 
            this.clearTxtBtn.Location = new System.Drawing.Point(466, 74);
            this.clearTxtBtn.Name = "clearTxtBtn";
            this.clearTxtBtn.Size = new System.Drawing.Size(90, 31);
            this.clearTxtBtn.TabIndex = 2;
            this.clearTxtBtn.Text = "清空文本";
            this.clearTxtBtn.UseVisualStyleBackColor = true;
            this.clearTxtBtn.Click += new System.EventHandler(this.clearTxtBtn_Click);
            // 
            // SendTxtBtn
            // 
            this.SendTxtBtn.Location = new System.Drawing.Point(466, 20);
            this.SendTxtBtn.Name = "SendTxtBtn";
            this.SendTxtBtn.Size = new System.Drawing.Size(90, 31);
            this.SendTxtBtn.TabIndex = 1;
            this.SendTxtBtn.Text = "发送文本";
            this.SendTxtBtn.UseVisualStyleBackColor = true;
            this.SendTxtBtn.Click += new System.EventHandler(this.SendTxtBtn_Click);
            // 
            // SendTxtTbx
            // 
            this.SendTxtTbx.Location = new System.Drawing.Point(7, 18);
            this.SendTxtTbx.Multiline = true;
            this.SendTxtTbx.Name = "SendTxtTbx";
            this.SendTxtTbx.Size = new System.Drawing.Size(441, 96);
            this.SendTxtTbx.TabIndex = 0;
            // 
            // SendImgBtn
            // 
            this.SendImgBtn.Location = new System.Drawing.Point(476, 92);
            this.SendImgBtn.Name = "SendImgBtn";
            this.SendImgBtn.Size = new System.Drawing.Size(90, 28);
            this.SendImgBtn.TabIndex = 1;
            this.SendImgBtn.Text = "发送图片";
            this.SendImgBtn.UseVisualStyleBackColor = true;
            this.SendImgBtn.Click += new System.EventHandler(this.SendImgBtn_Click);
            // 
            // ClearImgBtn
            // 
            this.ClearImgBtn.Location = new System.Drawing.Point(587, 92);
            this.ClearImgBtn.Name = "ClearImgBtn";
            this.ClearImgBtn.Size = new System.Drawing.Size(90, 28);
            this.ClearImgBtn.TabIndex = 1;
            this.ClearImgBtn.Text = "清空图片";
            this.ClearImgBtn.UseVisualStyleBackColor = true;
            this.ClearImgBtn.Click += new System.EventHandler(this.ClearImgBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.pictureBox10);
            this.groupBox2.Location = new System.Drawing.Point(683, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 108);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "版权信息：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "版权所有  CopyRight 2008-2018";
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::ManagenrController.Properties.Resources._4;
            this.pictureBox10.Location = new System.Drawing.Point(6, 20);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(223, 56);
            this.pictureBox10.TabIndex = 0;
            this.pictureBox10.TabStop = false;
            // 
            // installApkBtn
            // 
            this.installApkBtn.Location = new System.Drawing.Point(4, 654);
            this.installApkBtn.Name = "installApkBtn";
            this.installApkBtn.Size = new System.Drawing.Size(127, 38);
            this.installApkBtn.TabIndex = 11;
            this.installApkBtn.Text = "一键安装app";
            this.installApkBtn.UseVisualStyleBackColor = true;
            this.installApkBtn.Click += new System.EventHandler(this.installApkBtn_Click);
            // 
            // openApkBtn
            // 
            this.openApkBtn.Location = new System.Drawing.Point(138, 654);
            this.openApkBtn.Name = "openApkBtn";
            this.openApkBtn.Size = new System.Drawing.Size(127, 38);
            this.openApkBtn.TabIndex = 11;
            this.openApkBtn.Text = "一键打开app";
            this.openApkBtn.UseVisualStyleBackColor = true;
            this.openApkBtn.Click += new System.EventHandler(this.openApkBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "png,.jpg,.gif,.bmp";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "选择图片";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem1.Text = "选择图片";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem2.Text = "删除图片";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 700);
            this.Controls.Add(this.openApkBtn);
            this.Controls.Add(this.installApkBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ClearImgBtn);
            this.Controls.Add(this.SendImgBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SelectImgBtn);
            this.Controls.Add(this.SendNumTbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.minFriendsNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maxFriendsNum);
            this.Controls.Add(this.label_1);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "控制器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnNum;
        private System.Windows.Forms.ColumnHeader columnSN;
        private System.Windows.Forms.Label label_1;
        private System.Windows.Forms.Label maxFriendsNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label minFriendsNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SendNumTbx;
        private System.Windows.Forms.Button SelectImgBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button clearTxtBtn;
        private System.Windows.Forms.Button SendTxtBtn;
        private System.Windows.Forms.TextBox SendTxtTbx;
        private System.Windows.Forms.Button SendImgBtn;
        private System.Windows.Forms.Button ClearImgBtn;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox10;
        //private System.Windows.Forms.ColumnHeader columnUsb;
        private System.Windows.Forms.ColumnHeader columnSocket;
        //private System.Windows.Forms.ColumnHeader columnState;
        private System.Windows.Forms.Button installApkBtn;
        private System.Windows.Forms.Button openApkBtn;
        //private System.Windows.Forms.ColumnHeader columnHeader1;
        //private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}


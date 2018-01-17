using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagenrController
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            PictureBoxList = new List<PictureBox>();
            InitializeComponent();
            PictureBoxList.Add(this.pictureBox1);
            PictureBoxList.Add(this.pictureBox2);
            PictureBoxList.Add(this.pictureBox3);
            PictureBoxList.Add(this.pictureBox4);
            PictureBoxList.Add(this.pictureBox5);
            PictureBoxList.Add(this.pictureBox6);
            PictureBoxList.Add(this.pictureBox7);
            PictureBoxList.Add(this.pictureBox8);
            PictureBoxList.Add(this.pictureBox9);
        }

        private List<PictureBox> PictureBoxList;

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            // 设置图片选择框
            this.openFileDialog1.Filter = "Image文件(*.png;*.jpg;*.gif;*.bmp)|*.png;*.jpg;*.gif;*.bmp";
            this.openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            this.installApkBtn.Visible = false;
            this.openApkBtn.Visible = false;
        }
        /// <summary>
        /// 刷新列表
        /// </summary>
        /// <param name="phone"></param>
        public void RefreshListView(Phone phone)
        {
            var enumerator = this.listView1.Items.GetEnumerator();
            while(enumerator.MoveNext())
            {
                var it = enumerator.Current as ListViewItem;
                if (it.Tag.ToString() == phone.SerialNumber)
                {
                    this.listView1.Items[it.Index].SubItems[2].Text = phone.IsUsbConnect ? "已连接" : "未连接";
                    this.listView1.Items[it.Index].SubItems[3].Text = phone.IsSocketConnect ? "已连接" : "未连接";
                    //this.listView1.Items[it.Index].SubItems[4].Text = phone.MobileState.ToString();
                    //this.listView1.Items[it.Index].SubItems[5].Text = phone.FriendsNum.ToString();
                    //this.listView1.Items[it.Index].SubItems[6].Text = phone.ExecuteState.ToString();
                    return;
                }
            }
            string[] strs = new string[4];
            strs[0] = phone.Id;
            strs[1] = phone.SerialNumber;
            strs[2] = phone.IsUsbConnect ? "已连接" : "未连接";
            strs[3] = phone.IsSocketConnect ? "已连接" : "未连接";
            //strs[4] = phone.MobileState.ToString();
            //strs[5] = phone.FriendsNum.ToString();
            //strs[6] = phone.ExecuteState.ToString();
            ListViewItem item = new ListViewItem(strs);
            item.Tag = phone.SerialNumber;
            this.listView1.Items.Add(item);
        }
        /// <summary>
        /// 刷新列表
        /// </summary>
        /// <param name="phone"></param>
        public void RefreshListView()
        {
            foreach (var phone in Global.PhoneList)
            {
                this.RefreshListView(phone);
            }
        }

        public void RefreshFriendNum ()
        {
            int max = 0, min = int.MaxValue;
            foreach (var phone in Global.IsSocketConnectPhoneList)
            {
                max = Math.Max(phone.FriendsNum, max);
                min = Math.Min(phone.FriendsNum, min);
            }
            this.maxFriendsNum.Text = max.ToString() ;
            this.minFriendsNum.Text = min.ToString();

            this.SendNumTbx.Text = min.ToString();
        }

        private void openApkBtn_Click(object sender, EventArgs e)
        {
            if (Global.IsUsbConnectPhoneList.Count <= 0)
            {
                return;
            }
            this.openApkBtn.Enabled = false;
            var t = new Thread(() => {
                foreach (var phone in Global.IsUsbConnectPhoneList)
                {
                    AdbHelper.OpenApk(phone, Global.StartActivity);
                }
                this.openApkBtn.Invoke(new Action(() => { this.openApkBtn.Enabled = true; }));
            });
            t.IsBackground = true;
            t.Start();
            RefreshListView();
        }

        private void installApkBtn_Click(object sender, EventArgs e)
        {
            if (Global.IsUsbConnectPhoneList.Count <= 0)
            {
                return;
            }
            this.installApkBtn.Enabled = false;
            var t = new Thread(() =>
            {
                ConcurrentStack<IAsyncResult> stack = new ConcurrentStack<IAsyncResult>();
                Semaphore semaphore  = new Semaphore(0, 1);
                foreach (var phone in Global.IsUsbConnectPhoneList)
                {
                    stack.Push(new Action(() =>
                    {
                        AdbHelper.InstallApk(phone, Global.AppPath);
                    }).BeginInvoke((obj) =>
                    {
                        this.Invoke(new Action(RefreshListView));
                        IAsyncResult result = null;
                        stack.TryPop(out result);
                        if (stack.Count == 0)
                        {
                            semaphore.Release();
                        }
                    }, null));
                }
                semaphore.WaitOne();
                this.installApkBtn.Invoke(new Action(() => { this.installApkBtn.Enabled = true; }));
            });
            t.IsBackground = true;
            t.Start();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var item in Global.PhoneList)
            {
                AdbHelper.RemoveAllReverse(item);
            }
            AdbHelper.KillServer();
            System.Windows.Forms.Application.Exit();
        }

        private void clearTxtBtn_Click(object sender, EventArgs e)
        {
            this.SendTxtTbx.Text = "";
        }

        private void ClearImgBtn_Click(object sender, EventArgs e)
        {
            foreach (var item in PictureBoxList)
            {
                item.Image = global::ManagenrController.Properties.Resources._3;
                item.ImageLocation = "";
            }
        }

        private void SendImgBtn_Click(object sender, EventArgs e)
        {
            List<string> images = new List<string>();
            foreach (var item in PictureBoxList)
            {
                if (!string.IsNullOrEmpty(item.ImageLocation))
                {
                    images.Add(item.ImageLocation);
                }
            }
            if (!CheckNum())
            {
                return;
            }
            if (images.Count > 0)
            {
                if (Global.IsSocketConnectPhoneList.Count > 0)
                {
                    string num = this.SendNumTbx.Text.Trim();
                    // 发送消息
                    ((Action)(delegate ()
                    {
                        // 发送图片
                        string imgArr = "";
                        for (int i = 0; i < images.Count; i++)
                        {
                            imgArr += "\"" + Convert.ToBase64String(File.ReadAllBytes(images[i])) + "\",";
                        }
                        string msg = "{{\"type\":102,\"data\":[{0}],\"num\":{1}}}";
                        var body = MessageProcessor.ToBytesFromMessageString(string.Format(msg, imgArr, num));
                        foreach (var item in Global.IsSocketConnectPhoneList)
                        {
                            Global.SendMsgQueue.Enqueue(new Message(body, item.SerialNumber));
                        }
                    })).BeginInvoke(null, null);
                    MessageBox.Show("消息开始发送...", "信息");
                }
                else
                {
                    MessageBox.Show(this, "没有socket连接的手机，请打开app", "信息");
                    return;
                }
                
            }
            else
            {
                MessageBox.Show("请先选择图片", "信息");
                return;
            }
        }

        private void SelectImgBtn_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.FileOk += OpenFileDialog1_FileOk;
            this.openFileDialog1.ShowDialog();
            this.openFileDialog1.FileOk -= OpenFileDialog1_FileOk;
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string[] files = this.openFileDialog1.FileNames;
            int min = Math.Min(files.Length, PictureBoxList.Count);
            for (int i = 0; i < min; i++)
            {
                PictureBoxList[i].ImageLocation = files[i];
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (string.IsNullOrWhiteSpace((sender as PictureBox).ImageLocation))
                {
                    this.contextMenuStrip1.Items[1].Enabled = false;
                }
                else
                {
                    this.contextMenuStrip1.Items[1].Enabled = true;
                }
                this.contextMenuStrip1.Show(sender as Control, new Point(e.X, e.Y));
            }
            else if (e.Button == MouseButtons.Left)
            {
                this.openFileDialog1.Multiselect = false;
                var ret = this.openFileDialog1.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    (sender as PictureBox).ImageLocation = this.openFileDialog1.FileName;
                }
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var cms = sender as ContextMenuStrip;
            var pb = cms.SourceControl;
            cms.Visible = false;
            if (cms.Items[0] == e.ClickedItem) // 修改图片
            {
                this.openFileDialog1.Multiselect = false;
                var ret = this.openFileDialog1.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    (pb as PictureBox).ImageLocation = this.openFileDialog1.FileName;
                }
            }
            else if (cms.Items[1] == e.ClickedItem)
            {
                (pb as PictureBox).Image = global::ManagenrController.Properties.Resources._3;
                (pb as PictureBox).ImageLocation = "";
            }
        }

        private bool CheckNum()
        {
            string num = this.SendNumTbx.Text.Trim();
            if (string.IsNullOrWhiteSpace(num))
            {
                Logger.Warn("每台设备发送的数量不能为空！");
                MessageBox.Show("每台设备发送的数量不能为空！", "信息");
                return false;
            }
            int a = 0;
            if (!int.TryParse(num, out a))
            {
                Logger.Warn("每台设备发送的数量必须是正整数！");
                MessageBox.Show("每台设备发送的数量必须是正整数！", "信息");
                return false;
            }
            if (a <= 0)
            {
                Logger.Warn("每台设备发送的数量必须是正整数！");
                MessageBox.Show("每台设备发送的数量必须是正整数！", "信息");
                return false;
            }
            return true;
        }

        private void SendTxtBtn_Click(object sender, EventArgs e)
        {
            string txt = this.SendTxtTbx.Text.Trim();
            string num = this.SendNumTbx.Text.Trim();
            if (string.IsNullOrWhiteSpace(txt))
            {
                Logger.Warn("发送文本内容不能为空！");
                MessageBox.Show("发送文本内容不能为空！", "信息");
                return;
            }
            if (!CheckNum())
            {
                return;
            }
            if (Global.IsSocketConnectPhoneList.Count > 0)
            {
                string msg = "{{\"type\":101,\"data\":\"{0}\",\"num\":{1}}}";
                var body = MessageProcessor.ToBytesFromMessageString(string.Format(msg, txt, num));
                ((Action)(delegate ()
                {
                    foreach (var item in Global.IsSocketConnectPhoneList)
                    {
                        Global.SendMsgQueue.Enqueue(new Message(body, item.SerialNumber));
                    }
                })).BeginInvoke(null, null);
                MessageBox.Show(this, "消息开始发送...", "信息");
            }
            else
            {
                MessageBox.Show(this, "没有socket连接的手机，请打开app", "信息");
            }
        }
    }
}

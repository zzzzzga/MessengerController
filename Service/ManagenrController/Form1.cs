using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
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

        private void Test()
        {
            //var t = new Thread(() =>
            //{
            //    List<Socket> list = new List<Socket>();
            //    int i = 0;
            //    while(i<30)
            //    {
            //        i++;
            //        // to do 监听手机连接
            //        //string id = Guid.NewGuid().ToString();
            //        //string serialNumber = Guid.NewGuid().ToString();
            //        //Global.PhoneDic.TryAdd(serialNumber, new Phone() { Id = id, SerialNumber = serialNumber });
            //        //Thread.Sleep(1000);
            //        //this.Invoke(new Action(RefreshListView));
            //        Socket client = new Socket(SocketType.Stream, ProtocolType.Tcp);
            //        client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 14808));
            //        string sn = i.ToString();
            //        string msg = "{\"type\":1,\"SN\":\""+ sn + "\",\"result\":100}";

            //        Global.AddPhoneDic(sn, new Phone() { Id = Guid.NewGuid().ToString(), SerialNumber = sn });
            //        int len = Encoding.UTF8.GetByteCount(msg);
            //        byte[] buf = new byte[4];
            //        buf[0] = (byte)(len & 0xff);
            //        buf[1] = (byte)(len >> 8);
            //        buf[2] = (byte)(len >> 16);
            //        buf[3] = (byte)(len >> 24);
            //        buf = buf.Concat(Encoding.UTF8.GetBytes(msg)).ToArray();
            //        client.Send(buf);
            //        list.Add(client);
            //        //Thread.Sleep(1000);
            //    }
            //    Thread.Sleep(5000);
            //    while (i < 60)
            //    {
            //        i++;
            //        // to do 监听手机连接
            //        //string id = Guid.NewGuid().ToString();
            //        //string serialNumber = Guid.NewGuid().ToString();
            //        //Global.PhoneDic.TryAdd(serialNumber, new Phone() { Id = id, SerialNumber = serialNumber });
            //        //Thread.Sleep(1000);
            //        //this.Invoke(new Action(RefreshListView));
            //        Socket client = new Socket(SocketType.Stream, ProtocolType.Tcp);
            //        client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 14808));
            //        string sn = (i - 30).ToString();
            //        string msg = "{\"type\":2,\"SN\":\"" + sn + "\",\"result\":1}";

            //        Global.AddPhoneDic(sn, new Phone() { Id = Guid.NewGuid().ToString(), SerialNumber = sn });
            //        int len = Encoding.UTF8.GetByteCount(msg);
            //        byte[] buf = new byte[4];
            //        buf[0] = (byte)(len & 0xff);
            //        buf[1] = (byte)(len >> 8);
            //        buf[2] = (byte)(len >> 16);
            //        buf[3] = (byte)(len >> 24);
            //        buf = buf.Concat(Encoding.UTF8.GetBytes(msg)).ToArray();
            //        client.Send(buf);
            //        list.Add(client);
            //        //Thread.Sleep(1000);
            //    }
            //    string msg1 = "{\"type\":101,\"data\":\"sdgsdhjfgsjhdfgsjhdfg这是文本消息\",\"num\":100}";
            //    for(i = 1; i<=10;i++)
            //    {
            //        if (Global.GetPhone(i.ToString()).Connection == null)
            //        {

            //        }
            //        Global.SendMsgQueue.Enqueue(new Message(MessageProcessor.ToBytesFromMessageString(msg1),
            //            i.ToString()));
            //    }
            //    foreach (var item in list)
            //    {
            //        byte[] buf = new byte[msg1.Length + 1000];
            //        item.BeginReceive(buf, 0, buf.Length, SocketFlags.None,(obj) => {

            //            Console.WriteLine (Encoding.UTF8.GetString(buf).Replace('\0', '0'));
            //        }, null);
            //        Thread.Sleep(1000);
            //    }
            //    Thread.Sleep(int.MaxValue);
            //});
            //t.IsBackground = true;
            //t.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 
            //AdbHelper.ScanDevice();
            //AdbHelper.InstallApk();
            //AdbHelper.OpenApk(Global.PhoneList[0], "com.tencent.mm/com.tencent.mm.ui.LauncherUI");
            //Test();

            // 设置图片选择框
            this.openFileDialog1.Filter = "Image文件(*.png;*.jpg;*.gif;*.bmp)|*.png;*.jpg;*.gif;*.bmp";
            this.openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        }

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
                    this.listView1.Items[it.Index].SubItems[4].Text = phone.MobileState.ToString();
                    this.listView1.Items[it.Index].SubItems[5].Text = phone.FriendsNum.ToString();
                    this.listView1.Items[it.Index].SubItems[6].Text = phone.ExecuteState.ToString();
                    return;
                }
            }
            string[] strs = new string[7];
            strs[0] = phone.Id;
            strs[1] = phone.SerialNumber;
            strs[2] = phone.IsUsbConnect ? "已连接" : "未连接";
            strs[3] = phone.IsSocketConnect ? "已连接" : "未连接";
            strs[4] = phone.MobileState.ToString();
            strs[5] = phone.FriendsNum.ToString();
            strs[6] = phone.ExecuteState.ToString();
            ListViewItem item = new ListViewItem(strs);
            item.Tag = phone.SerialNumber;
            this.listView1.Items.Add(item);
        }

        public void RefreshListView()
        {
            foreach (var phone in Global.PhoneList)
            {
                this.RefreshListView(phone);
            }
        }

        private void openApkBtn_Click(object sender, EventArgs e)
        {
            this.openApkBtn.Enabled = false;
            var t = new Thread(() => {
                foreach (var phone in Global.PhoneList)
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
            this.installApkBtn.Enabled = false;
            var t = new Thread(() =>
            {
                ConcurrentStack<IAsyncResult> stack = new ConcurrentStack<IAsyncResult>();
                Semaphore semaphore  = new Semaphore(0, 1);
                foreach (var phone in Global.PhoneList)
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
        }

        private void SelectImgBtn_Click(object sender, EventArgs e)
        {
            //foreach (var item in PictureBoxList)
            //{
            //    item.ImageLocation = @"C:\Users\Administrator\Desktop\4.png";
            //}
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
    }
}

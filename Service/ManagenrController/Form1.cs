using System;
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
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var t = new Thread(() =>
            {
                List<Socket> list = new List<Socket>();
                int i = 0;
                while(i<30)
                {
                    i++;
                    // to do 监听手机连接
                    //string id = Guid.NewGuid().ToString();
                    //string serialNumber = Guid.NewGuid().ToString();
                    //Global.PhoneDic.TryAdd(serialNumber, new Phone() { Id = id, SerialNumber = serialNumber });
                    //Thread.Sleep(1000);
                    //this.Invoke(new Action(RefreshListView));
                    Socket client = new Socket(SocketType.Stream, ProtocolType.Tcp);
                    client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 14808));
                    string sn = i.ToString();
                    string msg = "{\"type\":1,\"SN\":\""+ sn + "\",\"result\":100}";

                    Global.AddPhoneDic(sn, new Phone() { Id = Guid.NewGuid().ToString(), SerialNumber = sn });
                    int len = Encoding.UTF8.GetByteCount(msg);
                    byte[] buf = new byte[4];
                    buf[0] = (byte)(len & 0xff);
                    buf[1] = (byte)(len >> 8);
                    buf[2] = (byte)(len >> 16);
                    buf[3] = (byte)(len >> 24);
                    buf = buf.Concat(Encoding.UTF8.GetBytes(msg)).ToArray();
                    client.Send(buf);
                    list.Add(client);
                    //Thread.Sleep(1000);
                }
                string msg1 = "{\"type\":101,\"data\":\"sdgsdhjfgsjhdfgsjhdfg这是文本消息\",\"num\":100}";
                for(i = 1; i<=10;i++)
                {
                    if (Global.GetPhone(i.ToString()).Connection == null)
                    {

                    }
                    Global.SendMsgQueue.Enqueue(new Message(MessageProcessor.ToBytesFromMessageString(msg1),
                        i.ToString()));
                }
                foreach (var item in list)
                {
                    byte[] buf = new byte[msg1.Length + 1000];
                    item.BeginReceive(buf, 0, buf.Length, SocketFlags.None,(obj) => {

                        Console.WriteLine (Encoding.UTF8.GetString(buf).Replace('\0', '0'));
                    }, null);
                    Thread.Sleep(1000);
                }
                Thread.Sleep(int.MaxValue);
            });
            t.IsBackground = true;
            t.Start();
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
                    return;
                }
            }
            string[] strs = new string[5];
            strs[0] = phone.Id;
            strs[1] = phone.SerialNumber;
            strs[2] = phone.IsUsbConnect ? "已连接" : "未连接";
            strs[3] = phone.IsSocketConnect ? "已连接" : "未连接";
            strs[4] = phone.MobileState.ToString();
            ListViewItem item = new ListViewItem(strs);
            item.Tag = phone.SerialNumber;
            this.listView1.Items.Add(item);
        }
    }
}

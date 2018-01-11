using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Net.Sockets;

namespace ManagenrController
{
    public class Global
    {
        /// <summary>
        /// 手机序列号， 手机对象 字典
        /// </summary>
        private static ConcurrentDictionary<string, Phone> PhoneDic = new ConcurrentDictionary<string, Phone>();
        /// <summary>
        /// 发送消息队列
        /// </summary>
        public static BlockingQueue<Message> SendMsgQueue = new BlockingQueue<Message>();
        /// <summary>
        /// 接受消息队列
        /// </summary>
        public static BlockingQueue<Message> ReceiveMsgQueue = new BlockingQueue<Message>();

        private static int NextId = 1;

        private static readonly object lockObj = new object();

        public static string GetId()
        {
            lock(lockObj)
            {
                return NextId++.ToString();
            }
        }

        public static readonly string IP = "127.0.0.1";

        public static readonly int Port = 14807;

        public static readonly int ScanTime = 1; // 每1秒扫描一次

        public static readonly string StartActivity = "com.tencent.mm/com.tencent.mm.ui.LauncherUI";

        public static readonly string AppPath = "douban_120.apk";

        public static MainForm Form;

        public static void AddPhoneDic(string serialNumber, Phone phone)
        {
            //PhoneDic.TryAdd(serialNumber, phone);
            //PhoneDic[serialNumber] = phone;
            PhoneDic[serialNumber] = phone;
        }

        public static void UpdatePhone(string serialNumber, int friendNum)
        {
            PhoneDic[serialNumber].FriendsNum = friendNum;
        }

        public static void UpdatePhone(string serialNumber, Socket connection)
        {
            PhoneDic[serialNumber].Connection = connection;
        }

        public static void UpdatePhone(string serialNumber, EnumMobileState state)
        {
            PhoneDic[serialNumber].MobileState = state;
        }

        public static void UpdatePhone(string serialNumber, bool isUsb)
        {
            PhoneDic[serialNumber].IsUsbConnect = isUsb;
        }

        public static void UpdatePhone(string serialNumber, EnumPrevExecuteState state)
        {
            PhoneDic[serialNumber].ExecuteState = state;
        }

        public static Phone GetPhone(string serialNumber)
        {
            Phone phone = null;
            if (PhoneDic.TryGetValue(serialNumber, out phone))
            {
                return phone;
            }
            return null;
        }

        public static List<Phone> PhoneList
        {
            get
            {
                return PhoneDic.Select(p => p.Value).ToList();
            }
        }
    }
}

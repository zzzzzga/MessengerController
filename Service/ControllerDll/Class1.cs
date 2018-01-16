using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AndroidControlSDK;

namespace ControllerDll
{
    public class Class1 : AndroidScript
    {
        public override string Description()
        {
            return "fackbook Controller";
        }

        public override string Name()
        {
            return "fackbook Controller";
        }

        public override void RunScript()
        {
            // this.ShowLogConsole("测试");
            // 启动testdemo
            // 找到输入框，输入ip
            // 点击连接按钮
            // ShowLogConsole();
            var str = this.RunAdb("am start -n com.lxkj.fansir.fansirfb/com.lxkj.fansir.fansirfb.MainActivity");
            Thread.Sleep(2000);
            // ShowStatus(str);
            str = this.FindAndInutText("et", GetLocalIP());
            Thread.Sleep(1000);
            // ShowStatus(str);
            str = this.FindAndCLickObj("连        接");
            //Thread.Sleep(2000);
            // ShowStatus(str);
        }

        public string GetLocalIP()
        {
            try
            {
                string HostName = Dns.GetHostName(); //得到主机名
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址
                    //AddressFamily.InterNetwork表示此IP为IPv4,
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork && IpEntry.AddressList[i].ToString().Contains("192.168.1."))
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                ShowStatus(ex.ToString());
                return "";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Windows.Forms;

namespace ManagenrController
{
    public class Service
    {
        private static Object obj = new object();
        private Service()
        {

        }

        private static Service service;

        public static Service Default
        {
            get
            {
                if (service == null)
                {
                    lock (obj)
                    {
                        if (service == null)
                        {
                            service = new Service();
                        }
                    }
                }
                return service;
            }
        }

        public void StartService()
        {
            var thread = new Thread(Listen);
            thread.IsBackground = true;
            thread.Start();
        }

        private void Listen()
        {
            Socket socket = null;
            try
            {
                //  死循环
                // 启动socket服务
                // 获得连接
                socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(new IPEndPoint(IPAddress.Any, Global.Port));
                socket.Listen(100);
                Socket connection = null;

                while (true)
                {
                    try
                    {
                        connection = socket.Accept();
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.Message);
                        break;
                    }
                    // 接受消息
                    var pts = new ParameterizedThreadStart(MessageProcessor.ReceiveMsg);
                    var t = new Thread(pts);
                    t.IsBackground = true;
                    t.Start(connection);
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex.ToString());
            }
            finally
            {
                socket?.Close();
                MessageBox.Show("端口：" + Global.Port + "被占用...", "错误");
                Environment.Exit(1);
            }
        }

        public void Receive()
        {
            var thread = new Thread(MessageProcessor.DealWithReceiveMessage);
            thread.IsBackground = true;
            thread.Start();
        }

        public void Send()
        {
            var thread = new Thread(MessageProcessor.DealWidthSendMessage);
            thread.IsBackground = true;
            thread.Start();
        }

        public void ScanDevice()
        {
            var t = new Thread(() =>
            {
                try
                {
                    Stopwatch stopwatch = new Stopwatch();
                    while (true)
                    {
                        stopwatch.Start();
                        AdbHelper.ScanDevice();
                        if (Global.Form != null)
                        {
                            Global.Form.Invoke(new Action(Global.Form.RefreshListView));
                        }
                        stopwatch.Stop();
                        int time = Global.ScanTime * 1000 - (int)stopwatch.ElapsedMilliseconds;
                        Thread.Sleep(time > 0 ? time : 0);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.ToString());
                }
            });
            t.IsBackground = true;
            t.Start();
        }
    }
}

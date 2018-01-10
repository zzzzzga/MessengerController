using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/// <summary>
/// 消息头定义
/// 前4个字节是消息内容的长度
/// 内容是json字符串
/// </summary>
namespace ManagenrController
{
    public class MessageProcessor
    {
        /// <summary>
        /// 字符串转字节数组
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static byte[] ToBytesFromMessageString(string msg)
        {
            int len = Encoding.UTF8.GetByteCount(msg);
            byte[] buf = new byte[4];
            buf[0] = (byte)(len);
            buf[1] = (byte)(len >> 8);
            buf[2] = (byte)(len >> 16);
            buf[3] = (byte)(len >> 24);
            return buf.Concat(Encoding.UTF8.GetBytes(msg)).ToArray();
        }

        /// <summary>
        /// 接受消息
        /// </summary>
        /// <param name="clientSocket"></param>
        public static void ReceiveMsg(object clientSocket)
        {
            Socket client = clientSocket as Socket;

            int readLen = 0;
            int frameLen = 0;
            byte[] frame = null;
            while (true)
            {
                try
                {
                    byte[] buf = new byte[1024 * 1024];
                    int len = 0;
                    len = client.Receive(buf);
                    for (int i = 0; i < len; i++)
                    {
                        if (readLen < 4)
                        {
                            // 计算消息长度
                            switch (readLen)
                            {
                                case 0:
                                case 1:
                                case 2:
                                case 3:
                                    frameLen += buf[i] << (readLen * 8);
                                    break;
                            }
                        }
                        else
                        {
                            if (len - i >= frameLen)
                            {
                                // 成功
                                if (frame == null)
                                {
                                    frame = buf.Skip(i).Take(frameLen).ToArray();
                                    Global.ReceiveMsgQueue.Enqueue(new Message(client, frame));
                                    i += frameLen - 1;
                                    readLen = 0;
                                    frameLen = 0;
                                    frame = null;
                                }
                                else
                                {
                                    int oldLen = frame.Length;
                                    frame = frame.Concat(buf.Skip(i).Take(frameLen - oldLen)).ToArray();
                                    Global.ReceiveMsgQueue.Enqueue(new Message(client, frame));
                                    i += frameLen - oldLen - 1;
                                    readLen = 0;
                                    frameLen = 0;
                                    frame = null;
                                }
                            }
                            else
                            {
                                if (frame == null)
                                {
                                    frame = buf.Skip(i).Take(len - i).ToArray();
                                    i = len - 1;
                                    readLen += len - i - 1;
                                }
                                else
                                {
                                    int oldLen = frame.Length;
                                    if (len - i >= frameLen - oldLen)
                                    {
                                        // 成功
                                        frame = frame.Concat(buf.Skip(i).Take(frameLen - oldLen)).ToArray();
                                        Global.ReceiveMsgQueue.Enqueue(new Message(client, frame));
                                        i += frameLen - oldLen - 1;
                                        readLen = 0;
                                        frameLen = 0;
                                        frame = null;
                                    }
                                    else
                                    {
                                        frame = frame.Concat(buf.Skip(i).Take(len - i)).ToArray();
                                        i = len - 1;
                                        readLen += len - i - 1;
                                    }
                                }
                            }
                        }
                        readLen++;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                    break;
                }
            }
        }

        public static void DealWithReceiveMessage()
        {
            while(true)
            {
                Message msg = null;
                if (Global.ReceiveMsgQueue.TryDequeue(out msg))
                {
                    try
                    {
                        var model = JsonConvert.DeserializeObject<MessageModel>(Encoding.UTF8.GetString(msg.MessgaeBody));
                        switch (model.type)
                        {
                            case 1:
                                // 建立连接
                                Global.UpdatePhone(model.SN, model.result);
                                Global.UpdatePhone(model.SN, msg.Connection);
                                Logger.Info("序列号：" + model.SN + ", 建立socket连接, 好友数为：" + model.result);
                                break;
                            case 2:
                                // 返回执行结果
                                Global.UpdatePhone(model.SN, (EnumPrevExecuteState)model.result);
                                Global.UpdatePhone(model.SN, EnumMobileState.准备);
                                Logger.Info("序列号：" + model.SN + ", 执行结果返回, 最终结果为：" + model.result);
                                break;
                        }
                        //if (Global.Form != null && Global.ReceiveMsgQueue.Count == 0)
                        //{
                        //    // Global.Form.Invoke(new Action<Phone>(Global.Form.RefreshListView), Global.GetPhone(model.SN));
                        //    Global.Form.Invoke(new Action(Global.Form.RefreshListView));
                        //}
                        if (Global.Form != null)
                        {
                            Global.Form.Invoke(new Action<Phone>(Global.Form.RefreshListView), Global.GetPhone(model.SN));
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.ToString());
                    }
                }
            }
        }

        public static void DealWidthSendMessage()
        {
            while(true)
            {
                Message msg = null;
                try
                {
                    if (Global.SendMsgQueue.TryDequeue(out msg))
                    {
                        var conn = Global.GetPhone(msg.SerialNumber).Connection;
                        conn.BeginSend(msg.MessgaeBody, 0, msg.MessgaeBody.Length,
                            SocketFlags.None, null, null);
                    }
                }
                catch(Exception ex)
                {
                    if (msg != null)
                    {
                        Logger.Info("消息发送失败， 重新发送");
                        Global.SendMsgQueue.Enqueue(msg);
                    }
                    Logger.Error(ex.ToString());
                }
            }
        }
    }
}

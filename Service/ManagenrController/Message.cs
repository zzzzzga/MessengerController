using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ManagenrController
{
    public class Message
    {

        public Message(byte[] messgaeBody, string serialNumber)
        {
            MessgaeBody = messgaeBody;
            SerialNumber = serialNumber;
        }

        public Message(Socket connection, byte[] messgaeBody)
        {
            Connection = connection;
            MessgaeBody = messgaeBody;
        }

        public Message()
        {
        }

        public Socket Connection { get; set; }

        public byte[] MessgaeBody { get; set; }

        public string SerialNumber { get; set; }
    }

    public enum EnumConnectState
    {
        连接,
        未连接
    }

    public  enum EnumMobileState
    {
        执行中,
        准备
    }

    public enum EnumPrevExecuteState
    {
        无 = -1,
        成功 = 0,
        失败 = 1
    }
}

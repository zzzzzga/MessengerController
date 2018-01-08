using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ManagenrController
{
    public class Phone
    {
        public string Id { get; set; }

        public string SerialNumber { get; set; }

        public int FriendsNum { get; set; }
        /// <summary>
        /// Socket是否连接
        /// </summary>
        public bool IsSocketConnect
        {
            get
            {
                return Connection == null ? false : Connection.Connected;
            }
        }
        public Socket Connection { get; set; }

        public EnumMobileState MobileState { get; set; }

        public bool IsUsbConnect { set; get; }

        public EnumPrevExecuteState ExecuteState {set;get;}
    }

    public class PhoneViewModel
    {
        public string Id { get; set; }

        public string SerialNumber { get; set; }
    }
}

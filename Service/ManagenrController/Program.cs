using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagenrController
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Service.Default.StartService();
            Service.Default.Receive();
            Service.Default.Send();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Global.Form = new MainForm();
            Application.Run(Global.Form);
        }
    }
}

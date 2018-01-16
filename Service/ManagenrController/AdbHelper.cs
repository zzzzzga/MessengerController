using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagenrController
{
    public class AdbHelper
    {
        private static readonly string ScanDeviceCmd = "adb \"devices\"";

        private static readonly string InstallApkCmd = "adb -s \"{0}\" install -r \"{1}\"";

        private static readonly string OpenAppCmd = "adb -s \"{0}\" shell am start -n \"{1}\"";

        private static readonly string PortForward = "adb -s \"{0}\" reverse \"tcp:{1}\" \"tcp:{2}\"";

        private static readonly string RemoveReverse = "adb -s \"{0}\" reverse --remove-all";

        private static readonly string KillAdb = "adb kill-server";
        /// <summary>
        /// 扫描设备
        /// </summary>
        public static void ScanDevice()
        {
            string output, err;
            WinCmd.Execute(ScanDeviceCmd, out output, out err);
            string[] result = output.Split(new String[] { "List of devices attached" }, StringSplitOptions.RemoveEmptyEntries);
            IEnumerable<string> devices = result[1].Split('\n').Where(r => !string.IsNullOrWhiteSpace(r) && r.Contains("device")).Select(r => r.Trim().Split(' ', '\r', '\t')[0].Trim());
            foreach (var item in Global.PhoneList)
            {
                if (!devices.Contains(item.SerialNumber))
                {
                    if (item.IsUsbConnect)
                    {
                        Global.UpdatePhone(item.SerialNumber, false);
                        //Global.UpdatePhone(item.SerialNumber, null);
                        //Global.UpdatePhone(item.SerialNumber, EnumPrevExecuteState.无);
                        //Global.UpdatePhone(item.SerialNumber, 0);
                        //Global.UpdatePhone(item.SerialNumber, EnumMobileState.准备);
                        Logger.Warn("手机：" + item.SerialNumber + ", Usb断开");
                    }
                }
                else
                {
                    if (!item.IsUsbConnect)
                    {
                        Global.UpdatePhone(item.SerialNumber, true);
                        // MobileMapPortPC(item, Global.MobilePort, Global.Port);
                        Logger.Info("手机：" + item.SerialNumber + ", Usb重新连接");
                    }
                }
                devices = devices.Where(d => d != item.SerialNumber);
            }
            foreach (var item in devices)
            {
                Phone phone = new Phone()
                {
                    Id = Global.GetId(),
                    SerialNumber = item,
                    Connection = null,
                    ExecuteState = EnumPrevExecuteState.无,
                    FriendsNum = 0,
                    IsUsbConnect = true,
                    MobileState = EnumMobileState.准备
                };
                Global.AddPhoneDic(item, phone);
                // MobileMapPortPC(phone, Global.MobilePort, Global.Port);
                Logger.Info("手机：" + item + ", Usb连接");
            }
        }
        /// <summary>
        /// 安装apk
        /// </summary>
        public static void InstallApk(Phone phone, string apkPath)
        {
            string output, err;
            phone.MobileState = EnumMobileState.执行中;
            if (Global.Form != null)
            {
                Global.Form.Invoke(new Action(Global.Form.RefreshListView));
            }
            WinCmd.Execute(string.Format(InstallApkCmd, phone.SerialNumber, apkPath), out output, out err);
            phone.MobileState = EnumMobileState.准备;
            if (!err.Contains("Failure"))
            {
                phone.ExecuteState = EnumPrevExecuteState.成功;
                Logger.Info("手机: " + phone.SerialNumber + ", 安装成功！");
            }
            else
            {
                phone.ExecuteState = EnumPrevExecuteState.失败;
                Logger.Error("手机: " + phone.SerialNumber + ", 安装失败！\n" + err);
            }
        }
        /// <summary>
        /// 打开app
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="apk"></param>
        public static void OpenApk(Phone phone, string apk)
        {
            string output, err;
            phone.MobileState = EnumMobileState.执行中;
            if (Global.Form != null)
            {
                Global.Form.Invoke(new Action(Global.Form.RefreshListView));
            }
            WinCmd.Execute(string.Format(OpenAppCmd, phone.SerialNumber, apk), out output, out err);
            phone.MobileState = EnumMobileState.准备;
            if (string.IsNullOrWhiteSpace(err))
            {
                phone.ExecuteState = EnumPrevExecuteState.成功;
                Logger.Info("手机: " + phone.SerialNumber + ", 打开" + apk + "成功!");
            }
            else
            {
                phone.ExecuteState = EnumPrevExecuteState.失败;
                Logger.Warn("手机: " + phone.SerialNumber + ", 打开" + apk + "失败!\n" + err);
            }
        }
        /// <summary>
        /// 手机端口映射到PC
        /// </summary>
        /// <param name="phone"></param>
        public static void MobileMapPortPC(Phone phone, int mobilePort, int port)
        {
            string output, err;
            phone.MobileState = EnumMobileState.执行中;
            if (Global.Form != null)
            {
                Global.Form.Invoke(new Action(Global.Form.RefreshListView));
            }
            WinCmd.Execute(string.Format(PortForward, phone.SerialNumber, mobilePort, port), out output, out err);
            phone.MobileState = EnumMobileState.准备;
            if (string.IsNullOrWhiteSpace(err))
            {
                phone.ExecuteState = EnumPrevExecuteState.成功;
                Logger.Warn("手机: " + phone.SerialNumber + ", 端口映射成功");
            }
            else
            {
                phone.ExecuteState = EnumPrevExecuteState.失败;
                Logger.Warn("手机: " + phone.SerialNumber + ", 端口映射失败!\n" + err);
            }
        }

        public static void RemoveAllReverse(Phone phone)
        {
            string output, err;
            WinCmd.Execute(string.Format(RemoveReverse, phone.SerialNumber), out output, out err);
            if (string.IsNullOrWhiteSpace(err))
            {
                Logger.Info("手机: " + phone.SerialNumber + ", 成功!");
            }
            else
            {
                Logger.Warn("手机: " + phone.SerialNumber + ", 失败!\n" + err);
            }
        }

        public static void KillServer()
        {
            string output, err;
            WinCmd.Execute(string.Format(KillAdb), out output, out err);
            if (string.IsNullOrWhiteSpace(err))
            {
                Logger.Info("KillADB成功!");
            }
            else
            {
                Logger.Warn("KillADB失败!\n" + err);
            }
        }
    }
}

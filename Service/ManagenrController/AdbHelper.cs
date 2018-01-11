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
        /// <summary>
        /// 扫描设备
        /// </summary>
        public static void ScanDevice()
        {
            string output, err;
            WinCmd.Execute(ScanDeviceCmd, out output, out err);
            string[] result = output.Split("\n".ToArray(), StringSplitOptions.RemoveEmptyEntries);
            IEnumerable<string> devices = result.Skip(5).Where(r => !string.IsNullOrWhiteSpace(r)).Select(r => r.Trim().Split(' ', '\r', '\t')[0].Trim());
            foreach (var item in Global.PhoneList)
            {
                if (!devices.Contains(item.SerialNumber))
                {
                    if (item.IsUsbConnect)
                    {
                        Global.UpdatePhone(item.SerialNumber, false);
                        Logger.Warn("手机：" + item.SerialNumber + ", Usb断开");
                    }
                }
                else
                {
                    if (!item.IsUsbConnect)
                    {
                        Global.UpdatePhone(item.SerialNumber, true);
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
            if (output.Split('\n')[5].Trim() == "Success")
            {
                phone.ExecuteState = EnumPrevExecuteState.成功;
                Logger.Info("手机: " + phone.SerialNumber + ", 安装成功！");
            }
            else
            {
                phone.ExecuteState = EnumPrevExecuteState.失败;
                Logger.Error("手机: " + phone.SerialNumber + ", 安装失败！");
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
            }
            else
            {
                phone.ExecuteState = EnumPrevExecuteState.失败;
            }
        }
    }
}

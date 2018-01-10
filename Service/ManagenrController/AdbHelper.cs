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
        private static string ScanDeviceCmd = "adb \"devices\"";

        private static string InstallApkCmd = "adb -s \"{0}\" install -r \"{1}\"";

        private static string OpenAppCmd = "adb -s \"{0}\" shell am start -n \"{1}\"";

        public static void ScanDevice()
        {
            string output, err;
            WinCmd.Execute(ScanDeviceCmd, out output, out err);
            string[] result = output.Split("\n".ToArray(), StringSplitOptions.RemoveEmptyEntries);
            List<string> devices = result.Skip(5).Where(r => !string.IsNullOrWhiteSpace(r)).Select(r => r.Trim().Split(' ', '\r', '\t')[0].Trim()).ToList();
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
            }
        }

        public static void InstallApk(Phone phone, string apkPath)
        {
            string output, err;
            phone.MobileState = EnumMobileState.执行中;
            WinCmd.Execute(string.Format(InstallApkCmd, phone.SerialNumber, apkPath), out output, out err);
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

        public static void OpenApk(Phone phone, string apk)
        {
            string output, err;
            phone.MobileState = EnumMobileState.执行中;
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

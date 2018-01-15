using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallDll
{
    public class Class1 : AndroidControlSDK.AndroidScript
    {
        public override string Description()
        {
            return "安装testdemo";
        }

        public override string Name()
        {
            return "安装testdemo";
        }

        public override void RunScript()
        {
            // 安装apk
            this.RunAdb("");
        }
    }
}

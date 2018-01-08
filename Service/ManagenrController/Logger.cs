using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagenrController
{
    public class Logger
    {
        public static void Info (string format, params object[] strs)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("INFO: " + format, strs);
        }

        public static void Debug(string format, params object[] strs)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DEBUG: " + format, strs);
        }

        public static void Error(string format, params object[] strs)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: " + format, strs);
        }

        public static void Warn(string format, params object[] strs)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("WARN: " + format, strs);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagenrController
{
    public class Logger
    {
        public static void Info (string format)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("INFO: " + format);
        }

        public static void Debug(string format)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DEBUG: " + format);
        }

        public static void Error(string format)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: " + format);
        }

        public static void Warn(string format)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("WARN: " + format);
        }
    }
}

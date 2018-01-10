using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ManagenrController
{
    public class WinCmd
    {

        static WinCmd()
        {
            var path = System.Environment.GetEnvironmentVariable("Path");
            path += $";{Path.GetFullPath(".")};";
            System.Environment.SetEnvironmentVariable("Path", path, EnvironmentVariableTarget.Process);
        }
        public static void Execute(string command, out string output, out string error)
        {
            try
            {
                output = "";
                error = "";
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;

                process.Start();

                process.StandardInput.WriteLine(command + "&exit");
                process.StandardInput.AutoFlush = true;
                string _output = "", _error = "";
                //process.OutputDataReceived += (sender, e) =>
                //{
                //    _output += e.Data;
                //};

                //process.ErrorDataReceived += (sender, e) =>
                //{
                //    _error += e.Data;
                //};

                //process.BeginOutputReadLine();
                //process.BeginErrorReadLine();
                _error = process.StandardError.ReadToEnd();
                _output = process.StandardOutput.ReadToEnd();

                process.WaitForExit();

                process.Close();

                output = _output;
                error = _error;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

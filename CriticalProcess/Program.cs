using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CriticalProcess
{
    class Program
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);
        static void Main(string[] args)
        {
            Process.EnterDebugMode();
            NtSet(1, 0x1D);

            Console.WriteLine("Nice Process!");
            Console.ReadLine();
        }

        public static void NtSet(int Enabled = 1, int Flag = 0x1D)
        {
            NtSetInformationProcess(Process.GetCurrentProcess().Handle, Flag, ref Enabled, sizeof(int));
        }
    }
}

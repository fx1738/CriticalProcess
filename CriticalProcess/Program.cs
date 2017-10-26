using Microsoft.Win32;
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
            // app shutdown listener
            SystemEvents.SessionEnded += new SessionEndedEventHandler(SystemEvents_SessionEnded);

            // enter debug mode
            Process.EnterDebugMode();
            NtSet(1, 0x1D);
            // do your stuff here
            Console.WriteLine("Nice ProaaaceswaWRRQFds");//suh
            Console.ReadLine();

            // end critical mode
            NtSet(0, 0x1D);
        }

        public static void NtSet(int Enabled = 1, int Flag = 0x1D)
        {
            NtSetInformationProcess(Process.GetCurrentProcess().Handle, Flag, ref Enabled, sizeof(int));
        }

        static void SystemEvents_SessionEnded(object sender, SessionEndedEventArgs e)
        {
            // End Critical Process on windows shutdown or log off
            NtSet(0, 0x1D);
        }
    }
}

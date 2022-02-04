using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NETProject
{
    internal class _07_Process
    {
        public static void Main(string[] args)
        {
            // 프로세스 생성
            if (false)
            {
                Console.WriteLine("메모장 실행, 5초 후 종료");

                // Process notepad = Process.Start("notepad.exe");
                Process notepad = Process.Start("notepad.exe","c:\\temp\\fs.txt");
                Thread.Sleep(5000);
                notepad.Kill();
            }
            // 프로세스 열거
            if (true)
            {
                //Console.WriteLine("열거");
                //foreach(Process process in Process.GetProcesses()) 
                //{ 
                //    Console.WriteLine(
                //        string.Format(
                //            "Process Name : {0}\nProcess ID : {1}\nWorking Set : {2}",
                //            process.ProcessName,
                //            process.Id,
                //            process.WorkingSet64)); 
                //}

                Process[] Procs = Process.GetProcesses();
                foreach(Process p in Procs)
                {
                    Console.WriteLine("ID={0}, 이름={1}", p.Id, p.ProcessName);
                }

            }
        }
    }
}

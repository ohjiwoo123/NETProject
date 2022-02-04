using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NETProject
{
    class MySync
    {
        private object obj = new object();
        public void MyThreadFuncRace(object count)
        {
            lock (obj)
            {
                // lock 지우고 lock의 기능을 똑같이 Monitor로도 가능 
                // Monitor.Enter(this);
                //-------------------------------------------------
                for (int i = 0; i <= (int)count; i++)
                {
                    Thread mySelf = Thread.CurrentThread;   //GetCurrentThread (c++)
                    Console.WriteLine("스레드 {0} ==> {1}초:{2}", mySelf.Name, DateTime.Now.Second, i);
                    Thread.Sleep(1000);
                }
                //-------------------------------------------------
                // Monitor.Exit(this);
            }
        }
    }

    internal class _08_Thread
    {
        public static void MyThreadFunc()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread mySelf = Thread.CurrentThread;   //GetCurrentThread (c++)
                Console.WriteLine("스레드 {0} ==> {1}초:{2}", mySelf.Name, DateTime.Now.Second, i);
                Thread.Sleep(1000);
            }
        }
        public static void MyThreadFuncParam(object count)
        {
            for (int i = 0; i <= (int)count; i++)
            {
                Thread mySelf = Thread.CurrentThread;   //GetCurrentThread (c++)
                Console.WriteLine("스레드 {0} ==> {1}초:{2}", mySelf.Name, DateTime.Now.Second, i);
                Thread.Sleep(1000);
            }
        }
        public static void Main(string[] args)
        {
            // 쓰레드 동시성 확보 
            if (false)
            {
                ThreadStart ts = new ThreadStart(MyThreadFunc);
                Thread t = new Thread(ts);
                t.Name = "오렌지";
                t.Start();

                ThreadStart ts2 = new ThreadStart(MyThreadFunc);
                Thread t1 = new Thread(ts2);
                t1.Name = "딸기";
                t1.Start();


                for (; ; )
                {
                    ConsoleKeyInfo cki;
                    cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.A)
                        Console.WriteLine('A');
                    if (cki.Key == ConsoleKey.B)
                        break;
                }
                Console.WriteLine("End Main");
            }
            // 쓰레드 상태 제어----------------------------------------
            if (false)
            {
                Thread t = new Thread(new ThreadStart(MyThreadFunc));
                t.Name = "오렌지";
                //t.Start();

                // 우선순위 --------------------------------------------------------
                // 우선순위가 높으면 cpu time을 더 할당 받는다.
                Console.WriteLine("우선순위1. " + t.Priority);
                ++t.Priority;
                Console.WriteLine("우선순위2. " + t.Priority);
                ++t.Priority;
                Console.WriteLine("우선순위1. " + t.Priority);
                Console.WriteLine("------------------------------");

                Console.WriteLine("Step1. " + t.ThreadState);
                t.Start();
                Console.WriteLine("Step2 . " + t.ThreadState);

                t.Suspend();    // 쓰레드 잠시 멈춤
                Thread.Sleep(1000);
                Console.WriteLine("Step3 . " + t.ThreadState);

                t.Resume(); // 쓰레드 재개
                Thread.Sleep(1000);
                Console.WriteLine("Step4 . " + t.ThreadState);

                // t.Abort();  // 쓰레드 종료 
                t.Join();   // 쓰레드가 완전히 종료하고 자원을 해제할 때까지 기다림.
                Thread.Sleep(1000);
                Console.WriteLine("Step5 . " + t.ThreadState);
            }
            // 인자가 있는 스레드 (ParameterizedThreadStart)
            if (false)
            {
                // 인자가 있을 시 , ParameterizedThreadStart를 앞에 붙여준다.
                Thread t = new Thread(new ThreadStart(MyThreadFunc));
                t.Name = "오렌지";
                t.Start();

                // 인자가 있을 시 , ParameterizedThreadStart를 앞에 붙여준다.
                Thread t1 = new Thread(new ParameterizedThreadStart(MyThreadFuncParam));
                t1.Name = "딸기";
                t1.Start(5);
            }
            // 동기화 (lock, monitor) - 쓰레드의 경쟁 (동시성 저해)
            if (true)
            {
                MySync mysync = new MySync();

                // 인자가 있을 시 , ParameterizedThreadStart를 앞에 붙여준다.
                Thread t = new Thread(new ParameterizedThreadStart(mysync.MyThreadFuncRace));
                t.Name = "강아지";

                // 인자가 있을 시 , ParameterizedThreadStart를 앞에 붙여준다.
                Thread t1 = new Thread(new ParameterizedThreadStart(mysync.MyThreadFuncRace));
                t1.Name = "고양이";

                t.Start(5);
                t1.Start(5);
            }
        }
    }
}

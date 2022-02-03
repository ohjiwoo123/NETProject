using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETProject
{
    class Human
    {
        private string Name;
        private int Age;
        private float Temp; // 저장할 필요가 없는 임시 데이터
        public Human(string aName, int aAge)
        {
            Name = aName;
            Age = aAge;
            Temp = 1.23f;
        }

        public void WriteHuman(BinaryWriter bw)
        {
            bw.Write(Name);
            bw.Write(Age);
            bw.Write(Temp);
        }

        public static Human ReadHuman(BinaryReader br)
        {
            // 지정한 순서대로 복구해야 함
            string name = br.ReadString();
            int age = br.ReadInt32();

            return new Human(name, age);
        }

        public void ReadHuman2(BinaryReader br)
        {
            // 지정한 순서대로 복구해야 함
            Name = br.ReadString();
            Age = br.ReadInt32();
        }

        public static void PrintHuman(Human a)
        {
            Console.WriteLine(a.Name);
            Console.WriteLine(a.Age);
            Console.WriteLine($"이름 : {a.Name}, 나이 : {a.Age}세");
        }
    }

    internal class _06_File_iO
    {
        public static void Main(string[] args)
        {
            // FileStream : 1) 쓰기
            if (false)
            {
                byte[] data = { 65, 66, 67, 68, 69, 70, 71, 72 };
                FileStream fs = new FileStream(@"c:\Temp\fs.txt",   // file path
                                                FileMode.Create,    // file mode
                                                FileAccess.Write);  // file access

                fs.Write(data, 3, data.Length-3);
                fs.Close();

                Console.WriteLine("기록 완료");
            }

            // FileStream : 2) 읽기
            if (false)
            {
                byte[] data = new byte[20];
                FileStream fs = new FileStream(@"c:\Temp\fs.txt",   // file path
                                                FileMode.Open,    // file mode
                                                FileAccess.Read);  // file access

                int ss = fs.Read(data, 0, data.Length);
                fs.Close();

                for (int i=0; i<ss; i++)
                {
                    Console.WriteLine(data[i]);
                }

                for (int i = 0; i < ss; i++)
                {
                    char a = (char)data[i];
                    Console.WriteLine(a);
                }

                foreach (char ch in data)
                {
                    Console.WriteLine(ch);
                }

                Console.WriteLine("읽기 완료");
            }

            // StreamWriter : 쓰기
            if (false)
            {
                StreamWriter sw = new StreamWriter(@"c:\Temp\cstest.txt");
                sw.Write("I Love You, Do You Love Me?");
                sw.Write(1234);
                sw.Write(' ');
                sw.Write(3.14);
                sw.Close();

                Console.WriteLine("기록했습니다.");

            }
            // StreamReader : 읽기
            if (false)
            {
                StreamReader sr = new StreamReader(@"c:\Temp\cstest.txt");
                string si = sr.ReadToEnd();
                Console.WriteLine(si);
                sr.Close();
                Console.WriteLine("sr 읽었습니다.");

                char[] buf = new char[1024];
                StreamReader sr2 = new StreamReader(@"c:\Temp\cstest.txt");
                int ret = sr2.Read(buf, 0, 1024);

                // string temp = new string(buf, 0, ret); sr2를 이렇게 바꿔서 읽어도 되긴함.

                Console.WriteLine("sr2 읽었습니다.");
            }
            // BinaryWriter : 쓰기
            if (false)
            {
                //const string fileName = "AppSettings.dat";
                //Human Hong = new Human("홍길동", 28);
                //BinaryWriter bw = new BinaryWriter(File.Open(fileName, FileMode.Create));
                
                Human Hong = new Human("홍길동", 28);
                FileStream fs = new FileStream(@"c:\Temp\Hong.dat",   // file path
                                                FileMode.Create,    // file mode
                                                FileAccess.Write);  // file access
                BinaryWriter bw = new BinaryWriter(fs);
                Hong.WriteHuman(bw);
                //bw.Write(Hong.Name);
                //bw.Write(Hong.Age);
                fs.Close();
            }
            // BinaryReader : 읽기
            if (true)
            {

                FileStream fs = new FileStream(@"c:\Temp\Hong.dat",   // file path
                                                FileMode.Open,    // file mode
                                                FileAccess.Read);  // file access

                BinaryReader br = new BinaryReader(fs);

                Human Hong = Human.ReadHuman(br);

                // Hong.ReadHuman2(br);

                Human.PrintHuman(Hong);

                fs.Close();
            }
        }
    }
}

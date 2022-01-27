using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETProject
{
    // Reflection
    // 객체의 형식을 보여주는 기능 (객체에 대한 X-Ray 사진)

    public class Human
    {
        public string name;
        public int age;
        public void PrintInfo() { }
    }

    internal class _04_Reflection
    {
        static void OutScore(object score)
        {
            switch (score)//switch 패턴매칭
            {
                case null:
                    Console.WriteLine("성적 정보 없음");
                    break;
                case 100:
                    Console.WriteLine("만점 ^^~");
                    break;
                case int value when value < 0 || value > 100:
                    Console.WriteLine("무효한 성적" + value);
                    break;
                case int value:
                    Console.WriteLine(value);
                    break;
                case string why:
                    Console.WriteLine(why);
                    break;
                case DateTime tran:
                    Console.WriteLine(tran + "에 전학감");
                    break;
                case ArrayList list:
                    foreach (var a in list)
                    {
                        Console.Write(a + ", ");
                    }
                    Console.WriteLine();
                    break;
            }
        }
            static void Main(string[] args)
        {
            // 1. Object.GetType() : 객체의 형식정보를 반환함
            if (false)
            {
                //int a = 40;
                Human a = new Human();
                Type type = a.GetType();    // 인스턴스가 있어야 정보를 구함.
                Console.WriteLine(type);

                var f = type.GetFields();
                foreach (var x in f)
                {
                    Console.WriteLine("필드 : " + x.Name);
                    Console.WriteLine("필드 : " + x.FieldType);
                }

                var m = type.GetMethods();
                foreach (var x in m)
                {
                    Console.WriteLine("메소드 : " + x.Name + "()");
                }
            }
            // 2. typeof 연산자
            if (false)
            {
                Type t = typeof(int);
                Type tt = typeof(Human);
                Console.WriteLine(t);
                Console.WriteLine(tt);
            }
            // 3. Type.GetType()
            if (true)
            {
                //Type tt = Type.GetType(Human);
                //Console.WriteLine(tt);
            }
            // 4. 패턴매칭
            if (true)
            {
                OutScore(88);
                OutScore(null);
                OutScore("결석");
                OutScore(100);
                OutScore(-20);
                OutScore(new DateTime(2020,4,15));
                OutScore(77);
                ArrayList ar = new ArrayList();
                ar.Add(70);
                ar.Add(80);
                ar.Add(90);
                OutScore(ar);
            }
        }
    }
}

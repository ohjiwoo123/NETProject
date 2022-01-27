using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Dynamic
/// - object : compile 시간 형식검사/ 원본특성 유지 못함
/// - var : compile 시간 형식검사/ 원본특성 유지
/// - dynamic : compile 시간 형식검사/ 원본특성 유지


/// </summary>
namespace NETProject
{
    internal class _03_dynamic
    {
        static void Main(string[] args)
        {
            // Data Type
            if (false)
            {
                object x = 30;
                var y = "aaa";
                dynamic z = 30;

                Console.WriteLine(x);
                Console.WriteLine(y);
                Console.WriteLine(z);
            }
            // 타입 추론
            if (false)
            {
                // var a; // error
                // var e = null; // error
                var b = 10;
                // b = 3.14; // error
                var c = 3.14;
                var d = "대한민국";

                Console.WriteLine(b);
                Console.WriteLine(c);
                Console.WriteLine(d);
            }
            // 암묵적 타입의 활용
            if (false)
            {
                // (1) 제너릭의 타입명
                List<NETProject._03_dynamic> ar = new List<NETProject._03_dynamic>(10);
                var ar2 = new List<NETProject._03_dynamic>(10);

                // (2) foreach 문
                int[] ar3 = { 1, 2, 3, 4, 5 };
                // var ar3 = new int[] { 1, 2, 3, 4, 5 };
                foreach (var x in ar3)
                {
                    Console.WriteLine(x);
                }
            }
            // Dynamic 동적 타입
            if (true)
            {
                dynamic a;
                a = 10;
                Console.WriteLine(a);

                a = 3.14;
                Console.WriteLine(a);

                a = "대한민국";
                Console.WriteLine(a);
            }
        }
    }
}

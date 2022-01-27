using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 람다 표현식 (Lamda Expression) = 이름이 없는 함수 
/// 
/// : 코드를 메서드 없이 인라인으로 작성하는 방법 (코드의 간결화 목적)
/// : (익명의 메서드와 유사하나 기능적으로 우위에 있음, 3가지로 정리 됨.
/// : 문법 : (인수) => 표현식 또는 명령문
///     예) a => a + 1; // a가 a+1 이 된다. (return은 생략 됨)
/// </summary>

namespace NETProject {

    delegate int MyDelegate0();
    delegate int MyDelegate(int a);
    delegate int MyDelegate2(int a, int b);
    delegate int MyDelegate3(int a, int b);
    delegate void Function();

    internal class _02_Lamda
    {
        static public int AddOne(int a)
        {
            return a+1;
        }
        static void Main(string[] args)
        {
            if (false)
            {
                // 1. 함수를 이름으로 호출 
                int k = AddOne(3); // 일반 메서드
                Console.WriteLine("k = " + k);

                // 2. 익명의 함수 
                MyDelegate d = AddOne;
                d(3);
                Console.WriteLine(d(1));

                MyDelegate f = delegate (int a) { return a + 1; };
                Console.WriteLine(f(100));

                Func<int, int> op = delegate (int a) { return a + 1; };
                Console.WriteLine(op(5));

                // 3. 람다식   C# => , C++ [] 라고 함.
                MyDelegate dd = a => a + 1;
                Console.WriteLine(dd(50));
            }
            // 여러가지 람다식
            if (false)
            {
                // 1. 인수를 여러개 받는 람다식
                // 2. 인수가 두 개 이상이면 ()괄호로 감싼다
                MyDelegate dd = a => a + 1;
                Console.WriteLine(dd(50));
                MyDelegate2 aa = (a, b) => a + b;
                Console.WriteLine(aa(3, 30));

                // 인수가 없으면 빈 () 괄호를 적는다.
                MyDelegate0 ddd = () => 10;
                Console.WriteLine(ddd());

                //  바디가 여러 개인 경우
            }
            // if문 붙은 lamda 식, 삼항연산자 이용한 lamda 식
            if (true)   
            {
                // 좌측 () => 우측 {} 
                MyDelegate3 dd = (a, b) => { if (a > b) { return a; } else { return b;}};
                MyDelegate3 ff = (a,b) => a>b ? a:b;
                Console.WriteLine(dd(2, 4));
                Console.WriteLine(ff(7, 2));
            }
        }
    }
}

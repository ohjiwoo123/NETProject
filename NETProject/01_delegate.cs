using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Delegate (대리자)
/// - 메소드를 가르키는 참조형 (객체를 만드는 Type)
/// - C++ 함수 포인터에 대응하는 개념 (객체지향적)
/// - 대리자 : 메소드를 대신 호출한다는 의미(가르킬 대상을 바꿔가며 호출 가능)
/// 
/// ex) CreateThread (3번째 인자 LPTHREAD_START_ROUTINE lpStartAddress) 
/// ex) deletate int IntOp (int a, int b);
/// 정의로 이동하면 typedef DWORD (WINAPI *PTHREAD_START_ROUTINE)(LPVOID lpThreadParameter);
/// 함수를 가르키는 변수, 이미 써봤다.
/// 
/// 
/// </summary>

namespace NETProject
{
    // delegate 
    delegate void MyDelegate(int a);
    // delegates 
    delegate int MyDelegates(string s);
    delegate double MyDelegates1(int i, long l);
    delegate void MyDelegates2(char ch);

    delegate int IntOp(int a, int b);


    internal class Program
    {
        // delegate 
        public static void Method1(int a)
        {
            Console.WriteLine("Method1 " + a);
        }
        public static void Method2(int a)
        {
            Console.WriteLine("Method2 " + a);
        }

        // delegates 
        public static int MyString(string s)
        {
            Console.WriteLine("Method2 " + s);
            return 0;
        }
        public static double MyNumber(int i, long l)
        {
            Console.WriteLine(i);
            return 1.0;
        }
        public static void MyChar(char ch)
        {
            Console.WriteLine(ch);
        }

        public static int Add(int a, int b)
        {
            Console.WriteLine("Add");
            return a + b;
        }

        public static int Sub(int a, int b)
        {
            Console.WriteLine("Sub");
            return a - b;
        }
        public static int Mul(int a, int b)
        {
            Console.WriteLine("Mul");
            return a * b;
        }
        static void Main(string[] args)
        {
            // delegate : 하나의 대리자 
            if (false)
            {
                Method1(10);
                Method2(20);

                MyDelegate d;
                d = Method1;
                d(30);

                d = Method2;
                d(40);
            }
            // delegates : 여러가지 형태의 대리자 만들기
            if (false)
            {
                MyDelegates da = MyString;
                MyDelegates1 db = MyNumber;
                MyDelegates2 dc = MyChar;
                da("a 메서드");
                db(20, 2);
                dc('델');
                Console.WriteLine("----------------------");
            }
            // SwitchMethod : 여러 개의 메소드를 정의하고, 사용자의 선택에 따라 호출함
            if (false)
            {
                int a = 3, b = 5;
                int ret =0;
                Console.Write("3, 5의 어떤 연산을 하고 싶습니까? (1:덧셈, 2:곱셈)\n");
                int o = Convert.ToInt32(Console.ReadLine());

                switch (o)
                {
                    case 1:
                        ret = Add(a, b);
                        //Console.WriteLine(ret);
                        break;
                    case 2:
                        ret = Mul(a, b);
                        //Console.WriteLine(ret);
                        break;
                }
                Console.WriteLine($"결과는{ret}입니다.");
            }
            // delegate : 배열로 활용하기 
            if (false)
            {
                int a = 3, b = 5;
                Console.Write("3, 5의 어떤 연산을 하고 싶습니까? (1:덧셈, 2:곱셈 3. 뺄셈)\n");
                int o = Convert.ToInt32(Console.ReadLine());

                //IntOp op;
                //if (o==1) op = Add; else op = Mul;
                //int ret = op(a, b);

                IntOp[] arOp = {null, Add, Mul, Sub};
                int ret = arOp[o](a,b);
                Console.WriteLine($"결과는{ret}입니다.");
            }
            // MultiCast
            if (false)
            {
                IntOp op;
                op = Add;
                Console.WriteLine(op(10, 30));
                op = op + Sub;  // op += Sub;
                Console.WriteLine(op(10, 30));
                op = op + Mul;  // op += Mul;
                Console.WriteLine(op(10, 30));
            }
            // 제너릭 델리게이트 Generic Delegate
            // 템플릿의 delegate
            if (false)
            {
                // 1. 리턴이 없는 델리 게이트
                // delegate void MyDelegates2(char ch);
                //MyDelegates2 voidp;

                // public delegate void Action();
                // public delegate void Action<T>(T obj);
                // public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);
                // Action은 최대 인자 17개 까지 받아준다. 
                Action<char>voidp = MyChar; // return이 없는 generic = Action 
                voidp('a');

                // 2. 리턴이 있는 델리 게이트
                // delegate int IntOp(int a, int b);
                // IntOp op;

                // 맨 마지막 인자에 return type까지 적어준다.
                // Func도 17종류 범용적 사용이 가능하다. 
                Func<int,int,int> op = Add;
                Console.WriteLine(op(10, 30));

                Func<string, int> p1 = MyString;
                Func<int, long, double> p2 = MyNumber;
                p1("b");    // MyString 함수 실행
                p2(2, 2);   // MyNumber 함수 실행 
            }
            // 익명의 메소드 (Anonymous  Method)
            // 1회성이고 짧을 때 사용 
            if (false)
            {
                int ret = 0;
                int ret2 = 0;
                IntOp op = delegate (int a, int b) { if (b != 0) return a / b; else return 0; };
                Func<int,int,int> op2 = delegate (int a, int b) { if (b != 0) return a / b; else return 0; };
                //IntOp opp = Div;
                ret = op(6, 3);
                ret2 = op2(9, 3);
                Console.WriteLine($"나누기의 결과는{ret} 입니다.");
                Console.WriteLine($"나누기의 결과는{ret2} 입니다.");
            }
        }
    }
}

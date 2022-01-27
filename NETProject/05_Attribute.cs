#define WARNING // [Conditional("WARNING")] 에 부합하는 조건 
#define JAVA    // [Conditional("JAVA")] 에 부합하는 조건 
#define CSHARP  // [Conditional("CSHARP")] 에 부합하는 조건 

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Attribute
/// : 컴파일러에게 코드에 대한 부가정보를 제공하는 기능
/// vs 주석문) 사람이 쓰고, 사람이 읽는 정보
/// 애트리뷰트) 사람이 쓰고, 컴파일러가 읽는 정보 
/// 문법 : [ 애트리뷰트_이름 (애트리뷰트_매개변수) ]
/// </summary>
namespace NETProject
{
    internal class _05_Attribute
    {
        [DllImport("User32.dll")]
        public static extern int MessageBox(int hParent, string Message, string a, int d);
        [DllImport("Kernel32.dll")]
        public static extern int WinExec(string Path, int a);

        [Conditional("WARNING")]
        public static void WarningMessage()
        {
            Console.WriteLine("이 제품은 30일 동안만 사용할 수 있습니다.");
            Console.WriteLine("정품을 구입하시려면 일로와서 사세요.");
        }

        [Conditional("CSHARP")]
        public static void CSharpMethod()
        {
            Console.WriteLine("call CSharpMethod");
        }
        [Conditional("JAVA")]
        public static void JavaMethod()
        {
            Console.WriteLine("call JavaMethod");
        }

        [Obsolete("경고 : 업데이트 이전에 만들어진 함수 입니다. 새로나온 함수를 사용하세요")]
        //[Obsolete("경고 : 사용금지 함수입니다.", true)] // 경고 뿐만 아니라 빌드가 안되게 막음
        public static void OldMethod()
        {
            Console.WriteLine("call JavaMethod");
        }

        [Conditional("JAVA")]
        public static void NewMethod()
        {
            Console.WriteLine("call JavaMethod");
        }

        static void Main(string[] args)
        {
            // [Conditional]
            if (false)
            {
                WarningMessage();
                CSharpMethod();
                JavaMethod();

                Console.WriteLine("게임을 시작합니다");
                Console.WriteLine("-------------------");
            }
            // [Obsolote] 구식 경고
            if (false)
            {
                OldMethod();
                NewMethod();
            }
            // dll 라이브러리 
            if (true)
            {
                WinExec("notepad.exe", 1);
                MessageBox(0, "메모장을 실행합니다.", "알림", 0);
            }
        }
    }
}

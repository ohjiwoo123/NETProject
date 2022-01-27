# NETProject (Delegate 대리자)

1 delegate = 데이터타입이다.  
2 Delegate (대리자)  
3 메소드를 가르키는 참조형 (객체를 만드는 Type)  
4 C++ 함수 포인터에 대응하는 개념 (객체지향적)  
5 대리자 : 메소드를 대신 호출한다는 의미(가르킬 대상을 바꿔가며 호출 가능)  
ex) CreateThread (3번째 인자 LPTHREAD_START_ROUTINE lpStartAddress)  
ex) deletate int IntOp (int a, int b);  
6 정의로 이동하면 typedef DWORD (WINAPI *PTHREAD_START_ROUTINE)(LPVOID lpThreadParameter);  
함수를 가르키는 변수, 이미 써봤다.  

아주 간단한 예시 ex)  
```
namespace
{
   delegate void MyDelegate(int a); // 대리자 
  internal class
  {
        public static void Method1(int a)
        {
            Console.WriteLine("Method1 " + a);
        }
        public static void Method2(int a)
        {
            Console.WriteLine("Method2 " + a);
        }
    static void Main(string[], args)
    {
        Method1(10);
        Method2(20);

        MyDelegate d;   // d 인스턴스 생성 
        d = Method1;  // d 에 method1 함수 대입
        d(30);    // "Method1 + 30" 콘솔에 출력

        d = Method2;
        d(40);  // "Method2 + 40" 콘솔에 출력 
    }
  }
}
```

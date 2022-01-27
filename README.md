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

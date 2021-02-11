using System;

namespace StructOOP
{
    // 객체 OOP (Object Oriented Programming)
    // Knight
    // 속성 : hp, attack, position
    // 기능 : Move, Attacking, Die

    // Knight 객체의 설계도. 붕어빵 틀!

    // 비슷한 모양으로 struct 가 있다.
    // class 로 선언한 것과 struct 로 선언한 것의 차이는?
    // class = Ref -> 참조로 사용(원본 값 사용)
    // struct = 값 복사.

    // new 문법은 struct에서 생략을 해도 된다. -> 그래도 값 복사이기 때문에. 복사본으로 연산한다. 

    class Player // 부모 클래스 혹은 기반 클래스
    {
        // static 정적 키워드 _ 오로지 1개만 존재!
        static public int playerTotalCount = 1;

        public int hp;
        public int attack;
        public int playerId;

        public Player()
        {
            Console.WriteLine("Player 생성자 호출!");
        }

        public Player(int hp)
        {
            this.hp = hp;
            Console.WriteLine("Player hp 생성자 호출!");
        }
    }

    class Mage : Player // 자식 클래스 혹은 파생 클래스
    {

    }

    class Archer : Player
    {

    }

    class Knight : Player
    {
        int c;

        // base 키워드 사용
        // 어떤 생성자를 호출할지 고르기 가능.
       public Knight() : base (100)
       {
            this.c = 10;    // 내(Knight)의 c
            base.hp = 1029; // 부모님의 hp
            Console.WriteLine("Knight hp 생성자 호출");
       }

        // 부모 생성자를 먼저 실행 하고 ( 공통적인 기능을 부모 클래스에 넣는다 )
        // 자식 생성자를 다음으로 실행한다. 강처럼 위에서 아래로 흐름

        // base 키워드 사용
        // base를 붙여서 실행하면, 어떤 생성자를 호출할지 골라서 호출할 수 있음.
        // base - 부모 클래스의 생성자에 접근

        // 깊은 복사
        // Clone 함수를 호출하면 새로운 객체를 생성한 다음, 리턴값을 새로 생성한 객체를 반환하여 돌려준다.

        // 진퉁도, 짝퉁도 아니고 새로운 객체를 생성하는 함수.
        public Knight Clone()
        {
            Knight knightClone = new Knight();

            knightClone.hp = hp;
            knightClone.attack = attack;

            return knightClone; 
        }

        // 생성자!!!
        public Knight()
        {
            // 생성을 하면서 그 인자를 자동적으로 채워줌.
            hp = 100;
            attack = 20;
            Console.WriteLine("Knight 생성자 호출 !!!");
        }

        public Knight(int hp, int attack)
        {
            // this =  내 hp 로 세팅을 해주세요.
            this.hp = hp;
            Console.WriteLine("int 생성자 호출!");
        }

        // : this() -> 생성자가 호출이 되는데, 내 사진의 빈 생성자를 호출 시켜줘! 라는 뜻.
        // 빈 생성자를 제일 먼저 채워주고, 해당 : this()를 쓴 호출 함수를 실행시킨다.

        public Knight(int hp) : this()
        {
            this.hp = hp;
            Console.WriteLine("This를 통해 이전 기본 생성자 호출!");
        }

        // static 함수.
        static public Knight CreateKnight()
        {
            // PlayertotalCount 는 이 class 내에서만 작동하는 것. 
            playerTotalCount++;

            Knight knight = new Knight();
            knight.playerId = playerTotalCount;
            knight.hp = 50;
            knight.attack = 50;

            return knight;
        }

        public void Move()
        {
            Console.WriteLine("Knight 가 움직입니다");
        }

        public void Attack()
        {
            Console.WriteLine("Knight 가 공격합니다");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Mage mage;
            Knight knight = new Knight();

            knight.hp = 100;
            knight.attack = 10;

            knight.Attack();
            knight.Move();

            // new 로 새로 생성해주지 않으면 값 복사이므로 같은 객체를 생성한 꼴이 된다.
            // 매번 new를 통해 대입을 하는 것이 맘에 들지 않으면
            // Deep Copy ( 깊은 복사) 라는 것을 사용하면 된다.
            // 별도의 객체를 만들어서 이 값만 똑같이 넣어주면 되는 것.

            // knight와 knight2는 완전하게 서로 분리된 객체로 볼 수 있다.
            Knight knight2 = knight.Clone();
            knight2.hp = 0;
            knight2.attack = 100;

            // Stack은 함수를 실행하기 위한 메모장 같은 영역
            // 함수 안에 선언되는 변수들은 스택 영역 안에 들어가게 된다.
            // 값복사하는 객체는 메모리 안에 본체가 들어가고, 참조형 객체는 메모리 안에 주소가 들어간다.
            // 주소가 들어가는 부분엔 어떤게 들어가나 ? -> 실제 본체가 들어있는 메모리의 '주소'를 나타낸다.

            // 참조 타입의 실제 객체는 어디있는가? = > 힙(Heap) 영역에 들어있음. 
            // 힙(Heap)영역이란, 동적으로 들어간 것이 들어가는 곳. 새로 메모리 할당을 실시간으로 요구함.
            // 이 메모리가 힙(Heap)영역에 할당되는 것이다.
            // Clone 함수를 통해 또 new 를 하여 할당하게 되면, 새로운 객체가 heap영역 안에 할당되게 된다.
            // 이를 깊은 복사(Deep Copy)라고 한다.

            // 주의!
            // 같은 주소를 가리키면 하나의 본체를 같이 공유하는 꼴이 됨.
           
            // stack 영역은 함수 호출 및 반환 할때 알아서 잘 줄었다가 늘어났다가 관리가 자동적으로 됨.
            // 그러나 heap 영역은 메모리 할당을 했으면 반드시 해제 시켜줘야 한다. -cpp의 경우, 프로그래머가 직접 해제 시켜줘야한다. (메모리 누수)

            // 본체가 들어 있는 것이 아니라 주소로 동작 하는 경우, 
            // 본체가 꼭 heap 영역에만 들어 있는 것이 아니라, Stack 영역 안에도 들어 있을 수도 있음.
            // 참조값으로 넘어줄 때, 같은 Stack 영역에 있는 본체를 넘겨주기도 함. (꼭 원본 값이 heap에 있다는 오해는 금지!)
            // main에서 먼저 stack에 선언한 원본값 - > 그 원본값의 주소를 참조하여 객체를 생성하면...? , stack에 있는 원본 값 사용하는 꼴
        }

        static void 생성자()
        {
            // 생성자 설명. Knight 의 기본 생성자 호출을 할 때도 있지만,
            // 각 인자에 값을 넣어준 상태로 생성을 해야 할 때도 있다.

            // 함수 뒤에 : this()를 붙이는  좋은 방법도 꼭 기억해둘것!
            Knight knight = new Knight(10, 200);
        }

        // Static 설명
        static void Static()
        {
            // Static은 오직 단 한개만 존재하는 변수를 구현할 때만 사용한다.
            // 한 변수를 통해 계속 모든 프로그램 내에서 써야할 때 사용한다.
            // 정적 필드 이니셜라이저에는 this 키워드를 사용할 수 없다.

            // static 정적 키워드!!!
            // 붕어빵이 아닌, 붕어빵 틀에 종속적인 필드(함수)가 되는 것이고
            // static이 아니면 인스턴스(객체) 자체에 종속적인 함수가 된다.

            // 오해하면 안되는 부분!
            // static 키워드라고 해서, 일반 인스턴스에 접근을 할 수없다는 의미는 아니다.
            // new를 통해 sample 객체를 만든 다음 , 그 객체를 이용해 객체의 인자에 접근 가능하다.

            // static이 아니면 sample 인스턴스(객체)를 먼저 생성한 다음에
            // 그 객체를 통해 접근, 혹은 호출하는 것이 맞고,

            // static 함수면 그 틀에서 접근이 바로 가능하기 때문에 Knight.Move()와 같은

            // static 함수 예시
            Knight.CreateKnight();

            // 이런식으로 Knight라는 클래스에서 바로 접근이 가능한 함수.
            // 샘플 객체를 만들어서 접근하지 않아도 된다.
        }

        static void 상속성()
        {
            // 객체지향의 3대장 중 하나
            // 은닉성 / 상속성 / 다형성


            // 접근 한정자 
            // public protected private 
            // int hp 처럼 접근 한정자를 명시하지 않으면 자동으로 private 으로 설정된다.

            // public 은 내부 외부 모두 접근이 가능한 한정자
            // protected 는 상속 관계에서 자식과 나 자신만이 접근 가능한 한정자
            // private 은 자식도 접근 못하고 오직 나(클래스) 에서만 접근이 가능한 한정자.

            // private의 경우, Get, Set 함수를 이용하여 접근이 가능한 통로를 열어준다.
            // 왜? 그 즉슨, 디버깅의 경우 해당 인자에 접근한 호출 스택을 찾기 용이하기 때문에.
        }

        static void 클래스_형식_변환()
        {
            // 공통적으로 플레이어 타입을 상속받으면 Player Type의 인자를 받아서 EnterGame의 함수를 실행할 수 있다.

            // 명시적 형 변환
            // 강제 형 변환

            // 강제 형 변환 : 앞에 괄호 (Clss) 를 붙여주어 해당 class형으로 강제로 변환 시킨다. 
            // 최대한 자제 해야한다. 문법 상으론 아무 문제없을 경우엔 나중에 문제가 되던 말던 그냥 진행됨

            // 강제 형 변환 때 조건 거는 법!!!
            // is / as 문법을 쓴다!
            object obj;

            // is, as를 이용하여 크로스 체크를 해야한다.

            //(1) is = bool 값 반환한다. 해당 오브젝트가 맞냐~~하는 질문
            // bool isMage = (obj is Mage);

            //(2) as = 형변환까지 해서 넘겨주는 것
            // Mage mage = (obj as Mage);
            // if(null != mage)

            // 주로 as를 쓴다.
        }

        static void 다형성()
        {
            // 최상위 클래스의 Move와 
            // 파생 클래스의 Move를 달리 해야 할 때는 new 를 쓴다.
            // public new void Move();
            // 새로운 Move 함수를 만들어서 최상위 클래스의 Move를 가리겠다, 라는 뜻으로 쓰인다.

            // 하지만 위와 같은 방법은 비효율적이므로, 다형성을 사용한다.
            // 가상함수를 만든다. public virtual void Move()를 써준다.
            // 파생 클래스에는 public override void Move()

            // 중요!!!!
            // virtual - override 키워드를 사용했을 때 런타임에 인스턴스의 타입을 체크해서, 그 타입에 맞는 버전의 함수를 호출한다!!!!
            // 파생클래스의 조상 중 한명이 virutal 키워드를 쓴 함수를 써야만 override 를 사용 할 수 있다.

            // base.Move()를 사용하면, 바로 위 부모가 가진 버전의 함수를 실행 한 다음에, 자신의 버전의 함수를 사용하게 할 수 있다.
            // 부모클래스의 기능을 사용하지만, 해당 파생 클래스의 기능을 추가적으로 쓰고 싶을 때 자주 쓰인다.

            // c# 에서만 있는 기능
            // sealed 키워드 : 해당 키워드의 파생 클래스들은 override 를 사용할 수 없게 한다.(부모 클래스의 기능만 사용할수 있도록 제한함)

            // virtual은 일반 함수보다는 성능에 부하를 주기 때문에 모든 함수를 virtual로 쓰기보단, 필요한 클래스에만 사용하는 것이 이득~~

        }
 
    }
}

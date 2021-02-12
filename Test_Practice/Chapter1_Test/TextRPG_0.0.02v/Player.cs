using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG_0._0._02v
{
    public enum PLAYERTYPE
    {
        NONE = 0,
        KNIGHT,
        MAGE,
        ARCHER,
    }

    // Creature 타입을 상속받는 Player
    class Player : Creature
    {
        // 초기화
        protected int hp = 0;
        protected int attack = 0;
        protected PLAYERTYPE playerType = PLAYERTYPE.NONE;

        // 생성자.
        // 생성자는 클래스 이름과 같으며 반환값이 없다.
        // 생성자를 공개하는 것보단, protected로 보호하는 것이 좋다.

        // 생성할 때 플레이어 타입을 꼭 받도록 한다.
        // 인자를 받도록만드는 순간, 인자 없는 버전은 사용할 수 없다.
       
        // protected로 설정을 해서 외부에서 Player 생성에 함부로 접근할 수 없도록 한다.
        // 접근하기 위해서는 Player player = new Knight(); 라고 자식을 통해 접근해야한다.
        protected Player(PLAYERTYPE playerType) : base(CREATURE_TYPE.PLAYER)
        {
            this.playerType = playerType;
        }

        public PLAYERTYPE GetPlayerType() { return this.playerType; }
    }

    class Knight : Player
    {
        public Knight() : base(PLAYERTYPE.KNIGHT)
        {
            SetInfo(100, 10);
        }
    }

    class Mage : Player
    {
        public Mage() : base(PLAYERTYPE.MAGE)
        {
            SetInfo(80, 15);
        }
    }

    class Archer : Player
    {
        public Archer() : base(PLAYERTYPE.ARCHER)
        {
            SetInfo(90, 13);
        }
    }
}

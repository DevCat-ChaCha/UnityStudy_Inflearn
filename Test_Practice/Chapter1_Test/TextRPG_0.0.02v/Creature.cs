using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG_0._0._02v
{
    public enum CREATURE_TYPE
    {
        NONE,
        PLAYER,
        MONSTER,
    }

    class Creature
    {
        // 초기화
        protected int hp = 0;
        protected int attack = 0;
        protected double speed = 1.0;
        protected CREATURE_TYPE creatureType = CREATURE_TYPE.NONE;

        protected Creature(CREATURE_TYPE creatureType)
        {
            this.creatureType = creatureType;
        }

        public void SetInfo(int hp, int attack, double speed = 1.0)
        {
            this.hp = hp;
            this.attack = attack;
            this.speed = speed;
        }

        public CREATURE_TYPE GetCreatureType() { return this.creatureType; }
        public int GetHp()  { return this.hp; }
        public int GetAttack()  { return this.attack; }

        public double GetAttackSpeed() { return this.speed; }
        public bool IsDead() 
        {
            return this.hp <= 0; 
        }
        public void OnDamaged(int damage)
        {
            Console.WriteLine(damage +" 데미지 받음! ");
            this.hp -= damage;
            if (this.hp < 0)
            {
                Console.WriteLine("죽었습니다..");
                this.hp = 0;
            }
        }
    }
}

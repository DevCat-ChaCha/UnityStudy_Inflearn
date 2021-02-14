using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG_0._0._02v
{
    public enum GAMEMODE
    {
        NONE,
        LOBBY,  // 로비
        TOWN,   // 마을
        FIELD,  // 필드(전투)
    }

    // 게임 진행의 전반적인 내용을 정하는 부분
    class Game
    {   
        // 초기값 설정
        private GAMEMODE gameMode = GAMEMODE.LOBBY;
        private Player player = null;
        private Monster monster = null;
        private Random rand = new Random();

        public void Process()
        {
            switch (gameMode)
            {
                case GAMEMODE.LOBBY:
                    ProcessLobby();
                    break;
                case GAMEMODE.TOWN:
                    ProcessTown();
                    break;
                case GAMEMODE.FIELD:
                    ProcessField();
                    break;
                default:
                    break;
            }
        }

        private void ProcessLobby()
        {
            Console.WriteLine("로비에 진입했습니다.");
            Console.WriteLine(">> 직업을 선택하세요 <<");
            Console.WriteLine("[1] 기사 [2] 마법사 [3] 궁수");

            string input = Console.ReadLine();
            int value = 0;
            int.TryParse(input, out value);

            switch(value)
            {
                case 1:
                    {
                        player = new Knight();
                        Console.WriteLine("기사 선택");
                    }
                    break;
                case 2:
                    {
                        player = new Mage();
                        Console.WriteLine("법사 선택");
                    }
                    break;
                case 3:
                    {
                        player = new Archer();
                        Console.WriteLine("궁수 선택");
                    }
                    break;
            }
            // gameMode를 바꿔준다.
            if(null != player)
                gameMode = GAMEMODE.TOWN;
        }

        private void ProcessTown()
        {
            Console.WriteLine("마을에 입장했습니다");
            Console.WriteLine("[1] 필드 입장! [2] 로비로 돌아가기");

            string input = Console.ReadLine();
            int value = 0;
            int.TryParse(input, out value);
            switch(value)
            {
                case 1:
                    {
                        gameMode = GAMEMODE.FIELD;
                    }
                    break;
                case 2:
                    {
                        gameMode = GAMEMODE.LOBBY;
                    }
                    break;
            }
        }

        private void ProcessField()
        {
            Console.WriteLine("필드에 도달했습니다!");
            // 랜덤으로 몬스터를 만나게 함.
            // 몬스터를 만나면 선택지 두가지 출력
            CreateMonster();

            Console.WriteLine("[1] 전투하기 [2] 일정확률로 필드에서 도망치기");
            string input = Console.ReadLine();
            int number = 0;
            int.TryParse(input, out number);

            switch(number)
            {
                case 1:
                    ProcessFight();
                    break;
                case 2:
                    {
                        if (TryEscape() == true)
                        {
                            Console.WriteLine("도망치는 데 성공했습니다^_________^!!");
                            gameMode = GAMEMODE.TOWN;
                        }
                        else
                            ProcessFight();
                    }
                    break;
                default:
                    break;
            }
        }

        private void ProcessFight()
        {
            Console.WriteLine("전투가 시작되었습니다!!");
            var monsterHp = monster.GetHp();
            var playerHp = player.GetHp();

            DateTime player_timeValue = DateTime.Now;
            DateTime monster_timeValue = DateTime.Now;

            while (true)
            {
                if (DateTime.Now > player_timeValue.AddSeconds(1/player.GetAttackSpeed()))
                {
                    // 플레이어 턴
                    monster.OnDamaged(player.GetAttack());
                    Console.WriteLine("플레이어의 공격력 : " + player.GetAttack());
                    Console.WriteLine("몬스터의 남은 체력 : " + monster.GetHp());
                    if (monster.IsDead() == true)
                    {
                        Console.WriteLine("승리!");
                        ReturnTown();
                        break;
                    }
                    player_timeValue= DateTime.Now;
                }

                if (DateTime.Now > monster_timeValue.AddSeconds(1 / monster.GetAttackSpeed()))
                {
                    // 몬스터 턴
                    playerHp -= monster.GetAttack();
                    Console.WriteLine("몬스터의 공격력 : " + monster.GetAttack());
                    Console.WriteLine("플레이어의 남은 체력 : " + playerHp);
                    if (playerHp <= 0)
                    {
                        Console.WriteLine("플레이어 사망!");
                        ReturnTown();
                        break;
                    }
                    monster_timeValue = DateTime.Now;
                }
            }
        }

        private void ReturnTown()
        {
            Console.WriteLine("마을로 돌아갑니다..");
            gameMode = GAMEMODE.TOWN;
        }

        private bool TryEscape()
        {
            int value = rand.Next(0, 101);
            if(value <= 33)
            {
                return true;
            }
            return false;
        }

        private void CreateMonster()
        {
            int value = rand.Next(0, 3);
            switch(value)
            {
                case 0:
                    {
                        monster = new Slime();
                    }
                    break;
                case 1:
                    {
                        monster = new Skeleton();
                    }
                    break;
                case 2:
                    {
                        monster = new Orc();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

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
            Console.WriteLine();
        }
    }
}

using System;

namespace TextRPG_0._0._02v
{
    class TextRPG
    {
        static void Main(string[] args)
        {
            //// Knight로 생성하는 Player
            //Player player = new Knight();
            //Player player2 = new Mage();

            //var attack = player.GetAttack();
            //player2.OnDamaged(attack);
 
            Game gameScene = new Game();

            while (true)
            {
                gameScene.Process();
            }
        }
    }
}

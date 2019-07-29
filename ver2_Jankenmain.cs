using Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    class Jankenmain
    {
        enum JankenHand
        {
        rock = 1,
        paper,
        scissors
        }

        static void Main()
        {

            int shiftNumber = 1;

            int allRock = 2;
            int allPaper = 4;
            int allScissors  = 8;
            int allHand = 14;
            int winRock = 10;
            int winPaper = 6;
            int winScissors = 12;

            string player = "Player";
            string npcPlayer = "NPCPlayer";

            Console.Write("何回勝負?");
            int battleCount = int.Parse(Console.ReadLine());

            Console.Write("プレイヤーは何人?");
            int playerCount = int.Parse(Console.ReadLine()); 
            int[] playerHandArray = new int[playerCount];
            int[] playerWinRateArray = new int[playerCount];

            Console.Write("コンピューターは何人?");
            int npcCount = int.Parse(Console.ReadLine());
            int[] computerHandArray = new int[npcCount];
            int[] computerWinRateArray = new int[npcCount];

            JankenArray.MakeJankenArray pmakeArray = new JankenArray.MakeJankenArray();
            JankenArray.MakeJankenArray cmakeArray = new JankenArray.MakeJankenArray();


            for (int i = 0; i < battleCount; i++)
            {    
            jankenIsDraw:
                int k = 0;
                playerHandArray = pmakeArray.PhandDetermin(playerHandArray);

                for (int p = 0; p < playerHandArray.Length; p++)
                {
                    k |= shiftNumber << playerHandArray[p];
                }

                computerHandArray = cmakeArray.CPhandDetermin(computerHandArray);
                for (int q = 0; q < computerHandArray.Length; q++)
                {
                        k |= shiftNumber << computerHandArray[q];
                }

                if (k == allHand || k == allScissors || k == allPaper || k == allRock)
                {
                    Console.WriteLine("DRAW");
                    goto jankenIsDraw;
                }

                if (k == winScissors)
                {
                    Console.WriteLine("WIN:{0}({1})",JankenHand.scissors, (int)JankenHand.scissors);
                    playerWinRateArray = pmakeArray.Winner(playerHandArray, playerWinRateArray, (int)JankenHand.scissors, player);
                    computerWinRateArray = cmakeArray.Winner(computerHandArray, computerWinRateArray, (int)JankenHand.scissors, npcPlayer);
                }

                if (k == winRock)
                {
                    Console.WriteLine("WIN:{0}({1})", JankenHand.rock, (int)JankenHand.rock);
                    playerWinRateArray = pmakeArray.Winner(playerHandArray, playerWinRateArray, (int)JankenHand.scissors, player);
                    computerWinRateArray = cmakeArray.Winner(computerHandArray, computerWinRateArray, (int)JankenHand.scissors, npcPlayer);
                }

                if (k == winPaper)
                {
                    Console.WriteLine("WIN:{0}({1})", JankenHand.paper, (int)JankenHand.paper);
                    playerWinRateArray = pmakeArray.Winner(playerHandArray, playerWinRateArray, (int)JankenHand.paper, player);
                    computerWinRateArray = cmakeArray.Winner(computerHandArray, computerWinRateArray, (int)JankenHand.paper, npcPlayer);
                }
            }

            for (int i = 0; i < playerWinRateArray.Length; i++)
            {
                Console.WriteLine(player + (i + 1) + ":" + playerWinRateArray[i] + ",");
            }

            for (int i = 0; i < computerWinRateArray.Length; i++)
            {
                Console.WriteLine(npcPlayer + (i + 1) + ":" + computerWinRateArray[i] + ",");
            }
        }
    }
}

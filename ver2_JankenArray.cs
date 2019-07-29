using Janken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JankenArray
{
    public class MakeJankenArray
    {
        Players.Player phand = new Players.Player();
        Players.NPCPlayer npchand = new Players.NPCPlayer();
        public int[] PhandDetermin(int[] phandArray)
        {
            for (int i = 0; i < phandArray.Length; i++)
            {
                phandArray[i] = phand.JankenHand();
            }

            foreach  (int hand in phandArray)
            {
                Console.WriteLine("player hand is" + hand);
            }
            return phandArray;
        }

        public int[] CPhandDetermin(int[] npchandArray)
        {
            for (int j = 0; j < npchandArray.Length; j++)
            {
                npchandArray[j] = npchand.NPCJankenHand();
            }

            foreach  (int hand in npchandArray)
            {
                Console.WriteLine("npcplayer hand is" + hand);
            }
            return npchandArray;
        }

        public int[] Winner(int[] pArray, int[] pWinRateArray, int winnerHand, string player)
        {
            int winCount = 1;
            for (int i = 0; i < pArray.Length; i++)
            {
                if (pArray[i] == winnerHand)
                {
                    pWinRateArray[i] += winCount;
                    
                    Console.Write("WINNER:");
                    Console.WriteLine(player + (i + 1));
                }
            }
            Console.WriteLine("--------------------");
            Console.WriteLine();
            return pWinRateArray;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    public class Player
    {
        int rock = 1, scissors = 3;
        public int JankenHand()
        {
            string pHand;
            do
            {
                Console.Write("input a number");
                pHand = Console.ReadLine();
            } while (int.Parse(pHand) > scissors || int.Parse(pHand) < rock);
            return int.Parse(pHand);
        }
    }

    public class NPCPlayer
    {       
        int npcHand;
        Random handRandom = new Random();
        public int NPCJankenHand()
        {           
            npcHand = handRandom.Next(1, 4);
            return npcHand;
        }
    }
}

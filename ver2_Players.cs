using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// プレイヤーの手を決定するためのクラスをまとめた箇所
/// </summary>
namespace Players
{
    /// <summary>
    /// プレイヤーの手を決定する
    /// </summary>
    public class Player
    {
        int rock = 1, scissors = 3; // プレイヤーが手として選択できる最小値、最大値

        /// <summary>
        /// プレイヤーの手を1,2,3から選んで決定する
        /// </summary>
        /// <returns>プレイヤーの選択した手に対応する整数の値</returns>
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

    /// <summary>
    /// コンピューターの手を決定する
    /// </summary>
    public class NPCPlayer
    {       
        int npcHand;
        Random handRandom = new Random();   // 乱数生成のため

        /// <summary>
        /// コンピューターの手を1,2,3のいずれかから乱数で決定
        /// </summary>
        /// <returns>乱数で生成されたコンピューター手に対応する整数の値</returns>
        public int NPCJankenHand()
        {           
            npcHand = handRandom.Next(1, 4);
            return npcHand;
        }
    }
}

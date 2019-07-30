using System;

/// <summary>
/// プレイヤーの手を決定するためのクラスをまとめた箇所
/// </summary>
namespace Janken
{
    /// <summary>
    /// プレイヤーの手を決定する
    /// </summary>
    public class Player
    {
        /// <summary>
        /// プレイヤーの手を1,2,3から選んで決定する
        /// </summary>
        /// <returns>プレイヤーの選択した手に対応する整数の値</returns>
        public int JankenHand()
        {
            string pHand;
            do
            {
                Console.Write("input a number({0}:{1}, {2}:{3}, {4}:{5}>>)",Jankenmain.JankenHand.rock, (int)Jankenmain.JankenHand.rock, Jankenmain.JankenHand.paper, (int)Jankenmain.JankenHand.paper, Jankenmain.JankenHand.scissors, (int)Jankenmain.JankenHand.scissors);
                pHand = Console.ReadLine();
            } while (int.Parse(pHand) > (int)Jankenmain.JankenHand.scissors || int.Parse(pHand) < (int)Jankenmain.JankenHand.rock);
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

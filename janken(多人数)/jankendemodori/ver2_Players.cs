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
        public int SetJankenHand()
        {
            string pHand;
            do
            {
                Console.WriteLine();
                Console.Write("input a number({0}:{1}, {2}:{3}, {4}:{5})>>",nameof(JankenHand.rock).ToUpper(), (int)JankenHand.rock, nameof(JankenHand.paper).ToUpper(), (int)JankenHand.paper, nameof(JankenHand.scissors).ToUpper(), (int)JankenHand.scissors);
                pHand = Console.ReadLine();
            } while (int.Parse(pHand) < (int)JankenHand.rock || int.Parse(pHand) > (int)JankenHand.scissors);

            Console.WriteLine();
            Console.WriteLine("↓↓↓↓↓↓ALL HANDS↓↓↓↓↓↓");
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
        public int SetNPCJankenHand()
        {           
            npcHand = handRandom.Next(1, 4);
            return npcHand;
        }
    }
}

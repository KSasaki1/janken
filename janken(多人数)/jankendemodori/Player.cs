/// <summary>
/// プレイヤーの手を決定するためのクラスをまとめた箇所
/// </summary>
namespace Janken
{
    using System;

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
            int pHand;
            do
            {
                Console.WriteLine();
                Console.Write("input a number({0}:{1}, {2}:{3}, {4}:{5})>>", nameof(JankenHand.Rock), (int)JankenHand.Rock, nameof(JankenHand.Paper), (int)JankenHand.Paper, nameof(JankenHand.Scissors), (int)JankenHand.Scissors);
                pHand = GameMaster.TryInputValidNumber();
            }
            while (pHand < (int)JankenHand.Rock || pHand > (int)JankenHand.Scissors);

            Console.WriteLine();
            return pHand;
        }
    }

    /// <summary>
    /// コンピューターの手を決定する
    /// </summary>
    public class NPCPlayer
    {
        private int npcHand;
        private Random handRandom = new Random();   // 乱数生成のため

        /// <summary>
        /// コンピューターの手を1,2,3のいずれかから乱数で決定
        /// </summary>
        /// <returns>乱数で生成されたコンピューター手に対応する整数の値</returns>
        public int SetNPCJankenHand()
        {
            this.npcHand = this.handRandom.Next(1, 4);
            return this.npcHand;
        }
    }
}

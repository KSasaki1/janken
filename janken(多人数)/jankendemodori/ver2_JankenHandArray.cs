using System;

namespace Janken
{
    /// <summary>
    /// メインメソッドで作成された配列に対応する要素を格納していくメソッドを集めたクラス
    /// </summary>
    public class MakeJankenArray
    {
        Player phand = new Player();
        NPCPlayer npchand = new NPCPlayer();

        /// <summary>
        /// プレイヤーの手を配列へ格納していく
        /// </summary>
        /// <param name="phandArray">メインメソッドで作成したじゃんけんの手を格納するための空の配列</param>
        /// <returns>じゃんけんの手が格納され終わった配列</returns>
        public int[] PhandDetermin(int[] phandArray)
        {
            for (int i = 0; i < phandArray.Length; i++)
            {
                phandArray[i] = phand.JankenHand(); // プレイヤーの手を決定するメソッドを使用。
            }

            foreach  (int hand in phandArray)
            {
                Console.WriteLine("player hand is" + hand);
                Console.WriteLine();
            }
            return phandArray;
        }

        /// <summary>
        /// コンピューターの手を配列へ格納していく
        /// </summary>
        /// <param name="npchandArray">メインメソッドで作成したじゃんけんの手を格納するための空の配列</param>
        /// <returns>じゃんけんの手が格納され終わった配列</returns>
        public int[] CPhandDetermin(int[] npchandArray)
        {
            for (int j = 0; j < npchandArray.Length; j++)
            {
                npchandArray[j] = npchand.NPCJankenHand(); // コンピューターの手を決定するメソッドを使用
            }

            foreach  (int hand in npchandArray)
            {
                Console.WriteLine("npcplayer hand is" + hand);
                Console.WriteLine();
            }
            return npchandArray;
        }
    }
}

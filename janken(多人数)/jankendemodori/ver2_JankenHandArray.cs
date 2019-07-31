using System;

namespace Janken
{
    /// <summary>
    /// メインメソッドで作成された配列に対応する要素を格納していくメソッドを集めたクラス
    /// </summary>
    public class MakeHandArray
    {
        Player phand = new Player();
        NPCPlayer npchand = new NPCPlayer();
        Convert convert = new Convert();
        /// <summary>
        /// プレイヤーの手を配列へ格納していく
        /// </summary>
        /// <param name="phandArray">メインメソッドで作成したじゃんけんの手を格納するための空の配列</param>
        /// <returns>じゃんけんの手が格納され終わった配列</returns>
        public int[] makePlayersArray(int[] phandArray)
        {
            Console.WriteLine("---------------------------");
            for (int i = 0; i < phandArray.Length; i++)
            {
                phandArray[i] = phand.SetJankenHand(); // プレイヤーの手を決定するメソッドを使用。
                Console.Write("[Player{0}] :{1}, ", i + 1, convert.ToJankenHands(phandArray[i]));

            }
            return phandArray;
        }

        /// <summary>
        /// コンピューターの手を配列へ格納していく
        /// </summary>
        /// <param name="npchandArray">メインメソッドで作成したじゃんけんの手を格納するための空の配列</param>
        /// <returns>じゃんけんの手が格納され終わった配列</returns>
        public int[] makeNPCsArray(int[] npchandArray)
        {
            for (int j = 0; j < npchandArray.Length; j++)
            {
                npchandArray[j] = npchand.SetNPCJankenHand(); // コンピューターの手を決定するメソッドを使用
                Console.Write("[NPCPlayer{0}] :{1}, ", j + 1, convert.ToJankenHands(npchandArray[j]));

            }
            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            return npchandArray;
        }
    }
}

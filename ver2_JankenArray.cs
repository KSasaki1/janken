using Janken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JankenArray
{
    /// <summary>
    /// メインメソッドで作成された配列に対応する要素を格納していくメソッドを集めたクラス
    /// </summary>
    public class MakeJankenArray
    {
        // じゃんけんの手を決定するメソッドを使うためのインスタンス作成
        Players.Player phand = new Players.Player();
        Players.NPCPlayer npchand = new Players.NPCPlayer();

        /// <summary>
        /// プレイヤーの手を配列へ格納していく
        /// </summary>
        /// <param name="phandArray">メインメソッドで作成したじゃんけんの手を格納するための空の配列</param>
        /// <returns>じゃんけんの手が格納され終わった配列</returns>
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

        /// <summary>
        /// コンピューターの手を配列へ格納していく
        /// </summary>
        /// <param name="npchandArray">メインメソッドで作成したじゃんけんの手を格納するための空の配列</param>
        /// <returns>じゃんけんの手が格納され終わった配列</returns>
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

        /// <summary>
        /// じゃんけんの勝者に対する処理を行う
        /// </summary>
        /// <param name="pArray">じゃんけんの手を格納した配列</param>
        /// <param name="pWinRateArray">プレイヤーごとの勝利回数を格納するための配列</param>
        /// <param name="winnerHand">そのゲームにおいて勝利扱いとなる手に対応した整数</param>
        /// <param name="player">プレイヤーか、コンピュータープレイヤーどちらかの文字列</param>
        /// <returns>プレイヤーの勝利回数を格納し終えた配列</returns>
        public int[] Winner(int[] pArray, int[] pWinRateArray, int winnerHand, string player)
        {
            int winCount = 1;   // じゃんけんの勝利時にプレイヤーごとに加算される勝利回数

            // 勝ったら勝利回数を加算し勝利プレイヤー名を表示
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

using System;

namespace Janken
{
    class Judge
    {
        // 以下の7つの変数は論理和を用いたシフト演算の計算結果。
        public const int allRock = 2;        // 全てグーのとき 
        public const int allPaper = 4;       // 全てチョキのとき
        public const int winPaper = 6;       // パーとグーのみ出ているとき
        public const int allScissors = 8;    // 全てパーのとき
        public const int winRock = 10;       // グーとチョキのみ出ているとき
        public const int winScissors = 12;   // チョキとパーのみ出ているとき
        public const int allHand = 14;       // 3つの手が出そろったとき

        // 以下の2つの変数はプレイヤーに関する表示文章に用いる文字列。
        static string player = "Player";       // 通常プレイヤー用
        static string npcPlayer = "NPCPlayer"; // コンピューター用

        /// <summary>
        /// シフト演算で出た結果をもとに全プレイヤーの勝敗引き分けを判断
        /// </summary>
        public void Judger()
        {
            int shiftCalcedNum = ShiftCalculation.shiftCalc; // シフト演算で出た結果をここに代入。

            // 以下よりじゃんけんの判定を行う。
            if (shiftCalcedNum == allHand || shiftCalcedNum == allScissors || shiftCalcedNum == allPaper || shiftCalcedNum == allRock) // 引き分け
            {
                Console.WriteLine("DRAW");
                Console.WriteLine();
                Jankenmain.draw = true;
            }

            // 勝った場合の以下(1)～(3)処理をグーチョキパーそれぞれの場合にたいして行う。
            // (1) この試合で勝った手の役名とそれに対応する番号を表示。
            // (2) 通常プレイヤーについて、勝利したプレイヤーのプレイヤー名を表示し、勝利回数を加算。
            // (3) コンピュータープレイヤーについて(2)と同様の処理を行う
            if (shiftCalcedNum == winScissors) // チョキの勝ち 
            {
                Console.WriteLine("WIN:{0}({1})", Jankenmain.JankenHand.scissors, (int)Jankenmain.JankenHand.scissors); // (1)
                Jankenmain.playerWinCountArray = Winner(Jankenmain.playerHandArray, Jankenmain.playerWinCountArray, (int)Jankenmain.JankenHand.scissors, player); // (2)
                Jankenmain.computerWinCountArray = Winner(Jankenmain.computerHandArray, Jankenmain.computerWinCountArray, (int)Jankenmain.JankenHand.scissors, npcPlayer); // (3)
                Jankenmain.draw = false;
            }

            if (shiftCalcedNum == winRock) // グーの勝ち
            {
                Console.WriteLine("WIN:{0}({1})", Jankenmain.JankenHand.rock, (int)Jankenmain.JankenHand.rock); // (1)
                Jankenmain.playerWinCountArray = Winner(Jankenmain.playerHandArray, Jankenmain.playerWinCountArray, (int)Jankenmain.JankenHand.rock, player); // (2)
                Jankenmain.computerWinCountArray = Winner(Jankenmain.computerHandArray, Jankenmain.computerWinCountArray, (int)Jankenmain.JankenHand.rock, npcPlayer); // (3)
                Jankenmain.draw = false;
            }

            if (shiftCalcedNum == winPaper) // パーの勝ち
            {
                Console.WriteLine("WIN:{0}({1})", Jankenmain.JankenHand.paper, (int)Jankenmain.JankenHand.paper); // (1)
                Jankenmain.playerWinCountArray = Winner(Jankenmain.playerHandArray, Jankenmain.playerWinCountArray, (int)Jankenmain.JankenHand.paper, player); // (2)
                Jankenmain.computerWinCountArray = Winner(Jankenmain.computerHandArray, Jankenmain.computerWinCountArray, (int)Jankenmain.JankenHand.paper, npcPlayer); // (3)
                Jankenmain.draw = false;
            }
        }

        /// <summary>
        /// じゃんけんの勝者に対し勝利数を加算する。
        /// </summary>
        /// <param name="pArray">じゃんけんの手を格納した配列</param>
        /// <param name="pWinRateArray">勝利数を格納するための配列</param>
        /// <param name="winnerHand">その試合で勝ったじゃんけんの役</param>
        /// <param name="player">プレイヤーかコンピューターかの文字列</param>
        /// <returns></returns>
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

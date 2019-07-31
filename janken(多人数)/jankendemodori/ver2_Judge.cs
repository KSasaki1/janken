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

        int winHand;    // 引き分け:0, グーの勝ち:1, パーの勝ち:2, チョキの勝ち:3

        // 以下の2つの変数はプレイヤーに関する表示文章に用いる文字列。
        static string player = "Player";       // 通常プレイヤー用
        static string npcPlayer = "NPCPlayer"; // コンピューター用

        /// <summary>
        /// シフト演算で出た結果をもとに全プレイヤーの勝敗引き分けを判断
        /// </summary>
        public void Judger()
        {
            int shiftCalcedNum = ShiftCalculation.shiftCalc; // シフト演算で出た結果をここに代入。
            Convert convert = new Convert();

            // 以下よりじゃんけんの判定を行う。
            switch (shiftCalcedNum)
            {
                case allHand:
                case allRock:
                case allPaper:
                case allScissors:
                    Console.WriteLine("     DRAW");
                    Console.WriteLine("-----RETRY-----");
                    winHand = 0;
                    Jankenmain.draw = true;
                    break;
                case winRock:
                    winHand = (int)JankenHand.rock;
                    break;
                case winPaper:
                    winHand = (int)JankenHand.paper;
                    break;
                case winScissors: 
                    winHand = (int)JankenHand.scissors;
                    break;
                default:
                    break;
            }

            if (winHand != 0)
            {
                Console.WriteLine("WIN:{0}({1})", convert.ToJankenHands(winHand), winHand); // (1)
                Console.WriteLine();
                Jankenmain.playerWinCountArray = Winner(Jankenmain.playerHandArray, Jankenmain.playerWinCountArray, winHand, player); // (2)
                Jankenmain.computerWinCountArray = Winner(Jankenmain.computerHandArray, Jankenmain.computerWinCountArray, winHand, npcPlayer); // (3)
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
            return pWinRateArray;
        }
    }
}

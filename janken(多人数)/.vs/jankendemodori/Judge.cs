namespace Janken
{
    using System;

    /// <summary>
    /// 判定を行う
    /// </summary>
    public class Judge
    {
        // 以下の7つの変数は論理和を用いたシフト演算の計算結果。
        public const int AllRock = 2;        // 全てグーのとき
        public const int AllPaper = 4;       // 全てチョキのとき
        public const int WinPaper = 6;       // パーとグーのみ出ているとき
        public const int AllScissors = 8;    // 全てパーのとき
        public const int WinRock = 10;       // グーとチョキのみ出ているとき
        public const int WinScissors = 12;   // チョキとパーのみ出ているとき
        public const int AllHand = 14;       // 3つの手が出そろったとき

        // 以下の2つの変数はプレイヤーに関する表示文章に用いる文字列。
        private string player = "Player";       // 通常プレイヤー用
        private string npcPlayer = "NPCPlayer"; // コンピューター用

        private int winHand;    // 引き分け:0, グーの勝ち:1, パーの勝ち:2, チョキの勝ち:3

        /// <summary>
        /// シフト演算で出た結果をもとに全プレイヤーの勝敗引き分けを判断
        /// </summary>
        public void Judger()
        {
            int shiftCalcedNum = ShiftCalculation.ShiftCalc; // シフト演算で出た結果をここに代入。
            Convert convert = new Convert();

            // 以下よりじゃんけんの判定を行う。
            switch (shiftCalcedNum)
            {
                case AllHand:
                case AllRock:
                case AllPaper:
                case AllScissors:
                    Console.WriteLine("     DRAW");
                    Console.WriteLine("-----RETRY-----");
                    this.winHand = 0;
                    Jankenmain.Draw = true;
                    break;
                case WinRock:
                    this.winHand = (int)JankenHand.Rock;
                    break;
                case WinPaper:
                    this.winHand = (int)JankenHand.Paper;
                    break;
                case WinScissors:
                    this.winHand = (int)JankenHand.Scissors;
                    break;
                default:
                    break;
            }

            if (this.winHand != 0)
            {
                Console.WriteLine("WIN:{0}({1})", convert.ToJankenHands(this.winHand), this.winHand);
                Console.WriteLine();
                Jankenmain.PlayerWinCountArray = this.Winner(Jankenmain.PlayerHandArray, Jankenmain.PlayerWinCountArray, this.winHand, this.player);
                Jankenmain.ComputerWinCountArray = this.Winner(Jankenmain.ComputerHandArray, Jankenmain.ComputerWinCountArray, this.winHand, this.npcPlayer);
                Jankenmain.Draw = false;
            }
        }

        /// <summary>
        /// じゃんけんの勝者に対し勝利数を加算する。
        /// </summary>
        /// <param name="pArray">じゃんけんの手を格納した配列</param>
        /// <param name="pWinRateArray">勝利数を格納するための配列</param>
        /// <param name="winnerHand">その試合で勝ったじゃんけんの役</param>
        /// <param name="player">プレイヤーかコンピューターかの文字列</param>
        /// <returns>勝利回数の記録された配列</returns>
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

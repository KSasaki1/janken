namespace Janken
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;

    /// <summary>
    /// 全プレイヤーの勝敗数と勝率を処理する。
    /// </summary>
    public class Result
    {
        public const string Player = "Player";
        public const string NPCPlayer = "NPCPlayer";
        private int[] playerLoseCountArray = new int[GameMaster.PlayerCount]; // 各プレイヤーの敗北数を格納
        private float[] playerWinRateArray = new float[GameMaster.PlayerCount]; // 各プレイヤーの勝率を格納
        private int[] computerLoseCountArray = new int[GameMaster.NpcCount]; // 各コンピュータの敗北数を格納
        private float[] computerWinRateArray = new float[GameMaster.NpcCount]; // 各コンピュータの勝率を格納

        /// <summary>
        /// プレイヤーの種類に応じてじゃんけん結果の配列を返す。
        /// </summary>
        /// <param name="userkind">プレイヤーの種類(プレイヤー、コンピュータ)</param>
        /// <returns>勝利数、敗北数、勝率の配列</returns>
        public Tuple<int[], int[], float[]> GetResultArrays(string userkind)
        {
            switch (userkind)
            {
                case Player:
                    return Tuple.Create(Judge.PlayerWinCountArray, this.playerLoseCountArray, this.playerWinRateArray);
                case NPCPlayer:
                    return Tuple.Create(Judge.ComputerWinCountArray, this.computerLoseCountArray, this.computerWinRateArray);
                default:
                    return Tuple.Create(new int[0], new int[0], new float[0]);
            }
        }

        /// <summary>
        /// 配列に各プレイヤーの結果を格納する。
        /// </summary>
        /// <param name="userkind">プレイヤーの種類(プレイヤー、コンピュータ)</param>
        public void TestStorePlayersResult(string userkind)
        {
            var arrays = this.GetResultArrays(userkind);
            int[] winCArr = arrays.Item1;
            int[] loseCArr = arrays.Item2;
            float[] winRArr = arrays.Item3;

            for (int i = 0; i < winCArr.Length; i++)
            {
                loseCArr[i] = GameMaster.GameCount - winCArr[i]; // 敗北数計算
                winRArr[i] = (float)winCArr[i] / (float)GameMaster.GameCount; // 勝率計算
            }
        }

        /// <summary>
        /// 各プレイヤーの戦績を表示する。
        /// </summary>
        /// <param name="userkind">プレイヤーの種類(プレイヤー、コンピュータ)</param>
        /// <param name="playersArray">プレイヤーのじゃんけん結果が格納された配列</param>
        public void TestShowPlayersResult(string userkind, int[] playersArray)
        {
            for (int i = 0; i < playersArray.Length; i++)
            {
                Console.WriteLine(this.ReturnResultString(userkind, i));
            }
        }

        /// <summary>
        /// プレイヤーのじゃんけん結果の文字列を返す。
        /// </summary>
        /// <param name="userkind">プレイヤーの種類(プレイヤー、コンピュータ)</param>
        /// <param name="roopCounter">for文のループカウンタ</param>
        /// <returns>プレイヤーの勝利、敗北数と勝率を表示するための文字列</returns>
        public string ReturnResultString(string userkind, int roopCounter)
        {
            var arrays = this.GetResultArrays(userkind);
            int[] winCArr = arrays.Item1;
            int[] loseCArr = arrays.Item2;
            float[] winRArr = arrays.Item3;

            return $"{userkind}{roopCounter + 1:00} >> WIN[{winCArr[roopCounter]}], LOSE[{loseCArr[roopCounter]}], WINRATE[{winRArr[roopCounter]:P}]";
        }

        /// <summary>
        /// じゃんけん最終結果の出力
        /// </summary>
        public void ExportResult()
        {
            string wannaExport;
            Console.WriteLine();
            Console.Write("Export result ?(YES:y, NO:n)>>");
            wannaExport = Console.ReadLine();

            if (wannaExport.ToLower() == "y")
            {
                using (StreamWriter newwriter = new StreamWriter("Result.txt", false, Encoding.UTF8))
                {
                    newwriter.WriteLine("[RESULT]");
                    for (int i = 0; i < Judge.PlayerWinCountArray.Length; i++)
                    {
                        newwriter.WriteLine(this.ReturnResultString(Player, i));
                    }
                }

                using (StreamWriter addwriter = new StreamWriter("Result.txt", true, Encoding.UTF8))
                {
                    for (int i = 0; i < Judge.ComputerWinCountArray.Length; i++)
                    {
                        addwriter.WriteLine(this.ReturnResultString(NPCPlayer, i));
                    }
                }

                Console.WriteLine();
                Console.WriteLine("exported");
                Console.WriteLine("quit the game....");
            }
            else if (wannaExport.ToLower() == "n")
            {
                Console.WriteLine("quit the game....");
            }
        }
    }
}

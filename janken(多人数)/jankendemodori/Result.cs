namespace Janken
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// 全プレイヤーの勝敗数と勝率を処理する。
    /// </summary>
    public class Result
    {
        private int stiringWidth = 30;
        private int[] playerLoseCountArray = new int[GameMaster.PlayerCount]; // 各プレイヤーの敗北数を格納
        private float[] playerWinRateArray = new float[GameMaster.PlayerCount]; // 各プレイヤーの勝率を格納
        private int[] computerLoseCountArray = new int[GameMaster.NpcCount]; // 各コンピュータの敗北数を格納
        private float[] computerWinRateArray = new float[GameMaster.NpcCount]; // 各コンピュータの勝率を格納

        /// <summary>
        /// プレイヤーの勝敗数、勝率を算出して表示する。
        /// </summary>
        public void ShowPlayersResult()
        {
            for (int i = 0; i < Jankenmain.PlayerWinCountArray.Length; i++)
            {
                this.playerLoseCountArray[i] = GameMaster.GameCount - Jankenmain.PlayerWinCountArray[i]; // 敗北数計算
                this.playerWinRateArray[i] = (float)Jankenmain.PlayerWinCountArray[i] / (float)GameMaster.GameCount; // 勝率計算
                Console.WriteLine("Player{0} >> WIN[{1}], LOSE[{2}], WINRATE[{3:P}]", i + 1, Jankenmain.PlayerWinCountArray[i], this.playerLoseCountArray[i], this.playerWinRateArray[i]);
            }
        }

        /// <summary>
        /// コンピューターの勝敗数と勝率を算出して表示する。
        /// </summary>
        public void ShowNPCPlayersResult()
        {
            for (int i = 0; i < Jankenmain.ComputerWinCountArray.Length; i++)
            {
                this.computerLoseCountArray[i] = GameMaster.GameCount - Jankenmain.ComputerWinCountArray[i]; // 敗北数計算
                this.computerWinRateArray[i] = (float)Jankenmain.ComputerWinCountArray[i] / (float)GameMaster.GameCount; // 勝率計算
                Console.WriteLine("NPCPlayer{0} >> WIN[{1}], LOSE[{2}], WINRATE[{3:P}]", i + 1, Jankenmain.ComputerWinCountArray[i], this.computerLoseCountArray[i], this.computerWinRateArray[i]);
            }
        }

        /// <summary>
        /// じゃんけん最終結果の出力
        /// </summary>
        public void ExportResult()
        {
            string wannaExport;
            Console.WriteLine();
            Console.Write("Export result file?(YES:y, NO:n)>>");
            wannaExport = Console.ReadLine();

            if (wannaExport.ToLower() == "y")
            {
                using (StreamWriter newwriter = new StreamWriter(@"C:\\Users\\kaito.sasaki\\Desktop\\言語、開発研修\\Result.txt", false, Encoding.UTF8))
                {
                    newwriter.WriteLine("[RESULT]");
                    for (int i = 0; i < Jankenmain.PlayerWinCountArray.Length; i++)
                    {
                        newwriter.WriteLine("Player{0} >> WIN[{1}], LOSE[{2}], WINRATE[{3:P}]", i + 1, Jankenmain.PlayerWinCountArray[i], this.playerLoseCountArray[i], this.playerWinRateArray[i]);
                    }
                }

                using (StreamWriter addwriter = new StreamWriter(@"C:\\Users\\kaito.sasaki\\Desktop\\言語、開発研修\\Result.txt", true, Encoding.UTF8))
                {
                    for (int i = 0; i < Jankenmain.ComputerWinCountArray.Length; i++)
                    {
                        addwriter.WriteLine("NPCPlayer{0} >> WIN[{1}], LOSE[{2}], WINRATE[{3:P}]", i + 1, Jankenmain.ComputerWinCountArray[i], this.computerLoseCountArray[i], this.computerWinRateArray[i]);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("exported");
            }
            else if (wannaExport.ToLower() == "n")
            {
                Console.WriteLine("quit the game....");
            }
        }
    }
}

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
        private string player = "Player";
        private string npcPlayer = "NPCPlayer";
        private int[] playerLoseCountArray = new int[GameMaster.PlayerCount]; // 各プレイヤーの敗北数を格納
        private float[] playerWinRateArray = new float[GameMaster.PlayerCount]; // 各プレイヤーの勝率を格納
        private int[] computerLoseCountArray = new int[GameMaster.NpcCount]; // 各コンピュータの敗北数を格納
        private float[] computerWinRateArray = new float[GameMaster.NpcCount]; // 各コンピュータの勝率を格納

        /// <summary>
        /// プレイヤーの勝敗数、勝率を算出して表示する。
        /// </summary>
        public void ShowPlayersResult()
        {
            for (int i = 0; i < Judge.PlayerWinCountArray.Length; i++)
            {
                this.playerLoseCountArray[i] = GameMaster.GameCount - Judge.PlayerWinCountArray[i]; // 敗北数計算
                this.playerWinRateArray[i] = (float)Judge.PlayerWinCountArray[i] / (float)GameMaster.GameCount; // 勝率計算
                Console.WriteLine($"   {this.player}{i + 1:00} >> WIN[{Judge.PlayerWinCountArray[i]}], LOSE[{this.playerLoseCountArray[i]}], WINRATE[{this.playerWinRateArray[i]:P}]");
            }
        }

        /// <summary>
        /// コンピューターの勝敗数と勝率を算出して表示する。
        /// </summary>
        public void ShowNPCPlayersResult()
        {
            for (int i = 0; i < Judge.ComputerWinCountArray.Length; i++)
            {
                this.computerLoseCountArray[i] = GameMaster.GameCount - Judge.ComputerWinCountArray[i]; // 敗北数計算
                this.computerWinRateArray[i] = (float)Judge.ComputerWinCountArray[i] / (float)GameMaster.GameCount; // 勝率計算
                Console.WriteLine($"{this.npcPlayer}{i + 1:00} >> WIN[{Judge.ComputerWinCountArray[i]}], LOSE[{this.computerLoseCountArray[i]}], WINRATE[{this.computerWinRateArray[i]:P}]");
            }
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
                        newwriter.WriteLine($"   {this.player}{i + 1:00} >> WIN[{Judge.PlayerWinCountArray[i]}], LOSE[{this.playerLoseCountArray[i]}], WINRATE[{this.playerWinRateArray[i]:P}]");
                    }
                }

                using (StreamWriter addwriter = new StreamWriter("Result.txt", true, Encoding.UTF8))
                {
                    for (int i = 0; i < Judge.ComputerWinCountArray.Length; i++)
                    {
                        addwriter.WriteLine($"{this.npcPlayer}{i + 1:00} >> WIN[{Judge.ComputerWinCountArray[i]}], LOSE[{this.computerLoseCountArray[i]}], WINRATE[{this.computerWinRateArray[i]:P}]");
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

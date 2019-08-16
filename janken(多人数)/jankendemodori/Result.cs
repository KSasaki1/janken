namespace Janken
{
    using System;
    using System.Diagnostics.Eventing.Reader;
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
        public (int[] winCArr, int[] loseCArr, float[] winRArr) GetResultArrays(string userkind)
        {
            switch (userkind)
            {
                case Player:
                    return (Judge.PlayerWinCountArray, this.playerLoseCountArray, this.playerWinRateArray);
                case NPCPlayer:
                    return (Judge.ComputerWinCountArray, this.computerLoseCountArray, this.computerWinRateArray);
                default:
                    return (new int[0], new int[0], new float[0]);
            }
        }

        /// <summary>
        /// 配列に各プレイヤーの結果を格納する。
        /// </summary>
        /// <param name="userkind">プレイヤーの種類(プレイヤー、コンピュータ)</param>
        public void StorePlayersResult(string userkind)
        {
            var arrays = this.GetResultArrays(userkind);

            for (int i = 0; i < arrays.winCArr.Length; i++)
            {
                arrays.loseCArr[i] = GameMaster.GameCount - arrays.winCArr[i]; // 敗北数計算
                arrays.winRArr[i] = (float)arrays.winCArr[i] / (float)GameMaster.GameCount; // 勝率計算
            }
        }

        /// <summary>
        /// 成績の表示、ファイル出力のもととなる処理
        /// </summary>
        /// <param name="userkind">プレイヤーの種類(プレイヤー、コンピュータ)</param>
        /// <param name="playersArray">プレイヤーの数だけ要素を格納する配列</param>
        public void ShowPlayersResult(string userkind, int[] playersArray)
        {
            var arrays = this.GetResultArrays(userkind);

            for (int i = 0; i < playersArray.Length; i++)
            {
                Console.WriteLine($"{userkind}{i + 1:00} >> WIN[{arrays.winCArr[i]}], LOSE[{arrays.loseCArr[i]}], WINRATE[{arrays.winRArr[i]:P}]");
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
                StreamWriter standerd = new StreamWriter(Console.OpenStandardOutput());
                using (StreamWriter newwriter = new StreamWriter("Result.txt", false, Encoding.UTF8))
                {
                    Console.SetOut(newwriter);
                    Console.WriteLine("[RESULT]");
                    this.ShowPlayersResult(Player, Judge.PlayerWinCountArray);
                    this.ShowPlayersResult(NPCPlayer, Judge.ComputerWinCountArray);
                    Console.SetOut(standerd);
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

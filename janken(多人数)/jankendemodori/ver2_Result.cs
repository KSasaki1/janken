using System;

namespace Janken
{
    /// <summary>
    /// 全プレイヤーの勝敗数と勝率を処理する。
    /// </summary>
    class Result
    {
        /// <summary>
        /// プレイヤーの勝敗数、勝率を算出して表示する。
        /// </summary>
        public void ShowPlayersResult()
        {
            int[] playerLoseCountArray = new int[GameMaster.playerCount]; // 各プレイヤーの敗北数を格納
            float[] playerWinRateArray = new float[GameMaster.playerCount]; // 各プレイヤーの勝率を格納
            for (int i = 0; i < Jankenmain.playerWinCountArray.Length; i++)
            {
                playerLoseCountArray[i] = GameMaster.gameCount - Jankenmain.playerWinCountArray[i]; // 敗北数計算
                playerWinRateArray[i] =( (float)Jankenmain.playerWinCountArray[i] / (float)GameMaster.gameCount); // 勝率計算
                Console.WriteLine("Player{0} >> WIN[{1}], LOSE[{2}], WINRATE[{3:P}]", i + 1, Jankenmain.playerWinCountArray[i], playerLoseCountArray[i], playerWinRateArray[i]);
            }
        }

        /// <summary>
        /// コンピューターの勝敗数と勝率を算出して表示する。
        /// </summary>
        public void ShowNPCPlayersResult()
        {
            int[] computerLoseCountArray = new int[GameMaster.npcCount]; // 各コンピュータの敗北数を格納
            float[] computerWinRateArray = new float[GameMaster.npcCount]; // 各コンピュータの勝率を格納
            for (int i = 0; i < Jankenmain.computerWinCountArray.Length; i++)
            {
                computerLoseCountArray[i] = GameMaster.gameCount - Jankenmain.computerWinCountArray[i]; // 敗北数計算
                computerWinRateArray[i] = ((float)Jankenmain.computerWinCountArray[i] / (float)GameMaster.gameCount); // 勝率計算
                Console.WriteLine("NPCPlayer{0} >> WIN[{1}], LOSE[{2}], WINRATE[{3:P}]", i + 1, Jankenmain.computerWinCountArray[i], computerLoseCountArray[i], computerWinRateArray[i]);

            }
        }
    }
}

using System;

namespace Janken
{
    /// <summary>
    /// ここでじゃんけんゲームを行う
    /// </summary>
    class Jankenmain
    {
        static public bool draw = false; // 引き分け (true) のときじゃんけんの手の選択から仕切りなおす
 
        static public int[] playerHandArray;        // プレイヤーの出した手を格納する配列。
        static public int[] playerWinCountArray;    // プレイヤーの勝利回数を格納する配列。
        static public int[] computerHandArray;      // コンピューターの出した手を格納する配列。
        static public int[] computerWinCountArray;  // コンピューターの勝利回数を格納する配列。

        /// <summary>
        /// じゃんけんのメイン処理
        /// </summary>
        static void Main()
        {
            GameMaster gameMaster = new GameMaster();
            MakeHandArray makeHandArray = new MakeHandArray();
            ShiftCalculation shiftCalculation = new ShiftCalculation();
            Judge judge = new Judge();

            gameMaster.Master(); // プレイ回数、人数決定

            // 以下よりプレイヤーの指定した数だけじゃんけんをする。
            for (int i = 0; i < GameMaster.gameCount; i++)
            {
                do // 引き分けの間繰り返す
                {
                    ShiftCalculation.shiftCalc = 0; // 引き分けの時はここでシフト演算の結果が0に初期化される。

                    // プレイヤーのじゃんけんの手を配列に格納し、中身についてシフト演算していく
                    playerHandArray = makeHandArray.makePlayersArray(playerHandArray);
                    shiftCalculation.playerShiftCalc();

                    // コンピューターについて上部でプレイヤーに対して行ったものと同じ処理を行う。
                    computerHandArray = makeHandArray.makeNPCsArray(computerHandArray);
                    shiftCalculation.cpShiftCalc();

                    judge.Judger(); // 勝敗引き分けの判定。 

                } while (draw);
            }

            Result result = new Result();
            Console.WriteLine();
            Console.WriteLine("↓↓↓↓↓↓RESULT↓↓↓↓↓↓");
            result.ShowPlayersResult();     // プレイヤーの戦績表示。
            result.ShowNPCPlayersResult();  // コンピューターの戦績表示。
        }
    }
}

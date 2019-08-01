namespace Janken
{
    using System;

    /// <summary>
    /// ここでじゃんけんゲームを行う
    /// </summary>
    public static class Jankenmain
    {
        /// <summary>
        /// じゃんけんのメイン処理
        /// </summary>
        public static void Main()
        {
            GameMaster gameMaster = new GameMaster();
            ShiftCalculation shiftCalculation = new ShiftCalculation();

            gameMaster.Master(); // プレイ回数、人数決定

            MakeHandArray makeHandArray = new MakeHandArray();
            Judge judge = new Judge();

            // 以下よりプレイヤーの指定した数だけじゃんけんをする。
            for (int i = 0; i < GameMaster.GameCount; i++)
            {
                // 引き分けの間繰り返す
                do
                {
                    ShiftCalculation.ShiftCalc = 0; // 引き分けの時はここでシフト演算の結果が0に初期化される。

                    // プレイヤーのじゃんけんの手を配列に格納し、中身についてシフト演算していく
                    makeHandArray.MakePlayersArray();
                    shiftCalculation.PlayerShiftCalc();

                    // コンピューターについて上部でプレイヤーに対して行ったものと同じ処理を行う。
                    makeHandArray.MakeNPCsArray();
                    shiftCalculation.CPShiftCalc();

                    judge.Judger(); // 勝敗引き分けの判定。
                }
                while (Judge.Draw);
            }

            Result result = new Result();
            Console.WriteLine();
            Console.WriteLine("↓↓↓↓↓↓RESULT↓↓↓↓↓↓");
            result.ShowPlayersResult();     // プレイヤーの戦績表示。
            result.ShowNPCPlayersResult();  // コンピューターの戦績表示。

            result.ExportResult();
        }
    }
}

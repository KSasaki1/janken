namespace Janken
{
    using System;

    /// <summary>
    /// ここでじゃんけんゲームを行う
    /// </summary>
    public static class Jankenmain
    {
        private static bool draw = false; // 引き分け (true) のときじゃんけんの手の選択から仕切りなおす
        private static int[] playerHandArray;        // プレイヤーの出した手を格納する配列。
        private static int[] playerWinCountArray;    // プレイヤーの勝利回数を格納する配列。
        private static int[] computerHandArray;      // コンピューターの出した手を格納する配列。
        private static int[] computerWinCountArray;  // コンピューターの勝利回数を格納する配列。

        public static bool Draw
        {
            get => draw;
            set => draw = value;
        }

        public static int[] PlayerHandArray
        {
            get => playerHandArray;
            set => playerHandArray = value;
        }

        public static int[] PlayerWinCountArray
        {
            get => playerWinCountArray;
            set => playerWinCountArray = value;
        }

        public static int[] ComputerHandArray
        {
            get => computerHandArray;
            set => computerHandArray = value;
        }

        public static int[] ComputerWinCountArray
        {
            get => computerWinCountArray;
            set => computerWinCountArray = value;
        }

        /// <summary>
        /// じゃんけんのメイン処理
        /// </summary>
        public static void Main()
        {
            GameMaster gameMaster = new GameMaster();
            MakeHandArray makeHandArray = new MakeHandArray();
            ShiftCalculation shiftCalculation = new ShiftCalculation();
            Judge judge = new Judge();

            gameMaster.Master(); // プレイ回数、人数決定

            // 以下よりプレイヤーの指定した数だけじゃんけんをする。
            for (int i = 0; i < GameMaster.GameCount; i++)
            {
                // 引き分けの間繰り返す
                do
                {
                    ShiftCalculation.ShiftCalc = 0; // 引き分けの時はここでシフト演算の結果が0に初期化される。

                    // プレイヤーのじゃんけんの手を配列に格納し、中身についてシフト演算していく
                    PlayerHandArray = makeHandArray.MakePlayersArray(PlayerHandArray);
                    shiftCalculation.PlayerShiftCalc();

                    // コンピューターについて上部でプレイヤーに対して行ったものと同じ処理を行う。
                    ComputerHandArray = makeHandArray.MakeNPCsArray(ComputerHandArray);
                    shiftCalculation.CPShiftCalc();

                    judge.Judger(); // 勝敗引き分けの判定。
                }
                while (Draw);
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

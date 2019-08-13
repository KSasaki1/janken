﻿namespace Janken
{
    using System;

    /// <summary>
    /// じゃんけんの試合回数、プレイ人数を決定する。
    /// </summary>
    public static class GameMaster
    {
        private static int playerCount; // プレイヤー人数
        private static int npcCount;    // コンピュータの数
        private static int gameCount;   // プレイ回数

        public static int PlayerCount
        {
            get => playerCount;
            private set => playerCount = value;
        }

        public static int NpcCount
        {
            get => npcCount;
            private set => npcCount = value;
        }

        public static int GameCount
        {
            get => gameCount;
            private set => gameCount = value;
        }

        /// <summary>
        /// ゲーム準備のための入力
        /// </summary>
        public static void Master()
        {
            // じゃんけんを何ゲームするか決定。
            Console.Write("何回勝負?>>");
            GameCount = CorrectNumber();

            // 通常プレイヤーの数を決定。
            // これに伴いプレイヤー数に対応したじゃんけんの手を格納する配列、プレイヤーごとの勝利回数を格納する配列を作成。
            Console.Write("プレイヤーは何人?>>");
            PlayerCount = CorrectNumber();

            // コンピュータープレイヤーに関して、上部でプレイヤーに関して行ったものと同じ処理を行う。
            do
            {
                Console.Write("コンピューターは何人?>>");
                NpcCount = CorrectNumber();
            }
            while ((PlayerCount + NpcCount) < 2 && GameCount > 0);
        }

        /// <summary>
        /// 数値が入力されるまでリトライ
        /// </summary>
        /// <returns>int型の数値</returns>
        public static int CorrectNumber()
        {
            string input;           // 数値入力

            while (true)
            {
                input = Console.ReadLine();
                if (uint.TryParse(input, out uint i))
                {
                        return (int)i;
                }
                else
                {
                    Console.Write("正の整数を入力してください(int32)>>");
                }
            }
        }
    }
}

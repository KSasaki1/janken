﻿namespace Janken
{
    using System;

    /// <summary>
    /// メインメソッドで作成された配列に対応する要素を格納していくメソッドを集めたクラス
    /// </summary>
    public class MakeHandArray
    {
        private static int[] playerHandArray = new int[GameMaster.PlayerCount];        // プレイヤーの出した手を格納する配列。
        private static int[] computerHandArray = new int[GameMaster.NpcCount];      // コンピューターの出した手を格納する配列。
        private Player phand = new Player();
        private NPCPlayer npchand = new NPCPlayer();
        private Convert convert = new Convert();

        public static int[] PlayerHandArray
        {
            get => playerHandArray;
            private set => playerHandArray = value;
        }

        public static int[] ComputerHandArray
        {
            get => computerHandArray;
            private set => computerHandArray = value;
        }

        /// <summary>
        /// プレイヤーの手を配列へ格納していく
        /// </summary>
        /// <param name="phandArray">メインメソッドで作成したじゃんけんの手を格納するための空の配列</param>
        public void MakePlayersArray()
        {
            Console.WriteLine("---------------------------");
            for (int i = 0; i < playerHandArray.Length; i++)
            {
                playerHandArray[i] = this.phand.SetJankenHand(); // プレイヤーの手を決定するメソッドを使用。
                Console.Write("[Player{0}] :{1}, ", i + 1, this.convert.ToJankenHands(playerHandArray[i]));
            }
        }

        /// <summary>
        /// コンピューターの手を配列へ格納していく
        /// </summary>
        /// <param name="npchandArray">メインメソッドで作成したじゃんけんの手を格納するための空の配列</param>
        public void MakeNPCsArray()
        {
            for (int j = 0; j < computerHandArray.Length; j++)
            {
                computerHandArray[j] = this.npchand.SetNPCJankenHand(); // コンピューターの手を決定するメソッドを使用
                Console.Write("[NPCPlayer{0}] :{1}, ", j + 1, this.convert.ToJankenHands(computerHandArray[j]));
            }

            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine();
        }
    }
}

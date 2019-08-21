namespace Janken
{
    using System;

    /// <summary>
    /// 作成された配列に対応する要素を格納していくメソッドを集めたクラス
    /// </summary>
    public class MakeHandArray
    {
        private static int[] playerHandArray = new int[GameMaster.PlayerCount];        // プレイヤーの出した手を格納する配列。
        private static int[] computerHandArray = new int[GameMaster.NpcCount];         // コンピューターの出した手を格納する配列。
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
        /// <param name="playerkind">プレイヤーの種類(プレイヤー、コンピュータ)</param>
        /// <param name="pHandArr">プレイヤーの手を格納する配列</param>
        public void TestMakePlayersArray(string playerkind, int[] pHandArr)
        {
            for (int i = 0; i < pHandArr.Length; i++)
            {
                pHandArr[i] = this.ReturnJankenHandFunc(playerkind);
                Console.Write("[{0}{1}] :{2}, ", playerkind, i + 1, this.convert.ToJankenHands(pHandArr[i]));
            }
        }

        /// <summary>
        /// プレイヤーに対応したじゃんけんの手を決定するメソッドを返す
        /// </summary>
        /// <param name="playerKind">>プレイヤーの種類(プレイヤー、コンピュータ)</param>
        /// <returns>プレイヤーに対応したじゃんけんの手を決定するメソッド</returns>
        public int ReturnJankenHandFunc(string playerKind)
        {
            switch (playerKind)
            {
                case Result.Player:
                    return this.phand.SetJankenHand();
                case Result.NPCPlayer:
                    return this.npchand.SetNPCJankenHand();
                default:
                    return 0;
            }
        }
    }
}

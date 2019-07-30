using System;

namespace Janken
{
    /// <summary>
    /// じゃんけんの試合回数、プレイ人数を決定する。
    /// </summary>
    public class GameMaster
    {
        static public int playerCount, npcCount, gameCount; // プレイヤーとコンピュータの数、プレイ回数。
        public void Master()
        {
            // じゃんけんを何ゲームするか決定。
            Console.Write("何回勝負?");
            gameCount = int.Parse(Console.ReadLine());

            // 通常プレイヤーの数を決定。
            // これに伴いプレイヤー数に対応したじゃんけんの手を格納する配列、プレイヤーごとの勝利回数を格納する配列を作成。
            Console.Write("プレイヤーは何人?");
            playerCount = int.Parse(Console.ReadLine());
            Jankenmain.playerHandArray = new int[playerCount];
            Jankenmain.playerWinCountArray = new int[playerCount];

            // コンピュータープレイヤーに関して、上部でプレイヤーに関して行ったものと同じ処理を行う。
            do
            {
                Console.Write("コンピューターは何人?");
                npcCount = int.Parse(Console.ReadLine());
            } while ((playerCount + npcCount) < 2 && gameCount > 0);

            Jankenmain.computerHandArray = new int[npcCount];
            Jankenmain.computerWinCountArray = new int[npcCount];
        }
    }
}

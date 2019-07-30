using System;

namespace Janken
{
    class Jankenmain
    {
        /// <summary>
        /// じゃんけんの手をまとめたもの
        /// </summary>
        enum JankenHand
        {
            rock = 1,
            paper,
            scissors
        }

        /// <summary>
        /// 対戦について、任意の人数、回数を決定し、勝利判定を行う。
        /// プレイヤーの指定したゲーム数の後、プレイヤーごとの勝利回数を表示する。
        /// </summary>
        static void Main()
        {
            int shiftNumber = 1;    // シフト演算に使う2進数の'1'

            // 以下の7つの変数は論理和を用いたシフト演算の計算結果。
            int allRock = 2;        // 全てグーのとき 
            int allPaper = 4;       // 全てチョキのとき
            int allScissors = 8;    // 全てパーのとき
            int allHand = 14;       // 3つの手が出そろったとき
            int winRock = 10;       // グーとチョキのみ出ているとき
            int winPaper = 6;       // パーとグーのみ出ているとき
            int winScissors = 12;   // チョキとパーのみ出ているとき

            // 以下の2つの変数はプレイヤーに関する表示文章に用いる文字列。
            string player = "Player";       // 通常プレイヤー用
            string npcPlayer = "NPCPlayer"; // コンピューター用

            // じゃんけんを何ゲームするか決定。
            Console.Write("何回勝負?");
            int battleCount = int.Parse(Console.ReadLine());

            // 通常プレイヤーの数を決定。
            // これに伴いプレイヤー数に対応したじゃんけんの手を格納する配列、プレイヤーごとの勝利回数を格納する配列を作成。
            Console.Write("プレイヤーは何人?");
            int playerCount = int.Parse(Console.ReadLine());
            int[] playerHandArray = new int[playerCount];
            int[] playerWinRateArray = new int[playerCount];

            // コンピュータープレイヤーに関して、上部でプレイヤーに関して行ったものと同じ処理を行う。
            Console.Write("コンピューターは何人?");
            int npcCount = int.Parse(Console.ReadLine());
            int[] computerHandArray = new int[npcCount];
            int[] computerWinRateArray = new int[npcCount];

            // じゃんけんの手、勝利回数を配列へ格納するメソッドを使うためのインスタンス作成。
            JankenArray.MakeJankenArray pmakeArray = new JankenArray.MakeJankenArray();
            JankenArray.MakeJankenArray cmakeArray = new JankenArray.MakeJankenArray();

            // 以下よりプレイヤーの指定した数だけじゃんけんをする。
            for (int i = 0; i < battleCount; i++)
            {
            jankenIsDraw: // じゃんけんが引き分けのときここに戻ってくる。

                int k = 0; // シフト演算の結果をここに代入していく。引き分けの時はここで0に初期化される。

                // プレイヤーのじゃんけんの手を配列に格納し、中身を'k'へシフト演算していく
                playerHandArray = pmakeArray.PhandDetermin(playerHandArray);
                for (int p = 0; p < playerHandArray.Length; p++)
                {
                    k |= shiftNumber << playerHandArray[p];
                }

                // コンピューターについて上部でプレイヤーに対して行ったものと同じ処理を行う。
                computerHandArray = cmakeArray.CPhandDetermin(computerHandArray);
                for (int q = 0; q < computerHandArray.Length; q++)
                {
                    k |= shiftNumber << computerHandArray[q];
                }

                // 以下よりじゃんけんの判定を行う。
                if (k == allHand || k == allScissors || k == allPaper || k == allRock) // 引き分け
                {
                    Console.WriteLine("DRAW");
                    Console.WriteLine();
                    goto jankenIsDraw;
                }

                // 勝った場合の以下(1)～(3)処理をグーチョキパーそれぞれの場合にたいして行う。
                // (1) この試合で勝った手の役名とそれに対応する番号を表示。
                // (2) 通常プレイヤーについて、勝利したプレイヤーのプレイヤー名を表示し、勝利回数を加算。
                // (3) コンピュータープレイヤーについて(2)と同様の処理を行う
                if (k == winScissors) // チョキの勝ち 
                {
                    Console.WriteLine("WIN:{0}({1})", JankenHand.scissors, (int)JankenHand.scissors); // (1)
                    playerWinRateArray = pmakeArray.Winner(playerHandArray, playerWinRateArray, (int)JankenHand.scissors, player); // (2)
                    computerWinRateArray = cmakeArray.Winner(computerHandArray, computerWinRateArray, (int)JankenHand.scissors, npcPlayer); // (3)
                }

                if (k == winRock) // グーの勝ち
                {
                    Console.WriteLine("WIN:{0}({1})", JankenHand.rock, (int)JankenHand.rock);　// (1)
                    playerWinRateArray = pmakeArray.Winner(playerHandArray, playerWinRateArray, (int)JankenHand.rock, player); // (2)
                    computerWinRateArray = cmakeArray.Winner(computerHandArray, computerWinRateArray, (int)JankenHand.rock, npcPlayer); // (3)
                }

                if (k == winPaper) // パーの勝ち
                {
                    Console.WriteLine("WIN:{0}({1})", JankenHand.paper, (int)JankenHand.paper); // (1)
                    playerWinRateArray = pmakeArray.Winner(playerHandArray, playerWinRateArray, (int)JankenHand.paper, player); // (2)
                    computerWinRateArray = cmakeArray.Winner(computerHandArray, computerWinRateArray, (int)JankenHand.paper, npcPlayer); // (3)
                }
            }

            // 以下にstring.formatを使いたい
            // 全試合終了後、プレイヤー、コンピューター全員の名前と勝利回数を表示。
            for (int i = 0; i < playerWinRateArray.Length; i++)
            {
                Console.WriteLine(player + (i + 1) + ":" + playerWinRateArray[i] + ",");
            }

            for (int i = 0; i < computerWinRateArray.Length; i++)
            {
                Console.WriteLine(npcPlayer + (i + 1) + ":" + computerWinRateArray[i] + ",");
            }
        }
    }
}

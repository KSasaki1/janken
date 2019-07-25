// janken

namespace JankenGameMaster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// ゲームをプレイするか否か、結果確認の処理をまとめたもの
    /// </summary>
    public class GameMaster
    {
        private static int winCount = 0;      // プレイヤーの勝利数
        private static int loseCount = 0;      // プレイヤーの敗北数
        private static int drawCount = 0;      // 引き分け数
        private static int gameCount = 0;      // ゲームのプレイ回数

        /// <summary>
        /// 勝敗引き分けを判定するメソッド
        /// </summary>
        /// <param name="result">JankenGameMainより結果を持ってくる</param>
        /// <returns>プレイを続ける:true 成績を確認しプレイをやめる:false</returns>
        public bool Result(string result)
        {
            gameCount++;

            // 勝敗が決まった場合はゲームを続けるか結果確認をしてゲームを終了するか選ぶ
            // 引き分けの場合は再度じゃんけんの手を入力する処理へ戻る
            switch (result)
            {
                case "win":
                    winCount++;
                    goto gamescore;

                case "lose":
                    loseCount++;
                    goto gamescore;

                case "draw":
                    drawCount++;
                    return true;

                default:
                    Console.WriteLine("ERROR");
                    return false;

// 勝ち、負けの場合の処理
gamescore:
                    Console.Write("continue?(yes:y, no:n)>>");
                    char wannaplay = char.Parse(Console.ReadLine());
                    if (char.ToLower(wannaplay) == 'n')
                    {
                        double winRate = (winCount / gameCount) * 100;
                        Console.WriteLine("{0}games result... [Win:{1}, Lose:{2}, Draw:{3}] , Win Rate = {4}", gameCount, winCount, loseCount, drawCount, winRate);
                        return false;
                    }
                    else if (wannaplay == 'y')
                    {
                        Console.WriteLine("play one more time");
                        Console.WriteLine();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("play one more time");
                        Console.WriteLine();
                        return true;
                    }
            }
        }
    }
}

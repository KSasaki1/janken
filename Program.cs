// janken

namespace Janken2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// じゃんけんゲーム
    /// </summary>
    public class Program
    {
        public enum Janken                  // 16~21に関する部分は編集中
        {
            Rock = 1, // じゃんけん:ぐー           
            Paper,    // じゃんけん:ぱー
            Scissors,  // じゃんけん:ちょき
        }                                   

        /// <summary>
        /// やめるを選択するまでプレイ
        /// </summary>
        /// <param name="args">引数なし</param>
        private static void Main(string[] args)
        {
            bool gamePlay = true;
            JankenGameMaster.GameMaster gm = new JankenGameMaster.GameMaster();

            while (gamePlay)
            {
                string result = JankenGameMain();
                gamePlay = gm.Result(result);
            }
        }

        /// <summary>
        /// じゃんけんを実行して勝敗を決める
        /// </summary>
        /// <returns>返り値なし</returns>
        private static string JankenGameMain()
        {
            int playerHand;
            int computerHand1, computerHand2;
            int rock = 1, paper = 2, scissors = 3;
            Random doHandRandom = new System.Random(); // CPプレイヤーの手となる1～３の乱数を作る

            // プレイヤーの手を入力
            Console.Write("input a number (ROCK = 1, PAPER = 2, SCISSORS = 3)>>");
            playerHand = int.Parse(Console.ReadLine());

            // １、２、３のどれかを選択するまでプレイヤーの手を入力
            while (playerHand > 3 || playerHand < 1)
            {
                Console.Write("input a correct number (ROCK = 1, PAPER = 2, SCISSORS = 3)>>");
                playerHand = int.Parse(Console.ReadLine());
            }

            // コンピュータ1の出す手を１～３のうちから決める
            computerHand1 = doHandRandom.Next(1, 4);

            // コンピュータ2の出す手を１～３のうちから決める
            computerHand2 = doHandRandom.Next(1, 4);

            // 全プレイヤーの手を表示
            Console.WriteLine("<You:" + ConvertJankenHands(playerHand) + "> vs " + "<CP1:" + ConvertJankenHands(computerHand1) + "> vs " + "<CP2:" + ConvertJankenHands(computerHand2) + ">");

            // 以下勝敗引き分けの判定とそれに対応した値を返す処理

            // 勝ちの判定
            if ((playerHand == rock && computerHand1 == scissors && computerHand2 == scissors) || (playerHand == paper && computerHand1 == rock && computerHand2 == rock) || (playerHand == scissors && computerHand1 == paper && computerHand2 == paper)　||
                (playerHand == rock && computerHand1 == rock && computerHand2 == scissors) || (playerHand == paper && computerHand1 == paper && computerHand2 == rock) || (playerHand == scissors && computerHand1 == scissors && computerHand2 == paper)　||
                (playerHand == rock && computerHand1 == scissors && computerHand2 == rock) || (playerHand == paper && computerHand1 == rock && computerHand2 == paper) || (playerHand == scissors && computerHand1 == paper && computerHand2 == scissors))
            {
                Console.WriteLine("-----YOU WIN-----");
                Console.WriteLine();
                return "win";
            }

            // 引き分けの判定
            else if ((playerHand == computerHand1 && playerHand == computerHand2) || (playerHand != computerHand1 && playerHand != computerHand2 && computerHand1 != computerHand2))
            {
                Console.WriteLine("------DRAW------");
                Console.WriteLine();
                Console.WriteLine("try again");
                return "draw";
            }

            // 負けの判定
            else
            {
                Console.WriteLine("-----YOU LOSE-----");
                Console.WriteLine();
                return "lose";
            }
        }

        /// <summary>
        /// じゃんけんの手となる値を対応するじゃんけんの手の文字列として返す
        /// </summary>
        /// <param name="handNumber"> JankenGameMainで出した数値が入る </param>
        /// <returns>1:ROCK 2:PAPER 3:SCISSORS </returns>
        private static string ConvertJankenHands(int handNumber)
        {
            switch (handNumber)
            {
                case 1:
                    return "ROCK";
                case 2:
                    return "PAPER";
                case 3:
                    return "SCISSORS";
                default:
                    return "ERROR";
            }
        }
    }
}

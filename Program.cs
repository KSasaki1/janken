using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace janken2
{
    class Program
    {

        static void Main(string[] args)
        { 
            bool GamePlay = true;
            GameMaster GM = new GameMaster();

            while (GamePlay == true)
            {
                string result = JankenGameMain();
                GamePlay = GM.Result(result);
            }
               
        }


        //コンピューターとのじゃんけんの勝敗を決める
        static string JankenGameMain()
        {
            int PlayerHand;
            int ComputerHand;
            Random CPhandRandom = new System.Random();    //CPプレイヤーの手となる1～３の乱数を作る

            //プレイヤーの手を入力
            Console.WriteLine("imput a number (rock = 1, paper = 2, scissors = 3)");
            PlayerHand = int.Parse(Console.ReadLine());

            //１、２、３のどれかを選択するまでプレイヤーの手を入力
            while (PlayerHand > 3 || PlayerHand < 1)
            {
                Console.WriteLine("imput a collect number (rock = 1, paper = 2, scissors = 3)");
                PlayerHand = int.Parse(Console.ReadLine());
            }

            //コンピュータの出す手を１～３のうちから決める
            ComputerHand = CPhandRandom.Next(1, 4);
            Console.WriteLine("your hand:" + PlayerHand + " vs " + "CP's hand:" + ComputerHand);

            //以下勝敗引き分けの判定とそれに対応した値を返す処理

            //勝ちの判定
            if ((PlayerHand == 1 && ComputerHand == 3) || (PlayerHand == 2 && ComputerHand == 1) || (PlayerHand == 3 && ComputerHand == 2))
            {
                Console.WriteLine("-----YOU WIN-----");
                Console.WriteLine();
                return "win";
            }
            //引き分けの判定
            else if (PlayerHand == ComputerHand)
            {
                Console.WriteLine("------DRAW!------");
                Console.WriteLine();
                Console.WriteLine("try again");
                return "draw";
            }
            //負けの判定
            else
            {
                Console.WriteLine("-----YOU LOSE-----");
                Console.WriteLine();
                return "lose";
            }
                                                             //return Tuple.Create(PHand, CPHand);   //プレイヤーとｃｐの手を返り値として返す
        }
    }

    //ゲームをプレイするか否か、結果確認の処理をまとめたもの
    class GameMaster
    {

        static int WinCount = 0;      //プレイヤーの勝利数
        static int LoseCount = 0;      //プレイヤーの敗北数
        static int DrawCount = 0;      //引き分け数
        static int GameCount = 0;      //ゲームのプレイ回数


        //勝敗引き分けを判定するメソッド
        //static string IsJudge(int PHand, int CPHand){}

        public bool Result(string result)
        {
            GameCount++;

            //勝敗が決まった場合はゲームを続けるか結果確認をしてゲームを終了するか選ぶ
            //引き分けの場合は再度じゃんけんの手を入力する処理へ戻る
            switch (result)
            {
                case "win":
                    WinCount++;
                    goto gamescore;

                case "lose":
                    LoseCount++;
                    goto gamescore;

                case "draw":
                    DrawCount++;
                    return true;

                default:
                    return true;

//勝ち、負けの場合の処理
gamescore:
                    Console.Write("continue?(yes:y, no:n)>>");
                    char Wannaplay = char.Parse(Console.ReadLine());
                    if (char.ToLower(Wannaplay) == 'n')
                    {
                        Console.WriteLine("your {0}games of result is [win:{1}, lose:{2}, draw:{3}]", GameCount, WinCount, LoseCount, DrawCount);
                        return false;
                    }
                    else if (Wannaplay == 'y')
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

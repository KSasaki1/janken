using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    /// <summary>
    /// じゃんけんの手をまとめたもの
    /// </summary>
    public enum JankenHand
    {
        rock = 1,
        paper,
        scissors
    }

    /// <summary>
    /// 整数値を対応するじゃんけんの手に変換する。
    /// </summary>
    class Convert
    {
        /// <summary>
        /// じゃんけんの手となる値を対応するじゃんけんの手の文字列として返す
        /// </summary>
        /// <param name="handNumber"> JankenGameMainで出した数値が入る </param>
        /// <returns>1:rock 2:paper 3:scissors </returns>
        public string ToJankenHands(int handNumber)
        {
            switch (handNumber)
            {
                case (int)JankenHand.rock:
                    return nameof(JankenHand.rock).ToUpper();
                case (int)JankenHand.paper:
                    return nameof(JankenHand.paper).ToUpper();
                case (int)JankenHand.scissors:
                    return nameof(JankenHand.scissors).ToUpper();
                default:
                    return "ERROR";
            }
        }
    }
}

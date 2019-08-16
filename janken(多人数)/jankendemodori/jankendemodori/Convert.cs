namespace Janken
{
    /// <summary>
    /// じゃんけんの手をまとめたもの
    /// </summary>
    public enum JankenHand
    {
        /// <summary>
        /// グー
        /// </summary>
        Rock = 1,

        /// <summary>
        /// パー
        /// </summary>
        Paper,

        /// <summary>
        /// チョキ
        /// </summary>
        Scissors,
    }

    /// <summary>
    /// 整数値を対応するじゃんけんの手に変換する。
    /// </summary>
    public class Convert
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
                case (int)JankenHand.Rock:
                    return nameof(JankenHand.Rock);
                case (int)JankenHand.Paper:
                    return nameof(JankenHand.Paper);
                case (int)JankenHand.Scissors:
                    return nameof(JankenHand.Scissors);
                default:
                    return "ERROR";
            }
        }
    }
}

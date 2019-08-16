namespace Janken
{
    /// <summary>
    /// 論理和によるシフト演算を行いじゃんけんのどの手が出たかを算出する。
    /// </summary>
    public class ShiftCalculation
    {
        private const int ShiftNumber = 1;    // シフト演算に使う2進数の'1'
        private static int assignShiftCalcResult;  // シフト演算の結果をここに代入していく。

        public static int AssignShiftCalcResult
        {
            get => assignShiftCalcResult;
            set => assignShiftCalcResult = value;
        }

        /// <summary>
        /// プレイヤーの出した手を用いてシフト演算を行う
        /// </summary>
        /// <param name="playersHandArray">プレイヤー、コンピュータの手が格納された配列</param>
        public void PlayersShiftCalc(int[] playersHandArray)
        {
            for (int i = 0; i < playersHandArray.Length; i++)
            {
                AssignShiftCalcResult |= ShiftNumber << playersHandArray[i];
            }
        }
    }
}

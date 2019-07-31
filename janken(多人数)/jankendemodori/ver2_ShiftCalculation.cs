namespace Janken
{
    /// <summary>
    /// 論理和によるシフト演算を行いじゃんけんのどの手が出たかを算出する。
    /// </summary>
    class ShiftCalculation
    {
        static public int shiftCalc;  // シフト演算の結果をここに代入していく。
        private const int shiftNumber = 1;    // シフト演算に使う2進数の'1'

        /// <summary>
        /// プレイヤー出した手に対してシフト演算を行う。
        /// </summary>
        public void playerShiftCalc()
        {
            for (int p = 0; p < Jankenmain.playerHandArray.Length; p++)
            {
                shiftCalc |= shiftNumber << Jankenmain.playerHandArray[p];
            }
        }

        /// <summary>
        /// コンピュータの出した手に対してシフト演算を行う。
        /// </summary>
        public void cpShiftCalc()
        {
            for (int q = 0; q < Jankenmain.computerHandArray.Length; q++)
            {
                shiftCalc |= shiftNumber << Jankenmain.computerHandArray[q];
            }
        }
    }
}

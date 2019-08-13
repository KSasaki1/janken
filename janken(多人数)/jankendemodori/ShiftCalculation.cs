namespace Janken
{
    /// <summary>
    /// 論理和によるシフト演算を行いじゃんけんのどの手が出たかを算出する。
    /// </summary>
    public class ShiftCalculation
    {
        private const int ShiftNumber = 1;    // シフト演算に使う2進数の'1'
        private static int shiftCalc;  // シフト演算の結果をここに代入していく。

        public static int ShiftCalc
        {
            get => shiftCalc;
            set => shiftCalc = value;
        }

        /// <summary>
        /// プレイヤー出した手に対してシフト演算を行う。
        /// </summary>
        public void PlayerShiftCalc()
        {
            for (int p = 0; p < MakeHandArray.PlayerHandArray.Length; p++)
            {
                ShiftCalc |= ShiftNumber << MakeHandArray.PlayerHandArray[p];
            }
        }

        /// <summary>
        /// コンピュータの出した手に対してシフト演算を行う。
        /// </summary>
        public void CPShiftCalc()
        {
            for (int q = 0; q < MakeHandArray.ComputerHandArray.Length; q++)
            {
                ShiftCalc |= ShiftNumber << MakeHandArray.ComputerHandArray[q];
            }
        }
    }
}

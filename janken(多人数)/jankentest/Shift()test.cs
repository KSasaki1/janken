namespace jankentest
{
    using Janken;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
    public class ShiftTest
    {
        [TestMethod]
        [Description("Shiftcalclationのテスト1")]
        public void TestMethod1()
        {
            int[] testAllRock = { 1, 1, 1 };
            int[] testAllPaper = { 2, 2, 2 };
            int[] testAllScissors = { 3, 3, 3 };
            int[] testWinRock = { 1, 3, 3 };
            int[] testWinPaper = { 2, 1, 1 };
            int[] testWinScissors = { 3, 2, 2 };
            int[] testAllHand = { 1, 2, 3 };

            int resultAllRock = 2;
            int resultAllPaper = 4;
            int resultWinPaper = 6;
            int resultAllScissors = 8;
            int resultWinRock = 10;
            int resultWinScissors = 12;
            int resultAllHand = 14;

            ShiftCalculation shift = new ShiftCalculation();

            shift.PlayersShiftCalc(testAllHand);
            Assert.IsTrue(ShiftCalculation.AssignShiftCalcResult == resultAllHand, "使用された配列allhandに対して計算結果が異なります。");
            ShiftCalculation.AssignShiftCalcResult = 0;

            shift.PlayersShiftCalc(testAllRock);
            Assert.IsTrue(ShiftCalculation.AssignShiftCalcResult == resultAllRock, "使用された配列allrockに対して計算結果が異なります。");
            ShiftCalculation.AssignShiftCalcResult = 0;

            shift.PlayersShiftCalc(testAllPaper);
            Assert.IsTrue(ShiftCalculation.AssignShiftCalcResult == resultAllPaper, "使用された配列allpaperに対して計算結果が異なります。");
            ShiftCalculation.AssignShiftCalcResult = 0;

            shift.PlayersShiftCalc(testAllScissors);
            Assert.IsTrue(ShiftCalculation.AssignShiftCalcResult == resultAllScissors, "使用された配列allscissorsに対して計算結果が異なります。");
            ShiftCalculation.AssignShiftCalcResult = 0;

            shift.PlayersShiftCalc(testWinRock);
            Assert.IsTrue(ShiftCalculation.AssignShiftCalcResult == resultWinRock, "使用された配列winrockに対して計算結果が異なります。");
            ShiftCalculation.AssignShiftCalcResult = 0;

            shift.PlayersShiftCalc(testWinPaper);
            Assert.IsTrue(ShiftCalculation.AssignShiftCalcResult == resultWinPaper, "使用された配列winpaperに対して計算結果が異なります。");
            ShiftCalculation.AssignShiftCalcResult = 0;

            shift.PlayersShiftCalc(testWinScissors);
            Assert.IsTrue(ShiftCalculation.AssignShiftCalcResult == resultWinScissors, "使用された配列winscissorsに対して計算結果が異なります。");
            ShiftCalculation.AssignShiftCalcResult = 0;
        }
    }
}

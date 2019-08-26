<<<<<<< HEAD
﻿namespace jankentest
{
    using Janken;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Janken;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace jankentest
{
>>>>>>> ba38683fb80b5bea609cbe938fcce2ede792943c
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
<<<<<<< HEAD

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
=======
            shift.PlayersShiftCalc(testAllHand);
            Assert.IsTrue(ShiftCalculation.AssignShiftCalcResult == resultAllHand, "使用された配列allhandに対して計算結果が異なります。");

            //ShiftCalculation shift2 = new ShiftCalculation();
            //shift2.PlayersShiftCalc(testAllRock);
            //Assert.IsTrue(ShiftCalculation.AssignShiftCalcResult == resultAllRock, "使用された配列allrockに対して計算結果が異なります。");

            //ShiftCalculation shift3 = new ShiftCalculation();
            //shift3.PlayersShiftCalc(testAllPaper);
            //Assert.IsTrue(ShiftCalculation.AssignShiftCalcResult == resultAllPaper, "使用された配列allpaperに対して計算結果が異なります。");

            //ShiftCalculation shift4 = new ShiftCalculation();
            //shift4.PlayersShiftCalc(testAllScissors);
            //Assert.IsTrue(ShiftCalculation.AssignShiftCalcResult == resultAllScissors, "使用された配列allscissorsに対して計算結果が異なります。");

            //ShiftCalculation shift5 = new ShiftCalculation();
            //shift5.PlayersShiftCalc(testWinRock);
            //Assert.IsTrue(ShiftCalculation.AssignShiftCalcResult == resultWinRock, "使用された配列winrockに対して計算結果が異なります。");

            //ShiftCalculation shift6 = new ShiftCalculation();
            //shift6.PlayersShiftCalc(testWinPaper);
            //Assert.IsTrue(ShiftCalculation.AssignShiftCalcResult == resultWinPaper, "使用された配列winpaperに対して計算結果が異なります。");

            //ShiftCalculation shift7 = new ShiftCalculation();
            //shift7.PlayersShiftCalc(testWinScissors);
            //Assert.IsTrue(ShiftCalculation.AssignShiftCalcResult == resultWinScissors, "使用された配列winscissorsに対して計算結果が異なります。");
>>>>>>> ba38683fb80b5bea609cbe938fcce2ede792943c
        }
    }
}

using System;
using Janken;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace jankentest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [Description("コンピュータのみの勝負")]
        public void TestMethod1()
        {
            string resultfile = "Result.txt";
            

            if (System.IO.File.Exists(resultfile))
            {
                System.IO.File.Delete(resultfile);
            }

            Console.SetIn(new System.IO.StreamReader("../../inputJankenTest.txt"));

            Jankenmain.Main();

            Assert.IsTrue(System.IO.File.Exists(resultfile), "結果ファイル作成失敗");
        }
    }
}

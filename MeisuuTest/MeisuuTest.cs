using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Meisuu;

namespace MeisuuTest
{
    [TestClass]
    public class MeisuuTest
    {
        [TestMethod]
        public void Under100()
        {
            decimal result;
            Assert.IsFalse(JapaneseKansuuji.TryParse("", out result));
            Assert.IsTrue(JapaneseKansuuji.TryParse("零", out result));
            Assert.AreEqual(0m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("一", out result));
            Assert.AreEqual(1m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("二", out result));
            Assert.AreEqual(2m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("十", out result));
            Assert.AreEqual(10m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("十三", out result));
            Assert.AreEqual(13m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("一十", out result));
            Assert.AreEqual(10m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四十", out result));
            Assert.AreEqual(40m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四十五", out result));
            Assert.AreEqual(45m, result);
        }

        [TestMethod]
        public void Under1000()
        {
            decimal result;
            Assert.IsTrue(JapaneseKansuuji.TryParse("百", out result));
            Assert.AreEqual(100m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("百三", out result));
            Assert.AreEqual(103m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("一百", out result));
            Assert.AreEqual(100m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四百", out result));
            Assert.AreEqual(400m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四百五", out result));
            Assert.AreEqual(405m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("百六十", out result));
            Assert.AreEqual(160m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四百七十", out result));
            Assert.AreEqual(470m, result);
        }

        [TestMethod]
        public void Under10000()
        {
            decimal result;
            Assert.IsTrue(JapaneseKansuuji.TryParse("千", out result));
            Assert.AreEqual(1000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("千三", out result));
            Assert.AreEqual(1003m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("一千", out result));
            Assert.AreEqual(1000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四千", out result));
            Assert.AreEqual(4000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四千五", out result));
            Assert.AreEqual(4005m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("千六十", out result));
            Assert.AreEqual(1060m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四千七十", out result));
            Assert.AreEqual(4070m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四千七百", out result));
            Assert.AreEqual(4700m, result);
        }

        [TestMethod]
        public void Under10m()
        {
            decimal result;
            Assert.IsFalse(JapaneseKansuuji.TryParse("万", out result));
            Assert.IsFalse(JapaneseKansuuji.TryParse("万三", out result));
            Assert.IsTrue(JapaneseKansuuji.TryParse("一万", out result));
            Assert.AreEqual(10000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四万", out result));
            Assert.AreEqual(40000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四万五百", out result));
            Assert.AreEqual(40500m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("六十万七千", out result));
            Assert.AreEqual(607000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("八千九十万百", out result));
            Assert.AreEqual(80900100m, result);
            Assert.IsFalse(JapaneseKansuuji.TryParse("九十八千万", out result));
        }

        [TestMethod]
        public void Under10t()
        {
            decimal result;
            Assert.IsFalse(JapaneseKansuuji.TryParse("兆", out result));
            Assert.IsFalse(JapaneseKansuuji.TryParse("兆三", out result));
            Assert.IsTrue(JapaneseKansuuji.TryParse("一兆", out result));
            Assert.AreEqual(1000000000000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四兆", out result));
            Assert.AreEqual(4000000000000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四兆五百", out result));
            Assert.AreEqual(4000000000500m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("六十兆七千", out result));
            Assert.AreEqual(60000000007000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("八千九十兆百", out result));
            Assert.AreEqual(8090000000000100m, result);
            Assert.IsFalse(JapaneseKansuuji.TryParse("九十八千兆", out result));
        }

        [TestMethod]
        public void Under10t2()
        {
            decimal result;
            Assert.IsFalse(JapaneseKansuuji.TryParse("京一万", out result));
            Assert.IsFalse(JapaneseKansuuji.TryParse("三京万", out result));
            Assert.IsTrue(JapaneseKansuuji.TryParse("一京二億", out result));
            Assert.AreEqual(10000000200000000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四京五百億", out result));
            Assert.AreEqual(40000050000000000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("六十京七千億", out result));
            Assert.AreEqual(600000700000000000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("八千九十京百億", out result));
            Assert.AreEqual(80900000010000000000m, result);
            Assert.IsFalse(JapaneseKansuuji.TryParse("九十八千京億", out result));
        }
    }
}

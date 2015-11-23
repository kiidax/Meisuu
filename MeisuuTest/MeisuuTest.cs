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
            ulong result;
            Assert.IsFalse(JapaneseKansuuji.TryParse("", out result));
            Assert.IsTrue(JapaneseKansuuji.TryParse("零", out result));
            Assert.AreEqual(0ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("一", out result));
            Assert.AreEqual(1ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("二", out result));
            Assert.AreEqual(2ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("十", out result));
            Assert.AreEqual(10ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("十三", out result));
            Assert.AreEqual(13ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("一十", out result));
            Assert.AreEqual(10ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四十", out result));
            Assert.AreEqual(40ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四十五", out result));
            Assert.AreEqual(45ul, result);
        }

        [TestMethod]
        public void Under1000()
        {
            ulong result;
            Assert.IsTrue(JapaneseKansuuji.TryParse("百", out result));
            Assert.AreEqual(100ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("百三", out result));
            Assert.AreEqual(103ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("一百", out result));
            Assert.AreEqual(100ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四百", out result));
            Assert.AreEqual(400ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四百五", out result));
            Assert.AreEqual(405ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("百六十", out result));
            Assert.AreEqual(160ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四百七十", out result));
            Assert.AreEqual(470ul, result);
        }

        [TestMethod]
        public void Under10000()
        {
            ulong result;
            Assert.IsTrue(JapaneseKansuuji.TryParse("千", out result));
            Assert.AreEqual(1000ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("千三", out result));
            Assert.AreEqual(1003ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("一千", out result));
            Assert.AreEqual(1000ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四千", out result));
            Assert.AreEqual(4000ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四千五", out result));
            Assert.AreEqual(4005ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("千六十", out result));
            Assert.AreEqual(1060ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四千七十", out result));
            Assert.AreEqual(4070ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四千七百", out result));
            Assert.AreEqual(4700ul, result);
        }

        [TestMethod]
        public void Under10m()
        {
            ulong result;
            Assert.IsFalse(JapaneseKansuuji.TryParse("万", out result));
            Assert.IsFalse(JapaneseKansuuji.TryParse("万三", out result));
            Assert.IsTrue(JapaneseKansuuji.TryParse("一万", out result));
            Assert.AreEqual(10000ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四万", out result));
            Assert.AreEqual(40000ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四万五百", out result));
            Assert.AreEqual(40500ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("六十万七千", out result));
            Assert.AreEqual(607000ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("八千九十万百", out result));
            Assert.AreEqual(80900100ul, result);
            Assert.IsFalse(JapaneseKansuuji.TryParse("九十八千万", out result));
        }

        [TestMethod]
        public void Under10t()
        {
            ulong result;
            Assert.IsFalse(JapaneseKansuuji.TryParse("兆", out result));
            Assert.IsFalse(JapaneseKansuuji.TryParse("兆三", out result));
            Assert.IsTrue(JapaneseKansuuji.TryParse("一兆", out result));
            Assert.AreEqual(1000000000000ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四兆", out result));
            Assert.AreEqual(4000000000000ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四兆五百", out result));
            Assert.AreEqual(4000000000500ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("六十兆七千", out result));
            Assert.AreEqual(60000000007000ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("八千九十兆百", out result));
            Assert.AreEqual(8090000000000100ul, result);
            Assert.IsFalse(JapaneseKansuuji.TryParse("九十八千兆", out result));
        }

        [TestMethod]
        public void Under10t2()
        {
            ulong result;
            Assert.IsFalse(JapaneseKansuuji.TryParse("京一万", out result));
            Assert.IsFalse(JapaneseKansuuji.TryParse("三京万", out result));
            Assert.IsTrue(JapaneseKansuuji.TryParse("一京二億", out result));
            Assert.AreEqual(10000000200000000ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四京五百億", out result));
            Assert.AreEqual(40000050000000000ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("六十京七千億", out result));
            Assert.AreEqual(600000700000000000ul, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("八千九十京百億", out result));
            Assert.AreEqual(809000000010000000000ul, result);
            Assert.IsFalse(JapaneseKansuuji.TryParse("九十八千京億", out result));
            decimal.MaxValue
        }
    }
}

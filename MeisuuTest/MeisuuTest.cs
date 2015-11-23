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
            Assert.IsFalse(JapaneseKansuuji.TryParse("", 0L, out result));
            Assert.IsTrue(JapaneseKansuuji.TryParse("零", 0L, out result));
            Assert.AreEqual(0m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("一", 0L, out result));
            Assert.AreEqual(1m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("二", 0L, out result));
            Assert.AreEqual(2m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("十", 0L, out result));
            Assert.AreEqual(10m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("十三", 0L, out result));
            Assert.AreEqual(13m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("一十", 0L, out result));
            Assert.AreEqual(10m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四十", 0L, out result));
            Assert.AreEqual(40m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四十五", 0L, out result));
            Assert.AreEqual(45m, result);
        }

        [TestMethod]
        public void Under1000()
        {
            decimal result;
            Assert.IsTrue(JapaneseKansuuji.TryParse("百", 0L, out result));
            Assert.AreEqual(100m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("百三", 0L, out result));
            Assert.AreEqual(103m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("一百", 0L, out result));
            Assert.AreEqual(100m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四百", 0L, out result));
            Assert.AreEqual(400m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四百五", 0L, out result));
            Assert.AreEqual(405m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("百六十", 0L, out result));
            Assert.AreEqual(160m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四百七十", 0L, out result));
            Assert.AreEqual(470m, result);
        }

        [TestMethod]
        public void Under10000()
        {
            decimal result;
            Assert.IsTrue(JapaneseKansuuji.TryParse("千", 0L, out result));
            Assert.AreEqual(1000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("千三", 0L, out result));
            Assert.AreEqual(1003m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("一千", 0L, out result));
            Assert.AreEqual(1000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四千", 0L, out result));
            Assert.AreEqual(4000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四千五", 0L, out result));
            Assert.AreEqual(4005m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("千六十", 0L, out result));
            Assert.AreEqual(1060m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四千七十", 0L, out result));
            Assert.AreEqual(4070m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四千七百", 0L, out result));
            Assert.AreEqual(4700m, result);
        }

        [TestMethod]
        public void Under10m()
        {
            decimal result;
            Assert.IsFalse(JapaneseKansuuji.TryParse("万", 0L, out result));
            Assert.IsFalse(JapaneseKansuuji.TryParse("万三", 0L, out result));
            Assert.IsTrue(JapaneseKansuuji.TryParse("一万", 0L, out result));
            Assert.AreEqual(10000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四万", 0L, out result));
            Assert.AreEqual(40000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四万五百", 0L, out result));
            Assert.AreEqual(40500m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("六十万七千", 0L, out result));
            Assert.AreEqual(607000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("八千九十万百", 0L, out result));
            Assert.AreEqual(80900100m, result);
            Assert.IsFalse(JapaneseKansuuji.TryParse("九十八千万", 0L, out result));
        }

        [TestMethod]
        public void Under10t()
        {
            decimal result;
            Assert.IsFalse(JapaneseKansuuji.TryParse("兆", 0L, out result));
            Assert.IsFalse(JapaneseKansuuji.TryParse("兆三", 0L, out result));
            Assert.IsTrue(JapaneseKansuuji.TryParse("一兆", 0L, out result));
            Assert.AreEqual(1000000000000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四兆", 0L, out result));
            Assert.AreEqual(4000000000000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四兆五百", 0L, out result));
            Assert.AreEqual(4000000000500m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("六十兆七千", 0L, out result));
            Assert.AreEqual(60000000007000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("八千九十兆百", 0L, out result));
            Assert.AreEqual(8090000000000100m, result);
            Assert.IsFalse(JapaneseKansuuji.TryParse("九十八千兆", 0L, out result));
        }

        [TestMethod]
        public void Under10t2()
        {
            decimal result;
            Assert.IsFalse(JapaneseKansuuji.TryParse("京一万", 0L, out result));
            Assert.IsFalse(JapaneseKansuuji.TryParse("三京万", 0L, out result));
            Assert.IsTrue(JapaneseKansuuji.TryParse("一京二億", 0L, out result));
            Assert.AreEqual(10000000200000000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("四京五百億", 0L, out result));
            Assert.AreEqual(40000050000000000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("六十京七千億", 0L, out result));
            Assert.AreEqual(600000700000000000m, result);
            Assert.IsTrue(JapaneseKansuuji.TryParse("八千九十京百億", 0L, out result));
            Assert.AreEqual(80900000010000000000m, result);
            Assert.IsFalse(JapaneseKansuuji.TryParse("九十八千京億", 0L, out result));
        }

        [TestMethod]
        public void MaxValue()
        {
            decimal result;
            Assert.IsTrue(JapaneseKansuuji.TryParse("七穣九千杼三垓", 0L, out result));
            Assert.AreEqual(79000000300000000000000000000m, result);
            Assert.IsFalse(JapaneseKansuuji.TryParse("八穣", 0L, out result));
            try { JapaneseKansuuji.Parse("八穣", 0L); Assert.Fail(); } catch (OverflowException) { }
            try { JapaneseKansuuji.Parse("八千穣", 0L); Assert.Fail(); } catch (OverflowException) { }
            try { JapaneseKansuuji.Parse("七穣九千三百杼", 0L); Assert.Fail(); } catch (OverflowException) { }
            try { JapaneseKansuuji.Parse("七穣九千二百二十八杼千六百二十五垓千四百二十六京四千三百三十七兆五千九百三十五億四千三百九十五万三百三十六", 0L); Assert.Fail(); } catch (OverflowException) { }
            Assert.IsTrue(JapaneseKansuuji.TryParse("七穣九千二百二十八杼千六百二十五垓千四百二十六京四千三百三十七兆五千九百三十五億四千三百九十五万三百三十五", 0L, out result));
            Assert.AreEqual(79228162514264337593543950335m, result);
        }

        [TestMethod]
        public void Wrapper()
        {
            decimal result;
            try { JapaneseKansuuji.Parse("", 0L); Assert.Fail(); } catch (FormatException) { }
            try { JapaneseKansuuji.Parse("数", 0L); Assert.Fail(); } catch (FormatException) { }
            Assert.AreEqual(56m, JapaneseKansuuji.Parse("五十六", 0L));
            Assert.IsFalse(JapaneseKansuuji.TryParse("五十六数", 0L, out result));
            try { JapaneseKansuuji.Parse("五十六数", 0L); Assert.Fail(); } catch (FormatException) { }
        }

        [TestMethod]
        public void NotSupportedYet()
        {
            decimal result;
            try { JapaneseKansuuji.TryParse("", JapaneseKansuuji.UseArabicNumbers, out result); Assert.Fail(); } catch (NotSupportedException) { }
            try { JapaneseKansuuji.TryParse("", JapaneseKansuuji.UseDaijiNumbers, out result); Assert.Fail(); } catch (NotSupportedException) { }
        }
    }
}

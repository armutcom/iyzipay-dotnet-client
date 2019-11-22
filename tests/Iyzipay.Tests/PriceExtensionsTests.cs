using Armut.Iyzipay.Tests.Functional.Util;
using NUnit.Framework;

namespace Armut.Iyzipay.Tests
{
    public class PriceExtensionsTests
    {
        [Test]
        public void Should_Remove_Trailing_Zeros_From_Decimal_String()
        {
            Assert.AreEqual("0.028875", "0.02887500".RemoveTrailingZeros());
            Assert.AreEqual("0.25", "0.25000000".RemoveTrailingZeros());
            Assert.AreEqual("10", "10.00000000".RemoveTrailingZeros());
            Assert.AreEqual("10.0001", "10.00010000".RemoveTrailingZeros());
            Assert.AreEqual("0.02887500101", "0.02887500101000".RemoveTrailingZeros());
        }

        [Test]
        public void Should_Parse_Given_String_Price_To_Double()
        {
            Assert.AreEqual(0.0, "0.0".ParseDouble());
            Assert.AreEqual(1.0, "1.0".ParseDouble());
            Assert.AreEqual(1.00000, "1.00000".ParseDouble());
            Assert.AreEqual(1, "1.00000".ParseDouble());
            Assert.AreEqual(1.001, "1.001".ParseDouble());
            Assert.AreEqual(-1.0, "-1.0".ParseDouble());
            Assert.AreEqual(-1.00000, "-1.00000".ParseDouble());
            Assert.AreEqual(-1, "-1.00000".ParseDouble());
            Assert.AreEqual(-1.001, "-1.001".ParseDouble());
            Assert.AreEqual(10000.00001, "10000.00001".ParseDouble());
            Assert.AreEqual(-10000.00001, "-10000.00001".ParseDouble());
            Assert.AreEqual(0.028875, "0.02887500".ParseDouble());
            Assert.AreEqual(0.25, "0.25000000".ParseDouble());
            Assert.AreEqual(10, "10.00000000".ParseDouble());
            Assert.AreEqual(0.02887500, "0.02887500".ParseDouble());
            Assert.AreEqual(0.25000000, "0.25000000".ParseDouble());
            Assert.AreEqual(10.00000000, "10.00000000".ParseDouble());
        }

        [Test]
        public void Should_Parse_Given_String_Price_To_Decimal()
        {
            AssertDecimal.AreEqual(0.0M, "0.0".ParseDecimal());
            AssertDecimal.AreEqual(1.0M, "1.0".ParseDecimal());
            AssertDecimal.AreEqual(1.00000M, "1.00000".ParseDecimal());
            AssertDecimal.AreEqual(1M, "1.00000".ParseDecimal());
            AssertDecimal.AreEqual(1.001M, "1.001".ParseDecimal());
            AssertDecimal.AreEqual(-1.0M, "-1.0".ParseDecimal());
            AssertDecimal.AreEqual(-1.00000M, "-1.00000".ParseDecimal());
            AssertDecimal.AreEqual(-1, "-1.00000".ParseDecimal());
            AssertDecimal.AreEqual(-1.001M, "-1.001".ParseDecimal());
            AssertDecimal.AreEqual(10000.00001M, "10000.00001".ParseDecimal());
            AssertDecimal.AreEqual(-10000.00001M, "-10000.00001".ParseDecimal());
            AssertDecimal.AreEqual(0.02887500M, "0.02887500".ParseDecimal());
            AssertDecimal.AreEqual(0.25000000M, "0.25000000".ParseDecimal());
            AssertDecimal.AreEqual(10.00000000M, "10.00000000".ParseDecimal());
            AssertDecimal.AreEqual(10.000000001M, "10.000000001".ParseDecimal());
            AssertDecimal.AreEqual(99999999999999999999999999.99999999999999999999999M, "99999999999999999999999999.99999999999999999999999".ParseDecimal());
            AssertDecimal.AreEqual(-99999999999999999999999999.99999999999999999999999M, "-99999999999999999999999999.99999999999999999999999".ParseDecimal());
        }

        [Test]
        public void Should_Format_Given_Decimal_To_String()
        {
            Assert.AreEqual(0.0M.ToPrice(), "0.0");
            Assert.AreEqual(1.0M.ToPrice(), "1.0");
            Assert.AreEqual(1.00000M.ToPrice(), "1.00000");
            Assert.AreEqual(1M.ToPrice(), "1");
            Assert.AreEqual(1.001M.ToPrice(), "1.001");
            Assert.AreEqual((-1.0M).ToPrice(), "-1.0");
            Assert.AreEqual((-1.00000M).ToPrice(), "-1.00000");
            Assert.AreEqual((-1.001M).ToPrice(), "-1.001");
            Assert.AreEqual(10000.00001M.ToPrice(), "10000.00001");
            Assert.AreEqual((-10000.00001M).ToPrice(), "-10000.00001");
            Assert.AreEqual(0.02887500M.ToPrice(), "0.02887500");
            Assert.AreEqual(0.25000000M.ToPrice(), "0.25000000");
            Assert.AreEqual(10.00000000M.ToPrice(), "10.00000000");
            Assert.AreEqual(10.000000001M.ToPrice(), "10.000000001");
        }

        [Test]
        public void Should_Format_Given_Double_To_String()
        {
            Assert.AreEqual(0.0.ToPrice(), "0");
            Assert.AreEqual(1.0.ToPrice(), "1");
            Assert.AreEqual(1.00000.ToPrice(), "1");
            Assert.AreEqual(1.001.ToPrice(), "1.001");
            Assert.AreEqual((-1.0).ToPrice(), "-1");
            Assert.AreEqual((-1.00000).ToPrice(), "-1");
            Assert.AreEqual((-1.001).ToPrice(), "-1.001");
            Assert.AreEqual(10000.00001.ToPrice(), "10000.00001");
            Assert.AreEqual((-10000.00001).ToPrice(), "-10000.00001");
            Assert.AreEqual(0.028875.ToPrice(), "0.028875");
            Assert.AreEqual(0.25.ToPrice(), "0.25");
            Assert.AreEqual(0.02887500.ToPrice(), "0.028875");
            Assert.AreEqual(0.25000000.ToPrice(), "0.25");
            Assert.AreEqual(10.00000000.ToPrice(), "10");
        }
    }
}

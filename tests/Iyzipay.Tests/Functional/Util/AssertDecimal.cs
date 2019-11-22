using System;
using NUnit.Framework;

namespace Armut.Iyzipay.Tests.Functional.Util
{
    public static class AssertDecimal
    {
        public static void AreEqual(decimal a, decimal b, decimal diff = 0.0001M)
        {
            Assert.That(Math.Abs(a - b), Is.LessThan(diff));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Figures.Tests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowsOnNegativeRadius()
        {
            var circle = new Cirle(-42);
        }

        [TestMethod]
        public void ComputesArea()
        {
            var radius = 100;
            var circle = new Cirle(radius);

            var area = circle.ComputeArea();

            Assert.IsTrue(MathHelper.Equals(area, Math.PI * radius * radius));
        }
    }
}

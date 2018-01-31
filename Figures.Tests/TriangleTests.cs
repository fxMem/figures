using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Tests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowsOnNegativeSideValue()
        {
            var circle = Triangle.Create(-42, 10, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsOnNonExistingTriangle()
        {
            var circle = Triangle.Create(42, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowsOnUsingNonSquareTriangle()
        {
            var circle = new Triangle(42, 42, 42, new SquareTriangleMethod());

            circle.ComputeArea();
        }

        [TestMethod]
        public void ComputesAreaForSquareTriangle()
        {
            var data = GetSquareTriangle(new SquareTriangleMethod());

            var area = data.Triangle.ComputeArea();

            Assert.IsTrue(MathHelper.Equals(area, data.AreaValue));
        }

        [TestMethod]
        public void GeronAndSquareMethodsGiveSameResults()
        {
            var square = GetSquareTriangle(new SquareTriangleMethod());
            var geron = GetSquareTriangle(new GeronMethod());

            var squareArea = square.Triangle.ComputeArea();
            var geronArea = geron.Triangle.ComputeArea();

            Assert.IsTrue(MathHelper.Equals(squareArea, geronArea));
        }

        class TestTriangleData
        {
            public Triangle Triangle { get; set; }

            public double AreaValue { get; set; }
        }

        private TestTriangleData GetSquareTriangle(IComputeAreaMethod method)
        {
            var a = 10d;
            var b = 10d;
            var c = Math.Sqrt(a * a + b * b);
            return new TestTriangleData
            {
                Triangle = new Triangle(a, b, c, method),
                AreaValue = (a * b) / 2
            };
        }
    }
}

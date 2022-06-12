using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasyOjima.Bezier;
using EasyOjima.Video;
using System.Numerics;

namespace CubicEquationUnitTest {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            CubicEquation equation = new CubicEquation(1d, -6d, 12d, -8d);
            var sol = equation.Solutions;
            Assert.AreEqual(2d, sol[1].Real);
        }

        [TestMethod]
        public void TestMethod2() {
            CubicEquation equation = new CubicEquation(1d, -2d, 3d, -1d);
            var d = equation.P;
            Assert.AreEqual(d, 5.0/3.0);
        }

        [TestMethod]
        public void TestMethod3() {
            CubicEquation equation = new CubicEquation(1d, -3d, 0d, 4d);
            var sol = equation.Discriminant;
            Assert.AreEqual(0, sol);
        }

        [TestMethod]
        public void TestMethod4() {
            CubicEquation equation = new CubicEquation(1d, -2d, -1d, 2d);
            var sol = equation.Solutions;
            Assert.AreEqual(-1, sol[1].Real);
        }
    }
}

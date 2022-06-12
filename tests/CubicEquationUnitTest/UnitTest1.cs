using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasyOjima.Bezier;
using EasyOjima.Video;

namespace CubicEquationUnitTest {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            CubicEquation equation = new CubicEquation(1d, -6d, 12d, -8d);
            var sol = equation.Solutions;
            Assert.AreEqual(sol[1].Real, 2d);
        }

        [TestMethod]
        public void TestMethod2() {
            CubicEquation equation = new CubicEquation(1d, -2d, 3d, -1d);
            var d = equation._P;
            Assert.AreEqual(d, 5.0/3.0);
        }
    }
}

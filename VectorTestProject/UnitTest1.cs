using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorLibrary;
namespace VectorTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodisPositive()
        {
            var v = new Vector(111, -213, -313);
            Assert.IsTrue(true == v.X.isPositive());
            Assert.IsTrue(false == v.Y.isPositive());
        }
        [TestMethod]
        public void TestMethodInverse()
        {
            var v = new Vector(10, 5.1, 15.55);
            Assert.IsTrue(new Vector(-10, -5.1, -15.55) == v.Inverse());
        }
        [TestMethod]
        public void TestMethodisInteger()
        {
            var v = new Vector(11.1, -213, -31.3);
            Assert.IsTrue(false == v.X.isInteger());
            Assert.IsTrue(true == v.Y.isInteger());
        }
        [TestMethod]
        public void TestMethodZeroLength()
        {
            var v = new Vector(0, 0, 0);
            Assert.IsTrue(0 == v.Length());
        }
        [TestMethod]
        public void TestMethodGap()
        {
            var v = new Vector(21, 22, 12.2);
            var vr = new Vector(0, 2, 52.2);
            Assert.IsTrue(49.406 == Vector.Gap(v,vr));
        }
        [TestMethod]
        public void TestMethodToString()
        {
            var v = new Vector(2, 22, 12.2);
            Assert.IsTrue("Vector(2, 22, 12,2)" == v.ToString());
        }
        [TestMethod]
        public void TestMethodVectorPositive()
        {
            var v = new Vector(2, 22, 12.2);
            Assert.IsTrue(true == Vector.isPositive(v));
        }
        [TestMethod]
        public void TestMethodVectorInteger()
        {
            var v = new Vector(2, 22, 12);
            Assert.IsTrue(true == Vector.isInteger(v));
        }
        [TestMethod]
        public void TestMethodLength()
        {
            var v = new Vector(2, 22, 12);
            Assert.IsTrue(25.14 == v.Length());
        }
        [TestMethod]
        public void TestOperatorPlus()
        {
            var v = new Vector(2, 22, 12);
            Assert.IsTrue(new Vector(3, 24, 15) == v + new Vector(1, 2, 3));
        }
        [TestMethod]
        public void TestOperatorMinus()
        {
            var v = new Vector(2, 22, 12);
            Assert.IsTrue(new Vector(0, 20, 9) == v - new Vector(2, 2, 3));
        }
        [TestMethod]
        public void TestOperatorMultiply()
        {
            var v = new Vector(2, 22, 12);
            Assert.IsTrue(new Vector(42, 18, -40) == v * new Vector(2, 2, 3));
        }
        [TestMethod]
        public void TestMethodScalDobytok()
        {
            var v = new Vector(2, 22, 12);
            Assert.IsTrue(84 == Vector.scalDobytok(v , new Vector(2, 2, 3)));
        }
        [TestMethod]
        public void TestOperatorNotEqual()
        {
            var v = new Vector(2, 22, 12);
            Assert.IsTrue(new Vector(2, 18, -40) != v * new Vector(2, 2, 3));
        }
        [TestMethod]
        public void TestOperatorEqual()
        {
            var v = new Vector(2, 22, 12);
            Assert.IsTrue(new Vector(2, 22, 12) == v);
        }
        [TestMethod]
        public void TestMethodEqual()
        {
            var v = new Vector(2, 22, 12);
            Assert.IsTrue(true == v.Equals(new Vector(2, 22, 12)));
        }
        [TestMethod]
        public void TestMethodClone()
        {
            var v = new Vector(2, 22, 12);
            var clone = (Vector) v.Clone();
            Assert.IsTrue(clone == v);
            clone.X = 1;
            Assert.IsFalse(clone == v);
        }
        [TestMethod]
        public void TestMethodCompareTo()
        {
            var v = new Vector(2, 22, 12);
            
            Assert.IsTrue(0 == v.CompareTo(new Vector(2, 22, 12)));
            Assert.IsTrue(-1 == v.CompareTo(new Vector(15, 22, 12)));
            Assert.IsTrue(1 == v.CompareTo(new Vector(0, 22, 12)));
        }
        [TestMethod]
        public void TestConstructorSomebody()
        {
            var s = new Somebody(2, 5.1);
            var v = new Vector(2, 5.1, 0);
            Assert.IsTrue(v == s);
        }
    }
}

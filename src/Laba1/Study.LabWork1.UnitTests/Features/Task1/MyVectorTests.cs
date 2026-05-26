using NUnit.Framework;
using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.UnitTests.Features.Task1
{
    [TestFixture]
    public class MyVectorTests
    {
        [Test]
        public void OperatorPlus_AddsTwoVectors()
        {
            var v1 = new MyVector(1, 2);
            var v2 = new MyVector(3, 4);
            var result = v1 + v2;

            Assert.That(result.DirectionX, Is.EqualTo(4));
            Assert.That(result.DirectionY, Is.EqualTo(6));
        }

        [Test]
        public void OperatorPlus_WithZeroVector_ReturnsSameVector()
        {
            var v1 = new MyVector(5, -3);
            var zero = new MyVector(0, 0);
            var result = v1 + zero;

            Assert.That(result.DirectionX, Is.EqualTo(5));
            Assert.That(result.DirectionY, Is.EqualTo(-3));
        }

        [Test]
        public void OperatorMinus_SubtractsTwoVectors()
        {
            var v1 = new MyVector(5, 7);
            var v2 = new MyVector(2, 3);
            var result = v1 - v2;

            Assert.That(result.DirectionX, Is.EqualTo(3));
            Assert.That(result.DirectionY, Is.EqualTo(4));
        }

        [Test]
        public void OperatorMinus_WithZeroVector_ReturnsSameVector()
        {
            var v1 = new MyVector(4, -2);
            var zero = new MyVector(0, 0);
            var result = v1 - zero;

            Assert.That(result.DirectionX, Is.EqualTo(4));
            Assert.That(result.DirectionY, Is.EqualTo(-2));
        }

        [Test]
        public void OperatorMultiply_DotProduct_ReturnsCorrectValue()
        {
            var v1 = new MyVector(1, 2);
            var v2 = new MyVector(3, 4);
            float dot = v1 * v2;

            Assert.That(dot, Is.EqualTo(1 * 3 + 2 * 4));
        }

        [Test]
        public void OperatorMultiply_OrthogonalVectors_ReturnsZero()
        {
            var v1 = new MyVector(1, 0);
            var v2 = new MyVector(0, 1);
            float dot = v1 * v2;

            Assert.That(dot, Is.EqualTo(0));
        }

        [Test]
        public void OperatorEquality_EqualVectors_ReturnsTrue()
        {
            var v1 = new MyVector(2.5f, -1.5f);
            var v2 = new MyVector(2.5f, -1.5f);

            Assert.That(v1 == v2, Is.True);
        }

        [Test]
        public void OperatorEquality_DifferentVectors_ReturnsFalse()
        {
            var v1 = new MyVector(1, 2);
            var v2 = new MyVector(1, 3);

            Assert.That(v1 == v2, Is.False);
        }

        [Test]
        public void OperatorInequality_DifferentVectors_ReturnsTrue()
        {
            var v1 = new MyVector(0, 0);
            var v2 = new MyVector(0, 1);

            Assert.That(v1 != v2, Is.True);
        }

        [Test]
        public void OperatorInequality_EqualVectors_ReturnsFalse()
        {
            var v1 = new MyVector(3, 4);
            var v2 = new MyVector(3, 4);

            Assert.That(v1 != v2, Is.False);
        }

        [Test]
        public void UnaryPlus_ReturnsMagnitude()
        {
            var v = new MyVector(3, 4);
            float magnitude = +v;

            Assert.That(magnitude, Is.EqualTo(5).Within(1e-6));
        }

        [Test]
        public void UnaryPlus_ZeroVector_ReturnsZero()
        {
            var v = new MyVector(0, 0);
            float magnitude = +v;

            Assert.That(magnitude, Is.EqualTo(0));
        }

        [Test]
        public void UnaryPlus_NegativeComponents_ReturnsCorrectMagnitude()
        {
            var v = new MyVector(-3, -4);
            float magnitude = +v;

            Assert.That(magnitude, Is.EqualTo(5).Within(1e-6));
        }

        [Test]
        public void ToString_ZeroVector_ReturnsZeroCoordinates()
        {
            var v = new MyVector(0, 0);
            string result = v.ToString();

            Assert.That(result, Is.EqualTo("(0, 0)"));
        }
    }
}

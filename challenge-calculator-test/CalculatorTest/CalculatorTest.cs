using System;
using challenge_calculator;
using NUnit.Framework;

namespace Tests
{
    public class CalculatorTest
    {
        private Calculator sut;

        [SetUp]
        public void SetUp()
        {
            sut = new Calculator();
        }

        [Test]
        public void ShouldCountNonDigitsAsZero()
        {
            var args = new String[] {"1", "x"};
            sut.ParseList(args);

            Assert.That(sut.GetNumCount(), Is.EqualTo(2));
            Assert.That(sut.GetSum(), Is.EqualTo(1));
        }

        [Test]
        public void ShouldAcceptTwoDigitsInArgs()
        {
            var args = new String[] { "1", "3" };
            sut.ParseList(args);

            Assert.That(sut.GetNumCount(), Is.EqualTo(2));
        }

        [Test]
        public void ListWithNoDigitsShouldReturnZeroSum()
        {
            var args = new String[] { "x", "y" };
            sut.ParseList(args);

            Assert.That(sut.GetNumCount(), Is.EqualTo(2));
            Assert.That(sut.GetSum(), Is.EqualTo(0));
        }

        [Test]
        public void ParseIntReturnsZeroWhenNonDigit()
        {
            sut = new Calculator();

            Assert.That(sut.GetValidIntFromString("a"), Is.EqualTo(0));
        }

        [Test]
        public void ParseIntReturnsInt()
        {
            sut = new Calculator();

            Assert.That(sut.GetValidIntFromString("5"), Is.EqualTo(5));
        }

        [Test]
        public void CanAddAnyNumberOfArgs()
        {
            var args = new String[] { "1","2","3","4","5","6","7","8","9","10","11","12" };
            sut.ParseList(args);

            Assert.That(sut.GetNumCount(), Is.EqualTo(12));
            Assert.That(sut.GetSum(), Is.EqualTo(78));
        }

        [Test]
        public void ShouldThrowExceptionOnNegativeValue()
        {
            var args = new String[] { "1", "-3", "-12" };

            var result = Assert.Throws<Exception>(() => sut.ParseList(args));

            Assert.That(result.Message, Is.EqualTo("Negative numbers not allowed: -3, -12"));
        }

        [Test]
        public void ShouldSetNumbersOverOneThousandToZero()
        {
            var args = new String[] { "1", "1001" };
            sut.ParseList(args);

            Assert.That(sut.GetNumCount(), Is.EqualTo(2));
            Assert.That(sut.GetSum(), Is.EqualTo(1));
        }
    }
}
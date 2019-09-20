using System;
using challenge_calculator;
using NUnit.Framework;

namespace Tests
{
    public class CalculatorTest
    {
        private Calculator sut;
        [Test]
        public void ShouldCountNonDigitsAsZero()
        {
            var args = new String[] {"1", "x"};
            sut = new Calculator(args);

            Assert.That(sut.GetNumCount(), Is.EqualTo(2));
            Assert.That(sut.GetSum(), Is.EqualTo(1));
        }

        [Test]
        public void ShouldAcceptTwoDigitsInArgs()
        {
            var args = new String[] { "1", "3" };
            var sut = new Calculator(args);

            Assert.That(sut.GetNumCount(), Is.EqualTo(2));
        }

        [Test]
        public void ListWithNoDigitsShouldReturnZeroSum()
        {
            var args = new String[] { "x", "y" };
            sut = new Calculator(args);

            Assert.That(sut.GetNumCount(), Is.EqualTo(2));
            Assert.That(sut.GetSum(), Is.EqualTo(0));
        }

        [Test]
        public void ParseIntReturnsZeroWhenNonDigit()
        {
            sut = new Calculator(new string[0]);

            Assert.That(sut.TryParseInt("a"), Is.EqualTo(0));
        }

        [Test]
        public void ParseIntReturnsInt()
        {
            sut = new Calculator(new string[0]);

            Assert.That(sut.TryParseInt("5"), Is.EqualTo(5));
        }

        [Test]
        public void CanAddAnyNumberOfArgs()
        {
            var args = new String[] { "1","2","3","4","5","6","7","8","9","10","11","12" };
            sut = new Calculator(args);

            Assert.That(sut.GetNumCount(), Is.EqualTo(12));
            Assert.That(sut.GetSum(), Is.EqualTo(78));
        }
    }
}
using System;
using challenge_calculator;
using NUnit.Framework;

namespace Tests
{
    class InputFormatterTest
    {
        private InputFormatter sut;

        [Test]
        public void ShouldSplitStringOnComma()
        {
            sut = new InputFormatter();
            var result = sut.GetFormattedString("1,2,3");

            Assert.That(result, Has.Length.EqualTo(3));
        }

        [Test]
        public void ShouldSplitStringOnNewline()
        {
            sut = new InputFormatter();
            var result = sut.GetFormattedString("1\n2\n3");

            Assert.That(result, Has.Length.EqualTo(3));
        }

        [Test]
        public void ShouldSplitStringOnCommaAndNewline()
        {
            sut = new InputFormatter();
            var result = sut.GetFormattedString("1\n2,3");

            Assert.That(result, Has.Length.EqualTo(3));
        }
    }
}

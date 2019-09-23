using challenge_calculator;
using NUnit.Framework;

namespace Tests
{
    class InputFormatterTest
    {
        private InputFormatter sut;

        [SetUp]
        public void SetUp()
        {
            sut = new InputFormatter();
        }

        [Test]
        public void ShouldSplitStringOnComma()
        {
            var result = sut.GetNumListFromString("1,2,3");

            Assert.That(result, Has.Length.EqualTo(3));
        }

        [Test]
        public void ShouldSplitStringOnNewline()
        {
            var result = sut.GetNumListFromString("1\n2\n3");

            Assert.That(result, Has.Length.EqualTo(3));
        }

        [Test]
        public void ShouldSplitStringOnCommaAndNewline()
        {
            var result = sut.GetNumListFromString("1\n2,3");

            Assert.That(result, Has.Length.EqualTo(3));
        }

        [Test]
        public void ShouldSetCustomSingleCharDelim()
        {
            var result = sut.GetNumListFromString(@"//^\n2^3^4");

            Assert.That(result, Has.Length.EqualTo(3));
        }

        [Test]
        public void CustomDelimShouldWorkAlongsideDefaults()
        {
            var result = sut.GetNumListFromString(@"//^\n2^3,4\\n5");

            Assert.That(result, Has.Length.EqualTo(3));
        }

        [Test]
        public void ShouldSetCustomMultiCharDelim()
        {
            var result = sut.GetNumListFromString(@"//[**]\n2**3**4");

            Assert.That(result, Has.Length.EqualTo(3));
        }

        [Test]
        public void ShouldAllowMultipleMultiCharDelims()
        {
            var result = sut.GetNumListFromString(@"//[**][$$]\n2**3$$4");

            Assert.That(result, Has.Length.EqualTo(3));
        }

        [Test]
        public void MultiCharDelimsShouldWorkWithDefaults()
        {
            var result = sut.GetNumListFromString(@"//[**][$$]\n2**3$$4,5");

            Assert.That(result, Has.Length.EqualTo(4));
        }

        [Test]
        public void MultiCharDelimsOfVaryingLengthsShouldWork()
        {
            var result = sut.GetNumListFromString(@"//[**][$*$][a]\n2**3$*$4a5");

            Assert.That(result, Has.Length.EqualTo(4));
        }
    }
}

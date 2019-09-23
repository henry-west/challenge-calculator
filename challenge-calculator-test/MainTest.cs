using challenge_calculator;
using NUnit.Framework;

namespace Tests
{
    class MainTest
    {
        [Test]
        public void InputStringWithExistingCustomDelimAndDelimOptionShouldAddNewDelimCleanly()
        {
            var result = ChallengeCalculator.GetOrCreateInputStringFromArgs(@"//[a]\n1a2a3", "bbb");

            Assert.That(result, Is.EqualTo(@"//[bbb][a]\n1a2a3"));
        }

        [Test]
        public void CustomDelimOptionShouldAddDelimSectionToInputString()
        {
            var result = ChallengeCalculator.GetOrCreateInputStringFromArgs(@"1a2a3", "a");

            Assert.That(result, Is.EqualTo(@"//[a]\n1a2a3"));
        }

        [Test]
        public void NoCustomDelimOptionShouldReturnBaseInputString()
        {
            var result = ChallengeCalculator.GetOrCreateInputStringFromArgs(@"1a2a3", string.Empty);

            Assert.That(result, Is.EqualTo("1a2a3"));
        }
    }
}

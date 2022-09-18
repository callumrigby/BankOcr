using BankOcr.Console.AccountNumbers.Validator;

namespace BankOcr.Console.Tests.UserStories
{
    [TestFixture]
    public class UserStory2
    {
        [TestCase("711111111", true)]
        [TestCase("123456789", true)]
        [TestCase("490867715", true)]
        [TestCase("888888888", false)]
        [TestCase("490067715", false)]
        [TestCase("012345678", false)]
        public void Tests(string accountNumber, bool isValid)
        {
            var result = AccountNumberValidator.Validate(accountNumber);

            Assert.That(result, Is.EqualTo(isValid));
        }
    }
}

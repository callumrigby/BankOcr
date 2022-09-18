using BankOcr.Console.AccountNumbers.Reader;

namespace BankOcr.Console.Tests.UserStories
{
    public class UserStory3
    {
        [TestCase(@"
 _  _  _  _  _  _  _  _    
| || || || || || || ||_   |
|_||_||_||_||_||_||_| _|  |", "000000051")]
        [TestCase(@"
    _  _  _  _  _  _     _ 
|_||_|| || ||_   |  |  | _ 
  | _||_||_||_|  |  |  | _|", "49006771? ILL")]
        [TestCase(@"
    _  _     _  _  _  _  _ 
  | _| _||_| _ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _ ", "1234?678? ILL")]
        public void Tests(string input, string expectedResult)
        {
            var formattedInput = string.Concat(input.TrimStart('\n'), '\n');
            var accountNumbers = AccountNumberReader.Read(formattedInput).ToList();

            Assert.That(accountNumbers, Has.Count.EqualTo(1));
            Assert.That(accountNumbers[0].ToString(), Is.EqualTo(expectedResult));
        }
    }
}

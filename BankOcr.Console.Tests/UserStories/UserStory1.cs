using BankOcr.Console.AccountNumbers.Reader;

namespace BankOcr.Console.Tests.UserStories
{
    [TestFixture]
    public class UserStory1
    {
        [TestCase(@"
 _  _  _  _  _  _  _  _  _ 
| || || || || || || || || |
|_||_||_||_||_||_||_||_||_|", "000000000")]
        [TestCase(@"
 _                         
  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |", "711111111")] // Changed from original test case values after implementing auto-correction
        [TestCase(@"
 _  _  _  _  _  _  _  _  _ 
 _| _| _| _| _| _| _| _| _|
|_ |_ |_ |_ |_ |_ |_ |_ |_ ", "222222222")]
        [TestCase(@"
 _  _  _  _  _  _  _  _  _ 
 _| _| _| _||_| _| _| _| _|
 _| _| _| _| _| _| _| _| _|", "333393333")] // Changed from original test case values after implementing auto-correction
        [TestCase(@"
                           
|_||_||_||_||_||_||_||_||_|
  |  |  |  |  |  |  |  |  |", "444444444")]
        [TestCase(@"
 _  _  _  _  _  _  _  _  _ 
|_ |_ |_ |_ |_ |_ |_ |_ |_ 
 _| _| _| _| _| _| _| _| _|", "555555555")]
        [TestCase(@"
 _  _  _  _  _  _  _  _  _ 
|_ |_ |_ |_ |_ |_ |_ |_ |_ 
|_||_||_||_||_||_||_||_||_|", "666666666")]
        [TestCase(@"
 _  _  _  _  _  _     _  _ 
  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |", "777777177")] // Changed from original test case values after implementing auto-correction
        [TestCase(@"
 _  _  _  _  _  _  _  _  _ 
|_||_||_||_||_||_||_||_||_|
|_||_||_||_||_||_||_||_||_|", "888888888")]
        [TestCase(@"
 _  _  _  _  _  _  _  _  _ 
|_||_||_||_||_||_||_||_||_|
 _| _| _| _| _| _| _| _| _|", "999999999")]
        [TestCase(@"
    _  _     _  _  _  _  _ 
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _|", "123456789")]
        public void Tests(string input, string expectedResult)
        {
            var formattedInput = string.Concat(input.TrimStart('\n'), '\n');
            var accountNumbers = AccountNumberReader.Read(formattedInput).ToList();

            Assert.That(accountNumbers, Has.Count.EqualTo(1));
            Assert.That(accountNumbers[0].Value, Is.EqualTo(expectedResult));
        }
    }
}

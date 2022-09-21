using BankOcr.Console.AccountNumbers.Models;
using BankOcr.Console.AccountNumbers.Parser;

namespace BankOcr.Console.Tests.Parser
{
    [TestFixture]
    public class AccountNumberParserTests
    {
        private readonly static DigitalCharacter DigitalCharacterOne = new("   ", "  |", "  |");
        private readonly static DigitalCharacter DigitalCharacterTwo = new(" _ ", " _|", "|_ ");
        private readonly static DigitalCharacter DigitalCharacterThree = new(" _ ", " _|", " _|");
        private readonly static DigitalCharacter DigitalCharacterFour = new("   ", "|_|", "  |");
        private readonly static DigitalCharacter DigitalCharacterFive = new(" _ ", "|_ ", " _|");
        private readonly static DigitalCharacter DigitalCharacterSix = new(" _ ", "|_ ", "|_|");
        private readonly static DigitalCharacter DigitalCharacterSeven = new(" _ ", "  |", "  |");
        private readonly static DigitalCharacter DigitalCharacterEight = new(" _ ", "|_|", "|_|");
        private readonly static DigitalCharacter DigitalCharacterNine = new(" _ ", "|_|", " _|");

        [TestCase(@"
    _  _     _  _  _  _  _ 
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _|")]
        public void Parse_WhenInputIsValid_ReturnsParsedDigitalCharacters(string input)
        {
            var formattedInput = string.Concat(input.TrimStart('\n'), '\n');
            var digitalAccountNumbers = AccountNumberParser.Parse(formattedInput);

            Assert.That(digitalAccountNumbers, Has.Count.EqualTo(1));
            AssertDigitalCharacterLines(digitalAccountNumbers[0].Position1.OriginalValue, DigitalCharacterOne);
            AssertDigitalCharacterLines(digitalAccountNumbers[0].Position2.OriginalValue, DigitalCharacterTwo);
            AssertDigitalCharacterLines(digitalAccountNumbers[0].Position3.OriginalValue, DigitalCharacterThree);
            AssertDigitalCharacterLines(digitalAccountNumbers[0].Position4.OriginalValue, DigitalCharacterFour);
            AssertDigitalCharacterLines(digitalAccountNumbers[0].Position5.OriginalValue, DigitalCharacterFive);
            AssertDigitalCharacterLines(digitalAccountNumbers[0].Position6.OriginalValue, DigitalCharacterSix);
            AssertDigitalCharacterLines(digitalAccountNumbers[0].Position7.OriginalValue, DigitalCharacterSeven);
            AssertDigitalCharacterLines(digitalAccountNumbers[0].Position8.OriginalValue, DigitalCharacterEight);
            AssertDigitalCharacterLines(digitalAccountNumbers[0].Position9.OriginalValue, DigitalCharacterNine);
        }

        [TestCase(@"
    _  _     _  _  _  _  _ 
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _|

 _  _  _  _  _     _  _    
|_||_|  ||_ |_ |_| _| _|  |
 _||_|  ||_| _|  | _||_   |")]
        public void Parse_WhenInputIsValid_AndHasMultipleEntries_ReturnsParsedDigitalCharacters(string input)
        {
            var formattedInput = string.Concat(input.TrimStart('\n'), '\n');
            var digitalAccountNumbers = AccountNumberParser.Parse(formattedInput);

            Assert.That(digitalAccountNumbers, Has.Count.EqualTo(2));
            AssertDigitalCharacterLines(digitalAccountNumbers[0].Position1.OriginalValue, DigitalCharacterOne);
            AssertDigitalCharacterLines(digitalAccountNumbers[0].Position2.OriginalValue, DigitalCharacterTwo);
            AssertDigitalCharacterLines(digitalAccountNumbers[0].Position3.OriginalValue, DigitalCharacterThree);
            AssertDigitalCharacterLines(digitalAccountNumbers[0].Position4.OriginalValue, DigitalCharacterFour);
            AssertDigitalCharacterLines(digitalAccountNumbers[0].Position5.OriginalValue, DigitalCharacterFive);
            AssertDigitalCharacterLines(digitalAccountNumbers[0].Position6.OriginalValue, DigitalCharacterSix);
            AssertDigitalCharacterLines(digitalAccountNumbers[0].Position7.OriginalValue, DigitalCharacterSeven);
            AssertDigitalCharacterLines(digitalAccountNumbers[0].Position8.OriginalValue, DigitalCharacterEight);
            AssertDigitalCharacterLines(digitalAccountNumbers[0].Position9.OriginalValue, DigitalCharacterNine);

            AssertDigitalCharacterLines(digitalAccountNumbers[1].Position1.OriginalValue, DigitalCharacterNine);
            AssertDigitalCharacterLines(digitalAccountNumbers[1].Position2.OriginalValue, DigitalCharacterEight);
            AssertDigitalCharacterLines(digitalAccountNumbers[1].Position3.OriginalValue, DigitalCharacterSeven);
            AssertDigitalCharacterLines(digitalAccountNumbers[1].Position4.OriginalValue, DigitalCharacterSix);
            AssertDigitalCharacterLines(digitalAccountNumbers[1].Position5.OriginalValue, DigitalCharacterFive);
            AssertDigitalCharacterLines(digitalAccountNumbers[1].Position6.OriginalValue, DigitalCharacterFour);
            AssertDigitalCharacterLines(digitalAccountNumbers[1].Position7.OriginalValue, DigitalCharacterThree);
            AssertDigitalCharacterLines(digitalAccountNumbers[1].Position8.OriginalValue, DigitalCharacterTwo);
            AssertDigitalCharacterLines(digitalAccountNumbers[1].Position9.OriginalValue, DigitalCharacterOne);
        }

        private static void AssertDigitalCharacterLines(DigitalCharacter actual, DigitalCharacter expected)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actual.Line1, Is.EqualTo(expected.Line1));
                Assert.That(actual.Line2, Is.EqualTo(expected.Line2));
                Assert.That(actual.Line3, Is.EqualTo(expected.Line3));
            });
        }
    }
}

using System.Collections;
using BankOcr.Console.AccountNumbers.Characters;
using BankOcr.Console.AccountNumbers.Converter;
using BankOcr.Console.AccountNumbers.Models;

namespace BankOcr.Console.Tests.Converter
{
    class TestCases : IEnumerable
    {
        private readonly static DigitalAccountNumber TestCase1 = new(new List<DigitalAccountNumberDigit>
        {
            new DigitalAccountNumberDigit(Digits.One),
            new DigitalAccountNumberDigit(Digits.Two),
            new DigitalAccountNumberDigit(Digits.Three),
            new DigitalAccountNumberDigit(Digits.Four),
            new DigitalAccountNumberDigit(Digits.Five),
            new DigitalAccountNumberDigit(Digits.Six),
            new DigitalAccountNumberDigit(Digits.Seven),
            new DigitalAccountNumberDigit(Digits.Eight),
            new DigitalAccountNumberDigit(Digits.Nine)
        });

        private readonly static DigitalAccountNumber TestCase2 = new(new List<DigitalAccountNumberDigit>
        {
            new DigitalAccountNumberDigit(Digits.Nine),
            new DigitalAccountNumberDigit(Digits.Eight),
            new DigitalAccountNumberDigit(Digits.Seven),
            new DigitalAccountNumberDigit(Digits.Six),
            new DigitalAccountNumberDigit(Digits.Five),
            new DigitalAccountNumberDigit(Digits.Four),
            new DigitalAccountNumberDigit(Digits.Three),
            new DigitalAccountNumberDigit(Digits.Two),
            new DigitalAccountNumberDigit(Digits.One)
        });

        public IEnumerator GetEnumerator()
        {
            yield return new object[] { TestCase1, "123456789" };
            yield return new object[] { TestCase2, "987654321" };
        }
    }

    [TestFixture]
    public class AccountNumberConverterTests
    {

        [TestCaseSource(typeof(TestCases))]
        public void Convert_WhenDigitalAccountNumberContainsOnlyValidCharacters_ReturnsNumericAccountNumber(DigitalAccountNumber digitalAccountNumber, string expected)
        {
            var numericAccountNumber = AccountNumberConverter.Convert(digitalAccountNumber);

            Assert.That(numericAccountNumber.Value, Is.EqualTo(expected));
        }
    }
}

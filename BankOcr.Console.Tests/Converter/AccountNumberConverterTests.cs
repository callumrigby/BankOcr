using System.Collections;
using BankOcr.Console.AccountNumbers.Characters;
using BankOcr.Console.AccountNumbers.Converter;
using BankOcr.Console.AccountNumbers.Models;

namespace BankOcr.Console.Tests.Converter
{
    class TestCases : IEnumerable
    {
        private readonly static DigitalAccountNumber TestCase1 = new(new List<DigitalCharacter>
        {
            Digits.One,
            Digits.Two,
            Digits.Three,
            Digits.Four,
            Digits.Five,
            Digits.Six,
            Digits.Seven,
            Digits.Eight,
            Digits.Nine
        });

        private readonly static DigitalAccountNumber TestCase2 = new(new List<DigitalCharacter>
        {
            Digits.Nine,
            Digits.Eight,
            Digits.Seven,
            Digits.Six,
            Digits.Five,
            Digits.Four,
            Digits.Three,
            Digits.Two,
            Digits.One
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

            Assert.That(numericAccountNumber, Is.EqualTo(expected));
        }
    }
}

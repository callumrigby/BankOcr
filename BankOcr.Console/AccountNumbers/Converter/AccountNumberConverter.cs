using System.Text;
using BankOcr.Console.AccountNumbers.Characters;
using BankOcr.Console.AccountNumbers.Models;

namespace BankOcr.Console.AccountNumbers.Converter
{
    public class AccountNumberConverter
    {
        public static AccountNumber Convert(DigitalAccountNumber digitalAccountNumber)
        {
            var accountNumberBuilder = new StringBuilder();
            var accountNumberCharacters = digitalAccountNumber.ToList();
            for (int i = 0; i < accountNumberCharacters.Count; i++)
            {
                DigitalCharacter digitalCharacter = accountNumberCharacters[i];
                var (_, value) = Digits.NumericValues.FirstOrDefault((t) => CompareDigitalCharacters(t.character, digitalCharacter));

                var digit = value is null ? "?" : value;
                accountNumberBuilder.Append(digit);
            }

            return new AccountNumber(accountNumberBuilder.ToString());
        }

        private static bool CompareDigitalCharacters(DigitalCharacter character1, DigitalCharacter character2) =>
            character1.Line1 == character2.Line1 &&
            character1.Line2 == character2.Line2 &&
            character1.Line3 == character2.Line3;
    }
}

using BankOcr.Console.AccountNumbers.Characters;
using BankOcr.Console.AccountNumbers.Models;

namespace BankOcr.Console.AccountNumbers.Converter
{
    public class AccountNumberConverter
    {
        public static AccountNumber Convert(DigitalAccountNumber digitalAccountNumber)
        {
            var accountNumberDigits = new List<AccountNumberDigit>();
            var accountNumberCharacters = digitalAccountNumber.ToList();
            for (int i = 0; i < accountNumberCharacters.Count; i++)
            {
                var digitalDigit = accountNumberCharacters[i];
                var value = GetCharacterValue(digitalDigit.OriginalValue);
                var originalValue = value is null ? "?" : value;
                var possibleValues = GetPossibleCharacterValues(digitalDigit);
                accountNumberDigits.Add(new AccountNumberDigit(originalValue, possibleValues));
            }

            return new AccountNumber(accountNumberDigits);
        }

        private static List<string> GetPossibleCharacterValues(DigitalAccountNumberDigit digitalDigit)
        {
            var possibleValues = new List<string>();
            foreach (var character in digitalDigit.PossibleValues)
            {
                var value = GetCharacterValue(character);
                if (value is not null)
                {
                    possibleValues.Add(value);
                }
            }

            return possibleValues;
        }

        private static string? GetCharacterValue(DigitalCharacter character)
        {
            var (_, value) = Digits.NumericValues.FirstOrDefault((t) => CompareDigitalCharacters(t.character, character));
            return value;
        }

        private static bool CompareDigitalCharacters(DigitalCharacter character1, DigitalCharacter character2) =>
            character1.Line1 == character2.Line1 &&
            character1.Line2 == character2.Line2 &&
            character1.Line3 == character2.Line3;
    }
}

using System.Text;
using BankOcr.Console.AccountNumbers.Characters;
using BankOcr.Console.AccountNumbers.Models;

namespace BankOcr.Console.AccountNumbers.Converter
{
    public class AccountNumberConverter
    {
        public static string Convert(DigitalAccountNumber digitalAccountNumber)
        {
            var accountNumberBuilder = new StringBuilder();
            var accountNumberCharacters = digitalAccountNumber.ToList();
            for (int i = 0; i < accountNumberCharacters.Count; i++)
            {
                DigitalCharacter digitalCharacter = accountNumberCharacters[i];
                var (_, value) = Digits.NumericValues.FirstOrDefault((t) => CompareDigitalCharacters(t.character, digitalCharacter));

                if (value is null)
                {
                    throw new Exception($"Character at position {i + 1} is not a valid digit. Value:\n{digitalCharacter.Line1}\n{digitalCharacter.Line2}\n{digitalCharacter.Line3}");
                }

                accountNumberBuilder.Append(value);
            }

            return accountNumberBuilder.ToString();
        }

        private static bool CompareDigitalCharacters(DigitalCharacter character1, DigitalCharacter character2) =>
            character1.Line1 == character2.Line1 &&
            character1.Line2 == character2.Line2 &&
            character1.Line3 == character2.Line3;
    }
}

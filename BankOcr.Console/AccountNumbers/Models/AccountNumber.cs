using System.Text;
using BankOcr.Console.AccountNumbers.Validator;

namespace BankOcr.Console.AccountNumbers.Models
{
    public class AccountNumber
    {
        public AccountNumberStatus Status { get; }
        public string Value { get; }

        private readonly List<string> ambiguousAccountNumbers = new();

        public AccountNumber(List<AccountNumberDigit> accountNumberDigits)
        {
            var originalAccountNumber = string.Concat(accountNumberDigits.Select((d) => d.OriginalValue));
            var isIllegible = originalAccountNumber.Contains('?');
            var isValid = AccountNumberValidator.ValidateChecksum(originalAccountNumber);
            var hasUnreadableCharacter = accountNumberDigits.Any((d) => d.OriginalValue == "?" && d.PossibleValues.Count == 0);
            if (hasUnreadableCharacter)
            {
                Status = AccountNumberStatus.Illegible;
                Value = originalAccountNumber;
            }
            else if (isIllegible || !isValid)
            {
                var possibleAccountNumbers = GetPossibleAccountNumbers(accountNumberDigits);
                var validPossibleAccountNumbers = possibleAccountNumbers.Where((an) => AccountNumberValidator.ValidateChecksum(an)).ToList();
                if (validPossibleAccountNumbers.Count == 0)
                {
                    Status = isIllegible ? AccountNumberStatus.Illegible : AccountNumberStatus.Invalid;
                    Value = originalAccountNumber;
                }
                else if (validPossibleAccountNumbers.Count == 1)
                {
                    Status = AccountNumberStatus.Valid;
                    Value = validPossibleAccountNumbers[0];
                }
                else
                {
                    Status = AccountNumberStatus.Ambiguous;
                    Value = originalAccountNumber;
                    ambiguousAccountNumbers = validPossibleAccountNumbers;
                }
            }
            else
            {
                Status = AccountNumberStatus.Valid;
                Value = originalAccountNumber;
            }
        }

        private static List<string> GetPossibleAccountNumbers(List<AccountNumberDigit> accountNumberDigits)
        {
            var possibleAccountNumbers = new List<string>();
            for (int digitIndex = 0; digitIndex < accountNumberDigits.Count; digitIndex++)
            {
                foreach (var value in accountNumberDigits[digitIndex].PossibleValues)
                {
                    possibleAccountNumbers.Add(string.Concat(accountNumberDigits.Select((d, i) => digitIndex == i ? value : d.OriginalValue)));
                }
            }

            return possibleAccountNumbers;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(Value);
            if (Status != AccountNumberStatus.Valid)
            {
                sb.Append($" {GetAccountNumberStatusAbbreviation(Status)}");
                if (Status == AccountNumberStatus.Ambiguous)
                {
                    var formattedAccountNumbers = ambiguousAccountNumbers.OrderBy(int.Parse).Select((an) => $"'{an}'");
                    sb.Append($" [{string.Join(", ", formattedAccountNumbers)}]");
                }
            }

            return sb.ToString();
        }

        private static string GetAccountNumberStatusAbbreviation(AccountNumberStatus status) => status switch
        {
            AccountNumberStatus.Invalid => "ERR",
            AccountNumberStatus.Illegible => "ILL",
            AccountNumberStatus.Ambiguous => "AMB",
            _ => string.Empty,
        };
    }
}

using System.Text;
using BankOcr.Console.AccountNumbers.Validator;

namespace BankOcr.Console.AccountNumbers.Models
{
    public class AccountNumber
    {
        public bool IsIllegible { get; }
        public bool IsValid { get; }
        public string Value { get; }

        public AccountNumber(string accountNumber)
        {
            IsIllegible = accountNumber.Contains('?');
            IsValid = AccountNumberValidator.ValidateChecksum(accountNumber);
            Value = accountNumber;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(Value);
            if (IsIllegible || !IsValid)
            {
                sb.Append(' ');
                if (IsIllegible)
                {
                    sb.Append("ILL");
                }
                else if (!IsValid)
                {
                    sb.Append("ERR");
                }
            }

            return sb.ToString();
        }
    }
}

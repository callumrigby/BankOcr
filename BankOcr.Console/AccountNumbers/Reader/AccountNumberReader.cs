using BankOcr.Console.AccountNumbers.Converter;
using BankOcr.Console.AccountNumbers.Models;
using BankOcr.Console.AccountNumbers.Parser;

namespace BankOcr.Console.AccountNumbers.Reader
{
    public class AccountNumberReader
    {
        public static IEnumerable<AccountNumber> Read(string input)
        {
            var digitalAccountNumbers = AccountNumberParser.Parse(input);
            return digitalAccountNumbers.Select((d) => AccountNumberConverter.Convert(d));
        }
    }
}

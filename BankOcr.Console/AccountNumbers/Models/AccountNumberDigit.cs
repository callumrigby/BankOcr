namespace BankOcr.Console.AccountNumbers.Models
{
    public class AccountNumberDigit
    {
        public string OriginalValue { get; set; }
        public List<string> PossibleValues { get; set; }

        public AccountNumberDigit(string originalValue, List<string> possibleValues)
        {
            OriginalValue = originalValue;
            PossibleValues = possibleValues;
        }
    }
}

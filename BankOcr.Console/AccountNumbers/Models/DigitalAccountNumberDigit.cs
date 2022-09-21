namespace BankOcr.Console.AccountNumbers.Models
{
    public class DigitalAccountNumberDigit
    {
        public DigitalCharacter OriginalValue { get; }
        public List<DigitalCharacter> PossibleValues { get; }

        public DigitalAccountNumberDigit(DigitalCharacter originalValue) : this(originalValue, new List<DigitalCharacter>())
        {
        }

        public DigitalAccountNumberDigit(DigitalCharacter originalValue, List<DigitalCharacter> possibleValues)
        {
            OriginalValue = originalValue;
            PossibleValues = possibleValues;
        }
    }
}

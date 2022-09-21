namespace BankOcr.Console.AccountNumbers.Models
{
    public class DigitalAccountNumber
    {
        private const int AccountNumberLength = 9;

        public DigitalAccountNumber(List<DigitalAccountNumberDigit> digitalCharacters)
        {
            if (digitalCharacters.Count != AccountNumberLength)
            {
                throw new ArgumentException($"Account Numbers must be {AccountNumberLength} character long.");
            }

            Position1 = digitalCharacters[0];
            Position2 = digitalCharacters[1];
            Position3 = digitalCharacters[2];
            Position4 = digitalCharacters[3];
            Position5 = digitalCharacters[4];
            Position6 = digitalCharacters[5];
            Position7 = digitalCharacters[6];
            Position8 = digitalCharacters[7];
            Position9 = digitalCharacters[8];
        }

        public DigitalAccountNumberDigit Position1 { get; set; }
        public DigitalAccountNumberDigit Position2 { get; set; }
        public DigitalAccountNumberDigit Position3 { get; set; }
        public DigitalAccountNumberDigit Position4 { get; set; }
        public DigitalAccountNumberDigit Position5 { get; set; }
        public DigitalAccountNumberDigit Position6 { get; set; }
        public DigitalAccountNumberDigit Position7 { get; set; }
        public DigitalAccountNumberDigit Position8 { get; set; }
        public DigitalAccountNumberDigit Position9 { get; set; }

        public List<DigitalAccountNumberDigit> ToList() => new()
        {
            Position1,
            Position2,
            Position3,
            Position4,
            Position5,
            Position6,
            Position7,
            Position8,
            Position9,
        };
    }
}

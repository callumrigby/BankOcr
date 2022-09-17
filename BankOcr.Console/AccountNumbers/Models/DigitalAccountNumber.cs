namespace BankOcr.Console.AccountNumbers.Models
{
    public class DigitalAccountNumber
    {
        private const int AccountNumberLength = 9;

        public DigitalAccountNumber(List<DigitalCharacter> digitalCharacters)
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

        public DigitalCharacter Position1 { get; set; }
        public DigitalCharacter Position2 { get; set; }
        public DigitalCharacter Position3 { get; set; }
        public DigitalCharacter Position4 { get; set; }
        public DigitalCharacter Position5 { get; set; }
        public DigitalCharacter Position6 { get; set; }
        public DigitalCharacter Position7 { get; set; }
        public DigitalCharacter Position8 { get; set; }
        public DigitalCharacter Position9 { get; set; }

        public List<DigitalCharacter> ToList() => new()
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

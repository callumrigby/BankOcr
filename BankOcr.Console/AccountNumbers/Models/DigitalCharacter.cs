namespace BankOcr.Console.AccountNumbers.Models
{
    public class DigitalCharacter
    {
        public DigitalCharacter(string line1, string line2, string line3)
        {
            Line1 = line1;
            Line2 = line2;
            Line3 = line3;
        }

        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
    }
}

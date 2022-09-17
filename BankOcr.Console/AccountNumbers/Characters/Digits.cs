using BankOcr.Console.AccountNumbers.Models;

namespace BankOcr.Console.AccountNumbers.Characters
{
    public static class Digits
    {
        public readonly static DigitalCharacter Zero = new(
            " _ ",
            "| |",
            "|_|"
        );
        public readonly static DigitalCharacter One = new(
            "   ",
            "  |",
            "  |"
        );
        public readonly static DigitalCharacter Two = new(
            " _ ",
            " _|",
            "|_ "
        );
        public readonly static DigitalCharacter Three = new(
            " _ ",
            " _|",
            " _|"
        );
        public readonly static DigitalCharacter Four = new(
            "   ",
            "|_|",
            "  |"
        );
        public readonly static DigitalCharacter Five = new(
            " _ ",
            "|_ ",
            " _|"
        );
        public readonly static DigitalCharacter Six = new(
            " _ ",
            "|_ ",
            "|_|"
        );
        public readonly static DigitalCharacter Seven = new(
            " _ ",
            "  |",
            "  |"
        );
        public readonly static DigitalCharacter Eight = new(
            " _ ",
            "|_|",
            "|_|"
        );
        public readonly static DigitalCharacter Nine = new(
            " _ ",
            "|_|",
            " _|"
        );
        public readonly static List<(DigitalCharacter character, string value)> NumericValues = new()
        {
            (Zero, "0"),
            (One, "1"),
            (Two, "2"),
            (Three, "3"),
            (Four, "4"),
            (Five, "5"),
            (Six, "6"),
            (Seven, "7"),
            (Eight, "8"),
            (Nine, "9"),
        };
    }
}

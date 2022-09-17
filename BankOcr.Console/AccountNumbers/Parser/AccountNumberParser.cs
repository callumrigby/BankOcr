using BankOcr.Console.AccountNumbers.Models;

namespace BankOcr.Console.AccountNumbers.Parser
{
    public class AccountNumberParser
    {
        private const int EntryNumberOfLines = 4;
        private const int EntrySymbolLineLength = 27;
        private const int SymbolLength = 3;

        public static List<DigitalAccountNumber> Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException($"'{nameof(input)}' cannot be null or whitespace.", nameof(input));
            }

            var lines = input.Split('\n');
            if (lines.Length == 0 || lines.Length % EntryNumberOfLines != 0)
            {
                throw new Exception($"Input must contain at least one entry and each entry must be {EntryNumberOfLines} lines long.");
            }

            var digitalAccountNumbers = new List<DigitalAccountNumber>();
            for (int i = 0; i < lines.Length; i += EntryNumberOfLines)
            {
                ValidateEntry(lines, i);
                var digitalCharacters = ParseEntry(lines, i);
                digitalAccountNumbers.Add(new DigitalAccountNumber(digitalCharacters));
            }

            return digitalAccountNumbers;
        }

        private static void ValidateEntry(string[] lines, int offset)
        {
            ValidateAllSymbolLines(lines, offset);

            if (!ValidateTerminatingLine(lines[offset + EntryNumberOfLines - 1]))
            {
                throw new Exception($"All entry terminating lines must be blank. Line {offset + EntryNumberOfLines}.");
            }
        }

        private static void ValidateAllSymbolLines(string[] lines, int offset)
        {
            for (int i = 0; i < EntryNumberOfLines - 1; i++)
            {
                if (!ValidateSymbolLine(lines[offset + i]))
                {
                    throw new Exception($"All lines containing symbols must be {EntrySymbolLineLength} characters long. Line {offset + i + 1}.");
                }
            }
        }

        private static bool ValidateSymbolLine(string line) => line.Length == EntrySymbolLineLength;

        private static bool ValidateTerminatingLine(string line) => line == string.Empty;

        private static List<DigitalCharacter> ParseEntry(string[] lines, int offset)
        {
            var digitalCharacters = new List<DigitalCharacter>();
            for (int i = 0; i < EntrySymbolLineLength; i += SymbolLength)
            {
                var digitalCharacter = new DigitalCharacter(
                    ExtractSymbol(lines[offset], i),
                    ExtractSymbol(lines[offset + 1], i),
                    ExtractSymbol(lines[offset + 2], i)
                );
                digitalCharacters.Add(digitalCharacter);
            }

            return digitalCharacters;
        }

        private static string ExtractSymbol(string line, int index) => line.Substring(index, SymbolLength);
    }
}

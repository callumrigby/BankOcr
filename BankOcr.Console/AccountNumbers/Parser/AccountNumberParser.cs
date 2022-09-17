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
                for (int j = 0; j < EntryNumberOfLines - 1; j++)
                {
                    if (!ValidateSymbolLine(lines[i + j]))
                    {
                        throw new Exception($"All lines containing symbols must be {EntrySymbolLineLength} characters long. Line {i + j + 1}.");
                    }
                }

                if (!ValidateTerminatingLine(lines[i + EntryNumberOfLines - 1]))
                {
                    throw new Exception($"All entry terminating lines must be blank. Line {i + EntryNumberOfLines}.");
                }

                var digitalCharacters = new List<DigitalCharacter>();
                for (int j = 0; j < EntrySymbolLineLength; j += SymbolLength)
                {
                    var digitalCharacter = new DigitalCharacter(
                        lines[i].Substring(j, SymbolLength),
                        lines[i + 1].Substring(j, SymbolLength),
                        lines[i + 2].Substring(j, SymbolLength)
                    );
                    digitalCharacters.Add(digitalCharacter);
                }

                digitalAccountNumbers.Add(new DigitalAccountNumber(digitalCharacters));
            }

            return digitalAccountNumbers;
        }

        private static bool ValidateSymbolLine(string line) => line.Length == EntrySymbolLineLength;

        private static bool ValidateTerminatingLine(string line) => line == string.Empty;
    }
}

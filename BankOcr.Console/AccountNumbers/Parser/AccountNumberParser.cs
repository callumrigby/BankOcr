using System.Text;
using BankOcr.Console.AccountNumbers.Models;
using BankOcr.Console.Utils;

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

        private static List<DigitalAccountNumberDigit> ParseEntry(string[] lines, int offset)
        {
            var digits = new List<DigitalAccountNumberDigit>();
            for (int i = 0; i < EntrySymbolLineLength; i += SymbolLength)
            {
                string line1 = ExtractSymbol(lines[offset], i);
                string line2 = ExtractSymbol(lines[offset + 1], i);
                string line3 = ExtractSymbol(lines[offset + 2], i);
                var originalValue = new DigitalCharacter(
                    line1,
                    line2,
                    line3
                );

                var line1PossibleSymbols = GetPossibleSymbols(line1);
                var line2PossibleSymbols = GetPossibleSymbols(line2);
                var line3PossibleSymbols = GetPossibleSymbols(line3);
                var line1ChangedCharacters = line1PossibleSymbols.Select((s) => new DigitalCharacter(s, line2, line3));
                var line2ChangedCharacters = line2PossibleSymbols.Select((s) => new DigitalCharacter(line1, s, line3));
                var line3ChangedCharacters = line3PossibleSymbols.Select((s) => new DigitalCharacter(line1, line2, s));
                var possibleValues = line1ChangedCharacters.Concat(line2ChangedCharacters).Concat(line3ChangedCharacters).ToList();

                var digit = new DigitalAccountNumberDigit(originalValue, possibleValues);
                digits.Add(digit);
            }

            return digits;
        }

        private static string ExtractSymbol(string line, int index) => line.Substring(index, SymbolLength);

        private static List<string> GetPossibleSymbols(string line)
        {
            var possibleSymbols = new List<string>();
            var symbolCharacters = new List<char> { ' ', '_', '|' };
            for (int i = 0; i < SymbolLength; i++)
            {
                var substituteCharacters = symbolCharacters.Where((c) => c != line[i]);
                foreach (var character in substituteCharacters)
                {
                    possibleSymbols.Add(line.ReplaceAt(i, character));
                }
            }

            return possibleSymbols;
        }
    }
}

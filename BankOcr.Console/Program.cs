using BankOcr.Console.AccountNumbers.Reader;

if (args.Length == 0)
{
    Console.WriteLine("Must provide path to file containing account numbers.");
    return 1;
}

try
{
    string text = File.ReadAllText(args[0]);
    var accountNumbers = AccountNumberReader.Read(text);

    foreach (var accountNumber in accountNumbers)
    {
        Console.WriteLine(accountNumber);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error processing account numbers: {ex.Message}.");
    return 1;
}

return 0;

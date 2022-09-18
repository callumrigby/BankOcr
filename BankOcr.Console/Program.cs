using BankOcr.Console.AccountNumbers.Reader;

if (args.Length != 2)
{
    Console.WriteLine("Must provide path to file containing account numbers and an output file path.");
    return 1;
}

try
{
    string text = await File.ReadAllTextAsync(args[0]);
    var accountNumbers = AccountNumberReader.Read(text).ToList();
    var accountNumberLines = accountNumbers.Select((a) => a.ToString());
    await File.WriteAllLinesAsync(args[1], accountNumberLines);

    Console.WriteLine($"Successfully processed {accountNumbers.Count} account numbers.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error processing account numbers: {ex.Message}");
    return 1;
}

return 0;

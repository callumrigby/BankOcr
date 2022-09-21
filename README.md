# Bank OCR

This application processes files containing account numbers in a digital format and converts them to a numeric account number. The account numbers are validated using a checksum. If there are any issues with the account number (illegible or invalid), the application tries to find potential valid account numbers based on the original input. The results are written to a file at the specified output path.

## Prerequisites

You must have the .NET 6 SDK installed to build and run this project. You can download it [here](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).

## Running

To run the application using the dotnet CLI, use the following command from the project root.

```sh
dotnet run --project BankOcr.Console/BankOcr.Console.csproj -- <input-file-path> <output-file-path>
```

There are example input files in the [examples](./examples/) folder. For example

```sh
dotnet run --project BankOcr.Console/BankOcr.Console.csproj -- ./examples/user-story-4.txt ./out/results.txt
```

## Testing

To run all unit tests using the dotnet CLI, use the folling command from the project root.

```sh
dotnet test
```

namespace BankOcr.Console.AccountNumbers.Validator
{
    public class AccountNumberValidator
    {
        public static bool Validate(string accountNumber)
        {
            if (accountNumber.Length != 9)
            {
                return false;
            }

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                if (int.TryParse(accountNumber[i].ToString(), out var digit))
                {
                    var multiplier = 9 - i;
                    sum += digit * multiplier;
                }
                else
                {
                    return false;
                }
            }

            return sum % 11 == 0;
        }
    }
}

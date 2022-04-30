namespace BankApp;

public class Program
{
    public static void Main()
    {
        CSVUsersAndAccountsReader reader = new CSVUsersAndAccountsReader();
        Bank.Bank mBank = new Bank.Bank(reader);
        mBank.ReturnAllAccounts();
        Console.WriteLine("\n\n");
        mBank.ReturnAccountsOfAnUser(1);
    }
}


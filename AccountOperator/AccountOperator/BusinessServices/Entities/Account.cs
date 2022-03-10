namespace AccountOperator.BusinessServices.Entities;

public class Account
{
    private const double DepositFee = 0.99;

    private readonly Guid AccountUid;
    public decimal Balance;
    public List<StatementEntry> Statement;

    public Account(int balance, string ownerName)
    {
        AccountUid = new Guid();
        Balance = balance;
        Statement = new List<StatementEntry>();
    }

    public void Deposit(decimal amount, string source, double depositFee = DepositFee)
    {
        var operationFee = depositFee == 0 ? 1 : (decimal) depositFee;
        var depositNetAmount = amount * operationFee;
        Balance += depositNetAmount;
        Statement.Add(new StatementEntry(AccountUid, amount, "Deposit"));
    }

    public void Transfer(int amount, Account destination)
    {
        destination.Deposit(amount, $"Transfer from {AccountUid}", 0); 
        Balance -= amount;
        Statement.Add(new StatementEntry(AccountUid, -amount, $"Transfer to {destination.AccountUid.ToString()}"));
    }
    
    public void Withdrawn(int amount)
    {
        Balance -= amount;
        Statement.Add(new StatementEntry(AccountUid, -amount, "Withdrawn"));
    }
}
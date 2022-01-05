namespace AccountOperator.BusinessServices.Entities;

public class Account
{
    private const double DepositFee = 0.99;
    
    public Guid Uid;
    public decimal Balance;
    public List<StatementEntry> Statement;

    public Account(int balance, string ownerName)
    {
        Uid = new Guid();
        Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        var depositNetAmount = amount * (decimal) DepositFee;
        Balance += depositNetAmount;
        Statement.Add(new StatementEntry(Uid, amount, "Deposit"));
    }

    public void Transfer(int amount, Account destination)
    {
        Balance -= amount;
        destination.Balance += amount;
        Statement.Add(new StatementEntry(Uid, -amount, $"Transfer to {destination.Uid.ToString()}"));
        //bug here, destionation accountin does not have statement entry
    }
    
    public void Withdrawn(int amount)
    {
        Balance -= amount;
        Statement.Add(new StatementEntry(Uid, -amount, "Withdrawn"));
    }
}
namespace AccountOperator.BusinessServices.Entities;

public class Account
{
    private const double DepositFee = 0.99;
    
    public Guid Uid;
    public decimal Balance;
    public string OwnerName;
    public List<StatementEntry> Statement;

    public Account(int balance, string ownerName)
    {
        Uid = new Guid();
        Balance = balance;
        ownerName = ownerName;
    }

    public void Deposit(decimal amount)
    {
        var depositNetAmount = amount * (decimal) DepositFee;
        Balance += depositNetAmount;
    }

    public void Transfer(int amount, Account destination)
    {
        Balance -= amount;
        destination.Balance += amount;
    }
    
    public void Withdrawn(int amount)
    {
        Balance -= amount;
    }
}
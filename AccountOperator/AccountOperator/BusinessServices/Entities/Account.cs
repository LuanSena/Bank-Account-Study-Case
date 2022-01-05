namespace AccountOperator.BusinessServices.Entities;

public class Account
{
    private const double DepositFee = 0.99;
    
    public Guid Uid;
    public decimal Balance;
    public string OwnerName;

    public decimal Deposit(decimal amount)
    {
        var depositNetAmount = amount * (decimal) DepositFee;
        Balance += depositNetAmount;
        return Balance;
    }
}
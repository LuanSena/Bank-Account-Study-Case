namespace AccountOperator.BusinessServices.Entities;

public class StatementEntry
{
    public Guid AccountUid;
    public decimal Amount;
    public string OperationType;
    public readonly DateTime OperationTime;

    public StatementEntry(Guid accountUid, decimal amount, string operationType)
    {
        AccountUid = accountUid;
        Amount = amount;
        OperationType = operationType;
        OperationTime = DateTime.Now;
    }
}
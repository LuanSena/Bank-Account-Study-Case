using System;
using AccountOperator.BusinessServices.Entities;
using Xunit;

namespace AccountOperatorTests;

public class AccountUseCases
{
    [Fact]
    public void Account_deposit_should_discount_fee()
    {
        var account = new Account
        {
            Balance = 0,
            Uid = new Guid(),
            OwnerName = "Tester"
        };
        account.Deposit(100);
        Assert.Equal(99, account.Balance);
        
        account.Deposit(0);
        Assert.Equal(99, account.Balance);
    }
}
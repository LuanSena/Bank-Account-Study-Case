using System;
using AccountOperator.BusinessServices.Entities;
using Xunit;

namespace AccountOperatorTests;

public class AccountUseCases
{
    [Fact]
    public void Account_deposit_should_discount_fee()
    {
        var account = new Account(0, "tester");
        account.Deposit(100, "Initial deposit");
        Assert.Equal(99, account.Balance);
    }

    [Fact]
    public void Account_blank_deposit_should_not_Apply_discount_fee()
    {
        var account = new Account(100, "tester");
        account.Deposit(0, "Blank deposit");
        Assert.Equal(100, account.Balance);
    }
    
    [Fact]
    public void Account_amount_transfer_should_move_amounts_between_accounts()
    {
        var accountSource = new Account(10, "TesterA");
        var accountDestination = new Account(0, "TesterB");
        
        accountSource.Transfer(10, accountDestination);
        
        Assert.Equal(0, accountSource.Balance);
        Assert.Equal(10, accountDestination.Balance);
    }
    
    [Fact]
    public void Account_withdraw_should_affect_account_balance()
    {
        var account = new Account(10, "Tester");
        
        account.Withdrawn(10);
        
        Assert.Equal(0, account.Balance);
    }
}
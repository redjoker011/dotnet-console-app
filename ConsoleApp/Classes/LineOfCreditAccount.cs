using System;

namespace ConsoleApp.Classes
{
    public class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit) { }

        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {

                decimal interest = Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Charge Monthly Interest");
            }
        }

        protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
            isOverdrawn
            ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
            : default;
    }
}

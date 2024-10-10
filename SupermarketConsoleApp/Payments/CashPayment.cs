using SupermarketConsoleApp.Classes;
using SupermarketConsoleApp.Payments.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketConsoleApp.Payments
{
    internal class CashPayment : IPaymentForm
    {
        CashRegister CashRegister;

        public CashPayment(CashRegister cashRegister)
        {
            CashRegister = cashRegister;
        }

        public void ProcessPayment(double amount)
        {
            CashRegister.Withdraw(amount);

            Console.WriteLine($"Оплата готiвкою на сумму {amount} успiшна");
        }
    }
}

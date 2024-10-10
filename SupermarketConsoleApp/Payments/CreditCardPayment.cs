using SupermarketConsoleApp.Payments.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketConsoleApp.Payments
{
    internal class CreditCardPayment : IPaymentForm
    {
        public void ProcessPayment(double amount)
        {

            Console.WriteLine($"Оплата карткою на сумму {amount} успiшна!");
        }
    }
}

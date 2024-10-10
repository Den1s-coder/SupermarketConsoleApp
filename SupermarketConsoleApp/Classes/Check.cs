using SupermarketConsoleApp.Payments.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketConsoleApp.Classes
{
    class Check
    {
        DateTime Time = DateTime.Now;
        IPaymentForm paymentForm;

    }
}

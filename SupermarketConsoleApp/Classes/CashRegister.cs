using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketConsoleApp.Classes
{
    internal class CashRegister
    {
        int Id;
        double Amount;
        List<string> Log;
        string Model;


        private CashRegister(int id,double amount, string model)
        {
            Id = id;
            Amount = amount;
            Model = model;
        }

        public CashRegister CreateCashRegister(int id, double amount, string model)    
        {
            if (string.IsNullOrEmpty(model))
            {
                Console.WriteLine("Помилка: назва моделі не може бути пустою");
                return null;
            }
            return new CashRegister(id, amount, model);
        }

        public void withdraw(double value) 
        {
            if(Amount <= 0)
            {
                Amount = 0;
                Console.WriteLine("Увага на касі закінчились гроші!");
                return;
            }
            if (value > Amount) 
            {
                Console.WriteLine("Помилка: на касі не достатньо грошей!");
                return;
            }
            if(value < 0) {value*=-1;}

            Amount -= value;
            Console.WriteLine($"Готівка успішно знята \nЗалишилось готівки - {Amount}");
            return;
        }
    }
}

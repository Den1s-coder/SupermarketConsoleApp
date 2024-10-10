using SupermarketConsoleApp.Payments.Interface;
using SupermarketConsoleApp.Payments;
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
        double Amount = 1000;
        List<string> Log;
        string Model;
        List<Product> Products;


        private CashRegister(int id, string model, List<Product> products)
        {
            Id = id;
            Model = model;
            Products = products;
        }

        public static CashRegister CreateCashRegister(int id, string model, List<Product> products)    
        {
            if (string.IsNullOrEmpty(model))
            {
                Console.WriteLine("Помилка: назва моделі не може бути пустою");
                return null;
            }
            return new CashRegister(id, model, products);
        }

        public void Withdraw(double value) 
        {
            if (value < 0) value *= -1; 

            if (value > Amount) 
            {
                Console.WriteLine("Помилка: на касі не достатньо грошей!");
                return;
            }

            Amount -= value;
            Console.WriteLine($"Готівка успішно знята \nЗалишилось готівки на кассі - {Amount}");
            return;
        }

        public void Purchase(double amount)
        {
            Console.WriteLine("Выберите метод оплаты (1 - Кредитная карта, 2 - Готівка):");
            string choice = Console.ReadLine();
            if (choice != "1" && choice != "2") 
            {
                Console.WriteLine("Помилка: Неправильний вибір. Спробуйте ще раз.");
                return;
            }

            IPaymentForm paymentsChoice = choice switch
            {
                "1" => new CreditCardPayment(),
                "2" => new CashPayment(this)
            };

            PaymentProcessor paymentProcessor = new PaymentProcessor(paymentsChoice);
            paymentProcessor.ProcessPayment(amount);

            return;
        }

        public double Count()
        {
            double amount = 0;

            for (int i = 0; i < Products.Count; i++) Products[i].GetName();

            while (true)
            {
                Console.WriteLine("Вкажіть Id товару який хочете взяти: ");
                int ChoiseId;

                while (!int.TryParse(Console.ReadLine(), out ChoiseId))
                {
                    Console.WriteLine("Помилка: Невірний формат введення спробуйте ще раз:");
                };

                amount += Products[ChoiseId].GetPrice();
                Console.WriteLine("Хочете додати щось ще?");

                while (!int.TryParse(Console.ReadLine(), out ChoiseId))
                {
                    Console.WriteLine("Помилка: Невірний формат введення спробуйте ще раз:");
                };

                switch (ChoiseId)
                {
                    case 1: break;
                    case 2: return amount;
                }
            }
        }

        public void CheckGenerator(int id) 
        {

        }
    }
}

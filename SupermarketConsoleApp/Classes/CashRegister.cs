﻿using SupermarketConsoleApp.Payments.Interface;
using SupermarketConsoleApp.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SupermarketConsoleApp.Classes
{
    internal class CashRegister
    {
        int Id;
        double Amount = 1000;
        List<Check> Log;
        string Model;
        List<Product> Products;


        private CashRegister(int id, string model, List<Product> products)
        {
            Id = id;
            Model = model;
            Products = products;
            Log = new List<Check>();
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

        public void WithdrawCash()
        {
            Console.WriteLine("Вкажiть сумму яку хочете зняти з касси");
            int value;

            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Помилка: Невірний формат введення спробуйте ще раз:");
            };

            Withdraw(value);
            
            return;
        }

        public void AddCash()
        {
            Console.WriteLine("Вкажiть сумму на яку хочете поповнити кассу");
            int value;

            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Помилка: Невірний формат введення спробуйте ще раз:");
            };

            if (value < 0) value *= -1;

            Amount += value;
            Console.WriteLine($"Поповнення Успішне на кассі = {Amount} грн");
            return;
        }

        private void Purchase(List<Product> Basket)
        {
            Console.WriteLine("Выберите метод оплаты (1 - Кредитная карта, 2 - Готівка, 3 - Кур'єр):");
            string choice = Console.ReadLine();

            if (choice != "1" && choice != "2" && choice != "3")
            {
                Console.WriteLine("Помилка: Неправильний вибір. Спробуйте ще раз.");
                return;
            }

            IPaymentForm paymentsChoice = choice switch
            {
                "1" => new CreditCardPayment(this),
                "2" => new CashPayment(this),
                "3" => new СourierPayment(this)
            };

            PaymentProcessor paymentProcessor = new PaymentProcessor(paymentsChoice);
            paymentProcessor.ProcessPayment(Basket);

            return;
        }

        public void Basket()
        {
            List<Product> Basket = new List<Product>();

            double amount = 0;

            for (int i = 0; i < Products.Count; i++) Products[i].GetInfo();
            Console.WriteLine($"Вкажiть {Products.Count + 1} якщо хочете вийти");
            while (true)
            {
                Console.WriteLine("Вкажіть Id товару який хочете взяти: ");
                int ChoiseId;

                while (!int.TryParse(Console.ReadLine(), out ChoiseId))
                {
                    Console.WriteLine("Помилка: Невiрний формат введення спробуйте ще раз:");
                };

                if (ChoiseId == Products.Count + 1) return;

                if (!Products.Any(p => p.GetId() == ChoiseId)) 
                {
                    Console.WriteLine("Помилка: Товару з таким ID не iснує:");
                    break;
                }

                if (Basket.Any(p => p.GetId() == ChoiseId))
                {
                    Product product = Basket.First(p => p.GetId() == ChoiseId);
                    product.AddQuantity();
                }
                else Basket.Add(Products[ChoiseId]);


                Console.WriteLine("Хочете додати щось ще? (1(Так)/2(Ні)");

                while (!int.TryParse(Console.ReadLine(), out ChoiseId))
                {
                    Console.WriteLine("Помилка: Невірний формат введення спробуйте ще раз:");
                };

                switch (ChoiseId)
                {
                    case 1:
                        break;
                    case 2:
                        this.Purchase(Basket);
                        break;
                    default:
                        Console.WriteLine("Помилка: Неправильний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        public List<Check> GetLogger() { return Log; }

        public int GetId() {  return Id; }
    }
}

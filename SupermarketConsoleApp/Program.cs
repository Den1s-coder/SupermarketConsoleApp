using SupermarketConsoleApp.Classes;
using SupermarketConsoleApp.Payments;
using SupermarketConsoleApp.Payments.Interface;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Product> Products = new List<Product>();

        Product.CreateProduct(Products, "banana", 1, 15);
        Product.CreateProduct(Products, "Bread", 2, 10);
        Product.CreateProduct(Products, "Fanta", 3, 36.50);
        Product.CreateProduct(Products, "Milk", 4, 33.70);
        Product.CreateProduct(Products, "Chocolate Ice Cream", 5, 30);
        Product.CreateProduct(Products, "Coca-Cola", 6, 37);
        Product.CreateProduct(Products, "Pepsi-Cola", 7, 45);
        Product.CreateProduct(Products, "Cheese", 8, 15);
        Product.CreateProduct(Products, "Pineapple", 9, 15.50);
        Product.CreateProduct(Products, "Water", 10, 5.30);

        for (int i = 0; i < Products.Count; i++) Products[i].GetName();


        Console.WriteLine("Выберите метод оплаты (1 - Кредитная карта, 2 - PayPal):");
        string choice = Console.ReadLine();

        IPaymentForm paymentsChoice = choice switch
        {
            "1" => new CreditCardPayment(),
            "2" => new CashPayment()
        };

        PaymentProcessor paymentProcessor = new PaymentProcessor(paymentsChoice);
        paymentProcessor.ProcessPayment(1000);
    }
}
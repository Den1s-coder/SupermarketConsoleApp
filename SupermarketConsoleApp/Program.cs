using SupermarketConsoleApp.Classes;

internal class Program
{
    private static void Main(string[] args)
    {

        List<Product> Products = new List<Product>();

        Product.CreateProduct(Products, "banana", 15);
        Product.CreateProduct(Products, "Bread", 10);
        Product.CreateProduct(Products, "Fanta", 36.50);
        Product.CreateProduct(Products, "Milk", 33.70);
        Product.CreateProduct(Products, "Chocolate Ice Cream", 30);
        Product.CreateProduct(Products, "Coca-Cola", 37);
        Product.CreateProduct(Products, "Pepsi-Cola", 45);
        Product.CreateProduct(Products, "Cheese", 15);
        Product.CreateProduct(Products, "Pineapple", 15.50);
        Product.CreateProduct(Products, "Water", 5.30);

        CashRegister cashRegister = CashRegister.CreateCashRegister(1, "Model_1", Products);

        while (true)
        {
        Console.WriteLine("1 Сформувати замовлення\r\n 2 Додати грошей до касси\r\n 3 Зняти кошти\r\n 4 перелiк транзакцій \r\n 5 Додати товар до касси");
        string Choise = Console.ReadLine();
        
            switch (Choise)
            {
                case "1":
                    cashRegister.Basket();
                    break;
                case "2":
                    cashRegister.AddCash();
                    break;
                case "3":
                    cashRegister.WithdrawCash();
                    break;
                case "4":
                    Check.ShowTransactions(cashRegister.GetLogger());
                    break;
                case "5":
                    Product.AddProduct(Products);
                    break;
                case "6": return;
            }
        }
    }
}

// 1 Сформувати замовлення
// 2 Додати грошей до касси
// 3 Зняти кошти
// 4 перелік транзакцій 
// 5 Додати товар до касси
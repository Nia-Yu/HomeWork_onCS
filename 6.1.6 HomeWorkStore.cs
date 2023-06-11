using System;
using System.Collections.Generic;

namespace HWCardDeck
{
    class Program
    {
        //Существует продавец, он имеет у себя список товаров, и при нужде, может вам его показать, также продавец может продать вам товар.
        //После продажи товар переходит к вам, и вы можете также посмотреть свои вещи.
        //Возможные классы – игрок, продавец, товар.
        //Вы можете сделать так, как вы видите это.

        static void Main(string[] args)
        {
            Seller seller = new Seller(1000);
            Player player = new Player(2000);
            bool isWork = true;

            while (isWork)
            {
                const int CommandShowInfoBagSeller = 1;
                const int CommandShowInfoBagPlayer = 2;
                const int CommandExit = 0;

                int userInput;

                Console.Clear();
                Console.WriteLine("Вы встретили торговца.");
                Console.WriteLine($"Выберите действие. \n" +
                    $"Попросить торговца показать товары на продажу({CommandShowInfoBagSeller}), " +
                    $"посмотреть свой инвентарь({CommandShowInfoBagPlayer}) " +
                    $"или пойти дальше({CommandExit})");
                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case CommandShowInfoBagSeller:
                        seller.ShowInfoBag();
                        break;

                    case CommandShowInfoBagPlayer:
                        player.ShowInfoBag();
                        break;

                    case CommandExit:
                        Console.WriteLine("Вы идете дальше!");
                        isWork = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Такой команды нет.");
                        break;
                }

                Console.ReadKey();
            }            
        }
    }

    abstract class Human
    {
        protected Inventory Inventory;
        protected Wallet Wallet;

        public Human(int money)
        {
            Inventory = new Inventory();
            Wallet = new Wallet(money);
        }

        public virtual void ShowInfoBag()
        {
            Inventory.ShowInfo();
        }

        public virtual void SellProduct()
        {

        }

        public virtual void BuyProduct()
        {

        }
    }

    class Seller : Human
    {
        public Seller(int money) : base(money)
        {
            Inventory.AddProduct(new Product("Зелье исцеления Х1", 58));
            Inventory.AddProduct(new Product("Зелье исцеления Х5", 300));
            Inventory.AddProduct(new Product("Зелье силы", 100));
            Inventory.AddProduct(new Product("Крюк Коготь дракона", 250));
            Inventory.AddProduct(new Product("Паутина мао", 125));
            Inventory.AddProduct(new Product("Меч мертвых", 620));
            Inventory.AddProduct(new Product("Золотое яблоко", 70));
            Inventory.AddProduct(new Product("Свиток призыва: Чёрный кот", 200));
            Inventory.AddProduct(new Product("Броня Лепестки Тьмы", 1270));
        }

        public override void ShowInfoBag()
        {
            Console.Clear();
            Console.WriteLine("Товары на продажу:");
            base.ShowInfoBag();
        }
    }

    class Player : Human
    {
        public Player(int money) : base(money) { }

        public override void ShowInfoBag()
        {
            Console.Clear();
            Console.WriteLine("Ваш инвентарь:");
            base.ShowInfoBag();
            Wallet.ShowInfo();
        }

        
    }

    class Inventory
    {
        private List<Product> _products;

        public Inventory()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void DeleteProduct(int idProduct)
        {
            _products.RemoveAt(idProduct);
        }

        public void ShowInfo()
        {
            for (int i = 0; i < _products.Count; i++)
            {
                int idProduct = i + 1;

                Console.Write($"{idProduct} ");
                _products[i].ShowInfo();
            }
        }
    }

    class Wallet
    {
        private int _money;

        public Wallet(int money)
        {
            _money = money;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"\nВ кошельке {_money} монет.");
        }
    }

    class Product
    {
        private string _name;
        private int _price;

        public Product(string name, int price)
        {
            _name = name;
            _price = price;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_name} Цена {_price} монет.");
        }
    }
}

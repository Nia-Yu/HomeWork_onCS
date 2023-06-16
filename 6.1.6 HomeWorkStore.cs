using System;
using System.Collections.Generic;

namespace HWStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Seller seller = new Seller(1000);
            Player player = new Player(2000);
            bool isWork = true;

            while (isWork)
            {
                const string CommandShowInfoBagSeller = "1";
                const string CommandBuyProduct = "2";
                const string CommandShowInfoBagPlayer = "3";
                const string CommandExit = "0";

                string userInput;

                Console.Clear();
                Console.WriteLine("Вы встретили торговца.");
                Console.WriteLine($"Выберите действие. \n" +
                    $"Попросить торговца показать товары на продажу({CommandShowInfoBagSeller}), " +
                    $"купить товар({CommandBuyProduct}), " +
                    $"посмотреть свой инвентарь({CommandShowInfoBagPlayer}) " +
                    $"или пойти дальше({CommandExit})");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandShowInfoBagSeller:
                        seller.ShowInfoBag();
                        break;

                    case CommandBuyProduct:
                        seller.SellProduct(player);
                        break;

                    case CommandShowInfoBagPlayer:
                        player.ShowInfoBag();
                        break;

                    case CommandExit:
                        Console.WriteLine("Вы идёте дальше!");
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
            Inventory.AddProduct(new Product("Меч мертвых", 2300));
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

        public void SellProduct(Player player)
        {
            ShowInfoBag();
            int userInput = ReadIntNumber();
            int idProduct = userInput - 1;

            if (Inventory.TryGetProduct(out Product product, idProduct) == true)
            {
                Console.WriteLine($"С вас: {product.Price}");

                if (player.TryBuyProduct(product) == true)
                {
                    Inventory.DeleteProduct(product);
                    Wallet.ReceiveCoins(product.Price);
                    Console.WriteLine("Спасибо за покупку! Приходите еще.");
                }
            }
            else
            {
                Console.WriteLine("Выбирете товар из списка!");
            }
        }

        private int ReadIntNumber()
        {
            string userInput = Console.ReadLine();
            int numberInput;

            while ((int.TryParse(userInput, out numberInput) == false))
            {
                Console.WriteLine("Ошибка ввода! Проверьте введенные данные");

                userInput = Console.ReadLine();
            }

            return numberInput;
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

        public bool TryBuyProduct(Product product)
        {
            if (Wallet.TryPayCoins(product.Price) == true)
            {
                Inventory.AddProduct(product);

                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Inventory
    {
        private readonly List<Product> _products;

        public Inventory()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            _products.Remove(product);
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

        public bool TryGetProduct(out Product productFound, int numberId)
        {
            productFound = null;

            if (numberId >= 0 && numberId < _products.Count)
            {
                productFound = _products[numberId];

                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ошибка! Такого товара нет.");

                return false;
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

        public bool TryPayCoins(int price)
        {
            if ((_money) >= price)
            {
                _money -= price;

                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("У вас не достаточно средств. Может вы выбирете что то более дешёвое?");

                return false;
            }
        }

        public void ReceiveCoins(int price)
        {
            _money += price;
        }
    }

    class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} Цена {Price} монет.");
        }
    }
}

using System;
using System.Collections.Generic;

namespace HWCardDeck
{
	class Program
	{
		//—уществует продавец, он имеет у себ€ список товаров, и при нужде, может вам его показать, также продавец может продать вам товар.
		//ѕосле продажи товар переходит к вам, и вы можете также посмотреть свои вещи.
		//¬озможные классы Ц игрок, продавец, товар.
		//¬ы можете сделать так, как вы видите это.

		static void Main(string[] args)
		{

		}
	}

	class Seller
	{
		private List<Product> _products = new List<Product>();
	}

	class Player
	{

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
	}
}
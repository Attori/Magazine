using System;
using System.Collections.Generic;


namespace Magasin
{
    public class Product
    {
        public string Name;
        public int Coast;
        public int Quantity;
    }

    public class Assortiment
    {
        private Dictionary<int, Product> _magazineAssortiment = new Dictionary<int, Product>();

        public Assortiment()
        {
            _magazineAssortiment = new Dictionary<int, Product>
            {
                {
                    1, new Product
                    {
                        Name = "Xbox",
                        Coast = 35000,
                        Quantity = 50
                    }
                },
                {
                    2, new Product
                    {
                        Name = "PlayStation",
                        Coast = 36000,
                        Quantity = 50
                    }
                },
                {
                    3, new Product
                    {
                        Name = "Iphone",
                        Coast = 55000,
                        Quantity = 50
                    }
                },
                {
                    4, new Product
                    {
                        Name = "Samsung",
                        Coast = 42000,
                        Quantity = 50
                    }
                },
                {
                    5, new Product
                    {
                        Name = "Apupa",
                        Coast = 7000,
                        Quantity = 50
                    }
                }
            };
        }

        public Dictionary<int,Product> GetAssortiment()
        {
            return _magazineAssortiment;
        }


        public void ShowAssortiment()
        {
            Console.WriteLine("В магазине доступные следущие товары :");
            Console.WriteLine();
            foreach (var t in _magazineAssortiment)
            {
                Console.WriteLine($" * {t.Value.Name} *  по цене {t.Value.Coast} рублей , ключ продукта {t.Key}" );
            }
        }
    }
}
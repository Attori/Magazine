using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace Magasin
{
    public class Menu
    {
        private bool flagAuthorisation = false;
        private Assortiment _assortiment;
        private List<Product> _myCart;
        private Wallet _wallet;

        public Menu()
        {
            _assortiment = new Assortiment();
            _myCart = new List<Product>();
            _wallet = new Wallet(75000);
        }


        public void DoAction()
        {
            while (true)
            {
                var userChoise1 = Convert.ToInt32(Console.ReadLine());

                switch (userChoise1)
                {
                    case 1:

                        Login(); // войти в систему
                        break;
                    case 2:
                        ShowAllProducts(); // показать ассортимент
                        break;
                    case 3:
                        AddProductsInCart(); // добавить конкретный продукт в корзину
                        break;
                    case 4:
                        PrintCartInformation(); // показать добавленные товары в корзине
                        break;
                    case 5:
                        BuyAllProductsInCart(); // купить все продукты находящиеся в корзине
                        break;
                    default:
                        Console.WriteLine("Выберите корректное действие");
                        break;
                }
            }
        }

        private void Login()
        {
            var myPerson = new Person();

            if (flagAuthorisation == false)
            {
                Console.WriteLine("Введите Имя");
                var userName = Console.ReadLine();

                Console.WriteLine("Введите пароль");
                var userPassword = Console.ReadLine();

                if (myPerson._userName == userName && myPerson._userPassword == userPassword)
                {
                    flagAuthorisation = true;
                    Console.WriteLine("Вы Успешно авторизовались!");
                    Console.WriteLine("Выбирите действие из контекстного меню");
                    PrintCartInformationAboutMenu();
                }
                else
                {
                    Console.WriteLine("Ошибка ввода данных ,попробуйте ещё раз!");
                }
            }
            else
            {
                Console.WriteLine(" Вы уже авторизованы на сайте =) ");
            }
        }

        private void ShowAllProducts()
        {
            _assortiment.ShowAssortiment();
        }


        private void AddProductsInCart()
        {
            Console.WriteLine("Введите ключ товара");

            PrintInformationAboutProducts();

            var item = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите Кол-во");
            var count = Convert.ToInt32(Console.ReadLine());

            var currentAssortiment = _assortiment.GetAssortiment();

            var copyCurrentAndCoastItem = new Product
                { Name = currentAssortiment[item].Name, Coast = currentAssortiment[item].Coast, Quantity = count };

            currentAssortiment[item].Quantity -= count;

            _myCart.Add(copyCurrentAndCoastItem);
        }

        private void PrintCartInformation()
        {
            foreach (var t in _myCart)
            {
                Console.WriteLine($" В вашей корзине {t.Name} в кол-ве {t.Quantity}");
            }
        }

        private void BuyAllProductsInCart()
        {
            int totalPrice = 0;
            foreach (var t in _myCart)
            {
                totalPrice += t.Quantity * t.Coast;
            }

            Console.WriteLine($"Общая сумма покупки составляет : {totalPrice} рублей");

            if (totalPrice > _wallet._money)
            {
                Console.WriteLine("На вашем балансе не хватает средств");
            }
            else
            {
                _wallet._money -= totalPrice;
                Console.WriteLine("Оплата успешно совершена");
            }

            Console.WriteLine();

            Console.WriteLine($"Баланс вашего кошелька составляет {_wallet._money}");
        }

        public void PrintInformationAboutProducts()
        {
            Console.WriteLine("Для того чтобы приобрести товар ,нажмите соответствующую кнопку на клавиатуре");
            Console.WriteLine("[1] для покупки *Xbox*");
            Console.WriteLine("[2] для покупки *PlayStation*");
            Console.WriteLine("[3] для покупки *Iphone*");
            Console.WriteLine("[4] для покупки *Samsung*");
            Console.WriteLine("[5] для покупки *Apupa*");
        }

        private void PrintCartInformationAboutMenu()
        {
            Console.WriteLine("[2] Показать ассортимент товаров магазина ");
            Console.WriteLine("[3] Добавить товар в Корзину покупок ");
            Console.WriteLine("[4] Показать добавленные товары в Корзине покупок ");
            Console.WriteLine("[5] Оплатить товары в Корзину покупок ");
        }
    }
}
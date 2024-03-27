using Car;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

internal class CarConclusion
{
    static void Main(string[] args)
    {
        Auto.cars = new List<Auto>();
        categories(Auto.cars);
    }
    public static void categories(List<Auto> cars)
    {
        Auto car;
        while (true)
        {
            Console.WriteLine("\n>> Mеню:\n> 1 - Создание нового автомобиля\n> 2 - Выбор автомобиля");
            string? vybor1 = Console.ReadLine();
            if (vybor1 == "1")
            {
                Console.WriteLine(">> Выберите категорию машины");
                Console.WriteLine(">Категории машин<\n> 1 - Легковая\n> 2 - Автобус\n> 3 - Грузовик");
                int type = Convert.ToInt32(Console.ReadLine());
                switch (type)
                {
                    case 1:
                        cars.Add(new Auto());
                        break;
                    case 2:
                        cars.Add(new Bus());
                        break;
                    case 3:
                        cars.Add(new Truck());
                        break;
                }
            }
            else if(vybor1 == "2")
            {
                foreach (Auto auto in cars)
                {
                    Console.WriteLine("Введите номер автомобиля: ");
                    string? s = Console.ReadLine();
                    if (s == auto.Num_Car)
                    {
                        car = auto;
                        car.Menu(cars);
                    }
                }
            }
        }
    }
}
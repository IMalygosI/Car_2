using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    internal class Bus : Auto
    {
        protected double otsihdosih;
        protected int Number_Bus_Stops;
        protected int place_Passenger_in_Bus;
        protected double topost;
        protected double kilometrdoost;
        protected double kilom;
        protected int Passenger;
        protected double mileage; //Пробег общий
        //protected double top2;
        public string? Nom { get { return number_Car; } }
        public Bus() { Menu(cars); }
        public static int metod = 0;

        protected override void Info(List<Auto> cars)
        {
            Console.WriteLine("\n> Выбрать номер автобуса:\n1- Ввод вручную\n2- Автоматически");
            string? Choice_select_car_number = Console.ReadLine();
            if (Choice_select_car_number == "1")//Номер машины
            {
                Console.WriteLine("> Введите номер автобуса :");
                this.number_Car = Console.ReadLine();
                Console.WriteLine($"Номер автобуса : {number_Car}\n");
            }//Номер машины
            if (Choice_select_car_number == "2")//Номер машины
            {
                char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
                Random rnd = new Random();
                string word = "";
                for (int j = 1; j <= 4; j++)
                {
                    int letter_num = rnd.Next(0, letters.Length - 1);
                    word += letters[letter_num];
                }
                this.number_Car = word;
                Console.WriteLine($"Номер автобуса : {number_Car}\n");
            }//Номер машины
            this.volume_Tank = 60;
            Console.WriteLine($"Объем бака автобуса: {volume_Tank}\n");

            Console.WriteLine("> Расход топлива на 100 км:");
            this.consumption_Fuel = float.Parse(Console.ReadLine());
            if (consumption_Fuel >= (60 / 2))
            {
                Console.WriteLine("расход топлива  Слишком большой!");
                Info(cars);
            }
            Console.WriteLine("> Вместительность пассажиров:");
            this.place_Passenger_in_Bus = Convert.ToInt32(Console.ReadLine());
            this.speed = 0;
            this.currentamount_Gasoline = 0;
            this.probeg = 0;
            this.kilometragh = 0;
            this.interval = 0;
            this.Passenger = 0;
        }
        protected override void Path_Information(List<Auto> cars)
        {
            if (distance > 0)
            {
                Console.WriteLine("Сменить маршрут?\nДа - 1\nНет - 2");
                string? smena = Console.ReadLine();
                switch (smena)
                {
                    case "1":
                        distance = 0;
                        break;
                    case "2":
                        Console.WriteLine("");
                        break;
                }
                Menu(cars);
            }
            if (distance == 0)
            {
                speed = 0;
                Console.WriteLine("> Введите координаты вашего пути");
                Console.WriteLine("Начало-Xa: ");
                this.koordinata_Xa = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Начало-Ya: ");
                this.koordinata_Ya = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Конец-Xb: ");
                this.koordinata_Xb = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Конец-Yb: ");
                this.koordinata_Yb = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("> Количество остановок на маршруте: ");
                this.Number_Bus_Stops = Convert.ToInt32(Console.ReadLine());
                this.distance = 2 * (Math.Round(Math.Sqrt(((koordinata_Xb - koordinata_Xa) * (koordinata_Xb - koordinata_Xa)) + ((koordinata_Yb - koordinata_Ya) * (koordinata_Yb - koordinata_Ya)))));
                this.otsihdosih = Math.Round((distance / 2) / Number_Bus_Stops);
                this.kilometrdoost = distance / 2;
                this.kilometragh = Math.Round((currentamount_Gasoline / consumption_Fuel) * 100); //На сколько километров хватит бензина
                Console.WriteLine($"Ваш маршрут: {distance / 2}. \nОстановок: {Number_Bus_Stops}.");
                this.interval = 0;
                Menu(cars);
            }
        }
        protected override void Stop(List<Auto> cars)
        {
            speed = 0;
            Console.WriteLine($"\n> Вы остановились\n");
            Console.WriteLine($"> Номер авто: {number_Car}");
            Console.WriteLine($"> Пробег автомобиля: {mileage} км");
            Drive2(cars);
            Menu(cars);
        }
        protected override void Razgon(List<Auto> cars)
        {
            if (distance == 0)
            {
                Console.WriteLine("Сначала укажите путь!");
                Menu(cars);
            }
            else if (distance > 0)
            {
                if (currentamount_Gasoline > 0)
                {
                    speed += 20;
                    Drive2(cars);
                    Menu(cars);
                }
                else if (currentamount_Gasoline <= 0)
                {
                    interval = 0;
                    Console.WriteLine($"Требуется заправка!");
                    Console.WriteLine("> Заправиться?\nДа - 1\nНет - 2");
                    string? zap = Console.ReadLine();
                    switch (zap)
                    {
                        case "1":
                            Zapravka(cars); break;
                        case "2":
                            Stop(cars); break;
                    }
                }
            }
        }




        protected override void Drive2(List<Auto> cars)
        {
            if (speed > 0) //Если машина в принципе поехала
            {
                if (currentamount_Gasoline > 0)
                {
                    currentamount_Gasoline -= consumption_Fuel; //*
                    //probeg += 100;
                    interval += 100;
                }
                else if ((currentamount_Gasoline - consumption_Fuel) < 0 & speed > 0)
                {
                    probeg -= 100;
                    interval -= 100;
                    probeg += kilometragh;
                    interval += kilometragh;
                    currentamount_Gasoline = 0;
                }
                else if (currentamount_Gasoline <= 0)
                {
                    Console.WriteLine($"Требуется заправка!");
                    Console.WriteLine("> Заправиться?\nДа - 1\nНет - 2");
                    string? zap = Console.ReadLine();
                    switch (zap)
                    {
                        case "1":
                            Zapravka(cars); break;
                        case "2":
                            Stop(cars); break;
                    }
                }
                else if ((currentamount_Gasoline - consumption_Fuel) < topost)
                {
                    Console.WriteLine($"Требуется заправка!");
                    Console.WriteLine("> Заправиться?\nДа - 1\nНет - 2");
                    string? zap = Console.ReadLine();
                    switch (zap)
                    {
                        case "1":
                            Zapravka(cars); break;
                        case "2":
                            Stop(cars); break;
                    }
                }
            }
            while (probeg <= distance / 2)
            {
                if (currentamount_Gasoline < 2 && interval < distance / 2 && interval != 0)
                {
                    interval += kilometragh - 100;
                    currentamount_Gasoline = 0;
                    speed = 0;
                }
                if (interval >= otsihdosih & otsihdosih != 0) //Для маршрута
                {
                    double a = otsihdosih - interval;
                    topost = (a * consumption_Fuel) / 100;
                    currentamount_Gasoline -= topost;
                    kilometrdoost -= otsihdosih;
                    probeg += otsihdosih;
                    speed = 0;
                    interval = 0;
                    Console.WriteLine("Остановка!");
                    Console.WriteLine($"Остаток топлива: {Math.Round(currentamount_Gasoline, 1)} литров.");
                    Console.WriteLine($"Пробег: {Math.Round(probeg)} километров.");
                    Console.WriteLine($"Пассажиры: {Passenger}.");
                Found:
                    Console.WriteLine("Сколько людей вошло?");
                    int prihod = Convert.ToInt32(Console.ReadLine());
                    if (prihod > place_Passenger_in_Bus || (Passenger + prihod) > place_Passenger_in_Bus)
                    {
                        Console.WriteLine("Автобус забит");
                        //ludy += mesta;
                        goto Found;
                    }
                    else
                    {
                        Passenger += prihod;
                    }
                Round:
                    Console.WriteLine("Сколько людей вышло?");
                    int uhod = Convert.ToInt32(Console.ReadLine());
                    if (uhod > place_Passenger_in_Bus || (Passenger - uhod) < 0)
                    {
                        Console.WriteLine(" Нет столько пассажиров");
                        //ludy -= mesta;
                        goto Round;
                    }
                    else
                    {
                        Passenger -= uhod;
                    }
                    if (probeg == distance / 2 || probeg == Number_Bus_Stops * otsihdosih)
                    {
                        probeg = distance / 2;
                        kilometrdoost = distance / 2;
                        Console.WriteLine("ВНИМАНИЕ!!!Автобус на конечной Остановке!!!");
                        Console.WriteLine("ВНИМАНИЕ!!!Автобус Дальше автобус двигается только в обратном направлении!!!");
                    }
                }
                kilometragh = Math.Round((currentamount_Gasoline / consumption_Fuel) * 100); //На сколько километров хватит бензина
                kilom = Math.Round((volume_Tank / consumption_Fuel) * 100);
                Console.WriteLine($"\n> Вы проехали: {interval} Км");// Интервал это то сколько -за раз едем, если остановаится он сбрасывается до 0 ну пробег все еще остается!
                // Console.WriteLine($"> Объем бака: {volume_Tank} литров");
                Console.WriteLine($"> Необходимо проехать до следующей точки: {kilom} Км");
                Console.WriteLine($"> Ваша скорость: {speed} Км");
                Console.WriteLine($"> Ваш весь маршрут с дорогой обратно: {distance} Км\n");
                if (currentamount_Gasoline == 0 || currentamount_Gasoline <= 0)
                {
                    Console.WriteLine("Требуется заправка!");
                    Console.WriteLine("> Заправиться? (1 - Да, 2 - Нет)\n");
                    string? zapravim = Console.ReadLine();
                    switch (zapravim)
                    {
                        case "1":
                            Zapravka(cars);
                            break;
                        case "2":
                            Stop(cars);
                            break;
                    }
                }
                else
                {
                    Menu(cars);
                }
            }
            while (probeg <= distance && probeg >= distance / 2)
            {
                if (interval >= kilometrdoost && otsihdosih != 0 && probeg >= distance / 2 && probeg >= distance && probeg >= otsihdosih * Number_Bus_Stops) //Для маршрута !!!
                {
                    kilometrdoost = 0;
                    probeg = distance;
                    speed = 0;
                    interval = 0;
                    mileage += probeg;
                    Console.WriteLine("База");
                    Console.WriteLine($"Топлива осталось: {Math.Round(currentamount_Gasoline, 1)} литров.");
                    Console.WriteLine($"Пробег: {Math.Round(mileage)} километров.");
                    distance = 0;
                    probeg = 0;
                }
                if (currentamount_Gasoline < 2 && interval < distance && interval != 0)
                {
                    probeg += kilometragh - 100;
                    interval += kilometragh - 100;
                    currentamount_Gasoline = 0;
                    speed = 0;
                }
                if (interval >= otsihdosih && otsihdosih != 0 && probeg < distance) //Для маршрута
                {
                    if (kilometrdoost > otsihdosih && probeg < distance)
                    {
                        kilometrdoost -= otsihdosih;
                        probeg += otsihdosih;
                        speed = 0;
                        interval = 0;
                        Console.WriteLine("Остановка");
                        Console.WriteLine($"Топлива осталось: {Math.Round(currentamount_Gasoline, 1)} литров.");
                        Console.WriteLine($"Пробег: {Math.Round(probeg)} километров.");
                        Console.WriteLine($"Пассажиры: {Passenger}.");
                    Gound:
                        Console.WriteLine("Сколько людей вошло?");
                        int prihod = Convert.ToInt32(Console.ReadLine());
                        if (prihod > place_Passenger_in_Bus || (Passenger + prihod) > place_Passenger_in_Bus)
                        {
                            Console.WriteLine("Автобус забит");
                            goto Gound;
                        }
                        else
                        {
                            Passenger += prihod;
                        }
                    Pound:
                        Console.WriteLine("Сколько людей вышло?");
                        int uhod = Convert.ToInt32(Console.ReadLine());
                        if (uhod > place_Passenger_in_Bus || (Passenger - uhod) < 0)
                        {
                            Console.WriteLine(" Нет столько пассажиров");
                            goto Pound;
                        }
                        else
                        {
                            Passenger -= uhod;
                        }
                    }
                    else if (kilometrdoost <= otsihdosih) //*
                    {
                        kilometrdoost -= kilometrdoost;
                        kilometrdoost = 0;
                        probeg = distance;
                        speed = 0;
                        interval = 0;
                        mileage += probeg;
                        Console.WriteLine("База");
                        Console.WriteLine($"Топлива осталось: {Math.Round(currentamount_Gasoline, 1)} литров.");
                        Console.WriteLine($"Пробег: {Math.Round(mileage)} километров.");
                        distance = 0;
                        probeg = 0;
                    }
                }
                kilometragh = Math.Round((currentamount_Gasoline / consumption_Fuel) * 100); //На сколько километров хватит бензина
                kilom = Math.Round((volume_Tank / consumption_Fuel) * 100);
                topost = ((otsihdosih * consumption_Fuel) / 100);
                Console.WriteLine($"\n> Вы проехали: {interval} Км");// Интервал это то сколько -за раз едем, если остановаится он сбрасывается до 0 ну пробег все еще остается!
                // Console.WriteLine($"> Объем бака: {volume_Tank} литров");
                Console.WriteLine($"> Необходимо проехать до следующей точки: {kilom} Км");
                Console.WriteLine($"> Ваша скорость: {speed} Км");
                Console.WriteLine($"> Ваш весь маршрут с дорогой обратно: {distance} Км\n");
                if (currentamount_Gasoline == 0)
                {
                    Console.WriteLine("Требуется заправка!");
                    Console.WriteLine("> Заправиться? (1 - Да, 2 - Нет)\n");
                    string? zapravim = Console.ReadLine();
                    switch (zapravim)
                    {
                        case "1":
                            Zapravka(cars);
                            break;
                        case "2":
                            Stop(cars);
                            break;
                    }
                }
                else
                {
                    Menu(cars);
                }
            }
        }

        protected override void Crash(List<Auto> cars)
        {
            base.Crash(cars);
        }
        public override void Menu(List<Auto> cars)//меню выбора
        {
            Console.WriteLine(">> Меню:" +
                             "\n> 1 - Задать цель поездки" +//Выбираем начало и конец координат пути, для определения дистанции пути
                             "\n> 2 - Газ" +
                             "\n> 3 - Останавливаемся" +
                             "\n> 4 - Заправиться" +
                             "\n> 5 - Сменить автомобиль" +
                             "\n> 6 - АВАРИЯ");

            string? vybor = Console.ReadLine();
            switch (vybor)
            {
                case "1":
                    Path_Information(cars);
                    break;
                case "2":
                    Razgon(cars);
                    break;
                case "3":
                    Stop(cars);
                    break;
                case "4":
                    Zapravka(cars);
                    break;
                case "5":
                    CarConclusion.categories(cars);
                    break;
                case "6":
                    Crash(cars);
                    break;
                default:
                    Console.WriteLine("\nКоманды с таким номером не существует");
                    break;
            }
        }
    }
}
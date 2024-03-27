using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    internal class Truck : Auto
    {
        protected int carrying;
        protected int pogruzka;
        protected double pogruzk;
        protected double razgrus;
        protected double kilom;
        protected double topost;
        protected int pogruz;
        protected int razgruz;
        protected int kuzov;
        protected double mileage; //Пробег общий
        public string? Nom { get { return number_Car; } }
        public Truck() { Menu(cars); }
        protected override void Info(List<Auto> cars)
        {
            this.type = "Грузовик";
            Console.WriteLine("\n> Выбрать номер грузовика:\n1- Ввод вручную\n2- Автоматически");
            string? Choice_select_car_number = Console.ReadLine();
            if (Choice_select_car_number == "1")//Номер машины
            {
                Console.WriteLine("> Введите номер грузовика :");
                this.number_Car = Console.ReadLine();
                Console.WriteLine($"Номер грузовика : {number_Car}\n");
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
                Console.WriteLine($"Номер грузовика: {number_Car}\n");
            }//Номер машины
            this.volume_Tank = 80;
            Console.WriteLine($"Объем бака грузовика: {volume_Tank}\n");
            Console.WriteLine("> Укажите нынешний уровень топлива:\n1- Ввод вручную\n2- Автоматически");
            string? Choice_Current_quantity_gasoline = Console.ReadLine();
            if (Choice_Current_quantity_gasoline == "1")//текущее количество бензина
            {
                Console.WriteLine("Уровень топлива:");
                this.currentamount_Gasoline = Convert.ToDouble(Console.ReadLine());
                if (volume_Tank >= currentamount_Gasoline)
                {
                    Console.WriteLine($"Уровень топлива: {currentamount_Gasoline}");
                }
                else
                {
                    this.currentamount_Gasoline = volume_Tank;
                    Console.WriteLine($"Уровень топлива: {currentamount_Gasoline}");
                }
            }//текущее количество бензина 
            if (Choice_Current_quantity_gasoline == "2")
            {
                Random rnd = new Random();
                int currentamount = rnd.Next(0, 90);
                this.currentamount_Gasoline = currentamount;
                if (volume_Tank >= currentamount)
                {
                    Console.WriteLine($"Уровень топлива: {currentamount_Gasoline}");
                }
                else
                {
                    currentamount_Gasoline = volume_Tank;
                    Console.WriteLine($"Уровень топлива: {currentamount_Gasoline}");
                }
            }//текущее количество бензина 

            Console.WriteLine("> Укажите Грузоподъёмность:\n1- Ввод вручную\n2- Автоматически");
            string? Choice_carrying = Console.ReadLine();
            if (Choice_carrying == "1")//текущая Грузоподъемность
            {
                Console.WriteLine("Грузоподъемность:");
                this.carrying = Convert.ToInt32(Console.ReadLine());
                if (2000 >= carrying)
                {

                    Console.WriteLine($"Грузоподъемность: {carrying}");
                }
                else
                {
                    this.carrying = 2000;
                    Console.WriteLine($"Грузоподъемность: {carrying}");
                }
            }//текущая Грузоподъемность
            if (Choice_carrying == "2")
            {
                Random rnd = new Random();
                int currentamount = rnd.Next(0, 2000);
                this.carrying = currentamount;
                Console.WriteLine($"Грузоподъемность: {carrying}");
            }//текущая Грузоподъемность

            Console.WriteLine("> Введите расход топлива на 100 км:");
            this.consumption_Fuel = float.Parse(Console.ReadLine());
            if (consumption_Fuel >= (80 / 2))
            {
                Console.WriteLine("расход топлива  Слишком большой!");
                Info(cars);
            }
            this.speed = 0;//скорость
            this.currentamount_Gasoline = 0;//уровень топлива
            this.probeg = 0;// проехал
            this.kilometragh = 0;//
            this.interval = 0;//осталось
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
                Console.WriteLine("Место погрузки: ");
                this.pogruzka = Convert.ToInt32(Console.ReadLine());
                this.distance = 2 * (Math.Round(Math.Sqrt(((koordinata_Xb - koordinata_Xa) * (koordinata_Xb - koordinata_Xa)) + ((koordinata_Yb - koordinata_Ya) * (koordinata_Yb - koordinata_Ya)))));
                if (pogruzka > distance)
                {
                    Console.WriteLine($"Вы не можете назначить точку погрузки дальше точки разгрузки {distance} км!");
                    distance = 0;
                    Path_Information(cars);
                }
                if (pogruzka <= 0)
                {
                    Console.WriteLine("Bведите точку погрузки!");
                    distance = 0;
                    Path_Information(cars);
                }
                this.pogruzk = 0 + pogruzka;
                this.razgrus = (distance / 2) - pogruzka;
                this.kilom = pogruzk;
                Console.WriteLine($"Ваш маршрут: {distance / 2} км. \nТочка погрузки через: {pogruzka} км"); //!!!
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

        //protected void Unloading_Point(List<Auto> cars) // вводим информацию по пути 
        //{
        //    Mesto_Razgruz = Math.Sqrt(Math.Pow(koordinata_X_Unloading - koordinata_Xb, 2) + Math.Pow(koordinata_Y_Unloading - koordinata_Yb, 2)); //расстояние от места погрузки до места рагрузки
        //    distance = Convert.ToInt32(Mesto_Razgruz);
        //    e += 1;            
        //    Console.WriteLine("\nМашина ЗАГРУЖЕНА!");
        //    Console.WriteLine($"\nОбъем бака: {volume_Tank} Литров\nУровень топлива: {currentamount_Gasoline} Литров");
        //    Console.WriteLine($"Точка разгрузки через: {distance-pogruzk} Км\n");
        //    Menu(cars);
        //}
        //protected void BAZA_Point(List<Auto> cars) // вводим информацию по пути 
        //{
        //    Mesto_Baza = Math.Sqrt(Math.Pow(koordinata_Xa - koordinata_X_Unloading, 2) + Math.Pow(koordinata_Ya - koordinata_Y_Unloading, 2)); //расстояние от места разгрузки до базы
        //    //distance = Convert.ToInt32(Mesto_Baza);
        //    e += 1;
        //    Console.WriteLine("\nМашина разгружена!");
        //    Console.WriteLine($"\nОбъем бака: {volume_Tank} Литров\nУровень топлива: {currentamount_Gasoline} Литров");
            
        //    Menu(cars);
        //}
        //protected override void Razgon(List<Auto> cars) //Разгон
        //{
        //    while (true)
        //    {
        //        try //для поиска ошибок try
        //        {
        //            Console.WriteLine("\nВведите значение скорости от 1 до 180 км/ч, до которого хотите разогнаться:\n");
        //            speed = Convert.ToDouble(Console.ReadLine());
        //            if (speed > 0 && speed <= 180)
        //            {
        //                Fuel_Consumption(speed);
        //                break;
        //            }
        //            else
        //            {
        //                Console.WriteLine("\nВведено значение вне заданного диапазона");
        //            }
        //            if (carrying > 100 && carrying <= 1000)
        //            {
        //                speed *= 0.6;
        //                Console.WriteLine($"\nС текущим весом груза в {carrying} т скорость уменьшена на 40%.");
        //                Fuel_Consumption(speed);
        //            }
        //            else
        //            {
        //                if (carrying > 1 && carrying <= 2)
        //                {
        //                    speed *= 0.2;
        //                    Console.WriteLine($"\nС текущим весом груза в {carrying} т скорость уменьшена на 80%.");
        //                    Fuel_Consumption(speed);
        //                }
        //            }
        //        }
        //        catch
        //        {
        //            Console.WriteLine("\nОшибка");
        //        }
        //    }            
        //}
        //protected void Fuel_Consumption(double speed) //рассчет расхода топлива от скорости
        //{
        //    if (speed >= 1 && speed <= 45)
        //    {
        //        consumption_Fuel = 12;
        //        if ((currentamount_Gasoline - consumption_Fuel) >= 0)
        //        {
        //            Drive();
        //        }
        //        else if ((currentamount_Gasoline - consumption_Fuel) < consumption_Fuel)
        //        {
        //            Zapravka(cars);
        //        }
        //    }
        //    else if (speed >= 46 && speed <= 100)
        //    {
        //        consumption_Fuel = 9;
        //        if ((currentamount_Gasoline - consumption_Fuel) >= 0)
        //        {
        //            Drive();
        //        }
        //        else if ((currentamount_Gasoline - consumption_Fuel) < consumption_Fuel)
        //        {
        //            Zapravka(cars);
        //        }
        //    }
        //    else if (speed >= 101 && speed <= 180)
        //    {
        //        consumption_Fuel = 12.5;
        //        if ((currentamount_Gasoline - consumption_Fuel) >= 0)
        //        {
        //            Drive();
        //        }
        //        else if ((currentamount_Gasoline - consumption_Fuel) < consumption_Fuel)
        //        {
        //            Zapravka(cars);
        //        }
        //    }
        //}
        //protected void mesto_pogruzka()// Загружаем на точке груз
        //{
        //    while (true)
        //    {
        //        try
        //        {
        //            Console.WriteLine("Введите груз в кг, который повезет машина! максимум 2000 кг!:\n");
        //            double ves = Convert.ToDouble(Console.ReadLine());
        //            if (ves > 1 && ves <= 2000)
        //            {
        //                carrying_Vess = ves;
        //                Console.WriteLine("\nТранспорт заполнен, направляйтесь к точке разгрузки\n");
        //                break;
        //            }
        //            else
        //            {
        //                Console.WriteLine("\nОшибка");
        //            }
        //        }
        //        catch
        //        {
        //            Console.WriteLine("\nОшибка");
        //        }
        //    }
        //}
        //protected override void Drive2(List<Auto> cars) // Метод езды автомобиля
        //{
        //    Razgon(cars);
        //}

        protected override void Drive2(List<Auto> cars)
        {
            if (speed > 0) //Если машина в принципе поехала
            {
                if (currentamount_Gasoline > 0)
                {
                    currentamount_Gasoline -= consumption_Fuel;
                    probeg += 100;
                    interval += 100;
                }
                else if ((currentamount_Gasoline - consumption_Fuel) < 0 && speed > 0)
                {
                    probeg -= 100;
                    interval -= 100;
                    probeg += kilometragh;
                    interval += kilometragh;
                    currentamount_Gasoline = 0;
                }
                else if (currentamount_Gasoline == 0)
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
                if (interval >= pogruzk && kilom == pogruzk) //Для маршрута
                {
                    double a = kilom - interval;
                    topost = (a * consumption_Fuel) / 100;
                    currentamount_Gasoline -= topost;
                    probeg = pogruzk;
                    kilom = razgrus;
                    interval = pogruzk;
                    Console.WriteLine("\nМашина прибыла в точку погрузки");
                    Console.WriteLine($"Топлива осталось: {Math.Round(currentamount_Gasoline, 1)} литров");
                    Console.WriteLine($"Пробег: {Math.Round(probeg)} километров");
                    speed = 0;
                Much:
                    Console.WriteLine($"Сколько можно загрузить максимум =>{carrying}<=");
                    Console.WriteLine("Сколько грузить?");
                    pogruz = Convert.ToInt32(Console.ReadLine());
                    if (pogruz <= carrying)
                    {
                        kuzov += pogruz;
                    }
                    else if (pogruz > carrying)
                    {
                        Console.WriteLine("Превышение объема кузова!");//нельзя превышать грузоподъемность
                        goto Much;
                    }
                }
                kilometragh = Math.Round((currentamount_Gasoline / consumption_Fuel) * 100); //На сколько километров хватит бензина
                Console.WriteLine($"\n> Вы проехали: {interval} Км");// Интервал это то сколько -за раз едем, если остановаится он сбрасывается до 0 ну пробег все еще остается!
                //Console.WriteLine($"> Объем бака: {volume_Tank} литров");
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
            while (probeg >= distance / 2)
            {
                if (interval >= distance / 2 && kilom == razgrus) //Для маршрута
                {
                    double a = (distance / 2) - interval;
                    topost = (a * consumption_Fuel) / 100;
                    currentamount_Gasoline -= topost;
                    kilom = distance / 2;
                    probeg = distance / 2;
                    speed = 0;
                    interval = 0;

                    Console.WriteLine("\nМашина прибыла в точку разгрузки");
                    Console.WriteLine($"Топлива осталось: {Math.Round(currentamount_Gasoline, 1)} литров");
                    Console.WriteLine($"Пробег: {Math.Round(probeg)} километров");

                    Console.WriteLine("Выгрузить все - 1 часть - 2?");
                    string io = Convert.ToString(Console.ReadLine());
                    if (io == "1")
                    {
                        razgruz = kuzov;
                        kuzov -= razgruz;
                    }
                    else if (io == "2")
                    {
                    Kuch:
                        Console.WriteLine("Сколько выгрузить?");
                        razgruz = Convert.ToInt32(Console.ReadLine());
                        if (razgruz <= kuzov)
                        {
                            kuzov -= razgruz;
                        }
                        else if (razgruz > kuzov)
                        {
                            Console.WriteLine("У вас столько нет! Укажите правильно!");
                            goto Kuch;
                        }
                    }

                }
                if (interval >= distance / 2 && probeg >= distance / 2 && kilom == distance / 2) //Для маршрута
                {
                    double a = kilom - interval;
                    topost = (a * consumption_Fuel) / 100;
                    currentamount_Gasoline -= topost;
                    kilom = 0;
                    probeg = distance;
                    mileage += probeg;
                    speed = 0;
                    interval = 0;
                    Console.WriteLine("База");
                    Console.WriteLine($"Топлива осталось: {Math.Round(currentamount_Gasoline, 1)} литров.");
                    Console.WriteLine($"Пробег: {Math.Round(mileage)} Км.");
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
                kilometragh = Math.Round((currentamount_Gasoline / consumption_Fuel) * 100); //На сколько километров хватит бензина
                Console.WriteLine($"\n> Вы проехали: {interval} Км");// Интервал это то сколько -за раз едем, если остановаится он сбрасывается до 0 ну пробег все еще остается!
               // Console.WriteLine($"> Объем бака: {volume_Tank} литров");
                Console.WriteLine($"> Необходимо проехать до следующей точки: {kilom} Км");
                Console.WriteLine($"> Ваша скорость: {speed} Км");
                Console.WriteLine($"> Ваш весь маршрут с дорогой обратно: {distance} Км\n");
                if (currentamount_Gasoline == 0)
                {
                    Console.WriteLine("Требуется заправка!");
                    Console.WriteLine("> Заправиться? 1 - Да, 2 - Нет\n");
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
        public override void Menu(List<Auto> cars)//меню выбора
        {
            Console.WriteLine(">> Меню:" +
                             "\n> 1 - Задать цель поездки" +//Выбираем начало и конец координат пути, для определения дистанции пути
                             "\n> 2 - Разогнаться" +
                             "\n> 3 - Тормозить" +
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

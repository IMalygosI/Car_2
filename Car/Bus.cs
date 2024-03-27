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
        protected double Stops_Bus_dis;//до остановки
        protected int Number_Bus_Stops;//кол-во остановок автобуса
        protected int place_Passenger_in_Bus;//Место для пассажиров в автобусе
        protected int Passenger;//Пассажир
        protected double remainder;//остаток от раст. для остановок в сторону 1

        public Bus()
        {
            Info(cars);
        }

        protected override void Info(List<Auto> cars) //Информация об автомобиле
        {
            this.type = "Автобус";
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
            /*
            Console.WriteLine("> Укажите расход топлива :\n1- Ввод вручную\n2- Автоматически");
            string? Choice_select_car_consumption = Console.ReadLine();
            if (Choice_select_car_consumption == "1")//Расход топлива машины
            {
                Console.WriteLine("Расход топлива (на 100 км):");
                this.consumption_Fuel = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"Расход топлива (на 100 км): {consumption_Fuel}\n");
            }//Расход топлива машины
            if (Choice_select_car_consumption == "2")//Расход топлива машины
            {
                Random rnd = new Random();
                int consumption = rnd.Next(8, 17);
                this.consumption_Fuel = consumption;
                Console.WriteLine($"Расход топлива (на 100 км): {consumption_Fuel}\n");
            }//Расход топлива машины
            *///Рассход топлива
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
                if (2100 >= carrying)
                {

                    Console.WriteLine($"Грузоподъемность: {carrying}");
                }
                else
                {
                    this.carrying = 2100;
                    Console.WriteLine($"Грузоподъемность: {carrying}");
                }
            }//текущая Грузоподъемность
            if (Choice_carrying == "2")
            {
                Random rnd = new Random();
                int currentamount = rnd.Next(70, 2100);
                this.carrying = currentamount;
                Console.WriteLine($"Грузоподъемность: {carrying}");
            }//текущая Грузоподъемность
            this.place_Passenger_in_Bus = 30;
            Console.WriteLine($"Количество мест пассажиров: {place_Passenger_in_Bus}");
            this.speed = 0;//скорость
            this.interval = 0;//расстояние что проехали
            this.rast = 0;//пробег
            this.kilometragh = 0;//На сколько километров хватит топлива
            this.Passenger = 0;
            this.massa = "3т";

            Console.WriteLine($"\n|Информация по машине|");
            Console.WriteLine("|Автомобиль занесен в базу, теперь его можете выбрать\n");
            Menu(cars);
            Console.WriteLine($"> Номер авто: {number_Car}");
            Console.WriteLine($"> Пробег автомобиля: {rast} км\n");
        }
        protected override void Path_Information(List<Auto> cars) // вводим информацию по пути 
        {
            this.interval = 0;
            Console.WriteLine("> Введите координаты вашего пути");
            Console.WriteLine("Начало-Xa: ");
            this.koordinata_Xa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Начало-Ya: ");
            this.koordinata_Xa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Конец-Xb: ");
            this.koordinata_Xb = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Конец-Yb: ");
            this.koordinata_Yb = Convert.ToInt32(Console.ReadLine());

            distance = (Math.Round(Math.Sqrt(((koordinata_Xb - koordinata_Xa) * (koordinata_Xb - koordinata_Xa)) + ((koordinata_Yb - koordinata_Ya) * (koordinata_Yb - koordinata_Ya)))));
            distance = Convert.ToInt32(2 * distance);// в одну сторону
            Console.WriteLine("Введите Количество остановок: ");
            this.Number_Bus_Stops = Convert.ToInt32(Console.ReadLine());

            this.Stops_Bus_dis = Math.Round((distance / 2) / Number_Bus_Stops);//Находим раст до след ост
            this.remainder = distance / 2;

            this.kilometragh = Math.Round((currentamount_Gasoline / consumption_Fuel) * 100); //На сколько километров хватит бензина
            Console.WriteLine("> Данные внесены");
            Console.WriteLine($"Маршрут поездки: {distance / 2} Км\nОстановок на маршруте: {Number_Bus_Stops}"); //УЧИТЫВАЕМ ЧТО ЭТО ТОЛЬКО В ОДНУ СТОРОНУ, после того как приедет поедет обратно!
            Console.WriteLine($"\nОбъем бака: {volume_Tank} Литров\nУровень топлива: {currentamount_Gasoline} Литров");
            Menu(cars);
        }
        protected override void Stop(List<Auto> cars)//Остановка
        {
            speed = 0;
            interval = 0;
            Console.WriteLine($"\n> Вы остановились\n");
            Console.WriteLine($"> Пробег автомобиля: {rast} км");
            Console.WriteLine($"> Вы желаете продолжить или закончить путь ?\n1 - Продолжить\n2 - Закончить\n");
            string? vybor = Console.ReadLine();
            if (vybor == "1")
            {
                Console.WriteLine($"> Номер авто: {number_Car}");
                Console.WriteLine($"> Пробег автомобиля: {rast} км");
                Drive2(cars);
            }
            else if (vybor == "2")
            {
                return;
            }
        }
        protected override void Razgon(List<Auto> cars) //Разгон
        {
            while (true)
            {
                try //для поиска ошибок try
                {
                    Console.WriteLine("\nВведите значение скорости от 1 до 180 км/ч, до которого хотите разогнаться:\n");
                    speed = Convert.ToDouble(Console.ReadLine());
                    carrying = place_Passenger_in_Bus * 70;
                    if (carrying > 0.1 && carrying <= 1)
                    {
                        speed *= 0.6;
                        Console.WriteLine($"\nС текущим весом  в {carrying} скорость уменьшена на 40%.");
                        Fuel_Consumption();
                    }
                    else
                    {
                        if (carrying > 1 && carrying <= 2)
                        {
                            speed *= 0.2;
                            Console.WriteLine($"\nС текущим весом в {carrying} скорость уменьшена на 80%.");
                            Fuel_Consumption();
                        }
                    }
                    if (speed > 0 && speed <= 180)
                    {
                        Fuel_Consumption();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nОшибка!");
                    }
                }
                catch
                {
                    Console.WriteLine("\nОшибка!");
                }
            }
        }
        protected void Fuel_Consumption() //рассчет расхода топлива от скорости
        {
            if (speed >= 1 && speed <= 45)
            {
                consumption_Fuel = 12;
                if ((currentamount_Gasoline - consumption_Fuel) >= 0)
                {
                    Drive2(cars);
                }
                else if ((currentamount_Gasoline - consumption_Fuel) < consumption_Fuel)
                {
                    Zapravka(cars);
                }
            }
            else if (speed >= 46 && speed <= 100)
            {
                consumption_Fuel = 9;
                if ((currentamount_Gasoline - consumption_Fuel) >= 0)
                {
                    Drive2(cars);
                }
                else if ((currentamount_Gasoline - consumption_Fuel) < consumption_Fuel)
                {
                    Zapravka(cars);
                }
            }
            else if (speed >= 101 && speed <= 180)
            {
                consumption_Fuel = 12.5;
                if ((currentamount_Gasoline - consumption_Fuel) >= 0)
                {
                    Drive2(cars);
                }
                else if ((currentamount_Gasoline - consumption_Fuel) < consumption_Fuel)
                {
                    Zapravka(cars);
                }
            }
        }
        protected override void Drive2(List<Auto> cars) // Метод езды автомобиля
        {
            if (speed > 0)
            {
                if (currentamount_Gasoline > 0)
                {
                    currentamount_Gasoline -= consumption_Fuel;
                    interval += 100;
                }
                else if ((currentamount_Gasoline - consumption_Fuel) < 0 & speed > 0)
                {
                    rast -= 100;
                    interval -= 100;
                    rast += kilometragh;
                    interval += kilometragh;
                    currentamount_Gasoline = 0;
                }
                else if (currentamount_Gasoline == 0)
                {
                    //interval = 0;
                    Console.WriteLine("Требуется заправка!");
                    Console.WriteLine("> Заправиться? (1 - Да / 2 - Нет)\n");
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
                else if (currentamount_Gasoline < 0)
                {
                    //interval = 0;
                    Console.WriteLine("Требуется заправка!");
                    Console.WriteLine("> Заправиться? (1 - Да / 2 - Нет)\n");
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
            }
            while (rast <= distance / 2)
            {
                if (currentamount_Gasoline < 2 && interval < distance / 2 && interval != 0) //!!!
                {
                    interval += kilometragh - 100;
                    currentamount_Gasoline = 0;
                    speed = 0;
                }
                if (interval >= Stops_Bus_dis & Stops_Bus_dis != 0) //Для маршрута
                {
                    remainder -= Stops_Bus_dis;
                    rast += Stops_Bus_dis;
                    interval += Stops_Bus_dis;

                    Console.WriteLine("Остановка!");
                    Console.WriteLine($"Уровень топлива: {currentamount_Gasoline} литров.");
                    Console.WriteLine($"Пробег: {rast} километров.");
                    Console.WriteLine($"Пассажиры: {Passenger}.");
                    Console.WriteLine("Сколько людей вошло?");
                    int voyti = Convert.ToInt32(Console.ReadLine());
                    if (voyti > place_Passenger_in_Bus)
                    {
                        Console.WriteLine("Автобус забит");
                        Passenger += place_Passenger_in_Bus;
                    }
                    else
                    {
                        Passenger += voyti;
                        Console.WriteLine($"В автобусе {Passenger} пассажиров");
                    }
                    Console.WriteLine("Сколько людей вышло?");
                    int vyti = Convert.ToInt32(Console.ReadLine());
                    if (vyti > place_Passenger_in_Bus)
                    {
                        Console.WriteLine("Автобус пуст!");
                        Passenger -= place_Passenger_in_Bus;
                    }
                    else
                    {
                        Passenger -= vyti;
                        Console.WriteLine($"В автобусе {Passenger} пассажиров");
                    }
                    if (rast == distance / 2 || rast == Number_Bus_Stops * Stops_Bus_dis)
                    {
                        rast = distance / 2;
                        remainder = distance / 2;
                        Console.WriteLine("ВНИМАНИЕ!!!Автобус на конечной Остановке!!!");
                        Console.WriteLine("ВНИМАНИЕ!!!Автобус Дальше автобус двигается только в обратном направлении!!!");
                    }
                }
                kilometragh = Math.Round((currentamount_Gasoline / consumption_Fuel) * 100); //На сколько километров хватит бензина

                Console.WriteLine($"\n> Вы проехали: {interval} км");// Интервал это то сколько -за раз едем, если остановаится он сбрасывается до 0 но пробег все еще остается!
                Console.WriteLine($"> Cколько проедем при текущем уровне бензина в баке: {kilometragh} км");
                Console.WriteLine($"> Сейчас в баке: {currentamount_Gasoline} литров");
                Console.WriteLine($"> Необходимо до последней остановки: {distance} км");
                Console.WriteLine($"> Пробег автомобиля: {rast} км");
                Console.WriteLine($"> Вы ехали со скоростью: {speed} км\n");
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
            while (rast <= distance && rast >= distance / 2)
            {
                if (interval >= remainder && Stops_Bus_dis != 0 && rast >= distance / 2 && rast >= distance && rast >= Stops_Bus_dis * Number_Bus_Stops) //Для маршрута !!!
                {
                    remainder = 0;
                    rast = distance;
                    interval += Stops_Bus_dis;
                    Console.WriteLine("База");
                    Console.WriteLine("");
                    Console.WriteLine($"Остаток топлива: {currentamount_Gasoline} литров.");
                    Console.WriteLine($"Пробег: {rast} километров.");
                    distance = 0;
                }
                if (currentamount_Gasoline < 2 && interval < distance && interval != 0)
                {
                    rast += kilometragh - 100;
                    interval += kilometragh - 100;
                    currentamount_Gasoline = 0;
                    speed = 0;
                }
                if (interval >= Stops_Bus_dis && Stops_Bus_dis != 0 && rast < distance) //Для маршрута
                {
                    if (remainder <= Stops_Bus_dis && rast < distance)
                    {
                        remainder -= Stops_Bus_dis;
                        rast += Stops_Bus_dis;
                        interval += Stops_Bus_dis;
                        Console.WriteLine("Остановка!");
                        Console.WriteLine($"Уровень топлива: {currentamount_Gasoline} литров.");
                        Console.WriteLine($"Пробег: {rast} километров.");
                        Console.WriteLine($"Пассажиры: {Passenger}.");
                        Console.WriteLine("Сколько людей вошло?");
                        int prihod = Convert.ToInt32(Console.ReadLine());
                        if (prihod > place_Passenger_in_Bus)
                        {
                            Console.WriteLine("Автбум забит!");
                            Passenger += place_Passenger_in_Bus;
                        }
                        else
                        {
                            Passenger += prihod;
                            Console.WriteLine($"В автобусе {Passenger} пассажиров");
                        }
                        Console.WriteLine("Сколько людей вышло?");
                        int uhod = Convert.ToInt32(Console.ReadLine());
                        if (uhod > place_Passenger_in_Bus)
                        {
                            Console.WriteLine("Все пассажиры вышли");
                            Passenger -= place_Passenger_in_Bus;
                        }
                        else
                        {
                            Passenger -= uhod;
                            Console.WriteLine($"В автобусе {Passenger} пассажиров");
                        }
                    }
                    else if (remainder >= Stops_Bus_dis)
                    {
                        remainder -= remainder;
                        remainder = 0;
                        rast = distance;
                        interval = 0;
                        Console.WriteLine("База");
                        Console.WriteLine($"Остаток топлива: {currentamount_Gasoline} литров.");
                        Console.WriteLine($"Пробег: {rast} километров.");
                        distance = 0;
                    }
                }
                kilometragh = Math.Round((currentamount_Gasoline / consumption_Fuel) * 100); //На сколько километров хватит бензина
                Console.WriteLine($"\n> Вы проехали: {interval} км");// Интервал это то сколько -за раз едем, если остановаится он сбрасывается до 0 но пробег все еще остается!
                Console.WriteLine($"> Cколько проедем при текущем уровне бензина в баке: {kilometragh} км");
                Console.WriteLine($"> Сейчас в баке: {currentamount_Gasoline} литров");
                Console.WriteLine($"> Необходимо до последней остановки: {distance} км");
                Console.WriteLine($"> Пробег автомобиля: {rast} км");
                Console.WriteLine($"> Вы ехали со скоростью: {speed} км\n");

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
        public override void Menu(List<Auto> cars)//меню выбора
        {
            Console.WriteLine(">> Меню:" +
                             "\n> 1 - Задать цель поездки" +//Выбираем начало и конец координат пути, для определения дистанции пути
                             "\n> 2 - Газ" +
                             "\n> 3 - Останавливаемся" +
                             "\n> 4 - Заправиться" +
                             "\n> 5 - Сменить автомобиль" +
                             "\n> 6 - Вызывть справку по машине" +
                             "\n> 7 - АВАРИЯ");

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
                    Out();
                    Menu(cars);
                    break;
                case "7":
                    Crash(cars);
                    break;
                default:
                    Console.WriteLine("\nКоманды с таким номером не существует");
                    break;
            }
        }
    }
}

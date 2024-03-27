using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Car
{
    internal class Auto
    {
        protected string? number_Car;//Номер машины
        protected string? type;
        protected double volume_Tank;//Объём бака
        protected double consumption_Fuel;//Расход топлива
        protected double speed;//Скорость
        protected double currentamount_Gasoline;//Текущее количество бензина
        protected double rast;//Пробег весь       

        protected double probeg; //Пробег
        protected double kilometragh; //На сколько километров хватит топлива

        protected double interval; //Расстояние
        protected double distance;//Дистанция
        protected string? massa;//
        protected int carrying;//Грузоподъемность
        protected double koordinata_Xa;//Координата X
        protected double koordinata_Ya;//Координата Y
        protected double koordinata_Xb;//Координата X
        protected double koordinata_Yb;//Координата Y
        static public List<Auto> cars;

        public string? Num_Car
        {
            get { return number_Car; }
        }
        public Auto()
        {
            Info(cars);
        }

        protected virtual void Info(List<Auto> cars) //Информация об автомобиле
        {
            Console.WriteLine("\n> Выбрать номер машины:\n1- Ввод вручную\n2- Автоматически");
            string? Choice_select_car_number = Console.ReadLine();
            if (Choice_select_car_number == "1")//Номер машины
            {
                Console.WriteLine("> Введите номер машины :");
                this.number_Car = Console.ReadLine();
                Console.WriteLine($"Номер машины : {number_Car}\n");
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
                Console.WriteLine($"Номер машины : {number_Car}\n");
            }//Номер машины
            Console.WriteLine("> Введите объем бака :\n1- Ввод вручную\n2- Автоматически");
            string? Choice_select_car_tank_volume = Console.ReadLine();
            if (Choice_select_car_tank_volume == "1")//Объем бака машины
            {
                Console.WriteLine("> Введите объем бака :");
                this.volume_Tank = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"Объем бака машины : {volume_Tank}\n");
            }//Объем бака машины
            if (Choice_select_car_tank_volume == "2")//Объем бака машины
            {
                Random rnd = new Random();
                int volume = rnd.Next(70, 90);
                this.volume_Tank = volume;
                Console.WriteLine($"Объем бака машины : {volume_Tank}\n");
            }//Объем бака машины
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
            this.type = "Автомобиль";
            this.speed = 0;//скорость
            this.carrying = 0;//скорость
            this.interval = 0;//расстояние что проехали
            this.rast = 0;//пробег
            this.kilometragh = 0;//На сколько километров хватит топлива
            this.massa = "2т";
            Console.WriteLine($"\n|Информация по машине|");
            Console.WriteLine("|Автомобиль занесен в базу, теперь его можете выбрать\n");
            Out();
            Menu(cars);
        }
        protected virtual void Path_Information(List<Auto> cars) // вводим информацию по пути 
        {
            Console.WriteLine("> Введите координаты вашего пути");
            Console.WriteLine("Начало-Xa: ");
            this.koordinata_Xa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Начало-Ya: ");
            this.koordinata_Xa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Конец-Xb: ");
            this.koordinata_Xb = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Конец-Yb: ");
            this.koordinata_Yb = Convert.ToInt32(Console.ReadLine());
            distance = Math.Sqrt(((koordinata_Xb - koordinata_Xa) * (koordinata_Xb - koordinata_Xa)) + ((koordinata_Yb - koordinata_Ya) * (koordinata_Yb - koordinata_Ya)));
            distance = Convert.ToInt32(distance);
            Console.WriteLine("\n> Данные внесены");
            Console.WriteLine($"Цель поездки проехать {distance} км");
            Console.WriteLine($"объем бака и уровень топлива в машине:\nбак: {volume_Tank} Литров\nТопливо: {currentamount_Gasoline} Литров\n");
            this.interval = 0;
            Menu(cars);
        }
        protected virtual void Stop(List<Auto> cars)//Остановка
        {
            speed = 0;
            interval = 0;
            Console.WriteLine($"\n> Вы остановились");
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
        protected virtual void Razgon(List<Auto> cars) //Разгон
        {
            while (true)
            {
                if (currentamount_Gasoline <= 0)
                {
                    interval = 0;
                    Console.WriteLine("Бак пуст");
                    Console.WriteLine($"Требуется заправка !");
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
                try //для поиска ошибок try
                {
                    Console.WriteLine("\nВведите значение скорости от 1 до 180 км/ч, до которого хотите разогнаться:\n");
                    speed = Convert.ToDouble(Console.ReadLine());
                    if (speed > 0 && speed <= 180)
                    {
                        Fuel_Consumption(speed);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nВведено значение вне заданного диапазона. Попробуйте снова.");
                    }
                }
                catch
                {
                    Console.WriteLine("\nВведено некорректное значение. Попробуйте снова.");
                }
            }
        }
        protected void Fuel_Consumption(double speed) //рассчет расхода топлива от скорости
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
        protected virtual void Crash(List<Auto> cars) //Авария
        {
            if (cars.Count == 1)
            {
                Console.WriteLine("Ваша машина единственная на трассе) ");
            }
            else if (cars.Count > 1)
            {
                for (int i = 0; i < cars.Count; i++) //Для одного участника движения ...
                {
                    for (int j = 0; j < cars.Count; j++) //...и для другого
                    {
                        if (i != j)
                        {
                            if (cars[i].koordinata_Xa == cars[j].koordinata_Xa && cars[i].koordinata_Ya == cars[j].koordinata_Ya) //Если начальные координаты обоих совпадают, то 
                            {
                                if (cars[i].distance < cars[j].distance)
                                {
                                    Console.WriteLine($"Авария произошла на участке в {cars[i].distance} км.");
                                    Menu(cars);
                                }
                                else if (cars[j].distance < cars[i].distance)
                                {
                                    Console.WriteLine($"Авария произошла на участке в {cars[i].distance} км.");
                                    Menu(cars);
                                }
                            }
                            else if (cars[i].koordinata_Xb == cars[j].koordinata_Xb && cars[i].koordinata_Yb == cars[j].koordinata_Yb) //Если начальные координаты обоих совпадают, то 
                            {
                                if (cars[i].distance < cars[j].distance)
                                {
                                    Console.WriteLine($"Авария произошла на участке в {cars[i].distance} км.");
                                    Menu(cars);
                                }
                                else if (cars[j].distance < cars[i].distance)
                                {
                                    Console.WriteLine($"Авария произошла на участке в {cars[i].distance} км.");
                                    Menu(cars);
                                }
                            }
                            if ((cars[i].koordinata_Xa < cars[j].koordinata_Xa && cars[i].koordinata_Ya < cars[j].koordinata_Ya) && (cars[i].koordinata_Xb > cars[j].koordinata_Xb && cars[i].koordinata_Yb > cars[j].koordinata_Yb))
                            {
                                if (cars[i].distance < cars[j].distance)
                                {
                                    Console.WriteLine($"Авария произошла на участке в {cars[i].distance} км.");
                                    Menu(cars);
                                }
                                else if (cars[j].distance < cars[i].distance)
                                {
                                    Console.WriteLine($"Авария произошла на участке в {cars[i].distance} км.");
                                    Menu(cars);
                                }
                            }
                            else if ((cars[i].koordinata_Xa > cars[j].koordinata_Xa && cars[i].koordinata_Ya > cars[j].koordinata_Ya) && (cars[i].koordinata_Xb < cars[j].koordinata_Xb && cars[i].koordinata_Yb < cars[j].koordinata_Yb))
                            {
                                if (cars[i].distance < cars[j].distance)
                                {
                                    Console.WriteLine($"Авария может произойти на участке в {cars[i].distance} км.");
                                    Menu(cars);
                                }
                                else if (cars[j].distance < cars[i].distance)
                                {
                                    Console.WriteLine($"Авария может произойти на участке в {cars[i].distance} км.");
                                    Menu(cars);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Аварии не случилось");
                                Menu(cars);
                            }
                        }
                    }
                }
            }
        }
        protected virtual void Drive2(List<Auto> cars) // Метод езды автомобиля
        {
            if (speed > 0)
            {
                if (currentamount_Gasoline > 0)//currentamount_Gasoline - Текущее количество бензина
                {
                    currentamount_Gasoline -= consumption_Fuel;
                    rast += 100;
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
                else if (currentamount_Gasoline == 0 || currentamount_Gasoline < consumption_Fuel)
                {
                    interval = 0;
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
            if (interval >= distance && distance != 0) //Для цели поездки
            {
                double vivo = distance - (interval - 100);
                //currentamount_Gasoline = (v * consumption_Fuel) / 100;
                rast += vivo - 100;
                speed = 0;
                distance = 0;
                interval = 0;
                Console.WriteLine("Вы выполнили цель поездки!");
                Console.WriteLine($"> Пробег автомобиля: {rast} км");
                Console.WriteLine($"\n1 - Вернутся в меню автомобиля\n2 - Закончить работу с автомобилем\n");
                string? vybor = Console.ReadLine();
                if (vybor == "1")
                {
                    Menu(cars);
                }
                else if (vybor == "2")
                {
                    return;
                }

            }
            if (currentamount_Gasoline < 2 && interval < distance && interval != 0)
            {
                rast += kilometragh - 100;
                interval += kilometragh - 100;
                currentamount_Gasoline = 0;
                speed = 0;
            }
            kilometragh = Math.Round((currentamount_Gasoline / consumption_Fuel) * 100); //На сколько километров хватит бензина
            Console.WriteLine($"\n> Вы проехали: {interval} км");// Интервал это то сколько -за раз едем, если остановаится он сбрасывается до 0 ну пробег все еще остается!
            Console.WriteLine($"> Cколько проедем при текущем уровне бензина в баке: {kilometragh} км");
            Console.WriteLine($"> Сейчас в баке: {currentamount_Gasoline} литров");
            Console.WriteLine($"> Необходимо проехать: {distance} км");
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
        protected virtual double Zapravka(List<Auto> cars) //Заправка
        {
            speed = 0;
            Console.WriteLine($"> Сколько литров Вы хотите заправить в бак?\n" +
            $"> Объем бака автомобиля: {volume_Tank},\n> Нынешний уровень топлива в автомобиле: {currentamount_Gasoline} литров.");

            double zapravim = Convert.ToDouble(Console.ReadLine());
            if ((currentamount_Gasoline + zapravim) <= volume_Tank) //Условие на случай переполнения бака
            {
                currentamount_Gasoline += zapravim;
                Console.WriteLine($"Автомобиль заправлен. Сейчас в машине: {currentamount_Gasoline} литров.");
                Menu(cars);
            }
            else
            {
                currentamount_Gasoline = volume_Tank;
                Console.WriteLine($"\nВы заливаете слишком многоЙ! излишки убраны");
                Console.WriteLine($"Ваш автомобиль заправлен. Сейчас в машине: {currentamount_Gasoline} литров.");
                Menu(cars);
            }
            return currentamount_Gasoline;
        }
        protected virtual void Out()//Вывод информации
        {
            Console.WriteLine($"\n|Номер автомобиля: {number_Car}" +
                              $"\n|Категория автомобиля: {type}" +
                              $"\n|Масса автомобиля: {massa}" +
                              $"\n|Объём бака: {volume_Tank}" +
                              $"\n|Уровень топлива: {currentamount_Gasoline}" +
                              $"\n|Расход топлива: {consumption_Fuel}" +
                              $"\n|Пробег автомобиля: {rast}");// за все время, ведь пробег же
        }
        public virtual void Menu(List<Auto> cars)//меню выбора
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
                    return;
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
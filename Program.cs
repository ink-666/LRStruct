using System;

namespace StructsWithOverload
{
    // ==========================================================
    // КЛАСС Vehicle (из предыдущей работы) - для сравнения
    // ==========================================================
    class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public Vehicle(string make, string model, int year, decimal price)
        {
            Console.WriteLine($"   [КЛАСС] Конструктор Vehicle: {make} {model}");
            Make = make;
            Model = model;
            Year = year;
            Price = price;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"   [КЛАСС] {Make} {Model}, {Year} год, {Price} руб.");
        }
    }

    // ==========================================================
    // КЛАСС Car (наследник Vehicle)
    // ==========================================================
    class Car : Vehicle
    {
        public int NumDoors { get; set; }
        public string BodyStyle { get; set; }

        public Car(string make, string model, int year, decimal price, int numDoors, string bodyStyle)
            : base(make, model, year, price)
        {
            Console.WriteLine($"   [КЛАСС] Конструктор Car: дверей={numDoors}, кузов={bodyStyle}");
            NumDoors = numDoors;
            BodyStyle = bodyStyle;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"   [КЛАСС] Автомобиль: {Make} {Model}, {Year} г., {Price} руб., {NumDoors} дв., {BodyStyle}");
        }
    }

    // ==========================================================
    // СТРУКТУРА Point (новая структура для демонстрации)
    // ==========================================================
    struct Point
    {
        // Поля структуры
        public int X;
        public int Y;

        // Статическое поле (общее для всех точек)
        public static string CoordinateSystem = "Декартова";

        // Конструктор 1: с параметрами
        public Point(int x, int y)
        {
            Console.WriteLine($"   [СТРУКТУРА] Конструктор Point({x}, {y})");
            X = x;
            Y = y;
        }

        // Конструктор 2: без параметров (C# 10+)
        public Point() : this(0, 0)
        {
            Console.WriteLine("   [СТРУКТУРА] Конструктор Point() по умолчанию");
        }

        // Метод для вывода
        public void Display()
        {
            Console.WriteLine($"   [СТРУКТУРА] Точка: ({X}, {Y}) в системе {CoordinateSystem}");
        }

        // Перегрузка метода Display (разные версии)
        public void Display(string prefix)
        {
            Console.WriteLine($"   {prefix} Точка: ({X}, {Y})");
        }

        public void Display(bool showSystem)
        {
            if (showSystem)
                Console.WriteLine($"   Точка: ({X}, {Y}) - {CoordinateSystem}");
            else
                Console.WriteLine($"   Точка: ({X}, {Y})");
        }

        // Метод для перемещения точки
        public void Move(int deltaX, int deltaY)
        {
            X += deltaX;
            Y += deltaY;
        }
    }

    // ==========================================================
    // СТРУКТУРА Rectangle (ещё одна структура для демонстрации)
    // ==========================================================
    struct Rectangle
    {
        // Поля
        public double Width;
        public double Height;

        // Конструктор
        public Rectangle(double width, double height)
        {
            Console.WriteLine($"   [СТРУКТУРА] Конструктор Rectangle({width}, {height})");
            Width = width;
            Height = height;
        }

        // Свойство только для чтения (вычисляемое)
        public double Area
        {
            get { return Width * Height; }
        }

        // Перегрузка метода Display
        public void Display()
        {
            Console.WriteLine($"   [СТРУКТУРА] Прямоугольник: {Width} x {Height}, площадь: {Area}");
        }

        public void Display(string unit)
        {
            Console.WriteLine($"   [СТРУКТУРА] Прямоугольник: {Width}{unit} x {Height}{unit}, площадь: {Area}{unit}²");
        }
    }

    // ==========================================================
    // КЛАСС Helper с перегрузкой методов (из предыдущей работы)
    // ==========================================================
    class Helper
    {
        // Перегрузка для целого числа
        public void Display(int number)
        {
            Console.WriteLine($"   [ПЕРЕГРУЗКА] Helper.Display(int): {number}");
        }

        // Перегрузка для строки
        public void Display(string text)
        {
            Console.WriteLine($"   [ПЕРЕГРУЗКА] Helper.Display(string): \"{text}\"");
        }

        // Перегрузка для двух целых чисел
        public void Display(int a, int b)
        {
            Console.WriteLine($"   [ПЕРЕГРУЗКА] Helper.Display(int, int): {a} и {b}");
        }

        // Перегрузка для Point (структура)
        public void Display(Point point)
        {
            Console.WriteLine($"   [ПЕРЕГРУЗКА] Helper.Display(Point): точка ({point.X}, {point.Y})");
        }

        // Перегрузка для Rectangle (структура)
        public void Display(Rectangle rect)
        {
            Console.WriteLine($"   [ПЕРЕГРУЗКА] Helper.Display(Rectangle): {rect.Width} x {rect.Height}");
        }

        // Перегрузка для Vehicle (класс)
        public void Display(Vehicle vehicle)
        {
            Console.WriteLine($"   [ПЕРЕГРУЗКА] Helper.Display(Vehicle): {vehicle.Make} {vehicle.Model}");
            vehicle.DisplayInfo();
        }

        // Обобщённый метод Swap (из предыдущей работы)
        public void Swap<T>(ref T first, ref T second)
        {
            Console.WriteLine($"   [ОБОБЩЁННЫЙ МЕТОД] Swap<{typeof(T).Name}>");
            T temp = first;
            first = second;
            second = temp;
        }

        // Специальная версия для Point (чтобы показать разницу с классом)
        public void SwapPoints(ref Point p1, ref Point p2)
        {
            Console.WriteLine("   [МЕТОД] SwapPoints (специально для структур)");
            Point temp = p1;
            p1 = p2;
            p2 = temp;
        }
    }

    // ==========================================================
    // ГЛАВНЫЙ КЛАСС ПРОГРАММЫ
    // ==========================================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №4: СТРУКТУРЫ И ПЕРЕГРУЗКА МЕТОДОВ");
            Console.WriteLine("==========================================\n");

            // Создаём Helper для демонстрации перегрузки
            Helper helper = new Helper();

            // ============= ЧАСТЬ 1: ДЕМОНСТРАЦИЯ СТРУКТУР =============
            Console.WriteLine("--- ЧАСТЬ 1: Создание и работа со структурами ---\n");

            // Создание структуры разными способами
            Console.WriteLine(">> Способ 1: Конструктор с параметрами");
            Point p1 = new Point(5, 10);
            p1.Display();
            Console.WriteLine();

            Console.WriteLine(">> Способ 2: Конструктор по умолчанию");
            Point p2 = new Point();
            p2.Display();
            Console.WriteLine();

            Console.WriteLine(">> Способ 3: Прямая инициализация полей");
            Point p3;
            p3.X = 15;
            p3.Y = 25;
            p3.Display("Прямая инициализация:");
            Console.WriteLine();

            // Статическое поле
            Console.WriteLine(">> Статическое поле структуры");
            Console.WriteLine($"   Система координат: {Point.CoordinateSystem}");
            Point.CoordinateSystem = "Полярная";
            Console.WriteLine($"   Изменили на: {Point.CoordinateSystem}");
            p1.Display();
            Console.WriteLine();

            // Создание прямоугольника
            Console.WriteLine(">> Создание Rectangle");
            Rectangle rect1 = new Rectangle(12.5, 8.3);
            rect1.Display();
            rect1.Display("см");
            Console.WriteLine();

            // ============= ЧАСТЬ 2: ПЕРЕГРУЗКА МЕТОДОВ СО СТРУКТУРАМИ =============
            Console.WriteLine("--- ЧАСТЬ 2: Перегрузка методов с использованием структур ---\n");

            Console.WriteLine(">> Вызов Helper.Display с разными типами:");
            helper.Display(42);                 // int
            helper.Display("Привет");           // string
            helper.Display(10, 20);              // int, int
            helper.Display(p1);                  // Point
            helper.Display(rect1);                // Rectangle
            Console.WriteLine();

            // ============= ЧАСТЬ 3: КОПИРОВАНИЕ СТРУКТУР =============
            Console.WriteLine("--- ЧАСТЬ 3: Копирование структур (значимые типы) ---\n");

            Point original = new Point(100, 200);
            Point copy = original; // Копирование (создаётся новая копия)

            Console.WriteLine("   original = (100, 200), copy = original");
            Console.WriteLine("   Изменяем copy.Move(50, 50):");
            
            copy.Move(50, 50);
            
            Console.WriteLine("   original:");
            original.Display("   original:");
            Console.WriteLine("   copy:");
            copy.Display("   copy:");
            Console.WriteLine("   !!! original НЕ изменилась (структура - значимый тип)");
            Console.WriteLine();

            // ============= ЧАСТЬ 4: СРАВНЕНИЕ С КЛАССАМИ =============
            Console.WriteLine("--- ЧАСТЬ 4: Сравнение с классами (для контраста) ---\n");

            // Создаём объекты классов
            Car car1 = new Car("Toyota", "Camry", 2022, 2900000, 4, "седан");
            Car car2 = car1; // Ссылка на тот же объект

            Console.WriteLine("\n   car2 = car1 (ссылка на тот же объект)");
            Console.WriteLine("   Изменяем car2.Price = 3000000:");
            
            car2.Price = 3000000;
            
            Console.WriteLine("   car1.Price:");
            Console.WriteLine($"   car1: {car1.Price} руб.");
            Console.WriteLine("   !!! car1 ИЗМЕНИЛСЯ (класс - ссылочный тип)");
            Console.WriteLine();

            // ============= ЧАСТЬ 5: ОБОБЩЁННЫЙ МЕТОД СО СТРУКТУРАМИ =============
            Console.WriteLine("--- ЧАСТЬ 5: Обобщённый метод Swap со структурами ---\n");

            Point a = new Point(1, 2);
            Point b = new Point(3, 4);

            Console.WriteLine("   До Swap:");
            a.Display("   a:");
            b.Display("   b:");

            helper.Swap(ref a, ref b);

            Console.WriteLine("\n   После Swap:");
            a.Display("   a:");
            b.Display("   b:");
            Console.WriteLine();

            // ============= ЧАСТЬ 6: ОСОБЕННОСТИ ПЕРЕДАЧИ СТРУКТУР =============
            Console.WriteLine("--- ЧАСТЬ 6: Передача структур в методы ---\n");

            Point point = new Point(7, 8);
            Console.WriteLine("   До вызова метода:");
            point.Display("   point:");

            ModifyPoint(point); // Передаётся КОПИЯ структуры

            Console.WriteLine("\n   После вызова ModifyPoint(point):");
            point.Display("   point:");
            Console.WriteLine("   !!! point НЕ изменилась (передаётся копия)");

            ModifyPointRef(ref point); // Передаётся по ссылке

            Console.WriteLine("\n   После вызова ModifyPointRef(ref point):");
            point.Display("   point:");
            Console.WriteLine("   !!! point ИЗМЕНИЛАСЬ (передана по ссылке)");
            Console.WriteLine();

            // ============= ЧАСТЬ 7: МАССИВЫ СТРУКТУР =============
            Console.WriteLine("--- ЧАСТЬ 7: Массивы структур ---\n");

            Point[] points = new Point[3];
            points[0] = new Point(1, 1);
            points[1] = new Point(2, 2);
            points[2] = new Point(3, 3);

            Console.WriteLine("   Массив точек:");
            foreach (var p in points)
            {
                p.Display("   ");
            }
            Console.WriteLine();

            // ============= ИТОГ =============
            Console.WriteLine("==========================================");
            Console.WriteLine("ИТОГ РАБОТЫ СО СТРУКТУРАМИ:");
            Console.WriteLine("==========================================");
            Console.WriteLine("✓ Структуры - значимые типы (хранятся в стеке)");
            Console.WriteLine("✓ При присваивании создаётся КОПИЯ");
            Console.WriteLine("✓ Можно перегружать методы для структур");
            Console.WriteLine("✓ Есть статические поля");
            Console.WriteLine("✓ Можно использовать обобщённые методы");
            Console.WriteLine("✓ В отличие от классов - не поддерживают наследование");
            Console.WriteLine("==========================================");
        }

        // Метод для демонстрации передачи структуры по значению
        static void ModifyPoint(Point p)
        {
            Console.WriteLine("   >>> Внутри ModifyPoint (передана КОПИЯ)");
            p.Move(100, 100);
            Console.WriteLine("       После Move(100, 100) внутри метода:");
            p.Display("       p:");
            Console.WriteLine("   <<< Выход из ModifyPoint (копия уничтожается)");
        }

        // Метод для демонстрации передачи структуры по ссылке
        static void ModifyPointRef(ref Point p)
        {
            Console.WriteLine("   >>> Внутри ModifyPointRef (передана ССЫЛКА)");
            p.Move(100, 100);
            Console.WriteLine("       После Move(100, 100) внутри метода:");
            p.Display("       p:");
            Console.WriteLine("   <<< Выход из ModifyPointRef");
        }
    }
}
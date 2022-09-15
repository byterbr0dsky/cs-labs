namespace MyProgram 
{
    public class Program
    {
        private static double[] GetInput(int n)
        {
            var input_array = Console.ReadLine()!.Split(' ');
            var input_values = new double[n];

            try
            {
                for (int i = 0; i < n; i++) input_values[i] = double.Parse(input_array[i]);
            }
            catch (System.FormatException error) { Console.WriteLine(error.Message); }

            return input_values;
        }

        private static void Task1() 
        {
            Console.WriteLine("\n1) Введите строку значений (x, y, z): ");
            var input_1 = GetInput(3);

            CalculateAB(input_1[0], input_1[1], input_1[2]);

            Console.WriteLine("\n2) Введите строку значений (H, V): ");
            var input_2 = GetInput(2);

            Console.WriteLine("Falling time: {0}", CalculateTime(input_2[0], input_2[1]));

            Console.WriteLine("\n3) Введите строку значений (a,b,c): ");

            var inpute_3 = GetInput(3);

            Console.WriteLine((CalculateTruth(inpute_3[0], inpute_3[1], inpute_3[2]) ? "Can" : "Can\'t") + " calcualte yravnenie");

            var inpute_4 = GetInput(4);

            Console.WriteLine("Введите строку значений (a,b,h,R");

            for (int i = 0; i < 6; i++) Console.WriteLine($"S = {Figura(inpute_4[0], inpute_4[1], inpute_4[2], i,  inpute_4[3])}, n = {i}");

            void CalculateAB(double x, double y, double z) 
            {
                double a = y + (x / (Math.Pow(y, 2) + Math.Abs(Math.Pow(x, 2) / (y + Math.Pow(x, 2))))),
                    b = Math.Pow(1+Math.Pow(Math.Tan(z/2),2),2);

                Console.WriteLine($"Result - A: {a}, B: {b}");
            }

            double CalculateTime(double h, double _v) 
            {
                double v = Math.Sqrt(2 * 10.0 * h + Math.Pow(_v, 2));
                return (v - _v) / 10.0;
            }

            bool CalculateTruth(double a, double b, double c) => (Math.Pow(b, 2) - (4.0 * a * c) < 0);

            double Figura(double a, double b, double h , int n, double R)
            {
                switch (n)
                {
                    case 1: return a * b;
                    case 2: return a * h / 2;
                    case 3: return (a + b) * h / 2;
                    case 4: return Math.PI * Math.Pow(R, 2);
                    case 5: return Math.PI * Math.Pow(R, 2) * a / 360.0;
                    default: 
                        Console.WriteLine("4to-to poshlo ne tak"); 
                        return 0;
                }
            }

        }

        private enum MotoType { Scooter = 1, Classic, Sports, Tourer }
        private struct MotoBike 
        {
            private const double StandantSpeed = 101.0;
            private static int CurrentServiceNumber = 0;

            public double Speed { get; set; } = 0;
            public int ServiceNumber { get; private set; }
            public MotoType Type { get; private set; }
            public double MaxSpeed { get; set; }

            public MotoBike(double maxspeed, MotoType type)
            {
                this.MaxSpeed = maxspeed;
                this.ServiceNumber = CurrentServiceNumber++;
                this.Type = type;
            }

            public MotoBike() : this(StandantSpeed, MotoType.Classic) { }

            public void SpeedUp(double speed)
            {
                if (Speed + speed > MaxSpeed || Speed + speed < 0) Console.WriteLine("Неверное значение");
                else
                {
                    this.Speed += speed;
                    Console.WriteLine("Текущая скорость = " + Speed);
                }
            }

            public string GetState() => $"Скорость: {Speed}, Максимальная скорость: {MaxSpeed}, Тип: {Type.ToString()}, " +
                $"Сервисный номер: {ServiceNumber}";

            public override string ToString() => this.GetState();
        }

        private static void Task2() 
        {
            Console.WriteLine("Создание нового объекта структуры \"Мотоцикл\"");
            MotoBike motobike_object = CreateMotoBike();
            
            while (true)
            {
                Console.Write("\n1) - Получение текущего состояния; 2) - Изменение скорости; 3) - Создать новый; 4) - Выход\n" +
                    "Введите номер операции: ");
                int input_value = default(int);

                try { input_value = int.Parse(Console.ReadLine()!); }
                catch (System.FormatException error) { Console.WriteLine(error.Message); return; }

                switch (input_value)
                {
                    case 1: Console.WriteLine(motobike_object.GetState()); break;
                    case 2:
                    {
                        Console.Write("Введите значение: ");
                        double delta_speed = default(double);

                        try { delta_speed = double.Parse(Console.ReadLine()!); }
                        catch (System.FormatException error) { Console.WriteLine(error.Message); return; }

                        motobike_object.SpeedUp(delta_speed);
                        break;
                    }
                    case 3: motobike_object = CreateMotoBike(); break;
                    case 4: return;
                    default: Console.WriteLine("Указано неверное значение"); break;
                }
            }

            MotoBike CreateMotoBike() 
            {
                try
                {
                    Console.WriteLine("Выберите тип мотоцикла: { 1 - Скутер, 2 - Классический, 3 - Спортивный, 4 - Турист. }");
                    var moto_type = (MotoType)Enum.Parse(typeof(MotoType), Console.ReadLine()!);

                    Console.WriteLine("Установите максимальную скорость мотоцикла:");
                    var moto_maxspeed = Int64.Parse(Console.ReadLine()!);

                    if (moto_maxspeed <= 0)
                    {
                        throw new Exception("Установите нормальное значение скорости (>_<)");
                    }
                    return new MotoBike(moto_maxspeed, moto_type);
                }
                catch (System.Exception error)
                {
                    Console.WriteLine(error.Message + "; " + error.GetType());
                    return new MotoBike();
                }
            }
        }

        public static void Main(string[] args) 
        {
            while (true)
            {
                Console.WriteLine("Что необходимо выполнить?\n1) - Задание 1\n2) - Задание 2\n3) - Завершение программы\n");
                int input_value = default(int);

                try { input_value = int.Parse(Console.ReadLine()!); }
                catch (System.FormatException error) { Console.WriteLine(error.Message); return; }

                switch (input_value)
                {
                    case 1: Program.Task1(); break;
                    case 2: Program.Task2(); break;
                    case 3: return;
                    default: Console.WriteLine("Указано неверное значение"); break;
                }
                Console.WriteLine("Нажмите клавишу для продолжения");
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
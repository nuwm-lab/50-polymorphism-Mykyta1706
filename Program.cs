using System;

namespace LabWork
{
    // Базовий клас
    class Celipsoid
    {
        public double a1, a2, a3;

        // Віртуальний метод для введення даних
        public virtual void Inita()
        {
            Console.WriteLine("Введiть пiвосi елiпсоїда (a1, a2, a3):");
            a1 = double.Parse(Console.ReadLine());
            a2 = double.Parse(Console.ReadLine());
            a3 = double.Parse(Console.ReadLine());
        }

        // Віртуальний метод для показу даних
        public virtual void Show() => Console.WriteLine($"Елiпсоїд: a1={a1}, a2={a2}, a3={a3}");

        // Віртуальний метод для обчислення об'єму
        public virtual double Size() => (4.0 / 3.0) * Math.PI * a1 * a2 * a3;
    }

    // Похiдний клас
    class Cball : Celipsoid
    {
        public double r;

        // Перевизначення (поліморфізм)
        public override void Inita()
        {
            Console.Write("Введiть радiус кулi: ");
            r = double.Parse(Console.ReadLine());
            a1 = a2 = a3 = r; // У кулі всі півосі рівні радіусу
        }

        public override void Show() => Console.WriteLine($"Куля: радiус={r}");

        public override double Size() => (4.0 / 3.0) * Math.PI * Math.Pow(r, 3);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Celipsoid obj; // Унiверсальне посилання базового класу

            Console.WriteLine("Виберiть об'єкт: 1 - Елiпсоїд, 2 - Куля");
            string choice = Console.ReadLine();

            if (choice == "2")
                obj = new Cball();    // Створення об'єкта похiдного класу
            else
                obj = new Celipsoid(); // Створення об'єкта базового класу

            // Виклик методiв через універсальне посилання
            obj.Inita();
            obj.Show();
            Console.WriteLine($"Об'єм: {obj.Size():F2}");

            Console.WriteLine("\nНатиснiть будь-яку клавiшу для виходу...");
            Console.ReadKey();
        }
    }
}
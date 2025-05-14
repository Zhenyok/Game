using System;
using System.Linq;
using System.Collections.Generic;

namespace Lesson5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("============================================");
            Console.WriteLine("What task do you want to execute? Select task from 1 to 3");
            
            Task task = (Task) int.Parse(Console.ReadLine());
            
            Action action = task switch
            {
                Task.First => FirstTask,
                Task.Second => SecondTask,
                Task.Third => ThirdTask,
                _ => () => Console.WriteLine("You entered an invalid task number")
            };

            action();
        }

        static void FirstTask()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("Start show elements");

            int[] numbers = new int[50];

            for (int i = 0; i < 50; i++)
            {
                numbers[i] = (i + 1) * 2;
            }
            
            foreach (var number in numbers)
            {
                Console.WriteLine($"Element: {number}");
            }
        }

        static void SecondTask()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("Show random numbers");
            
            Random random = new Random();
            
            int[] numbers = new int[25];

            for (int i = 0; i < 25; i++)
            {
                numbers[i] = random.Next(1, 101);
            }

            List<int> randomNumbers = new List<int>();
            
            foreach (int number in numbers)
            {
                if (number % 2 == 0) // Перевірка на парність
                {
                    randomNumbers.Add(number); // Додаємо парне число до списку
                }
            }
            
            Console.WriteLine($"Array include {randomNumbers.Count} pair numbers.");
            Console.WriteLine("It`s: " + string.Join(", ", randomNumbers));
        }

        static void ThirdTask()
        {
            Console.WriteLine("============================================");
            
            Console.WriteLine("Put your string");
            string value = Console.ReadLine();
            
            Console.WriteLine($"Write text: {value}");
            Console.WriteLine($"Text - \"{value}\" include: {value.Length} symbols");
            
            Console.WriteLine("What symbol do you want find?");
            string symbol = Console.ReadLine();
            
            if (symbol.Length == 1)
            {
                int count = value.Count(c => char.ToLower(c) == char.ToLower(symbol[0]));

                Console.WriteLine($"The symbol '{symbol}' appears {count} times in the string.");
            }
            else
            {
                Console.WriteLine("Please enter exactly one symbol.");
            }
        }
    }
}
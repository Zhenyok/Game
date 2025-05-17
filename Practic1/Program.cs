using System;

namespace Practic1
{
    internal class Program
    {
        private static bool continueGame = true;
        private static string PlayerName;
        private static int PlayerAge;
        private static int PlayerWin = 0;
        private static int PlayerLoss = 0;
        private static int PlayerRound = 0;
        
        public static void Main(string[] args)
        {
           Game();
        }

        private static void Game()
        {
            do
            {
                Console.WriteLine("============================================");
                Console.WriteLine("Hi player. We glad to see you here");
                
                SetName();
                SetAge();

                if (!continueGame)
                {
                    return;
                }

                ShowPlayerStats();

                continueGame = false;
                
            } while (continueGame);
        }
        
        private static void ShowPlayerStats()
        {
            string border = new string('═', 30);
            
            Console.WriteLine($"╔{border}╗");
            Console.WriteLine($"║Player round : {PlayerRound,-15}║");
            Console.WriteLine($"╠{border}╣");
            Console.WriteLine($"║ Name    : {PlayerName,-19}║");
            Console.WriteLine($"║ Age     : {PlayerAge,-19}║");
            Console.WriteLine($"║ Win     : {PlayerWin,-19}║");
            Console.WriteLine($"║ Loss    : {PlayerLoss,-19}║");
            Console.WriteLine($"╚{border}╝");
        }

        private static void SetName()
        {
            var isValidName = false;
            
            while (!isValidName)
            {
                Console.WriteLine("What is it your name?");
                PlayerName = Console.ReadLine();
                
                if (PlayerName.Length > 18 )
                {
                    Console.WriteLine("Please enter a name shorter than 18 characters");
                    continue;
                }
                
                isValidName = true;
            }
            
            Console.WriteLine($"Nice to meet you {PlayerName}");
        }
        
        private static void SetAge()
        {
            Console.WriteLine("Let`s put your age and we will start play?");
            Console.WriteLine("How old are you?");
            
            PlayerAge = int.Parse(Console.ReadLine());

            if (PlayerAge < 13 )
            {
                Console.WriteLine("Sorry but you can not play. Please try again");
                continueGame = false;
            }
        }
    }
}
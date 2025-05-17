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
                SayHello();
                SetName();
                SetAge();

                if (!continueGame)
                {
                    SayGoodbye();
                    
                    return;
                }

                ShowPlayerStats();

                StartGame();
                
                if (!continueGame)
                {
                    SayGoodbye();
                    
                    return;
                }

            } while (continueGame);
        }

        private static void StartGame()
        {
            AskStartGame();
            
            int isStart;
            
            while (true)
            {
                Console.Write("Your choice (1 or 0): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out isStart) && (isStart == 0 || isStart == 1))
                {
                    break;
                }
    
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Please enter 0 or 1.");
                Console.ResetColor();
            }

            if (isStart == 0)
            {
                continueGame = false;
            }
        }

        private static void SetName()
        {
            var isValidName = false;
            
            while (!isValidName)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("╔════════════════════════════════════╗");
                Console.WriteLine("║ What is your name?                 ║");
                Console.WriteLine("╚════════════════════════════════════╝");
                Console.ResetColor();
            
                PlayerName = Console.ReadLine();
                
                if (PlayerName.Length > 18 )
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a name shorter than 18 characters.");
                    Console.ResetColor();
                    
                    continue;
                }
                
                isValidName = true;
            }
            
            string message = $"Nice to meet you, {PlayerName}!";
            string border = new string('═', message.Length + 4);
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"╔{border}╗");
            Console.WriteLine($"║  {message}  ║");
            Console.WriteLine($"╚{border}╝");
            Console.ResetColor();
        }
        
        private static void SetAge()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║ How old are you?                   ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.ResetColor();
            
            
            PlayerAge = int.Parse(Console.ReadLine());

            if (PlayerAge < 13 )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry but you can not play. Please grow up ^-^");
                Console.ResetColor();
                
                continueGame = false;
            }
        }

        private static void AskStartGame()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║ Are you ready to enter the battle?         ║");
            Console.WriteLine("║                                            ║");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("║ [1] Yes                                    ║");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("║ [0] No                                     ║");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.Write("Your choice: ");
        }

        private static void ShowPlayerStats()
        {
            string border = new string('═', 30);
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"╔{border}╗");
            Console.WriteLine($"║Player round : {PlayerRound,-15}║");
            Console.WriteLine($"╠{border}╣");
            Console.WriteLine($"║ Name    : {PlayerName,-19}║");
            Console.WriteLine($"║ Age     : {PlayerAge,-19}║");
            Console.WriteLine($"║ Win     : {PlayerWin,-19}║");
            Console.WriteLine($"║ Loss    : {PlayerLoss,-19}║");
            Console.WriteLine($"╚{border}╝");
        }
        
        private static void SayHello()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║           WELCOME TO THE GAME!             ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║  HI PLAYER. WE'RE GLAD TO SEE YOU HERE!    ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        private static void SayGoodbye()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("╔═══════════════════════╗");
            Console.WriteLine("║      GOODBYE!         ║");
            Console.WriteLine("║   UNTIL NEXT TIME!    ║");
            Console.WriteLine("╚═══════════════════════╝");
            Console.ResetColor();
        }
    }
}
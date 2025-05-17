using System;

namespace Practic1
{
    internal class Program
    {
        // System properties
        private static bool continueGame = true;
        private static int countGames = 0;
        private static string[] weapons = { "Rock", "Paper", "Scissors" };
        
        // Player properties 
        private static string PlayerName;
        private static int PlayerAge;
        private static int PlayerWin = 0;
        private static int PlayerLoss = 0;
        private static int PlayerWeapon = 0;
        private static int PlayerScore = 0;
        
        // Bot properties 
        private static int BotWin = 0;
        private static int BotWeapon = 0;
        private static int BotScore = 0;

        public static void Main(string[] args)
        {
            Game();
        }

        private static void Game()
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
                
            do
            {

                if (!continueGame)
                {
                    SayGoodbye();

                    return;
                }

                for (int round = 1; round <= 3; round++)
                {
                    Console.WriteLine($"ROUND {round}/3\n");

                    bool roundNotFinished = true;
                    
                    do
                    {
                        SelectWeapon();
                        SetWeaponForBot();
                    
                        ShowChoices();
                        ResolveRound(ref roundNotFinished);
                    } while (roundNotFinished);
                    
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }
                
                ShowFinalResults();
                
                ShowPlayerStats();

                StartGame();

            } while (continueGame);
        }
        
        static void ShowFinalResults()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║        GAME OVER                           ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine($"║ {PlayerName}: {PlayerScore} wins          ║");
            Console.WriteLine($"║ Bot: {BotScore} wins                      ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();

            if (PlayerScore > BotScore)
            {
                Console.WriteLine("\n You are the winner!");
                PlayerWin++;
            }
            else if (BotScore > PlayerScore)
            {
                Console.WriteLine("\n Bot wins! Better luck next time.");
                PlayerLoss++;
                BotWin++;
            }

            countGames++;
        }
        
        static void ResolveRound(ref bool roundNotFinished)
        {
            if (PlayerWeapon == BotWeapon)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("It's a draw!");
                roundNotFinished = true;
            } 
            else if ((PlayerWeapon == 1 && BotWeapon == 3) || (PlayerWeapon == 2 && BotWeapon == 1) || (PlayerWeapon == 3 && BotWeapon == 2))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You win this round!");
                PlayerScore++;
                roundNotFinished = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You lost this round!");
                BotScore++;
                roundNotFinished = false;
            }

            Console.ResetColor();
        }
        
        private static void ShowChoices()
        {
            Console.WriteLine($"\n{PlayerName} chose: {weapons[PlayerWeapon - 1]}");
            Console.WriteLine($"Bot chose: {weapons[BotWeapon - 1]}");
        }

        private static void SetWeaponForBot()
        {
            Random random = new Random();
            
            BotWeapon = random.Next(1, 4);
        }
        
        private static void SelectWeapon()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║         CHOOSE YOUR WEAPON!                ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║ [1] ROCK                                   ║");
            Console.WriteLine("║ [2] PAPER                                  ║");
            Console.WriteLine("║ [3] SCISSORS                               ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.Write("Your choice: "); 
            
            int weapon;

            while (true)
            { 
                string input = Console.ReadLine();

                if (int.TryParse(input, out weapon) && (weapon >= 1 && weapon <= 3))
                {
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Please enter 1, 2 or 3.");
                Console.ResetColor();
            }

            PlayerWeapon = weapon;
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
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║            What is your name?              ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
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
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine($"          Nice to meet you, {PlayerName}!");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        
        private static void SetAge()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║              How old are you?              ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
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

            var message = countGames == 0
                ? "Are you ready to start the battle?"
                : PlayerWin > BotWin 
                    ? "Do you want to destroy bot again?" 
                    : "Do you want a rematch against the bot?"
            ;
            
            Console.WriteLine($"        {message}");
            Console.WriteLine("╔════════════════════════════════════════════╗");
            
            Console.WriteLine("║                                            ║");

            Console.Write("║ [1] ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Yes");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string(' ', 36) + "║");
            
            Console.Write("║ [0] ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("No");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string(' ', 37) + "║");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.Write("Your choice: ");
        }

        private static void ShowPlayerStats()
        {
            string border = new string('═', 44);
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"╔{border}╗");
            Console.WriteLine($"║ Name    : {PlayerName,-33}║");
            Console.WriteLine($"║ Age     : {PlayerAge,-33}║");
            Console.WriteLine($"║ Win     : {PlayerWin,-33}║");
            Console.WriteLine($"║ Loss    : {PlayerLoss,-33}║");
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
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║                 GOODBYE!                   ║");
            Console.WriteLine("║             UNTIL NEXT TIME!               ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
    }
}
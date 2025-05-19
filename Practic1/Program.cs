using System;

namespace Practic1
{
    internal class Program
    {
        // System properties
        private static bool continueGame = true;
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
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║               Start battle                 ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.ResetColor();

                for (int round = 1; round <= 3; round++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("╔════════════════════════════════════════════╗");
                    Console.Write($"║                 ROUND {round}/3");
                    Console.WriteLine(new string(' ', 18) + "║");
                    Console.WriteLine("╚════════════════════════════════════════════╝");
                    Console.ResetColor();

                    bool roundNotFinished = true;
                    
                    do
                    {
                        SelectWeapon();
                        SetWeaponForBot();
                    
                        ShowChoices();
                        ResolveRound(ref roundNotFinished);
                    } while (roundNotFinished);


                    if (round < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("╔════════════════════════════════════════════╗");
                        Console.WriteLine("║          Press Enter to continue...        ║");
                        Console.WriteLine("╚════════════════════════════════════════════╝");
                        Console.ResetColor();
                        Console.ReadLine();
                    }
                }
                
                ShowFinalResults();

                ResetScore();
                
                ShowPlayerStats();

                StartGame();

            } while (continueGame);
        }

        private static void ResetScore()
        {
            BotScore = 0;
            PlayerScore = 0;
        }
        
        static void ShowFinalResults()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║                BATTLE STATS                ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine($"║ {PlayerName}: {PlayerScore} wins".PadRight(45) + "║");
            Console.WriteLine($"║ Bot:    {BotScore} wins".PadRight(45) + "║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            
            Console.ResetColor();
            
            var randomMessageIndex = new Random();
            
            var messageIndex = randomMessageIndex.Next(1, 4);

            if (PlayerScore > BotScore)
            {
                string message = messageIndex switch
                {
                    1 => "Congratulations! You’ve won the game!",
                    2 => "Victory is yours! Well played.",
                    3 => "You did it! You're the champion!",
                    _ => "You are the winner!"
                };
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine($"       {message}");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.ResetColor();
                
                PlayerWin++;
            }
            else if (BotScore > PlayerScore)
            {
                string message = messageIndex switch
                {
                    1 => "Defeated by the bot!",
                    2 => "Oops, the bot outplayed you!",
                    3 => "The bot takes the win! Try again soon.",
                    _ => "Bot won! Better luck next time."
                };
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine($"     {message}");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.ResetColor();
                
                PlayerLoss++;
                BotWin++;
            }

            countGames++;
        }
        
        static void ResolveRound(ref bool roundNotFinished)
        {
            
            if (PlayerWeapon == BotWeapon)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║                It's a draw!                ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                
                roundNotFinished = true;
            } 
            else if (
                    (PlayerWeapon == 1 && BotWeapon == 3)
                    || (PlayerWeapon == 2 && BotWeapon == 1)
                    || (PlayerWeapon == 3 && BotWeapon == 2)
                )
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║            You win this round!             ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                
                PlayerScore++;
                roundNotFinished = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║           You lost this round              ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                
                BotScore++;
                roundNotFinished = false;
            }

            Console.ResetColor();
        }
        
        private static void ShowChoices()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine($"║ {PlayerName,-10} chose: {weapons[PlayerWeapon - 1],-25}║");
            Console.WriteLine($"║ {"Bot",-10} chose: {weapons[BotWeapon - 1],-25}║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        private static void SetWeaponForBot()
        {
            Random random = new Random();
            
            BotWeapon = random.Next(1, 4);
        }
        
        private static void SelectWeapon()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║             CHOOSE YOUR WEAPON!            ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║ [1] ROCK                                   ║");
            Console.WriteLine("║ [2] PAPER                                  ║");
            Console.WriteLine("║ [3] SCISSORS                               ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║               Your choice:                 ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            
            Console.ResetColor();
            
            int weapon;

            while (true)
            { 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("My weapon is ");
                string input = Console.ReadLine();
                Console.ResetColor();

                if (int.TryParse(input, out weapon) && (weapon >= 1 && weapon <= 3))
                {
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║    Invalid input! Please enter 1, 2 or 3.  ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
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
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║           Your choice (1 or 0):            ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.ResetColor();
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("I start battle: ");
                string input = Console.ReadLine();
                Console.ResetColor();

                if (int.TryParse(input, out isStart) && (isStart == 0 || isStart == 1))
                {
                    break;
                }
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║    Invalid input! Please enter 0 or 1.     ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
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
                Console.WriteLine("║             What is your name?             ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.ResetColor();
            
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Name: ");
                PlayerName = Console.ReadLine();
                Console.ResetColor();
                
                if (PlayerName.Length < 1 || PlayerName.Length > 18 )
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("╔════════════════════════════════════════════╗");
                    Console.WriteLine("║        Please enter a name.                ║");
                    Console.WriteLine("╚════════════════════════════════════════════╝");
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
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Age: ");
            PlayerAge = int.Parse(Console.ReadLine());
            Console.ResetColor();

            if (PlayerAge < 13  || PlayerAge > 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║            Please grow up ^-^              ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.ResetColor();
                
                continueGame = false;
            }
        }

        private static void AskStartGame()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            var message = countGames == 0
                ? "Are you ready to start the battle?"
                : PlayerWin >= BotWin 
                    ? "Do you want to destroy bot again?" 
                    : "Do you want a rematch against the bot?"
            ;
            
            Console.WriteLine($"  {message}");
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║                 GOODBYE!                   ║");
            Console.WriteLine("║             UNTIL NEXT TIME!               ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
    }
}
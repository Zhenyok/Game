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
            ConsoleShowInfo.SayHello();
            
            SetName();
            SetAge();
            
            if (!continueGame)
            {
                ConsoleShowInfo.SayGoodbye();

                return;
            }
            
            ConsoleShowInfo.ShowPlayerStats(PlayerName, PlayerAge, PlayerWin, PlayerLoss);

            StartGame();
                
            do
            {
                if (!continueGame)
                {
                    return;
                }
                
                ConsoleShowInfo.StartBattle();

                for (int round = 1; round <= 3; round++)
                {
                    ConsoleShowInfo.ShowRoundInfo(round);

                    bool roundNotFinished = true;
                    
                    do
                    {
                        SelectWeapon();
                        SetWeaponForBot();
                        
                        ConsoleShowInfo.ShowWeaponChoices(PlayerName, PlayerWeapon, BotWeapon, weapons);
                        
                        ResolveRound(ref roundNotFinished);
                    } while (roundNotFinished);


                    if (round < 3)
                    {
                        ConsoleShowInfo.ShowContinue();
                        
                        Console.ReadLine();
                    }
                }
                
                ShowFinalResults();

                ResetScore();
                
                ConsoleShowInfo.ShowPlayerStats(PlayerName, PlayerAge, PlayerWin, PlayerLoss);

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
            ConsoleShowInfo.BattleStats(PlayerName, PlayerScore, BotScore);
            
            var randomMessageIndex = new Random();
            
            var messageIndex = randomMessageIndex.Next(1, 4);

            if (PlayerScore > BotScore)
            {
                ConsoleShowInfo.YouWinBattle(messageIndex);
                
                PlayerWin++;
            }
            else if (BotScore > PlayerScore)
            {
                ConsoleShowInfo.YouLoseBattle(messageIndex);
                
                PlayerLoss++;
                BotWin++;
            }

            countGames++;
        }
        
        static void ResolveRound(ref bool roundNotFinished)
        {
            
            if (PlayerWeapon == BotWeapon)
            {
                ConsoleShowInfo.DrawRound();
                
                roundNotFinished = true;
            } 
            else if (
                    (PlayerWeapon == 1 && BotWeapon == 3)
                    || (PlayerWeapon == 2 && BotWeapon == 1)
                    || (PlayerWeapon == 3 && BotWeapon == 2)
                )
            {
                ConsoleShowInfo.WinRound();
                
                PlayerScore++;
                roundNotFinished = false;
            }
            else
            {
                ConsoleShowInfo.LostRound();
                
                BotScore++;
                roundNotFinished = false;
            }

            Console.ResetColor();
        }

        private static void SetWeaponForBot()
        {
            Random random = new Random();
            
            BotWeapon = random.Next(1, 4);
        }
        
        private static void SelectWeapon()
        {
            ConsoleShowInfo.WeaponChoice();
            
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

                ConsoleShowInfo.WeaponChoiceError();
            }

            PlayerWeapon = weapon;
        }

        private static void StartGame()
        {
            ConsoleShowInfo.AskStartGame(countGames, PlayerWin, BotWin);
            
            int isStart;
            
            while (true)
            {
                ConsoleShowInfo.StartBattleChoice();
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("I start battle: ");
                string input = Console.ReadLine();
                Console.ResetColor();

                if (int.TryParse(input, out isStart) && (isStart == 0 || isStart == 1))
                {
                    break;
                }

                ConsoleShowInfo.StartBattleChoiceError();
            }

            if (isStart == 0)
            {
                ConsoleShowInfo.SayGoodbye();
                
                continueGame = false;
            }
        }

        private static void SetName()
        {
            var isValidName = false;
            
            while (!isValidName)
            {
                ConsoleShowInfo.AskName();
            
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Name: ");
                PlayerName = Console.ReadLine();
                Console.ResetColor();
                
                if (PlayerName.Length < 1 || PlayerName.Length > 18 )
                {
                    ConsoleShowInfo.EnterNameError();
                    
                    continue;
                }
                
                isValidName = true;
            }

            ConsoleShowInfo.NiceToMeetYou(PlayerName);
        }
        
        private static void SetAge()
        {
            ConsoleShowInfo.AskAge();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Age: ");
            PlayerAge = int.Parse(Console.ReadLine());
            Console.ResetColor();

            if (PlayerAge < 13  || PlayerAge > 100)
            {
                ConsoleShowInfo.EnterAgeError();
                
                continueGame = false;
            }
        }
    }
}
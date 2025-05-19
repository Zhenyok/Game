using System;

namespace Practic1
{
    public class ConsoleShowInfo
    {
        public static void SayHello()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║           WELCOME TO THE GAME!             ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine("║  HI PLAYER. WE'RE GLAD TO SEE YOU HERE!    ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        public static void AskName()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║             What is your name?             ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        
        public static void EnterNameError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║           Please enter a name.             ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        
        public static void NiceToMeetYou(string playerName)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine($"          Nice to meet you, {playerName}!");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        
        public static void AskAge()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║              How old are you?              ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        
        public static void EnterAgeError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║            Please grow up ^-^              ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        
        public static void SayGoodbye()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║                 GOODBYE!                   ║");
            Console.WriteLine("║             UNTIL NEXT TIME!               ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        
        public static void ShowPlayerStats(string playerName, int playerAge, int playerWin, int playerLoss)
        {
            string border = new string('═', 44);
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.WriteLine($"╔{border}╗");
            Console.WriteLine($"║ Name    : {playerName,-33}║");
            Console.WriteLine($"║ Age     : {playerAge,-33}║");
            Console.WriteLine($"║ Win     : {playerWin,-33}║");
            Console.WriteLine($"║ Loss    : {playerLoss,-33}║");
            Console.WriteLine($"╚{border}╝");
            
            Console.ResetColor();
        }
        
        public static void AskStartGame(int countGames, int playerWin, int botWin)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            var message = countGames == 0
                    ? "Are you ready to start the battle?"
                    : playerWin >= botWin 
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
        
        public static void StartBattleChoice()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║           Your choice (1 or 0):            ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        
        public static void StartBattleChoiceError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║    Invalid input! Please enter 0 or 1.     ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        
        public static void StartBattle()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║               Start battle                 ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        public static void ShowRoundInfo(int round)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.Write($"║                 ROUND {round}/3");
            Console.WriteLine(new string(' ', 18) + "║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        
        public static void ShowContinue()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║          Press Enter to continue...        ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        
        public static void WeaponChoice()
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
        }
        
        public static void WeaponChoiceError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║    Invalid input! Please enter 1, 2 or 3.  ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        
        public static void ShowWeaponChoices(string playerName, int playerWeapon, int botWeapon, string[] weapons)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine($"║ {playerName,-10} chose: {weapons[playerWeapon - 1],-25}║");
            Console.WriteLine($"║ {"Bot",-10} chose: {weapons[botWeapon - 1],-25}║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        
        public static void DrawRound()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║                It's a draw!                ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        
        public static void WinRound()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║            You win this round!             ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        
        public static void LostRound()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║           You lost this round              ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        
        public static void BattleStats(string playerName, int playerScore, int botScore)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║                BATTLE STATS                ║");
            Console.WriteLine("╠════════════════════════════════════════════╣");
            Console.WriteLine($"║ {playerName}: {playerScore} wins".PadRight(45) + "║");
            Console.WriteLine($"║ Bot:    {botScore} wins".PadRight(45) + "║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        
        public static void YouWinBattle(int messageIndex)
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
        }
        
        public static void YouLoseBattle(int messageIndex)
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
        }
    }
}
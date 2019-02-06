using System;
using System.Collections.Generic;
using System.Text;

namespace PigDice
{
    class Game
    {
        Random rnd = new Random();

        int GamesPlayed = 0;
        int GamesPlayed2 = 1;
        int GamesLast = 0;
        int Rolls2 = 0;

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write(" ");
            Console.SetCursorPosition(0, currentLineCursor);
        }

        int RollDice()
        {
            return rnd.Next(6) + 1;
        }

        (int, int) RunPigDiceGame()
        {
            var Total = 0;
            var Rolls = 0;
            int Die;


            //Console.WriteLine("Rolling...");
            if(GamesPlayed < GamesPlayed2)
            {
                
                do
                {

                    Rolls++;
                    Rolls2++;
                    Die = RollDice();
                    if (Die != 1)
                    {
                        Total = Total + Die;
                    }
                } while (Die != 1);


                GamesPlayed++;
                GamesPlayed2++;

                ClearCurrentConsoleLine();
                Console.Write($" Current Game: {GamesPlayed} |");
            }
            return (Total, Rolls);

        }

        public void Run()
        {
            var BestTotal = 0;
            var BestRolls = 0;
            var counter = 0;
            var GamesToPlay = 10000000000;
            while (counter++ < GamesToPlay)
            {
                var (Total, Rolls) = RunPigDiceGame();
                if (Total > BestTotal)
                {
                    BestTotal = Total;
                    BestRolls = Rolls;
                    GamesLast = GamesPlayed - GamesLast;
                    Console.WriteLine($"Score: {BestTotal} in {BestRolls} rolls."
                        +$" | Games played since last win {GamesLast}, Total Rolls: {Rolls2}");
                }

            }

        }


    }
}

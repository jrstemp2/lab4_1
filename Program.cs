using System;

namespace lab4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            char c;
            bool goAgain = true;
            int counter = 0;
            bool result = false;
            int sides = 0;

            do
            {
                counter++;//this is counting the times the user rolls. 
                
                Console.WriteLine("Roll " + counter);

                while (result == false)
                {
                    Console.Write("Please select the number of sides for your Dice: ");
                    result = int.TryParse(Console.ReadLine(), out sides);

                    if (result == false)
                    {
                        Console.WriteLine("That is not a number.");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                
                int diceOne = RollDice(sides);
                int diceTwo = RollDice(sides);
                int total = (diceOne + diceTwo);
                Console.WriteLine($"Dice One: {diceOne}");
                Console.WriteLine($"Dice Two: {diceTwo}");
                Console.WriteLine($"The total or your roll is {total}");

                if (sides == 6)
                {
                    Console.WriteLine(DiceCombo(diceOne, diceTwo));
                }
                do
                {
                    Console.WriteLine("Would you like to roll again? (y/n)");
                    c = Console.ReadKey().KeyChar;
                    if (c == 'n')
                    {
                        goAgain = false;
                        break;
                    }
                    Console.WriteLine();
                } while (c != 'y');
            } while (goAgain == true );
            Console.WriteLine();
            Console.WriteLine("Thank you for playing.");
        } 

        static int RollDice (int diceSides)
        {
            //method to generate random numbers. 
            Random compChoice = new Random();
            int diceRoll = compChoice.Next(1, diceSides + 1);
            return diceRoll;  
        }

        static string DiceCombo (int d1, int d2)
        {
            int sum = d1 + d2;
            if (d1 == 1 && d2 == 1)
            {
                return "Snake Eyes";
            }
            else if ((d1 == 1 && d2 == 2) || (d1 == 2 && d2 == 1))
            {
                return "Ace Deuce";
            }
            else if (d1 == 6 && d2 == 6)
            {
                return "Box Cars";
            }
            
            if (sum == 7 || sum == 11)
            {
                return "You're a Winner";
            }
            if (sum == 2 || sum == 3 || sum == 12)
            {
                return "Craps";
            }
            else
            {
                return "Better Luck Next Time";
            }
        }

    


    }
}

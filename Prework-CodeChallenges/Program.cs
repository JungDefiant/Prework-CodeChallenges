using System;
using System.Linq;

namespace Prework_CodeChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ArrayMaxResult();
        }

        // Challenge 1
        static int ArrayMaxResult()
        {
            // Given an array select a number that exists, and output the computated "score". The method you create should take in both an array of integers 
            // and the integer the user selected.

            // Create a Console application that requests 5 numbers between 1 - 10 from the user. Output the array to the console and ask the user to select a number. 
            // After the selection, output the "score" of the number chosen.

            // You can select any number from the list, however your scoring will be depend on the frequency of that number in the list. E.g for [2,2,3,5,4] if you 
            // pick 2 your score will be 4 (2 * 2) but if you pick 5 your score will be 5 (5 * 1)

            Console.WriteLine("Enter five numbers between 1 - 10.");

            int[] scores = new int[5] { 1, 1, 1, 1, 1 };
            int numInput = 0;

            for(int i = 0; i < scores.Length; i++)
            {
                while(numInput < 1 || numInput > 10)
                {
                    numInput = Convert.ToInt32(Console.ReadLine());
                    if (numInput < 1 || numInput > 10) Console.WriteLine("Invalid Entry. Input a number from 1 to 10");
                    else scores[i] = numInput;
                }

                numInput = 0;
            }

            Console.WriteLine("Select a number from the list.");

            numInput = 0;
            while(!scores.Contains(numInput))
            {
                numInput = Convert.ToInt32(Console.ReadLine());
                if (!scores.Contains(numInput)) Console.WriteLine("Number is not in the list.");
            }

            int counter = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] == numInput) counter++;
            }

            int finalScore = counter * numInput;

            Console.WriteLine("Your score is " + finalScore);

            return 0;
        }
    }
}

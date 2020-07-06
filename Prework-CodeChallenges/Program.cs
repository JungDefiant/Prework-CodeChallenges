using System;
using System.Linq;
using System.Security.Cryptography;

namespace Prework_CodeChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ArrayMaxResult();

            LeapYearCalculator(1996);
            LeapYearCalculator(2000);
            LeapYearCalculator(2004);
            LeapYearCalculator(1997);
            LeapYearCalculator(2001);
            LeapYearCalculator(2005);
            LeapYearCalculator(1000);
            LeapYearCalculator(4000);

            if(PerfectSequence(new int[2] { 2, 2 })) Console.WriteLine("This array is a perfect sequence!\n");
            else Console.WriteLine("This array is NOT a perfect sequence!\n");

            if(PerfectSequence(new int[3] { 1, 3, 2 })) Console.WriteLine("This array is a perfect sequence!\n");
            else Console.WriteLine("This array is NOT a perfect sequence!\n");

            if(PerfectSequence(new int[3] { 4, 5, 6 })) Console.WriteLine("This array is a perfect sequence!\n");
            else Console.WriteLine("This array is NOT a perfect sequence!\n");

            if(PerfectSequence(new int[3] { 0, 2, -2 })) Console.WriteLine("This array is a perfect sequence!\n");
            else Console.WriteLine("This array is NOT a perfect sequence!\n");

            int[] sumOfRows = SumOfRows();
            Console.WriteLine("\n\nSum Of Rows");
            for (int i = 0; i < sumOfRows.Length; i++) {
                Console.WriteLine(sumOfRows[i]);
            }

            sumOfRows = SumOfRows();
            Console.WriteLine("\n\nSum Of Rows");
            for (int i = 0; i < sumOfRows.Length; i++)
            {
                Console.WriteLine(sumOfRows[i]);
            }

            sumOfRows = SumOfRows();
            Console.WriteLine("\n\nSum Of Rows");
            for (int i = 0; i < sumOfRows.Length; i++)
            {
                Console.WriteLine(sumOfRows[i]);
            }

        }

        // Challenge 1
        static void ArrayMaxResult()
        {
            /* PROBLEM STATEMENT            
            Given an array select a number that exists, and output the computated "score". The method you create should take in both an array of integers 
            and the integer the user selected.

            Create a Console application that requests 5 numbers between 1 - 10 from the user. Output the array to the console and ask the user to select a number. 
            After the selection, output the "score" of the number chosen.

            You can select any number from the list, however your scoring will be depend on the frequency of that number in the list. E.g for [2,2,3,5,4] if you 
            pick 2 your score will be 4 (2 * 2) but if you pick 5 your score will be 5 (5 * 1). */

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

            Console.WriteLine("Your score is " + finalScore + "\n");
        }

        // Challenge 2
        static void LeapYearCalculator(int year)
        {
            /* PROBLEM STATEMENT
            Given a year, report if it is a leap year. The tricky thing here is that a leap year in the Gregorian calendar occurs:

                on every year that is evenly divisible by 4
                except every year that is evenly divisible by 100
                unless the year is also evenly divisible by 400

            For example, 1997 is not a leap year, but 1996 is. 1900 is not a leap year, but 2000 is.

            Want to know more about Leap Year? Watch this 4 minute video HERE{:target = "_blank"}

            Note: This is not a trick problem. Edge cases do not need to be taken into consideration when creating a solution.*/

            //Console.WriteLine("Enter a year.");
            //int year = Convert.ToInt32(Console.ReadLine());

            if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0)) Console.WriteLine(year + " is a leap year!");
            else Console.WriteLine(year + " is not a leap year... ;(");
        }

        // Challenge 3
        static bool PerfectSequence(int[] array)
        {
            /* PROBLEM STATEMENT
            Given an array, return "Yes" if the sequence is considered a perfect sequence. Otherwise, return "No".

            PERFECT SEQUENCE
            A perfect sequence is a sequence such that all of its elements are non-negative integers and the product 
            of all of them is equal to their sum. For example: [2,2], [1,3,2] and [0,0,0,0] are perfect sequences and 
            [4,5,6] and [0,2,-2] are not perfect sequences. Negative numbers of any kind are not valid in a perfect sequence */

            int product = 1;
            int sum = 0;

            Console.WriteLine("Checking if array is a perfect sequence...");

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    return false;
                }

                product *= array[i];
                sum += array[i];
                Console.WriteLine(array[i]);
            }

            if (product == sum)
            {
                
                return true;
            }

            Console.WriteLine("This array is not a perfect sequence!\n");
            return false;

        }

        // Challenge 4
        static int[] SumOfRows()
        {
            /* PROBLEM STATEMENT
            Given a matrix of integers. Return the sum of each row in a single dimensional array.

            INPUT FORMAT
            a multidimensional array with the dimensions of m x n (m = rows, n = columns).

            1. duplicate integers are possible.
            2. Negative numbers are possible
            3. both m and n can vary in length

            The user should specify the length and the width of the array within the console. To populate the numbers, you may randomly generate them, or have the user input one by one.
            The method should take in the multidimensional array and return the single dimensional array with the sum */

            int length = 0, width = 0;

            Console.WriteLine("\n\nSpecify the length of the array.");
            while (length < 1)
            {
                length = Convert.ToInt32(Console.ReadLine());
                if (length < 1) Console.WriteLine("Invalid length entered.");
            }

            Console.WriteLine("Specify the width of the array.");
            while (width < 1)
            {
                width = Convert.ToInt32(Console.ReadLine());
                if (width < 1) Console.WriteLine("Invalid width entered.");
            }

            int[,] matrix = new int[length, width];
            int[] sum = new int[length];

            Console.WriteLine("Matrix is being randomized.");
            Random rand = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine("\nRow " + i);

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rand.Next(-100, 100);
                    sum[i] += matrix[i, j];

                    Console.WriteLine(matrix[i, j]);
                }
            }

            return sum;
        }
    }
}

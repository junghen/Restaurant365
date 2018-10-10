using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = { "", "1", "1,2", "10,25", "999,1", "10000000000,1000000000", "1,2,3" };

            StringCalculator sc = new StringCalculator();

            for (int i = 0; i < input.Length; i++) {
                Console.WriteLine(string.Format("Sum of {0}:", input[i]));
                Console.WriteLine(string.Format("{0}", sc.Add(input[i]).ToString()));
            }
            Console.Read();
        }
    }

    public class StringCalculator
    {
        /// <summary>
        /// Parse a string and add all the numbers inside that string. Assumptions: The method can take 0, 1 or 2 numbers seperated by comma, and will return their sum (for an empty string it will return 0) for example “” or “1” or “1,2”
        /// </summary>
        /// <param name="numbers">Type: <see cref="System.String"/><para>Set of numbers separated by comma</para></param>
        /// <returns>Type: <see cref="System.Int32"/><para>The sum of numbers</para></returns>
        public int Add(string numbers)
        {
            // if empty or null return 0
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            string[] numArray = numbers.Split(',');
            int sumOfNumbers = 0;
            // if numbers is more than 2 return -1.
            if(numArray.Length > 2)
            {
                Console.WriteLine("Too many numbers passed. Limit is 2");
                return -1;
            }
            for(int i=0; i< numArray.Length; i++)
            {
                try { 
                    sumOfNumbers += Convert.ToInt32(numArray[i]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
            }
            return sumOfNumbers;
        }
    }
}

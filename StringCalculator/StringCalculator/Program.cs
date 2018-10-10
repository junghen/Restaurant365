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
            string[] input = { "1,-2,-3", "", "1", "1,2", "10,25", "999,1", "10000000000,1000000000", "1,2,3", "1\n2,3\n4", "//;\n1;2\n3\n4;5;6" };

            StringCalculator sc = new StringCalculator();

            for (int i = 0; i < input.Length; i++) {
                Console.WriteLine(string.Format("Sum of {0}:", input[i].Replace("\n", ",")));
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
            // JK 10/9 code exercise 3 - Allow the Add method to handle new lines between numbers (instead of commas).
            // Find a better way to do it by using StringReader
            try
            {
                string[] numArray = new string[0];// List<string[]> listNumbers = new List<string[]>();
                using (System.IO.StringReader reader = new System.IO.StringReader(numbers))
                {
                    string line;
                    bool firstLine = true;
                    string delimiter = ",";
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (firstLine)
                        {
                            if (line.Contains("//")) //if first line contains "//" then use delimiter set in string
                            {
                                // Assumption: delimiter is only 1 character
                                delimiter = line.Substring(line.IndexOf("//") + 2, 1);
                                firstLine = false;
                                continue;
                            }
                            else
                            {
                                numArray = numArray.Concat(line.Split(new[] { delimiter }, StringSplitOptions.None)).ToArray();
                                firstLine = false;
                            }
                        }
                        else
                        {
                            numArray = numArray.Concat(line.Split(new[] { delimiter }, StringSplitOptions.None)).ToArray();
                        }
                    }
                }
                int sumOfNumbers = 0;
                List<int> listNegativeNumbers = new List<int>();
                for (int i = 0; i < numArray.Length; i++)
                {
                    string number = numArray[i];
                    int numToAdd;
                    if (string.IsNullOrEmpty(number))
                    {
                        numToAdd = 0;
                    }
                    else
                    {
                        numToAdd = Convert.ToInt32(numArray[i]);
                        // code exercise 5 - Calling Add with a negative number will throw an exception “negatives not allowed” - and the negative that was passed. If there are multiple negatives, show all of them in the exception message
                        if (numToAdd < 0)
                        {
                            listNegativeNumbers.Add(numToAdd);
                        }
                    }
                    sumOfNumbers += numToAdd;
                }

                if (listNegativeNumbers.Count > 0)
                {
                    string strNegativeNumbers = "";
                    foreach (var negativeNumber in listNegativeNumbers)
                    {
                        strNegativeNumbers += "[" + negativeNumber.ToString() + "]";
                    }
                    throw new Exception(string.Format("negatives not allowed {0}", strNegativeNumbers));
                }
                return sumOfNumbers;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            
        }
    }
}

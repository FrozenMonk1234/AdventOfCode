using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class DayOne
    {
        
        public int PartOne(string input)
        {
            int[] numbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
            string[] inputList = input.Split(Environment.NewLine);
            int[] calibrationValues = new int[inputList.Length];
            for (int i = 0; i < inputList.Length; i++)
            {
                var calibratedValue = "";
                var reversedTemp = inputList[i].Reverse().ToList();
                var temp = inputList[i].ToList();
                //Checks the string from left right to find the first occurance of a number
                for (int j = 0; j < temp.Count; j++)
                {
                    if (calibratedValue.Length == 1)
                    {
                        break;
                    }

                    for (int k = 0; k < numbers.Length; k++)
                    {
                        if (temp[j].ToString().Equals(numbers[k].ToString()))
                        {
                            calibratedValue += numbers[k];
                            break;
                        }
                    }
                }
                //Checks the reversed string from left right to find the first occurance of a number
                for (int j = 0; j < reversedTemp.Count; j++)
                {
                    if (calibratedValue.Length == 2)
                    {
                        break;
                    }

                    for (int k = 0; k < numbers.Length; k++)
                    {
                        if (reversedTemp[j].ToString().Equals(numbers[k].ToString()))
                        {
                            calibratedValue += numbers[k];
                            break;
                        }
                    }
                }

                Int32.TryParse(calibratedValue, out int value);
                calibrationValues[i] = value;
            }

            return calibrationValues.Sum();
        }
    }
}

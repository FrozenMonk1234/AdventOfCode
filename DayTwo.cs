using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class DayTwo
    {

        public int Execute(string input)
        {
            string[] colors = ["red", "green", "blue"];
            List<string> inputList = input.Split(Environment.NewLine).ToList();
            List<string> outputList = inputList;

            for (int i = 0; i < inputList.Count; i++)
            {
                var game = inputList[i].Substring(0, 7);
                var set = inputList[i].Substring(7);

                var charArray = set.ToCharArray();
                bool redFlag = false;
                Dictionary<string, int> invalidGame = new();
                //Checks if array is at the correct word to check prefixed number. If prefix number meets invalid criteria 
                //then the flag is raised which by then end of the statment if flag is raised it removed the item at that index
                for (int j = 0; j < charArray.Length; j++)
                {
                    if (charArray[j] == 'r' && charArray[j + 1] == 'e' && charArray[j + 2] == 'd')
                    {
                        var Number = string.Empty;
                        for (int k = j - 3; k <= j - 1; k++)
                        {
                            Number += charArray[k];
                        }

                        Int32.TryParse(Number.Trim(), out var value);
                        if (value > 12)
                        {
                            redFlag = true;
                            break;
                        }
                    }

                    if (charArray[j] == 'g' && charArray[j + 1] == 'r' && charArray[j + 2] == 'e')
                    {
                        var Number = string.Empty;
                        for (int k = j - 3; k <= j - 1; k++)
                        {
                            Number += charArray[k];
                        }

                        Int32.TryParse(Number.Trim(), out var value);
                        if (value > 13)
                        {
                            redFlag = true;
                            break;
                        }
                    }

                    if (charArray[j] == 'b' && charArray[j + 1] == 'l' && charArray[j + 2] == 'u')
                    {
                        var Number = string.Empty;
                        for(int k = j - 3; k <= j -1; k++)
                        {
                            Number += charArray[k];
                        }

                        Int32.TryParse(Number.Trim(), out var value);
                        if (value > 13)
                        {
                            redFlag = true;
                            break;
                        }
                    }
                }

                if (redFlag)
                {
                    outputList.RemoveAt(i);
                }
            }

            int result = 0;
            for(int i = 0; i < outputList.Count; i++)
            {
                var tempList = outputList[i].Split(':');

                if (int.TryParse(tempList[0].Replace("Game",""), out int value))
                {
                    result += value;
                }
            }

            return result;
        }
    }
}

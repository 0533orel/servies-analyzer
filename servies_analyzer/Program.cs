using System.Collections.Generic;


namespace servies_analyser
{
    class program()
    {
        static void Main(string[] args)
        {


            //  1
            List<double> getNumbers()
            {
                string userInput = inputUser();
                List<double> numsList = getlist(userInput);
                return numsList;
            }
            
            

            
            string inputUser()
            {
                string userInput;
                while (true)
                {
                    Console.WriteLine("enter a series of numbers with a comma between each number.");
                    userInput = Console.ReadLine();
                    if (isNull(userInput))
                    {
                        Console.WriteLine("invalid input. blease try again.");
                    }
                    else
                    {
                        break;
                    }

                } 
                return userInput;
            }

            
            bool isNull(string strInput)
            {
                if (string.IsNullOrEmpty(strInput))
                {
                    return true;
                }
                else
                    return false;
            }
            

            List<double> getlist(string strInput)
            {
                string[] strArray = strInput.Split(",");

                List<double> numsList = new List<double>();

                for (int i = 0; i < strArray.Length; i++)
                {
                    numsList.Add(double.Parse(strArray[i]));
                }
                return numsList;
            }




            void printInOrder(List<double> dblList)
            {
                foreach (var x in dblList)
                {
                    Console.Write($"{x} ");
                }
                Console.WriteLine();
            }





            void printRevers(List<double> dblList)
            {
                for (int i = dblList.Count - 1; i >= 0; i--)
                {
                    Console.Write($"{dblList[i]} ");
                }
                Console.WriteLine();
            }




            double maxNumber(List<Double> list)
            {
                double maxNum = 0;
                foreach (var number in list)
                {
                    if (number > maxNum)
                    {
                        maxNum = number;
                    }
                }
                return maxNum;
            }


         



            double minNumber(List<Double> list)
            {
                double minNum = list[0];
                foreach (var number in list)
                {
                    if (number < minNum)
                    {
                        minNum = number;
                    }
                }
                return minNum;
            }




            double sumList(List<Double> list)
            {
                double sumNumbers = 0;
                foreach (var number in list)
                {
                    sumNumbers += number;
                }
                return sumNumbers;
            }




        }
    }
}
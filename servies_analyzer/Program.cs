using System.Collections.Generic;

namespace servies_analyser
{
    class program()
    {
        static void Main(string[] args)
        {



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
                    Console.WriteLine("Enter a series of at least 3 numbers with a comma between each number.");
                    userInput = Console.ReadLine();

                    if (string.IsNullOrEmpty(userInput) || isLetter(userInput))
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                    }
                    else
                    {
                        if (isShort(userInput))
                        {
                            Console.WriteLine("You entered less than three numbers, please try again.");
                        }
                        else
                        {
                            break;
                        }

                    }
                }
                return userInput;
            }



            bool isShort(string strInput)
            {
                int countComma = 0;
                foreach (char item in strInput)
                {
                    if (item == ',')
                    {
                        countComma++;
                    }
                    if (countComma == 2)
                    {
                        return false;
                    }
                }
                return true;
                
            }



            bool isLetter(string strInput)
            {
                foreach (char item in strInput)
                {
                    if (char.IsLetter(item))
                    {
                        return true;
                    }
                }
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



            int lengthList(List<Double> list)
            {
                int len = 0;
                foreach (var number in list)
                {
                    len++;
                }
                return len;
            }




            double avarageList(List<Double> list)
            {
                return sumList(list) / lengthList(list);
            }





            List<double> bobbleSort(List<Double> list)
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    bool sorted = true;
                    for (int j = 0; j < list.Count - 1 - i; j++)
                    {
                        if (list[j] > list[j + 1])
                        {
                            double temp = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = temp;
                            sorted = false;
                        }
                    }
                    if (sorted)
                        break;
                }
                return list;
            }




            Console.Write("Welcom to the program! \nplease ");
            List<double> listOfNumabers = getNumbers();

            bool again = true;
            do
            {
                Console.WriteLine("chose from the menu below: \n" +
                    "a.\tInput a Series. (Replace the current series) \n" +
                    "b.\tDisplay the series in the order it was entered. \n" +
                    "c.\tDisplay the series in the reversed order it was entered. \n" +
                    "d.\tDisplay the series in sorted order (from low to high). \n" +
                    "e.\tDisplay the Max value of the series. \n" +
                    "f.\tDisplay the Min value of the series. \n" +
                    "g.\tDisplay the Average of the series. \n" +
                    "h.\tDisplay the Number of elements in the series. \n" +
                    "i.\tDisplay the Sum of the series. \n" +
                    "j.\tExit.");
                string userChoose = Console.ReadLine().ToLower();

                switch (userChoose)
                {
                    case "a":
                        listOfNumabers = getNumbers();
                        Console.WriteLine("done!");
                        break;
                    case "b":
                        printInOrder(listOfNumabers);
                        break;
                    case "c":
                        printRevers(listOfNumabers);
                        break;
                    case "d":
                        printInOrder(bobbleSort(listOfNumabers));
                        break;
                    case "e":
                        Console.WriteLine($"the Max value is: {maxNumber(listOfNumabers)}");
                        break;
                    case "f":
                        Console.WriteLine($"the Min value is: {minNumber(listOfNumabers)}");
                        break;
                    case "g":
                        Console.WriteLine($"the Average of the series is: {avarageList(listOfNumabers)}");
                        break;
                    case "h":
                        if (listOfNumabers.Count == 1)
                            Console.WriteLine($"There is {lengthList(listOfNumabers)} number in the series.");
                        else
                            Console.WriteLine($"There are {lengthList(listOfNumabers)} numbers in the series.");
                        break;
                    case "i":
                        Console.WriteLine($"the Sum of the series is: {sumList(listOfNumabers)}");
                        break;
                    case "j":
                        Console.WriteLine("thank you and godbay.");
                        again = false;
                        break;
                    default:
                        Console.WriteLine("invalid input. please try again.");
                        break;

                }

            } while (again);







        }
    }
}



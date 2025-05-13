using System.Collections.Generic;

namespace servies_analyser
{
    class Program()
    {

        static void Main(string[] args)
        {
            menu();
        }



        static List<double> getNumbers()
        {
            string userInput = inputUser();
            List<double> numsList = getlist(userInput);
            return numsList;
        }



        static string inputUser()
        {
            string userInput;
            while (true)
            {
                Console.WriteLine("Enter a series of at least 3 numbers with a comma between each number.");
                userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput) || isNotNum(userInput))
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
                        if (endWithNum(userInput))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                        }
                    }

                }
            }
            return userInput;
        }


        static bool endWithNum(string strInput)
        {
            int lastCahr = strInput.Length - 1;
            string numbers = "1234567890";

            foreach (char number in numbers)
            {
                if (strInput[lastCahr] == number)
                {
                    return true;
                }
            }
            return false;
        }




        static bool isShort(string strInput)
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



        static bool isNotNum(string strInput)
        {
            string specialCharacter = "!@#$%^&*()_-+=<>?/:;'\\\"";

            for (int i = 0; i < strInput.Length - 1; i++)
            {
                if (char.IsLetter(strInput[i]) ||
                    specialCharacter.Contains(strInput[i]) ||
                    strInput[i] == ',' && strInput[i + 1] == ',' ||
                    strInput[i] == '.' && strInput[i + 1] == '.')
                {
                    return true;
                }
            }
            return false;            
        }



        static bool isValidNumber(string[] strArray)
        {
            int countPoint;

            foreach (var value in strArray)
            {
                countPoint = 0;
                if (value.Length > 1)
                {
                    foreach (var item in value)
                    {
                        if (item == '.')
                        {
                            countPoint++;
                        }
                    }
                    if (countPoint > 1)
                    {
                        return false;
                    }
                }
            }
            return true;           
        }



        static List<double> getlist(string strInput)
        {
            List<double> numsList = new List<double>();

            string[] strArray = strInput.Split(",");

            if (isValidNumber(strArray))
            {
                for (int i = 0; i < strArray.Length; i++)
                {

                    numsList.Add(double.Parse(strArray[i]));
                }   
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                inputUser();
            }
            return numsList;
        }




        static void printInOrder(List<double> dblList)
        {
            foreach (var x in dblList)
            {
                Console.Write($"{x} ");
            }
            Console.WriteLine();
        }





        static void printRevers(List<double> dblList)
        {
            for (int i = dblList.Count - 1; i >= 0; i--)
            {
                Console.Write($"{dblList[i]} ");
            }
            Console.WriteLine();
        }




        static double maxNumber(List<Double> list)
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






        static double minNumber(List<Double> list)
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




        static double sumList(List<Double> list)
        {
            double sumNumbers = 0;
            foreach (var number in list)
            {
                sumNumbers += number;
            }
            return sumNumbers;
        }



        static int lengthList(List<Double> list)
        {
            int len = 0;
            foreach (var number in list)
            {
                len++;
            }
            return len;
        }




        static double avarageList(List<Double> list)
        {
            return sumList(list) / lengthList(list);
        }





        static List<double> bobbleSort(List<Double> list)
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



        static void menu()
        {
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




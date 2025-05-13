using System.Collections.Generic;

namespace servies_analyser
{
    class Program()
    {

        static void Main(string[] args)
        {
            menu();
        }


        /// <summary>
        /// A function accepts numbers as a string and returns them as a list.
        /// </summary>
        /// <returns></returns>
        static List<double> getNumbers()
        {
            List<double> numsList;
            bool emptyList = true;

            do // Will run as long as the list is empty.
            {
                string userInput = inputUser();
                numsList = getlist(userInput);
                if (numsList.Count > 0)
                {
                    emptyList = false;
                }
            } while (emptyList);
            
            return numsList;
        }


        /// <summary>
        /// A function that receives input from the user, checks that the numbers have been entered and the length is correct, and returns them as a string.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// A Boolean function that accepts a string and checks that it ends with a number and not with ',' or '.'
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
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



        /// <summary>
        /// A Boolean function that accepts a string with a series of numbers and checks if there are fewer than 3 numbers in the series.
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
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


        /// <summary>
        /// A Boolean function that accepts a string and checks if it contains a letter or special character or '.' or ',' in sequence.
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        static bool isNotNum(string strInput)
        {
            string specialCharacter = "!@#$%^&*()_-+=<>?/:;'\\\"";

            for (int i = 0; i < strInput.Length - 1; i++)
            {
                if (char.IsLetter(strInput[i]) ||
                    specialCharacter.Contains(strInput[i]) ||
                    strInput[i] == ',' && strInput[i + 1] == ',' ||
                    strInput[i] == '.' && strInput[i + 1] == '.' ||
                    strInput[i] == '.' && strInput[i + 1] == ',' ||
                    strInput[i] == ',' && strInput[i + 1] == '.')
                {
                    return true;
                }
            }
            return false;            
        }


        /// <summary>
        /// A boolean function that accepts an array of numbers in a string and verifies that the number is valid.
        /// </summary>
        /// <param name="strArray"></param>
        /// <returns></returns>
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



        /// <summary>
        /// A function that accepts a string with numbers. Converts it to an array and then to a list of type double if the numbers are valid and returns the list.
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
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
                Console.WriteLine("Invalid number.");
            }
            return numsList;
        }




        static void printInOrder(List<double> List)
        {
            foreach (var number in List)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }





        static void printRevers(List<double> List)
        {
            for (int i = List.Count - 1; i >= 0; i--)
            {
                Console.Write($"{List[i]} ");
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




        static double averageList(List<Double> list)
        {
            return sumList(list) / lengthList(list);
        }





        static List<double> bubbleSort(List<Double> list)
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
            Console.WriteLine("Welcome to the program!");
            List<double> listOfNumabers = getNumbers();

            bool again = true;
            do
            {
                Console.WriteLine("Choose from the menu below: \n" +
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
                        Console.WriteLine("Done!");
                        break;
                    case "b":
                        printInOrder(listOfNumabers);
                        break;
                    case "c":
                        printRevers(listOfNumabers);
                        break;
                    case "d":
                        printInOrder(bubbleSort(listOfNumabers));
                        break;
                    case "e":
                        Console.WriteLine($"The max value is: {maxNumber(listOfNumabers)}");
                        break;
                    case "f":
                        Console.WriteLine($"The min value is: {minNumber(listOfNumabers)}");
                        break;
                    case "g":
                        Console.WriteLine($"The average of the series is: {averageList(listOfNumabers)}");
                        break;
                    case "h":
                        Console.WriteLine($"There are {lengthList(listOfNumabers)} numbers in the series.");
                        break;
                    case "i":
                        Console.WriteLine($"The sum of the series is: {sumList(listOfNumabers)}");
                        break;
                    case "j":
                        Console.WriteLine("Thank you and goodbye.");
                        again = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. please try again.");
                        break;

                }

            } while (again);
        }
    }
}




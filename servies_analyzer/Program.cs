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
                    Console.WriteLine("Enter a series of numbers with a comma between each number.");
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
            }





            void printRevers(List<double> dblList)
            {
                for (int i = dblList.Count - 1; i >= 0; i--)
                {
                    Console.Write($"{dblList[i]} ");
                }
            }

        }
    }
}
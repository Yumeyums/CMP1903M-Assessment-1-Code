using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CMP1903M_Assessment_1_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            //Local list of integers to hold the first five measurements of the text
            List<int> parameters = new List<int>();
            //Create 'Input' object
            //Get either manually entered text, or text from a file
            
            Input input = new Input();
            string userInput = GetUserInput(input);

            //Create an 'Analyse' object
            Analyse analyse = new Analyse();

            //Pass the text input to the 'analyseText' method
            Report analysisReport = new Report();
            analysisReport.Output(analyse.analyseText(userInput)); //Passes to the Report class, outputs the results of analysis.
            analysisReport.Output(analyse.LetterFrequency(userInput)); //Passes to the Report class, outputs the letter frequency.


            //TO ADD: Get the frequency of individual letters?
        }

        public static string GetUserInput(Input input) //Gets user input, checks whether they want to use a manual sentence or read from a text file.
        {
            string filePath = "testfiles\\TestFile1.txt"; //File path for the test file, can be modified, directory is located in bin\Debug\netcoreapp3.1\testfiles

            int userInput;
            while (true)
            {
                try
                {
                    Console.WriteLine("1. Do you want to enter text via the keyboard?\n" +
                                      "2. Do you want to read in the text from a file?");
                    Console.Write("Please enter '1' or '2': ");
                    userInput = int.Parse(Console.ReadLine());
                    if (userInput >= 3 || userInput <= 0)
                    {
                        Console.WriteLine("Please enter 1 or 2.");
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid number."); //If user does not enter a number and instead a letter, the loop continues instead of throwing an error.
                    continue;
                }
            }
            if (userInput == 1)
            {
                return input.manualTextInput();
            }
            else
            {
                return input.fileTextInput(filePath);
            }
            
        }

    }
}

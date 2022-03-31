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
            Analyse analysis = new Analyse();

            //Pass the text input to the 'analyseText' method
            Report analysisReport = new Report();
            analysisReport.Output(analysis.analyseText(userInput), analysis.LetterFrequency(userInput)); //Passes to the Report class, outputs the results of analysis, including Letter Frequency.
            analysisReport.SaveLongWords(analysis.longWords, useManualInput);
            //TO ADD: Get the frequency of individual letters?
        }

        public static bool useManualInput { get; set; }

        private static string GetUserInput(Input input) //Gets user input, checks whether they want to use a manual sentence or read from a text file.
        {
            string filePath = "testfiles\\TestFile1.txt"; //File path for the test file, can be modified, directory is located in bin\Debug\netcoreapp3.1\testfiles

            int userChoice;
            while (true)
            {
                try
                {
                    Console.WriteLine("1. Do you want to enter text via the keyboard?\n" +
                                      "2. Do you want to read in the text from a file?");
                    Console.Write("Please enter '1' or '2': ");
                    userChoice = int.Parse(Console.ReadLine());
                    if (userChoice >= 3 || userChoice <= 0) //Changed name from userInput to userChoice to make it less confusing.
                    {
                        Console.WriteLine("Please enter 1 or 2.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid number."); //If user does not enter a number and instead a letter, the loop continues instead of throwing an error.
                    continue;
                }

                //Breaks out of the loop by returning a userInput value.
                if (userChoice == 1)
                {
                    useManualInput = true;
                    return input.manualTextInput();
                }
                else
                {
                    useManualInput = false;
                    //Error handling if File path does not exist
                    try
                    {
                        return input.fileTextInput(filePath); 
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid file path, please try a manual sentence."); //If the file path does not exist, continues the loop.
                        continue;
                    }

                }
            }
            
            
        }

    }
}

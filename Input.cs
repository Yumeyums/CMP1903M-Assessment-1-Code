using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CMP1903M_Assessment_1_Code
{
    class Input
    {
        //Handles the text input for Assessment 1
        string text = "nothing";

        //Method: manualTextInput
        //Arguments: none
        //Returns: string
        //Gets text input from the keyboard

        public string manualTextInput()
        {
            while (true)
            {
                text = Console.ReadLine();
                if (text == null || text.Length <= 0) //If the user doesn't input anything, the text input loops.
                {
                    Console.WriteLine("Please enter a valid sentence.");
                }
                break;
            }
            return text;
        }

        //Method: fileTextInput
        //Arguments: string (the file path)
        //Returns: string
        //Gets text input from a .txt file
        public string fileTextInput(string fileName) 
        {
            text = File.ReadAllText(fileName);
            return text;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CMP1903M_Assessment_1_Code
{
    class Report
    {
        //Handles the reporting of the analysis
        
        public void Output(List<int> values) //Outputs sentence analyses.
        {
            string[] keywords = { "sentences", "vowels", "consonants", "upper case letters", "lower case letters" };
            for (int i = 0; i < keywords.Length; i++)
            {
                Console.WriteLine($"Number of {keywords[i]}: {values[i]}");
            }
        }

        public void Output(Dictionary<char, int> LetterFrequency) //Outputs letter frequency.
        {
            foreach (var frequentLetter in LetterFrequency)
            {
                Console.WriteLine($"\nLetter {frequentLetter.Key}: {frequentLetter.Value} times.");
            }
        }
    }
}

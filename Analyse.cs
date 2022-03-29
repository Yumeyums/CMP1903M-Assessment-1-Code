using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Code
{
    class Analyse
    {
        //Handles the analysis of text

        //Method: analyseText
        //Arguments: string
        //Returns: list of integers
        //Calculates and returns an analysis of the text

        public List<int> analyseText(string input)
        {
            //List of integers to hold the first five measurements:
            //1. Number of sentences
            //2. Number of vowels
            //3. Number of consonants
            //4. Number of upper case letters
            //5. Number of lower case letters
            List<int> values = new List<int>();
            //Initialise all the values in the list to '0'
            for (int i = 0; i < 5; i++)
            {
                values.Add(0);
            }

            string[] sentences = DeconstructSentence(input);

            values[0] = sentences.Length; //Gets the number of sentences.

            values[1] = GetVowelCount(sentences);  //Gets the number of vowels of the sentences.

            values[2] = GetConsonantCount(sentences); //Gets the number of consonants of the sentences.

            values[3] = GetUpperCaseCount(sentences); //Gets the number of Upper Case letters.

            values[4] = GetLowerCaseCount(sentences); //Gets the number of Lower Case letters.


            return values;
        }

        private string[] DeconstructSentence(string input) //Takes the user input and splits it into sentences.
        {
            char[] sentenceEnder = { '!', '?', '.' };
            return input.Split(sentenceEnder);
            
        }

        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

        private int GetVowelCount(string[] sentences)
        {
            int vowelCount = 0;
            foreach (string sentence in sentences)
            {
                string words = sentence.ToLower();
                foreach (char letter in words)
                {
                    if (vowels.Contains(letter))
                    {
                        vowelCount++; //Raise the number of vowels by 1 every time a consonant is found in a letter.
                    }
                }
            }
            return vowelCount;
        }

        private int GetConsonantCount(string[] sentences)
        {
            int consonantCount = 0;
            foreach (string sentence in sentences) 
            {
                foreach (char letter in sentence)
                {

                    if (!vowels.Contains(letter) && char.IsLetter(letter))
                    {
                        consonantCount++; //Raise the number of consonants by 1 every time a consonant is found in a letter.
                    }
                }
            }
            return consonantCount;
        }

        private int GetUpperCaseCount(string[] sentences)
        {

            int upperCaseCount = 0;
            foreach (string sentence in sentences)
            {
                upperCaseCount = upperCaseCount + sentence.Count(c => c >= 'A' && c <= 'Z'); //Adds the number of upper cases from the previous sentence.
            }

            return upperCaseCount;
        }
        private int GetLowerCaseCount(string[] sentences)
        {
            int lowerCaseCount = 0;
            foreach (string sentence in sentences)
            {
                lowerCaseCount = lowerCaseCount + sentence.Count(c => c >= 'a' && c <= 'z');
            }

            return lowerCaseCount;
        }

        public Dictionary<char, int> LetterFrequency(string sentences) //Stores the letters used in the sentences and creates a dictionary of letters and how frequent they appear.
        {
            sentences = sentences.ToLower();
            Dictionary<char, int> frequentLetters = new Dictionary<char, int>();
            foreach (char letter in sentences)
            {
                if (!char.IsLetter(letter)) //If character is a whitespace or punctuation, it is skipped.
                {
                    continue;
                }

                
                if (frequentLetters.ContainsKey(letter)) //If character is already in the dictionary as a key, value of that key is incremented by 1
                {
                    frequentLetters[letter]++;
                }
                else
                {
                    frequentLetters[letter] = 1; //If character is not in dictionary, it is initialised as 1.
                }
            }

            return frequentLetters;
        }

    }
}

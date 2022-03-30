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

            values[0] = sentences.Length - 1; //Gets the number of sentences.
            foreach (string sentence in sentences)
            {
                values[1] = GetVowelCount(sentence, values[1]); //Gets the number of vowels of the sentences.
                values[2] = GetConsonantCount(sentence, values[2]); //Gets the number of consonants of the sentences.
                values[3] = GetUpperCaseCount(sentence, values[3]); //Gets the number of Upper Case letters.
                values[4] = GetLowerCaseCount(sentence, values[4]); //Gets the number of Lower Case letters.
            }


            return values;
        }

        private string[] DeconstructSentence(string input) //Takes the user input and splits it into sentences.
        {
            char[] sentenceEnder = { '!', '?', '.' };
            return input.Split(sentenceEnder);
            
        }

        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

        private int GetVowelCount(string sentence, int curVowelCount)
        {
            string words = sentence.ToLower();
            foreach (char letter in words)
            {
                if (vowels.Contains(letter))
                {
                    curVowelCount++; //Raise the number of vowels by 1 every time a vowel is found in a letter.
                }
            }
            return curVowelCount;
        }

        private int GetConsonantCount(string sentence, int curConsonantCount)
        {
            string words = sentence.ToLower();
            foreach (char letter in words)
            {

                if (!vowels.Contains(letter) && char.IsLetter(letter))
                {
                    curConsonantCount++; //Raise the number of consonants by 1 every time a consonant is found in a letter.
                }
            }
            
            return curConsonantCount;
        }

        private int GetUpperCaseCount(string sentence, int curUpperCaseCount)
        {
            curUpperCaseCount = curUpperCaseCount + sentence.Count(c => c >= 'A' && c <= 'Z'); //Adds the number of upper cases from the sentences provided.

            

            return curUpperCaseCount;
        }
        private int GetLowerCaseCount(string sentence, int curLowerCaseCount)
        {

            curLowerCaseCount = curLowerCaseCount + sentence.Count(c => c >= 'a' && c <= 'z'); //Adds the number of lower cases from the sentences provided.
            
            return curLowerCaseCount;
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

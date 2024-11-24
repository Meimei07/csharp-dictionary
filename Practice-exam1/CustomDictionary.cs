using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_exam1
{
    public class CustomDictionary
    {
        public string DictionaryType;
        public List<WordTranslation> WordTranslations = new List<WordTranslation>();

        public CustomDictionary() { }
        public CustomDictionary(string dictionaryType)
        {
            this.DictionaryType = dictionaryType;
        }

        public void DisplayDictionary()
        {
            Console.WriteLine($" {DictionaryType}");
        }

        public void DisplayWords()
        {
            foreach(WordTranslation wordTranslation in WordTranslations)
            {
                wordTranslation.Display();
            }
        }

        public WordTranslation FindWord(string word)
        {
            foreach (WordTranslation wordTranslation in WordTranslations)
            {
                if (wordTranslation.Word == word)
                {
                    return wordTranslation;
                }
            }
            return null;
        }

        public void AddWord(WordTranslation wordTranslation)
        {
            if(FindWord(wordTranslation.Word) == null)
            {
                WordTranslations.Add(wordTranslation);
                Console.WriteLine("word/translations added success");
            }
            else
            {
                Console.WriteLine("word already exist");
            }
        }

        public void AddTranslation(string word)
        {
            WordTranslation wordTranslation = FindWord(word);
            if(wordTranslation != null)
            {
                wordTranslation.addTranslation();
            }
            else
            {
                Console.WriteLine("word doesn't exist");
            }
        }

        public void RemoveWord(string word)
        {
            WordTranslation wordTranslation = FindWord(word);
            if (wordTranslation != null)
            {
                WordTranslations.Remove(wordTranslation);
                Console.WriteLine("removed success");
            }
            else
            {
                Console.WriteLine("word doesn't exist");
            }
        }

        public void RemoveTranslation(string word)
        {
            WordTranslation wordTranslation = FindWord(word);
            if(wordTranslation != null)
            {
                wordTranslation.removeTranslation();
            }
            else
            {
                Console.WriteLine("word doesn't exist");
            }
        }

        public void ReplaceWord(string word)
        {
            WordTranslation wordTranslation = FindWord(word);
            if (wordTranslation != null)
            {
                wordTranslation.replaceWord();
            }
            else
            {
                Console.WriteLine("word doesn't exist");
            }
        }

        public void ReplaceTranslation(string word)
        {
            WordTranslation wordTranslation = FindWord(word);
            if(wordTranslation != null)
            {
                wordTranslation.replaceTranslation();
            }
            else
            {
                Console.WriteLine("word doesn't exist");
            }
        }

        public void SearchWord(string word)
        {
            WordTranslation wordTranslation = FindWord(word);
            if (wordTranslation != null)
            {
                wordTranslation.Display();
            }
            else
            {
                Console.WriteLine("word doesn't exist");
            }
        }
    }
}
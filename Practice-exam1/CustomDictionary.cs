using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_exam1
{
    public class CustomDictionary
    {
        public string DictionaryType;
        private List<WordTranslation> WordTranslations = new List<WordTranslation>();
        private IOManager io = new IOManager();
        private string path = "D:\\C# term2\\Exam github clone\\csharp-dictionary\\Practice-exam1\\bin\\Debug\\Dictionaries";

        public CustomDictionary() { }
        public CustomDictionary(string dictionaryType)
        {
            this.DictionaryType = dictionaryType;
        }

        public void DisplayDictionary()
        {
            Console.WriteLine($" {DictionaryType}");
        }

        public void ViewAllWords(string dictionaryType)
        {
            WordTranslations = io.ReadJson<List<WordTranslation>>(path, dictionaryType);

            foreach(WordTranslation wordTranslation in WordTranslations)
            {
                wordTranslation.Display();
            }
        }

        public int DisplayWordsToSelect(string dictionaryType)
        {
            WordTranslations = io.ReadJson<List<WordTranslation>>(path, dictionaryType);

            int index = 1;
            foreach(WordTranslation wordTranslation in WordTranslations)
            {
                Console.WriteLine($"{index}. {wordTranslation.Word}");
                index++;
            }
            Console.Write("Select word: ");
            int selected = int.Parse(Console.ReadLine());

            return selected;
        }

        public WordTranslation FindWord(string word, string dictionaryType)
        {
            //read from file
            WordTranslations = io.ReadJson<List<WordTranslation>>(path, dictionaryType);

            WordTranslation wordTranslation = WordTranslations.Find(w => w.Word == word);

            if(wordTranslation != null)
            {
                return wordTranslation;
            }
            else
            {
                return null;
            }
        }

        public void AddWord(string dictionaryType)
        {
            Console.Write("Enter word: ");
            string key = Console.ReadLine();

            //check if word already exist
            if (FindWord(key, dictionaryType) == null)
            {
                List<string> values = new List<string>();
                string input;
                do
                {
                    Console.Write("Enter translation (e to exit): ");
                    input = Console.ReadLine();

                    if (input.ToLower() == "e")
                    {
                        break;
                    }

                    values.Add(input);
                } while (input.ToLower() != "e");

                //read from file
                WordTranslations = io.ReadJson<List<WordTranslation>>(path, dictionaryType);

                WordTranslations.Add(new WordTranslation(key, values));
                Console.WriteLine("word added success");

                //write to file
                io.WriteJson(path, dictionaryType, WordTranslations);
            }
            else
            {
                Console.WriteLine("word already exist");
            }
        }

        public void AddTranslation(string dictionaryType)
        {
            int selected = DisplayWordsToSelect(dictionaryType);

            //read from file
            WordTranslations = io.ReadJson<List<WordTranslation>>(path, dictionaryType);        

            if(selected > 0 && selected <= WordTranslations.Count)
            {
                WordTranslation wordTranslation = WordTranslations[selected - 1];
                wordTranslation.addTranslation(dictionaryType);

                //write to file
                io.WriteJson(path, dictionaryType, WordTranslations);
            }
            else
            {
                Console.WriteLine("invalid selection");
            }
        }

        public void RemoveWord(string dictionaryType)
        {
            int selected = DisplayWordsToSelect(dictionaryType);

            //read from file
            WordTranslations = io.ReadJson<List<WordTranslation>>(path, dictionaryType);

            if(selected > 0 && selected <= WordTranslations.Count)
            {
                WordTranslations.RemoveAt(selected - 1);
                Console.WriteLine("word removed success");

                //write to file
                io.WriteJson(path, dictionaryType, WordTranslations);
            }
            else
            {
                Console.WriteLine("invalid selection");
            }
        }

        public void RemoveTranslation(string dictionaryType)
        {
            int selected = DisplayWordsToSelect(dictionaryType);

            //read from file
            WordTranslations = io.ReadJson<List<WordTranslation>>(path, dictionaryType);

            if (selected > 0 && selected <= WordTranslations.Count)
            {
                WordTranslation wordTranslation = WordTranslations[selected - 1];
                wordTranslation.removeTranslation();

                //write to file
                io.WriteJson(path, dictionaryType, WordTranslations);
            }
            else
            {
                Console.WriteLine("invalid selection");
            }
        }

        public void ReplaceWord(string dictionaryType)
        {
            int selection = DisplayWordsToSelect(dictionaryType);

            //read from file
            WordTranslations = io.ReadJson<List<WordTranslation>>(path, dictionaryType);

            if(selection > 0 && selection <= WordTranslations.Count)
            {
                WordTranslation wordTranslation = WordTranslations[selection - 1];
                wordTranslation.replaceWord(WordTranslations);
            }
            else
            {
                Console.WriteLine("invalid selection");
            }
        }

        public void ReplaceTranslation(string dictionaryType)
        {
            int selection = DisplayWordsToSelect(dictionaryType);

            //read from file
            WordTranslations = io.ReadJson<List<WordTranslation>>(path, dictionaryType);

            if (selection > 0 && selection <= WordTranslations.Count)
            {
                WordTranslation wordTranslation = WordTranslations[selection - 1];
                wordTranslation.replaceTranslation();

                //write to file
                io.WriteJson(path, dictionaryType, WordTranslations);
            }
            else
            {
                Console.WriteLine("invalid selection");
            }
        }

        public void SearchWord(string word, string dictionaryType)
        {
            WordTranslation wordTranslation = FindWord(word, dictionaryType);
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
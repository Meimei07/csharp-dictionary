using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Practice_exam1
{
    public class CustomDictionary
    {
        public string DictionaryType;
        private List<WordTranslation> WordTranslations = new List<WordTranslation>();
        private IOManager io = new IOManager();
        private string path = Directory.GetCurrentDirectory() + @"\Dictionaries";
        private string exportPath = Directory.GetCurrentDirectory() + @"\Export";

        public CustomDictionary() { }
        public CustomDictionary(string dictionaryType)
        {
            this.DictionaryType = dictionaryType;
        }

        public void DisplayDictionary()
        {
            Console.WriteLine($" {DictionaryType}");
        }

        public void FileExist(string dictionaryType)
        {
            //read from file
            string fullPath = Path.Combine(path, dictionaryType + ".json");
            if (File.Exists(fullPath))
            {
                WordTranslations = io.ReadJson<List<WordTranslation>>(path, dictionaryType);
            }
        }

        public bool ViewAllWords(string dictionaryType)
        {
            FileExist(dictionaryType);

            if(WordTranslations.Count == 0)
            {
                return false;
            }
            else
            {
                Console.WriteLine();
                int index = 1;
                foreach (WordTranslation wordTranslation in WordTranslations)
                {
                    Console.Write(index);
                    wordTranslation.Display();
                    index++;
                }
                return true;
            }
        }

        public int DisplayWordsToSelect(string dictionaryType)
        {
            if(ViewAllWords(dictionaryType) == true)
            {
                Console.Write("Select word: ");
                int selected = int.Parse(Console.ReadLine());

                return selected;
            }
            else
            {
                return 0;
            }
        }

        public WordTranslation FindWord(string word, string dictionaryType)
        {
            FileExist(dictionaryType);

            WordTranslation wordTranslation = WordTranslations.Find(w => w.Word.ToLower() == word.ToLower());

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
            Console.Write("\nAdd word: ");
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

                    if(values.Find(value => value.ToLower() == input.ToLower()) == null)
                    {
                        values.Add(input);
                    }
                    else
                    {
                        Console.WriteLine("translation already exist");
                    }

                } while (input.ToLower() != "e");

                FileExist(dictionaryType);

                WordTranslations.Add(new WordTranslation(key, values));

                //write to file
                io.WriteJson(path, dictionaryType, WordTranslations);
                
                Console.WriteLine("word added success");
            }
            else
            {
                Console.WriteLine("word already exist");
            }
        }

        public void AddTranslation(string dictionaryType)
        {
            int selected = DisplayWordsToSelect(dictionaryType);

            FileExist(dictionaryType);

            if (selected > 0 && selected <= WordTranslations.Count)
            {
                WordTranslation wordTranslation = WordTranslations[selected - 1];
                wordTranslation.addTranslation(dictionaryType);

                //write to file
                io.WriteJson(path, dictionaryType, WordTranslations);
            }
            else
            {
                Console.WriteLine("no available word");
            }
        }

        public void RemoveWord(string dictionaryType)
        {
            int selected = DisplayWordsToSelect(dictionaryType);

            FileExist(dictionaryType);

            if (selected > 0 && selected <= WordTranslations.Count)
            {
                WordTranslations.RemoveAt(selected - 1);

                //write to file
                io.WriteJson(path, dictionaryType, WordTranslations);

                Console.WriteLine("word removed success");
            }
            else
            {
                Console.WriteLine("no available word");
            }
        }

        public void RemoveTranslation(string dictionaryType)
        {
            int selected = DisplayWordsToSelect(dictionaryType);

            FileExist(dictionaryType);

            if (selected > 0 && selected <= WordTranslations.Count)
            {
                WordTranslation wordTranslation = WordTranslations[selected - 1];
                wordTranslation.removeTranslation();

                //write to file
                io.WriteJson(path, dictionaryType, WordTranslations);
            }
            else
            {
                Console.WriteLine("no available word");
            }
        }

        public void ReplaceWord(string dictionaryType)
        {
            int selection = DisplayWordsToSelect(dictionaryType);

            FileExist(dictionaryType);

            if (selection > 0 && selection <= WordTranslations.Count)
            {
                WordTranslation wordTranslation = WordTranslations[selection - 1];
                //wordTranslation.replaceWord(WordTranslations);

                Console.Write("Enter new word: ");
                string newWord = Console.ReadLine();

                bool exist = false;
                foreach (WordTranslation wordTrans in WordTranslations)
                {
                    if (wordTrans.Word == newWord)
                    {
                        exist = true;
                    }
                }

                if (exist == true)
                {
                    Console.WriteLine("word already exist");
                }
                else
                {
                    wordTranslation.Word = newWord;

                    //write to file
                    io.WriteJson(path, dictionaryType, WordTranslations);
                    
                    Console.WriteLine("word replaced success");
                }
            }
            else
            {
                Console.WriteLine("no available word");
            }
        }

        public void ReplaceTranslation(string dictionaryType)
        {
            int selection = DisplayWordsToSelect(dictionaryType);

            FileExist(dictionaryType);

            if (selection > 0 && selection <= WordTranslations.Count)
            {
                WordTranslation wordTranslation = WordTranslations[selection - 1];
                wordTranslation.replaceTranslation();

                //write to file
                io.WriteJson(path, dictionaryType, WordTranslations);
            }
            else
            {
                Console.WriteLine("no available word");
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
                Console.WriteLine($"word ({word}) doesn't exist");
            }
        }

        public void exportWord(string dictionaryType)
        {
            int selected = DisplayWordsToSelect(dictionaryType);

            FileExist(dictionaryType);

            if (selected > 0 && selected <= WordTranslations.Count)
            {
                WordTranslation wordTranslation = WordTranslations[selected - 1];

                io.WriteJson(exportPath, wordTranslation.Word, wordTranslation);
                Console.WriteLine("word exported success");
            }
            else
            {
                Console.WriteLine("no available word");
            }
        }
    }
}
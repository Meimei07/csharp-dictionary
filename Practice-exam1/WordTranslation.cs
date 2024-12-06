using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Practice_exam1
{
    public class WordTranslation
    {
        public string Word;
        public List<string> Translations;

        public WordTranslation()
        {
            Word = string.Empty;
            Translations = new List<string>();
        }
        public WordTranslation(string word)
        {
            this.Word = word;
            Translations = new List<string>();
        }
        public WordTranslation(string word, List<string> translations)
        {
            this.Word = word;
            this.Translations = translations;
        }

        public void Display()
        {
            Console.Write($"-{Word} --> ");
            for (int i = 0; i < Translations.Count; i++)
            {
                Console.Write($"   {i + 1}. {Translations[i]}");
            }
            Console.WriteLine();
        }

        public void addTranslation(string dictionaryType)
        {
            Console.WriteLine();
            Display();
            Console.Write("Add translation: ");
            string translation = Console.ReadLine();

            if (Translations.Find(trans => trans.ToLower() == translation.ToLower()) == null)
            {
                Translations.Add(translation);
                Console.WriteLine("translation added success");
            }
            else
            {
                Console.WriteLine("translation already exist");
            }
        }

        public void removeTranslation()
        {
            if(Translations.Count > 1)
            {
                Console.WriteLine();
                Display();
                Console.Write("Select translation to remove: ");
                int selected = int.Parse(Console.ReadLine());

                if (selected > 0 && selected <= Translations.Count)
                {
                    Translations.RemoveAt(selected - 1);
                    Console.WriteLine("translation removed success");
                }
                else
                {
                    Console.WriteLine("invalid selection");
                }
            }
            else if(Translations.Count == 1)
            {
                Console.WriteLine("remain only 1 translation. can't remove");
            }
        }

        public void replaceTranslation()
        {
            Console.WriteLine();
            Display();
            Console.Write("Select translation to replace: ");
            int selected = int.Parse(Console.ReadLine());

            if(selected > 0 && selected <= Translations.Count)
            {
                Console.Write("Enter new translation: ");
                string newTranslation = Console.ReadLine();

                if (Translations.Find(trans => trans.ToLower() == newTranslation.ToLower()) == null)
                {
                    Translations[selected - 1] = newTranslation;
                    Console.WriteLine("translation replaced success");
                }
                else
                {
                    Console.WriteLine("translation already exist");
                }
            }
            else
            {
                Console.WriteLine("invalid selection");
            }
        }
    }
}
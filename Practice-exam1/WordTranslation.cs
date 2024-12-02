using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void addTranslation(string dictionaryType)
        {
            Display();

            Console.Write("Add translation: ");
            string translation = Console.ReadLine(); 

            if (!Translations.Contains(translation))
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

//        public void replaceWord(List<WordTranslation> WordTranslations)
//        {
//            Console.Write("Enter new word: ");
//            string newWord = Console.ReadLine();

//            bool exist = false;
//            foreach (WordTranslation wordTranslation in WordTranslations)
//            {
//                if (wordTranslation.Word == newWord)
//                {
//;                   exist = true;
//                }
//            }

//            if(exist == true)
//            {
//                Console.WriteLine("word already exist");
//            }
//            else
//            {
//                Word = newWord;
//                Console.WriteLine("word replaced success");
//            }
//        }

        public void replaceTranslation()
        {
            Display();
            Console.Write("Select translation to replace: ");
            int selected = int.Parse(Console.ReadLine());

            if(selected > 0 && selected <= Translations.Count)
            {
                Console.Write("Enter new translation: ");
                string newTranslation = Console.ReadLine();

                if(!Translations.Contains(newTranslation))
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

        public void Display()
        {
            Console.Write(Word + " --> ");
            for(int i=0; i<Translations.Count; i++)
            {
                Console.Write($"   {i + 1}. {Translations[i]}");
            }
            Console.WriteLine();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_exam1
{
    public class DictionaryMenu
    {
        CustomDictionary dictionary = new CustomDictionary();

        public DictionaryMenu(CustomDictionary customDictionary)
        {
            this.dictionary = customDictionary;
        }

        public void StartDictionaryMenu()
        {
            Console.WriteLine(@"========== Dictionary Menu ==========
1. Add word/translation
2. Remove word/translation
3. Replace word/translation
4. Search word
5. Show all words
0. Back to main menu");
            Console.Write("Enter: ");
            int option = int.Parse(Console.ReadLine());

            switch(option)
            {
                case 1: AddWordTranslation(); break;
                case 2: RemoveWordTranslation(); break;
                case 3: ReplaceWordTranslation(); break;
                case 4: SearchWord(); break;
                case 5: ShowAllWords(); break;
                case 0: BackToMainMenu(); break;
                default: StartDictionaryMenu(); break;
            }
        }

        public void AddWordTranslation()
        {
            Console.WriteLine(@" 1. Add word with translations
 2. Add translation to existing word
 0. Back to menu");
            Console.Write("Enter: ");
            int option = int.Parse(Console.ReadLine());

            switch(option)
            {
                case 1: addWordTrans(); break;
                case 2: addTrans(); break;
                case 0: StartDictionaryMenu(); break;
                default: AddWordTranslation(); break;
            }
        }

        public void addWordTrans()
        {
            Console.Write("Enter word: ");
            string key = Console.ReadLine();
            
            List<string> values = new List<string>();
            string input;
            do
            {
                Console.Write("Enter translation (e to exit): ");
                input = Console.ReadLine();

                if(input.ToLower() == "e")
                {
                    break;
                }

                values.Add(input);
            } while (input.ToLower() != "e");

            dictionary.AddWord(new WordTranslation(key, values));
            AddWordTranslation();
        }

        public void addTrans()
        {
            Console.Write("Enter word you want to add translation to: ");
            string key = Console.ReadLine();

            dictionary.AddTranslation(key);
            AddWordTranslation();
        }

        public void RemoveWordTranslation()
        {
            Console.WriteLine(@" 1. Remove word
 2. Remove translation from existing word
 0. Back to menu");
            Console.Write("Enter: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: removeWord(); break;
                case 2: removeTrans(); break;
                case 0: StartDictionaryMenu(); break;
                default: RemoveWordTranslation(); break;
            }
        }

        public void removeWord()
        {
            Console.Write("Enter word to remove: ");
            string key = Console.ReadLine();

            dictionary.RemoveWord(key);
            RemoveWordTranslation();
        }

        public void removeTrans()
        {
            Console.Write("Enter word you want to remove translation: ");
            string key = Console.ReadLine();

            dictionary.RemoveTranslation(key);
            RemoveWordTranslation();
        }

        public void ReplaceWordTranslation()
        {
            Console.WriteLine(@" 1. Replace word
 2. Replace translation from existing word
 0. Back to menu");
            Console.Write("Enter: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: replaceWord(); break;
                case 2: replaceTrans(); break;
                case 0: StartDictionaryMenu(); break;
                default: ReplaceWordTranslation(); break;
            }
        }

        public void replaceWord()
        {
            Console.Write("Enter word to replace: ");
            string key = Console.ReadLine();

            dictionary.ReplaceWord(key);
            ReplaceWordTranslation();
        }

        public void replaceTrans()
        {
            Console.Write("Enter word you want to replace translation: ");
            string key = Console.ReadLine();

            dictionary.ReplaceTranslation(key);
            ReplaceWordTranslation();
        }

        public void SearchWord()
        {
            Console.Write("Enter word: ");
            string key = Console.ReadLine();

            dictionary.SearchWord(key);
            StartDictionaryMenu();
        }

        public void ShowAllWords()
        {
            dictionary.DisplayWords();
            StartDictionaryMenu();
        }

        public void BackToMainMenu() { }
    }
}
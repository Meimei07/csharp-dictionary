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

        public void StartDictionaryMenu(string dictionaryType)
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
                case 1: AddWordTranslation(dictionaryType); break;
                case 2: RemoveWordTranslation(dictionaryType); break;
                case 3: ReplaceWordTranslation(dictionaryType); break;
                case 4: SearchWord(dictionaryType); break;
                case 5: ShowAllWords(dictionaryType); break;
                case 0: BackToMainMenu(); break;
                default: StartDictionaryMenu(dictionaryType); break;
            }
        }

        public void AddWordTranslation(string dictionaryType)
        {
            Console.WriteLine(@" 1. Add word with translations
 2. Add translation to existing word
 0. Back to menu");
            Console.Write("Enter: ");
            int option = int.Parse(Console.ReadLine());

            switch(option)
            {
                case 1: addWordTrans(dictionaryType); break;
                case 2: addTrans(dictionaryType); break;
                case 0: StartDictionaryMenu(dictionaryType); break;
                default: AddWordTranslation(dictionaryType); break;
            }
        }

        public void addWordTrans(string dictionaryType)
        {
            dictionary.AddWord(dictionaryType);
            AddWordTranslation(dictionaryType);
        }

        public void addTrans(string dictionaryType)
        {
            dictionary.AddTranslation(dictionaryType);
            AddWordTranslation(dictionaryType);
        }

        public void RemoveWordTranslation(string dictionaryType)
        {
            Console.WriteLine(@" 1. Remove word
 2. Remove translation from existing word
 0. Back to menu");
            Console.Write("Enter: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: removeWord(dictionaryType); break;
                case 2: removeTrans(dictionaryType); break;
                case 0: StartDictionaryMenu(dictionaryType); break;
                default: RemoveWordTranslation(dictionaryType); break;
            }
        }

        public void removeWord(string dictionaryType)
        {
            dictionary.RemoveWord(dictionaryType);
            RemoveWordTranslation(dictionaryType);
        }

        public void removeTrans(string dictionaryType)
        {
            dictionary.RemoveTranslation(dictionaryType);
            RemoveWordTranslation(dictionaryType);
        }

        public void ReplaceWordTranslation(string dictionaryType)
        {
            Console.WriteLine(@" 1. Replace word
 2. Replace translation from existing word
 0. Back to menu");
            Console.Write("Enter: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: replaceWord(dictionaryType); break;
                case 2: replaceTrans(dictionaryType); break;
                case 0: StartDictionaryMenu(dictionaryType); break;
                default: ReplaceWordTranslation(dictionaryType); break;
            }
        }

        public void replaceWord(string dictionaryType)
        {
            dictionary.ReplaceWord(dictionaryType);
            ReplaceWordTranslation(dictionaryType);
        }

        public void replaceTrans(string dictionaryType)
        {
            dictionary.ReplaceTranslation(dictionaryType);
            ReplaceWordTranslation(dictionaryType);
        }

        public void SearchWord(string dictionaryType)
        {
            Console.Write("Search word: ");
            string key = Console.ReadLine();

            dictionary.SearchWord(key, dictionaryType);
            StartDictionaryMenu(dictionaryType);
        }

        public void ShowAllWords(string dictionaryType)
        {
            dictionary.ViewAllWords(dictionaryType);
            StartDictionaryMenu(dictionaryType);
        }

        

        public void BackToMainMenu() { }
    }
}
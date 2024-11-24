using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_exam1
{
    public class Menu
    {
        public List<CustomDictionary> Dictionaries = new List<CustomDictionary>();
        public CustomDictionary dictionary;
        public void StartMenu()
        {
            Console.WriteLine(@"========== Menu ==========
1. Create dictionary
2. Show dictionaries
3. Select dictionary");
            Console.Write("Enter: ");
            int option = int.Parse(Console.ReadLine());

            switch(option)
            {
                case 1: Create(); break;
                case 2: Show(); break;
                case 3: Select(); break;
                default: StartMenu(); break;
            }
        }

        public void Create()
        {
            Console.Write("Enter dictionary type (e.g. English-Khmer): ");
            string type = Console.ReadLine();

            Dictionaries.Add(new CustomDictionary(type));
            Console.WriteLine("dictionary added success");
            StartMenu();
        }

        public void Show()
        {
            Console.WriteLine("Dictionaries...");
            foreach(CustomDictionary dictionary in Dictionaries)
            {
                dictionary.DisplayDictionary();
            }
            StartMenu();
        }

        public void Select()
        {
            for(int i=0; i<Dictionaries.Count; i++)
            {
                Console.Write($"{i + 1}.");
                Dictionaries[i].DisplayDictionary();
            }

            Console.Write("Select: ");
            int selected = int.Parse(Console.ReadLine());
            Console.WriteLine($"Dictionary {Dictionaries[selected-1].DictionaryType} is selected.");

            CustomDictionary customDictionary = Dictionaries[selected - 1];
            DictionaryMenu dictionaryMenu = new DictionaryMenu(customDictionary);
            dictionaryMenu.StartDictionaryMenu();

            StartMenu();
        }
    }
}
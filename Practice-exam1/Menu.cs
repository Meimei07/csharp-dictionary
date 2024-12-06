using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Practice_exam1
{
    public class Menu
    {
        private List<CustomDictionary> Dictionaries = new List<CustomDictionary>();
        private CustomDictionary dictionary;
        private IOManager io = new IOManager();
        private string path = Directory.GetCurrentDirectory() + @"\Dictionaries";

        public void StartMenu()
        {
            Console.WriteLine(@"========== Main Menu ==========
1. Create dictionary
2. Show dictionaries
3. Select dictionary");
            Console.Write("Enter: ");
            int option = int.Parse(Console.ReadLine());

            switch(option)
            {
                case 1: Create(); break;
                case 2: Show(); Console.WriteLine(); StartMenu(); break;
                case 3: Select(); break;
                default: StartMenu(); break;
            }
        }

        public void Create()
        {
            Console.Write("Enter dictionary type (e.g. English-Khmer): ");
            string type = Console.ReadLine();

            //check if file type already exist
            List<FileInfo> files = io.LoadFiles(path);

            if (files.Find(f => io.GetFileName(f).ToLower() == type.ToLower()) == null)
            {
                Dictionaries.Add(new CustomDictionary(type));
                io.WriteJson(path, type, new List<WordTranslation>());
                Console.WriteLine("dictionary added success");
            }
            else
            {
                Console.WriteLine("dictionary type already exist");
            }

            Console.WriteLine();
            StartMenu();
        }

        public void Show()
        {
            List<FileInfo> dictionaries = io.LoadFiles(path);
            if (dictionaries.Count == 0)
            {
                Console.WriteLine("no available dictionary\n");
                StartMenu();
            }

            Console.WriteLine("\nDictionaries...");
            int index = 1;       
            foreach(FileInfo dictionary in dictionaries)
            {
                Console.WriteLine($"{index}. {io.GetFileName(dictionary)}");
                index++;
            }
        }

        public void Select()
        {
            Show();

            List<FileInfo> dictionaries = io.LoadFiles(path);

            Console.Write("Select dictionary: ");
            int selected = int.Parse(Console.ReadLine());

            if(selected > 0 && selected <= dictionaries.Count)
            {
                Dictionaries = dictionaries.Select(file => new CustomDictionary
                {
                    DictionaryType = io.GetFileName(file)
                }).ToList();
                
                string selectedDictionary = Dictionaries[selected - 1].DictionaryType;
                Console.WriteLine($"Dictionary {selectedDictionary} is selected.");

                CustomDictionary customDictionary = Dictionaries[selected - 1];
                DictionaryMenu dictionaryMenu = new DictionaryMenu(customDictionary);
                dictionaryMenu.StartDictionaryMenu(selectedDictionary);
            }
            else
            {
                Console.WriteLine("invalid selection\n");
            }

            StartMenu();
        }
    }
}
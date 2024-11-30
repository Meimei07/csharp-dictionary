using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Practice_exam1
{
    public class IOManager
    {
        private string extension = ".json";

        public void WriteJson(string path, string fileName, Object obj)
        {
            string fullPath = path + @"\" + fileName + extension;
            StreamWriter streamWriter = new StreamWriter(fullPath);
            string content = JsonConvert.SerializeObject(obj);
            streamWriter.Write(content);
            streamWriter.Close();
        }

        public T ReadJson<T>(string path, string fileName)
        {
            string fullPath = path + @"\" + fileName + extension;
            StreamReader streamReader=new StreamReader(fullPath);
            string cotent = streamReader.ReadToEnd();
            return JsonConvert.DeserializeObject<T>(cotent);
        }

        public List<FileInfo> LoadFiles(string path)
        {
            DirectoryInfo folder = new DirectoryInfo(path);
            FileInfo[] files = folder.GetFiles();
            return files.ToList();
        }

        public string GetFileName(FileInfo file)
        {
            return file.Name.Replace(file.Extension, "");
        }
    }
}
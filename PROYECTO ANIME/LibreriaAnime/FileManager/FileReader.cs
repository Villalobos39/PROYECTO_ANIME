using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LibreriaAnime.FileManager
{
    public class FileReader
    {
        public static List<string> ReadFile(String path)
        {
            return File.ReadAllLines(path).ToList();
        }
    }
}

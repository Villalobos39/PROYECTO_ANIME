using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaAnime.FileManager
{
    public class FileWriterJson : IFileWriter
    {
        public void Write(List<Anime> animes, string path)
        {
            var json = JsonConvert.SerializeObject(animes);
            File.WriteAllText(path, json);
        }
    }

}

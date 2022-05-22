using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibreriaAnime.FileManager
{
    public class FileWriterXml : IFileWriter
    {
        public void Write(List<Anime> animes, string path)
        {
            var serializer = new XmlSerializer(typeof(List<Anime>));
            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, animes);
            }
        }
    }
}

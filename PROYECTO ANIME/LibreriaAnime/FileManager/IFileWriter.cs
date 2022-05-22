using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaAnime.FileManager
{
    public interface IFileWriter
    {
         void Write(List<Anime> animes, string path);
    }
}

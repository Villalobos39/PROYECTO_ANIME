using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaAnime
{
    public interface IRepository
    {
        List<Anime> GetAll();
        List<Anime> GetAnimeByName(string anime);
        long Create(Anime anime);
    }
}

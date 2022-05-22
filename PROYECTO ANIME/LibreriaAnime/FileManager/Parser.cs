using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibreriaAnime.FileManager
{
    public class Parser
    {
        public Anime Parse(string line)
        {
            var anime = new Anime();
            var values = line.Split(',');
            anime.Id_Anime = long.Parse(values[0]);

            anime.Titulo_Anime = values[1];
            anime.Generos = ParseGenre(values[2]);
            //anime.Genero = values[1];
            //anime.Tipos = values[1];
            return anime;
        }
        public Generos ParseGenre(string line)
        {
            Generos returnValue = new Generos();
            var values = line.Split('-');
            foreach (var item in values)
            {
                if (item.Any(Char.IsWhiteSpace))
                {
                    if (item == "Aventura Fantasia")
                        returnValue = returnValue | Generos.Aventura | Generos.Fantasia;
                }
                else
                {
                    if (Enum.TryParse<Generos>(item, out var genreroValue))
                        returnValue = returnValue | genreroValue;
                }
            }
            return returnValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibreriaAnime
{
    public class Repositorio
    {
        public List<Anime> ListaAnime { get; set; }
        private bool LoadedFile { get; set; } = false;

        public void LoadFile(String filename)
        {
            try
            {
                ListaAnime = new List<Anime>();
                var listAnimeStrings = FileManager.FileReader.ReadFile(filename);
                foreach (var item in listAnimeStrings.Skip(1).Take(20))
                {
                    var parser = new FileManager.Parser();
                    var anime = parser.Parse(item);
                    ListaAnime.Add(anime);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            LoadedFile = true;
        }

        public List<Anime> GetAll()
        {
            if (LoadedFile == false)
            {
                throw new Exception("NO SE CARGO EL ARCHIVO");
            }
            return ListaAnime;
        }

        public List<Anime> GetAnimeByTitulo(String title)
        {
            Console.WriteLine("LEYENDO ANIMES POR TITULO");
            if (LoadedFile == false)
            {
                throw new Exception("NO SE CARGO EL ARCHIVO");
            }
            return ListaAnime.Where(m => m.Titulo_Anime.Contains(title)).ToList();
        }
    }
}


//public List<Anime> GetAlls()
//{
//    var listAnimeStrings = FileManager.FileReader.ReadFile(@"C:\Users\dulso\OneDrive\Documentos\Anime\TablaAnime.csv");

//    List<Anime> listaAnime = new List<Anime>();
//    foreach (var item in listAnimeStrings.Skip(1))
//    {
//        var parser = new FileManager.Parser();
//        var movie = parser.Parse(item);
//        listaAnime.Add(movie);
//    }

//    return listaAnime;
//}
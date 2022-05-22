using System;
using System.Linq;

namespace Proyecto_Anime
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new LibreriaAnime.Repositorio();
            repository.LoadFile(@"C:\Users\dulso\OneDrive\Documentos\Anime\TablaAnime.csv");
            Console.WriteLine("ARCHIVO CARGADO");
            LibreriaAnime.FileManager.IFileWriter writer = new LibreriaAnime.FileManager.FileWriterXml();
            writer.Write(repository.GetAnimeByTitulo("ONE PIECE").Take(10).ToList(), "TablaAnime.xml");

            Console.Write("________________________ ~~~ LISTA DE ANIMES ~~~ ___________________________\n\n");
            foreach (var anime in repository.GetAll())
            {
                Console.Write("   °°° TITULO DEL ANIME  :  " + anime.Titulo_Anime + "|  \n");
                Console.Write("   ^^^ TIPO DE ANIME     :  " + anime.Tipo + "|  \n");
                Console.Write("   ¬¬¬ GENEROS DEL ANIME :  " + anime.Generos+ "\n\n");
                Console.Write("___________________________________________________________________________________\n");
                Console.ReadLine();
            }
        }
    }
}
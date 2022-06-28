using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LibreriaAnime;

namespace AnimeWebApi.sqlManager
{
    public class SqlRepository
    {
        private SqlConnectionStringBuilder sqlConnectionStringBuilder
        {
            get
            {
                return new SqlConnectionStringBuilder()
                {
                    DataSource = @"SISTEMAS-01\SQLEXPRESS",
                    IntegratedSecurity = true,
                    InitialCatalog = "Anime"
                };
            }
        }


        public List<Anime> GetAll()
        {
            List<Anime> anime = new List<Anime>();
            using (SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {

                connection.Open();
                String sql = "SELECT ANIME_ID, NOMBRE, GENERO FROM REGISTROS_ANIME";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            anime.Add(new Anime()
                            {
                                Id_Anime = reader.GetInt32(0),
                                Titulo_Anime = reader.GetString(1)
                            });
                        }
                    }
                }
            }

            return anime;
        }

        public List<Anime> GetAnimeByName(string title)
        {
            List<Anime> anime = new List<Anime>();
            using (SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {

                connection.Open();

                String sql = "SELECT ANIME_ID, NOMBRE, GENERO FROM REGISTROS_ANIME where NOMBRE like @title";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    SqlParameter titleParam = new SqlParameter("@title", System.Data.SqlDbType.VarChar);
                    titleParam.Value = "%" + title + "%";
                    titleParam.Direction = System.Data.ParameterDirection.Input;
                    command.Parameters.Add(titleParam);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            anime.Add(new Anime()
                            {
                                Id_Anime = reader.GetInt32(0),
                                Titulo_Anime = reader.GetString(1)
                            });
                        }
                    }
                }
            }

            return anime;
        }
    }

}

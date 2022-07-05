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


        public long Create(Anime anime)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
                {
                    connection.Open();
                    var SqlCreate = "Insert into REGISTROS_ANIME_2 (ANIME_ID"
                            + ",NOMBRE"
                            + ",GENERO"
                            + ",TIPO"
                            + ",EPISODIO"
                            + " )"
                            + " Values ( "
                            + " @ANIME_ID "
                            + " , @NOMBRE"
                            + " , @GENERO"
                            + " , @TIPO "
                            + " , @EPISODIO) ";

                    SqlCommand sqlCommand = new SqlCommand(SqlCreate, connection);

                    sqlCommand.Parameters.Add(new SqlParameter("@ANIME_ID", anime.Id_Anime));
                    sqlCommand.Parameters.Add(new SqlParameter("@NOMBRE", anime.Titulo_Anime));
                    sqlCommand.Parameters.Add(new SqlParameter("@GENERO", anime.Generos));
                    sqlCommand.Parameters.Add(new SqlParameter("@TIPO", anime.Tipo));
                    sqlCommand.Parameters.Add(new SqlParameter("@EPISODIO", anime.Episodios));

                    sqlCommand.ExecuteNonQuery();
                    return anime.Id_Anime;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

    }

}


/// ESQUEMA DE LA BASE DE DATOS 

//CREATE TABLE REGISTROS_ANIME_2(
//	ANIME_ID int,
//    NOMBRE varchar(255),
//    GENERO varchar(255),
//    TIPO varchar(20),
//    EPISODIO int
//);

//INSERT INTO REGISTROS_ANIME VALUES (32281, 'Kimi no Na wa.', 'Drama, Romance, School, Supernatural','Movie',1);
//INSERT INTO REGISTROS_ANIME VALUES (5114, 'Fullmetal Alchemist: Brotherhood', 'Action, Adventure, Drama, Fantasy, Magic, Military, Shounen','TV',64);
//INSERT INTO REGISTROS_ANIME VALUES (28977, 'Gintamaa.', 'Action, Comedy, Historical, Parody, Samurai, Sci-Fi, Shounen','TV',51);
//INSERT INTO REGISTROS_ANIME VALUES (21, 'One Piece.', 'Action, Adventure, Comedy, Drama, Fantasy, Shounen, Super Power','TV',1018);
//INSERT INTO REGISTROS_ANIME VALUES (28755, 'Boruto: Naruto the Movie.', 'Action, Comedy, Martial Arts, Shounen, Super Power','Movie',1);
//INSERT INTO REGISTROS_ANIME VALUES (1735, 'Naruto: Shippuuden.', 'Action, Comedy, Martial Arts, Shounen, Super Power','TV',500);
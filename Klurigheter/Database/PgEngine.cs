using Klurigheter.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klurigheter.Database
{
    static class PgEngine
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString;

        /// <summary>
        /// Metod som utifrån ett postgresexception sedan kan skicka ut en sträng med relevant meddelande
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>Sträng med felmeddelande</returns>
        public static string ErrorMessage(PostgresException ex)
        {
            string errorMessage = "";
            //ex.ConstraintName

            //Returnera den sträng du skapat med information
            return errorMessage;
        }
        public static int SavePlayer(Player player)
        {
            int id;
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand() )
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO player(name, nickname) values(@name, @nickname) returning player_id";
                    cmd.Parameters.AddWithValue("name", player.Name);
                    cmd.Parameters.AddWithValue("nickname", player.Nickname);
                    id = cmd.ExecuteNonQuery();
                }
            }
            return id;
        }

        public static int SavePlayer2(Player player)
        {
            int id=0;
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO player(name, nickname) values(@name, @nickname) returning player_id ";
                    cmd.Parameters.AddWithValue("name", player.Name);
                    cmd.Parameters.AddWithValue("nickname", player.Nickname);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = (int)reader["player_id"];
                        }
                    }
                }
            }
            return id;
        }

        #region Transaktionshantering
        public static List<Player> SavePlayers(List<Player> players)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (NpgsqlTransaction trans = conn.BeginTransaction())
                {
                    using (var cmd = new NpgsqlCommand())
                    {
                        try
                        {
                            cmd.Connection = conn;
                            foreach (var p in players)
                            {
                                cmd.Parameters.Clear();
                                cmd.CommandText = "INSERT INTO player(name, nickname) values(@name, @nickname) returning player_id";
                                cmd.Parameters.AddWithValue("name", p.Name);
                                cmd.Parameters.AddWithValue("nickname", p.Nickname);
                                using (var reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        p.Player_id = (int)reader["player_id"];

                                    }
                                }
                            }
                            trans.Commit();
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
                return players;
            }
        }
        #endregion

    }
}

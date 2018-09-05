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

        public static string ErrorMessage(PostgresException ex)
        {
            //ex.ConstraintName
            return "Databasen krånglar";
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


    }
}

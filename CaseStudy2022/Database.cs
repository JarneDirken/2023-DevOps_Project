using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
    public class Database
    {
        //Database stuff -> https://www.youtube.com/watch?v=QppzzwaET-s
        
        public static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqliteConn;

            sqliteConn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True;");
            try
            {
                sqliteConn.Open();
            }
            catch
            {

            }
            return sqliteConn;
        }
        public static void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand sqliteCommand;

            string createSQL = "CREATE TABLE IF NOT EXISTS MilestoneTable(username VARCHAR(45), score int);";
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = createSQL;
            sqliteCommand.ExecuteNonQuery();
        }
        public static void InsertData(SQLiteConnection conn)
        {
            string addData = ($"INSERT INTO MilestoneTable(username, score) VALUES ('{Program.getName()}', '{Program.score}');");
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = addData;
            sqliteCommand.ExecuteNonQuery();

            conn.Close();
        }
        public static string HighScoreName()
        {
            using (SQLiteConnection conn = new SQLiteConnection(Database.CreateConnection()))
            {
                using (SQLiteCommand command = new SQLiteCommand("SELECT username FROM milestonetable ORDER BY score DESC LIMIT 1", conn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            string name = reader.GetString(0);
                            conn.Close();
                            return name;
                        }
                        else
                        {
                            return "No data found";
                        }
                    }
                }
            }
        }
        public static int HighScoreValue()
        {
            using (var conn = new SQLiteConnection(Database.CreateConnection()))
            {
                {
                    using (var command = new SQLiteCommand("SELECT score FROM milestonetable ORDER BY score DESC LIMIT 1;", conn))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                int score = reader.GetInt32(0);
                                conn.Close();
                                return score;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }
                }
            }
        }
        public static void DeleteTable(SQLiteConnection conn)
        {
            SQLiteCommand sqliteCommand;

            string createSQL = "DROP TABLE IF EXISTS MilestoneTable;";
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = createSQL;
            sqliteCommand.ExecuteNonQuery();
        }
    }
}

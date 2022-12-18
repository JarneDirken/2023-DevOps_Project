using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
// database
using System.Data.SQLite;

namespace CaseStudy
{
    public class Program
    {
        //variables 
        public static List<string> seen = new List<string>(); // create list
        public static List<string> list = new List<string>(); // create list
        public static int lives;
        public static int score = 0;
        public static Random rand = new Random();
        public static string name = "jarne";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Database
            SQLiteConnection sQLiteConnection;
            sQLiteConnection = Database.CreateConnection();
            //Database.DeleteTable(sQLiteConnection);
            Database.CreateTable(sQLiteConnection);
            //starting game
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
            // game logic
            getName();
            // insert and read done at end
            Database.InsertData(sQLiteConnection);
            Database.HighScoreName();
            Database.HighScoreValue();
        }
        public static String generateRandomString()
        {
            foreach (string line in System.IO.File.ReadLines(@"..\..\..\Words.txt"))
            {
                list.Add(line);                 // add every word in list
            }
            String[] str = list.ToArray();           // convert the list to an array.
            rand = new Random();
            int index = rand.Next(str.Length);
            string rnd = str[index];

            return rnd;
        }
        public static int updateScore(int btn)
        {
            if (seen.Contains(generateRandomString())) // if the random word is in the list 'seen'
            { 
                if (btn == 0) // button 0 = seen button
                {
                    return score += 1;
                }
                else // not seen button
                {
                    return score;
                }
            }
            else // if the random word is NOT in the list 'seen'
            {
                if (btn == 1) // button 1 = not seen button
                {
                    seen.Add(generateRandomString());
                    return score += 1;
                }
                else
                {
                    seen.Add(generateRandomString());
                    return score;
                }
            }
        }
        public static int updateLives(int btn)
        {
            if (seen.Contains(generateRandomString()))
            { // if the random word is in the list 'seen'
                if (btn == 0) // button 0 = seen button
                {
                    return lives;
                }
                else
                {
                    return lives -= 1;
                }
            }
            else // if the random word is NOT in the list 'seen'
            {
                if (btn == 1) // button 1 = not seen button
                {
                    seen.Add(generateRandomString());
                    return lives;
                }
                else
                {
                    seen.Add(generateRandomString());
                    return lives -= 1;
                }
            }
        }
        public static string getName()
        {
            name = Form2.instance.name.Trim();
            return name;
        }
    }
}

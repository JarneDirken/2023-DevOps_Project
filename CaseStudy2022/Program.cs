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
            string[] str = new string[] {
            "abstemious", "adjudicate", "adulation", "aesthetic", "aggregate", "alacrity", "alchemy", "amalgamate", "ameliorate", "amortize",
            "anachronism", "anathema", "anomaly", "antecedent", "antipathy", "apathy", "apotheosis", "arbitrary", "arduous", "ascetic",
            "asperity", "assiduous", "atrophy", "augury", "austere", "avarice", "aver", "axiom", "bolster", "bombastic", "brevity",
            "bucolic", "cachet", "cajole", "calumny", "candor", "canonical", "capricious", "castigate", "catalyst", "caustic",
            "censure", "chicanery", "cogent", "complaisance", "conciliatory", "condone", "conflate", "confound", "congruous", "consummate",
            "contemptuous", "contentious", "contrite", "contumacious", "conundrum", "corroborate", "craven", "culpable", "curtail", "cynicism",
            "dearth", "debacle", "decorum", "deference", "deride", "desuetude", "diatribe", "diffidence", "dilate", "disabuse",
            "discordant", "disparage", "dissemble", "divest", "ebullience", "eclectic", "effrontery", "egregious", "elixir", "emollient",
            "empirical", "enervate", "enigma", "ephemeral", "equanimity", "equivocate", "erudite", "evanescent", "evince", "excoriate",
            "exemplar", "exigent", "exonerate", "expiate", "extemporaneous", "extol", "fervor", "fervid", "fickle", "filibuster",
            "flout", "fractious", "gainsay", "gall", "gibe", "grandiose", "gregarious", "guile", "hackneyed", "hapless",
            "harangue", "hegemony", "hyperbole", "impecunious", "imperturbable", "impetuous", "implacable", "impugn", "incontrovertible", "incumbent",
            "indefatigable", "indifferent", "ineffable", "infelicitous", "ingenuous", "inimical", "insidious", "insolvent", "intractable", "intransigence",
            "invective", "irascible", "laconic", "largesse", "lethargy", "lionize", "lucid", "luminous", "magnanimity", "malevolent",
            "malinger", "martial", "mendacious", "mercurial", "mettle", "misanthrope", "mitigate", "multifarious", "nefarious", "negate" };
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

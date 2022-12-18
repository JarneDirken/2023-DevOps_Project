using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
    public class Difficulty
    {
        public string Level { get; set; }
        public int Lives { get; set; }

        public Difficulty(string level, int lives)
        {
            Level = level;
            Lives = lives;
        }

        public class Easy : Difficulty
        {
            public Easy() : base("Easy", 3)
            {
            }
        }

        public class Medium : Difficulty
        {
            public Medium() : base("Medium", 2)
            {
            }
        }

        public class Hard : Difficulty
        {
            public Hard() : base("Hard", 1)
            {
            }
        }
    }
}

namespace Shotgun
{
    public class RobotMillis : Ai
    {
        public RobotMillis()
        {
            Namn = "RobotMillis"; 
            AiFarg = ConsoleColor.Magenta;
            Introduktion = "RobotMillis är busig och har smygit med ett skott till sej själv! ";
            Avslutning = "Hej då, hoppas vi INTE ses igen! ";
            VinstTal = "Jag vann!! jag är bäst, ingen protest!! ";
            ForlustTal = "Du måste ha fuskat... \nUndrar vart jag la det där extraskottet? det kan ju behövas till nästa gång.";
            Skott =   Skott + 1;

            AiBilder = new Dictionary<string, string[]>
            {
                {
                    "start",
                    new string[]
                    {
                             "s(^_^)s    ",
                              " |&|-+    ",
                             "  / \\ "
                    }
                },
                {
                    "ladda",
                    new string[]
                    {
                             "s(^_^)s    ",
                              " |&|    ",
                             "  / \\ "
                    }
                },
                {
                    "blocka",
                    new string[]
                   {
                       "      s(^_^)s  ",
                       "     |>-|&|    ",
                       "        / \\    "
                   }
                },
                {
                    "skjuta",
                    new string[]
                   {
                      " s(*_*)s   ",
                      "  <-|&|    ",
                      "   / \\  "
                   }
                },
                {
                    "shotgun",
                    new string[]
                   {
                      " s(*_*)s   ",
                      "  <-|&|    ",
                      "   / \\  "
                   }
                },
                {
                    "tom",
                    new string[]
                   {
                       "         ",
                       "         ",
                       "         "
                   }
                },
                {
                    "vinna",
                    new string[]
                   {
                      "     s(^_^)s ",
                      "      -|&|-    ",
                      "       / \\  "
                   }
                },
                {
                    "forlora",
                    new string[]
                   {
                       "     ?      ",
                       "  s(*_*)s ",
                       "   _|&|_  "
                   }
                }
            };

            AiValBilder = new Dictionary<string, string[]>
            {
                 {  "ladda", new string[]
                      {
                         "   +  ",
                         "       ",
                         "      "
                       }
                      },
                    { "skjuta", new string[]
                 {
                     "     ",
                     "*  *",
                     "     "
                 }
                    },
                    { "shotgun", new string[]
                   {
                       "*      ",
                       " *  >-",
                       "*      "
                   }
                    },

                    { "blocka", new string[]
                   {
                       "",
                       "",
                       ""
                   }
                    }
                    
            };
        }
    }
}

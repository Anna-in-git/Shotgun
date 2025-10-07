namespace Shotgun
{
    public class RobotRobin : Ai
    {


        public RobotRobin()
        {



            Namn = "RobotRobin";
            AiFarg = ConsoleColor.Cyan;
            Introduktion = "RobotRobin är tuff och börjar utan skott!";
            Avslutning = "Ingen kan stoppa mej! Jag ska ta över hela världen!";
            
            ForlustTal = "Du är verkligen skicklig, men nästa gång står jag som vinnare! \nJag ska gå och smörja mina kugghjul så jag är redo för nästa gång vi möts.";
            VinstTal = "Du hade ingen chans mot en tuff stridsrobot som mej!";
            AiBilder = new Dictionary<string, string[]>
            {
                {
                    "ladda",
                    new string[]
                    {
                             " [o_o]    ",
                              " |#|    ",
                             " /   \\ "
                    }
                },

                {
                    "blocka",
                    new string[]
                   {
                       "       [o_o]   ",
                       "     |>-|#|    ",
                       "       /   \\  "
                   }
                },

                {
                    "skjuta",
                    new string[]
                   {
                       "[o_o]   ",
                       "<-|#|    ",
                       "/   \\  "
                   }
                },
                {
                    "shotgun",
                    new string[]
                   {
                       "[o_o]   ",
                       "<-|#|    ",
                       "/   \\  "
                   }
                },
                {
                    "vinna",
                    new string[]
                   {
                       "      \\[^_^]/   ",
                       "        |#|     ",
                       "       /   \\   "
                   }
                },
                {
                    "forlora",
                    new string[]
                   {
                       "        ?     ",
                       "      [x_x]  ",
                       "      _|#|_  "
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
                     "       ",
                     "-  -  ",
                     "       "
                 }
                    },
                    { "shotgun", new string[]
                   {
                       "-       ",
                       " -  >- ",
                       "-       "
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

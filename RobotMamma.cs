namespace Shotgun
{
    public class RobotMamma : Ai
    {
        public RobotMamma(Spelare spelare)
        {
            Namn = "RobotMamma";
            AiFarg = ConsoleColor.Yellow;
            Introduktion = "RobotMamma är snäll och ger dig ett skott att börja med!";
            Avslutning = "Inte va ledsen nu, det kommer säker gå bättre nästa gång. RobotMamma vet bäst ";
            ForlustTal = "Hur kunde du göra så mot RobotMamma? fy skäms på dej! \nJag går och laddar upp med en ny kaffe!";
            VinstTal = "Ojj, var kaffet lite för varmt för dej, kom så ska jag blåsa.";

            spelare.Skott = spelare.Skott + 1;

            AiBilder = new Dictionary<string, string[]>
            {
                {
                    "ladda",
                    new string[]
                    {
                           ".<(^o^)>.    ",
                           " -|#&|-ù  ",
                           "   /  \\ "
                    }
                },
                {
                    "blocka",
                    new string[]
                   {
                       "     .<(^o^)>. ",
                       "     |>-|#&|    ",
                       "        /  \\  "
                   }
                },
                {
                    "skjuta",
                    new string[]
                   {
                     " .<(^o^)>.   ",
                      "ù-|#&|    ",
                       " /  \\  "
                   }
                },
                {
                    "shotgun",
                    new string[]
                   {
                      ".<(^o^)>.  ",
                      "ù-|#&|    ",
                      "  /  \\  "
                   }
                },
                {
                    "vinna",
                    new string[]
                   {
                     "   .<(^O^)>. ",
                     "    ù-|#&|-   ",
                     "      /  \\  "
                   }
                },
                {
                    "forlora",
                    new string[]
                   {
                     ".    <(ToT)>.   ",
                     "      /|#&|    ",
                     "     ù /  \\  "
                   }
                }
            };

            AiValBilder = new Dictionary<string, string[]>
            {
                {  
                    "ladda", new string[]
                    {
                         "   + ",
                         "      ",
                         "     "
                    }
                },
                { 
                    "skjuta", new string[]
                    {
                     "    ",
                     "~  ~ ",
                     "      "
                    }
                },
                    { "shotgun", new string[]
                   {
                       "~     ",
                       " ~ >~ ",
                       "~     "
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


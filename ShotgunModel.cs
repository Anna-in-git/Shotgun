using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shotgun
{
    public class ShotgunImages //En class med alla ASCII bilder
    {
        public static string[] PlayerWin =
        {
            
            "    \\O/      ",
            "     |       ",
            "    / \\      "
        };

            // ASCII-robot
        public static string[] AiLose = 
        {
            "        [x_x]   ",
            "         |#|    ",
            "        /   \\  "
        };

        
          public static string[] PlayerLoad =
        {
            "      O        ",
            "     /|\\       ",
            "     / \\       "
        };

        public static string[] AiLoad =
        {
            "      [o_o]   ",
            "       |#|   ",
            "      /   \\ "
        };

        public static string[] PlayerShoot =
        {

            "     O        ",
            "    /|->  -  -",
            "    / \\       "
        };

        public static string[] AiShoot =
        { 
              "       [o_o]   ",
              "-  -  <-|#|    ",
              "       /   \\  "
        };
       
        public static string[] PlayerBlock =
        {

            "     O  |     ",
            "    /|-<|     ",
            "    / \\ |     "
        };

        public static string[] AiBlock =
        {
              "     | [o_o]   ",
              "     |>-|#|    ",
              "     | /   \\  "
        };

        public static string[] PlayerLose =
        {

            "     |Ø|       ",
            "      |       ",
            "     | |      "
        };

        // ASCII-robot
        public static string[] AiWin =
        {
            "     \\[^_^]/   ",
            "        |#|     ",
            "       /   \\   "
        };
    }
}

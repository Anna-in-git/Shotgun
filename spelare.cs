using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shotgun
{
    public class spelare
    {
        public string Namn {  get; set; }
        public string Val {  get; set; }
        public int Skott { get; set; }// = 100; om startvärdet skulle vara 100



        public string[] Start =
   {
            "      O        ",
            "     /|\\       ",
            "     / \\       "
        };

        public string[] AiStart =
        {
            "      [o_o]   ",
            "       |#|   ",
            "      /   \\ "
        };
        public string[] Vinnare =
        {

            "    \\O/      ",
            "     |       ",
            "    / \\      "
        };

        // ASCII-robot
        public string[] AiFörlorare =
        {
            "         ?     ",
            "       [x_x]  ",
            "       _|#|_  "
        };


        public string[] Ladda =
        {
            "      O   +    ",
            "     /|\\       ",
            "     / \\       "
        };

        public string[] AiLadda =
        {    
            "   +  [o_o]    ",
            "       |#|    ",
            "      /   \\ "
        };

        public string[] Skjuta =
        {

            "     O        ",
            "    /|->  -  -",
            "    / \\       "
        };

        public string[] SkjutaPers =
        {

            "     O",
            "    /|->",
            "    / \\"
        };

        public string[] SkjutaSkott =
       {

                  "        ",
                  "  -  -",
                    "       "
        };

        public string[] AiSkjuta =
        {
              "       [o_o]   ",
              "-  -  <-|#|    ",
              "       /   \\  "
        };

        public string[] Shotgun =
       {

            "     O       -",
            "    /|->  -<  -",
            "    / \\      -"
        };

        public string[] AiShotgun =
        {
              "-      [o_o]   ",
              "-  >- <-|#|    ",
              "-      /   \\  "
        };

        public string[] Blocka =
        {

            "     O         ",
            "    /|-<|      ",
            "    / \\        "
        };

        public string[] AiBlocka =
        {
              "       [o_o]   ",
              "     |>-|#|    ",
              "       /   \\  "
        };

        public string[] Förlorare =
        {

            "     |Ø|       ",
            "      |       ",
            "     | |      "
        };

        // ASCII-robot
        public string[] AiVinnare =
        {
            "     \\[^_^]/   ",
            "        |#|     ",
            "       /   \\   "
        };
    }
}

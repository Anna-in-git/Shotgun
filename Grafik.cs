using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shotgun
{


    public class Grafik //En class med alla ASCII bilder
    {

        // En metod som skriver ut en scen med 2 arrayer bredvid varandra
        // Lägg till antal skott längst ner i scenen och ev en fördröjning på ai
        public void CreateScene(string[] spelare, string[] ai, int spelareSkott, int aiSkott, ConsoleColor spelareFarg, ConsoleColor aiFarg)
        {


            // Skriv ut titlar
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("");
            Console.WriteLine(" ---------------------------------------");
            Console.ResetColor();
            Console.WriteLine();

            // Skriv ut figurerna rad för rad
            for (int i = 0; i < spelare.Length; i++)
            {
                Console.ForegroundColor = spelareFarg;
                Console.Write("   " + spelare[i] + "    ");
                Console.ForegroundColor = aiFarg;
                Console.WriteLine(ai[i] + " ");
                Console.ResetColor();
            }

            // Skriv ut botten
            Console.WriteLine("  " + spelareSkott + "                                   " + aiSkott);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" _______________________________________");
            Console.ResetColor();
        }


        public string[] Start =
       {
            "      O        ",
            "     /|\\       ",
            "     / \\       "
        };


        public string[] Ladda =
        {
            "      O   +    ",
            "     /|\\       ",
            "     / \\       "
        };


        public string[] Blocka =
     {

            "     O         ",
            "    /|-<|      ",
            "    / \\        "
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


        public string[] Shotgun =
       {

            "     O        -",
            "    /|->  -< - ",
            "    / \\       -"
        };


        public string[] Vinnare =
   {

            "    \\O/      ",
            "     |       ",
            "    / \\      "
        };


        public string[] Förlorare =
        {

            "     |Ø|       ",
            "      |       ",
            "     | |      "
        };


        public string[] AiStart =
       {
            "      [o_o]   ",
            "       |#|   ",
            "      /   \\ "
        };

        public string[] AiLadda =
        {
            "   +  [o_o]    ",
            "       |#|    ",
            "      /   \\ "
        };

        public string[] AiBlocka =
        {
              "       [o_o]   ",
              "     |>-|#|    ",
              "       /   \\  "
        };

        public string[] AiSkjuta =
        {
              "       [o_o]   ",
              "-  -  <-|#|    ",
              "       /   \\  "
        };

        public string[] AiShotgun =
        {
             "-       [o_o]   ",
             " -  >- <-|#|    ",
             "-       /   \\  "
        };

        public string[] AiVinnare =
        {
            "     \\[^_^]/   ",
            "        |#|     ",
            "       /   \\   "
        };

        public string[] AiFörlorare =
        {
            "         ?     ",
            "       [x_x]  ",
            "       _|#|_  "
        };
    }
}

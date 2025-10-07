namespace Shotgun
{
    public class Grafik //En klass med spelarens ASCII bilder och metoder för att visa scener
    {


        public void VisaStartScen(Ai ai, Spelare spelare)
        {
            Console.ForegroundColor = ai.AiFarg;
            Console.WriteLine("     " + ai.Namn + "!");
            Thread.Sleep(1500);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(ai.Introduktion);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("       " + spelare.Namn);
            Console.ResetColor();
            Console.ForegroundColor = ai.AiFarg;
            Console.WriteLine("             " + ai.Namn);
            Console.ResetColor();
            SkapaScen(Start, Tom, ai.AiBilder["ladda"], Tom, spelare.Skott, ai.Skott, ai.AiFarg);
            Console.WriteLine();
            Console.WriteLine("ladda, skjuta, blocka eller shotgun");
            Console.WriteLine();
        }



        // En metod som skriver ut en scen med 4 arrayer bredvid varandra
        public void SkapaScen(string[] spelare, string[] spelareVal, string[] ai, string[] aiVal, int spelareSkott, int aiSkott, ConsoleColor aiFarg)
        {


            // Skriv ut toppen, grå färg
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("");
            Console.WriteLine(" ---------------------------------------");
            Console.ResetColor();
            Console.WriteLine();

            // Skriv ut figurerna och deras val rad för rad i 4 arrayer bredvid varandra, de olika ai spelarna har egen färg och valen är vita
            for (int i = 0; i < spelare.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("   " + spelare[i]);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(spelareVal[i] + "    ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(aiVal[i]);
                Console.ResetColor();
                Console.ForegroundColor = aiFarg;
                Console.WriteLine(ai[i] + " ");
                Console.ResetColor();
            }

            // Skriv ut botten med antal skott, grå färg
            Console.WriteLine("  " + spelareSkott + "                                   " + aiSkott);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(" _______________________________________");
            Console.ResetColor();
        }


        // En metod som visar vinnarscenen beroende på vem som vann
        public void VisaVinnarScen(Ai ai, Spelare spelare, string vinnare)
        {

            if (vinnare == spelare.Namn)
            {
               
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("***************************************");
                Console.WriteLine("         " + spelare.Namn + " ÄR SEGRAREN! ");
                Console.WriteLine("***************************************");
                Console.ResetColor();
                SkapaScen(Vinnare, Tom, ai.AiBilder["forlora"], Tom, spelare.Skott, ai.Skott, ai.AiFarg); //lagt till forlora bild eftersom det inte är ett val
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ai.AiFarg;
                Console.WriteLine(ai.ForlustTal);  // Förlusttalet från aispelaren
                Console.ResetColor();

            }
            else if (vinnare == ai.Namn)
            {
                
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ai.AiFarg;
                Console.WriteLine("***************************************");
                Console.WriteLine("        " + ai.Namn + " ÄR SEGRAREN! ");
                Console.WriteLine("***************************************");
                Console.ResetColor();
                SkapaScen(Förlorare, Tom, ai.AiBilder["vinna"], Tom, spelare.Skott, ai.Skott, ai.AiFarg);
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ai.AiFarg;
                Console.WriteLine(ai.VinstTal);
                Console.ResetColor();
            }
        }


        public string[] Start =
       {
            "      O            ",
            "     /|\\            ",
            "     / \\           "
        };


        public string[] Ladda1 =
        {
            "      O ",
            "     /|\\",
            "     / \\"
        };

        public string[] Ladda2 =
        {
                     "  +   ",
                     "      ",
                     "      "
        };


        public string[] Blocka =
     {

            "     O        ",
            "    /|-<|     ",
            "    / \\       "
        };

        public string[] Skjuta1 =
        {

            "     O",
            "    /|->",
            "    / \\"
        };

        public string[] Skjuta2 =
       {

                  "        ",
                  "  -  -",
                  "       "
        };

        public string[] Shotgun1 =
       {

            "     O",
            "    /|->",
            "    / \\"
        };

        public string[] Shotgun2 =
       {

                  "       -",
                  " -< - ",
                  "      -"
        };


        public string[] Vinnare =
   {

            "     \\O/       ",
            "      |        ",
            "     / \\       "
        };


        public string[] Förlorare =
        {

            "     |Ø|      ",
            "      |       ",
            "     | |      "
        };

        public string[] Tom =
       {
            "",
            "",
            ""
        };

        public string[] AiMamma =
        {
         " .<(^o^)>.    [o_o]     s(*_*)s    ",
         " ú-|#&|       |#|        |&|      ",
         "    /  \\       / \\        / \\   "
        };

     


    }
}

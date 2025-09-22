using Shotgun;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Threading;

internal class Program
{
    private static void Main(string[] args)
    {
        string vinnare = "";
        bool spela = true;
        string fortsatt = "";


        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║           VÄLKOMMEN TILL             ║");
        Console.WriteLine("║            S H O T G U N             ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.ResetColor();


        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine("En mörk kväll möter du den legendariska stridsroboten RobotRobin.");
        Console.WriteLine("Han har besegrat otaliga motståndare och väntar nu på DIG!");
        Console.WriteLine("Det enda vapnet ni har är... era skott och list.");
        Console.WriteLine();

       

        Console.WriteLine("Regler:");

        Console.WriteLine("* Ladda  = +1 skott");
        Console.WriteLine("* Skjuta = -1 skott)");
        Console.WriteLine("* Blocka = Skyddar mot skott");
        Console.WriteLine("* Shotgun = Om du har 3 skott, kan du vinna direkt!");
        Console.WriteLine();
        Console.WriteLine("Tips: RobotRobin är slug, blockar när han anar fara och väntar på rätt läge...");
        Console.WriteLine();
        Console.ResetColor();

        Console.WriteLine();
        spelare spelare = new spelare();
        spelare ai = new spelare();
        for (int i = 0; i < spelare.SkjutaPers.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(spelare.SkjutaPers[i]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(spelare.SkjutaSkott[i]);
            Console.ResetColor();
        }
        Console.WriteLine();


        Console.Write("Skriv in ditt användarnamn: ");
        spelare.Namn = Console.ReadLine();
        ai.Namn = "RobotRobin";
        Console.WriteLine();
        Console.WriteLine("       " + spelare.Namn + "                " + ai.Namn);
        CreateScene(spelare.Start, ai.AiStart, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);
        Console.WriteLine();
        Console.WriteLine("ladda, skjuta, blocka eller shotgun");


        /*   SHOTGUN
        -------------------------------------------------------
        
        2 Användare:     Person    och    Datorn (slumpmässiga val)
        
        Val: Skjuta, Ladda och Blocka       (olika scenarion)

        If{
        Ladda mot ladda - Båda spelarna får ett skott
        Ladda mot blocka - Spelaren som laddar får ett skott
        Blocka mot blocka - Ingenting händer
        Skjuta mot blocka - Spelaren som skjuter förlorar ett skott
        Skjuta mot skjuta - Båda spelarna förlorar ett skott
        Skjuta mot ladda - Spelaren som skjuter vinner spelet
        Shotgun mot shotgun - Se "Skjuta mot skjuta" eller slumpmässig vinnare
        }

        Skott: man börjar med 0, laddar ++, if 3 skott = shotgun
        



        */


        // Skapa en användare, ska ha namn, skott och val.



        while (spela)
        {

            Console.WriteLine("Vad väljer du? ");
            Console.WriteLine();
            spelare.Val = GiltigtVal(spelare.Skott);
            // Ai får välja, lägg in if sats för att göra smartare
            Console.Write(ai.Namn + " väljer...        ");
            Thread.Sleep(1500);
            ai.Val = RandomVal(ai.Skott, spelare.Skott);
            Console.WriteLine(ai.Val);

            /*
           while (spelare.Val == "skjuta" && spelareSkott <= 0)
           {
              Console.WriteLine("Du har inga skott, välj ladda eller blocka.");
              spelareVal = Console.ReadLine();
           }
          while (spelareVal == "shotgun" && spelareSkott < 3)
          {
              Console.WriteLine("Du måste ha minst 3 skott för att använda SHOTGUN! välj igen.");
              spelareVal = Console.ReadLine();
          }*/


            /*
                else if (aiChoice == "skjuta" && aiShot <= 0)
                {
                aiChoice = "";
                aiChoice = RandomChoice();
                }*/




            if (spelare.Val == "ladda" && ai.Val == "ladda")
            {   //båda får ett skott
                spelare.Skott = spelare.Skott + 1;
                ai.Skott = ai.Skott + 1;
                CreateScene(spelare.Ladda, ai.AiLadda, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);

            }
            else if (spelare.Val == "ladda" && ai.Val == "skjuta")
            {   //ai vinner
                spelare.Skott = spelare.Skott + 1;
                ai.Skott = ai.Skott - 1;
                CreateScene(spelare.Ladda, ai.AiSkjuta, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);
                vinnare = ai.Namn;
                spela = false; //Spelet avslutas
            }
            else if (spelare.Val == "ladda" && ai.Val == "blocka")
            {   //user får ett skott
                spelare.Skott = spelare.Skott + 1;
                CreateScene(spelare.Ladda, ai.AiBlocka, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);
            }
            else if (spelare.Val == "skjuta" && ai.Val == "ladda")
            {   //user vinner
                spelare.Skott = spelare.Skott - 1;
                ai.Skott = +1;
                CreateScene(spelare.Skjuta, ai.AiLadda, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);
                vinnare = spelare.Namn;
                spela = false;
            }
            else if (spelare.Val == "skjuta" && ai.Val == "skjuta")
            {   //båda förlorar ett skott
                spelare.Skott = spelare.Skott - 1;
                ai.Skott = ai.Skott - 1;
                CreateScene(spelare.Skjuta, ai.AiSkjuta, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);

            }
            else if (spelare.Val == "skjuta" && ai.Val == "blocka")
            {   //user -1 skott
                spelare.Skott = spelare.Skott - 1;
                CreateScene(spelare.Skjuta, ai.AiBlocka, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);

            }
            else if (spelare.Val == "blocka" && ai.Val == "ladda")
            {   //ai +1 skott
                ai.Skott = ai.Skott + 1;
                CreateScene(spelare.Blocka, ai.AiLadda, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);

            }
            else if (spelare.Val == "blocka" && ai.Val == "skjuta")
            {   //ai -1 skott
                ai.Skott = ai.Skott - 1;
                CreateScene(spelare.Blocka, ai.AiSkjuta, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);

            }
            else if (spelare.Val == "blocka" && ai.Val == "blocka")
            {   //inget händer
                CreateScene(spelare.Blocka, ai.AiBlocka, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);

            }
            else if (spelare.Val == "shotgun" && ai.Val == "skjuta")
            {   //user vinner
                spelare.Skott = spelare.Skott - 3;
                ai.Skott = ai.Skott - 1;
                CreateScene(spelare.Shotgun, ai.AiSkjuta, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);
                vinnare = spelare.Namn;
                spela = false;

            }
            else if (spelare.Val == "shotgun" && ai.Val == "ladda")
            {   //user vinner
                spelare.Skott = spelare.Skott - 3;
                ai.Skott = ai.Skott + 1;
                CreateScene(spelare.Shotgun, ai.AiLadda, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);
                vinnare = spelare.Namn;
                spela = false;

            }
            else if (spelare.Val == "shotgun" && ai.Val == "blocka")
            {   //user vinner
                spelare.Skott = spelare.Skott - 3;
                CreateScene(spelare.Shotgun, ai.AiBlocka, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);
                vinnare = spelare.Namn;
                spela = false;

            }
            else if (spelare.Val == "skjuta" && ai.Val == "shotgun")
            {   //ai vinner
                spelare.Skott = spelare.Skott - 1;
                ai.Skott = ai.Skott - 3;
                CreateScene(spelare.Skjuta, ai.AiShotgun, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);
                vinnare = ai.Namn;
                spela = false;

            }
            else if (spelare.Val == "blocka" && ai.Val == "shotgun")
            {   //ai vinner
                ai.Skott = ai.Skott - 3;
                CreateScene(spelare.Blocka, ai.AiShotgun, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);
                vinnare = ai.Namn;
                spela = false;

            }
            else if (spelare.Val == "ladda" && ai.Val == "shotgun")
            {   //ai vinner
                spelare.Skott = spelare.Skott + 1;
                ai.Skott = ai.Skott - 3;
                CreateScene(spelare.Ladda, ai.AiShotgun, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);
                vinnare = ai.Namn;
                spela = false;

            }
            else if (spelare.Val == "shotgun" && ai.Val == "shotgun")
            {   //slumpmässig vinnare eller båda förlorar skott
                spelare.Skott = spelare.Skott - 3;
                ai.Skott = ai.Skott - 3;
                CreateScene(spelare.Shotgun, ai.AiShotgun, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);
            }
            else
            {
                Console.WriteLine("ladda, skjuta, blocka eller shotgun?");
            }


            //Måste definiera vad valen innebär och göra radom funktion till ai
            //if win??
            //Lägg rätt bild i rätt if
            if (spela == false)
            {
                //fixa för att avsluta eller fortsätta spel + fördröjning
                if (vinnare == spelare.Namn)
                {
                    Console.WriteLine();
                    Console.WriteLine("          " + spelare.Namn + " ÄR VINNAREN! ");
                    CreateScene(spelare.Vinnare, ai.AiFörlorare, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);

                }
                else if (vinnare == ai.Namn)
                {
                    Console.WriteLine();
                    Console.WriteLine("          " + ai.Namn + " ÄR VINNAREN!");
                    CreateScene(spelare.Förlorare, ai.AiVinnare, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);

                }

                Console.Write("Vill du fortsätta spela? (J/N)");
                fortsatt = Console.ReadLine().ToUpper();
                Console.WriteLine();

                while (fortsatt != "J" && fortsatt != "N")
                {


                    if (fortsatt == "J")
                    {
                        Console.WriteLine();
                        spela = true;
                        spelare.Skott = 0;
                        ai.Skott = 0;
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\"Bra... jag visste att du hade mer mod i dig.\" 🤖");
                        Console.ResetColor();
                        Console.WriteLine("RobotRobin laddar om sina kretsar och ställer sig redo igen!");
                        Console.WriteLine();
                        Console.WriteLine("        " + spelare.Namn + "               " + ai.Namn);
                        CreateScene(spelare.Ladda, ai.AiLadda, spelare.Skott, ai.Skott, ConsoleColor.Cyan, ConsoleColor.Yellow);
                        Console.WriteLine();
                        Console.WriteLine("ladda, skjuta, blocka eller shotgun");
                        // Nollställ spelare och ai
                    }
                    else if (fortsatt == "N")
                    {
                        if (vinnare == spelare.Namn)
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Du lämnar arenan som segrare. RobotRobin gnisslar sina kugghjul i ilska...");
                            Console.ResetColor();
                            Console.WriteLine("\"Detta är inte över... nästa gång kommer jag krossa dig!\" 🤖");
                        }
                        else if (vinnare == ai.Namn)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Du faller till marken, besegrad av RobotRobin.");
                            Console.ResetColor();
                            Console.WriteLine("\"Mwahaha! Jag visste att du inte hade en chans mot mig!\" 🤖");
                            Console.WriteLine("Han går därifrån och lämnar dig i dammet...");
                        }
                    }
                    else
                    {
                        Console.WriteLine("J eller N ?");
                        fortsatt = Console.ReadLine().ToUpper();
                    }
                }
            }

            // ctrl+ K + D Räta upp allt, ctrl + k + c Kommentera ut och ctrl + k + u för att kommentera upp


        }












    }


    public static string GiltigtVal(int skott) //tar in värdet från skott
    {
        //metod för att giltigt val ska skickas tillbaka

        string val = ""; //en string som bara finns i metoden
        bool giltig = false;



        while (giltig == false)
        {
            val = Console.ReadLine().ToLower();
            //ladda, skjuta, blocka, shotgun ska bli rätt
            if (val == "ladda" || val == "blocka")
            {
                giltig = true;
            }
            else if (val == "skjuta" && skott <= 0)
            {
                Console.WriteLine("Du har inga skott, välj ladda eller blocka: ");
            }
            else if (val == "skjuta" && skott > 0)
            {
                giltig = true;
            }
            else if (val == "shotgun" && skott < 3)
            {
                Console.WriteLine("Du behöver 3 skott för shotgun, välj igen: ");
            }
            else if (val == "shotgun" && skott >= 3)
            {
                giltig = true;
            }
            else
            {
                Console.WriteLine("ladda, skjuta, blocka eller shotgun? ");
            }

        }
        return val;
    }




    //En randomfunktion som kan användas överallt
    public static Random random = new Random();

    //Metod som väljer bland de olika valen med randomnr som läses av i arrayen
    public static string RandomVal(int aiSkott, int spelareSkott)
    {



        string aiVal = "";
        bool giltig = false;



        while (giltig == false)
        {
            string[] ai = { "skjuta", "ladda", "blocka", "shotgun" };
            int i = random.Next(ai.Length);
            aiVal = ai[i];

            //ladda, skjuta, blocka, shotgun ska bli rätt
            if (aiVal == "ladda" && aiSkott <= 2)  //ai ska inte blocka om spelare har 0 Skott
            {
                giltig = true;

            }
            else if (aiVal == "blocka" && spelareSkott > 0 && aiSkott <= 2)
            {
                giltig = true;
            }
            else if (aiVal == "blocka" && spelareSkott == 0)
            {

            }
            else if (aiVal == "skjuta" && aiSkott <= 0)
            {

            }
            else if (aiVal == "skjuta" && aiSkott > 0 && aiSkott <= 2)
            {
                giltig = true;

            }
            else if (aiVal == "shotgun" && aiSkott < 3)
            {

            }
            else if (aiVal == "shotgun" && aiSkott >= 3)
            {
                giltig = true;

            }

        }
        return aiVal;
    }


    // En metod som skriver ut en scen med 2 arrayer bredvid varandra
    // Lägg till antal skott längst ner i scenen och ev en fördröjning på ai
    public static void CreateScene(string[] spelare, string[] ai, int spelareSkott, int aiSkott, ConsoleColor spelareFarg, ConsoleColor aiFarg)
    {


        // Skriv ut titlar
        Console.ForegroundColor = ConsoleColor.DarkBlue;
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
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(" _______________________________________");
        Console.ResetColor();
    }



}
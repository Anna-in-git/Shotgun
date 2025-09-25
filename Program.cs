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

        Console.WriteLine("* Ladda  = + 1 skott");
        Console.WriteLine("* Skjuta = Du måste ha skott och kan vinna om motståndaren blockar eller laddar)");
        Console.WriteLine("* Blocka = Skyddar mot skott");
        Console.WriteLine("* Shotgun = Om du har 3 skott, kan du vinna direkt!");
        Console.WriteLine();
        Console.WriteLine("RobotRobin är slug, blockar när han anar fara och väntar på rätt läge...");
        Console.WriteLine();
        Console.ResetColor();

        Console.WriteLine();
        Spelare spelare = new Spelare();
        Ai ai = new Ai(); 
        Grafik grafik = new Grafik();


        for (int i = 0; i < grafik.SkjutaPers.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(grafik.SkjutaPers[i]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(grafik.SkjutaSkott[i]);
            Console.ResetColor();
        }
        Console.WriteLine();


        Console.Write("Skriv in ditt användarnamn: ");
        spelare.Namn = Console.ReadLine();
        ai.Namn = "RobotRobin";
        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("       " + spelare.Namn );
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("               " + ai.Namn);
        Console.ResetColor();
        grafik.CreateScene(grafik.Start, grafik.AiStart, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);
        Console.WriteLine();
        Console.WriteLine("ladda, skjuta, blocka eller shotgun");
        Console.WriteLine();


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
            //Spelaren får välja drag
            Console.WriteLine("Vad väljer du? ");
            Console.WriteLine();
            spelare.Val = spelare.GiltigtVal(spelare.Skott); //skickar in spelarens skott för att validera spelarens val
            // Ai får välja
            Console.Write(ai.Namn + " väljer...       ");
            Thread.Sleep(1500); //fördröjning för att skapa spänning
            ai.Val = ai.RandomVal(spelare.Skott); //skickar in spelarens skott för att ai ska kunna anpassa sitt val
            Console.WriteLine(ai.Val);



            if (spelare.Val == "ladda" && ai.Val == "ladda")
            {   //båda får ett skott
                spelare.Skott = spelare.Skott + 1;
                ai.Skott = ai.Skott + 1;
                grafik.CreateScene(grafik.Ladda, grafik.AiLadda, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);

            }
            else if (spelare.Val == "ladda" && ai.Val == "skjuta")
            {   //ai vinner
                spelare.Skott = spelare.Skott + 1;
                ai.Skott = ai.Skott - 1;
                grafik.CreateScene(grafik.Ladda, grafik.AiSkjuta, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);
                vinnare = ai.Namn;
                spela = false; //Spelet avslutas
            }
            else if (spelare.Val == "ladda" && ai.Val == "blocka")
            {   //user får ett skott
                spelare.Skott = spelare.Skott + 1;
                grafik.CreateScene(grafik.Ladda, grafik.AiBlocka, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);
            }
            else if (spelare.Val == "skjuta" && ai.Val == "ladda")
            {   //user vinner
                spelare.Skott = spelare.Skott - 1;
                ai.Skott = +1;
                grafik.CreateScene(grafik.Skjuta, grafik.AiLadda, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);
                vinnare = spelare.Namn;
                spela = false;
            }
            else if (spelare.Val == "skjuta" && ai.Val == "skjuta")
            {   //båda förlorar ett skott
                spelare.Skott = spelare.Skott - 1;
                ai.Skott = ai.Skott - 1;
                grafik.CreateScene(grafik.Skjuta, grafik.AiSkjuta, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);

            }
            else if (spelare.Val == "skjuta" && ai.Val == "blocka")
            {   //user -1 skott
                spelare.Skott = spelare.Skott - 1;
                grafik.CreateScene(grafik.Skjuta, grafik.AiBlocka, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);

            }
            else if (spelare.Val == "blocka" && ai.Val == "ladda")
            {   //ai +1 skott
                ai.Skott = ai.Skott + 1;
                grafik.CreateScene(grafik.Blocka, grafik.AiLadda, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);

            }
            else if (spelare.Val == "blocka" && ai.Val == "skjuta")
            {   //ai -1 skott
                ai.Skott = ai.Skott - 1;
                grafik.CreateScene(grafik.Blocka, grafik.AiSkjuta, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);

            }
            else if (spelare.Val == "blocka" && ai.Val == "blocka")
            {   //inget händer
                grafik.CreateScene(grafik.Blocka, grafik.AiBlocka, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);

            }
            else if (spelare.Val == "shotgun" && ai.Val == "skjuta")
            {   //user vinner
                spelare.Skott = spelare.Skott - 3;
                ai.Skott = ai.Skott - 1;
                grafik.CreateScene(grafik.Shotgun, grafik.AiSkjuta, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);
                vinnare = spelare.Namn;
                spela = false;

            }
            else if (spelare.Val == "shotgun" && ai.Val == "ladda")
            {   //user vinner
                spelare.Skott = spelare.Skott - 3;
                ai.Skott = ai.Skott + 1;
                grafik.CreateScene(grafik.Shotgun, grafik.AiLadda, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);
                vinnare = spelare.Namn;
                spela = false;

            }
            else if (spelare.Val == "shotgun" && ai.Val == "blocka")
            {   //user vinner
                spelare.Skott = spelare.Skott - 3;
                grafik.CreateScene(grafik.Shotgun, grafik.AiBlocka, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);
                vinnare = spelare.Namn;
                spela = false;

            }
            else if (spelare.Val == "skjuta" && ai.Val == "shotgun")
            {   //ai vinner
                spelare.Skott = spelare.Skott - 1;
                ai.Skott = ai.Skott - 3;
                grafik.CreateScene(grafik.Skjuta, grafik.AiShotgun, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);
                vinnare = ai.Namn;
                spela = false;

            }
            else if (spelare.Val == "blocka" && ai.Val == "shotgun")
            {   //ai vinner
                ai.Skott = ai.Skott - 3;
                grafik.CreateScene(grafik.Blocka, grafik.AiShotgun, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);
                vinnare = ai.Namn;
                spela = false;

            }
            else if (spelare.Val == "ladda" && ai.Val == "shotgun")
            {   //ai vinner
                spelare.Skott = spelare.Skott + 1;
                ai.Skott = ai.Skott - 3;
                grafik.CreateScene(grafik.Ladda, grafik.AiShotgun, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);
                vinnare = ai.Namn;
                spela = false;

            }
            else if (spelare.Val == "shotgun" && ai.Val == "shotgun")
            {   //slumpmässig vinnare eller båda förlorar skott
                spelare.Skott = spelare.Skott - 3;
                ai.Skott = ai.Skott - 3;
                grafik.CreateScene(grafik.Shotgun, grafik.AiShotgun, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);
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
                    Thread.Sleep(1500);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("***************************************");
                    Console.WriteLine("         " + spelare.Namn + " ÄR SEGRAREN! ");
                    Console.WriteLine("***************************************");
                    Console.ResetColor();
                    grafik.CreateScene(grafik.Vinnare, grafik.AiFörlorare, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);

                }
                else if (vinnare == ai.Namn)
                {
                    Thread.Sleep(1500);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("***************************************");
                    Console.WriteLine("        " + ai.Namn + " ÄR SEGRAREN! ");
                    Console.WriteLine("***************************************");
                    Console.ResetColor();
                    grafik.CreateScene(grafik.Förlorare, grafik.AiVinnare, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);

                }
                Console.WriteLine();
                Console.Write("Vill du fortsätta spela? (J/N)");
                fortsatt = Console.ReadLine().ToUpper();
                Console.WriteLine();
                bool fortsattSpela = false;

                while (fortsattSpela == false)
                {


                    if (fortsatt == "J")
                    {
                        Console.WriteLine();
                        spela = true;
                        spelare.Skott = 0;
                        ai.Skott = 0;
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\"Bra... jag visste att du hade mer mod i dig.\" 🤖");
                        Console.ResetColor();
                        Console.WriteLine("RobotRobin laddar om sina kretsar och ställer sig redo igen!");
                        Thread.Sleep(2000);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("        " + spelare.Namn + "               " + ai.Namn);
                        grafik.CreateScene(grafik.Ladda, grafik.AiLadda, spelare.Skott, ai.Skott, ConsoleColor.Green, ConsoleColor.DarkCyan);
                        Console.WriteLine();
                        Console.WriteLine("ladda, skjuta, blocka eller shotgun");
                        // Nollställ spelare och ai
                        fortsattSpela = true;
                    }
                    else if (fortsatt == "N")
                    {
                        if (vinnare == spelare.Namn)
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Du lämnar arenan som segrare. RobotRobin gnisslar sina kugghjul i ilska...");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\"Detta är inte över... nästa gång kommer jag krossa dig!\" 🤖");
                            Console.ResetColor();
                            fortsattSpela = true;
                        }
                        else if (vinnare == ai.Namn)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Du faller till marken, besegrad av RobotRobin.");
                            Console.WriteLine("\"Mwahaha! Jag visste att du inte hade en chans mot mig!\" 🤖");
                            Console.WriteLine("Han går därifrån och lämnar dig i dammet...");
                            Console.ResetColor();
                            fortsattSpela = true;
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
   


}
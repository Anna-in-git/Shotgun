using Shotgun;

public class Program
{
    private static void Main(string[] args)
    {
        string vinnare = "";
        bool spela = true;
        string fortsatt = "";
        //Instansierar mina klasser
        Spelare spelare = new Spelare();
        Grafik grafik = new Grafik();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║           VÄLKOMMEN TILL             ║");
        Console.WriteLine("║            S H O T G U N             ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.ResetColor();


        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("En mörk kväll träffar du på den legendariska robotfamiljen...");
        Thread.Sleep(1500);
        Console.WriteLine();
        Console.WriteLine("De har besegrat otaliga motståndare och väntar nu på dej.");
        Thread.Sleep(1500);
        Console.WriteLine();
        Console.WriteLine("För att besegra dom krävs det list, mod och ett laddat vapen.");
        Thread.Sleep(1500);
        Console.WriteLine();
        
        Thread.Sleep(1500);
        Console.ResetColor();
        Console.WriteLine();
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine();

        for (int i = 0; i < grafik.AiMamma.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(grafik.Start[i]);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(grafik.AiMamma[i]);
            Console.ResetColor();
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Regler:");
        Console.WriteLine();
        Console.WriteLine("Ni turas om att välja era drag, ska du ladda, skjuta, blocka eller spara till ett mäktigt SHOTGUN?");
        Console.WriteLine();
        Console.WriteLine("* Ladda  = + 1 skott");
        Console.WriteLine("* Skjuta = Du måste ha skott och vinner om motståndaren blockar eller laddar.");
        Console.WriteLine("* Blocka = Skyddar mot skott.");
        Console.WriteLine("* Shotgun = Om du har 3 skott, kan du vinna direkt!");
        Console.WriteLine();
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Dina Motståndare är sluga, blockar när de anar fara och väntar på rätt läge...");
        Console.WriteLine();
        Console.WriteLine();
        



        //Spelaren får välja namn, det ska vara mellan 1-10 tecken och inte samma som ai
        spelare.ValjNamn();
        Console.WriteLine();
        Console.WriteLine("Ok " + spelare.Namn + " , då ska vi se vem som vågar möta dej...");
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Det vart...");
        Thread.Sleep(1700);

         

        
       
        Ai ai = new Ai().SkapaAiSpelaren(spelare); // skapar en ai spelare med hjälp av metod i Ai klassen

        grafik.VisaStartScen(ai, spelare); // Visar startscenen med rätt ai och spelare





        while (spela)
        {
            
           


            

            //Spelaren får välja drag
            Console.WriteLine("Vad väljer du? ");
            Console.WriteLine();
            spelare.Val = spelare.GiltigtVal(spelare.Skott); //skickar in spelarens skott för att validera spelarens val
            // Ai får välja
            Console.Write(ai.Namn + " väljer...      ");
            Thread.Sleep(1500); //fördröjning för att skapa spänning
            ai.Val = ai.RandomVal(spelare.Skott); //skickar in spelarens skott för att ai ska kunna anpassa sitt val
            Console.WriteLine(ai.Val);
            string[] aiBild = ai.AiBilder[ai.Val]; //hämtar rätt aibild från dictionaryn
            string[] aiBildval = ai.AiValBilder[ai.Val]; //hämtar rätt bild för ai spelarens val från dictionaryn
            


            if (spelare.Val == "ladda" && ai.Val == "ladda")
            {   //båda får ett skott
                spelare.Skott = spelare.Skott + 1;
                ai.Skott = ai.Skott + 1;
                grafik.SkapaScen(grafik.Ladda1, grafik.Ladda2, aiBild, aiBildval, spelare.Skott, ai.Skott, ai.AiFarg);

            }
            else if (spelare.Val == "ladda" && ai.Val == "skjuta")
            {   //ai vinner
                spelare.Skott = spelare.Skott + 1;
                ai.Skott = ai.Skott - 1;
                grafik.SkapaScen(grafik.Ladda1, grafik.Ladda2, aiBild, aiBildval, spelare.Skott, ai.Skott, ai.AiFarg);
                vinnare = ai.Namn;
                spela = false; //Spelet avslutas
            }
            else if (spelare.Val == "ladda" && ai.Val == "blocka")
            {   //user får ett skott
                spelare.Skott = spelare.Skott + 1;
                grafik.SkapaScen(grafik.Ladda1, grafik.Ladda2, aiBild, aiBildval, spelare.Skott, ai.Skott, ai.AiFarg);
            }
            else if (spelare.Val == "skjuta" && ai.Val == "ladda")
            {   //user vinner
                spelare.Skott = spelare.Skott - 1;
                ai.Skott = ai.Skott + 1;
                grafik.SkapaScen(grafik.Skjuta1, grafik.Skjuta2, aiBild, aiBildval, spelare.Skott, ai.Skott, ai.AiFarg);
                vinnare = spelare.Namn;
                spela = false;
            }
            else if (spelare.Val == "skjuta" && ai.Val == "skjuta")
            {   //båda förlorar ett skott
                spelare.Skott = spelare.Skott - 1;
                ai.Skott = ai.Skott - 1;
                grafik.SkapaScen(grafik.Skjuta1, grafik.Skjuta2, aiBild, aiBildval, spelare.Skott, ai.Skott, ai.AiFarg);

            }
            else if (spelare.Val == "skjuta" && ai.Val == "blocka")
            {   //user -1 skott
                spelare.Skott = spelare.Skott - 1;
                grafik.SkapaScen(grafik.Skjuta1, grafik.Skjuta2, aiBild, aiBildval, spelare.Skott, ai.Skott, ai.AiFarg);

            }
            else if (spelare.Val == "blocka" && ai.Val == "ladda")
            {   //ai +1 skott
                ai.Skott = ai.Skott + 1;
                grafik.SkapaScen(grafik.Blocka, grafik.Tom, aiBild, aiBildval, spelare.Skott, ai.Skott, ai.AiFarg);

            }
            else if (spelare.Val == "blocka" && ai.Val == "skjuta")
            {   //ai -1 skott
                ai.Skott = ai.Skott - 1;
                grafik.SkapaScen(grafik.Blocka, grafik.Tom, aiBild, aiBildval, spelare.Skott, ai.Skott, ai.AiFarg);

            }
            else if (spelare.Val == "blocka" && ai.Val == "blocka")
            {   //inget händer
                grafik.SkapaScen(grafik.Blocka, grafik.Tom, aiBild, aiBildval, spelare.Skott, ai.Skott, ai.AiFarg);

            }
            else if (spelare.Val == "shotgun" && ai.Val == "skjuta")
            {   //user vinner
                spelare.Skott = spelare.Skott - 3;
                ai.Skott = ai.Skott - 1;
                grafik.SkapaScen(grafik.Shotgun1, grafik.Shotgun2, aiBild, aiBildval, spelare.Skott, ai.Skott, ai.AiFarg);
                vinnare = spelare.Namn;
                spela = false;

            }
            else if (spelare.Val == "shotgun" && ai.Val == "ladda")
            {   //user vinner
                spelare.Skott = spelare.Skott - 3;
                ai.Skott = ai.Skott + 1;
                grafik.SkapaScen(grafik.Shotgun1, grafik.Shotgun2, aiBild, aiBildval, spelare.Skott, ai.Skott, ai.AiFarg);
                vinnare = spelare.Namn;
                spela = false;

            }
            else if (spelare.Val == "shotgun" && ai.Val == "blocka")
            {   //user vinner
                spelare.Skott = spelare.Skott - 3;
                grafik.SkapaScen(grafik.Shotgun1, grafik.Shotgun2, aiBild, aiBildval, spelare.Skott, ai.Skott, ai.AiFarg);
                vinnare = spelare.Namn;
                spela = false;

            }
            else if (spelare.Val == "skjuta" && ai.Val == "shotgun")
            {   //ai vinner
                spelare.Skott = spelare.Skott - 1;
                ai.Skott = ai.Skott - 3;
                grafik.SkapaScen(grafik.Skjuta1, grafik.Skjuta2, aiBild, aiBildval, spelare.Skott, ai.Skott, ai.AiFarg);
                vinnare = ai.Namn;
                spela = false;

            }
            else if (spelare.Val == "blocka" && ai.Val == "shotgun")
            {   //ai vinner
                ai.Skott = ai.Skott - 3;
                grafik.SkapaScen(grafik.Blocka, grafik.Tom, aiBild, aiBildval, spelare.Skott, ai.Skott, ai.AiFarg);
                vinnare = ai.Namn;
                spela = false;

            }
            else if (spelare.Val == "ladda" && ai.Val == "shotgun")
            {   //ai vinner
                spelare.Skott = spelare.Skott + 1;
                ai.Skott = ai.Skott - 3;
                grafik.SkapaScen(grafik.Ladda1, grafik.Ladda2, aiBild, aiBildval, spelare.Skott, ai.Skott, ai.AiFarg);
                vinnare = ai.Namn;
                spela = false;

            }
            else if (spelare.Val == "shotgun" && ai.Val == "shotgun")
            {   //slumpmässig vinnare eller båda förlorar skott
                spelare.Skott = spelare.Skott - 3;
                ai.Skott = ai.Skott - 3;
                grafik.SkapaScen(grafik.Shotgun1, grafik.Shotgun2, aiBild, aiBildval, spelare.Skott, ai.Skott, ai.AiFarg);
            }
            else
            {
                Console.WriteLine("ladda, skjuta, blocka eller shotgun?");

            }


            // Om någon vunnit så visas vinnarscenen och valet att fortsätta eller avsluta

            if (spela == false)
            {
                Thread.Sleep(2000);
                grafik.VisaVinnarScen(ai, spelare, vinnare); // Visar vinnarscenen med rätt ai och spelare

                Console.WriteLine();
              

                    
                Thread.Sleep(1500);
                
                Console.WriteLine();
                Console.Write("Vill du spela en gång till? (J/N)");
                fortsatt = Console.ReadLine().ToUpper();
                Console.WriteLine();

                spelare.Skott = 0; // Nollställer skott för ett nytt spel

                bool fortsattSpela = false;

                while (fortsattSpela == false) // Loop för att hantera spelarens val att fortsätta eller avsluta
                {

                    if (fortsatt == "J")
                    {
                        spela = true;

                        Console.WriteLine();
                        Console.WriteLine("Du kör vi!");
                        Console.WriteLine();
                        Console.WriteLine(spelare.Namn + " Då ska vi se vem som vågar möta dej nu...");
                        Console.WriteLine();
                        Thread.Sleep(2000);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Det vart...");
                        Thread.Sleep(1700);


                        ai = new Ai().SkapaAiSpelaren(spelare); // Skapar en ny ai spelare till det nya spelet

                        grafik.VisaStartScen(ai, spelare); // Visar startscenen med rätt ai och spelare

                        fortsattSpela = true;
                    }
                    else if (fortsatt == "N")
                    {
                        if (vinnare == spelare.Namn)
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Du lämnar arenan som segrare.."); //Avslutningsfras aiForlorare
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Förloraren gnisslar sina kugghjul i ilska..");
                            Console.ResetColor();

                            fortsattSpela = true;
                        }
                        else if (vinnare == ai.Namn)
                        {   
                            
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Du faller till marken, besegrad av " + ai.Namn);
                            Console.ResetColor();
                            Console.ForegroundColor = ai.AiFarg;
                            Console.WriteLine(ai.Avslutning); //Avslutningsfras aiVinnare
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ai.Namn + " går därifrån och lämnar dig i dammet..."); //AvslutningsTal aiVinnare
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
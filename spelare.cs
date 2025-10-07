namespace Shotgun
{
    public class Spelare
    {
        public string Namn { get; set; }
        public string Val { get; set; }
        public int Skott { get; set; }

        //metod för att giltigt val ska skickas tillbaka
        public string GiltigtVal(int skott) //tar in värdet från skott
        {

            string val = "";
            bool giltig = false;



            while (giltig == false)
            {
                val = Console.ReadLine().ToLower();
                
                if (val == "ladda" || val == "blocka")
                {
                    giltig = true;
                }
                else if (val == "skjuta" && skott <= 0)
                {
                    Console.WriteLine("Du har inga skott, välj ladda eller blocka: ");
                    Console.WriteLine();
                }
                else if (val == "skjuta" && skott > 0)
                {
                    giltig = true;
                }
                else if (val == "shotgun" && skott < 3)
                {
                    Console.WriteLine("Du behöver 3 skott för shotgun, välj igen: ");
                    Console.WriteLine();
                }
                else if (val == "shotgun" && skott >= 3)
                {
                    giltig = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ladda, skjuta, blocka eller shotgun? ");
                    Console.WriteLine();

                }

            }
            return val;
        }


        //metod för att välja namn, 2 försök, annars blir det Blipp
        public void ValjNamn()
        {   

            Console.Write("Skriv in ditt användarnamn, max 10 tecken: ");
            Namn = Console.ReadLine();

           
            if (Namn.Length > 10 || string.IsNullOrWhiteSpace(Namn))
            {
                Console.WriteLine("Namnet är för långt, max 10 tecken. Försök igen.");
                Console.Write("Skriv in ditt användarnamn: ");
                Namn = Console.ReadLine();
            }

            if (Namn.Length > 10 || string.IsNullOrWhiteSpace(Namn))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nej men då får du heta Blipp.");
                Console.ResetColor();
                Namn = "Blipp";
            }
        }
    }
}

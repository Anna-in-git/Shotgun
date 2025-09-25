using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shotgun
{
    public class Spelare
    {
        public string Namn {  get; set; }
        public string Val {  get; set; }
        public int Skott { get; set; }// = 100; om startvärdet skulle vara 100

        //metod för att giltigt val ska skickas tillbaka
        public string GiltigtVal(int skott) //tar in värdet från skott
        {
            

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
                    Console.WriteLine();
                    Console.WriteLine("ladda, skjuta, blocka eller shotgun? ");

                }

            }
            return val;
        }

       

    }
}

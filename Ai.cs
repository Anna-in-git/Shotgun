using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shotgun
{
    public class Ai
    {

        public string Namn { get; set; }
        public string Val { get; set; }
        public int Skott { get; set; }


        public static Random random = new Random(); //skapar ett random objekt

        //Metod som väljer bland de olika valen med randomnr som läses av i arrayen
        public string RandomVal(int spelareSkott) //tar in spelarens skott för att ai ska kunna anpassa sitt val
        {

            string aiVal = "";
            bool giltig = false;



            while (giltig == false)
            {
                string[] ai = { "skjuta", "ladda", "blocka", "shotgun" };
                int i = random.Next(ai.Length);
                aiVal = ai[i];

                //ladda, skjuta, blocka, shotgun ska bli rätt
                if (aiVal == "ladda" && Skott <= 2)  //ai ska inte blocka om spelare har 0 Skott
                {
                    giltig = true;

                }
                else if (aiVal == "blocka" && spelareSkott > 0 && Skott <= 2)
                {
                    giltig = true;
                }
                else if (aiVal == "blocka" && spelareSkott == 0)
                {

                }
                else if (aiVal == "skjuta" && Skott <= 0)
                {

                }
                else if (aiVal == "skjuta" && Skott > 0 && Skott <= 2)
                {
                    giltig = true;

                }
                else if (aiVal == "shotgun" && Skott < 3)
                {

                }
                else if (aiVal == "shotgun" && Skott >= 3)
                {
                    giltig = true;

                }

            }
            return aiVal;
        }
       


    }
}

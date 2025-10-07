namespace Shotgun
{
    public class Ai
    {
        public string Namn { get; set; }
        public string Val { get; set; }
        public int Skott { get; set; }
        public Dictionary<string, string[]> AiBilder { get; set; }
        public Dictionary<string, string[]> AiValBilder { get; set; }
        public ConsoleColor AiFarg { get; set; }
        public string Introduktion { get; set; }
        public string Avslutning { get; set; }
        public string VinstTal { get; set; }
        public string ForlustTal { get; set; }


        public Random random = new Random(); //skapar ett random objekt 

        //metod som skapar en ai spelare
        public Ai SkapaAiSpelaren(Spelare spelare)
        {    
            string[] namn = { "RobotMamma" };
            string valtAinamn = namn[random.Next(namn.Length)];
           
            if (valtAinamn == "RobotRobin")
            {
                return new RobotRobin();

            }
            else if (valtAinamn == "RobotMillis")
            {
                return new RobotMillis();
            }
            else
            {
                return new RobotMamma(spelare);
            }
            
        }

        //Metod som väljer ains val slumpmässigt
        public string RandomVal(int spelareSkott) //tar in spelarens skott för att ai ska kunna anpassa sitt val
        {

            string aiVal = "";
            bool giltig = false;


            // En loop som körs tills ett giltigt val är gjort
            while (giltig == false)
            {

                string[] ai = { "ladda","shotgun" };
                int i = random.Next(ai.Length); //slumpar fram ett nummer mellan 0-3
                aiVal = ai[i]; //välj ett av alternativen i arrayen

                //ladda, skjuta, blocka, shotgun ska bli rätt
                if (aiVal == "ladda" && Skott <= 2)  //ai ska inte blocka om spelare har 0 Skott
                {
                    giltig = true;

                }
                else if (aiVal == "blocka" && spelareSkott > 0 && Skott <= 2)
                {
                    giltig = true;
                }
                else if (aiVal == "ladda" && spelareSkott == 0 && Skott == 2)
                {
                    giltig = true;
                }
                else if (aiVal == "skjuta" && Skott > 0 && Skott <= 2)
                {
                    giltig = true;

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

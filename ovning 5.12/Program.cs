using System;

namespace övning_5._12
{
    class Program
    {
        static int antalTärningar = 5;
        static int sidorPerTärning = 6;
        static Random slumpGenerator = new Random();

        static void Main(string[] args)
        {
            int[] tärningsvärden = new int[antalTärningar];

            Console.WriteLine("Välkommen till Yatzy!");

            KastaTärningar(tärningsvärden);
            SkrivUtTärningsvärden(tärningsvärden);

            bool allaTärningarLåsta = false;
            while (!allaTärningarLåsta)
            {
                Console.WriteLine("Vilka tärningar vill du låsa? Ange numren separerade med mellanslag (eller skriv 'klar' om du är klar):");
                string input = Console.ReadLine();

                if (input.ToLower() == "klar")
                {
                    allaTärningarLåsta = true;
                    break;
                }

                string[] valdaTärningar = input.Split(' ');
                foreach (string tärningStr in valdaTärningar)
                {
                    if (int.TryParse(tärningStr, out int tärningsnummer) && tärningsnummer >= 1 && tärningsnummer <= antalTärningar)
                    {
                        tärningsvärden[tärningsnummer - 1] = KastaTärning();
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt tärningsnummer. Vänligen ange ett nummer mellan 1 och 5.");
                    }
                }

                SkrivUtTärningsvärden(tärningsvärden);
            }

            Console.WriteLine("Tack för att du spelade Yatzy!");
        }

        static void KastaTärningar(int[] tärningsvärden)
        {
            for (int i = 0; i < tärningsvärden.Length; i++)
            {
                tärningsvärden[i] = KastaTärning();
            }
        }

        static int KastaTärning()
        {
            return slumpGenerator.Next(1, sidorPerTärning + 1);
        }

        static void SkrivUtTärningsvärden(int[] tärningsvärden)
        {
            Console.WriteLine("Tärningskasten blev:");
            for (int i = 0; i < tärningsvärden.Length; i++)
            {
                Console.WriteLine($"Tärning {i + 1}: {tärningsvärden[i]}");
            }
        }
    }
}

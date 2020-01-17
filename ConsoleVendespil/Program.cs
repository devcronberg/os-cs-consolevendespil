using System;

namespace ConsoleVendespil
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til Cronberg's vendespil");
            Console.WriteLine("----------------------------------");
            Console.WriteLine();
            int sværhedsgrad = ConsoleFunktioner.HentNummer("Angiv sværhedsgrad (1-5 hvor 1 er meget nem og 5 er meget svær)", "Forkert nummer", 1, 5);
            int[] muligeMatrixer = { 2, 4, 6, 8, 10 };
            VendeKortSpil s = new VendeKortSpil(muligeMatrixer[sværhedsgrad - 1], sværhedsgrad < 3 ? 3000 : 2000);
            do
            {
                s.Træk();
            } while (!s.SpilFærdigt());
            Console.WriteLine();
            Console.WriteLine($"Spiller er slut - du har brugt {s.AntalTræk} træk.");
        }
    }
}
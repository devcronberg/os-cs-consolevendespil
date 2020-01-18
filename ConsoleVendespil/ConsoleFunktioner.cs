using System;

namespace ConsoleVendespil
{
    /// <summary>
    /// Statisk klasse med hjælpefunktioner til consol
    /// </summary>
    public static class ConsoleFunktioner
    {
        /// <summary>
        /// Hent et nummer fra console og bliv ved til det overholder min/max
        /// </summary>
        /// <param name="tekst">Den tekst der vises</param>
        /// <param name="fejlTekst">Den evt fejltekst der vises</param>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximum</param>
        /// <returns>Indtastet tal</returns>
        public static int HentNummer(string tekst, string fejlTekst, int min, int max)
        {
            int? svar = null;
            do
            {
                try
                {
                    Console.WriteLine(tekst);
                    string tmp = Console.ReadLine();
                    svar = Convert.ToInt32(tmp);
                    if (svar < min || svar > max)
                    {
                        svar = null;
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(fejlTekst);
                }
            } while (svar == null);
            return svar.Value;
        }
    }
}
using System;

namespace ConsoleVendespil
{
    public static class ConsoleFunktioner
    {
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
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleVendespil
{
    /// <summary>
    /// Repræsenterer et vendekort
    /// </summary>
    public class VendeKortSpil
    {
        // Den matrix som kort gemmes i (2. dimensionelt array af VendeKort)
        private VendeKort[,] _matrix;

        // hvor stor matrix skal der skabes (_matrixAntal x _matrixAntal)
        private int _matrixAntal;

        // Hvor lang tid skal der ventes inden næste træk (millisekunder)
        private int _sleep;

        /// <summary>
        /// Constructor - opretter matrix med kort
        /// </summary>
        /// <param name="matrixAntal">Størrelse på matrix</param>
        /// <param name="sleep">Millisekunder der skal ventes når kort er vendt</param>
        public VendeKortSpil(int matrixAntal, int sleep)
        {
            _matrixAntal = matrixAntal;
            _sleep = sleep;
            _matrix = new VendeKort[_matrixAntal, _matrixAntal];

            int _antalKort = matrixAntal * matrixAntal;
            // Numre fra 1 - 100 som sorteres tilfældigt. Det bruges til at hente tal som er
            // tilfældige og unikke
            var numre = Enumerable.Range(1, 100).OrderBy(i => Guid.NewGuid().ToString()).ToList();

            // Dan matrix
            int index = 0;
            for (int i = 0; i < _matrixAntal; i++)
            {
                for (int x = 0; x < _matrixAntal; x += 2)
                {
                    _matrix[i, x] = new VendeKort(numre[index]);
                    _matrix[i, x + 1] = new VendeKort(numre[index++]);
                }
            }

            // Sorter matrix
            Random r = new Random();
            for (int i = 0; i < 1000; i++)
            {
                int nr1 = r.Next(0, _matrixAntal);
                int nr2 = r.Next(0, _matrixAntal);
                int nr3 = r.Next(0, _matrixAntal);
                int nr4 = r.Next(0, _matrixAntal);
                VendeKort tmp = _matrix[nr1, nr2];
                _matrix[nr1, nr2] = _matrix[nr3, nr4];
                _matrix[nr3, nr4] = tmp;
            }
        }

        /// <summary>
        /// Hvor mange træk har spilleren brugt
        /// </summary>
        public int AntalTræk { get; private set; }

        /// <summary>
        /// Vender alle kort (bliver kun brugt i test)
        /// </summary>
        public void BytSide()
        {
            MatrixSomListe().ForEach(i => i.BytSide());
        }

        /// <summary>
        /// Henter et kort fra brugeren (A1, B2 mv)
        /// </summary>
        /// <param name="nr"></param>
        /// <returns></returns>
        public VendeKort HentKortFraConsole(int nr)
        {
            VendeKort v = null;
            do
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Indtast " + nr + ". kort (som A1 eller B2):");
                    string kort1 = Console.ReadLine();
                    kort1 = kort1.ToUpper();
                    v = _matrix[Convert.ToInt32(kort1.ToCharArray()[1].ToString()) - 1, (Convert.ToInt32(kort1.ToCharArray()[0]) - 65)];
                    if (v.Side == VendeKortSide.Forside)
                        v = null;
                }
                catch (Exception)
                { }
            } while (v == null);
            if (nr == 2) AntalTræk++;
            return v;
        }

        /// <summary>
        /// Vender alle kort forsiden op? - i så fald er spillet slut
        /// </summary>
        /// <returns></returns>
        public bool SpilFærdigt()
        {
            return MatrixSomListe().Where(i => i.Side == VendeKortSide.Bagside).Count() == 0;
        }

        /// <summary>
        /// Tegner matrix på consol
        /// </summary>
        public void Tegn()
        {
            Console.Clear();
            Console.Write("    ");
            for (int i = 1; i < _matrixAntal + 1; i++)
            {
                // char 65 = A
                Console.Write(" " + Convert.ToChar(i + 64).ToString() + "  ");
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < _matrixAntal; i++)
            {
                Console.Write((i + 1).ToString().PadRight(4));
                for (int x = 0; x < _matrixAntal; x++)
                {
                    Console.Write(_matrix[i, x] + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Spillerens "træk" - der indsamles 2 kort
        /// </summary>
        public void Træk()
        {
            Tegn();
            var v = HentKortFraConsole(1);
            v.BytSide();
            Tegn();
            var v2 = HentKortFraConsole(2);
            v2.BytSide();
            Tegn();
            if (v2.Tal != v.Tal)
            {
                System.Threading.Thread.Sleep(_sleep);
                v.Side = VendeKortSide.Bagside;
                v2.Side = VendeKortSide.Bagside;
            }
        }

        /// <summary>
        /// Hjælpefunktion der "flader" matrix ud til en liste
        /// </summary>
        /// <returns></returns>
        private List<VendeKort> MatrixSomListe()
        {
            List<VendeKort> l = new List<VendeKort>();
            for (int i = 0; i < _matrixAntal; i++)
                for (int x = 0; x < _matrixAntal; x++)
                    l.Add(_matrix[i, x]);
            return l;
        }
    }
}
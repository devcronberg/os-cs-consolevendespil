namespace ConsoleVendespil
{
    /// <summary>
    /// Klasse der repræsenterer et vendekort
    /// </summary>
    public class VendeKort
    {
        /// <summary>
        /// Dan kort og vend bagside opad
        /// </summary>
        /// <param name="tal"></param>
        public VendeKort(int tal)
        {
            Tal = tal;
            Side = VendeKortSide.Bagside;
        }

        /// <summary>
        /// Forside eller bagside
        /// </summary>
        public VendeKortSide Side { get; set; }

        // Det gemte tal
        public int Tal { get; private set; }

        /// <summary>
        /// Bytter rundt på for- og bagside
        /// </summary>
        public void BytSide()
        {
            if (Side == VendeKortSide.Bagside)
                Side = VendeKortSide.Forside;
            else
                Side = VendeKortSide.Bagside;
        }

        /// <summary>
        /// String der viser kort afhængig af for- eller bagside
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Side == VendeKortSide.Bagside)
                return "***";
            else
                return Tal.ToString("000");
        }
    }
}
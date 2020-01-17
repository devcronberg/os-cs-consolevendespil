namespace ConsoleVendespil
{
    public class VendeKort
    {
        public VendeKort(int tal)
        {
            Tal = tal;
            Side = VendeKortSide.Bagside;
        }

        public VendeKortSide Side { get; set; }
        public int Tal { get; private set; }

        public void BytSide()
        {
            if (Side == VendeKortSide.Bagside)
                Side = VendeKortSide.Forside;
            else
                Side = VendeKortSide.Bagside;
        }

        public override string ToString()
        {
            if (Side == VendeKortSide.Bagside)
                return "***";
            else
                return Tal.ToString("000");
        }
    }
}
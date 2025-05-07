namespace SQL_CLI_Manager.models
{
    public class Produkt
    {
        private int id;
        private int artikelnummen;
        private string produktname;
        private double preis;
        private string beschreibung;
        private int anzahl;

        public Produkt(int artikelnummen, string produktname, double preis, string beschreibung, int anzahl)
        {
            this.artikelnummen = artikelnummen;
            this.produktname = produktname;
            this.preis = preis;
            this.beschreibung = beschreibung;
            this.anzahl = anzahl;
        }

        public Produkt(int id, int artikelnummen, string produktname, double preis, string beschreibung, int anzahl)
        {
            this.id = id;
            this.artikelnummen = artikelnummen;
            this.produktname = produktname;
            this.preis = preis;
            this.beschreibung = beschreibung;
            this.anzahl = anzahl;
        }



        public int Id
        {
            get => id;
            set => id = value;
        }

        public int Artikelnummen
        {
            get => artikelnummen;
            set => artikelnummen = value;
        }

        public string Produktname
        {
            get => produktname;
            set => produktname = value;
        }

        public double Preis
        {
            get => preis;
            set => preis = value;
        }

        public string Beschreibung
        {
            get => beschreibung;
            set => beschreibung = value;
        }

        public int Anzahl
        {
            get => anzahl;
            set => anzahl = value;
        }
    }
}
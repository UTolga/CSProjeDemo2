namespace CSProjeDemo2
{
    public abstract class Personel
    {
        public string Ad { get; set; }
        public string Unvan { get; set; }
        public int CalismaSaati { get; set; }
        public decimal SaatlikUcret { get; set; }

        public Personel(string ad, string unvan, int calismaSaati, decimal saatlikUcret)
        {
            Ad = ad;
            Unvan = unvan;
            CalismaSaati = calismaSaati;
            SaatlikUcret = saatlikUcret;
        }

        public abstract decimal MaasHesapla();

        public override string ToString()
        {
            return $"{Ad} - {Unvan} - {CalismaSaati} Saat";
        }
    }
}

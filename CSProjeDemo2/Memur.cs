namespace CSProjeDemo2
{
    public class Memur : Personel
    {
        public Memur(string ad, int calismaSaati, decimal saatlikUcret)
            : base(ad, "Memur", calismaSaati, saatlikUcret)
        {
            if (saatlikUcret < 500)
            {
                SaatlikUcret = 500; // Varsayılan olarak 500 TL
            }
        }

        public override decimal MaasHesapla()
        {
            if (CalismaSaati <= 180)
            {
                return CalismaSaati * SaatlikUcret;
            }
            else
            {
                int fazlaMesaiSaati = CalismaSaati - 180;
                decimal fazlaMesaiUcreti = fazlaMesaiSaati * (SaatlikUcret * 1.5M);
                return (180 * SaatlikUcret) + fazlaMesaiUcreti;
            }
        }
    }
}

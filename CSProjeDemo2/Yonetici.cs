namespace CSProjeDemo2
{
    public class Yonetici : Personel
    {
        public decimal Bonus { get; set; }

        public Yonetici(string ad, int calismaSaati, decimal saatlikUcret, decimal bonus)
            : base(ad, "Yönetici", calismaSaati, saatlikUcret)
        {
            if (saatlikUcret < 500)
            {
                throw new ArgumentException("Yönetici saatlik ücreti 500 TL'den az olamaz.");
            }
            Bonus = bonus;
        }

        public override decimal MaasHesapla()
        {
            return (CalismaSaati * SaatlikUcret) + Bonus;
        }
    }
}

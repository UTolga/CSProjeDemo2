using Newtonsoft.Json;
namespace CSProjeDemo2
{
    public static class MaasBordro
    {
        public static void MaaslariHesaplaVeKaydet(List<Personel> personeller, string ayYili)
        {
            List<Personel> azCalisanlar = new List<Personel>();

            foreach (var personel in personeller)
            {
                decimal anaOdeme = personel.MaasHesapla();
                decimal mesai = (personel is Memur && personel.CalismaSaati > 180)
                    ? (personel.CalismaSaati - 180) * (personel.SaatlikUcret * 0.5M)
                    : 0;

                decimal toplamOdeme = anaOdeme + mesai;

                var bordro = new
                {
                    PersonelIsmi = personel.Ad,
                    CalismaSaati = personel.CalismaSaati,
                    AnaOdeme = anaOdeme,
                    Mesai = mesai,
                    ToplamOdeme = toplamOdeme
                };

                string klasorAdi = $"Bordrolar/{personel.Ad}";
                Directory.CreateDirectory(klasorAdi);
                string dosyaAdi = $"{klasorAdi}/{ayYili}.json";
                File.WriteAllText(dosyaAdi, JsonConvert.SerializeObject(bordro, Formatting.Indented));

                if (personel.CalismaSaati < 150)
                {
                    azCalisanlar.Add(personel);
                }
            }

            Console.WriteLine("\n150 saatten az çalışanlar:");
            foreach (var p in azCalisanlar)
            {
                Console.WriteLine($"{p.Ad} - {p.CalismaSaati} Saat");
            }
        }
    }
}

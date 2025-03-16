using Newtonsoft.Json;

namespace CSProjeDemo2
{
    public static class DosyaOku
    {
        public static List<Personel> PersonelListesiOku(string dosyaYolu)
        {
            if (!File.Exists(dosyaYolu))
            {
                throw new FileNotFoundException("Belirtilen JSON dosyası bulunamadı.");
            }

            string json = File.ReadAllText(dosyaYolu);
            var personelVerileri = JsonConvert.DeserializeObject<List<dynamic>>(json);

            List<Personel> personeller = new List<Personel>();

            foreach (var veri in personelVerileri)
            {
                string ad = veri.name;
                string unvan = veri.title;
                int calismaSaati = veri.workHours;
                decimal saatlikUcret = veri.hourlyRate;
                decimal bonus = veri.bonus ?? 0;

                if (unvan == "Yonetici")
                {
                    personeller.Add(new Yonetici(ad, calismaSaati, saatlikUcret, bonus));
                }
                else if (unvan == "Memur")
                {
                    personeller.Add(new Memur(ad, calismaSaati, saatlikUcret));
                }
            }

            return personeller;
        }
    }
}

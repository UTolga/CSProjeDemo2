namespace CSProjeDemo2
{
    class Program
    {
        static void Main()
        {
            try
            {
                string jsonDosyaYolu = "personel.json";
                List<Personel> personeller = DosyaOku.PersonelListesiOku(jsonDosyaYolu);

                Console.WriteLine("\nPersonel Listesi:");
                foreach (var personel in personeller)
                {
                    Console.WriteLine(personel);
                }

                Console.WriteLine("\nMaaş bordroları hesaplanıyor...");
                MaasBordro.MaaslariHesaplaVeKaydet(personeller, "Mart_2025");

                Console.WriteLine("\nMaaş bordroları başarıyla oluşturuldu.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
        }
    }
}

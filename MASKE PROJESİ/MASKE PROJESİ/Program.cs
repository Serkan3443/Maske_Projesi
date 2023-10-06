namespace MASKE_PROJESİ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kisi kisi1 = new Kisi();
            kisi1.Ad = "SERKAN";
            kisi1.SoyAd = "KABADAYIOĞULLARI";
            kisi1.DogumTarihi = 1998;
            kisi1.TcNo = 123;//gerçek tc nizi yazarsanız maske verildi başarıyla sonuçlanır

            Kisi kisi2 = new Kisi();
            kisi2.Ad = "Daniel";

            PttYonetici pttYonetici = new PttYonetici(new KisiYonetici());
            pttYonetici.MaskeBasvur(kisi1);

            Console.Read();
        }
    }
}
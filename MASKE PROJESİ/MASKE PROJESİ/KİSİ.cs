using MernisServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASKE_PROJESİ
{
    class Kisi
    {
        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public long TcNo { get; set; }
        public int DogumTarihi { get; set; }
    }
    class KisiYonetici : IBasvuruHizmeti
    {
        public bool KisiKontrol(Kisi kisi)
        {

            KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            return client.TCKimlikNoDogrulaAsync(new TCKimlikNoDogrulaRequest(new TCKimlikNoDogrulaRequestBody(kisi.TcNo, Ad: kisi.Ad, Soyad: kisi.SoyAd, DogumYili: kisi.DogumTarihi))).Result.Body.TCKimlikNoDogrulaResult;
        }

        public List<Kisi> Listele()
        {
            return null;
        }

        public void MaskeBasvur(Kisi kisi)
        {

        }
    }
    class PttYonetici : IDagiticiHizmet
    {
        private IBasvuruHizmeti _basvuruHizmeti;
        public PttYonetici(IBasvuruHizmeti basvuruHizmeti)//constructor new yapıldığında çalışır
        {
            _basvuruHizmeti = basvuruHizmeti;
        }

        public void MaskeBasvur(Kisi kisi)
        {

            if (_basvuruHizmeti.KisiKontrol(kisi))
            {
                Console.WriteLine(kisi.Ad + " İçin maske verildi");
            }
            else
            {
                Console.WriteLine(kisi.Ad + " İçin maske VERİLEMEDİ");
            }
        }
    }
    interface IBasvuruHizmeti
    {
        void MaskeBasvur(Kisi kisi);
        List<Kisi> Listele();

        bool KisiKontrol(Kisi kisi);
    }
    class YabanciYonetici : IBasvuruHizmeti
    {
        public bool KisiKontrol(Kisi kisi)
        {
            throw new NotImplementedException();
        }

        public List<Kisi> Listele()
        {
            throw new NotImplementedException();
        }

        public void MaskeBasvur(Kisi kisi)
        {
            throw new NotImplementedException();
        }
    }
    interface IDagiticiHizmet
    {
        void MaskeBasvur(Kisi kisi);
    }

}

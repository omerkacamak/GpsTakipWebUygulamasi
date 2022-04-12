using System;
using System.Collections.Generic;
using proje.entity;


namespace proje.data.Abstract
{
    public interface IKullaniciVeri
    {
         Kullanici GetById(int? id);
         Araba GetByNameAraba(string araba);
         Araba GetByIdAraba(int? id);
         //void KullaniciyaArabalarEkle();
         void KullaniciEkle(Kullanici k);
         void ArabaEkle(Araba car);
       // List<ArabaYollari>yollariGetir(Araba ar); // arabanın yolları gelir
        void verileriEkle();
        List<KullaniciArabalari>GetKullaniciArabalaris(Kullanici kul); // kullanıcının arabaları gelir
        void girisEkle(DateTime taym, Kullanici kul1);
        void cikisEkle(DateTime tarih,Kullanici ku2);
        
        

         
         

        
         
         
         

    }
}
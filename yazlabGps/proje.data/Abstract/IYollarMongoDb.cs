using System;
using System.Collections.Generic;
using MongoDB.Driver;
using proje.entity;

namespace proje.data.Abstract
{
    public interface IYollarMongoDb
    {
         List<Yol> ArabaninTumYollari(Araba car);
         List<Yol> ArabaninTariheGoreYollari(Araba araba,DateTime tarih1,DateTime tarih2);
         List<List<Yol>> Son30DakikaVerileri (Araba araba,Kullanici kul );
         List<List<Yol>> ArabalarinYollari(Kullanici kul); // kullanıcın arabalari ve o arabalarin her birinin yollari gelir
         IEnumerable<string> forDate(Araba c);
         IEnumerable<string>forHour(Araba car);
         List<string> forHourx();
         DateTime dt(string st1,string st2);


    }
}
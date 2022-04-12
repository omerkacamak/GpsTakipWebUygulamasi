using System.Collections.Generic;
using proje.entity;

namespace proje.data.Concrete.EfCore
{
    public class TestVeri
    {
    // public  static   List<Araba> otomobil = new List<Araba>(){
    //                 new Araba(){
    //              isim="Hyundai",
    //              ArabaninYollari= new List<ArabaYollari>(){
    //                  new ArabaYollari (){Latitude="12.455",Longitude=14.666,tarih="2022"},
    //                  new ArabaYollari (){Latitude=77.455,Longitude=41.666,tarih="2022"}
    //              }
    //          },

    //             new Araba(){
    //              isim="Mazda",
    //              ArabaninYollari= new List<ArabaYollari>(){
    //                  new ArabaYollari (){Latitude=44.455,Longitude=232.666,tarih="2022"},
    //                  new ArabaYollari (){Latitude=66.455,Longitude=41.666,tarih="2022"}
    //              }
    //          },

    //          new Araba(){
    //              isim="Fiat",
    //              ArabaninYollari= new List<ArabaYollari>(){
    //                  new ArabaYollari (){Latitude=1232.455,Longitude=54.666,tarih="2022"},
    //                  new ArabaYollari (){Latitude=22.455,Longitude=97.666,tarih="2022"}
    //              }
    //          },

    //          new Araba(){
    //              isim="BMW",
    //              ArabaninYollari= new List<ArabaYollari>(){
    //                  new ArabaYollari (){Latitude=323.455,Longitude=226.666,tarih="2022"},
    //                  new ArabaYollari (){Latitude=66.455,Longitude=141.666,tarih="2022"}
    //              }
    //          },

    //          };



    public static List<Kullanici> kul = new List<Kullanici>(){
      new Kullanici(){
                isim= "Ömer",
                soyisim="Kaçamak",
                kullaniciAdi="ömer",
                KullaniciArabalari=
                    
                    new List<KullaniciArabalari>(){
 new KullaniciArabalari(){ArabaId=1}
// new KullaniciArabalari(){ArabaId=2}
     }
                 
            }  ,


//             new Kullanici(){
//                 isim= "Sedef",
//                 soyisim="Kaçamak",
//                 kullaniciAdi="galiii",
//                 KullaniciArabalari=
                    
//                     new List<KullaniciArabalari>(){
//  new KullaniciArabalari(){ArabaId=3},
//  new KullaniciArabalari(){ArabaId=4}
//      }
                 
//             }  ,



    }; // kul list




             
    }
}
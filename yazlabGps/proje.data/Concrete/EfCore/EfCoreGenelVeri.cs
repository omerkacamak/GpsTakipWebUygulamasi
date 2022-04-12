using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using proje.data.Abstract;
using proje.entity;
using MongoDB.Driver.Linq;

namespace proje.data.Concrete.EfCore
{
    public class EfCoreGenelVeri :IKullaniciVeri,IYollarMongoDb
    {
        MongoClient client ;
   
        public EfCoreGenelVeri()
        {
            client= new MongoClient("mongodb+srv://galimuna:Alakrum85i@denemecluster.0nawm.mongodb.net/Test?retryWrites=true&w=majority");
        }
        public void ArabaEkle(Araba car)
        {
           
            
            using(var context = new ProjeContext())
            {
                context.Arabas.Add(car);
                
                context.SaveChanges();
                System.Console.WriteLine("Başarıyla kaydedildi");
                
            }
        }

        public List<List<Yol>> ArabalarinYollari(Kullanici kul) // her arabanın yolu donecek
        {
           var tumArabalari = GetKullaniciArabalaris(kul); // kullanıcının arabaları gelir
           List<List<Yol>> liste=new List<List<Yol>>();
           
          System.Console.WriteLine(GetByIdAraba(tumArabalari[0].ArabaId));
         // var araba = GetByIdAraba(1);
          
           foreach (var item in tumArabalari)
           {
               
               System.Console.WriteLine("sorma : " + item.Araba.isim);
               var a =ArabaninTumYollari(item.Araba);
               liste.Add(a);
           }
            
            return liste;
           
           
        }

        public List<Yol> ArabaninTariheGoreYollari(Araba araba, DateTime tarih1, DateTime tarih2)
        {
            var database = client.GetDatabase("Test");
             var collec=database.GetCollection<Yol>("Yollar");
            var arabaninYollari = ArabaninTumYollari(araba);
        List<Yol> yolum = new List<Yol>();
        foreach (var item in arabaninYollari)
        {
            if(tarih1>tarih2)
            {
                if(item.Date<=tarih1 && item.Date>=tarih2)
                {
                    yolum.Add(item);
                }
            }
            else{
                if(item.Date<=tarih2 && item.Date>=tarih1)
                {
                    yolum.Add(item);
                }
            }
        }
           
             return yolum;
        }

        public List<Yol> ArabaninTumYollari(Araba car)
        {
            var database = client.GetDatabase("Test");
             var collec=database.GetCollection<Yol>("Yollar");
             string strId = car.ArabaId.ToString();
             var bilgi = collec.Find(x=>x.arabaid==strId).ToList();
             return bilgi;
        }

        public DateTime dt(string st1, string st2)
        {
            var str = st1 + " " + st2;
            var datem=DateTime.Parse(str);
            return datem;
        }

        public IEnumerable<string> forDate(Araba c)
        {
            var database = client.GetDatabase("Test");
             var collec=database.GetCollection<Yol>("Yollar");
             var tum= ArabaninTumYollari(c);
             var farkli = tum.Select(x=>x.Date.ToShortDateString()).Distinct();
            foreach (var item in farkli)
            {
                System.Console.WriteLine("farkli : " + item);
            }
             return farkli;
        }

        public List<string> forHourx()
        {
            var tt= DateTime.Parse("00:00");
            for (int i = 0; i < 10; i++)
            {
                
            }
            return null;
        }

        public IEnumerable<string> forHour(Araba car)
        {
            var database = client.GetDatabase("Test");
            var collec=database.GetCollection<Yol>("Yollar");
            var tum= ArabaninTumYollari(car);
            var farkli1 = tum.Select(x=>x.Date.Hour.ToString()).Distinct();
            
             foreach (var item in farkli1)
            {
                System.Console.WriteLine("farklizaa : " + item);
            }

            return farkli1;
        }

        public Kullanici GetById(int? id)
        {
            using(var context = new ProjeContext())
            {
                return context.Kullanicis.Find(id);
                
            }
        }

        public Araba GetByIdAraba(int? id)
        {
             using(var context = new ProjeContext())
            {
                return context.Arabas.Find(id);
                
            }
        }

        public Araba GetByNameAraba(string araba)
        {
            using(var context = new ProjeContext())
            {
                return context.Arabas.Where(x=>x.isim==araba).FirstOrDefault();
                
            }
        }

        public List<KullaniciArabalari> GetKullaniciArabalaris(Kullanici kul)
        {
           using(var context = new ProjeContext())
           {
               var bil =context.KullaniciArabalaris.Where(c=>c.Kullanici==kul).ToList();
               
               foreach (var item in bil)
               {
                   item.Kullanici=kul;
                   item.Araba=context.Arabas.Where(i=>i.ArabaId==item.ArabaId).FirstOrDefault();
               }
               //System.Console.WriteLine("efcorumu alim haci-<>>   " + bil[0].ArabaId);
               return bil;
           }
        }

        public void KullaniciEkle(Kullanici kullanici)
        {
            using(var context = new ProjeContext())
            {
                context.Kullanicis.Add(kullanici);
                
                context.SaveChanges();
                
            }
        }

        

        public  List<List<Yol>> Son30DakikaVerileri(Araba araba,Kullanici kul)
        {
             var database = client.GetDatabase("Test");
             var carcol=database.GetCollection<Yol>("Yollar");
             var saat= DateTime.Now.Hour.ToString();
             var liste = ArabaninTumYollari(araba);
             var liste2= carcol.Find(x=>x.tarih.Contains(saat)).ToList();
             var sonTarih = liste[liste.Count-1].tarih;
          //  database.CreateCollection("students");
             var collection = database.GetCollection<Student>("students");
             var today = DateTime.Now; //2017-04-05 15:21:23.234
        var yesterday = "2018-10-02 17:34";//2017-04-04 15:21:23.234
        // collection.InsertMany(new[]
        //     {
        //     new Student{Description = "today", CreatedOn = today},
        //     new Student{Description = "tomorrow", CreatedOn = DateTime.Parse(yesterday, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal )},
        //     }
        //  );
         var filterBuilder1 = Builders<Student>.Filter;
         var filter1 = filterBuilder1.Eq(x => x.CreatedOn, today);
          List<Student> searchResult1 = collection.Find(filter1).ToList();
          Console.Write(searchResult1.Count == 1);

           var filterBuilder2 = Builders<Student>.Filter;
      //  var filter2 = filterBuilder2.Eq(x => x.CreatedOn, yesterday);
       // List<Student> searchResult2 = collection.Find(filter2).ToList();
      //   Console.Write(searchResult2.Count == 1);
//           var start = new DateTime(2022, 03, 15);
//  var end = new DateTime(2022,03,22);
//          var filter = filterBuilder1.Gte(x => x.CreatedOn, start) &
//          filterBuilder1.Lt(x => x.CreatedOn, end);
//          var list = collection.Find(filter).ToList();
//          System.Console.WriteLine(list.Count==1);

var stringDate = "2018-10-02 17:34";
DateTime dateFilter = DateTime.Parse(stringDate, CultureInfo.InvariantCulture );
System.Console.WriteLine();
System.Console.WriteLine(dateFilter);
System.Console.WriteLine(Convert.ToDateTime(stringDate));
DateTime testDate = DateTime.ParseExact("2012-08-10T00:51:14.146Z", "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
System.Console.WriteLine(testDate);
System.Console.WriteLine(DateTime.Parse(stringDate));

string ss = DateTime.Now.ToString();
System.Console.WriteLine("ss " + ss);


var tt = DateTime.Parse(stringDate, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal );
System.Console.WriteLine("son : " + tt);
var key = collection.Find(x=>x.Description=="today").ToList();
System.Console.WriteLine("liste : " +key[0].CreatedOn );

System.Console.WriteLine(liste[0].Date);
//carcol.Find((Builders<Yol>.Filter.And()));
 //var ky =carcol.AsQueryable().Where(x=>x.Date == DateTime.UtcNow.AddHours(1)).ToList();
//System.Console.WriteLine("buson : " + carcol.AsQueryable());
 //System.Console.WriteLine(ky[0].Date);
var emptyFilter = Builders<Yol>.Filter.Empty;
var sort = Builders<Yol>.Sort.Descending(x=>x.Date);
var messagess = carcol.Find(emptyFilter).Sort(sort).ToList();
var yu = messagess[0].Date - DateTime.Now;

System.Console.WriteLine("mess " + (liste[liste.Count-1].Date));
var otuz = carcol.Find(x=>x.Date==liste[liste.Count-1].Date.AddHours(-0.5)).ToList(); // son verinin yarım saat öncesi
//System.Console.WriteLine("otuz: " + otuz[0].Date);

var sonYol =liste[liste.Count-1];
var son31=sonYol.Date.AddMinutes(-31);
var buyuk =sonYol.Date.AddMinutes(-31) > DateTime.Now;
System.Console.WriteLine("tarihe bakam : " + sonYol.Date.AddMinutes(-31));
Kullanici k = new Kullanici();



// list içinde list  asıl doğru yer
var arabalarVeYollari= ArabalarinYollari(kul);
var birSonYol = arabalarVeYollari[0][arabalarVeYollari[0].Count-1];
var birSon31= birSonYol.Date.AddMinutes(-31);
var ikiSonYol = arabalarVeYollari[1][arabalarVeYollari[1].Count-1];
var ikiSon31= ikiSonYol.Date.AddMinutes(-31);
 
 
 List<Yol>  yols = new List<Yol>();
 List<Yol> yol1= new List<Yol>();
 List<Yol> yol2= new List<Yol>(); 
  List<List<Yol>>  listYol = new List<List<Yol>>();
 

foreach (var item in arabalarVeYollari[0])
{
   if(item.Date > birSon31)
   {
       yol1.Add(item);
   }
}
foreach (var item2 in arabalarVeYollari[1])
{
    if(item2.Date > ikiSon31)
   {
       yol2.Add(item2);
   }
}

listYol.Add(yol1); 
listYol.Add(yol2);

var a =0;

foreach (var itemx in listYol[1])
{
    System.Console.WriteLine(a + " -z- " + itemx.Date);
    a++;
}




            
             
          
             
                return listYol;
        }

        public void verileriEkle()
        {
            
            //   foreach (var item in TestVeri.otomobil)
            //    {
            //       ArabaEkle(item);
            //    }

            //  foreach (var item in TestVeri.kul)
            //  {
            //     KullaniciEkle(item);
            //  }
            System.Console.WriteLine("GOOOOL");


        }

        public void girisEkle(DateTime taym,Kullanici kul)
        {
            using(var context = new ProjeContext())
            {
                var a = new KullaniciGiris(){Kullanici=kul,girisZamani=taym , KullaniciId=kul.KullaniciId};
                context.KullaniciGirises.Add(a);
                context.SaveChanges();
            }
        }

        public void cikisEkle(DateTime tarih,Kullanici kul)
        {
            throw new NotImplementedException();
        }
    } 
    }
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using proje.webui.Models;
using Microsoft.AspNetCore.Http;
using proje.webui.Filter;
using proje.data;
using proje.entity;
using proje.data.Abstract;
using proje.data.Concrete.EfCore;
using Newtonsoft.Json;

namespace proje.webui.Controllers
{
    //[UserFilter]
    public class GirisController :Controller
    {
         ProjeContext xx = new ProjeContext();
        private readonly ILogger<GirisController> _logger;
        private IKullaniciVeri _kullaniciVeri;
        private IYollarMongoDb _yollarMongoDb;

        public GirisController(ILogger<GirisController> logger,IKullaniciVeri kullaniciVeri,IYollarMongoDb yollarMongoDb)
        {
            _logger = logger;
            _kullaniciVeri=kullaniciVeri;
            _yollarMongoDb=yollarMongoDb;
            
        }

        public IActionResult Index()
        {
            
          var kullanici  = xx.Kullanicis.Where(c=>c.KullaniciId==2).FirstOrDefault();
          
                        
          var kk = xx.Arabas.Where(i=>i.ArabaId==5).FirstOrDefault();
 var veri = _yollarMongoDb.ArabaninTumYollari(kk);

var uyuyu= _yollarMongoDb.forHour(kk);

var kiko = _kullaniciVeri.GetKullaniciArabalaris(kullanici);
var userim = _yollarMongoDb.ArabalarinYollari(kullanici);

System.Console.WriteLine("odaklan : " + userim[0][6].lati);
var tarih = "2018-10-02 18:52";
string [] words =tarih.Split(' ',':');
int i =0;
foreach (var item in words )
{
    System.Console.WriteLine(" --  " + i + " - " + item);
    i++;
}
           var mm = _yollarMongoDb.ArabaninTariheGoreYollari(kk,DateTime.Now,DateTime.Now);
          var xw=_yollarMongoDb.forDate(kk);
          // System.Console.WriteLine("ayna ayna : " + mm[0].Date + "  ----  "  + mm[1].Date);
        

        var eklearaba = xx.Arabas.ToList();
    
     KullaniciArabalari jj = new KullaniciArabalari(){
         KullaniciId=1,
         ArabaId=1
     };

                       

            return View();
            
            
        }
         [HttpPost]
        public IActionResult List(AjaxData ajaxData)
        {
           
            var jsonfile =JsonConvert.SerializeObject(ajaxData);
             System.Console.WriteLine("ajaxx: " +ajaxData.A);

            return Json(jsonfile);
            
        
        }

        [HttpPost]
        public IActionResult Index(string? name ,string? sifre)
        {
            var user = xx.Kullanicis.Where(o=>o.isim.Equals(name) && o.sifre==sifre).FirstOrDefault();
            var kiki = xx.Kullanicis.ToList();

            if(user!=null)
            {
             HttpContext.Session.SetString("kullaniciAdi",user.isim);
             HttpContext.Session.SetInt32("id",user.KullaniciId);
            return RedirectToAction("Index","Home"); 
                     
            }
            else{
                string hata = "giris bilgileri yanlış!";
                ModelState.AddModelError("","HATAAA");
                ViewBag.errx="giris hatali";
               // System.Console.WriteLine(hata);
                return View();
            }
        }
    }
}
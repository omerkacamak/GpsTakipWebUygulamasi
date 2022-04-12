using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using proje.data.Abstract;
using proje.data.Concrete.EfCore;
using proje.entity;
using proje.webui.Models;

namespace proje.webui.Controllers
{
  public  class AjaxData
    {
        public string A { get; set; }
         public string B { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
         private IKullaniciVeri _kullaniciVeri;
         private IYollarMongoDb _yollarMongoDb;

        public HomeController(ILogger<HomeController> logger,IKullaniciVeri kullaniciVeri,IYollarMongoDb yollarMongoDb)
        {
            _logger = logger;
            _kullaniciVeri=kullaniciVeri;
            _yollarMongoDb=yollarMongoDb;
        }

        public IActionResult Index()
        {
            ProjeContext xx = new ProjeContext();
             var kadi = HttpContext.Session.GetString("kullaniciAdi");
             int? kid = HttpContext.Session.GetInt32("id");
             System.Console.WriteLine("kid : " + kid);
             var user = _kullaniciVeri.GetById(kid);
             var userCar =_kullaniciVeri.GetKullaniciArabalaris(user);
             var son30= _yollarMongoDb.Son30DakikaVerileri(userCar[0].Araba,user);
             var arabalarVeYollari = _yollarMongoDb.ArabalarinYollari(user);
             var tt1=_yollarMongoDb.forDate(userCar[0].Araba);
             var tt2=_yollarMongoDb.forDate(userCar[1].Araba);
             var forSaat = _yollarMongoDb.forHour(userCar[1].Araba);
             var forSaat2=  _yollarMongoDb.forHour(userCar[0].Araba);
           //  System.Console.WriteLine("-->gördüm :  " + iam[1][1].arabaid);
             var modelim = new KullaniciModel(){
                 kullanici=user,
                 KullaniciArabalarim=userCar,
                 SonOtuz=son30,
                 arabalarVeYollari=arabalarVeYollari,
                 forDate1 =tt1,
                 forDate2 =tt2,
                 forHour1=forSaat,
                 forHour2=forSaat2
             };

            System.Console.WriteLine("kadi : " + kadi);
            return View(modelim);
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       [HttpPost]
        public IActionResult Gonderdi(AjaxData ajaxDatam)
        {   System.Console.WriteLine("ciddi mi " +ajaxDatam);
            // var yazz = new Yazi(){
            //     str="gxx"
            // };
           var jsonfile =JsonConvert.SerializeObject(ajaxDatam);
           

           System.Console.WriteLine("yaziiiq : " + ajaxDatam);
            return Json(ajaxDatam);
        }

        [HttpPost]
        public IActionResult Index(string? tarihim ,string? ilk, string? son)
        {
            System.Console.WriteLine("postumu alim haci");
            var kadi = HttpContext.Session.GetString("kullaniciAdi");
             int? kid = HttpContext.Session.GetInt32("id");
             System.Console.WriteLine("kid : " + kid);
             var user = _kullaniciVeri.GetById(kid);
             var userCar =_kullaniciVeri.GetKullaniciArabalaris(user);
             var son30= _yollarMongoDb.Son30DakikaVerileri(userCar[0].Araba,user);
             var arabalarVeYollari = _yollarMongoDb.ArabalarinYollari(user);
             var tt=_yollarMongoDb.forDate(userCar[0].Araba);
             var tt2=_yollarMongoDb.forDate(userCar[1].Araba);
             var bir =_yollarMongoDb.dt(tarihim,ilk);
             var iki = _yollarMongoDb.dt(tarihim,son);
             var tariheGore = _yollarMongoDb.ArabaninTariheGoreYollari(userCar[0].Araba,bir,iki);
             var forSaat = _yollarMongoDb.forHour(userCar[1].Araba);
             var forSaat2=  _yollarMongoDb.forHour(userCar[0].Araba);
           //  System.Console.WriteLine("-->gördüm :  " + iam[1][1].arabaid);
           System.Console.WriteLine("golaxxx : " + tariheGore[0].Date);
           
             var modelim = new KullaniciModel(){
                 kullanici=user,
                 KullaniciArabalarim=userCar,
                 SonOtuz=son30,
                 arabalarVeYollari=arabalarVeYollari,
                 forDate1 =tt,
                 forDate2=tt2,
                 yolum=tariheGore,
                 forHour1=forSaat,
                 forHour2=forSaat2
             };
            System.Console.WriteLine("as : " + tarihim);
            return View(modelim);
        }
  
        [HttpPost]
        public IActionResult TarihYolu(string? tarihim ,string? ilk, string? son, string? car, int? idKul)
        {
             var kadi = HttpContext.Session.GetString("kullaniciAdi");
             int? kid = HttpContext.Session.GetInt32("id");
             int asiId= Convert.ToInt32(idKul);// ***

            
             System.Console.WriteLine("kid : " + kid);
             var user = _kullaniciVeri.GetById(kid);
             var userCar =_kullaniciVeri.GetKullaniciArabalaris(user);
             var son30= _yollarMongoDb.Son30DakikaVerileri(userCar[0].Araba,user);
             var arabalarVeYollari = _yollarMongoDb.ArabalarinYollari(user);
             var tt=_yollarMongoDb.forDate(userCar[0].Araba);
             var tt2=_yollarMongoDb.forDate(userCar[1].Araba);
             var forSaat = _yollarMongoDb.forHour(userCar[1].Araba);
             var bir =_yollarMongoDb.dt(tarihim,ilk);
             var iki = _yollarMongoDb.dt(tarihim,son);
             var hangiCar = _kullaniciVeri.GetByNameAraba(car);
             var tariheGore = _yollarMongoDb.ArabaninTariheGoreYollari(hangiCar,bir,iki);
             var forSaat2=  _yollarMongoDb.forHour(userCar[0].Araba);
             ViewBag.ilk = ilk;
             ViewBag.son = son;
             ViewBag.mesaj= car + " -->> " + ilk + " ile " + son + " saatleri arasındaki konumu";
             System.Console.WriteLine("tenimde: " + tarihim + " " + ilk + " " + " " + son);
           //  System.Console.WriteLine("-->gördüm :  " + iam[1][1].arabaid);
         //  System.Console.WriteLine("golaxxx : " + tariheGore[0].Date);
          
             var modelim = new KullaniciModel(){
                 kullanici=user,
                 KullaniciArabalarim=userCar,
                 SonOtuz=son30,
                 arabalarVeYollari=arabalarVeYollari,
                 forDate1 =tt,
                 forDate2=tt2,
                 yolum=tariheGore,
                 secilenAraba=hangiCar,
                 forHour1=forSaat,
                 forHour2=forSaat2
             };
            System.Console.WriteLine("as : " + tarihim);
            return View(modelim);
             System.Console.WriteLine("KULLANICIMMM : " + kadi + " " + kid);
            
        }

        [HttpGet]
        public IActionResult TarihYolu()
        {
            return View();
        }
        
    }
}

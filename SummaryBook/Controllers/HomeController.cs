using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SummaryBook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

//user listesi yap                                              +
//user listesini a outhantike görsün sadece                     +
//user kitap ekleme sayfası yap kitaplar admine düşsün          +
//yeni ekleme yapılınca küçük sayı yazsın
//özet yazdığım kitapları yap.                                  +
//Özet tablosu yap                                              +
//admin özet ekleyi değiştir                                    +
//eklenen kitaplardaki özet görüntüle kısmını yap.              +
// kitaba tıklandığında özet görünsün.
                        //1-tüm kitaplar                        +
                        //2-bnm yazdıklarım
                        //3-yeni eklenen kitaplar               +
                        //4.ana sayfada
// ana sayfa kitaplarını küçült                                 +
//Home -content alanını düznle
//kitaplar bölümüne arama butonu ekle
//kullanıncılar arası messajlaşmayı yap
//user ın silme düzenleme sayfasını ekle
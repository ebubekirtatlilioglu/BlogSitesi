using BlogSitesi.Areas.Identity.Data;
using BlogSitesi.Data;
using BlogSitesi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace BlogSitesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Kullanici> _userManager;
        private readonly UygulamaDbContext _db;

        public HomeController(ILogger<HomeController> logger, UserManager<Kullanici> userManager, UygulamaDbContext db)
        {
            _logger = logger;
            _userManager=userManager;
            _db=db;
        }

        public IActionResult Index()
        {

            ViewBag.Konular = _db.Konular.ToList();

            var makaleler = _db.Makale.Include(x => x.Konular).ToList();

            return View(makaleler);

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

        [Authorize]
        public IActionResult MakaleOlustur()
        {
            ViewBag.Konular = _db.Konular.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult MakaleOlustur(Makale makale, List<int> Konular)
        {
            foreach (var id in Konular)
            {
                var konu = _db.Konular.Find(id);
                makale.Konular.Add(konu);
            }

            makale.OkunmaSuresi = 2d;
            makale.KullaniciId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _db.Makale.Add(makale);
            _db.SaveChanges();
            ViewBag.Konular = _db.Konular.ToList();
            return View();
        }

        public IActionResult MakaleListele(int id)
        {
            if (id == 0)
            {
                ViewBag.Konular = _db.Konular.ToList();

                var makaleler = _db.Makale.Include(x => x.Konular).ToList();

                return View(makaleler);
            }

            var konu = _db.Konular
                .Include(x => x.Makaleler)
                .FirstOrDefault(x => x.Id == id);

            return View(konu.Makaleler);
        }

        public IActionResult KonuListele()
        {

            var konular = _db.Konular.Include(x => x.Makaleler).ToList();

            return View(konular);
        }

        public IActionResult Hakkimizda()
        {

            var konular = _db.Konular.Include(x => x.Makaleler).ToList();

            return View(konular);
        }

        public IActionResult MakaleOku(int id)
        {

            var makale = _db.Makale.Find(id);

            return View(makale);
        }
    }
}
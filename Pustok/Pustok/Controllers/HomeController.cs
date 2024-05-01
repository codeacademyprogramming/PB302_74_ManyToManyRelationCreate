using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Models;
using Pustok.ViewModels;
using System.Diagnostics;

namespace Pustok.Controllers
{
    public class HomeController : Controller
    {
        private readonly PustokDbContext _context;
        private readonly CountService countService;
        private readonly CountManageService countManageService;

        public HomeController(PustokDbContext context, CountService countService,CountManageService countManageService)
        {
            _context = context;
            countService = countService;
            this.countManageService = countManageService;
        }
        public IActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel
            {
                FeaturedBooks = _context.Books.Include(x => x.Author).Include(x=>x.BookImages.Where(bi=>bi.Status!=null)).Where(x => x.IsFeatured).Take(10).ToList(),
                NewBooks = _context.Books.Include(x => x.Author).Include(x => x.BookImages.Where(bi => bi.Status != null)).Where(x => x.IsNew).Take(10).ToList(),
                DiscountedBooks = _context.Books.Include(x => x.Author).Include(x => x.BookImages.Where(bi => bi.Status != null)).Where(x => x.DiscountPercent > 0).OrderByDescending(x=>x.DiscountPercent).Take(10).ToList(),
            };

            return View(vm);
        }

        public IActionResult Add()
        {
            countService.Add();
            countService.Add();
            countService.Add();

            countManageService.Add();
            countManageService.Add();


            return Json(new {count= countManageService.Count});
        }

       
    }
}

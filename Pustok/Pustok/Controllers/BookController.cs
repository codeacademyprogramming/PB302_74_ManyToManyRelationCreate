using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Models;

namespace Pustok.Controllers
{
    public class BookController : Controller
    {
        private readonly PustokDbContext _context;
        private readonly CountService countService;
        private readonly CountManageService countManageService;

        public BookController(PustokDbContext context, CountService countService, CountManageService countManageService)
        {
            _context = context;
            this.countService = countService;
            this.countManageService = countManageService;
        }
        public IActionResult GetBookById(int id)
        {
            Book book = _context.Books.Include(x => x.Genre).Include(x=>x.BookImages.Where(x=>x.Status==true)).FirstOrDefault(x => x.Id == id);
            return PartialView("_BookModalPartial",book);
        }


        public IActionResult Add()
        {
            countService.Add();
            countService.Add();
            countService.Add();

            countManageService.Add();
            countManageService.Add();


            return Json(new { count = countService.Count });
        }
    }
}

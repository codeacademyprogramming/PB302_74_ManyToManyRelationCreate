using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.Areas.Manage.ViewModels;
using Pustok.Models;

namespace Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class GenreController : Controller
    {
        private readonly PustokDbContext _context;

        public GenreController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            var query = _context.Genres.Include(x => x.Books);
            return View(PaginatedList<Genre>.Create(query,page,2));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            if (!ModelState.IsValid)
             {
                return View(genre);
            }

            if(_context.Genres.Any(x=>x.Name == genre.Name))
            {
                ModelState.AddModelError("Name", "Genre already exists!");
                return View(genre);
            }

            _context.Genres.Add(genre);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Genre genre = _context.Genres.Find(id);

            if (genre == null) return RedirectToAction("Error", "NotFound");

            return View(genre);
        }

        [HttpPost]
        public IActionResult Edit(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View(genre);
            }

            Genre existGenre = _context.Genres.Find(genre.Id);

            if (existGenre == null) return RedirectToAction("Error", "NotFound");

            if(_context.Genres.Any(x=>x.Name == genre.Name))
            {
                ModelState.AddModelError("Name", "Genre already exists!");
                return View(genre);
            }

            existGenre.Name = genre.Name;
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}

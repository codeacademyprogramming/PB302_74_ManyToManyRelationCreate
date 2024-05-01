using Pustok.Models;

namespace Pustok.Services
{
    public class LayoutService
    {
        private readonly PustokDbContext _context;

        public LayoutService(PustokDbContext context)
        {
            _context = context;
        }
        public List<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }

        public Dictionary<String,String> GetSettings() { 
            return _context.Settings.ToDictionary(x=>x.Key, x => x.Value);  
        }
    }
}

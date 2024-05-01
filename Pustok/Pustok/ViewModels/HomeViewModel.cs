using Pustok.Models;

namespace Pustok.ViewModels
{
    public class HomeViewModel
    {
        public List<Book> FeaturedBooks { get; set; }
        public List<Book> NewBooks { get; set; }
        public List<Book> DiscountedBooks { get; set; }

    }
}

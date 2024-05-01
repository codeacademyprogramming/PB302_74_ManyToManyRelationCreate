using System.ComponentModel.DataAnnotations.Schema;

namespace Pustok.Models
{

    [Table(name:"Tags")]
    public class Tag:BaseEntity
    {
        public string Name { get; set; }
        public List<BookTag>? Tags { get; set; }
    }
}

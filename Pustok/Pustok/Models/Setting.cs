using System.ComponentModel.DataAnnotations;

namespace Pustok.Models
{
    public class Setting
    {
        [Key]
        public string Key { get; set; }
        [MaxLength(500)]
        public string Value { get; set; }
    }
}

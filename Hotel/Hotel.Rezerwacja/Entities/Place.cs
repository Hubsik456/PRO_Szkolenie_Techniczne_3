using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Rezerwacja.Entities
{
    [Table("Places", Schema = "w67259_PRO_ST3")]
    public class Place
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        public string Address { get; set; }

        public string Desciption { get; set; } = string.Empty;
    }
}

//using Hotel.Rezerwacja.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Rezerwacja.Entities
{
    [Table("Reservations", Schema = "w67259_PRO_ST3")]
    public class Reservation
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int ClientID { get; set; }

        [Required]
        public ICollection<Place> Place { get; set; } = new List<Place>();

        public bool IsConfirmed { get; set; }

        [Column(TypeName="money")]
        public decimal Price { get; set; }
    }
}

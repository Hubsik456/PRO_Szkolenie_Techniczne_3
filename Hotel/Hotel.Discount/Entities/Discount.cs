using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Zniżka.Entities
{
    [Table("Discounts", Schema = "w67259_PRO_ST3")]
    public class Discount
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int ReservationID { get; set; }

        [Required]
        public float DiscountPercent { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations;

namespace MarucciHotel.Models
{
    public class Pensione
    {
        public int ID { get; set; }
        [Display(Name = "Pensione")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Tipologia { get; set; }
        [Display(Name = "Prezzo")]
        public double? Prezzo { get; set; }
    }
}

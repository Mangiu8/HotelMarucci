using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MarucciHotel.Models
{
    public class Clienti
    {
        public int ID { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Nome { get; set; }
        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Cognome { get; set; }
        [Display(Name = "Codice Fiscale")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Il campo deve contenere 16 caratteri")]
        public string Cod_Fisc { get; set; }
        [Display(Name = "Città")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Citta { get; set; }
        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Il campo deve contenere 2 caratteri")]
        public string Provincia { get; set; }
        [Display(Name = "Email")]
        [Remote("EmailValidator", "Home", ErrorMessage = "L'Email non e' valida")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Email { get; set; }
        [Display(Name = "Telefono")]
        public string? Telefono { get; set; }
        [Display(Name = "Cellulare")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Cellulare { get; set; }

    }
}

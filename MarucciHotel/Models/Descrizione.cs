using System.ComponentModel.DataAnnotations;
namespace MarucciHotel.Models
{
    public enum Descrizione
    {
        [Display(Name = "Pulizia")]
        Pulizia,
        [Display(Name = "Cambio biancheria")]
        CambioBiancheria,
        [Display(Name = "Cambio asciugamani")]
        CambioAsciugamani,
        [Display(Name = "Internet")]
        Internet,
        [Display(Name = "Compagnia")]
        Compagnia,
        [Display(Name = "Colazione in Camera")]
        ColazioneInCamera,
        [Display(Name = "Massaggio Hot")]
        MassaggioHot,
    }
}

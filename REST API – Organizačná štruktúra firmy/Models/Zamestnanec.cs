using System.ComponentModel.DataAnnotations;

namespace REST_API___Organizačná_štruktúra_firmy.Models
{
    public class Zamestnanec
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30, ErrorMessage = "Meno moze mat najviac 30 znakov.")]
        public string? Meno { get; set; }

        [StringLength(30, ErrorMessage = "Priezvisko moze mat najviac 30 znakov.")]
        public string? Priezvisko { get; set; }

        [StringLength(30, ErrorMessage = "Titul moze mat najviac 30 znakov.")]
        public string? Titul {  get; set; }

        [StringLength(15, ErrorMessage = "Telefon moze mat najviac 15 znakov.")]
        [RegularExpression("^+?[0-9]{1,14}$", ErrorMessage = "Telefon moze obsahovat iba cislice a +")]
        public string? Telefon { get; set; }

        [StringLength(30, ErrorMessage = "Email moze mat najviac 50 znakov.")]
        [EmailAddress(ErrorMessage = "Neplatna emailova adresa.")]
        public string? Email { get; set; }

    }
}

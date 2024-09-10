using System.ComponentModel.DataAnnotations;

namespace REST_API___Organizačná_štruktúra_firmy.Models
{
    public class Uzol
    {

        [Key]
        public int Kod { get; set; }

        [StringLength(30, ErrorMessage = "Nazov moze mat najviac 30 znakov.")]
        public string? Nazov { get; set; }

        [Required(ErrorMessage = "Veduci je povinny.")]
        public int VeduciId { get; set; }

        [Required(ErrorMessage = "Typ uzla je povinne.")]
        [RegularExpression("^[FDPO]^", ErrorMessage = "Typ moze byt iba F (firma), D (divizia), P (projekt) a O (oddelenie).")]
        public char Typ { get; set; } // F - firma, D - divizia, P - projekt, O - oddelenie

        public int? RodicUzol { get; set; }
    }
}

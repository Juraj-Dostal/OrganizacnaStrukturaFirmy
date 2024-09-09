﻿using System.ComponentModel.DataAnnotations;

namespace REST_API___Organizačná_štruktúra_firmy.Models
{
    public class Utvar
    {

        [Key]
        public int Kod { get; set; }
        public string? Nazov { get; set; }
        public int VeduciId { get; set; }
        public char Typ { get; set; }
        public int? RodicUtvar { get; set; }
    }
}

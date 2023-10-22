using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationNefc.Models
{
    public class Vehicle
    {
        [Key]
        [Column(TypeName ="nvarchar(12)")]
        public int RegNo { get; set; }

        [Required(ErrorMessage = "Model Name is required.")]
        [Display(Name = "Model Name")]
        [Column(TypeName = "nvarchar(255)")]
        public string ModelName { get; set; }

        [Display(Name = "Number of Seats")]
        [Range(0, 999, ErrorMessage = "Number of Seats should be between 0 and 999.")]
        [Column(TypeName = "nvarchar(255)")] public int? NumSeats { get; set; }

        [Display(Name = "Is Single Color")]
        public bool IsSingleColor { get; set; }

        public List<Color> Colors { get; set; } // List of colors
    }
}

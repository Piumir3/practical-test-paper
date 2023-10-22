using System.ComponentModel.DataAnnotations;

namespace WebApplicationNefc.Models
{
    public class Color
    {
        [Key]
        public int ColorID { get; set; }
        
        [Required(ErrorMessage = "Color Name is required.")]
        [Display(Name = "Color Name")]
        [StringLength(255)]
        public string ColorName { get; set; }

        public int VehicleRegNo { get; set; }

        [Display(Name = "Vehicle Registration Number")]
        public virtual Vehicle Vehicle { get; set; }
    }
}

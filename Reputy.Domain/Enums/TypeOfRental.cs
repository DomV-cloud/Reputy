using System.ComponentModel.DataAnnotations;

namespace Reputy.Domain.Enums
{
    public enum TypeOfRental
    {
        // using << ? to combine?
        [Display(Name= "Flat")]
        Flat = 1,

        [Display(Name = "House")]
        House = 2,

        [Display(Name = "Roomates")]
        Roomates = 3,

        [Display(Name = "Roomates")]
        Atelier = 4,
        
        [Display(Name = "Apartman")]
        Apartman = 5
    }
}

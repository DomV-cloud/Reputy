using System.ComponentModel.DataAnnotations;

namespace Reputy.Domain.Enums
{
    public enum Role
    {
        [Display(Name = "Tenant")]
        Tenant = 1,
        [Display(Name = "LandLord")]
        LandLord = 2,
    }
}

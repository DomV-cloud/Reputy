using System.ComponentModel.DataAnnotations;

namespace Reputy.Domain.Enums
{
    public enum Disposition
    {
        [Display(Name = "1+1")]
        OnePlusOne = 1,

        [Display(Name = "1kk")]
        OneKK = 2,

        [Display(Name = "2+1")]
        TwoPlusOne = 3,

        [Display(Name = "2kk")]
        TwoKK = 4,

        [Display(Name = "3+1")]
        ThreePlusOne = 5,

        [Display(Name = "3kk")]
        ThreeKK = 6,

        [Display(Name = "4+1")]
        FourPlusOne = 7,

        [Display(Name = "4kk")]
        FourKK = 8,

        [Display(Name = "5+1")]
        FivePlusOne = 9,

        [Display(Name = "5kk")]
        FiveKK = 10,
    }
}

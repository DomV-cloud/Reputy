

namespace Reputy.Application.PaginationFilter
{
    public class AdvertisementFilter : BasePaginationFilter
    {
        public string? Location { get; set; }
        public decimal? Size { get; set; }
        public decimal? Price { get; set; }
        public string? Disposition { get; set; }
    }
}

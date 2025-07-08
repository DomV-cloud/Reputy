namespace Reputy.Application.Pagination
{
    public class PagedResponse<T> : BaseResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);
        public int TotalRecords { get; set; }
        
        public PagedResponse(
            T data,
            int pageNumber,
            int pageSize,
            int totalRecords
            ) : base(data)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.Message = null;
            this.Succeeded = true;
            this.Errors = null;
            this.TotalRecords = totalRecords;
        }
    }
}

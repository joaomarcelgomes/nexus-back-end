namespace Backend.Domain.Shared.Pagination
{
    public class PaginationFilter
    {
        public int PageNumber { get; }
        public int PageSize { get; }

        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
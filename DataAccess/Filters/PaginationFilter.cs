namespace Api.Filters
{
    /// <summary>
    /// Defines a filter used in pagination.
    /// </summary>
    public class PaginationFilter
    {
        /// <summary>
        /// Page number requested. Defaults to one.
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// The number of records per page. Defaults to maximum value ten.
        /// </summary>
        public int PageSize { get; set; }
        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
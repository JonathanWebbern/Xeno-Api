using System.Net;

namespace DataAccess.Responses
{
    /// <summary>
    /// Defines the structure of a paginated generic Json response.
    /// </summary>
    /// <typeparam name="T">A model e.g. AlienModel.</typeparam>
    public class PagedResponse<T> : Response<T> 
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string FirstPage { get; set; }
        public string LastPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public string NextPage { get; set; }
        public string PreviousPage { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.Message = "Success";
            this.Succeeded = true;
            this.StatusCode = HttpStatusCode.OK;
        }
    }
}

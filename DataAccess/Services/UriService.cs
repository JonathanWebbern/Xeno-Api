using Api.Filters;
using Microsoft.AspNetCore.WebUtilities;

namespace DataAccess.Services
{
    public class UriService : IUriService
    {
        public string GetPageUri(PaginationFilter filter, string route)
        {
            var modifiedUri = QueryHelpers.AddQueryString(route ,"pageNumber", filter.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", filter.PageSize.ToString());
            return modifiedUri;
        }
    }
}

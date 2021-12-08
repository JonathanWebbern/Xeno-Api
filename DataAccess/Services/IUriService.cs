using Api.Filters;
using System;

namespace DataAccess.Services
{
    public interface IUriService
    {
        string GetPageUri(PaginationFilter filter, string route);
    }
}

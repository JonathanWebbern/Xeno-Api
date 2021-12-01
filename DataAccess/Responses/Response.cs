using System.Net;

namespace DataAccess.Responses
{
    /// <summary>
    /// Defines the structure of a generic Json response.
    /// </summary>
    public class Response<T>
    {
        public Response()
        {

        }
        public Response(T data)
        {
            Data = data;
            Message = "Success";
            Succeeded = true;
            StatusCode = HttpStatusCode.OK;
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}

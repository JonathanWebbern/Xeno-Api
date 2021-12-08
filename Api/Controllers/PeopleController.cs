using Api.Filters;
using DataAccess.Helpers;
using DataAccess.Managers;
using DataAccess.Models;
using DataAccess.Responses;
using DataAccess.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Api.Controllers
{
    /// <summary>
    /// Contains Methods for fetching data related to People.
    /// </summary>
    [RoutePrefix("api/people")]
    public class PeopleController : ApiController
    {
        private Response<PeopleModel> _response;
        private readonly PeopleManager _peopleManager;
        private readonly IUriService _uriService;
        public PeopleController()
        {
            _uriService = new UriService();
            _peopleManager = new PeopleManager();
        }

        /// <summary>
        /// Gets a list of all People.
        /// </summary>
        /// <returns>A list of PeopleModels.</returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<PeopleModel>))]
        public HttpResponseMessage Get([FromUri] PaginationFilter filter)
        {
            var filtered = filter == null ? new PaginationFilter() :
                new PaginationFilter(filter.PageNumber, filter.PageSize);
            var people = _peopleManager.GetPeople(filtered);
            var docCount = _peopleManager.GetCount();
            var pagesResponse = PaginationHelper.CreatePagedResponse<PeopleModel>(people, docCount, filtered, _uriService, "api/people");
            return Request.CreateResponse(HttpStatusCode.OK, pagesResponse);
        }

        /// <summary>
        /// Gets a Person by their numerical Id.
        /// </summary>
        /// <param name="id">Id of a Person.</param>
        /// <returns>A PeopleModel.</returns>
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(PeopleModel))]
        public HttpResponseMessage GetById(int id)
        {
            var person = _peopleManager.GetPeople(id);
            if (person == null)
            {
                _response = new Response<PeopleModel>(person)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = string.Format("Person with a Id of {0} was not found", id),
                    Succeeded = false
                };
                return Request.CreateResponse(HttpStatusCode.NotFound, _response);
            }
            _response = new Response<PeopleModel>(person);
            return Request.CreateResponse(HttpStatusCode.OK, _response);
        }

        /// <summary>
        /// Gets a Person by their name.
        /// </summary>
        /// <param name="name">Name of a Person</param>
        /// <returns>A PersonModel</returns>
        [HttpGet]
        [Route("{name}")]
        [ResponseType(typeof(PeopleModel))]
        public HttpResponseMessage GetByName(string name)
        {
            var person = _peopleManager.GetPeopleByName(name);
            if (person == null)
            {
                _response = new Response<PeopleModel>(person)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = string.Format("Person with a name of {0} was not found", name),
                    Succeeded = false
                };
                return Request.CreateResponse(HttpStatusCode.NotFound, _response);
            }
            _response = new Response<PeopleModel>(person);
            return Request.CreateResponse(HttpStatusCode.OK, _response);
        }
    }
}
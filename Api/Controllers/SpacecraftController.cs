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

namespace Api.Controllers
{
    /// <summary>
    /// Contains Methods for fetching data related to Spacecraft.
    /// </summary>
    [RoutePrefix("api/spacecraft")]
    public class SpacecraftController : ApiController
    {
        private Response<SpacecraftModel> _response;
        private readonly SpacecraftManager _spacecraftManager;
        private readonly IUriService _uriService;
        public SpacecraftController()
        {
            _uriService = new UriService();
            _spacecraftManager = new SpacecraftManager();
        }

        /// <summary>
        /// Gets a list of all Spacecraft.
        /// </summary>
        /// <returns>A list of Spacecraft Models.</returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<SpacecraftModel>))]
        public HttpResponseMessage Get([FromUri] PaginationFilter filter)
        {
            var filtered = filter == null ? new PaginationFilter() :
                new PaginationFilter(filter.PageNumber, filter.PageSize);
            var spacecraft = _spacecraftManager.GetSpacecraft(filtered);
            var docCount = _spacecraftManager.GetCount();
            var pagedResponse = PaginationHelper.CreatePagedResponse<SpacecraftModel>(spacecraft, docCount, filtered, _uriService, "api/spacecraft");
            return Request.CreateResponse(HttpStatusCode.OK, pagedResponse);
        }

        /// <summary>
        /// Gets a Spacecraft by its numerical Id.
        /// </summary>
        /// <param name="id">Id of Spacecraft.</param>
        /// <returns>A Spacecraft Model.</returns>
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(SpacecraftModel))]
        public HttpResponseMessage GetById(int id)
        {
            var spacecraft = _spacecraftManager.GetSpacecraft(id);
            if (spacecraft == null)
            {
                _response = new Response<SpacecraftModel>(spacecraft)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = string.Format("Spacecraft with an id of {0} was not found", id),
                    Succeeded = false
                };
                return Request.CreateResponse(HttpStatusCode.NotFound, _response);
            }
            _response = new Response<SpacecraftModel>(spacecraft);
            return Request.CreateResponse(HttpStatusCode.OK, _response);
        }

        /// <summary>
        /// Gets a Spacecraft by its name.
        /// </summary>
        /// <param name="name">Name of a Spacecraft.</param>
        /// <returns>A Spacecraft Model.</returns>
        [HttpGet]
        [Route("{name}")]
        [ResponseType(typeof(SpacecraftModel))]
        public HttpResponseMessage GetByName(string name)
        {
            var spacecraft = _spacecraftManager.GetSpacecraftByName(name);
            if (spacecraft == null)
            {
                _response = new Response<SpacecraftModel>(spacecraft)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = string.Format("Spacecraft with an name of {0} was not found", name),
                    Succeeded = false
                };
                return Request.CreateResponse(HttpStatusCode.NotFound, _response);
            }
            _response = new Response<SpacecraftModel>(spacecraft);
            return Request.CreateResponse(HttpStatusCode.OK, _response);
        }
    }
}
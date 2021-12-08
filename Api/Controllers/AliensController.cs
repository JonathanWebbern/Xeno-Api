using DataAccess.Managers;
using DataAccess.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Web.Http.Description;
using DataAccess.Responses;
using DataAccess.Services;
using Api.Filters;
using DataAccess.Helpers;

namespace Api.Controllers
{
    /// <summary>
    /// Contains Methods for fetching data related to Aliens.
    /// </summary>
    [RoutePrefix("api/aliens")]
    public class AliensController : ApiController
    {
        private Response<AlienModel> _response;
        private readonly AlienManager _alienManager;
        private readonly IUriService _uriService;
        public AliensController()
        {
            _uriService = new UriService();
            _alienManager = new AlienManager();
        }

        /// <summary>
        /// Gets a list of all Aliens.
        /// </summary>
        /// <returns>A list of Alien Models.</returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<AlienModel>))]
        public HttpResponseMessage Get([FromUri] PaginationFilter filter)
        {
            var filtered = filter == null ? new PaginationFilter() :
                new PaginationFilter(filter.PageNumber, filter.PageSize);
            var aliens = _alienManager.GetAliens(filtered);
            var docCount = _alienManager.GetCount();
            var pagedResponse = PaginationHelper.CreatePagedResponse<AlienModel>(aliens, docCount, filtered, _uriService, "api/aliens");
            return Request.CreateResponse(HttpStatusCode.OK, pagedResponse);
        }

        /// <summary>
        /// Gets an Alien by its numerical Id.
        /// </summary>
        /// <param name="id">Id of an Alien.</param>
        /// <returns>An Alien Model.</returns>
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(AlienModel))]
        public HttpResponseMessage Get(int id)
        {
            var alien = _alienManager.GetAlien(id);
            if (alien == null)
            {
                _response = new Response<AlienModel>(alien)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = string.Format("Alien with an id of {0} was not found", id),
                    Succeeded = false
                };
                return Request.CreateResponse(HttpStatusCode.NotFound, _response);
            }
            _response = new Response<AlienModel>(alien);
            return Request.CreateResponse(HttpStatusCode.OK, _response);
        }

        /// <summary>
        /// Gets an Alien by its name.
        /// </summary>
        /// <param name="name">Name of an Alien.</param>
        /// <returns>An AlienModel.</returns>
        [HttpGet]
        [Route("{name}")]
        [ResponseType(typeof(AlienModel))]
        public HttpResponseMessage Get(string name)
        {
            var alien = _alienManager.GetAlienByName(name);
            if (alien == null)
            {
                _response = new Response<AlienModel>(alien)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = string.Format("Alien with a name of {0} was not found", name),
                    Succeeded = false
                };
                return Request.CreateResponse(HttpStatusCode.NotFound, _response);
            }
            _response = new Response<AlienModel>(alien);
            return Request.CreateResponse(HttpStatusCode.OK, _response);
        }
    }
}
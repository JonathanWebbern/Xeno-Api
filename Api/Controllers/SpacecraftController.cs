using DataAccess.Managers;
using DataAccess.Models;
using DataAccess.Responses;
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
        private Response<List<SpacecraftModel>> _responses;
        private readonly SpacecraftManager spacecraftManager;
        public SpacecraftController()
        {
            spacecraftManager = new SpacecraftManager();
        }

        /// <summary>
        /// Gets a list of all Spacecraft.
        /// </summary>
        /// <returns>A list of Spacecraft Models.</returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<SpacecraftModel>))]
        public HttpResponseMessage Get()
        {
            var spacecraft = spacecraftManager.GetSpacecraft();
            _responses = new Response<List<SpacecraftModel>>(spacecraft);
            return Request.CreateResponse(HttpStatusCode.OK, _responses);
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
            var spacecraft = spacecraftManager.GetSpacecraft(id);
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
            var spacecraft = spacecraftManager.GetSpacecraftByName(name);
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
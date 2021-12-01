using DataAccess.Managers;
using DataAccess.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Web.Http.Description;
using DataAccess.Responses;

namespace Api.Controllers
{
    /// <summary>
    /// Contains Methods for fetching data related to Aliens.
    /// </summary>
    [RoutePrefix("api/aliens")]
    public class AliensController : ApiController
    {
        private Response<AlienModel> _response;
        private Response<List<AlienModel>> _responses;
        private readonly AlienManager alienManager;
        public AliensController()
        {
            alienManager = new AlienManager();
        }

        /// <summary>
        /// Gets a list of all Aliens.
        /// </summary>
        /// <returns>A list of Alien Models.</returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<AlienModel>))]
        public HttpResponseMessage Get()
        {
            var aliens = alienManager.GetAliens();
            _responses = new Response<List<AlienModel>>(aliens);
            return Request.CreateResponse(HttpStatusCode.OK, _responses);
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
            var alien = alienManager.GetAlien(id);
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
            var alien = alienManager.GetAlienByName(name);
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
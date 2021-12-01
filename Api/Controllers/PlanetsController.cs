﻿using DataAccess.Managers;
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
    /// Contains Methods for fetching data related to Planets.
    /// </summary>
    [RoutePrefix("api/planets")]
    public class PlanetsController : ApiController
    {
        private Response<PlanetModel> _response;
        private Response<List<PlanetModel>> _responses;
        private readonly PlanetManager planetManager;
        public PlanetsController()
        {
            planetManager = new PlanetManager();
        }

        /// <summary>
        /// Gets a list of all Planets.
        /// </summary>
        /// <returns>A list of PlanetModels.</returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<PlanetModel>))]
        public HttpResponseMessage Get()
        {
            var planets = planetManager.GetPlanets();
            _responses = new Response<List<PlanetModel>>(planets);
            return Request.CreateResponse(HttpStatusCode.OK, _responses);
        }

        /// <summary>
        /// Gets a Planet by its numerical Id.
        /// </summary>
        /// <param name="id">Id of Planet.</param>
        /// <returns>A Planet Model.</returns>
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(PlanetModel))]
        public HttpResponseMessage Get(int id)
        {
            var planet = planetManager.GetPlanet(id);
            if (planet == null)
            {
                _response = new Response<PlanetModel>(planet)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = string.Format("Planet with an id of {0} was not found", id),
                    Succeeded = false
                };
                return Request.CreateResponse(HttpStatusCode.NotFound, _response);
            }
            _response = new Response<PlanetModel>(planet);
            return Request.CreateResponse(HttpStatusCode.OK, _response);
        }

        /// <summary>
        /// Gets a Planet by its name.
        /// </summary>
        /// <param name="name">Name of a Planet.</param>
        /// <returns>A PlanetModel.</returns>
        [HttpGet]
        [Route("{name}")]
        [ResponseType(typeof(PlanetModel))]
        public HttpResponseMessage GetByName(string name)
        {
            var planet = planetManager.GetPlanetByName(name);
            if (planet == null)
            {
                _response = new Response<PlanetModel>(planet)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = string.Format("Planet with a name of {0} was not found", name),
                    Succeeded = false
                };
                return Request.CreateResponse(HttpStatusCode.NotFound, _response);
            }
            _response = new Response<PlanetModel>(planet);
            return Request.CreateResponse(HttpStatusCode.OK, _response);
        }
    }
}
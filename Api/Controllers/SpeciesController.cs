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
    /// Contains Methods for fetching data related to Species.
    /// </summary>
    [RoutePrefix("api/species")]
    public class SpeciesController : ApiController
    {
        private Response<SpeciesModel> _response;
        private Response<List<SpeciesModel>> _responses;
        private readonly SpeciesManager speciesManager;
        public SpeciesController()
        {
            speciesManager = new SpeciesManager();
        }

        /// <summary>
        /// Gets a list of all Species.
        /// </summary>
        /// <returns>A list of Species Models.</returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<SpeciesModel>))]
        public HttpResponseMessage Get()
        {
            var species = speciesManager.GetSpecies();
            _responses = new Response<List<SpeciesModel>>(species);
            return Request.CreateResponse(HttpStatusCode.OK, _responses);
        }

        /// <summary>
        /// Gets a Species by its numerical Id.
        /// </summary>
        /// <param name="id">Id of a Species.</param>
        /// <returns>A SpeciesModel.</returns>
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(SpeciesModel))]
        public HttpResponseMessage Get(int id)
        {
            var species = speciesManager.GetSpecies(id);
            if (species == null)
            {
                _response = new Response<SpeciesModel>(species)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = string.Format("Species with an id of {0} was not found", id),
                    Succeeded = false
                };
                return Request.CreateResponse(HttpStatusCode.NotFound, _response);
            }
            _response = new Response<SpeciesModel>(species);
            return Request.CreateResponse(HttpStatusCode.OK, _response);
        }

        /// <summary>
        /// Gets a Species by its name.
        /// </summary>
        /// <param name="name">Name of the Species.</param>
        /// <returns>A SpeciesModel</returns>
        [HttpGet]
        [Route("{name}")]
        [ResponseType(typeof(SpeciesModel))]
        public HttpResponseMessage Get(string name)
        {
            var species = speciesManager.GetSpeciesByName(name);
            if (species == null)
            {
                _response = new Response<SpeciesModel>(species)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = string.Format("Species with an name of {0} was not found", name),
                    Succeeded = false
                };
                return Request.CreateResponse(HttpStatusCode.NotFound, _response);
            }
            _response = new Response<SpeciesModel>(species);
            return Request.CreateResponse(HttpStatusCode.OK, _response);
        }
    }
}
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
    /// Contains Methods for fetching data related to Films.
    /// </summary>
    [RoutePrefix("api/films")]
    public class FilmsController : ApiController
    {
        private Response<FilmModel> _response;
        private Response<List<FilmModel>> _responses;
        private readonly FilmManager filmManager;
        public FilmsController()
        {
            filmManager = new FilmManager();
        }

        /// <summary>
        /// Gets a list of all Films.
        /// </summary>
        /// <returns>A list of Film Models.</returns>
        /// 
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<FilmModel>))]
        public HttpResponseMessage Get()
        {
            var films = filmManager.GetFilms();
            _responses = new Response<List<FilmModel>>(films);
            return Request.CreateResponse(HttpStatusCode.OK, _responses);
        }

        /// <summary>
        /// Gets a Film by its numerical Id.
        /// </summary>
        /// <param name="id">Id of Film.</param>
        /// <returns>A Film Model.</returns>
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(FilmModel))]
        public HttpResponseMessage GetById(int id)
        {
            var film = filmManager.GetFilm(id);
            if (film == null)
            {
                _response = new Response<FilmModel>(film)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = string.Format("Film with an id of {0} was not found", id),
                    Succeeded = false
                };
                return Request.CreateResponse(HttpStatusCode.NotFound, _response);
            }
            _response = new Response<FilmModel>(film);
            return Request.CreateResponse(HttpStatusCode.OK, _response);
        }

        /// <summary>
        /// Gets a Film by its Title.
        /// </summary>
        /// <param name="title">Title of Film.</param>
        /// <returns>A Film Model.</returns>
        [HttpGet]
        [Route("{title}")]
        [ResponseType(typeof(FilmModel))]
        public HttpResponseMessage GetByName(string title)
        {
            var film = filmManager.GetFilmByTitle(title);
            if (film == null)
            {
                _response = new Response<FilmModel>(film)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = string.Format("Film with an title of {0} was not found", title),
                    Succeeded = false
                };
                return Request.CreateResponse(HttpStatusCode.NotFound, _response);
            }
            _response = new Response<FilmModel>(film);
            return Request.CreateResponse(HttpStatusCode.OK, _response);
        }
    }
}
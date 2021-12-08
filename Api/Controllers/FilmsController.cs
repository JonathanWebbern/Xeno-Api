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
    /// Contains Methods for fetching data related to Films.
    /// </summary>
    [RoutePrefix("api/films")]
    public class FilmsController : ApiController
    {
        private Response<FilmModel> _response;
        private readonly FilmManager _filmManager;
        private readonly IUriService _uriService;
        public FilmsController()
        {
            _uriService = new UriService();
            _filmManager = new FilmManager();
        }

        /// <summary>
        /// Gets a list of all Films.
        /// </summary>
        /// <returns>A list of Film Models.</returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<FilmModel>))]
        public HttpResponseMessage Get([FromUri] PaginationFilter filter)
        {
            var filtered = filter == null ? new PaginationFilter() :
                new PaginationFilter(filter.PageNumber, filter.PageSize);
            var films = _filmManager.GetFilms(filtered);
            var docCount = _filmManager.GetCount();
            var pagedResponse = PaginationHelper.CreatePagedResponse<FilmModel>(films, docCount, filtered, _uriService, "api/films");
            return Request.CreateResponse(HttpStatusCode.OK, pagedResponse);
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
            var film = _filmManager.GetFilm(id);
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
            var film = _filmManager.GetFilmByTitle(title);
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
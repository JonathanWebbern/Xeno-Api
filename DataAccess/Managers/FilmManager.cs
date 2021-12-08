using Api.Filters;
using DataAccess.Models;
using System.Collections.Generic;
using System.Configuration;

namespace DataAccess.Managers
{
    /// <summary>
    /// Manages calls to the Mongo database relating to Film data. 
    /// </summary>
    public class FilmManager
    {
        private readonly MongoCRUD dbClient;
        public FilmManager()
        {
            dbClient = new MongoCRUD(ConfigurationManager.AppSettings["dbName"]);
        }

        /// <summary>
        /// Gets all Films from collection.
        /// </summary>
        /// <returns>A list of FilmModels</returns>
        public List<FilmModel> GetFilms(PaginationFilter filter)
        {
            return dbClient.LoadCollection<FilmModel>("films", filter.PageSize, filter.PageNumber);
        }

        /// <summary>
        /// Gets a Film by its Id.
        /// </summary>
        /// <param name="id">The Films Id.</param>
        /// <returns>A FilmModel.</returns>
        public FilmModel GetFilm(int id)
        {
            return dbClient.LoadDocument<FilmModel>("films", id);
        }

        /// <summary>
        /// Gets a Film by its Name.
        /// </summary>
        /// <param name="title">The title of the Film.</param>
        /// <returns>A FilmModel.</returns>
        public FilmModel GetFilmByTitle(string title)
        {
            return dbClient.LoadDocumentByTitle<FilmModel>("films", title);
        }

        /// <summary>
        /// Gets count of all Film records.
        /// </summary>
        /// <returns>The count of all Film records.</returns>
        public int GetCount()
        {
            var count = dbClient.GetCount<FilmModel>("films");
            return (int)count;
        }
    }
}

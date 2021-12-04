using Api.Filters;
using DataAccess.Models;
using System.Collections.Generic;
using System.Configuration;

namespace DataAccess.Managers
{
    /// <summary>
    /// Manages calls to the Mongo database relating to People data. 
    /// </summary>
    public class PeopleManager
    {
        private readonly MongoCRUD dbClient;
        public PeopleManager()
        {
            dbClient = new MongoCRUD(ConfigurationManager.AppSettings["dbName"]);
        }

        /// <summary>
        /// Gets all People from collection.
        /// </summary>
        /// <returns>A list of PeopleModels.</returns>
        public List<PeopleModel> GetPeople(PaginationFilter filter)
        {
            return dbClient.LoadCollection<PeopleModel>("people", filter.PageSize, filter.PageNumber);
        }

        /// <summary>
        /// Gets a Person by their Id.
        /// </summary>
        /// <param name="id">The Persons Id.</param>
        /// <returns>A PeopleModel.</returns>
        public PeopleModel GetPeople(int id)
        {
            return dbClient.LoadDocument<PeopleModel>("people", id);
        }

        /// <summary>
        /// Gets a Person by their Name.
        /// </summary>
        /// <param name="name">The name of the Person.</param>
        /// <returns>A PeopleModel.</returns>
        public PeopleModel GetPeopleByName(string name)
        {
            return dbClient.LoadDocument<PeopleModel>("people", name);
        }
    }
}

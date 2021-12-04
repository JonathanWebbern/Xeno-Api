using DataAccess.Models;
using System.Collections.Generic;
using System.Configuration;

namespace DataAccess.Managers
{
    /// <summary>
    /// Manages calls to the Mongo database relating to Species data. 
    /// </summary>
    public class SpeciesManager
    {
        private readonly MongoCRUD dbClient;
        public SpeciesManager()
        {
            dbClient = new MongoCRUD(ConfigurationManager.AppSettings["dbName"]);
        }

        /// <summary>
        /// Gets all Species from the collection.
        /// </summary>
        /// <returns>A list of SpeciesModels.</returns>
        public List<SpeciesModel> GetSpecies()
        {
            return dbClient.LoadCollection<SpeciesModel>("species", 5, 1);
        }

        /// <summary>
        /// Gets a Species by its Id.
        /// </summary>
        /// <param name="id">The Id of the Species.</param>
        /// <returns>A SpeciesModel.</returns>
        public SpeciesModel GetSpecies(int id)
        {
            return dbClient.LoadDocument<SpeciesModel>("species", id);
        }

        /// <summary>
        /// Gets a Species by its Name.
        /// </summary>
        /// <param name="name">The name of the Species.</param>
        /// <returns>A SpeciesModel.</returns>
        public SpeciesModel GetSpeciesByName(string name)
        {
            return dbClient.LoadDocument<SpeciesModel>("species", name);
        }
    }
}

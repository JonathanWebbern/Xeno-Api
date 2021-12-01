using DataAccess.Models;
using System.Collections.Generic;
using System.Configuration;

namespace DataAccess.Managers
{
    /// <summary>
    /// Manages calls to the Mongo database relating to Planet data. 
    /// </summary>
    public class PlanetManager
    {
        private readonly MongoCRUD dbClient;
        public PlanetManager()
        {
            dbClient = new MongoCRUD(ConfigurationManager.AppSettings["dbName"]);
        }

        /// <summary>
        /// Gets all Planets from collection.
        /// </summary>
        /// <returns>A list of PlanetModels.</returns>
        public List<PlanetModel> GetPlanets()
        {
            return dbClient.LoadCollection<PlanetModel>("planets");
        }

        /// <summary>
        /// Gets a Planet by its Id.
        /// </summary>
        /// <param name="id">Id of the Planet.</param>
        /// <returns>A PlanetModel.</returns>
        public PlanetModel GetPlanet(int id)
        {
            return dbClient.LoadDocument<PlanetModel>("planets", id);
        }

        /// <summary>
        /// Gets a Planet by its Name.
        /// </summary>
        /// <param name="name">name of the Planet.</param>
        /// <returns>A PlanetModel.</returns>
        public PlanetModel GetPlanetByName(string name)
        {
            return dbClient.LoadDocument<PlanetModel>("planets", name);
        }
    }
}

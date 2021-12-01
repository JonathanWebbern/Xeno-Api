using DataAccess.Models;
using System.Collections.Generic;
using System.Configuration;

namespace DataAccess.Managers
{
    /// <summary>
    /// Manages calls to the Mongo database relating to Spacecraft data. 
    /// </summary>
    public class SpacecraftManager
    {
        private readonly MongoCRUD dbClient;
        public SpacecraftManager()
        {
            dbClient = new MongoCRUD(ConfigurationManager.AppSettings["dbName"]);
        }

        /// <summary>
        /// Gets all Spacecraft from collection.
        /// </summary>
        /// <returns>A List of SpacecraftModels.</returns>
        public List<SpacecraftModel> GetSpacecraft()
        {
            return dbClient.LoadCollection<SpacecraftModel>("spacecraft");
        }

        /// <summary>
        /// Gets a Spacecraft by its Id.
        /// </summary>
        /// <param name="id">The Spacecrafts Id.</param>
        /// <returns>A SpacecraftsModel.</returns>
        public SpacecraftModel GetSpacecraft(int id)
        {
            return dbClient.LoadDocument<SpacecraftModel>("spacecraft", id);
        }

        /// <summary>
        /// Gets a Spacecraft by its Name.
        /// </summary>
        /// <param name="name">Name of the Spacecraft.</param>
        /// <returns>A SpacecraftModel.</returns>
        public SpacecraftModel GetSpacecraftByName(string name)
        {
            return dbClient.LoadDocument<SpacecraftModel>("spacecraft", name);
        }
    }
}

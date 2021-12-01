using DataAccess.Models;
using System.Collections.Generic;
using System.Configuration;

namespace DataAccess.Managers
{
    /// <summary>
    /// Manages calls to the Mongo database relating to Alien data. 
    /// </summary>
    public class AlienManager
    {
        private readonly MongoCRUD dbClient;
        public AlienManager()
        {
            dbClient = new MongoCRUD(ConfigurationManager.AppSettings["dbName"]);
        }

        /// <summary>
        /// Gets all Aliens from collection.
        /// </summary>
        /// <returns>A list of AlienModels.</returns>
        public List<AlienModel> GetAliens()
        {
            return dbClient.LoadCollection<AlienModel>("aliens");
        }

        /// <summary>
        /// Gets an Alien by Id.
        /// </summary>
        /// <param name="id">Id of the Alien.</param>
        /// <returns>An AlienModel.</returns>
        public AlienModel GetAlien(int id)
        {
            return dbClient.LoadDocument<AlienModel>("aliens", id);
        }

        /// <summary>
        /// Gets an Alien by Name.
        /// </summary>
        /// <param name="name">Name of the Alien.</param>
        /// <returns>An AlienModel.</returns>
        public AlienModel GetAlienByName(string name)
        {
            return dbClient.LoadDocument<AlienModel>("aliens", name);
        }
    }
}

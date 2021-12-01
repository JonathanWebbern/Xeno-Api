using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Configuration;

namespace DataAccess
{
    /// <summary>
    /// Provides a set of generic methods for querying data from database.
    /// </summary>
    public class MongoCRUD
    {
        private readonly string _ConnectionString;
        private IMongoDatabase db;

        public MongoCRUD(string database)
        {
            _ConnectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            var client = new MongoClient(_ConnectionString);
            db = client.GetDatabase(database);
        }

        /// <summary>
        /// Loads a full collection.
        /// </summary>
        /// <typeparam name="T">Model class e.g. AlienModel.</typeparam>
        /// <param name="table">Table name.</param>
        /// <returns>Collection of models.</returns>
        public List<T> LoadCollection<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();

        }

        /// <summary>
        /// Loads a single document by Id.
        /// </summary>
        /// <typeparam name="T">Model class e.g. AlienModel.</typeparam>
        /// <param name="table">Table name.</param>
        /// <param name="Id">Id of record.</param>
        /// <returns>A single model.</returns>
        public T LoadDocument<T>(string table, int Id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", Id);
            return collection.Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// Loads a single document by Name.
        /// </summary>
        /// <typeparam name="T">Model class e.g. AlienModel.</typeparam>
        /// <param name="table">Table name.</param>
        /// <param name="name">Name of a record.</param>
        /// <returns>A single model.</returns>
        public T LoadDocument<T>(string table, string name)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Name", name);
            return collection.Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// Loads a single document by Title.
        /// </summary>
        /// <typeparam name="T">Model class e.g. AlienModel.</typeparam>
        /// <param name="table">Table name.</param>
        /// <param name="title">Title of a record.</param>
        /// <returns>A single model.</returns>
        public T LoadDocumentByTitle<T>(string table, string title)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Title", title);
            return collection.Find(filter).FirstOrDefault();
        }
    }
}

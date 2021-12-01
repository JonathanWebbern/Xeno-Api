using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Models
{
    /// <summary>
    /// Defines a Sample Model.
    /// </summary>
    public class Sample
    {
        /// <summary>
        /// The identifier of this Alien.
        /// </summary>
        [BsonId]
        public int Id { get; set; }
        /// <summary>
        /// The name of this Alien.
        /// </summary>
        public string Name { get; set; }
    }
}

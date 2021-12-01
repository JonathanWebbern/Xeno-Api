using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Models
{
    /// <summary>
    /// Defines a PlanetModel.
    /// </summary>
    public class PlanetModel
    {
        /// <summary>
        /// Unique Identifier.
        /// </summary>
        [BsonId]
        public int Id { get; set; }
        /// <summary>
        /// Name of the Planet.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Planets Classification.
        /// </summary>
        public string Classification { get; set; }
        /// <summary>
        /// The Solar system the Planet is within.
        /// </summary>
        public string System { get; set; }
        /// <summary>
        /// Collection of the Planets Suns.
        /// </summary>
        public BsonArray Suns { get; set; }
        /// <summary>
        /// Collection of the Planets Moons.
        /// </summary>
        public BsonArray Moons { get; set; }
        /// <summary>
        /// The Planets Diameter.
        /// </summary>
        public string Diameter { get; set; }
        /// <summary>
        /// Average temperature of the Planet.
        /// </summary>
        public string Temperature { get; set; }
        /// <summary>
        /// Collection of Terrian types found on the Planet.
        /// </summary>
        public BsonArray Terrain { get; set; }
        /// <summary>
        /// The Climate of the Planet.
        /// </summary>
        public BsonArray Climate { get; set; }
        /// <summary>
        /// The Species native to the Planet.
        /// </summary>
        public ReferenceModel[] Species { get; set; }
    }
}

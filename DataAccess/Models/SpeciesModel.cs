using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Models
{
    /// <summary>
    /// Defines a Species.
    /// </summary>
    public class SpeciesModel
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        [BsonId]
        public int Id { get; set; }
        /// <summary>
        /// Name of a Species e.g. Human.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Collection of Alias.
        /// </summary>
        public BsonArray Alias { get; set; }
        /// <summary>
        /// Species Classification e.g. Mammal.
        /// </summary>
        public string Classification { get; set; }
        /// <summary>
        /// Average lifespan in years.
        /// </summary>
        public string Average_Lifespan { get; set; }
        /// <summary>
        /// Average Weight in pounds and ounces.
        /// </summary>
        public string Average_Weight { get; set; }
        /// <summary>
        /// Average Height in feet and inches.
        /// </summary>
        public string Average_Height { get; set; }
        /// <summary>
        /// The Species native Homeworld.
        /// </summary>
        public ReferenceModel[] Homeworld { get; set; }
    }
}

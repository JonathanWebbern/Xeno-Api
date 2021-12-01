using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Models
{
    /// <summary>
    /// Defines an AlienModel.
    /// </summary>
    public class AlienModel
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        [BsonId]
        public int Id { get; set; }
        /// <summary>
        /// Alien Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Collection of Alias.
        /// </summary>
        public BsonArray Alias { get; set; }
        /// <summary>
        /// The Stage of this Aliens evolutionary chain.
        /// </summary>
        public string Stage { get; set; }
        /// <summary>
        /// Alien average Length in feet and inches.
        /// </summary>
        public string Length { get; set; }
        /// <summary>
        /// Alien average Height in feet and inches.
        /// </summary>
        public string Height { get; set; }
        /// <summary>
        /// Alien average Diameter in feet and inches.
        /// </summary>
        public string Diameter { get; set; }
        /// <summary>
        /// Alien average weight in pounds and ounces.
        /// </summary>
        public string Weight { get; set; }
        /// <summary>
        /// Alien Skin color.
        /// </summary>
        public string Skin_Color { get; set; }
        /// <summary>
        /// Collection of Alien characteristics. 
        /// </summary>
        public BsonArray Characteristics { get; set; }
        /// <summary>
        /// The Homeworld this Alien is native to.
        /// </summary>
        public ReferenceModel Homeworld { get; set; }
        /// <summary>
        /// The Aliens Species.
        /// </summary>
        public ReferenceModel[] Species { get; set; }
    }
}

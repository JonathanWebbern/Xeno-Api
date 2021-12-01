using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Models
{
    /// <summary>
    /// Defines a Spacecraft.
    /// </summary>
    public class SpacecraftModel
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        [BsonId]
        public int Id { get; set; }
        /// <summary>
        /// Name of a  spacecraft e.g. Nostromo.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Full Name of a Spacecraft e.g. USCSS Nostromo.
        /// </summary>
        public string Full_Name { get; set; }
        /// <summary>
        /// Spacecraft type e.g. Escape Vessel.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Spacecraft Model e.g.Schuttle.
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Manufacturer of Spacecraft e.g. Weyland Yutani.
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// The Spacecraft Class.
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// The Registration No of the Spacecraft. 
        /// </summary>
        public string Reg { get; set; }
        /// <summary>
        /// The Owner of the Spacecraft e.g. US Military.
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// The Status of the Spacecraft e.g. Destroyed.
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The Length of the Spacecraft in feet and inches.
        /// </summary>
        public string Length { get; set; }
        /// <summary>
        /// The width of the Spacecraft in feet and inches.
        /// </summary>
        public string Width { get; set; }
        /// <summary>
        /// The height of the Spacecraft in feet and inches.
        /// </summary>
        public string Height { get; set; }
        /// <summary>
        /// The Weight of the Spacecraft in tonnes.
        /// </summary>
        public string Weight { get; set; }
        /// <summary>
        /// The cost of the Spacecraft.
        /// </summary>
        public string Cost { get; set; }
        /// <summary>
        /// The Parent ship e.g. the parnet of an escape vessel.
        /// </summary>
        public ReferenceModel[] Parent { get; set; }
        /// <summary>
        /// The Crew of the Spacecraft.
        /// </summary>
        public ReferenceModel[] Crew { get; set; }
        /// <summary>
        /// The Films in which the Spacecraft appears.
        /// </summary>
        public ReferenceModel[] Films { get; set; }
    }
}

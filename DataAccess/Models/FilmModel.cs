using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Models
{
    /// <summary>
    /// Defines a FilmModel.
    /// </summary>
    public class FilmModel
    {
        /// <summary>
        /// Unique Identifier.
        /// </summary>
        [BsonId]
        public int Id { get; set; }
        /// <summary>
        /// Title of the Film.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The Films Chronological order.
        /// </summary>
        public string Chronology { get; set; }
        /// <summary>
        /// The Films Director.
        /// </summary>
        public string Director { get; set; }
        /// <summary>
        /// The Films Producer.
        /// </summary>
        public BsonArray Producer { get; set; }
        /// <summary>
        /// Collection of the Films Editors.
        /// </summary>
        public BsonArray Editor { get; set; }
        /// <summary>
        /// The Films Screenwriter.
        /// </summary>
        public string Screenwriter { get; set; }
        /// <summary>
        /// The Films Cinematographer.
        /// </summary>
        public string Cinematography { get; set; }
        /// <summary>
        /// Composer of the Films Music.
        /// </summary>
        public string Music { get; set; }
        /// <summary>
        /// The year the Film was released.
        /// </summary>
        public string Released { get; set; }
        /// <summary>
        /// The Films Age certificate.
        /// </summary>
        public string Age_rating { get; set; }
        /// <summary>
        /// The Films Production house.
        /// </summary>
        public string Production { get; set; }
        /// <summary>
        /// The Films Distributor.
        /// </summary>
        public string Distribution { get; set; }
        /// <summary>
        /// The Genres the Film is associated with.
        /// </summary>
        public BsonArray Genre { get; set; }
        /// <summary>
        /// The Running length of the film.
        /// </summary>
        public string Running_time { get; set; }
        /// <summary>
        /// The Films marketing tagline.
        /// </summary>
        public string Tagline { get; set; }
        /// <summary>
        /// The Films synopsis.
        /// </summary>
        public string Blurb { get; set; }
        /// <summary>
        /// The Budget of the Film.
        /// </summary>
        public string Budget { get; set; }
        /// <summary>
        /// The Films Revenue.
        /// </summary>
        public string Revenue { get; set; }
        /// <summary>
        /// Characters in the Film.
        /// </summary>
        public ReferenceModel[] Chracters { get; set; }
        /// <summary>
        /// Aliens in the Film.
        /// </summary>
        public ReferenceModel[] Aliens { get; set; }
        /// <summary>
        /// Spacecraft in the Film.
        /// </summary>
        public ReferenceModel[] Spacecraft { get; set; }
        /// <summary>
        /// Planets in the Film.
        /// </summary>
        public ReferenceModel[] Planets { get; set; }
    }
}

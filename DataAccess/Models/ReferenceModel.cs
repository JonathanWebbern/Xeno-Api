namespace DataAccess.Models
{
    /// <summary>
    /// Defines a referance to a child record for easier access.
    /// </summary>
    public class ReferenceModel
    {
        /// <summary>
        /// The name of the referenced resource. 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The Url of the referenced resource. 
        /// </summary>
        public string Url { get; set; }
    }
}

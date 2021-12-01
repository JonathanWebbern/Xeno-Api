using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class PeopleModel
    {
        /// <summary>
        /// Unique Idntifier.
        /// </summary>
        [BsonId]
        public int Id { get; set; }
        /// <summary>
        /// Name of the Person.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Full name of the Person.
        /// </summary>
        public string Full_Name { get; set; }
        /// <summary>
        /// Serial No of the Person
        /// </summary>
        public string Serial_Number { get; set; }
        /// <summary>
        /// Height of the Person in feet and inches.
        /// </summary>
        public string Height { get; set; }
        /// <summary>
        /// Weight of the Person in pound and ounces.
        /// </summary>
        public string Mass { get; set; }
        /// <summary>
        /// Hair color of the Person.
        /// </summary>
        public string Hair_Color { get; set; }
        /// <summary>
        /// Skin color of the Person.
        /// </summary>
        public string Skin_Color { get; set; }
        /// <summary>
        /// Eye color of the Person.
        /// </summary>
        public string Eye_Color { get; set; }
        /// <summary>
        /// Persons Date of birth.
        /// </summary>
        public string Born { get; set; }
        /// <summary>
        /// Persons Gender.
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Persons Place of birth.
        /// </summary>
        public string Place_Of_Birth { get; set; }
        /// <summary>
        /// Persons Nationality.
        /// </summary>
        public string Nationality { get; set; }
        /// <summary>
        /// Actor portraying the Person.
        /// </summary>
        public string Actor { get; set; }
        /// <summary>
        /// Persons Titles e.g. Private.
        /// </summary>
        public BsonArray Titles { get; set; }
        /// <summary>
        /// Staus of Person e.g. Alive.
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Date of Persons Death.
        /// </summary>
        public string Died { get; set; }
        /// <summary>
        /// Affiliations e.g. US Militaay.
        /// </summary>
        public BsonArray Affiliation { get; set; }
        /// <summary>
        /// Persons Occupation e.g. Soldier.
        /// </summary>
        public BsonArray Occupation { get; set; }
        /// <summary>
        /// The Persons Marital Status e.g. Divorced.
        /// </summary>
        public string Marital_Status { get; set; }
        /// <summary>
        /// The Persons Homeworld.
        /// </summary>
        public ReferenceModel[] Homeworld { get; set; }
        /// <summary>
        /// Films the Person appeared in.
        /// </summary>
        public ReferenceModel[] Films { get; set; }
        /// <summary>
        /// Species of the Person.
        /// </summary>
        public ReferenceModel[] Species { get; set; }
        /// <summary>
        /// Spacecraft the Person was a aboard.
        /// </summary>
        public ReferenceModel[] Spacecraft { get; set; }

    }
}

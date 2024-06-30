using System.Xml.Serialization;

namespace Zadanie4.Models
{
    public class Model
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Year")]
        public int Year { get; set; }

        [XmlElement("EngineCapacity")]
        public string EngineCapacity { get; set; }

        [XmlElement("DriveType")]
        public string DriveType { get; set; }
    }
}

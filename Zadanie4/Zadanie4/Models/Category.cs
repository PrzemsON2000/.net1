using System.Collections.Generic;
using System.Xml.Serialization;

namespace Zadanie4.Models
{
    public class Category
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("Subcategory")]
        public List<Subcategory> Subcategories { get; set; }
    }
}

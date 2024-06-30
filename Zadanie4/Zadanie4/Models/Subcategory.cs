using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Zadanie4.Models
{
    public class Subcategory
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("ParentCompany")]
        public string ParentCompany { get; set; }

        [XmlElement("FoundationDate")]
        public int FoundationDate { get; set; }

        [XmlElement("ProductionCountries")]
        public string ProductionCountries { get; set; }

        [XmlElement("Model")]
        public List<Model> Models { get; set; }
    }
}

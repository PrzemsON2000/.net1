using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Zadanie4.Models
{
    [XmlRoot("Vehicles")]
    public class VehicleData
    {
        [XmlElement("Category")]
        public List<Category> Categories { get; set; }

        public static VehicleData LoadFromFile(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(VehicleData));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (VehicleData)serializer.Deserialize(fs);
            }
        }
    }
}

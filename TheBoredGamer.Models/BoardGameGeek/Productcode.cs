using System.Xml.Serialization;

namespace TheBoredGamer.Models.BoardGameGeek
{
    [XmlRoot(ElementName = "productcode")]
    public class Productcode
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
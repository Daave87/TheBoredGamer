using System.Xml.Serialization;

namespace TheBoredGamer.Models.BoardGameGeek
{
    [XmlRoot(ElementName = "maxplaytime")]
    public class Maxplaytime
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
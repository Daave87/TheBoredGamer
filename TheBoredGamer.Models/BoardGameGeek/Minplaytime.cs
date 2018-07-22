using System.Xml.Serialization;

namespace TheBoredGamer.Models.BoardGameGeek
{
    [XmlRoot(ElementName = "minplaytime")]
    public class Minplaytime
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
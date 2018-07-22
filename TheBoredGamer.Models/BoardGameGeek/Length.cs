using System.Xml.Serialization;

namespace TheBoredGamer.Models.BoardGameGeek
{
    [XmlRoot(ElementName = "length")]
    public class Length
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
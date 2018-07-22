using System.Xml.Serialization;

namespace TheBoredGamer.Models.BoardGameGeek
{
    [XmlRoot(ElementName = "depth")]
    public class Depth
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
using System.Xml.Serialization;

namespace TheBoredGamer.Models.BoardGameGeek
{
    [XmlRoot(ElementName = "minage")]
    public class Minage
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
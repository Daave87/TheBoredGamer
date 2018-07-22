using System.Xml.Serialization;

namespace TheBoredGamer.Models.BoardGameGeek
{
    [XmlRoot(ElementName = "width")]
    public class Width
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
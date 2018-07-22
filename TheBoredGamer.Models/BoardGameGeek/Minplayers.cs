using System.Xml.Serialization;

namespace TheBoredGamer.Models.BoardGameGeek
{
    [XmlRoot(ElementName = "minplayers")]
    public class Minplayers
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
using System.Xml.Serialization;

namespace TheBoredGamer.Models.BoardGameGeek
{
    [XmlRoot(ElementName = "maxplayers")]
    public class Maxplayers
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
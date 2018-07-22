using System.Xml.Serialization;

namespace TheBoredGamer.Models.BoardGameGeek
{
    [XmlRoot(ElementName = "link")]
    public class Link
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "inbound")]
        public string Inbound { get; set; }
    }
}
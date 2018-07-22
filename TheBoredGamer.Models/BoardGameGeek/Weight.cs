using System.Xml.Serialization;

namespace TheBoredGamer.Models.BoardGameGeek
{
    [XmlRoot(ElementName = "weight")]
    public class Weight
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
using System.Xml.Serialization;

namespace TheBoredGamer.Models.BoardGameGeek
{
    [XmlRoot(ElementName = "playingtime")]
    public class Playingtime
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
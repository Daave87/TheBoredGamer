using System.Xml.Serialization;

namespace TheBoredGamer.Models.BoardGameGeek
{
    [XmlRoot(ElementName = "comment")]
    public class Comment
    {
        [XmlAttribute(AttributeName = "username")]
        public string Username { get; set; }
        [XmlAttribute(AttributeName = "rating")]
        public string Rating { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
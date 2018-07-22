using System.Xml.Serialization;

namespace TheBoredGamer.Models.BoardGameGeek
{
    [XmlRoot(ElementName = "video")]
    public class Video
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }
        [XmlAttribute(AttributeName = "category")]
        public string Category { get; set; }
        [XmlAttribute(AttributeName = "language")]
        public string Language { get; set; }
        [XmlAttribute(AttributeName = "link")]
        public string Link { get; set; }
        [XmlAttribute(AttributeName = "username")]
        public string Username { get; set; }
        [XmlAttribute(AttributeName = "userid")]
        public string Userid { get; set; }
        [XmlAttribute(AttributeName = "postdate")]
        public string Postdate { get; set; }
    }
}
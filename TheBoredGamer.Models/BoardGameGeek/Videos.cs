using System.Collections.Generic;
using System.Xml.Serialization;

namespace TheBoredGamer.Models.BoardGameGeek
{
    [XmlRoot(ElementName = "videos")]
    public class Videos
    {
        [XmlElement(ElementName = "video")]
        public List<Video> Video { get; set; }
        [XmlAttribute(AttributeName = "total")]
        public string Total { get; set; }
    }
}
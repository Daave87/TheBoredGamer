using System.Collections.Generic;
using System.Xml.Serialization;

namespace TheBoredGamer.Models.BoardGameGeek
{
    [XmlRoot(ElementName = "comments")]
    public class Comments
    {
        [XmlElement(ElementName = "comment")]
        public List<Comment> Comment { get; set; }
        [XmlAttribute(AttributeName = "page")]
        public string Page { get; set; }
        [XmlAttribute(AttributeName = "totalitems")]
        public string Totalitems { get; set; }
    }
}
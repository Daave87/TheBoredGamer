using System.Collections.Generic;
using System.Xml.Serialization;

namespace TheBoredGamer.Models.BoardGameGeek
{
    [XmlRoot(ElementName = "poll")]
    public class Poll
    {
        [XmlElement(ElementName = "results")]
        public List<Results> Results { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }
        [XmlAttribute(AttributeName = "totalvotes")]
        public string Totalvotes { get; set; }
    }
}
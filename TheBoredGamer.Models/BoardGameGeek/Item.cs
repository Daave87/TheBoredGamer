using System.Collections.Generic;
using System.Xml.Serialization;

namespace TheBoredGamer.Models.BoardGameGeek
{
    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "thumbnail")]
        public string Thumbnail { get; set; }
        [XmlElement(ElementName = "image")]
        public string Image { get; set; }
        [XmlElement(ElementName = "link")]
        public List<Link> Link { get; set; }
        [XmlElement(ElementName = "name")]
        public Name Name { get; set; }
        [XmlElement(ElementName = "yearpublished")]
        public Yearpublished Yearpublished { get; set; }
        [XmlElement(ElementName = "productcode")]
        public Productcode Productcode { get; set; }
        [XmlElement(ElementName = "width")]
        public Width Width { get; set; }
        [XmlElement(ElementName = "length")]
        public Length Length { get; set; }
        [XmlElement(ElementName = "depth")]
        public Depth Depth { get; set; }
        [XmlElement(ElementName = "weight")]
        public Weight Weight { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }
}

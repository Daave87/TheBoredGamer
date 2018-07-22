using System.Collections.Generic;
using System.Xml.Serialization;

namespace TheBoredGamer.Models.BoardGameGeek
{
    [XmlRoot(ElementName = "versions")]
    public class Versions
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }
}
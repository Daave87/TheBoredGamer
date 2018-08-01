using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using TheBoredGamer.Models.BoardGameGeek;

namespace TheBoredGamer.Scraper
{
    public class Program
    {
        private const string BaseApiUrl = "https://www.boardgamegeek.com/xmlapi2/thing?id={0}";

        private static void Main(string[] args)
        {
            var serializer = new XmlSerializer(typeof(Items));

            for (var bggId = 1; bggId < 10; bggId++)
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(string.Format(BaseApiUrl, bggId));

                var response = (HttpWebResponse)httpRequest.GetResponse();

                var responseStream = response.GetResponseStream();
                
                Items items = null;

                items = (Items)serializer.Deserialize(responseStream);
                responseStream?.Close();
            }
        }
    }
}

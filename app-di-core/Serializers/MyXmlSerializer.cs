using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace homework
{
    public class MyXmlSerializer : ISerializer
    {
        public T Deserialize<T>(Stream s)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (var reader = new StreamReader(s))
            {
               return (T) serializer.Deserialize(reader) ;
            }
        }

        public void Serialize<T>(T value, Stream s)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StreamWriter writer = new StreamWriter(s))
            using (XmlWriter XMLwriter = new XmlTextWriter(writer))
            {
                serializer.Serialize(XMLwriter, value);
                XMLwriter.Flush();
            }
        }
    }
}

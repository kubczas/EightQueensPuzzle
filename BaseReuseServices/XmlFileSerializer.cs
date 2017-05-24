using System.IO;
using System.Xml.Serialization;

namespace BaseReuseServices
{
    public class XmlFileSerializer : IXmlFileSerializer
    {
        public void Serialize<T>(string filePath, T data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof (T));
            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer,data);
            }
        }

        public T Deserialize<T>(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StreamReader(filePath))
            {
                object obj = serializer.Deserialize(reader);
                return (T)obj;
            }
        }
    }
}

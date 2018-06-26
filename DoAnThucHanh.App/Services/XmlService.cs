using System.IO;
using System.Xml.Serialization;

namespace DoAnThucHanh.App.Services
{
    public class XmlService
    {
        public XmlService()
        {

        }

        public void WriteToXml<T>(string fileName, T obj)
        {
            using (var streamWriter = new StreamWriter(fileName))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(streamWriter, obj);
            }
        }

        public T ReadFromXml<T>(string fileName)
        {
            T obj;
            using (var streamReader = new StreamReader(fileName))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                obj = (T)xmlSerializer.Deserialize(streamReader);
            }
            return obj;
        }
    }
}

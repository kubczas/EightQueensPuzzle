namespace BaseReuseServices
{
    public interface IXmlFileSerializer
    {
        void Serialize<T>(string filePath, T data);
        T Deserialize<T>(string filePath);
    }
}

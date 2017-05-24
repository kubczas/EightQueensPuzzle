using System;
using System.IO;
using System.Reflection;
using BaseReuseServices;
using EightQueensPuzzle.Models;

namespace EightQueensPuzzle.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly IXmlFileSerializer _xmlFileSerializer;

        private static readonly string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            Assembly.GetCallingAssembly().FullName);

        public SettingsService(IXmlFileSerializer xmlFileSerializer)
        {
            _xmlFileSerializer = xmlFileSerializer;
        }

        public GameSettings Load()
        {
            return _xmlFileSerializer.Deserialize<GameSettings>(FilePath);
        }

        public void Save(GameSettings gameSettings)
        {
            _xmlFileSerializer.Serialize(FilePath, gameSettings);
        }
    }
}

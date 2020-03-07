using SchematicReader;

namespace Schematics.Core.Services
{
    public interface ISchematicServices
    {
        Schematic LoadSchematicFromFile(string path);
        bool FileExists(string path);
    }
}
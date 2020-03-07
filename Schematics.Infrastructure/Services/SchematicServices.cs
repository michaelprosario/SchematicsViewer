using SchematicReader;
using Schematics.Core.Requests;
using Schematics.Core.Responses;
using Schematics.Core.Services;

namespace Schematics.Infrastructure.Services
{
    public class SchematicServices : ISchematicServices
    {
        public bool FileExists(string path)
        {
            return System.IO.File.Exists(path);
        }

        public Schematic LoadSchematicFromFile(string path)
        {
            return SchematicReader.SchematicReader.LoadSchematic(path);
        }
    }
}

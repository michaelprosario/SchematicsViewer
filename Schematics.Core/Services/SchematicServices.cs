using Schematics.Core.Helpers;
using Schematics.Core.Requests;
using Schematics.Core.Responses;
using System.IO;

namespace Schematics.Core.Services
{
    public class SchematicServices
    {

        public SchematicServices(ISchematicServices services)
        {
            this.services = services;
        }

        public LoadSchematicResponse LoadSchematicFromFile(LoadSchematicRequest request)
        {
            ThrowIf.Argument.IsNull(request, "request");
            ThrowIf.Argument.IsNull(request.Path, "path");
            if (!services.FileExists(request.Path))
            {
                throw new FileNotFoundException();
            }

            return new LoadSchematicResponse()
            {
                Schematic = services.LoadSchematicFromFile(request.Path)
            }; 
        }

        private readonly ISchematicServices services;

    }
}

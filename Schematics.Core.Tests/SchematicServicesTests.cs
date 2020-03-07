using NSubstitute;
using NUnit.Framework;
using SchematicReader;
using Schematics.Core.Requests;
using Schematics.Core.Services;

namespace Schematics.Core.Tests
{
    public class SchematicServicesTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldWorkInHappyCase()
        {
            // arrange
            var request = new LoadSchematicRequest
            {
                Path = "goodFile.schematic"
            };
            
            ISchematicServices implementation = getServiceImplementation(request.Path);
            var service = new SchematicServices(implementation);

            // act
            var response = service.LoadSchematicFromFile(request);

            // assert
            Assert.IsTrue(response != null, "response should be defined");
            implementation.Received().LoadSchematicFromFile(request.Path);
        }

        private static ISchematicServices getServiceImplementation(string file)
        {
            var implementation = Substitute.For<ISchematicServices>();
            var schematic = new Schematic();
            implementation.LoadSchematicFromFile(file).Returns(schematic);
            implementation.FileExists(file).Returns(true);
            return implementation;
        }

        [Test]
        public void ShouldReturnErrorIfIPassBadFileName()
        {
            // arrange
            var request = new LoadSchematicRequest
            {
                Path = "goodFile.schematic"
            };

            var badRequest = new LoadSchematicRequest
            {
                Path = "bad.schematic"
            };
            ISchematicServices implementation = getServiceImplementation(request.Path);
            var service = new SchematicServices(implementation);

            // act
            Assert.Throws<System.IO.FileNotFoundException>(() => service.LoadSchematicFromFile(badRequest));
        }

        [Test]
        public void ShouldReturnErrorIfIPassNullFileName()
        {
            // arrange
            LoadSchematicRequest request = null;
            ISchematicServices implementation = null;
            var service = new SchematicServices(implementation);

            // act
            Assert.Throws<System.ArgumentNullException>(() => service.LoadSchematicFromFile(request));
        }
    }
}
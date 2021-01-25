using homework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using System.Threading.Tasks;

namespace app_di_core_tests
{
    [TestClass]
    public class ProgramServisTests
    {
        ProgramServis _systemUnderTests;
        Mock<IStorage> storageFrom;
        Mock<IStorage> storageTo;
        Mock<ISerializer> serializerFrom;
        Mock<ISerializer> serializerTo;

        [TestInitialize]
        public void Setup()
        {
            storageFrom = new Mock<IStorage>();
            storageTo = new Mock<IStorage>();
            serializerFrom = new Mock<ISerializer>();
            serializerTo = new Mock<ISerializer>();
            _systemUnderTests = new ProgramServis(storageFrom.Object, 
                serializerFrom.Object, 
                storageTo.Object, 
                serializerTo.Object);

        }

        [TestMethod]
        public async Task  MainTask_CalledLoadFromStorage()
        {
            storageFrom.Setup(x => x.Load()).Returns(async () =>
            {
                await Task.Yield();
                return null;
            });
            await _systemUnderTests.MainTask();
            storageFrom.Verify(x => x.Load(), Times.Once);
        }

        [TestMethod]
        public async Task MainTask_VerifyCalledDeserializeWithNull()
        {
            storageFrom.Setup(x => x.Load()).Returns(async () =>
            {
                await Task.Yield();
                return null;
            });
            await _systemUnderTests.MainTask();
            serializerFrom.Verify(x => x.Deserialize<IDocument>(null), Times.Once);
        }

        [TestMethod]
        public async Task MainTask_VerifyCalledSerialize()
        {
            var moqDoc = new Mock<IDocument>();
            
            serializerFrom.Setup(x => x.Deserialize<IDocument>(It.IsAny<Stream>()))
                .Returns(moqDoc.Object);
            await _systemUnderTests.MainTask();
            serializerTo.Verify(x => x.Serialize<IDocument>(moqDoc.Object, It.IsAny<MemoryStream>()), Times.Once);
        }
    }
}

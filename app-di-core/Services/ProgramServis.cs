using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Xml.Linq;
using homework.Wrapper;
using Newtonsoft.Json;

namespace homework
{
    public class ProgramServis : IProgramServis
    {
        private readonly IStorage _fromStorage;
        private readonly ISerializer _serializerFrom;
        private readonly IStorage _toStorage;
        private readonly ISerializer _serializerTo;

        public ProgramServis(IStorage fromStorage, ISerializer serializerFrom, IStorage toStorage, ISerializer serializerTo)
        {
            _fromStorage = fromStorage;
            _serializerFrom = serializerFrom;
            _toStorage = toStorage;
            _serializerTo = serializerTo;
        }

        public async System.Threading.Tasks.Task MainTask()
        {
            //var fromStorage = new HttpStorage("https://api-test-34995-default-rtdb.europe-west1.firebasedatabase.app/document", new HttpClientWrapper(new HttpClient()));

            var loadedData = await _fromStorage.Load();

            //var jsonSerializer = new MyJsonSerializer();

            IDocument desData = _serializerFrom.Deserialize<IDocument>(loadedData);
            //var xmlSerializer = new MyXmlSerializer();

            //var toStorage = new HttpStorage("https://api-test-34995-default-rtdb.europe-west1.firebasedatabase.app/document", new HttpClientWrapper(new HttpClient()));

            using (var memStream = new MemoryStream())
            {
                _serializerTo.Serialize<IDocument>(desData, memStream);
                await _toStorage.Save(memStream);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework
{
    public interface IStorage
    {
        Task<Stream> Load();
        Task<bool> Save(Stream data);
    }
}

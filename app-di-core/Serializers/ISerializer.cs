using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace homework
{
    public interface ISerializer
    {
        void Serialize<TValue>(TValue value, Stream s);
        T Deserialize<T>(Stream s);
    }
}

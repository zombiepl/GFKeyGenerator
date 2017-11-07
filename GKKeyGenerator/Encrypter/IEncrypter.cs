using System;
using System.Collections.Generic;
using System.Text;

namespace Encrypter
{
    public interface IEncrypter
    {
        String ToEncrypt { get; set; }
        String Enctypted { get; set; }
    }
}

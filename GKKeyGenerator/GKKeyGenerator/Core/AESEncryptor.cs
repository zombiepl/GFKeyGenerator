using GKKeyGenerator.Interfaces.Core;

namespace GKKeyGenerator.Core
{
    public class AESEncryptor : IAESEncryptor
    {
        public string KeyObject { get; set; }
    }
}
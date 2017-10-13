using FGMailGenerator.Mail;
using GKKeyGenerator.Interfaces.Core;

namespace GKKeyGenerator.Core
{
    public class KeyGenerator : IKeyGenerator
    {
        public string NIP { get; set; }
        public string Product { get; set; }
        public string ProductModule { get; set; }
        public int NumberOfModule { get; set; }
    }
}
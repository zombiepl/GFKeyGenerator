using System.Collections.Generic;
using GKKeyGenerator.Interfaces.Models;

namespace GKKeyGenerator.Models
{
    public class Modules : IModules
    {
        public List<IModules> modules { get; set; }
    }
}
using System.Collections.Generic;

namespace GKKeyGenerator.Interfaces.Models
{
    public interface IModules
    {
        List<IModules> modules { get; set; }
    }
}
using System.Collections.Generic;

namespace GKKeyGenerator.Interfaces.Models
{
    public interface ICustomerModules
    {
        Dictionary<IProduct, List<IModules>> ProductList { get; set; }
    }
}
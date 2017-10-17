using System.Collections.Generic;

namespace GKKeyGenerator.Interfaces.Models
{
    public interface IProduct
    {
        List<IProduct> ProductList { get; set; }
        
    }
}
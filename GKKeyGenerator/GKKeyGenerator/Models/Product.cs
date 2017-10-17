using System.Collections.Generic;
using GKKeyGenerator.Interfaces.Models;

namespace GKKeyGenerator.Models
{
    public class Product : Modules, IProduct
    {
        public List<IProduct> ProductList { get; set; }
    }
}
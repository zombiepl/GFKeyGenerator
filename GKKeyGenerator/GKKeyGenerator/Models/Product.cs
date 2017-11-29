using System.Collections.Generic;
using System.Dynamic;
using GKKeyGenerator.Interfaces.Models;

namespace GKKeyGenerator.Models
{
    public class Product : IProduct
    {
        public string Name { get; set; }
    }
}
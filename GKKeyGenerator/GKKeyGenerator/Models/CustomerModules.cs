using System.Collections.Generic;
using GKKeyGenerator.Interfaces.Models;

namespace GKKeyGenerator.Models
{
    public class CustomerModules : ICustomerModules
    {//słownik w którym kluczem jest obiekt Product a wartością klucza jest lista modułów tego produktu
        public Dictionary<IProduct, List<IModules>> ProductList { get; set; }
    }
}
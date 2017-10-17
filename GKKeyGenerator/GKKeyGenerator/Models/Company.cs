using System.Collections.Generic;
using GKKeyGenerator.Interfaces.Models;

namespace GKKeyGenerator.Models
{
    public class Company : Product, ICompany
    {
        public string companyNIP { get; set; }
    }
}
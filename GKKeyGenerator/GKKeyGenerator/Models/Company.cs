using System.Collections.Generic;
using GKKeyGenerator.Interfaces.Models;

namespace GKKeyGenerator.Models
{
    public class Company : Product, ICompany
    {
        public string companyName { get; set; }
        public string companyNIP { get; set; }
        public string companyAdress { get; set; }
        public string companyCity { get; set; }
        public string companyPCode { get; set; }
    }
}
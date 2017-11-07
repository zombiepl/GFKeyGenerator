using System.Collections.Generic;

namespace GKKeyGenerator.Interfaces.Models
{
    public interface ICompany
    {
        string companyName { get; set; }
        string companyNIP { get; set; }
        string companyAdress { get; set; }
        string companyCity { get; set; }
        string companyPCode { get; set; }

    }
    
}
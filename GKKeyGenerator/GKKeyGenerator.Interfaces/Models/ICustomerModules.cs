namespace GKKeyGenerator.Interfaces.Models
{

    /*
    select c.companyName, c.nip, p.productName, m.module_name
    from customerModules cm, modules m, products p, companya c
    where cm.id_company = c.id_company and cm.id_product = p.id_product and cm.id_module = m.id_module 
     */
    public interface ICustomerModules
    {

        
    }
}
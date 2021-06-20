using ComputerStoreAdmin.Models.Seller;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Services.Seller
{
    public interface IComplectationRepository
    {
        public Task<List<Complectation>> List(string role);
        public Task<Complectation> FindByID(string role, int id);
        public Task<ServicesList> GetServices(string role);
        public Task<int> SaleComplectation(string role, ServicesList services);
    }
}

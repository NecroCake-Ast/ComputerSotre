using ComputerStoreAdmin.Models.Seller;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Services.Seller
{
    public interface IChequeRepository
    {
        public Task<List<Cheque>> List(string role);
        public Task<Cheque> FindByID(string role, int id);
    }
}

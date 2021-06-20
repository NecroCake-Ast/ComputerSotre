using ComputerStoreAdmin.Models.Seller;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Services.Seller
{
    public class PGChequeRepository : IChequeRepository
    {
        public async Task<Cheque> FindByID(string role, int id)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(role));
            return await context.Cheques.SingleAsync(p => p.ChequeID == id);
        }

        public async Task<List<Cheque>> List(string role)
        {
            PGContext context = new PGContext(PGAccountManager.getConnectData(role));
            return await context.Cheques.ToListAsync();
        }
    }
}

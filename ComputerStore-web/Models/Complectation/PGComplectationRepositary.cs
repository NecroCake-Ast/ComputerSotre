using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStore.Models
{
    public class PGComplectationRepositary : IComplectationRepositary
    {
        private PGContext _context;
        public PGComplectationRepositary(PGContext context)
        {
            _context = context;
        }

        public async Task<List<Complectation>> List()
        {
            return await _context.Complectations.ToListAsync();
        }

        public async Task<Complectation> FindByID(int id)
        {
            return await _context.Complectations.SingleAsync(p => p.id == id);
        }
    }
}

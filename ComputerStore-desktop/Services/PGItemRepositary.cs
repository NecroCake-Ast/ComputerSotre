using ComputerStoreDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreDesk.Services
{
    public class PGItemRepositary
    {
        PGContext _context;
        public PGItemRepositary(PGContext context)
        {
            _context = context;
        }

        public List<ItemDetails> List()
        {
            return _context.ItemDetails.ToList();
        }

        public List<Item> NotDetailedList()
        {
            return _context.Items.ToList();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreDesk.Models
{
    [Table("item_info")]
    [Keyless]
    public class Item
    {
        public string type         { get; set; }
        public string manufacturer { get; set; }
        public string name         { get; set; }
    }
}

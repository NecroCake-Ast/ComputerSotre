using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreAdmin.Models.Store
{
    [Table("deficit")]
    public class DeficitItem
    {
        [Column("id")]
        public int    ID    { get; set; }
        [Column("item_name")]
        public string Name  { get; set; }
        [Column("cnt")]
        public int    Count { get; set; }
    }
}

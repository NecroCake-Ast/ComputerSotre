using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreDesk.Models
{
    [Table("detail_item_info")]
    public class ItemDetails
    {
        
        public string name              { get; set; }
        public int    id                { get; set; }
        public int    type_id           { get; set; }
        public string type              { get; set; }
        public int    manufacturer_id   { get; set; }
        public string manufacturer      { get; set; }

        public override string ToString()
        {
            return type + " " + manufacturer + " " + name;
        }
    }
}

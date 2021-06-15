using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreAdmin.Models.Admin
{
    [Table("roles")]
    public class Role
    {
        [Column("role_name")]
        [Key]
        public string name { get; set; }
    }
}

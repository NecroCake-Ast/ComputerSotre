using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreAdmin.Models.Admin
{
    [Table("users_info")]
    public class UserData
    {
        [Key]
        public string login { get; set; }
        [Column("user_role")]
        public string role  { get; set; }
    }
}

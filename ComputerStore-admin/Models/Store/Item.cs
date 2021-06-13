using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStoreAdmin.Models.Store
{
    [Table("item_info")]
    public class Item
    {
        public int    id                { get; set; }  //!< ID детали
        public string name              { get; set; }  //!< Наименование детали
        public int    type_id           { get; set; }  //!< ID типа детали
        public string type              { get; set; }  //!< Тип детали
        public int    manufacturer_id   { get; set; }  //!< ID производителя
        public string manufacturer      { get; set; }  //!< Производитель

        public override string ToString()
        {
            return type + " " + manufacturer + " " + name;
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

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

        public string FullName { get => ToString(); }

        public override string ToString()
        {
            return type + " " + manufacturer + " " + name;
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreAdmin.Models.Store
{
    [Table("store")]
    public class StoredItem
    {
        public int      id           { get; set; }  //!< ID хранимой детали
        public int      id_item      { get; set; }  //!< ID детали
        public string   item         { get; set; }  //!< Наименование детали
        public double   buy_price    { get; set; }  //!< Закупочная цена
        public DateTime buy_date     { get; set; }  //!< Дата прибытия на склад
        public string   place        { get; set; }  //!< Адрес расположения
        public bool     isOnStorage  { get; set; }  //!< Находится ли на складе
    }
}

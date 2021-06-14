using System;

namespace ComputerStoreAdmin.Models.Store
{
    public class StoredItemSearchData
    {
        public string    Etalon        { get; set; }  //!< Шаблон наименования для поиска
        public DateTime? StartDateDiap { get; set; }  //!< Начало диапазона дат поступления
        public DateTime? EndDateDiap   { get; set; }  //!< Конец диапазона дат поступления
    }
}

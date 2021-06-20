using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreAdmin.Models.Seller
{
    [Table("complectation_info")]
    [Keyless]
    public class Complectation
    {
        public class ComplectationLine
        {
            public int    ID           { get; set; }
            public string Type         { get; set; }
            public string Manufacturer { get; set; }
            public string Name         { get; set; }
        }

        public int    id            { get; set; }  //!< ID комплектации
        public string name          { get; set; }  //!< Название комплектации
        public string description   { get; set; }  //!< Краткое описание
        public double price         { get; set; }  //!< Цена
        public string specification { get; set; }  //!< Детальное описание
        public string complect      { get; set; }  //!< Комплектующие
        public bool   available     { get; set; }  //!< Есть ли в наличии

        public List<ComplectationLine> GetComplect()
        {
            List<ComplectationLine> data = JsonConvert.DeserializeObject<List<ComplectationLine>>(complect);
            return data;
        }
    }
}

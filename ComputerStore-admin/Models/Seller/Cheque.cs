using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreAdmin.Models.Seller
{
	[Table("sale_story")]
    public class Cheque
    {
		public class ItemRecord
        {
			public int    ID   { get; set; }
			public string Name { get; set; }
        }

		[Column("id")]
		public int          ChequeID      { get; set; }
		[Column("name")]
		public string       Complectation { get; set; }
		[Column("services")]
		public List<string> ServicesList  { get; set; }
		[Column("total_price")]
		public double       Price         { get; set; }
		[Column("sale_date")]
		public DateTime     Date          { get; set; }
		[Column("items")]
		public string       Items         { get; set; }

		public List<ItemRecord> ItemList()
        {
			return JsonConvert.DeserializeObject<List<ItemRecord>>(Items);
        }
	}
}

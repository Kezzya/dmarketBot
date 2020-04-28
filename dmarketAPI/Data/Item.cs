using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmarketAPI.Data
{
	public class DmarketItem
	{
		public Item[] objects { get; set; }
	}
	public class Item
	{
		public int discount { get; set; }
		public string title { get; set; }
	}
}

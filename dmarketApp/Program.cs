using System;
using System.Threading.Tasks;
using dmarketAPI.Data;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using System.Web;

namespace dmarketApp
{
	class Program
	{

		static readonly HttpClient client = new HttpClient();
		static async Task Main(string[] args)
		{

			while (true)
			{
				try
				{
					string link =
				   "https://api.dmarket.com/exchange/v1/market/items?orderBy=best_deals&orderDir=desc&title=&priceFrom=0&priceTo=4370&treeFilters=&gameId=a8db&offset=0&limit=100&currency=USD";
					HttpResponseMessage response = await client.GetAsync(link);
					response.EnsureSuccessStatusCode();
					string responseBody = await response.Content.ReadAsStringAsync();

					var firstItem = JsonConvert.DeserializeObject<DmarketItem>(responseBody);
				
					foreach (var item in firstItem.objects)
					{

						if (item.discount >= 23 && item.title != "CS:GO Weapon Case")
						{
							System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"music/дора.wav");
							player.Play();
							Console.WriteLine(item.discount);
							Console.WriteLine(item.title);
							Console.ReadLine();
							player.Stop();
						}
					}
				}
				catch (HttpRequestException e)
				{
					Console.WriteLine("\nException Caught!");
					Console.WriteLine("Message :{0} ", e.Message);
				}
				Thread.Sleep(200);
			}

		}
	}

}

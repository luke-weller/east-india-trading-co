using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Web.Http;

namespace east_india_trading_co.Models
{
    public class Edge
    {
        public static  string oaBaseUrl = "https://wa-oa-dk1.azurewebsites.net/api/route";
        public static  string tlBaseUrl = "https://wa-tl-dk1.azurewebsites.net/api/segments";

        public Edge(int type, double unit,  Node city1, Node city2, HttpClient client, RouteRequest routeRequest)
        {
            this.Type = type;
            this.CityPair = new List<Node>() { city1, city2 };
            this.Unit = unit;
            this.Price = unit*8;
            city1.Edges.Add(this);
            city1.Adjecent.Add(city2);
            city2.Edges.Add(this);
            city2.Adjecent.Add(city1);

            if (type != 0)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, type == 1 ? oaBaseUrl : tlBaseUrl);
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(routeRequest),
                    Encoding.UTF8, "application/json");
                var response = client.SendAsync(request).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    if (type == 2)
                    {
                       // result.Replace("\\", "");
                    }
                    this.Price = (double)JsonNode.Parse(result).AsObject()[type == 1 ? "price" : "cost"];
                }
            } else
            {
                int parcelType = routeRequest.type;

                if (routeRequest.weight > 100 || parcelType == 8 || parcelType == 5)
                {
                    this.Price = 0;
                }
                if (parcelType == 7)
                {
                    this.Price = this.Price * 1.2;
                }
                if (parcelType == 1)
                {
                    this.Price = this.Price * 1.25;
                }
                if (parcelType == 3)
                {
                    this.Price = this.Price * 1.1;
                }
            }

        }

        public int Type { get; set; }
        public double Unit { get; set; }
        public List<Node> CityPair { get; set; }
        public double Price { get; set; }
    }
}

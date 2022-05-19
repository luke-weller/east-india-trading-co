using east_india_trading_co.Models;
using Newtonsoft.Json;
using System.Net;
using System.Web.Http;

namespace east_india_trading_co.Util
{
    public class ShortestPathCalculator
    {
        List<Node> cities = new List<Node>();
        List<Edge> edges = new List<Edge>();
        List<KeyValuePair<Node, double>> distances = new List<KeyValuePair<Node, double>>();
        List<Node> unvisitedNodes = new List<Node>();
        string oaBaseUrl = "https://wa-oa-dk1.azurewebsites.net/api/route";
        string tlBaseUrl = "https://wa-tl-dk1.azurewebsites.net/api/segments";
        HttpClient Client = new HttpClient();

        public ShortestPathCalculator()
        {
            InitTestData();
        }
        
        public void InitTestData()
        {
            cities.Add(new Node(0, "kapstaden"));
            cities.Add(new Node(1, "hvalbugten"));
            cities.Add(new Node(2, "dragebjerget"));
            cities.Add(new Node(4, "victoria faldene"));
            cities.Add(new Node(3, "victoria faldene"));

            edges.Add(new Edge(0, 3, cities[0], cities[1]));
            edges.Add(new Edge(1, 0, cities[0], cities[1]));
            edges.Add(new Edge(2, 0, cities[0], cities[1]));
            edges.Add(new Edge(2, 0, cities[0], cities[1]));

            edges.Add(new Edge(2, 0, cities[1], cities[3]));
            edges.Add(new Edge(2, 0, cities[2], cities[3]));
            edges.Add(new Edge(1, 0, cities[0], cities[2]));
            Console.WriteLine("Boom");

        }
        
            public RouteResult CalculateShortestPath(RouteRequest routeRequest)
        {
        Node source = cities.Find(city => city.Name.ToLower().Equals(routeRequest.from));

            for (int i = 0; i<cities.Count; i++)
            {
                if (source.Equals(cities[i]))
                {
                    distances.Add(new KeyValuePair<Node, double>(cities[i], 0));
                    
                } else
                {
                distances.Add(new KeyValuePair<Node, double>(cities[i], double.MaxValue));
                unvisitedNodes.Add(cities[i]);

                }
                Console.WriteLine(distances[i].Key.Name + ", value: " + distances[i].Value);

            }

            foreach (Node adjecent in source.Adjecent)
            {
                double minValue = CalculateMinPriceForTwoNodes(source, adjecent, routeRequest);
            }


            

            return new RouteResult(100, 300);
        }

        private double CalculateMinPriceForTwoNodes(Node node1, Node node2, RouteRequest routeRequest)
        {
            double price = double.MaxValue;
            foreach (Edge edge in node1.Edges)
            {
                if (edge.CityPair.All(node => node.Equals(node1) || node.Equals(node2)))
                {
                    if( edge.Type == 0)
                    {
                        price = edge.Unit*5 ;
                    }
                    if (edge.Type == 1)
                    {
                        var request = new HttpRequestMessage(HttpMethod.Get, oaBaseUrl);
                        request.Content = new StringContent(
                            JsonConvert.SerializeObject(new RouteRequest(node1.Name, node2.Name, routeRequest.type, routeRequest.weight, routeRequest.width, routeRequest.height, routeRequest.length)));
                        var response = Client.SendAsync(request).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            JsonConvert.DeserializeObject<RouteResult>(response.Content.ToString());
                        } 
                    }

                }
                
            }
            return price;
        }

        public RouteResult TestCalc(RouteRequest routeRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, oaBaseUrl);
            request.Content = new StringContent(
                JsonConvert.SerializeObject(new RouteRequest("kapstaden", "hvalbugten", 0, 50, 50, 50, 50)));
            var response = Client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<RouteResult>(response.Content.ToString());
            } else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

    }
}
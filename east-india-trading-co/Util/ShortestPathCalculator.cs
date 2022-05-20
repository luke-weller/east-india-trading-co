using east_india_trading_co.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Web.Http;

namespace east_india_trading_co.Util
{
    public class ShortestPathCalculator
    {
        List<Node> cities = new List<Node>();
        List<Edge> edges = new List<Edge>();
        List<KeyValuePair<Node, double>> distances = new List<KeyValuePair<Node, double>>();
        List<Node> unvisitedNodes = new List<Node>();
        HttpClient Client = new HttpClient();
        public RouteResult Result;
        GFG gfg = new GFG();

        public ShortestPathCalculator(RouteRequest routeRequest)
        {
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/plain"));
            InitTestData(routeRequest);

        }

        public void InitTestData(RouteRequest routeRequest)
        {
            cities.Add(new Node(0, "cairo"));
            cities.Add(new Node(1, "suakin"));
            cities.Add(new Node(2, "addis abeba"));
            cities.Add(new Node(3, "omdurman"));
            cities.Add(new Node(4, "darfur"));
            cities.Add(new Node(5, "victoriasoeen"));
            cities.Add(new Node(6, "congo"));
            cities.Add(new Node(7, "kabalo"));
            cities.Add(new Node(8, "zanzibar"));
            cities.Add(new Node(9, "mocambique"));
            cities.Add(new Node(10, "victoriafaldene"));
            cities.Add(new Node(11, "dragebjerget"));
            cities.Add(new Node(12, "amatave"));
            cities.Add(new Node(13, "kapstaden"));
            cities.Add(new Node(14, "hvalbugten"));
            cities.Add(new Node(15, "luanda"));
            cities.Add(new Node(16, "de kanariske oeer"));
            cities.Add(new Node(17, "slavekysten"));
            cities.Add(new Node(18, "wadai"));
            cities.Add(new Node(19, "sahara"));
            cities.Add(new Node(20, "tripoli"));
            cities.Add(new Node(21, "tunis"));
            cities.Add(new Node(22, "tanger"));
            cities.Add(new Node(23, "marrakesh"));
            cities.Add(new Node(24, "st. helena"));
            cities.Add(new Node(25, "sierra leone"));
            cities.Add(new Node(26, "dakar"));
            cities.Add(new Node(27, "guldkysten"));
            cities.Add(new Node(28, "kap guardafui"));
            cities.Add(new Node(29, "kap st. marie"));
            cities.Add(new Node(30, "bahr el ghaza"));
            cities.Add(new Node(31, "timbuktu"));


            edges.Add(new Edge(0, 5, cities[0], cities[21], Client, routeRequest));
            edges.Add(new Edge(0, 4, cities[0], cities[1], Client, routeRequest));
            edges.Add(new Edge(1, 0, cities[0], cities[1], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[0], cities[3], Client, routeRequest));

            edges.Add(new Edge(0, 4, cities[1], cities[28], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[1], cities[2], Client, routeRequest));
            edges.Add(new Edge(1, 0, cities[1], cities[4], Client, routeRequest));
            edges.Add(new Edge(1, 0, cities[1], cities[5], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[1], cities[4], Client, routeRequest));

            edges.Add(new Edge(2, 0, cities[2], cities[28], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[2], cities[5], Client, routeRequest));

            edges.Add(new Edge(2, 0, cities[3], cities[20], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[3], cities[4], Client, routeRequest));

            edges.Add(new Edge(2, 0, cities[4], cities[19], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[4], cities[18], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[4], cities[17], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[4], cities[30], Client, routeRequest));
            edges.Add(new Edge(1, 0, cities[4], cities[20], Client, routeRequest));
            edges.Add(new Edge(1, 0, cities[4], cities[7], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[4], cities[6], Client, routeRequest));

            edges.Add(new Edge(2, 0, cities[5], cities[30], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[5], cities[8], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[5], cities[9], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[5], cities[7], Client, routeRequest));
            edges.Add(new Edge(1, 0, cities[5], cities[28], Client, routeRequest));
            edges.Add(new Edge(1, 0, cities[5], cities[11], Client, routeRequest));

            edges.Add(new Edge(2, 0, cities[6], cities[15], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[6], cities[17], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[6], cities[18], Client, routeRequest));

            edges.Add(new Edge(2, 0, cities[7], cities[15], Client, routeRequest));
            edges.Add(new Edge(1, 0, cities[7], cities[13], Client, routeRequest));

            edges.Add(new Edge(2, 0, cities[8], cities[28], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[8], cities[9], Client, routeRequest));

            edges.Add(new Edge(2, 0, cities[9], cities[15], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[9], cities[10], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[9], cities[11], Client, routeRequest));
            edges.Add(new Edge(0, 8, cities[9], cities[28], Client, routeRequest));
            edges.Add(new Edge(0, 3, cities[9], cities[29], Client, routeRequest));

            edges.Add(new Edge(2, 0, cities[10], cities[14], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[10], cities[15], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[10], cities[11], Client, routeRequest));

            edges.Add(new Edge(2, 0, cities[11], cities[15], Client, routeRequest));
            edges.Add(new Edge(1, 0, cities[11], cities[13], Client, routeRequest));

            edges.Add(new Edge(0, 8, cities[12], cities[28], Client, routeRequest));
            edges.Add(new Edge(1, 0, cities[12], cities[28], Client, routeRequest));
            edges.Add(new Edge(1, 0, cities[12], cities[13], Client, routeRequest));

            edges.Add(new Edge(0, 8, cities[13], cities[29], Client, routeRequest));
            edges.Add(new Edge(0, 3, cities[13], cities[14], Client, routeRequest));
            edges.Add(new Edge(0, 9, cities[13], cities[24], Client, routeRequest));
            edges.Add(new Edge(1, 0, cities[13], cities[24], Client, routeRequest));
            edges.Add(new Edge(1, 0, cities[13], cities[14], Client, routeRequest));
            edges.Add(new Edge(1, 0, cities[13], cities[29], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[13], cities[14], Client, routeRequest));

            edges.Add(new Edge(0, 9, cities[14], cities[17], Client, routeRequest));
            edges.Add(new Edge(0, 11, cities[14], cities[27], Client, routeRequest));
            edges.Add(new Edge(0, 10, cities[14], cities[24], Client, routeRequest));
            edges.Add(new Edge(1, 0, cities[14], cities[27], Client, routeRequest));
            edges.Add(new Edge(1, 0, cities[14], cities[15], Client, routeRequest));

            edges.Add(new Edge(1, 0, cities[15], cities[27], Client, routeRequest));

            edges.Add(new Edge(0, 3, cities[16], cities[22], Client, routeRequest));
            edges.Add(new Edge(0, 5, cities[16], cities[26], Client, routeRequest));


            edges.Add(new Edge(0, 4, cities[17], cities[27], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[17], cities[31], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[17], cities[18], Client, routeRequest));

            edges.Add(new Edge(2, 0, cities[19], cities[23], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[19], cities[22], Client, routeRequest));

            edges.Add(new Edge(1, 0, cities[20], cities[22], Client, routeRequest));
            edges.Add(new Edge(1, 0, cities[20], cities[27], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[20], cities[21], Client, routeRequest));

            edges.Add(new Edge(0, 3, cities[21], cities[22], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[21], cities[22], Client, routeRequest));

            edges.Add(new Edge(1, 0, cities[22], cities[23], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[22], cities[23], Client, routeRequest));

            edges.Add(new Edge(1, 0, cities[23], cities[25], Client, routeRequest));
            edges.Add(new Edge(1, 0, cities[23], cities[27], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[23], cities[26], Client, routeRequest));

            edges.Add(new Edge(0, 10, cities[24], cities[26], Client, routeRequest));
            edges.Add(new Edge(0, 11, cities[24], cities[25], Client, routeRequest));
            edges.Add(new Edge(1, 0, cities[24], cities[25], Client, routeRequest));

            edges.Add(new Edge(0, 3, cities[25], cities[1], Client, routeRequest));
            edges.Add(new Edge(0, 4, cities[25], cities[1], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[25], cities[1], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[25], cities[1], Client, routeRequest));
            edges.Add(new Edge(2, 0, cities[25], cities[1], Client, routeRequest));

            edges.Add(new Edge(2, 0, cities[27], cities[31], Client, routeRequest));


            double[,] map = new double[32, 32];


            foreach (Edge edge in edges)
            {
                int city1Id = cities.FindIndex(city => edge.CityPair[0] == city);
                int city2Id = cities.FindIndex(city => edge.CityPair[1] == city);
                if (map[city1Id, city2Id] > edge.Price || map[city1Id, city2Id] == 0)
                {
                    map[city1Id, city2Id] = edge.Price;
                    map[city2Id, city1Id] = edge.Price;
                }
               
            }

           this.Result = CalculateShortestPath(map, routeRequest.from, routeRequest.to); 
        }
        
            public RouteResult CalculateShortestPath(double[,] map, string from, string to)
        {

            double[] dist = gfg.dijkstra(map, getCityIdByName(from));
            
            return new RouteResult(dist[getCityIdByName(to)], 0);
        }

        private int getCityIdByName(string name)
        {
            return cities.FindIndex(city => city.Name == name);
        }

    }
}
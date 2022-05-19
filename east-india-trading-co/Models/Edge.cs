namespace east_india_trading_co.Models
{
    public class Edge
    {
        public Edge(int type, double unit,  Node city1, Node city2)
        {
            this.Type = type;
            this.CityPair = new List<Node>() { city1, city2 };
            this.Unit = unit;
            this.Price = null;
            city1.Edges.Add(this);
            city1.Adjecent.Add(city2);
            city2.Edges.Add(this);
            city2.Adjecent.Add(city1);
        }

        public int Type { get; set; }
        public double Unit { get; set; }
        public List<Node> CityPair { get; set; }
        public double? Price { get; set; }
    }
}

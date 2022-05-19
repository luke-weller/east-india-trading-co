namespace east_india_trading_co.Models
{
    public class Node
    {
        public Node(int id, string name, List<Edge> edges)
        {
            Name = name;
            Edges = edges;
            Id = id;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Edge> Edges { get; set; }
        
    }
}

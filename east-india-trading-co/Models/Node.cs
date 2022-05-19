namespace east_india_trading_co.Models
{
    public class Node
    {
        public Node(int id, string name)
        {
            Name = name;
            Id = id;
            Edges = new List<Edge>();
            Adjecent = new HashSet<Node> ();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Edge> Edges { get; set; }
        public HashSet<Node> Adjecent { get; set; }
    }
}

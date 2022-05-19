namespace east_india_trading_co.Models
{
    public class Edge
    {
        public int Id { get; set; }
        public int type { get; set; }
        Tuple<Node, Node> cities { get; set; }
    }
}

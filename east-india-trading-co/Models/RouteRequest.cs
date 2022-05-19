using System.ComponentModel.DataAnnotations;

namespace east_india_trading_co.Models
{
    public class RouteRequest
    {
        public RouteRequest(string from, string to, int type, double weight, double width, double height, double length)
        {
            this.from = from;
            this.to = to;
            this.type = type;
            this.weight = weight;
            this.width = width;
            this.height = height;
            this.length = length;
        }

        [Required]
        public string from { get; set; }
        [Required]
        public string to { get; set; }
        [Required]
        public int type { get; set; }
        [Required]
        public double weight { get; set; }  
        [Required]
        public double width { get; set; }
        [Required]
        public double height { get; set; }
        [Required]
        public double length { get; set; }
    }
}

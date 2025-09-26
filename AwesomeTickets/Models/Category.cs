using Microsoft.Extensions.Logging;

namespace AwesomeTickets.Models
{
    public class Category
    {
        // primary key
        public int CategoryId { get; set; }
        public string Categoryname { get; set; } = string.Empty;
        // navigation property
        public Listing? Listing { get; set; }
    }
}

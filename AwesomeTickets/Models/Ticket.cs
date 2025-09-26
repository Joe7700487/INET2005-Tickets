using Microsoft.Extensions.Logging;

namespace AwesomeTickets.Models
{
    public class Ticket
    {
        // primary key
        public int TicketId { get; set; }
        public string ShowTitle { get; set; } = string.Empty;
        public DateTime ShowDate { get; set; }
        public string ShowLocation { get; set; } = string.Empty;
        // foreign key
        public int ShowId { get; set; }
        // navigation property
        public Show? Show { get; set; }
    }
}

namespace AwesomeTickets.Models
{
    public class Show
    {
        // primary key
        public int ShowId { get; set; }
        public string ShowTitle { get; set; } = string.Empty;
        public string ShowDescription { get; set; } = string.Empty;
        public string ShowCategory { get; set; } = string.Empty;
        public DateTime ShowDate { get; set; }
        public string ShowLocation { get; set; } = string.Empty;
        public string ShowOwner { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        // navigation property
        public List<Ticket>? Tickets { get; set; }
    }
}

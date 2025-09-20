namespace AwesomeTickets.Models
{
    public class Ticket
    {
        // primary key
        public int TicketId { get; set; }
        public string EventTitle { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public string EventLocation { get; set; } = string.Empty;
        // foreign key
        public int EventId { get; set; }
        // navigation property
        public Event? Event { get; set; }
    }
}


//date, time, location, owner (who is running the event), date and time record created.
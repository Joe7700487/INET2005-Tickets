namespace AwesomeTickets.Models
{
    public class Event
    {
        int EventId { get; set; }
        String EventTitle { get; set; } = string.Empty;
        String EventDescription { get; set; } = string.Empty;
        String EventCategory { get; set; } = string.Empty;
        DateTime EventDate { get; set; }
        String EventLocation { get; set; } = string.Empty;
        String EventOwner { get; set; } = string.Empty;
        DateTime DateCreated { get; set; }
    }
}


//date, time, location, owner (who is running the event), date and time record created.
namespace AwesomeTickets.Models
{
    public class Listing
    {
        // primary key
        public int ListingId { get; set; }
        public string ListingTitle { get; set; } = string.Empty;
        public string ListingDescription { get; set; } = string.Empty;
        public string ListingCategory { get; set; } = string.Empty;
        public DateTime ListingDate { get; set; }
        public string ListingLocation { get; set; } = string.Empty;
        public string ListingOwner { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        // navigation property
        public List<Category>? Categories { get; set; }
    }
}

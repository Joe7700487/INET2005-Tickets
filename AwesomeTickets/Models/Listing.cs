using System.ComponentModel.DataAnnotations;

namespace AwesomeTickets.Models
{
    public class Listing
    {
        // primary key
        [Display(Name = "ID")]
        public int ListingId { get; set; }
        [Display(Name = "Title")]
        public string ListingTitle { get; set; } = string.Empty;
        [Display(Name = "Description")]
        public string ListingDescription { get; set; } = string.Empty;
        [Display(Name = "Category")]
        public string ListingCategory { get; set; } = string.Empty;
        [Display(Name = "Date")]
        public DateTime ListingDate { get; set; }
        [Display(Name = "Location")]
        public string ListingLocation { get; set; } = string.Empty;
        [Display(Name = "Owner")]
        public string ListingOwner { get; set; } = string.Empty;
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
        // navigation property
        public List<Category>? Categories { get; set; }
    }
}

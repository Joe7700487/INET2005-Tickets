using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Display(Name = "Date")]
        public DateTime ListingDate { get; set; }
        [Display(Name = "Location")]
        public string ListingLocation { get; set; } = string.Empty;
        [Display(Name = "Owner")]
        public string ListingOwner { get; set; } = string.Empty;
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
        // foriegn key
        public int CategoryId { get; set; }
        // navigation property
        public Category? Category { get; set; }
        public List<Purchase>? Purchases { get; set; }

        [Display(Name = "File Name")]
        public string FileName { get; set; } = string.Empty;
        [NotMapped]
        [Display(Name = "Image")]
        public IFormFile? FormFile { get; set; }


    }
}

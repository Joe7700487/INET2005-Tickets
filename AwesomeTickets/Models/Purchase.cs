using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomeTickets.Models
{
    public class Purchase
    {
        // primary key
        [Display(Name = "ID")]
        public int PurchaseId { get; set; }
        public int ListingId { get; set; }
        // navigation property
        public Listing? Listing { get; set; }
        public int Tickets { get; set; }
        public string Customer { get; set; } = string.Empty;
        public string CustomerPhoneNumber { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string Expiry { get; set; } = string.Empty;
        public string CCV { get; set; } = string.Empty;


    }
}

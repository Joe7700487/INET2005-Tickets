using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace AwesomeTickets.Models
{
    public class Category
    {
        // primary key
        [Display(Name = "ID")]
        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; } = string.Empty;
        // navigation property
        public Listing? Listing { get; set; }
    }
}

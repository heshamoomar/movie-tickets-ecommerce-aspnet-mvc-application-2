using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTicket2.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }

		[Display(Name = "Profile Picture")]
		public string ProfilePictureURL { get; set; } = string.Empty;

		[Display(Name = "Full Name")]
		public string FullName { get; set; } = string.Empty;

		[Display(Name = "Biography")]
		public string Bio { get; set; } = string.Empty;

        // Relationships
        public List<Movie> Movies { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTicket2.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

		[Display(Name = "Cinema Logo")]
		public string Logo { get; set; } = string.Empty;

		[Display(Name = "Cinema Name")]
		public string Name { get; set; } = string.Empty;

		[Display(Name = "Description")]
		public string Description { get; set; } = string.Empty;

        // Relationships
        public List<Movie> Movies { get; set; }

    }
}

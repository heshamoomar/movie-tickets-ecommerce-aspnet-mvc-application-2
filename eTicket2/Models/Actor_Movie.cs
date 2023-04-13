using eTicket2.Models;
using System.ComponentModel.DataAnnotations;
namespace eTicket2.Models
{
    public class Actor_Movie
    {
        [Key]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }


    }
}

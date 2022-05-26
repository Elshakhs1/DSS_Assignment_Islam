using System.ComponentModel.DataAnnotations;

namespace DSS_Assignment_Islam.Models
{
    public class Circus
    {
        [Key]
        public int CircusID { get; set; }
        public string? CircusName { get; set; }
        public string? CircusLocation { get; set; }
        public ICollection<Actor>? Actors { get; set; }

    }
}

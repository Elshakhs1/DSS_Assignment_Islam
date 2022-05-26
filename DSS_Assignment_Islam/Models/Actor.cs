using System.ComponentModel.DataAnnotations;

namespace DSS_Assignment_Islam.Models
{
    public class Actor
    {
        [Key]
        public int ActorID { get; set; }
        public string? ActorName { get; set; }
        public string? ActorAge { get; set; }
        public string? ActorSpacielity { get; set; }
        public int CircusID { get; set; }
        public Circus? Circus { get; set; }
        public ICollection<Act>? Acts { get; set; }  
    }
}

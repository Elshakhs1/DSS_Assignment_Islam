namespace DSS_Assignment_Islam.Models
{
    public class Act
    {
        public int ActID { get; set; }
      
        public int ActorID { get; set; }
        public Actor? Actor { get; set; }
        public int TrickID { get; set; }
        public Trick? Trick { get; set; }

    }
}

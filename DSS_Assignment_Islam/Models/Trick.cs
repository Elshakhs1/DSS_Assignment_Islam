namespace DSS_Assignment_Islam.Models
{
    public class Trick
    {
        public int TrickID { get; set; }
        public string TrickName { get; set; }
        public ICollection<Act>? Acts { get; set; }

    }
}

namespace crudappMvc.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public required string Title { get; set; }

        public required string Description { get; set; }

        public required string Author { get; set; }
    }
}

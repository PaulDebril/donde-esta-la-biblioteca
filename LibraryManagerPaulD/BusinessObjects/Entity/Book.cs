namespace BusinessObjects.Entity
{
    public class Book : AEntity

    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Pages { get; set; }
        public BookType Type { get; set; }
        public int Rate { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}

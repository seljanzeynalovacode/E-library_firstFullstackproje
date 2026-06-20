namespace E_library.DAL.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public ICollection<Book> Books { get; set; }

        
    }
}

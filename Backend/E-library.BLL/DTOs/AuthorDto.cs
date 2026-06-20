namespace E_library.BLL.DTOs
{
    public record AuthorDto : BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}

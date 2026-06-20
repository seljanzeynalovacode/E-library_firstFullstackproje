
namespace E_library.BLL.DTOs
{
    public record BookDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}

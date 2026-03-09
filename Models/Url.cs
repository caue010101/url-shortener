namespace minhaApi.Models
{

    public class Url
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string OriginalUrl { get; set; } = string.Empty;
        public string ShortCode { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

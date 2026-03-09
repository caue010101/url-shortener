namespace minhaApi.Dtos
{

    public record ResponseUrlDto
    {

        public string ShortCode { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}

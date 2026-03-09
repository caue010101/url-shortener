using minhaApi.Interface.Repository;
using minhaApi.Interface.Service;
using minhaApi.Models;
using minhaApi.Dtos;

namespace minhaApi.Service
{

    public class UrlService : IUrlService
    {
        private readonly IUrlRepository _urlRepository;

        public UrlService(IUrlRepository urlRepository)
        {
            this._urlRepository = urlRepository;

        }

        public async Task<ResponseUrlDto> ShortUrlAsync(RequestUrlDto dto)
        {
            string code;

            while (true)
            {

                code = GenerateCodeAsync(6);

                if (!await _urlRepository.GetCodeAsync(code))
                {
                    break;
                }
            }

            var url = new Url
            {

                Id = Guid.NewGuid(),
                OriginalUrl = dto.OriginalUrl,
                ShortCode = code,
                CreatedAt = DateTime.UtcNow
            };

            await _urlRepository.CreateUrlAsync(url);

            return new ResponseUrlDto
            {
                ShortCode = code,
                CreatedAt = DateTime.UtcNow
            };
        }

        public string GenerateCodeAsync(int length)

        {

            const string characters = "abcdefghijklmnopqrstuvwxyz0123456789";

            return new string(Enumerable.Repeat(characters, length)
                .Select(s => s[Random.Shared.Next(s.Length)])
              .ToArray());
        }

        public async Task<string?> GetOriginalUrlByCodeAsync(string code)
        {

            return await _urlRepository.GetOriginalUrlByCodeAsync(code);
        }
    }
}

using minhaApi.Dtos;

namespace minhaApi.Interface.Service
{

    public interface IUrlService
    {

        Task<ResponseUrlDto> ShortUrlAsync(RequestUrlDto dto);
        String GenerateCodeAsync(int length);
        Task<string> GetOriginalUrlByCodeAsync(string code);

    }
}

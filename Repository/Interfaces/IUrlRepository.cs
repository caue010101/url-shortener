using minhaApi.Models;


namespace minhaApi.Interface.Repository
{

    public interface IUrlRepository
    {

        Task<bool> CreateUrlAsync(Url url);
        Task<bool> GetCodeAsync(string code);
        Task<string?> GetOriginalUrlByCodeAsync(string code);
    }
}

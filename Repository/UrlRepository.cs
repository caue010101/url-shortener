using minhaApi.Data;
using minhaApi.Models;
using minhaApi.Interface.Repository;
using Dapper;

namespace minhaApi.Repository
{

    public class UrlRepository : IUrlRepository
    {

        private readonly DapperContext _context;

        public UrlRepository(DapperContext context)
        {
            this._context = context;
        }

        public async Task<bool> CreateUrlAsync(Url url)
        {

            using var conn = _context.CreateConnection();

            const string sql = @"INSERT INTO urls (id, original_url, short_code, created_at)
                VALUES(@Id, @OriginalUrl, @ShortCode, @CreatedAt)";

            var rowsAffected = await conn.ExecuteAsync(sql, url);

            return rowsAffected > 0;

        }

        public async Task<string?> GetOriginalUrlByCodeAsync(string code)
        {

            using var conn = _context.CreateConnection();

            const string sql = @"SELECT original_url FROM urls WHERE short_code = @Code";

            return await conn.QueryFirstOrDefaultAsync<string>(sql, new { Code = code });
        }

        public async Task<bool> GetCodeAsync(string code)
        {

            using var conn = _context.CreateConnection();

            const string sql = @"SELECT EXISTS(SELECT 1 FROM  urls WHERE short_code = @Code)";

            var count = await conn.ExecuteScalarAsync<int>(sql, new { Code = code });

            return count > 1;
        }
    }
}

using Npgsql;
using System.Data;

namespace minhaApi.Data
{

    public class DapperContext
    {

        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}

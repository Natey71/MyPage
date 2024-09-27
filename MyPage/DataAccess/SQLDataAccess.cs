using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MyPage.DataAccess
{
    public class SQLDataAccess : ISQLDataAccess
    {

        private readonly IConfiguration _configuration;

        public SQLDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> GetDataParamsAsync<T, P>(string txt, P parameters)
        {
            string connId = "DefaultConnection";
            var BaseConnectionString = _configuration.GetConnectionString(connId) ?? throw new InvalidOperationException("Connection");
            using IDbConnection conn = new SqlConnection(BaseConnectionString);

            try
            {
                return await conn.QueryAsync<T>(txt, parameters, commandType: CommandType.Text, commandTimeout: 240);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }
        public async Task<IEnumerable<T>> GetDataNoParamsAsync<T>(string txt)
        {
            string connId = "DefaultConnection";
            var BaseConnectionString = _configuration.GetConnectionString(connId) ?? throw new InvalidOperationException("Connection");
            using IDbConnection conn = new SqlConnection(BaseConnectionString);

            try
            {
                return await conn.QueryAsync<T>(txt, commandType: CommandType.Text, commandTimeout: 240);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }

    }
}

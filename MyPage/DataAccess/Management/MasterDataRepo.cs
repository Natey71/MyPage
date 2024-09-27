using MyPage.Models;

namespace MyPage.DataAccess.Management
{
    public class MasterDataRepo : IMasterDataRepo
    {
        private readonly ISQLDataAccess _db;
        private readonly IConfiguration _config;

        public MasterDataRepo(ISQLDataAccess db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public async Task<IEnumerable<Languages>> GetLanguagesAsync()
        {
            string query = @"SELECT * FROM LANGUAGES;";
            return await _db.GetDataNoParamsAsync<Languages>(query);
        }
    }
}

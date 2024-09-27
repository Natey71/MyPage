using MyPage.Models;

namespace MyPage.DataAccess.Management
{
    public interface IMasterDataRepo
    {
        Task<IEnumerable<Languages>> GetLanguagesAsync();
    }
}

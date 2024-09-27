namespace MyPage.DataAccess
{
    public interface ISQLDataAccess
    {
        Task<IEnumerable<T>> GetDataParamsAsync<T, P>(string txt, P parameters);
        Task<IEnumerable<T>> GetDataNoParamsAsync<T>(string txt);
    }
}

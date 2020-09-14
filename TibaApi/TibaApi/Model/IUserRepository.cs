namespace TibaApi.Model
{
    public interface IUserRepository
    {
        User Fetch(string userName, string password);
        User FetchById(string userName);
        void Insert(User user);
        void UpdateToken(string userName, string token);
    }
}

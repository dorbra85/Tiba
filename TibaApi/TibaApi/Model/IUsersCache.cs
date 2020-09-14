namespace TibaApi.Model
{
    public interface IUsersCache
    {
        User TryGetUser(string userName);
        void InsertUser(User user);
    }
}

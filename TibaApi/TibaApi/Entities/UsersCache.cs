using System.Collections.Concurrent;
using TibaApi.Model;

namespace TibaApi.Entities
{
    public class UsersCache : IUsersCache
    {
        public ConcurrentDictionary<string, User> AppUsers { get; set; }
        public UsersCache()
        {
            AppUsers = new ConcurrentDictionary<string, User>();
        }
        public User TryGetUser(string userName)
        {
            if (AppUsers.ContainsKey(userName))
                return AppUsers[userName];

            return null;
        }

        public void InsertUser(User user)
        {
            if (AppUsers is null)
                return;

            AppUsers.TryAdd(user.UserName, user);
        }
    }
}

using System.Linq;
using TibaApi.Model;
using TibaApi.TibaDataAccess;

namespace TibaApi.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly GitHubContext _gitHubContext;
        public UserRepository(GitHubContext gitHubContext)
        {
            _gitHubContext = gitHubContext;
        }

        public User Fetch(string userName, string password)
        {
            return _gitHubContext.Users.SingleOrDefault(user =>
                                                         user.UserName == userName
                                                         && user.Password == password);
        }

        public User FetchById(string userName)
        {
            return _gitHubContext.Users.SingleOrDefault(user =>
                                                         user.UserName == userName);
        }

        public void Insert(User user)
        {
            _gitHubContext.Users.Add(user);
            _gitHubContext.SaveChanges();
        }

        public void UpdateToken(string userName, string token)
        {
            var user = _gitHubContext.Users.SingleOrDefault(user =>
                                                         user.UserName == userName);
            if (user != null)
            {
                user.Token = token;
                _gitHubContext.SaveChanges();
            }
        }


    }
}

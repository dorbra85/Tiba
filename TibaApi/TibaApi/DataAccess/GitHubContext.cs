using Microsoft.EntityFrameworkCore;
using TibaApi.Model;

namespace TibaApi.TibaDataAccess
{
    public class GitHubContext : DbContext
    {
        public GitHubContext(DbContextOptions<GitHubContext> options) : base(options)
        { }
        public DbSet<Repository> Repositories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

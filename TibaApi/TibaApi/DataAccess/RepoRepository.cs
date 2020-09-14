using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TibaApi.Model;
using TibaApi.TibaDataAccess;

namespace TibaApi.DataAccess
{
    public class RepoRepository : IRepoRepository
    {
        private readonly GitHubContext _gitHubContext;
        public RepoRepository(GitHubContext gitHubContext)
        {
            _gitHubContext = gitHubContext;
        }

        public async Task SaveSearchResult(IEnumerable<Repository> repos)
        {
            var unSavedRepos = repos.Where(repo => !_gitHubContext.Repositories.Any(rep => rep.Id == repo.Id));
            _gitHubContext.Repositories.AddRange(unSavedRepos);
            await _gitHubContext.SaveChangesAsync();
            return;
        }

        public async Task<IEnumerable<Model.Repository>> SearchRepositories()
        {
            return _gitHubContext.Repositories;
        }
    }
}

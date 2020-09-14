using System.Collections.Generic;
using System.Threading.Tasks;

namespace TibaApi.Model
{
    public interface IRepoRepository
    {
        Task SaveSearchResult(IEnumerable<Repository> repos);
        Task<IEnumerable<Model.Repository>> SearchRepositories();
    }
}

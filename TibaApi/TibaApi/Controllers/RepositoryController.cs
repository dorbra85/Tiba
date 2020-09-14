using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using TibaApi.Model;

namespace TibaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RepositoryController : ControllerBase
    {
        private readonly IRepoRepository _repoRepository;

        public RepositoryController(IRepoRepository repoRepository)
        {
            _repoRepository = repoRepository;
        }

        [HttpGet("{searchTerm}")]
        public async Task<IEnumerable<Model.Repository>> Get(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return null;

            var items = await GetSearchResult(searchTerm);

            return items;
        }

        [HttpGet]
        public async Task<IEnumerable<Model.Repository>> Get()
        {
            var items = await _repoRepository.SearchRepositories();

            return items;
        }

        [HttpPost]
        public async Task PostRepositoryItems(IEnumerable<Model.Repository> repos)
        {
            await _repoRepository.SaveSearchResult(repos);

            return;
        }

        private static async Task<IEnumerable<Model.Repository>> GetSearchResult(string searchTerm)
        {
            const int MaxCountItems = 100;
            var items = new List<Model.Repository>();

            var productInformation = new ProductHeaderValue("dor");
            var httpClient = new GitHubClient(productInformation)
                            {
                                Credentials = new Credentials("097459a8621fdf63bbcd30d4af13484bee9f4341") 
                            };


            //It was not clear if needed pagination to support more then 100 repository search
            var repositories = await httpClient.Search.SearchRepo(
                new SearchRepositoriesRequest(searchTerm)
                {
                    In = new InQualifier[] { InQualifier.Name },
                    Page = 1,
                    PerPage = MaxCountItems
                });


            foreach (var repo in repositories.Items)
                items.Add(new Model.Repository
                {
                    Id = repo.Id,
                    Name = repo.Name,
                    FullName = repo.FullName,
                    Description = repo.Description,
                    Private = repo.Private,
                });


            return items;
        }

    }
}

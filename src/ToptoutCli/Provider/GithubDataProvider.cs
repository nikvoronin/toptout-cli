using Flurl.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptoutCli.Model.Github;

namespace ToptoutCli.Provider
{
    public class GithubDataProvider
    {
        readonly string Flurl_UserAgent = $"Flurl/{typeof(FlurlHttp).Assembly.GetName().Version}";

        readonly string _repo;
        readonly string _path;

        public GithubDataProvider(string repo, string path)
        {
            _repo = repo;
            _path = path;
        }

                
        public async Task<TreeItem> RequestTreeItemAsync(string url)
        {
            return await url
                .WithHeader("User-Agent", Flurl_UserAgent)
                .GetJsonAsync<TreeItem>();
        }

        public async Task<IReadOnlyList<string>> ListJsonFilesAsync(string url)
        {
            TreeItem ti = await RequestTreeItemAsync(url);

            return ti.tree
                .Where(info => info.path.EndsWith(".json") && info.type == "blob")
                .Select(info => info.path.Substring(0, info.path.Length - 5))
                .ToList();
        }

        public async Task<string> RepoDataFolderUrlAsync()
        {
            var subfolders = _path.Split('/')
                .Where(s => !string.IsNullOrWhiteSpace(s.Trim()))
                .ToArray();

            return await FindFolderRecursiveAsync(_repo, subfolders);
        }

        private async Task<string> FindFolderRecursiveAsync(string url, string[] path)
        {
            TreeItem ti = await RequestTreeItemAsync(url);

            string name = path[0];
            string folderUrl = ti.tree
                .FirstOrDefault(child => child.path == name)?.url;

            return path.Length < 2
                ? folderUrl
                : await FindFolderRecursiveAsync(folderUrl, path[1..]);
        }
    }
}

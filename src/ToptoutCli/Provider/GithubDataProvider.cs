﻿using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptoutCli.Model.Github;

namespace ToptoutCli.Provider
{
    public class GithubDataProvider
    {
        static readonly string Default_UserAgent = $"Flurl/{typeof(FlurlHttp).Assembly.GetName().Version}";

        readonly string _repoArg;
        readonly string _path;
        readonly string _userRepo;
        readonly string _branch;

        public GithubDataProvider(string repoArg, string path)
        {
            _repoArg = repoArg;
            _path = path;

            var ps = _repoArg.Split("/");
            _userRepo = $"{ps[0]}/{ps[1]}";
            _branch = ps[2];
        }

        public async Task<string> GetJsonFileAsString(string appId)
        {
            string jsonPath = "https://" + $"raw.githubusercontent.com/{_userRepo}/{_branch}/data/{appId}.json";
            return await jsonPath.GetStringAsync();
        }

        public async Task<TreeItem> RequestTreeItemAsync(string url)
        {
            return await url
                .WithHeader("User-Agent", Default_UserAgent)
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

        public async Task<string> FindDataFolderUrlAsync()
        {
            var subfolders = _path.Split('/')
                .Where(s => !string.IsNullOrWhiteSpace(s.Trim()))
                .ToArray();

            string apiurl = "https://" + $"api.github.com/repos/{_userRepo}/git/trees/{_branch}";

            return await FindDataFolderRecursiveAsync(apiurl, subfolders);
        }

        private async Task<string> FindDataFolderRecursiveAsync(string url, string[] path)
        {
            TreeItem ti = await RequestTreeItemAsync(url);

            string name = path[0];
            string folderUrl = ti.tree
                .FirstOrDefault(child => child.path == name)
                ?.url;

            return path.Length < 2
                ? folderUrl
                : await FindDataFolderRecursiveAsync(folderUrl, path[1..]);
        }
    }
}

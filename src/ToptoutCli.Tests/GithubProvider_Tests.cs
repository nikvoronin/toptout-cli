using IO.Swagger.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToptoutCli.Commands;
using ToptoutCli.Commands.Options;
using ToptoutCli.Provider;
using Xunit;

namespace ToptoutCli.Tests
{
    public class GithubProvider_Tests
    {
        [Fact]
        public async Task Find_RepoDataFolderUrl()
        {
            var provider = new GithubDataProvider(
                RepoOption.Default_ToptoutDataUserRepo,
                UpdateCommand.Default_ToptoutRepoPath);

            string url = await provider.FindDataFolderUrlAsync();

            Assert.NotNull(url);
        }

        [Fact]
        public async Task ListJsonFiles()
        {
            var provider = new GithubDataProvider(
                RepoOption.Default_ToptoutDataUserRepo,
                UpdateCommand.Default_ToptoutRepoPath);

            string url = await provider.FindDataFolderUrlAsync();

            var files = await provider.ListJsonFilesAsync(url);

            Assert.NotNull(url);

            Assert.NotNull(files);
            Assert.True(files.Count > 0);
        }

        [Fact]
        public async Task LoadJsonFile()
        {
            var provider = new GithubDataProvider(
                RepoOption.Default_ToptoutDataUserRepo,
                UpdateCommand.Default_ToptoutRepoPath);

            string url = await provider.FindDataFolderUrlAsync();

            var files = await provider.ListJsonFilesAsync(url);

            string jsonString = await provider.GetJsonFileAsString(files[0]);
            var t = JsonConvert.DeserializeObject<Toptout>(jsonString);

            Assert.NotNull(url);

            Assert.NotNull( files );
            Assert.True( files.Count > 0 );
            Assert.False( string.IsNullOrEmpty(jsonString) );
            Assert.NotNull( t );
        }
    }
}

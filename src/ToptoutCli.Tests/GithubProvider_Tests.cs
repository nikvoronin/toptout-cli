using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                UpdateCommand.Default_ToptoutDataRepo,
                UpdateCommand.Default_ToptoutRepoPath);

            string url = await provider.RepoDataFolderUrlAsync();

            Assert.NotNull(url);
        }

        [Fact]
        public async Task ListJsonFiles()
        {
            var provider = new GithubDataProvider(
                UpdateCommand.Default_ToptoutDataRepo,
                UpdateCommand.Default_ToptoutRepoPath);

            string url = await provider.RepoDataFolderUrlAsync();
            var files = await provider.ListJsonFilesAsync(url);

            Assert.NotNull(url);

            Assert.NotNull(files);
            Assert.True(files.Count > 0);
        }
    }
}

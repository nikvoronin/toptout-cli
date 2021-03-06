using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToptoutCli.Model.Github
{
    public class TreeItem
    {
        public string sha;
        public string url;
        public IReadOnlyList<TreeItemInfo> tree;
        public bool truncated;
    }
}

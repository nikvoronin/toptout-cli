using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Parsing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToptoutCli.Commands.Options
{
    public class RepoOption
    {
        public const string Default_ToptoutDataUserRepo = "beatcracker/toptout/master";

        public static Option<string> Create()
        {         
            var o = new Option<string> (
                aliases: new[]{ "--user-repo-branch", "--repo" },
                description: "Changes 'user/repo/branch' of the Github repository with a data",
                getDefaultValue: () => Default_ToptoutDataUserRepo
                );

            o.AllowMultipleArgumentsPerToken = false;
            o.AddValidator(r => Validate(r.Tokens));

            return o;
        }

        public static string Validate(IReadOnlyList<Token> tokens)
        {
            if (tokens.Count == 0)
                return null;

            if (tokens.Count > 1)
                return "ERROR: Too much arguments.";

            if (tokens[0].Type != TokenType.Argument)
                return "ERROR: Not an argument.";

            if (tokens[0].Value.Split("/").Length != 3)
                return "ERROR: Wrong arguments format. Expected 'username/repo/branch'.";

            return null;
        }
    }
}

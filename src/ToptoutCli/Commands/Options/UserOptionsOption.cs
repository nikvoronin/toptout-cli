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
    public class UserOptionsOption
    {
        public static Option<string> Create()
        {
            var o = new Option<string> (
                alias: "--options",
                description: "Set filename of the user defined options",
                getDefaultValue: () => Const.Default_UserOptionsFilename
                );
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

            if (!File.Exists(tokens[0].Value))
                return "ERROR: Can not open given file at `{tokens[0].Value}`.";

            return null;
        }
    }
}

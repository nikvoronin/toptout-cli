using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToptoutCli.Commands;
using Xunit;

namespace ToptoutCli.Tests
{
    public class Update_Cli_Options
    {
        [Theory]
        [InlineData(true, "user/repo/branch", TokenType.Argument)]
        [InlineData(true, "uuuu/rrrrreee/bbbb", TokenType.Argument)]
        [InlineData(false, "user/repo/branch", TokenType.Operand)]
        [InlineData(false, "user/repo/branch", TokenType.Command)]
        [InlineData(false, "uuuu-rrrrreee-bbbrrrr", TokenType.Argument)]
        [InlineData(false, "user/re/po/br/a/nch", TokenType.Argument)]
        [InlineData(false, "iamzetmib", TokenType.Argument)]
        [InlineData(false, "--amend", TokenType.Argument)]
        public void Validate_UpdateCommand_Options(bool valid, string newUserRepo, TokenType ttype)
        {
            Assert.Equal(
                valid,
                UpdateCommand.ValidateRepoArg(new List<Token>() { new Token(newUserRepo, ttype) }) == null);
        }

    }
}
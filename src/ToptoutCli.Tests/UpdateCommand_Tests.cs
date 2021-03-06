using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ToptoutCli.Tests
{
    public class Update_Cli_Options
    {
        [Theory]
        [InlineData(true, "user/repo", TokenType.Argument)]
        [InlineData(true, "uuuu/rrrrreee", TokenType.Argument)]
        [InlineData(false, "user/repo", TokenType.Operand)]
        [InlineData(false, "user/repo", TokenType.Command)]
        [InlineData(false, "uuuu-rrrrreee", TokenType.Argument)]
        [InlineData(false, "user/re/po", TokenType.Argument)]
        [InlineData(false, "iamzet", TokenType.Argument)]
        [InlineData(false, "--amend", TokenType.Argument)]
        public void Validate_UpdateCommand_Options(bool valid, string newUserRepo, TokenType ttype)
        {
            Assert.Equal(
                valid,
                UpdateCommand.Validate(new List<Token>() { new Token(newUserRepo, ttype) }) == null);
        }

    }
}
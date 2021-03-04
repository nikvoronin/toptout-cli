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
        [Fact]
        public void Default_Or_Absent_UserRepo()
        {
            var cmd = new RootCommand();

            cmd.AddCommand( UpdateCommand.Create(
                (userRepo) => {
                    Assert.True(userRepo == UpdateCommand.Default_UserRepo);
                }));

            cmd.Handler = CommandHandler.Create(() => {
                Assert.True(false);
            });

            int errlevel = cmd.Invoke( "update" );
        }

        [Theory]
        [InlineData("user/repo")]
        [InlineData("uuuu/rrrrreee")]
        public void Valid_Another_UserRepo(string newUserRepo)
        {
            var cmd = new RootCommand();

            bool updateCommandCalled = false;
            bool rootCommandCalled = false;

            cmd.AddCommand(UpdateCommand.Create(
                (userRepo) => {
                    Assert.True(userRepo == newUserRepo);
                    updateCommandCalled = true;
                }));

            cmd.Handler = CommandHandler.Create(() => {
                rootCommandCalled = true;
            });

            int errlevel = cmd.Invoke( $"update --user-repo {newUserRepo}" );

            Assert.False(rootCommandCalled);
            Assert.True(updateCommandCalled);
        }

        [Theory]
        [InlineData("user/re/po")]
        [InlineData("uuuu-rrrrreee")]
        [InlineData("iamzet")]
        [InlineData("--amend")]
        public void Invalid_Another_UserRepo(string newUserRepo)
        {
            var cmd = new RootCommand();

            bool updateCommandCalled = false;
            bool rootCommandCalled = false;

            cmd.AddCommand(UpdateCommand.Create(
                (userRepo) => {
                    updateCommandCalled = true;
                }));

            cmd.Handler = CommandHandler.Create(() => {
                rootCommandCalled = true;
            });

            int errlevel = cmd.Invoke( $"update --user-repo {newUserRepo}" );

            Assert.False(rootCommandCalled);
            Assert.False(updateCommandCalled);
        }

        [Theory]
        [InlineData(true, "user/repo", TokenType.Argument)]
        [InlineData(true, "uuuu/rrrrreee", TokenType.Argument)]
        [InlineData(false, "user/repo", TokenType.Operand)]
        [InlineData(false, "user/repo", TokenType.Command)]
        [InlineData(false, "uuuu-rrrrreee", TokenType.Argument)]
        [InlineData(false, "user/re/po", TokenType.Argument)]
        [InlineData(false, "iamzet", TokenType.Argument)]
        [InlineData(false, "--amend", TokenType.Argument)]
        public void Validate_Update_Options(bool valid, string newUserRepo, TokenType ttype)
        {
            Assert.Equal(
                valid, 
                UpdateCommand.Validate( new List<Token>() { new Token(newUserRepo, ttype) }) == null );
        }

    }
}

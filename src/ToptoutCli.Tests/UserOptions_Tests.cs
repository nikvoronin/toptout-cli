using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ToptoutCli.Tests
{
    public class UserOptions_Tests
    {
        [Theory]
        [InlineData("[-]   switch telemetry off")]
        [InlineData("(+) turn telemetry back again")]
        [InlineData("   {-} name of the module")]
        [InlineData(" |+|  name of the module 2")]
        [InlineData("[.]  ignore opts for module_name_3")]
        [InlineData("    [ ] do nothing for module_that_called_four")]
        [InlineData("\t[_] still do nothing mod-5")]
        public void Match_ValidValues(string line)
        {
            var result = UserOptions.MatchLine(line);
            Assert.True( result.IsSuccess );
        }

        [Theory]
        [InlineData("switch telemetry off ++")]
        [InlineData("[-]   switch telemetry off")]
        [InlineData("( + ) turn telemetry back again")]
        [InlineData("/-/ name of the module")]
        [InlineData("|+++|  name of the module 2")]
        [InlineData("[...]  ignore opts for module_name_3")]
        [InlineData("[] do nothing for module_that_called_four")]
        [InlineData("[\t] still do nothing mod-5")]
        public void Match_InvalidValues(string line)
        {
            var result = UserOptions.MatchLine(line);
            Assert.True(result.IsFailed);
        }
    }
}

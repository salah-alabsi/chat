using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace ChatApp.Pages;

[Collection(ChatAppTestConsts.CollectionDefinitionName)]
public class Index_Tests : ChatAppWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}

using Soenneker.Compression.XZ.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Compression.XZ.Tests;

[Collection("Collection")]
public sealed class IxzUtilTests : FixturedUnitTest
{
    private readonly IXZUtil _util;

    public IxzUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IXZUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}

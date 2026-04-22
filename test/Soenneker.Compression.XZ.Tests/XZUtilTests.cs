using Soenneker.Compression.XZ.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Compression.XZ.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class XZUtilTests : HostedUnitTest
{
    private readonly IXZUtil _util;

    public XZUtilTests(Host host) : base(host)
    {
        _util = Resolve<IXZUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}

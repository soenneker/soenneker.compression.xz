using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Compression.XZ.Abstract;
using Soenneker.Hashing.Sha256;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Compression.XZ.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class XZUtilTests : HostedUnitTest
{
    private static readonly Sha256HashingUtil _sha256 = new();

    private readonly IXZUtil _util;

    public XZUtilTests(Host host) : base(host)
    {
        _util = Resolve<IXZUtil>(true);
    }

    [Test]
    public async Task Decompress_BcjLzma2Archive(CancellationToken cancellationToken)
    {
        const string compressed =
            "/Td6WFoAAAFpIt42AgEEACEBFgANhjUf4///AH9dAABv/f//o7f/Rz5IFXI5YVG4kijmo4YH+e7kHoLTL8U6PAFLsX7JiopNL6MN2X+m44wjEVPgWRjFdYrid/i2lH8MasDedElk4ulcU7IE2PdEDKtZ4ugje5u5w+PdTgt9QnobE+/60+0+bW7Qlu7dH0rzDaWr0k3aii8vcdXKWsAAANETr1gAAZcBgIAQAHxk+Lg+MA2LAgAAAAABWVo=";
        const string expectedSha256 = "248D95DBF55FC8410BF43EB6955190BA04B9E57B04335BE725CA4DBD90CB0296";

        string inputPath = Path.GetTempFileName();
        string outputPath = Path.GetTempFileName();

        try
        {
            await File.WriteAllBytesAsync(inputPath, Convert.FromBase64String(compressed));
            await _util.Decompress(inputPath, outputPath, cancellationToken: cancellationToken);

            await using FileStream output = File.OpenRead(outputPath);
            string actualSha256 = Convert.ToHexString(await _sha256.Hash(output, cancellationToken));

            await Assert.That(actualSha256).IsEqualTo(expectedSha256);
        }
        finally
        {
            File.Delete(inputPath);
            File.Delete(outputPath);
        }
    }
}

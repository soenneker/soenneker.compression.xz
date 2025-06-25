using SharpCompress.Compressors.Xz;
using Soenneker.Compression.XZ.Abstract;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.Task;
using System.Threading;

namespace Soenneker.Compression.XZ;

/// <inheritdoc cref="IXZUtil"/>
public sealed class XZUtil: IXZUtil
{
    private readonly ILogger<XZUtil> _logger;

    public XZUtil(ILogger<XZUtil> logger)
    {
        _logger = logger;
    }

    public async ValueTask Decompress(string filePath, string outputFilePath, CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Decompressing XZ file: {XzFilePath} to {OutputFilePath} ...", filePath, outputFilePath);

        await using FileStream xzInput = File.OpenRead(filePath);
        await using var xzStream = new XZStream(xzInput);
        await using FileStream output = File.Create(outputFilePath);
        await xzStream.CopyToAsync(output, cancellationToken).NoSync();
    }
}

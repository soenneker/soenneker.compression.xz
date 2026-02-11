using SharpCompress.Compressors.Xz;
using Soenneker.Compression.XZ.Abstract;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.Task;

namespace Soenneker.Compression.XZ;

/// <inheritdoc cref="IXZUtil"/>
public sealed class XZUtil : IXZUtil
{
    private readonly ILogger<XZUtil> _logger;

    // 128KB is a good general-purpose streaming buffer for disk -> CPU -> disk...
    private const int _copyBufferSize = 128 * 1024;

    public XZUtil(ILogger<XZUtil> logger)
    {
        _logger = logger;
    }

    public async ValueTask Decompress(string filePath, string outputFilePath, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogDebug("Decompressing XZ file: {XzFilePath} to {OutputFilePath} ...", filePath, outputFilePath);

        var inputOptions = new FileStreamOptions
        {
            Mode = FileMode.Open,
            Access = FileAccess.Read,
            Share = FileShare.Read,
            Options = FileOptions.Asynchronous | FileOptions.SequentialScan,
            BufferSize = _copyBufferSize
        };

        var outputOptions = new FileStreamOptions
        {
            Mode = FileMode.Create,
            Access = FileAccess.Write,
            Share = FileShare.None,
            Options = FileOptions.Asynchronous | FileOptions.SequentialScan,
            BufferSize = _copyBufferSize
        };

        await using var input = new FileStream(filePath, inputOptions);
        await using var xz = new XZStream(input);
        await using var output = new FileStream(outputFilePath, outputOptions);

        await xz.CopyToAsync(output, _copyBufferSize, cancellationToken).NoSync();
    }
}
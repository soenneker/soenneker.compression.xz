using LzmaNet;
using Soenneker.Compression.XZ.Abstract;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.Task;
using Soenneker.Utils.File.Abstract;

namespace Soenneker.Compression.XZ;

/// <inheritdoc cref="IXZUtil"/>
public sealed class XZUtil : IXZUtil
{
    private readonly ILogger<XZUtil> _logger;
    private readonly IFileUtil _fileUtil;

    // 128KB is a good general-purpose streaming buffer for disk -> CPU -> disk...
    private const int _copyBufferSize = 128 * 1024;

    public XZUtil(ILogger<XZUtil> logger, IFileUtil fileUtil)
    {
        _logger = logger;
        _fileUtil = fileUtil;
    }

    public async ValueTask Decompress(string filePath, string outputFilePath, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogDebug("Decompressing XZ file: {XzFilePath} to {OutputFilePath} ...", filePath, outputFilePath);

        await _fileUtil.WriteAtomically(outputFilePath, async (output, ct) =>
        {
            await using var input = _fileUtil.OpenRead(filePath, log: false);
            await using var xz = new XzDecompressStream(input);
            await xz.CopyToAsync(output, _copyBufferSize, ct).NoSync();
        }, log: false, cancellationToken).ConfigureAwait(false);
    }
}

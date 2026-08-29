using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Compression.XZ.Abstract;

/// <summary>
/// A utility library dealing with XZ compression and decompression
/// </summary>
public interface IXZUtil
{
    /// <summary>
    /// Decompresses XZ.
    /// </summary>
    /// <param name="filePath">Path of the file to use.</param>
    /// <param name="outputFilePath">Path of the output file to use.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the decompress operation is complete.</returns>
    ValueTask Decompress(string filePath, string outputFilePath, CancellationToken cancellationToken = default);
}

using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Compression.XZ.Abstract;

/// <summary>
/// A utility library dealing with XZ compression and decompression
/// </summary>
public interface IXZUtil
{
    /// <summary>
    /// Executes the decompress operation.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="outputFilePath">The output file path.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    ValueTask Decompress(string filePath, string outputFilePath, CancellationToken cancellationToken = default);
}

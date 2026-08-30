using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Compression.XZ.Abstract;

/// <summary>
/// Decompresses XZ streams to files.
/// </summary>
public interface IXZUtil
{
    /// <summary>
    /// Decompresses an XZ file to the specified output path.
    /// </summary>
    /// <param name="filePath">Path to the XZ input file.</param>
    /// <param name="outputFilePath">Path to the decompressed output file.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task representing the decompression operation.</returns>
    /// <remarks>The output is replaced only after decompression completes successfully.</remarks>
    ValueTask Decompress(string filePath, string outputFilePath, CancellationToken cancellationToken = default);
}

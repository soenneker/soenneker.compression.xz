using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Compression.XZ.Abstract;

/// <summary>
/// A utility library dealing with XZ compression and decompression
/// </summary>
public interface IXZUtil
{
    ValueTask Decompress(string filePath, string outputFilePath, CancellationToken cancellationToken = default);
}

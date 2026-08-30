[![](https://img.shields.io/nuget/v/soenneker.compression.xz.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.compression.xz/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.compression.xz/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.compression.xz/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.compression.xz.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.compression.xz/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.compression.xz/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.compression.xz/actions/workflows/codeql.yml)

# Soenneker.Compression.XZ

Streams an XZ-compressed file to a decompressed output file.

## Install

```bash
dotnet add package Soenneker.Compression.XZ
```

## Registration

```csharp
using Soenneker.Compression.XZ.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddXZUtilAsSingleton();
```

Use `AddXZUtilAsScoped()` instead when its lifetime should follow a dependency-injection scope.

## Usage

```csharp
using Soenneker.Compression.XZ.Abstract;

public sealed class SnapshotDecoder(IXZUtil xzUtil)
{
    public ValueTask Decode(CancellationToken cancellationToken = default)
    {
        return xzUtil.Decompress("snapshot.json.xz", "snapshot.json", cancellationToken);
    }
}
```

The decoder writes to a uniquely named sibling file and moves it over `outputFilePath` only after decompression succeeds. An existing output therefore remains intact if decoding fails or is cancelled.

## Practical notes

- The output file's parent directory must already exist.
- A successfully decoded file replaces an existing output at the requested path.
- Temporary output is removed after failure or cancellation.
- Decompressed data is streamed with a 128 KiB buffer rather than loaded into memory.
- This package decompresses XZ; it does not create XZ streams.
- XZ files can expand substantially. Enforce input and storage limits before decoding untrusted content.

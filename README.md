[![](https://img.shields.io/nuget/v/soenneker.compression.xz.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.compression.xz/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.compression.xz/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.compression.xz/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.compression.xz.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.compression.xz/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.compression.xz/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.compression.xz/actions/workflows/codeql.yml)

# Soenneker.Compression.XZ

A utility library dealing with XZ compression and decompression.

## Install

```bash
dotnet add package Soenneker.Compression.XZ
```

## Quick start

```csharp
using Soenneker.Compression.XZ.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddXZUtilAsSingleton();
```

Adds `IXZUtil` as a singleton service.

## What you get

- `IXZUtil` — A utility library dealing with XZ compression and decompression.
- `XZUtilRegistrar` — A utility library dealing with XZ compression and decompression.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IXZUtil.Decompress(filePath, outputFilePath, cancellationToken)` | Decompresses XZ. | A task that completes when the decompress operation is complete. |
| `XZUtilRegistrar.AddXZUtilAsSingleton(services)` | Adds `IXZUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `XZUtilRegistrar.AddXZUtilAsScoped(services)` | Adds `IXZUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.

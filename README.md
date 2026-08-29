[![](https://img.shields.io/nuget/v/Soenneker.Extensions.MemoryStream.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.MemoryStream/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.memorystream/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.memorystream/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Extensions.MemoryStream.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.MemoryStream/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.memorystream/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.memorystream/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.MemoryStream
Exposes the written portion of a `MemoryStream` as `ReadOnlyMemory<byte>` without copying it.

## Installation

```bash
dotnet add package Soenneker.Extensions.MemoryStream
```

## Usage

```csharp
using Soenneker.Extensions.MemoryStream;

using var stream = new MemoryStream();
stream.Write([1, 2, 3]);

ReadOnlyMemory<byte> bytes = stream.ToReadOnlyMemoryBytes(); // [1, 2, 3]
```

Despite its old XML wording, this method does not encode a string. It returns a zero-copy view over the stream's underlying buffer from index `0` through `Length`; the stream's current `Position` is irrelevant.

Because the memory aliases the stream buffer, later writes can be visible through the returned memory. `GetBuffer()` must be permitted—streams created over a non-publicly-visible external buffer throw `UnauthorizedAccessException`. The length must fit in an `int`.

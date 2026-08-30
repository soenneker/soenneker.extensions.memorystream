[![](https://img.shields.io/nuget/v/Soenneker.Extensions.MemoryStream.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.MemoryStream/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.memorystream/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.memorystream/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Extensions.MemoryStream.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.MemoryStream/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.memorystream/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.memorystream/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.MemoryStream
Extension methods for working with `MemoryStream` instances, including efficient buffer access, conversion, positioning, and other common stream operations.

## Installation

```bash
dotnet add package Soenneker.Extensions.MemoryStream
```

## Expose the valid buffer without copying

```csharp
using Soenneker.Extensions.MemoryStream;

using var stream = new MemoryStream();
stream.Write([1, 2, 3]);

ReadOnlyMemory<byte> bytes = stream.ToReadOnlyMemoryBytes(); // [1, 2, 3]
```

`ToReadOnlyMemoryBytes()` returns a zero-copy `ReadOnlyMemory<byte>` view over the stream's valid underlying buffer segment. The stream's current `Position` does not affect the returned range.

For a stream created over an array segment, the returned memory begins at that segment's offset rather than at index zero of the underlying array:

```csharp
byte[] buffer = [99, 1, 2, 3, 88];
using var stream = new MemoryStream(buffer, 1, 3, writable: false, publiclyVisible: true);

ReadOnlyMemory<byte> bytes = stream.ToReadOnlyMemoryBytes(); // [1, 2, 3]
```

Because the memory aliases the stream buffer, later writes through the stream or another owner of the array can be visible through the returned memory. `ReadOnlyMemory<byte>` prevents mutation through this particular view; it does not make the underlying bytes immutable or create a snapshot. Call `ToArray()` on the returned memory when an independent copy is required.

Buffer visibility must be permitted. A `MemoryStream` created over a non-publicly-visible external buffer throws `UnauthorizedAccessException`. A null or disposed/inaccessible stream follows the underlying `MemoryStream` buffer APIs' exception behavior.

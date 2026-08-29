[![](https://img.shields.io/nuget/v/Soenneker.Extensions.MemoryStream.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.MemoryStream/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.memorystream/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.memorystream/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Extensions.MemoryStream.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.MemoryStream/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.memorystream/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.memorystream/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.MemoryStream
A collection of helpful MemoryStream extension methods.

## Installation

```bash
dotnet add package Soenneker.Extensions.MemoryStream
```

## Quick start

```csharp
using Soenneker.Extensions.MemoryStream;

// Given an existing System.IO.MemoryStream named value:
var result = value.ToReadOnlyMemoryBytes();
```

## Common operations

- `ToReadOnlyMemoryBytes()` - Returns a zero-copy view over the stream's internal buffer through `Length`; the stream must expose its buffer.

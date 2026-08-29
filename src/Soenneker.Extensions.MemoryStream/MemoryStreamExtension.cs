using System;
using System.Diagnostics.Contracts;

namespace Soenneker.Extensions.MemoryStream;

/// <summary>
/// A collection of helpful MemoryStream extension methods
/// </summary>
public static class MemoryStreamExtension
{
    /// <summary>
    /// Encodes the string as UTF-8 bytes in read-only memory.
    /// </summary>
    /// <param name="value">The stream whose written bytes are exposed.</param>
    /// <returns>Read-only memory containing the UTF-8 bytes.</returns>
    [Pure]
    public static ReadOnlyMemory<byte> ToReadOnlyMemoryBytes(this System.IO.MemoryStream value)
    {
        return new ReadOnlyMemory<byte>(value.GetBuffer(), 0, (int)value.Length);
    }
}
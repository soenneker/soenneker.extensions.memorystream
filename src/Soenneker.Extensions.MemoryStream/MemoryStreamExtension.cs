using System;
using System.Diagnostics.Contracts;

namespace Soenneker.Extensions.MemoryStream;

/// <summary>
/// A collection of helpful MemoryStream extension methods
/// </summary>
public static class MemoryStreamExtension
{
    /// <summary>
    /// Returns a read-only view of the stream's valid underlying buffer segment.
    /// </summary>
    /// <param name="value">The stream whose written bytes are exposed.</param>
    /// <returns>Read-only memory that aliases the bytes from the beginning of the stream through its length.</returns>
    [Pure]
    public static ReadOnlyMemory<byte> ToReadOnlyMemoryBytes(this System.IO.MemoryStream value)
    {
        if (!value.TryGetBuffer(out ArraySegment<byte> segment))
        {
            // Preserve MemoryStream.GetBuffer()'s established exception for a non-public buffer.
            value.GetBuffer();
        }

        return new ReadOnlyMemory<byte>(segment.Array!, segment.Offset, segment.Count);
    }
}

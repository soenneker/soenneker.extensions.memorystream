using System;
using System.Diagnostics.Contracts;

namespace Soenneker.Extensions.MemoryStream;

/// <summary>
/// A collection of helpful MemoryStream extension methods
/// </summary>
public static class MemoryStreamExtension
{
    /// <summary>
    /// Executes the to read only memory bytes operation.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The result of the operation.</returns>
    [Pure]
    public static ReadOnlyMemory<byte> ToReadOnlyMemoryBytes(this System.IO.MemoryStream value)
    {
        return new ReadOnlyMemory<byte>(value.GetBuffer(), 0, (int)value.Length);
    }
}
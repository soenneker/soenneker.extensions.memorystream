using System.Linq;
using Soenneker.Tests.Unit;

namespace Soenneker.Extensions.MemoryStream.Tests;

public class MemoryStreamExtensionTests : UnitTest
{
    [Test]
    public async System.Threading.Tasks.Task Uses_the_stream_segment_offset()
    {
        byte[] buffer = [99, 1, 2, 3, 88];
        using var stream = new System.IO.MemoryStream(buffer, 1, 3, writable: false, publiclyVisible: true);

        byte[] result = stream.ToReadOnlyMemoryBytes().ToArray();

        await Assert.That(result.SequenceEqual(new byte[] {1, 2, 3})).IsTrue();
    }
}

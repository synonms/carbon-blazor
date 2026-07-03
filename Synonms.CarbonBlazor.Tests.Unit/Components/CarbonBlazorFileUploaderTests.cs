using Bunit;
using Microsoft.AspNetCore.Components.Forms;
using Synonms.CarbonBlazor.Components;
using Synonms.CarbonBlazor.Enumerations;

namespace Synonms.CarbonBlazor.Tests.Unit.Components;

public class CarbonBlazorFileUploaderTests : IDisposable
{
    private readonly BunitContext _ctx = new();
    private readonly List<IBrowserFile> _emptyFiles = [];

    public CarbonBlazorFileUploaderTests()
    {
        _ctx.JSInterop.Mode = JSRuntimeMode.Loose;
    }

    public void Dispose() => _ctx.Dispose();

    [Fact]
    public void Renders_ButtonTrigger()
    {
        IRenderedComponent<CarbonBlazorFileUploader> cut = _ctx.Render<CarbonBlazorFileUploader>(
            parameters => parameters
                .Add(p => p.FieldIdentifier, FieldIdentifier.Create(() => _emptyFiles))
                .Add(p => p.Label, "Upload files"));

        cut.Find(".cb-file-uploader-trigger-shell");
    }

    [Fact]
    public void Renders_DropZoneVariant()
    {
        IRenderedComponent<CarbonBlazorFileUploader> cut = _ctx.Render<CarbonBlazorFileUploader>(
            parameters => parameters
                .Add(p => p.FieldIdentifier, FieldIdentifier.Create(() => _emptyFiles))
                .Add(p => p.Variant, CarbonBlazorFileUploaderVariant.DragAndDrop));

        cut.Find(".cb-file-uploader-drop-zone");
    }

    [Fact]
    public void Renders_SelectedFiles()
    {
        List<IBrowserFile> files =
        [
            new TestBrowserFile("alpha.txt"),
            new TestBrowserFile("bravo.txt")
        ];

        IRenderedComponent<CarbonBlazorFileUploader> cut = _ctx.Render<CarbonBlazorFileUploader>(
            parameters => parameters
                .Add(p => p.FieldIdentifier, FieldIdentifier.Create(() => files))
                .Add(p => p.Files, files));

        Assert.Equal(2, cut.FindAll(".cb-file-uploader-file").Count);
        Assert.Contains("alpha.txt", cut.Markup);
        Assert.Contains("bravo.txt", cut.Markup);
    }

    [Fact]
    public void RemovesFile_WhenRemoveButtonClicked()
    {
        List<IBrowserFile> files =
        [
            new TestBrowserFile("alpha.txt"),
            new TestBrowserFile("bravo.txt")
        ];

        IRenderedComponent<CarbonBlazorFileUploader> cut = _ctx.Render<CarbonBlazorFileUploader>(
            parameters => parameters
                .Add(p => p.FieldIdentifier, FieldIdentifier.Create(() => files))
                .Add(p => p.Files, files));

        cut.FindAll(".cb-file-uploader-remove")[0].Click();

        Assert.Single(cut.FindAll(".cb-file-uploader-file"));
        Assert.DoesNotContain("alpha.txt", cut.Markup);
    }

    private sealed class TestBrowserFile : IBrowserFile
    {
        public TestBrowserFile(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public DateTimeOffset LastModified => DateTimeOffset.UtcNow;

        public long Size => 1;

        public string ContentType => "text/plain";

        public Stream OpenReadStream(long maxAllowedSize = 512000, CancellationToken cancellationToken = default) =>
            Stream.Null;
    }
}

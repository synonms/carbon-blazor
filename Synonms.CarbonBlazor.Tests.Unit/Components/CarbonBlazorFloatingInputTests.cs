using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Synonms.CarbonBlazor.Components;

namespace Synonms.CarbonBlazor.Tests.Unit.Components;

public class CarbonBlazorFloatingInputTests : IDisposable
{
    private readonly BunitContext _ctx = new BunitContext();

    public void Dispose()
    {
        _ctx.Dispose();
    }

    [Fact]
    public void Updates_AllSupportedFloatingPointTypes()
    {
        AssertInputChange(1.5f, "2.5", 2.5f);
        AssertInputChange(1.5d, "2.5", 2.5d);
        AssertInputChange(1.5m, "2.5", 2.5m);
    }

    [Fact]
    public void Updates_NullableFloatingPointTypes_AndClearsEmptyValues()
    {
        AssertInputChange((float?)1.5f, "2.5", (float?)2.5f);
        AssertInputChange((double?)1.5d, "2.5", (double?)2.5d);
        AssertInputChange((decimal?)1.5m, "2.5", (decimal?)2.5m);
        AssertInputChange((float?)1.5f, string.Empty, null);
        AssertInputChange((double?)1.5d, string.Empty, null);
        AssertInputChange((decimal?)1.5m, string.Empty, null);
    }

    [Fact]
    public void DoesNotRenderIncrementOrDecrementButtons()
    {
        FloatingInputTestModel<double> model = new FloatingInputTestModel<double>
        {
            Value = 1.5d
        };

        IRenderedComponent<CarbonBlazorFloatingInput<double>> cut = _ctx.Render<CarbonBlazorFloatingInput<double>>(
            parameters => parameters
                .Add(p => p.FieldIdentifier, FieldIdentifier.Create(() => model.Value))
                .Add(p => p.Value, model.Value));

        Assert.Empty(cut.FindAll("button"));
    }

    private void AssertInputChange<TValue>(TValue initialValue, string input, TValue expectedValue)
    {
        FloatingInputTestModel<TValue> model = new FloatingInputTestModel<TValue>
        {
            Value = initialValue
        };

        IRenderedComponent<CarbonBlazorFloatingInput<TValue>> cut = _ctx.Render<CarbonBlazorFloatingInput<TValue>>(
            parameters => parameters
                .Add(p => p.FieldIdentifier, FieldIdentifier.Create(() => model.Value))
                .Add(p => p.Value, model.Value)
                .Add(p => p.ValueChanged, EventCallback.Factory.Create<TValue>(this, value => model.Value = value)));

        cut.Find("input").Input(input);

        Assert.Equal(expectedValue, model.Value);
    }

    private sealed class FloatingInputTestModel<TValue>
    {
        public TValue Value { get; set; } = default!;
    }
}

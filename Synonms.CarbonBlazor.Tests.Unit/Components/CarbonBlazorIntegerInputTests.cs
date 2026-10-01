using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Synonms.CarbonBlazor.Components;

namespace Synonms.CarbonBlazor.Tests.Unit.Components;

public class CarbonBlazorIntegerInputTests : IDisposable
{
    private readonly BunitContext _ctx = new BunitContext();

    public void Dispose()
    {
        _ctx.Dispose();
    }

    [Fact]
    public void Updates_AllSupportedIntegerTypes()
    {
        AssertInputChange((byte)1, "2", (byte)2);
        AssertInputChange((sbyte)1, "2", (sbyte)2);
        AssertInputChange((short)1, "2", (short)2);
        AssertInputChange((ushort)1, "2", (ushort)2);
        AssertInputChange(1, "2", 2);
        AssertInputChange(-1, "-2", -2);
        AssertInputChange(1u, "2", 2u);
        AssertInputChange(1L, "2", 2L);
        AssertInputChange(1UL, "2", 2UL);
    }

    [Fact]
    public void Updates_NullableIntegerTypes_AndClearsEmptyValues()
    {
        AssertInputChange((byte?)1, "2", (byte?)2);
        AssertInputChange((sbyte?)1, "2", (sbyte?)2);
        AssertInputChange((short?)1, "2", (short?)2);
        AssertInputChange((ushort?)1, "2", (ushort?)2);
        AssertInputChange((int?)1, "2", (int?)2);
        AssertInputChange((uint?)1, "2", (uint?)2);
        AssertInputChange((long?)1, "2", (long?)2);
        AssertInputChange((ulong?)1, "2", (ulong?)2);
        AssertInputChange((int?)1, string.Empty, null);
    }

    [Fact]
    public void Increment_RespectsTheUnderlyingIntegerMaximum()
    {
        IntegerInputTestModel<ulong> model = new IntegerInputTestModel<ulong>
        {
            Value = ulong.MaxValue - 1
        };

        IRenderedComponent<CarbonBlazorIntegerInput<ulong>> cut = _ctx.Render<CarbonBlazorIntegerInput<ulong>>(
            parameters => parameters
                .Add(p => p.FieldIdentifier, FieldIdentifier.Create(() => model.Value))
                .Add(p => p.Value, model.Value)
                .Add(p => p.ValueChanged, EventCallback.Factory.Create<ulong>(this, value => model.Value = value)));

        cut.Find("button.increment").Click();

        Assert.Equal(ulong.MaxValue, model.Value);
    }

    private void AssertInputChange<TValue>(TValue initialValue, string input, TValue expectedValue)
    {
        IntegerInputTestModel<TValue> model = new IntegerInputTestModel<TValue>
        {
            Value = initialValue
        };

        IRenderedComponent<CarbonBlazorIntegerInput<TValue>> cut = _ctx.Render<CarbonBlazorIntegerInput<TValue>>(
            parameters => parameters
                .Add(p => p.FieldIdentifier, FieldIdentifier.Create(() => model.Value))
                .Add(p => p.Value, model.Value)
                .Add(p => p.ValueChanged, EventCallback.Factory.Create<TValue>(this, value => model.Value = value)));

        cut.Find("input").Input(input);

        Assert.Equal(expectedValue, model.Value);
    }

    private sealed class IntegerInputTestModel<TValue>
    {
        public TValue Value { get; set; } = default!;
    }
}

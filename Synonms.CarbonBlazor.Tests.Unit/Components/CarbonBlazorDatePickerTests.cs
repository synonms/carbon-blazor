using System.Globalization;
using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Synonms.CarbonBlazor.Components;

namespace Synonms.CarbonBlazor.Tests.Unit.Components;

public class CarbonBlazorDatePickerTests : IDisposable
{
    private readonly BunitContext _ctx = new BunitContext();

    public void Dispose()
    {
        _ctx.Dispose();
    }

    [Fact]
    public void Renders_NullableDateOnlyValue()
    {
        DatePickerTestModel model = new DatePickerTestModel
        {
            NullableDateOnlyValue = new DateOnly(2026, 8, 20)
        };

        IRenderedComponent<CarbonBlazorDatePicker<DateOnly?>> cut = _ctx.Render<CarbonBlazorDatePicker<DateOnly?>>(
            parameters => parameters
                .Add(p => p.FieldIdentifier, FieldIdentifier.Create(() => model.NullableDateOnlyValue))
                .Add(p => p.Value, model.NullableDateOnlyValue)
                .Add(p => p.ValueChanged, EventCallback.Factory.Create<DateOnly?>(this, value => model.NullableDateOnlyValue = value)));

        Assert.Equal("20/08/2026", cut.Find("input").GetAttribute("value"));
    }

    [Fact]
    public void Updates_NonNullableDateTimeBinding_AndPreservesTime()
    {
        using TemporaryCulture temporaryCulture = new TemporaryCulture("en-GB");

        DatePickerTestModel model = new DatePickerTestModel
        {
            DateTimeValue = new DateTime(2026, 8, 20, 14, 30, 0)
        };

        IRenderedComponent<CarbonBlazorDatePicker<DateTime>> cut = _ctx.Render<CarbonBlazorDatePicker<DateTime>>(
            parameters => parameters
                .Add(p => p.FieldIdentifier, FieldIdentifier.Create(() => model.DateTimeValue))
                .Add(p => p.Value, model.DateTimeValue)
                .Add(p => p.ValueChanged, EventCallback.Factory.Create<DateTime>(this, value => model.DateTimeValue = value)));

        cut.Find("input").Change("21/08/2026");

        Assert.Equal(new DateTime(2026, 8, 21, 14, 30, 0), model.DateTimeValue);
    }

    [Fact]
    public void Clears_NullableDateTimeBinding_WhenInputIsEmpty()
    {
        DatePickerTestModel model = new DatePickerTestModel
        {
            NullableDateTimeValue = new DateTime(2026, 8, 20)
        };

        IRenderedComponent<CarbonBlazorDatePicker<DateTime?>> cut = _ctx.Render<CarbonBlazorDatePicker<DateTime?>>(
            parameters => parameters
                .Add(p => p.FieldIdentifier, FieldIdentifier.Create(() => model.NullableDateTimeValue))
                .Add(p => p.Value, model.NullableDateTimeValue)
                .Add(p => p.ValueChanged, EventCallback.Factory.Create<DateTime?>(this, value => model.NullableDateTimeValue = value)));

        cut.Find("input").Change(string.Empty);

        Assert.Null(model.NullableDateTimeValue);
    }

    private sealed class DatePickerTestModel
    {
        public DateOnly? NullableDateOnlyValue { get; set; }

        public DateTime DateTimeValue { get; set; }

        public DateTime? NullableDateTimeValue { get; set; }
    }

    private sealed class TemporaryCulture : IDisposable
    {
        private readonly CultureInfo _originalCulture;
        private readonly CultureInfo _originalUiCulture;

        public TemporaryCulture(string cultureName)
        {
            _originalCulture = CultureInfo.CurrentCulture;
            _originalUiCulture = CultureInfo.CurrentUICulture;

            CultureInfo newCulture = CultureInfo.GetCultureInfo(cultureName);
            CultureInfo.CurrentCulture = newCulture;
            CultureInfo.CurrentUICulture = newCulture;
        }

        public void Dispose()
        {
            CultureInfo.CurrentCulture = _originalCulture;
            CultureInfo.CurrentUICulture = _originalUiCulture;
        }
    }
}

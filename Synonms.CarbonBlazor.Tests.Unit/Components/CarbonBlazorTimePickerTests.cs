using System.Globalization;
using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Synonms.CarbonBlazor.Components;

namespace Synonms.CarbonBlazor.Tests.Unit.Components;

public class CarbonBlazorTimePickerTests : IDisposable
{
    private readonly BunitContext _ctx = new BunitContext();

    public void Dispose()
    {
        _ctx.Dispose();
    }

    [Fact]
    public void Renders_NullableTimeOnlyValue()
    {
        using TemporaryCulture temporaryCulture = new TemporaryCulture("en-GB");

        TimePickerTestModel model = new TimePickerTestModel
        {
            NullableTimeOnlyValue = new TimeOnly(14, 30)
        };

        IRenderedComponent<CarbonBlazorTimePicker<TimeOnly?>> cut = _ctx.Render<CarbonBlazorTimePicker<TimeOnly?>>(
            parameters => parameters
                .Add(p => p.FieldIdentifier, FieldIdentifier.Create(() => model.NullableTimeOnlyValue))
                .Add(p => p.Value, model.NullableTimeOnlyValue)
                .Add(p => p.ValueChanged, EventCallback.Factory.Create<TimeOnly?>(this, value => model.NullableTimeOnlyValue = value)));

        Assert.Equal("14:30", cut.Find("input").GetAttribute("value"));
    }

    [Fact]
    public void Updates_NonNullableTimeOnlyBinding()
    {
        using TemporaryCulture temporaryCulture = new TemporaryCulture("en-GB");

        TimePickerTestModel model = new TimePickerTestModel
        {
            TimeOnlyValue = new TimeOnly(14, 30)
        };

        IRenderedComponent<CarbonBlazorTimePicker<TimeOnly>> cut = _ctx.Render<CarbonBlazorTimePicker<TimeOnly>>(
            parameters => parameters
                .Add(p => p.FieldIdentifier, FieldIdentifier.Create(() => model.TimeOnlyValue))
                .Add(p => p.Value, model.TimeOnlyValue)
                .Add(p => p.ValueChanged, EventCallback.Factory.Create<TimeOnly>(this, value => model.TimeOnlyValue = value)));

        cut.Find("input").Change("16:45");

        Assert.Equal(new TimeOnly(16, 45), model.TimeOnlyValue);
    }

    [Fact]
    public void Updates_NonNullableDateTimeBinding_AndPreservesDate()
    {
        using TemporaryCulture temporaryCulture = new TemporaryCulture("en-GB");

        TimePickerTestModel model = new TimePickerTestModel
        {
            DateTimeValue = new DateTime(2026, 8, 20, 14, 30, 0)
        };

        IRenderedComponent<CarbonBlazorTimePicker<DateTime>> cut = _ctx.Render<CarbonBlazorTimePicker<DateTime>>(
            parameters => parameters
                .Add(p => p.FieldIdentifier, FieldIdentifier.Create(() => model.DateTimeValue))
                .Add(p => p.Value, model.DateTimeValue)
                .Add(p => p.ValueChanged, EventCallback.Factory.Create<DateTime>(this, value => model.DateTimeValue = value)));

        cut.Find("input").Change("16:45");

        Assert.Equal(new DateTime(2026, 8, 20, 16, 45, 0), model.DateTimeValue);
    }

    [Fact]
    public void Clears_NullableDateTimeBinding_WhenInputIsEmpty()
    {
        using TemporaryCulture temporaryCulture = new TemporaryCulture("en-GB");

        TimePickerTestModel model = new TimePickerTestModel
        {
            NullableDateTimeValue = new DateTime(2026, 8, 20, 14, 30, 0)
        };

        IRenderedComponent<CarbonBlazorTimePicker<DateTime?>> cut = _ctx.Render<CarbonBlazorTimePicker<DateTime?>>(
            parameters => parameters
                .Add(p => p.FieldIdentifier, FieldIdentifier.Create(() => model.NullableDateTimeValue))
                .Add(p => p.Value, model.NullableDateTimeValue)
                .Add(p => p.ValueChanged, EventCallback.Factory.Create<DateTime?>(this, value => model.NullableDateTimeValue = value)));

        cut.Find("input").Change(string.Empty);

        Assert.Null(model.NullableDateTimeValue);
    }

    private sealed class TimePickerTestModel
    {
        public TimeOnly TimeOnlyValue { get; set; }

        public TimeOnly? NullableTimeOnlyValue { get; set; }

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

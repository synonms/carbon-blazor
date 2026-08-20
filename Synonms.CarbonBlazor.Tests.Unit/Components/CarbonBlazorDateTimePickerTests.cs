using System.Globalization;
using AngleSharp.Dom;
using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Synonms.CarbonBlazor.Components;

namespace Synonms.CarbonBlazor.Tests.Unit.Components;

public class CarbonBlazorDateTimePickerTests : IDisposable
{
    private readonly BunitContext _ctx = new BunitContext();

    public void Dispose()
    {
        _ctx.Dispose();
    }

    [Fact]
    public void Renders_NullableDateTimeValue()
    {
        using TemporaryCulture temporaryCulture = new TemporaryCulture("en-GB");

        DateTimePickerTestModel model = new DateTimePickerTestModel
        {
            NullableDateTimeValue = new DateTime(2026, 8, 20, 14, 30, 0)
        };

        IRenderedComponent<CarbonBlazorDateTimePicker<DateTime?>> cut = _ctx.Render<CarbonBlazorDateTimePicker<DateTime?>>(
            parameters => parameters
                .Add(p => p.FieldIdentifier, FieldIdentifier.Create(() => model.NullableDateTimeValue))
                .Add(p => p.Value, model.NullableDateTimeValue)
                .Add(p => p.ValueChanged, EventCallback.Factory.Create<DateTime?>(this, value => model.NullableDateTimeValue = value)));

        IElement dateInput = cut.FindAll("input")[0];
        IElement timeInput = cut.FindAll("input")[1];

        Assert.Equal("20/08/2026", dateInput.GetAttribute("value"));
        Assert.Equal("14:30", timeInput.GetAttribute("value"));
    }

    [Fact]
    public void Updates_NonNullableDateTimeBinding_WhenDateChanges()
    {
        using TemporaryCulture temporaryCulture = new TemporaryCulture("en-GB");

        DateTimePickerTestModel model = new DateTimePickerTestModel
        {
            DateTimeValue = new DateTime(2026, 8, 20, 14, 30, 0)
        };

        IRenderedComponent<CarbonBlazorDateTimePicker<DateTime>> cut = _ctx.Render<CarbonBlazorDateTimePicker<DateTime>>(
            parameters => parameters
                .Add(p => p.FieldIdentifier, FieldIdentifier.Create(() => model.DateTimeValue))
                .Add(p => p.Value, model.DateTimeValue)
                .Add(p => p.ValueChanged, EventCallback.Factory.Create<DateTime>(this, value => model.DateTimeValue = value)));

        cut.FindAll("input")[0].Change("21/08/2026");

        Assert.Equal(new DateTime(2026, 8, 21, 14, 30, 0), model.DateTimeValue);
    }

    [Fact]
    public void Clears_NullableDateTimeBinding_WhenDateAndTimeAreCleared()
    {
        using TemporaryCulture temporaryCulture = new TemporaryCulture("en-GB");

        DateTimePickerTestModel model = new DateTimePickerTestModel
        {
            NullableDateTimeValue = new DateTime(2026, 8, 20, 14, 30, 0)
        };

        IRenderedComponent<CarbonBlazorDateTimePicker<DateTime?>> cut = _ctx.Render<CarbonBlazorDateTimePicker<DateTime?>>(
            parameters => parameters
                .Add(p => p.FieldIdentifier, FieldIdentifier.Create(() => model.NullableDateTimeValue))
                .Add(p => p.Value, model.NullableDateTimeValue)
                .Add(p => p.ValueChanged, EventCallback.Factory.Create<DateTime?>(this, value => model.NullableDateTimeValue = value)));

        IElement dateInput = cut.FindAll("input")[0];
        IElement timeInput = cut.FindAll("input")[1];
        dateInput.Change(string.Empty);
        timeInput.Change(string.Empty);

        Assert.Null(model.NullableDateTimeValue);
    }

    private sealed class DateTimePickerTestModel
    {
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

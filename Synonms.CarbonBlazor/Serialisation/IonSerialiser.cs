using System.Text.Json;
using System.Text.Json.Serialization;
using Synonms.RestEasy.Core.Serialisation;
using Synonms.RestEasy.Core.Serialisation.Ion;

namespace Synonms.CarbonBlazor.Serialisation;

public static class IonSerialiser
{
    public static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { 
            new DateOnlyJsonConverter(),
            new OptionalDateOnlyJsonConverter(),
            new TimeOnlyJsonConverter(),
            new OptionalTimeOnlyJsonConverter(),
            new IonCustomJsonConverterFactory(),
            new IonLinkJsonConverter(),
            new IonFormDocumentJsonConverter(),
            new IonFormFieldJsonConverter(),
            new IonPaginationJsonConverter(),
            new IonErrorCollectionDocumentJsonConverter(),
            new IonErrorJsonConverter()
        }
    };
}
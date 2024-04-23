using System.Text.Json;
using System.Text.Json.Serialization;
using Synonms.RestEasy.Core.Serialisation;
using Synonms.RestEasy.Core.Serialisation.Default;

namespace Synonms.CarbonBlazor.Serialisation;

public static class DefaultSerialiser
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
            new DefaultCustomJsonConverterFactory(),
            new DefaultLinkJsonConverter(),
            new DefaultFormDocumentJsonConverter(),
            new DefaultFormFieldJsonConverter(),
            new DefaultPaginationJsonConverter(),
            new DefaultErrorCollectionDocumentJsonConverter(),
            new DefaultErrorJsonConverter()
        }
    };
}
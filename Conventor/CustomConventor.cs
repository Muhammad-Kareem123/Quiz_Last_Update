namespace Exam_Api_v2.Conventor
{
    // Converters/CreateQuestionDtoConverter.cs
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Exam_Api_v2.DTOs;

    public class CreateQuestionDtoConverter : JsonConverter<CreateQuestionDto>
    {
        public override CreateQuestionDto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDoc = JsonDocument.ParseValue(ref reader);
            var root = jsonDoc.RootElement;

            if (!root.TryGetProperty("type", out JsonElement typeProperty))
            {
                throw new JsonException("Missing discriminator 'type' property.");
            }

            string typeDiscriminator = typeProperty.GetString();
            var json = root.GetRawText();

            return typeDiscriminator switch
            {
                "MCQ" => JsonSerializer.Deserialize<CreateMCQDto>(json, options),
                "TrueFalse" => JsonSerializer.Deserialize<CreateTrueFalseDto>(json, options),
                "FillInTheGaps" => JsonSerializer.Deserialize<CreateFillInTheGapsDto>(json, options),
                _ => throw new JsonException($"Unknown question type: {typeDiscriminator}")
            };
        }

        public override void Write(Utf8JsonWriter writer, CreateQuestionDto value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
        }
    }

}

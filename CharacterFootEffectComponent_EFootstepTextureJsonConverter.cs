using System;
using System.Text.Json;
using System.Text.Json.Serialization;

// Token: 0x02003501 RID: 13569
public class CharacterFootEffectComponent_EFootstepTextureJsonConverter : JsonConverter<CharacterFootEffectComponent.EFootstepTexture>
{
	// Token: 0x0601CA96 RID: 117398 RVA: 0x0089A3E4 File Offset: 0x008985E4
	public override CharacterFootEffectComponent.EFootstepTexture Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		string @string = reader.GetString();
		if (string.IsNullOrEmpty(@string))
		{
			return CharacterFootEffectComponent.EFootstepTexture.DirtSurface;
		}
		return CharacterFootEffectComponent_EFootstepTextureExtensions.FromString(@string);
	}

	// Token: 0x0601CA97 RID: 117399 RVA: 0x0089A408 File Offset: 0x00898608
	public override void Write(Utf8JsonWriter writer, CharacterFootEffectComponent.EFootstepTexture value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value.ToEnumString());
	}
}

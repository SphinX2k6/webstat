using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004ABC RID: 19132
	public class EGameplayEntityStateJsonConverter : JsonConverter<EGameplayEntityState>
	{
		// Token: 0x06031E1D RID: 204317 RVA: 0x00C7B7FC File Offset: 0x00C799FC
		public override EGameplayEntityState Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EGameplayEntityState.Locked;
			}
			return EGameplayEntityStateExtensions.FromString(@string);
		}

		// Token: 0x06031E1E RID: 204318 RVA: 0x00C7B820 File Offset: 0x00C79A20
		public override void Write(Utf8JsonWriter writer, EGameplayEntityState value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.VehicleStream
{
	// Token: 0x02004C4D RID: 19533
	public class EObstructionCheckResultJsonConverter : JsonConverter<EObstructionCheckResult>
	{
		// Token: 0x06032E4C RID: 208460 RVA: 0x00CBF064 File Offset: 0x00CBD264
		public override EObstructionCheckResult Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EObstructionCheckResult.None;
			}
			return EObstructionCheckResultExtensions.FromString(@string);
		}

		// Token: 0x06032E4D RID: 208461 RVA: 0x00CBF088 File Offset: 0x00CBD288
		public override void Write(Utf8JsonWriter writer, EObstructionCheckResult value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

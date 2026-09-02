using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.VehicleStream
{
	// Token: 0x02004C4F RID: 19535
	public class EMoveCheckResultJsonConverter : JsonConverter<EMoveCheckResult>
	{
		// Token: 0x06032E55 RID: 208469 RVA: 0x00CBF3B4 File Offset: 0x00CBD5B4
		public override EMoveCheckResult Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EMoveCheckResult.None;
			}
			return EMoveCheckResultExtensions.FromString(@string);
		}

		// Token: 0x06032E56 RID: 208470 RVA: 0x00CBF3D8 File Offset: 0x00CBD5D8
		public override void Write(Utf8JsonWriter writer, EMoveCheckResult value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

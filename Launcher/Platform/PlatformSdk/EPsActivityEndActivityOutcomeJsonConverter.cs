using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x020045CF RID: 17871
	public class EPsActivityEndActivityOutcomeJsonConverter : JsonConverter<EPsActivityEndActivityOutcome>
	{
		// Token: 0x0602ED35 RID: 191797 RVA: 0x00B16A68 File Offset: 0x00B14C68
		public override EPsActivityEndActivityOutcome Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EPsActivityEndActivityOutcome.Completed;
			}
			return EPsActivityEndActivityOutcomeExtensions.FromString(@string);
		}

		// Token: 0x0602ED36 RID: 191798 RVA: 0x00B16A8C File Offset: 0x00B14C8C
		public override void Write(Utf8JsonWriter writer, EPsActivityEndActivityOutcome value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.Platform
{
	// Token: 0x02004556 RID: 17750
	public class ECloudGamePlatformJsonConverter : JsonConverter<ECloudGamePlatform>
	{
		// Token: 0x0602EB4F RID: 191311 RVA: 0x00B11078 File Offset: 0x00B0F278
		public override ECloudGamePlatform Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return ECloudGamePlatform.Android;
			}
			return ECloudGamePlatformExtensions.FromString(@string);
		}

		// Token: 0x0602EB50 RID: 191312 RVA: 0x00B1109C File Offset: 0x00B0F29C
		public override void Write(Utf8JsonWriter writer, ECloudGamePlatform value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

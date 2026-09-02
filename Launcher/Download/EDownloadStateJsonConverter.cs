using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.Download
{
	// Token: 0x02004627 RID: 17959
	public class EDownloadStateJsonConverter : JsonConverter<EDownloadState>
	{
		// Token: 0x0602EEB1 RID: 192177 RVA: 0x00B1CC50 File Offset: 0x00B1AE50
		public override EDownloadState Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EDownloadState.None;
			}
			return EDownloadStateExtensions.FromString(@string);
		}

		// Token: 0x0602EEB2 RID: 192178 RVA: 0x00B1CC74 File Offset: 0x00B1AE74
		public override void Write(Utf8JsonWriter writer, EDownloadState value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

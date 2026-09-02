using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x020045CD RID: 17869
	public class PlatformSdkServerMsgJsonConverter : JsonConverter<PlatformSdkServerMsg>
	{
		// Token: 0x0602ED2C RID: 191788 RVA: 0x00B16910 File Offset: 0x00B14B10
		public override PlatformSdkServerMsg Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return PlatformSdkServerMsg.BadHttp;
			}
			return PlatformSdkServerMsgExtensions.FromString(@string);
		}

		// Token: 0x0602ED2D RID: 191789 RVA: 0x00B16934 File Offset: 0x00B14B34
		public override void Write(Utf8JsonWriter writer, PlatformSdkServerMsg value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x02004690 RID: 18064
	public class TConfigVersionKeyJsonConverter : JsonConverter<TConfigVersionKey>
	{
		// Token: 0x0602F084 RID: 192644 RVA: 0x00B24F60 File Offset: 0x00B23160
		public override TConfigVersionKey Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return TConfigVersionKey.FsmVersion;
			}
			return TConfigVersionKeyExtensions.FromString(@string);
		}

		// Token: 0x0602F085 RID: 192645 RVA: 0x00B24F84 File Offset: 0x00B23184
		public override void Write(Utf8JsonWriter writer, TConfigVersionKey value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068CF RID: 26831
	public class EDropCatchResourceIdJsonConverter : JsonConverter<EDropCatchResourceId>
	{
		// Token: 0x06042B88 RID: 273288 RVA: 0x01120014 File Offset: 0x0111E214
		public override EDropCatchResourceId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EDropCatchResourceId.DropItem;
			}
			return EDropCatchResourceIdExtensions.FromString(@string);
		}

		// Token: 0x06042B89 RID: 273289 RVA: 0x01120038 File Offset: 0x0111E238
		public override void Write(Utf8JsonWriter writer, EDropCatchResourceId value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

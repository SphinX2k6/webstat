using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068D1 RID: 26833
	public class EDropCatchRoleAnimStateJsonConverter : JsonConverter<EDropCatchRoleAnimState>
	{
		// Token: 0x06042B91 RID: 273297 RVA: 0x011202BC File Offset: 0x0111E4BC
		public override EDropCatchRoleAnimState Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EDropCatchRoleAnimState.IdleBowlLeft;
			}
			return EDropCatchRoleAnimStateExtensions.FromString(@string);
		}

		// Token: 0x06042B92 RID: 273298 RVA: 0x011202E0 File Offset: 0x0111E4E0
		public override void Write(Utf8JsonWriter writer, EDropCatchRoleAnimState value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068D5 RID: 26837
	public class EDropCatchRoleSkillStateJsonConverter : JsonConverter<EDropCatchRoleSkillState>
	{
		// Token: 0x06042BA3 RID: 273315 RVA: 0x0112059C File Offset: 0x0111E79C
		public override EDropCatchRoleSkillState Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EDropCatchRoleSkillState.Disable;
			}
			return EDropCatchRoleSkillStateExtensions.FromString(@string);
		}

		// Token: 0x06042BA4 RID: 273316 RVA: 0x011205C0 File Offset: 0x0111E7C0
		public override void Write(Utf8JsonWriter writer, EDropCatchRoleSkillState value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

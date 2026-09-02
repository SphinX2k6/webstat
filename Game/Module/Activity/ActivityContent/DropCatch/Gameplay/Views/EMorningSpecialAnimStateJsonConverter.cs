using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views
{
	// Token: 0x0200691A RID: 26906
	public class EMorningSpecialAnimStateJsonConverter : JsonConverter<EMorningSpecialAnimState>
	{
		// Token: 0x06042D1B RID: 273691 RVA: 0x01126C4C File Offset: 0x01124E4C
		public override EMorningSpecialAnimState Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EMorningSpecialAnimState.IdleNothingLeft;
			}
			return EMorningSpecialAnimStateExtensions.FromString(@string);
		}

		// Token: 0x06042D1C RID: 273692 RVA: 0x01126C70 File Offset: 0x01124E70
		public override void Write(Utf8JsonWriter writer, EMorningSpecialAnimState value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

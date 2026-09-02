using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068D3 RID: 26835
	public class EDropCatchRobotAnimStateJsonConverter : JsonConverter<EDropCatchRobotAnimState>
	{
		// Token: 0x06042B9A RID: 273306 RVA: 0x01120444 File Offset: 0x0111E644
		public override EDropCatchRobotAnimState Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EDropCatchRobotAnimState.HappyLeft;
			}
			return EDropCatchRobotAnimStateExtensions.FromString(@string);
		}

		// Token: 0x06042B9B RID: 273307 RVA: 0x01120468 File Offset: 0x0111E668
		public override void Write(Utf8JsonWriter writer, EDropCatchRobotAnimState value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

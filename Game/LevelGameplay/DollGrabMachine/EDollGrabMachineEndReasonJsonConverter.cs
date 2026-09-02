using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006EDF RID: 28383
	public class EDollGrabMachineEndReasonJsonConverter : JsonConverter<EDollGrabMachineEndReason>
	{
		// Token: 0x06044CF3 RID: 281843 RVA: 0x011E6C1C File Offset: 0x011E4E1C
		public override EDollGrabMachineEndReason Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EDollGrabMachineEndReason.TimeUp;
			}
			return EDollGrabMachineEndReasonExtensions.FromString(@string);
		}

		// Token: 0x06044CF4 RID: 281844 RVA: 0x011E6C40 File Offset: 0x011E4E40
		public override void Write(Utf8JsonWriter writer, EDollGrabMachineEndReason value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006EDD RID: 28381
	public class EDollGrabMachineStateJsonConverter : JsonConverter<EDollGrabMachineState>
	{
		// Token: 0x06044CEA RID: 281834 RVA: 0x011E6A94 File Offset: 0x011E4C94
		public override EDollGrabMachineState Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EDollGrabMachineState.InActive;
			}
			return EDollGrabMachineStateExtensions.FromString(@string);
		}

		// Token: 0x06044CEB RID: 281835 RVA: 0x011E6AB8 File Offset: 0x011E4CB8
		public override void Write(Utf8JsonWriter writer, EDollGrabMachineState value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

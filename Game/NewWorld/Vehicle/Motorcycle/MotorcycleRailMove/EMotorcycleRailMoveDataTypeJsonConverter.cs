using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047D2 RID: 18386
	public class EMotorcycleRailMoveDataTypeJsonConverter : JsonConverter<EMotorcycleRailMoveDataType>
	{
		// Token: 0x0602FB22 RID: 195362 RVA: 0x00B6930C File Offset: 0x00B6750C
		public override EMotorcycleRailMoveDataType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EMotorcycleRailMoveDataType.AccelerateAlongRail;
			}
			return EMotorcycleRailMoveDataTypeExtensions.FromString(@string);
		}

		// Token: 0x0602FB23 RID: 195363 RVA: 0x00B69330 File Offset: 0x00B67530
		public override void Write(Utf8JsonWriter writer, EMotorcycleRailMoveDataType value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

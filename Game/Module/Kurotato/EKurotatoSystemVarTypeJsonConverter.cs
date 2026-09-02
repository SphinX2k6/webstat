using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A70 RID: 23152
	public class EKurotatoSystemVarTypeJsonConverter : JsonConverter<EKurotatoSystemVarType>
	{
		// Token: 0x0603A958 RID: 239960 RVA: 0x00ED61E0 File Offset: 0x00ED43E0
		public override EKurotatoSystemVarType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EKurotatoSystemVarType.Gold;
			}
			return EKurotatoSystemVarTypeExtensions.FromString(@string);
		}

		// Token: 0x0603A959 RID: 239961 RVA: 0x00ED6204 File Offset: 0x00ED4404
		public override void Write(Utf8JsonWriter writer, EKurotatoSystemVarType value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

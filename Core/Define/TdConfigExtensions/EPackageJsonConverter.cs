using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Core.Define.TdConfigExtensions
{
	// Token: 0x0200713E RID: 28990
	public class EPackageJsonConverter : JsonConverter<EPackage>
	{
		// Token: 0x0604632A RID: 287530 RVA: 0x0126EE4C File Offset: 0x0126D04C
		public override EPackage Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EPackage.Message;
			}
			return EPackageExtensions.FromString(@string);
		}

		// Token: 0x0604632B RID: 287531 RVA: 0x0126EE70 File Offset: 0x0126D070
		public override void Write(Utf8JsonWriter writer, EPackage value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

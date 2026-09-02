using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Common.LocalStorageJson
{
	// Token: 0x02007067 RID: 28775
	[NullableContext(1)]
	[Nullable(0)]
	public class LocalStorageJsonConverterFactory : JsonConverterFactory
	{
		// Token: 0x06045AAE RID: 285358 RVA: 0x01234C3D File Offset: 0x01232E3D
		public override bool CanConvert(Type typeToConvert)
		{
			return true;
		}

		// Token: 0x06045AAF RID: 285359 RVA: 0x01234C40 File Offset: 0x01232E40
		public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
		{
			return (JsonConverter)Activator.CreateInstance(typeof(LocalStorageJsonConverter<>).MakeGenericType(new Type[]
			{
				typeToConvert
			}));
		}
	}
}

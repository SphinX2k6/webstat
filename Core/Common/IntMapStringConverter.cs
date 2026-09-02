using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Core.Common
{
	// Token: 0x02007150 RID: 29008
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class IntMapStringConverter : JsonConverter<Dictionary<int, int>>
	{
		// Token: 0x060463B0 RID: 287664 RVA: 0x01271E10 File Offset: 0x01270010
		public override Dictionary<int, int> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.Null)
			{
				return null;
			}
			if (reader.TokenType != JsonTokenType.String)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Expected String token, got ");
				defaultInterpolatedStringHandler.AppendFormatted<JsonTokenType>(reader.TokenType);
				throw new JsonException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			string @string = reader.GetString();
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			if (string.IsNullOrEmpty(@string))
			{
				return dictionary;
			}
			string[] array = @string.Replace("[", "").Replace("]", "").Split(',', StringSplitOptions.None);
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(':', StringSplitOptions.None);
				if (array2.Length == 2)
				{
					dictionary[int.Parse(array2[0])] = int.Parse(array2[1]);
				}
			}
			return dictionary;
		}

		// Token: 0x060463B1 RID: 287665 RVA: 0x01271EE1 File Offset: 0x012700E1
		public override void Write(Utf8JsonWriter writer, Dictionary<int, int> value, JsonSerializerOptions options)
		{
			JsonSerializer.Serialize<Dictionary<int, int>>(writer, value, options);
		}
	}
}

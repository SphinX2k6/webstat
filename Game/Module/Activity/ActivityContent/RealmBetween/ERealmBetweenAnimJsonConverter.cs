using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006562 RID: 25954
	public class ERealmBetweenAnimJsonConverter : JsonConverter<ERealmBetweenAnim>
	{
		// Token: 0x06040D72 RID: 265586 RVA: 0x010A0B40 File Offset: 0x0109ED40
		public override ERealmBetweenAnim Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return ERealmBetweenAnim.AniOpen;
			}
			return ERealmBetweenAnimExtensions.FromString(@string);
		}

		// Token: 0x06040D73 RID: 265587 RVA: 0x010A0B64 File Offset: 0x0109ED64
		public override void Write(Utf8JsonWriter writer, ERealmBetweenAnim value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

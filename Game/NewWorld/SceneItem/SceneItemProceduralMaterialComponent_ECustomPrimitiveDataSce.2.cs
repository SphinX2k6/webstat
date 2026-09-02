using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x02004819 RID: 18457
	public class SceneItemProceduralMaterialComponent_ECustomPrimitiveDataSceneItemTypeJsonConverter : JsonConverter<SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType>
	{
		// Token: 0x06030086 RID: 196742 RVA: 0x00BA384C File Offset: 0x00BA1A4C
		public override SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType.Chair;
			}
			return SceneItemProceduralMaterialComponent_ECustomPrimitiveDataSceneItemTypeExtensions.FromString(@string);
		}

		// Token: 0x06030087 RID: 196743 RVA: 0x00BA3870 File Offset: 0x00BA1A70
		public override void Write(Utf8JsonWriter writer, SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}

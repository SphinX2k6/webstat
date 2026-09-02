using System;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x02004818 RID: 18456
	public static class SceneItemProceduralMaterialComponent_ECustomPrimitiveDataSceneItemTypeExtensions
	{
		// Token: 0x06030080 RID: 196736 RVA: 0x00BA37AC File Offset: 0x00BA19AC
		public static string ToEnumString(this SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType value)
		{
			string result;
			if (value == SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType.Chair)
			{
				result = "Chair";
			}
			else
			{
				result = value.ToString();
			}
			return result;
		}

		// Token: 0x06030081 RID: 196737 RVA: 0x00BA37D4 File Offset: 0x00BA19D4
		public static SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType FromString(string name)
		{
			SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType result;
			if (!SceneItemProceduralMaterialComponent_ECustomPrimitiveDataSceneItemTypeExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06030082 RID: 196738 RVA: 0x00BA37FD File Offset: 0x00BA19FD
		public static bool TryFromString(string name, out SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType.Chair;
				return false;
			}
			if (name == "Chair")
			{
				value = SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType.Chair;
				return true;
			}
			value = SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType.Chair;
			return false;
		}

		// Token: 0x06030083 RID: 196739 RVA: 0x00BA3822 File Offset: 0x00BA1A22
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"Chair"
			};
		}

		// Token: 0x06030084 RID: 196740 RVA: 0x00BA3832 File Offset: 0x00BA1A32
		public static SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType[] GetValues()
		{
			return new SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType[1];
		}

		// Token: 0x06030085 RID: 196741 RVA: 0x00BA383A File Offset: 0x00BA1A3A
		public static string[] GetNames()
		{
			return new string[]
			{
				"Chair"
			};
		}
	}
}

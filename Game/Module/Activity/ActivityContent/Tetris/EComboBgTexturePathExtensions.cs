using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062F0 RID: 25328
	public static class EComboBgTexturePathExtensions
	{
		// Token: 0x0603FAC8 RID: 260808 RVA: 0x01052EAC File Offset: 0x010510AC
		public static string ToEnumString(this EComboBgTexturePath value)
		{
			string result;
			switch (value)
			{
			case EComboBgTexturePath.Good:
				result = "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatGoodBg.T_FloatGoodBg";
				break;
			case EComboBgTexturePath.Great:
				result = "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatGreatBg.T_FloatGreatBg";
				break;
			case EComboBgTexturePath.Excellent:
				result = "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatExcellentBg.T_FloatExcellentBg";
				break;
			case EComboBgTexturePath.Unbelievable:
				result = "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatUnbelievableBg.T_FloatUnbelievableBg";
				break;
			case EComboBgTexturePath.Combo:
				result = "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatComboBg.T_FloatComboBg";
				break;
			case EComboBgTexturePath.Default:
				result = "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatDefaultBg.T_FloatDefaultBg";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x0603FAC9 RID: 260809 RVA: 0x01052F18 File Offset: 0x01051118
		public static EComboBgTexturePath FromString(string name)
		{
			EComboBgTexturePath result;
			if (!EComboBgTexturePathExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EComboBgTexturePath 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0603FACA RID: 260810 RVA: 0x01052F44 File Offset: 0x01051144
		public static bool TryFromString(string name, out EComboBgTexturePath value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EComboBgTexturePath.Good;
				return false;
			}
			if (name == "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatGoodBg.T_FloatGoodBg")
			{
				value = EComboBgTexturePath.Good;
				return true;
			}
			if (name == "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatGreatBg.T_FloatGreatBg")
			{
				value = EComboBgTexturePath.Great;
				return true;
			}
			if (name == "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatExcellentBg.T_FloatExcellentBg")
			{
				value = EComboBgTexturePath.Excellent;
				return true;
			}
			if (name == "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatUnbelievableBg.T_FloatUnbelievableBg")
			{
				value = EComboBgTexturePath.Unbelievable;
				return true;
			}
			if (name == "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatComboBg.T_FloatComboBg")
			{
				value = EComboBgTexturePath.Combo;
				return true;
			}
			if (!(name == "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatDefaultBg.T_FloatDefaultBg"))
			{
				value = EComboBgTexturePath.Good;
				return false;
			}
			value = EComboBgTexturePath.Default;
			return true;
		}

		// Token: 0x0603FACB RID: 260811 RVA: 0x01052FD0 File Offset: 0x010511D0
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatGoodBg.T_FloatGoodBg",
				"/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatGreatBg.T_FloatGreatBg",
				"/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatExcellentBg.T_FloatExcellentBg",
				"/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatUnbelievableBg.T_FloatUnbelievableBg",
				"/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatComboBg.T_FloatComboBg",
				"/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatDefaultBg.T_FloatDefaultBg"
			};
		}

		// Token: 0x0603FACC RID: 260812 RVA: 0x01053008 File Offset: 0x01051208
		public static EComboBgTexturePath[] GetValues()
		{
			return new EComboBgTexturePath[]
			{
				EComboBgTexturePath.Good,
				EComboBgTexturePath.Great,
				EComboBgTexturePath.Excellent,
				EComboBgTexturePath.Unbelievable,
				EComboBgTexturePath.Combo,
				EComboBgTexturePath.Default
			};
		}

		// Token: 0x0603FACD RID: 260813 RVA: 0x0105301B File Offset: 0x0105121B
		public static string[] GetNames()
		{
			return new string[]
			{
				"Good",
				"Great",
				"Excellent",
				"Unbelievable",
				"Combo",
				"Default"
			};
		}
	}
}

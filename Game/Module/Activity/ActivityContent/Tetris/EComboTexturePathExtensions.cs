using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062EE RID: 25326
	public static class EComboTexturePathExtensions
	{
		// Token: 0x0603FABF RID: 260799 RVA: 0x01052CF4 File Offset: 0x01050EF4
		public static string ToEnumString(this EComboTexturePath value)
		{
			string result;
			switch (value)
			{
			case EComboTexturePath.Good:
				result = "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatGood.T_FloatGood";
				break;
			case EComboTexturePath.Great:
				result = "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatGreat.T_FloatGreat";
				break;
			case EComboTexturePath.Excellent:
				result = "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatExcellent.T_FloatExcellent";
				break;
			case EComboTexturePath.Unbelievable:
				result = "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatUnbelievable.T_FloatUnbelievable";
				break;
			case EComboTexturePath.Combo:
				result = "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatCombo.T_FloatCombo";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x0603FAC0 RID: 260800 RVA: 0x01052D54 File Offset: 0x01050F54
		public static EComboTexturePath FromString(string name)
		{
			EComboTexturePath result;
			if (!EComboTexturePathExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EComboTexturePath 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0603FAC1 RID: 260801 RVA: 0x01052D80 File Offset: 0x01050F80
		public static bool TryFromString(string name, out EComboTexturePath value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EComboTexturePath.Good;
				return false;
			}
			if (name == "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatGood.T_FloatGood")
			{
				value = EComboTexturePath.Good;
				return true;
			}
			if (name == "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatGreat.T_FloatGreat")
			{
				value = EComboTexturePath.Great;
				return true;
			}
			if (name == "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatExcellent.T_FloatExcellent")
			{
				value = EComboTexturePath.Excellent;
				return true;
			}
			if (name == "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatUnbelievable.T_FloatUnbelievable")
			{
				value = EComboTexturePath.Unbelievable;
				return true;
			}
			if (!(name == "/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatCombo.T_FloatCombo"))
			{
				value = EComboTexturePath.Good;
				return false;
			}
			value = EComboTexturePath.Combo;
			return true;
		}

		// Token: 0x0603FAC2 RID: 260802 RVA: 0x01052DFA File Offset: 0x01050FFA
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatGood.T_FloatGood",
				"/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatGreat.T_FloatGreat",
				"/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatExcellent.T_FloatExcellent",
				"/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatUnbelievable.T_FloatUnbelievable",
				"/Game/Aki/UI/UIResources/UiActivity/Image/Activity32/Cube/Main/T_FloatCombo.T_FloatCombo"
			};
		}

		// Token: 0x0603FAC3 RID: 260803 RVA: 0x01052E2A File Offset: 0x0105102A
		public static EComboTexturePath[] GetValues()
		{
			return new EComboTexturePath[]
			{
				EComboTexturePath.Good,
				EComboTexturePath.Great,
				EComboTexturePath.Excellent,
				EComboTexturePath.Unbelievable,
				EComboTexturePath.Combo
			};
		}

		// Token: 0x0603FAC4 RID: 260804 RVA: 0x01052E3D File Offset: 0x0105103D
		public static string[] GetNames()
		{
			return new string[]
			{
				"Good",
				"Great",
				"Excellent",
				"Unbelievable",
				"Combo"
			};
		}
	}
}

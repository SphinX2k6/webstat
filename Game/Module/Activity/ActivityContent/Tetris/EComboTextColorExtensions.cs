using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062F2 RID: 25330
	public static class EComboTextColorExtensions
	{
		// Token: 0x0603FAD1 RID: 260817 RVA: 0x01053090 File Offset: 0x01051290
		public static string ToEnumString(this EComboTextColor value)
		{
			string result;
			switch (value)
			{
			case EComboTextColor.Good:
				result = "03DD5A";
				break;
			case EComboTextColor.Great:
				result = "D200FF";
				break;
			case EComboTextColor.Excellent:
				result = "FF3000";
				break;
			case EComboTextColor.Unbelievable:
				result = "FFA800";
				break;
			case EComboTextColor.Combo:
				result = "00BBFA";
				break;
			case EComboTextColor.Default:
				result = "FFFFFF";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x0603FAD2 RID: 260818 RVA: 0x010530FC File Offset: 0x010512FC
		public static EComboTextColor FromString(string name)
		{
			EComboTextColor result;
			if (!EComboTextColorExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EComboTextColor 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0603FAD3 RID: 260819 RVA: 0x01053128 File Offset: 0x01051328
		public static bool TryFromString(string name, out EComboTextColor value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EComboTextColor.Good;
				return false;
			}
			if (name == "03DD5A")
			{
				value = EComboTextColor.Good;
				return true;
			}
			if (name == "D200FF")
			{
				value = EComboTextColor.Great;
				return true;
			}
			if (name == "FF3000")
			{
				value = EComboTextColor.Excellent;
				return true;
			}
			if (name == "FFA800")
			{
				value = EComboTextColor.Unbelievable;
				return true;
			}
			if (name == "00BBFA")
			{
				value = EComboTextColor.Combo;
				return true;
			}
			if (!(name == "FFFFFF"))
			{
				value = EComboTextColor.Good;
				return false;
			}
			value = EComboTextColor.Default;
			return true;
		}

		// Token: 0x0603FAD4 RID: 260820 RVA: 0x010531B4 File Offset: 0x010513B4
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"03DD5A",
				"D200FF",
				"FF3000",
				"FFA800",
				"00BBFA",
				"FFFFFF"
			};
		}

		// Token: 0x0603FAD5 RID: 260821 RVA: 0x010531EC File Offset: 0x010513EC
		public static EComboTextColor[] GetValues()
		{
			return new EComboTextColor[]
			{
				EComboTextColor.Good,
				EComboTextColor.Great,
				EComboTextColor.Excellent,
				EComboTextColor.Unbelievable,
				EComboTextColor.Combo,
				EComboTextColor.Default
			};
		}

		// Token: 0x0603FAD6 RID: 260822 RVA: 0x010531FF File Offset: 0x010513FF
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

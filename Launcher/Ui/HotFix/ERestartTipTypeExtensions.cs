using System;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x0200451C RID: 17692
	public static class ERestartTipTypeExtensions
	{
		// Token: 0x0602E9D0 RID: 190928 RVA: 0x00B0B154 File Offset: 0x00B09354
		public static string ToEnumString(this ERestartTipType value)
		{
			string result;
			switch (value)
			{
			case ERestartTipType.HotFixComplete:
				result = "HotFixRestartToCompleteHotFix";
				break;
			case ERestartTipType.RepairFilesComplete:
				result = "HotFixRestartToRepairFiles";
				break;
			case ERestartTipType.HotFixCompleteWin:
				result = "HotFixRestartToCompleteHotFixWin";
				break;
			case ERestartTipType.RepairFilesCompleteWin:
				result = "HotFixRestartToRepairFilesWin";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x0602E9D1 RID: 190929 RVA: 0x00B0B1A8 File Offset: 0x00B093A8
		public static ERestartTipType FromString(string name)
		{
			ERestartTipType result;
			if (!ERestartTipTypeExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 ERestartTipType 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0602E9D2 RID: 190930 RVA: 0x00B0B1D4 File Offset: 0x00B093D4
		public static bool TryFromString(string name, out ERestartTipType value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = ERestartTipType.HotFixComplete;
				return false;
			}
			if (name == "HotFixRestartToCompleteHotFix")
			{
				value = ERestartTipType.HotFixComplete;
				return true;
			}
			if (name == "HotFixRestartToRepairFiles")
			{
				value = ERestartTipType.RepairFilesComplete;
				return true;
			}
			if (name == "HotFixRestartToCompleteHotFixWin")
			{
				value = ERestartTipType.HotFixCompleteWin;
				return true;
			}
			if (!(name == "HotFixRestartToRepairFilesWin"))
			{
				value = ERestartTipType.HotFixComplete;
				return false;
			}
			value = ERestartTipType.RepairFilesCompleteWin;
			return true;
		}

		// Token: 0x0602E9D3 RID: 190931 RVA: 0x00B0B23C File Offset: 0x00B0943C
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"HotFixRestartToCompleteHotFix",
				"HotFixRestartToRepairFiles",
				"HotFixRestartToCompleteHotFixWin",
				"HotFixRestartToRepairFilesWin"
			};
		}

		// Token: 0x0602E9D4 RID: 190932 RVA: 0x00B0B264 File Offset: 0x00B09464
		public static ERestartTipType[] GetValues()
		{
			return new ERestartTipType[]
			{
				ERestartTipType.HotFixComplete,
				ERestartTipType.RepairFilesComplete,
				ERestartTipType.HotFixCompleteWin,
				ERestartTipType.RepairFilesCompleteWin
			};
		}

		// Token: 0x0602E9D5 RID: 190933 RVA: 0x00B0B277 File Offset: 0x00B09477
		public static string[] GetNames()
		{
			return new string[]
			{
				"HotFixComplete",
				"RepairFilesComplete",
				"HotFixCompleteWin",
				"RepairFilesCompleteWin"
			};
		}
	}
}

using System;

namespace CSharpScript.Game.Module.AutoPilot
{
	// Token: 0x02006150 RID: 24912
	public static class AutoPilotDefine_EAutoPilotResourceIdExtensions
	{
		// Token: 0x0603EF3D RID: 257853 RVA: 0x01022EB8 File Offset: 0x010210B8
		public static string ToEnumString(this AutoPilotDefine.EAutoPilotResourceId value)
		{
			string result;
			switch (value)
			{
			case AutoPilotDefine.EAutoPilotResourceId.AutoPilotNavBtn:
				result = "UiItem_AutocruiseNavBtn";
				break;
			case AutoPilotDefine.EAutoPilotResourceId.AutoPilotGoBtnGroup:
				result = "PnlSetOutBtn";
				break;
			case AutoPilotDefine.EAutoPilotResourceId.AutoPilotLineComp:
				result = "UiItem_AutoPilot_Line";
				break;
			case AutoPilotDefine.EAutoPilotResourceId.AutoPilotTrackMark:
				result = "UiItem_AutocruiseMark";
				break;
			case AutoPilotDefine.EAutoPilotResourceId.AutoPilotView:
				result = "UiView_MotorcycleAutoCruise";
				break;
			case AutoPilotDefine.EAutoPilotResourceId.AutoPilotState:
				result = "UiItem_MotorAutoCruise";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x0603EF3E RID: 257854 RVA: 0x01022F24 File Offset: 0x01021124
		public static AutoPilotDefine.EAutoPilotResourceId FromString(string name)
		{
			AutoPilotDefine.EAutoPilotResourceId result;
			if (!AutoPilotDefine_EAutoPilotResourceIdExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 AutoPilotDefine.EAutoPilotResourceId 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0603EF3F RID: 257855 RVA: 0x01022F50 File Offset: 0x01021150
		public static bool TryFromString(string name, out AutoPilotDefine.EAutoPilotResourceId value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = AutoPilotDefine.EAutoPilotResourceId.AutoPilotNavBtn;
				return false;
			}
			if (name == "UiItem_AutocruiseNavBtn")
			{
				value = AutoPilotDefine.EAutoPilotResourceId.AutoPilotNavBtn;
				return true;
			}
			if (name == "PnlSetOutBtn")
			{
				value = AutoPilotDefine.EAutoPilotResourceId.AutoPilotGoBtnGroup;
				return true;
			}
			if (name == "UiItem_AutoPilot_Line")
			{
				value = AutoPilotDefine.EAutoPilotResourceId.AutoPilotLineComp;
				return true;
			}
			if (name == "UiItem_AutocruiseMark")
			{
				value = AutoPilotDefine.EAutoPilotResourceId.AutoPilotTrackMark;
				return true;
			}
			if (name == "UiView_MotorcycleAutoCruise")
			{
				value = AutoPilotDefine.EAutoPilotResourceId.AutoPilotView;
				return true;
			}
			if (!(name == "UiItem_MotorAutoCruise"))
			{
				value = AutoPilotDefine.EAutoPilotResourceId.AutoPilotNavBtn;
				return false;
			}
			value = AutoPilotDefine.EAutoPilotResourceId.AutoPilotState;
			return true;
		}

		// Token: 0x0603EF40 RID: 257856 RVA: 0x01022FDC File Offset: 0x010211DC
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"UiItem_AutocruiseNavBtn",
				"PnlSetOutBtn",
				"UiItem_AutoPilot_Line",
				"UiItem_AutocruiseMark",
				"UiView_MotorcycleAutoCruise",
				"UiItem_MotorAutoCruise"
			};
		}

		// Token: 0x0603EF41 RID: 257857 RVA: 0x01023014 File Offset: 0x01021214
		public static AutoPilotDefine.EAutoPilotResourceId[] GetValues()
		{
			return new AutoPilotDefine.EAutoPilotResourceId[]
			{
				AutoPilotDefine.EAutoPilotResourceId.AutoPilotNavBtn,
				AutoPilotDefine.EAutoPilotResourceId.AutoPilotGoBtnGroup,
				AutoPilotDefine.EAutoPilotResourceId.AutoPilotLineComp,
				AutoPilotDefine.EAutoPilotResourceId.AutoPilotTrackMark,
				AutoPilotDefine.EAutoPilotResourceId.AutoPilotView,
				AutoPilotDefine.EAutoPilotResourceId.AutoPilotState
			};
		}

		// Token: 0x0603EF42 RID: 257858 RVA: 0x01023027 File Offset: 0x01021227
		public static string[] GetNames()
		{
			return new string[]
			{
				"AutoPilotNavBtn",
				"AutoPilotGoBtnGroup",
				"AutoPilotLineComp",
				"AutoPilotTrackMark",
				"AutoPilotView",
				"AutoPilotState"
			};
		}
	}
}

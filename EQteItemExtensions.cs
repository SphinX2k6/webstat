using System;

// Token: 0x020034FE RID: 13566
public static class EQteItemExtensions
{
	// Token: 0x0601CA87 RID: 117383 RVA: 0x00899ABC File Offset: 0x00897CBC
	public static string ToEnumString(this EQteItem value)
	{
		string result;
		switch (value)
		{
		case EQteItem.SingleClickItem:
			result = "UiItem_QteBtnSingleTap";
			break;
		case EQteItem.ContinuousClickItem:
			result = "UiItem_QteBtnTapRapidly";
			break;
		case EQteItem.DragItem:
			result = "UiItem_QteDrag";
			break;
		case EQteItem.LongPressItem:
			result = "UiItem_QteBtnLongPress";
			break;
		case EQteItem.SelectOptionItem:
			result = "UiView_PlotInteraction";
			break;
		case EQteItem.CustomOptionItem:
			result = "UiItem_QteObjectPos";
			break;
		case EQteItem.PullUpItem:
			result = "UiItem_PullUp";
			break;
		case EQteItem.PullDownItem:
			result = "UiItem_PullDown";
			break;
		case EQteItem.FocusSingleButtonItem:
			result = "UiItem_FocusSingleButton";
			break;
		case EQteItem.RingTapItem:
			result = "UiItem_QteBtnRingTab";
			break;
		case EQteItem.RingMatchTapItem:
			result = "UiItem_QteBtnRingMatch";
			break;
		case EQteItem.CompassRotateItem:
			result = "UiItem_CompassRotate";
			break;
		case EQteItem.FullScreenLongPressItem:
			result = "UiItem_FullScreenLongPress";
			break;
		case EQteItem.RightScreenDragItem:
			result = "UiItem_RightScreenDragItem";
			break;
		case EQteItem.SuisuiSlideItem:
			result = "UiItem_PlotQteSuisui";
			break;
		case EQteItem.SuisuiRight:
			result = "UiItem_PlotQteSuisuiRight";
			break;
		case EQteItem.SuisuiDown:
			result = "UiItem_PlotQteSuisuiDown";
			break;
		default:
			result = value.ToString();
			break;
		}
		return result;
	}

	// Token: 0x0601CA88 RID: 117384 RVA: 0x00899BB8 File Offset: 0x00897DB8
	public static EQteItem FromString(string name)
	{
		EQteItem result;
		if (!EQteItemExtensions.TryFromString(name, out result))
		{
			throw new InvalidCastException("从字符串转成枚举 EQteItem 失败, 字符串: " + name);
		}
		return result;
	}

	// Token: 0x0601CA89 RID: 117385 RVA: 0x00899BE4 File Offset: 0x00897DE4
	public static bool TryFromString(string name, out EQteItem value)
	{
		if (string.IsNullOrEmpty(name))
		{
			value = EQteItem.SingleClickItem;
			return false;
		}
		if (name != null)
		{
			switch (name.Length)
			{
			case 13:
				if (name == "UiItem_PullUp")
				{
					value = EQteItem.PullUpItem;
					return true;
				}
				break;
			case 14:
				if (name == "UiItem_QteDrag")
				{
					value = EQteItem.DragItem;
					return true;
				}
				break;
			case 15:
				if (name == "UiItem_PullDown")
				{
					value = EQteItem.PullDownItem;
					return true;
				}
				break;
			case 19:
				if (name == "UiItem_QteObjectPos")
				{
					value = EQteItem.CustomOptionItem;
					return true;
				}
				break;
			case 20:
			{
				char c = name[7];
				if (c != 'C')
				{
					if (c != 'P')
					{
						if (c == 'Q')
						{
							if (name == "UiItem_QteBtnRingTab")
							{
								value = EQteItem.RingTapItem;
								return true;
							}
						}
					}
					else if (name == "UiItem_PlotQteSuisui")
					{
						value = EQteItem.SuisuiSlideItem;
						return true;
					}
				}
				else if (name == "UiItem_CompassRotate")
				{
					value = EQteItem.CompassRotateItem;
					return true;
				}
				break;
			}
			case 22:
			{
				char c = name[13];
				if (c <= 'R')
				{
					if (c != 'L')
					{
						if (c == 'R')
						{
							if (name == "UiItem_QteBtnRingMatch")
							{
								value = EQteItem.RingMatchTapItem;
								return true;
							}
						}
					}
					else if (name == "UiItem_QteBtnLongPress")
					{
						value = EQteItem.LongPressItem;
						return true;
					}
				}
				else if (c != 'S')
				{
					if (c == 't')
					{
						if (name == "UiView_PlotInteraction")
						{
							value = EQteItem.SelectOptionItem;
							return true;
						}
					}
				}
				else if (name == "UiItem_QteBtnSingleTap")
				{
					value = EQteItem.SingleClickItem;
					return true;
				}
				break;
			}
			case 23:
				if (name == "UiItem_QteBtnTapRapidly")
				{
					value = EQteItem.ContinuousClickItem;
					return true;
				}
				break;
			case 24:
			{
				char c = name[7];
				if (c != 'F')
				{
					if (c == 'P')
					{
						if (name == "UiItem_PlotQteSuisuiDown")
						{
							value = EQteItem.SuisuiDown;
							return true;
						}
					}
				}
				else if (name == "UiItem_FocusSingleButton")
				{
					value = EQteItem.FocusSingleButtonItem;
					return true;
				}
				break;
			}
			case 25:
				if (name == "UiItem_PlotQteSuisuiRight")
				{
					value = EQteItem.SuisuiRight;
					return true;
				}
				break;
			case 26:
			{
				char c = name[7];
				if (c != 'F')
				{
					if (c == 'R')
					{
						if (name == "UiItem_RightScreenDragItem")
						{
							value = EQteItem.RightScreenDragItem;
							return true;
						}
					}
				}
				else if (name == "UiItem_FullScreenLongPress")
				{
					value = EQteItem.FullScreenLongPressItem;
					return true;
				}
				break;
			}
			}
		}
		value = EQteItem.SingleClickItem;
		return false;
	}

	// Token: 0x0601CA8A RID: 117386 RVA: 0x00899E94 File Offset: 0x00898094
	public static string[] GetStringValues()
	{
		return new string[]
		{
			"UiItem_QteBtnSingleTap",
			"UiItem_QteBtnTapRapidly",
			"UiItem_QteDrag",
			"UiItem_QteBtnLongPress",
			"UiView_PlotInteraction",
			"UiItem_QteObjectPos",
			"UiItem_PullUp",
			"UiItem_PullDown",
			"UiItem_FocusSingleButton",
			"UiItem_QteBtnRingTab",
			"UiItem_QteBtnRingMatch",
			"UiItem_CompassRotate",
			"UiItem_FullScreenLongPress",
			"UiItem_RightScreenDragItem",
			"UiItem_PlotQteSuisui",
			"UiItem_PlotQteSuisuiRight",
			"UiItem_PlotQteSuisuiDown"
		};
	}

	// Token: 0x0601CA8B RID: 117387 RVA: 0x00899F38 File Offset: 0x00898138
	public static EQteItem[] GetValues()
	{
		return new EQteItem[]
		{
			EQteItem.SingleClickItem,
			EQteItem.ContinuousClickItem,
			EQteItem.DragItem,
			EQteItem.LongPressItem,
			EQteItem.SelectOptionItem,
			EQteItem.CustomOptionItem,
			EQteItem.PullUpItem,
			EQteItem.PullDownItem,
			EQteItem.FocusSingleButtonItem,
			EQteItem.RingTapItem,
			EQteItem.RingMatchTapItem,
			EQteItem.CompassRotateItem,
			EQteItem.FullScreenLongPressItem,
			EQteItem.RightScreenDragItem,
			EQteItem.SuisuiSlideItem,
			EQteItem.SuisuiRight,
			EQteItem.SuisuiDown
		};
	}

	// Token: 0x0601CA8C RID: 117388 RVA: 0x00899F4C File Offset: 0x0089814C
	public static string[] GetNames()
	{
		return new string[]
		{
			"SingleClickItem",
			"ContinuousClickItem",
			"DragItem",
			"LongPressItem",
			"SelectOptionItem",
			"CustomOptionItem",
			"PullUpItem",
			"PullDownItem",
			"FocusSingleButtonItem",
			"RingTapItem",
			"RingMatchTapItem",
			"CompassRotateItem",
			"FullScreenLongPressItem",
			"RightScreenDragItem",
			"SuisuiSlideItem",
			"SuisuiRight",
			"SuisuiDown"
		};
	}
}

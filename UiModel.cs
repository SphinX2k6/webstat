using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;

// Token: 0x02003445 RID: 13381
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class UiModel : Singleton<UiModel>
{
	// Token: 0x0601C0DE RID: 114910 RVA: 0x0085CE0C File Offset: 0x0085B00C
	[NullableContext(2)]
	public UiViewBase GetTopView(ELayerType layer)
	{
		if (layer <= ELayerType.Pop)
		{
			switch (layer)
			{
			case ELayerType.HUD:
				if (this.HudMap.Count <= 0)
				{
					return null;
				}
				return this.HudMap.Values.Last<UiViewBase>();
			case ELayerType.Normal:
				return this.NormalStack.Peek();
			case ELayerType.HUD | ELayerType.Normal:
				break;
			case ELayerType.Plot:
				return this.PlotNormalStack.Peek();
			default:
				if (layer == ELayerType.Pop)
				{
					if (this.PopList.Count <= 0)
					{
						return null;
					}
					return this.PopList[this.PopList.Count - 1];
				}
				break;
			}
		}
		else if (layer != ELayerType.Guide)
		{
			if (layer != ELayerType.Loading)
			{
				if (layer == ELayerType.NetWork)
				{
					if (this.NetWorkList.Count <= 0)
					{
						return null;
					}
					return this.NetWorkList[this.NetWorkList.Count - 1];
				}
			}
			else
			{
				if (this.LoadingMap.Count <= 0)
				{
					return null;
				}
				return this.LoadingMap.Values.ToArray<UiViewBase>()[this.LoadingMap.Count - 1];
			}
		}
		else
		{
			if (this.GuideList.Count <= 0)
			{
				return null;
			}
			return this.GuideList[this.GuideList.Count - 1];
		}
		return null;
	}

	// Token: 0x0601C0DF RID: 114911 RVA: 0x0085CF47 File Offset: 0x0085B147
	public void AddNpcIconViewUnit(UiPanelBase npcIconView)
	{
		if (this.NpcIconViewUnitList.Contains(npcIconView))
		{
			return;
		}
		this.NpcIconViewUnitList.Add(npcIconView);
	}

	// Token: 0x0601C0E0 RID: 114912 RVA: 0x0085CF65 File Offset: 0x0085B165
	public void RemoveNpcIconViewUnit(UiPanelBase npcIconView)
	{
		if (!this.NpcIconViewUnitList.Contains(npcIconView))
		{
			return;
		}
		this.NpcIconViewUnitList.Remove(npcIconView);
	}

	// Token: 0x0601C0E1 RID: 114913 RVA: 0x0085CF84 File Offset: 0x0085B184
	public void SetNpcIconViewListShowState(bool visible)
	{
		foreach (UiPanelBase uiPanelBase in this.NpcIconViewUnitList)
		{
			uiPanelBase.GetRootItem().SetUIActive(visible);
		}
	}

	// Token: 0x0601C0E2 RID: 114914 RVA: 0x0085CFDC File Offset: 0x0085B1DC
	[NullableContext(2)]
	public UiViewBase GetFloatView(EUiViewName name)
	{
		UiFloatConfig? uiFloatConfig = ConfigBase<UiViewConfig>.Instance.GetUiFloatConfig(name);
		if (uiFloatConfig == null)
		{
			return null;
		}
		string key = StringUtils.IsEmpty(uiFloatConfig.Value.Area) ? name : uiFloatConfig.Value.Area;
		return this.ShowViewMap.GetValueOrDefault(key);
	}

	// Token: 0x0601C0E3 RID: 114915 RVA: 0x0085D03C File Offset: 0x0085B23C
	[NullableContext(2)]
	public UiViewBase PeekNormalView(int offsetFromTop = 0)
	{
		if (this.NormalStack.Size <= offsetFromTop)
		{
			return null;
		}
		int num = this.NormalStack.Size - 1 - offsetFromTop;
		int num2 = 0;
		foreach (UiViewBase result in this.NormalStack)
		{
			if (num2 == num)
			{
				return result;
			}
			num2++;
		}
		return null;
	}

	// Token: 0x0400E2A9 RID: 58025
	public readonly Dictionary<EUiViewName, UiViewBase> HudMap = new Dictionary<EUiViewName, UiViewBase>();

	// Token: 0x0400E2AA RID: 58026
	public readonly global::Stack<UiViewBase> NormalStack = new global::Stack<UiViewBase>();

	// Token: 0x0400E2AB RID: 58027
	public readonly global::Stack<UiViewBase> PlotNormalStack = new global::Stack<UiViewBase>();

	// Token: 0x0400E2AC RID: 58028
	public readonly List<UiViewBase> PopList = new List<UiViewBase>();

	// Token: 0x0400E2AD RID: 58029
	public readonly Dictionary<string, FloatViewQueue> FloatQueueMap = new Dictionary<string, FloatViewQueue>();

	// Token: 0x0400E2AE RID: 58030
	public readonly Dictionary<string, UiViewBase> ShowViewMap = new Dictionary<string, UiViewBase>();

	// Token: 0x0400E2AF RID: 58031
	public readonly Dictionary<string, UiViewBase> HideViewMap = new Dictionary<string, UiViewBase>();

	// Token: 0x0400E2B0 RID: 58032
	public readonly List<UiViewBase> GuideList = new List<UiViewBase>();

	// Token: 0x0400E2B1 RID: 58033
	public readonly Dictionary<EUiViewName, UiViewBase> LoadingMap = new Dictionary<EUiViewName, UiViewBase>();

	// Token: 0x0400E2B2 RID: 58034
	public readonly Dictionary<EUiViewName, UiViewBase> DebugMap = new Dictionary<EUiViewName, UiViewBase>();

	// Token: 0x0400E2B3 RID: 58035
	public readonly List<UiViewBase> NetWorkList = new List<UiViewBase>();

	// Token: 0x0400E2B4 RID: 58036
	private readonly HashSet<UiPanelBase> NpcIconViewUnitList = new HashSet<UiPanelBase>();

	// Token: 0x0400E2B5 RID: 58037
	public readonly HashSet<EUiViewName> ResetToViewWhiteSet = new HashSet<EUiViewName>
	{
		EUiViewName.ReviveView
	};

	// Token: 0x0400E2B6 RID: 58038
	public bool IsInMainView;

	// Token: 0x0400E2B7 RID: 58039
	public bool InNormalQueue;

	// Token: 0x0400E2B8 RID: 58040
	public readonly HashSet<EUiViewName> SeamlessStackWhileList = new HashSet<EUiViewName>
	{
		EUiViewName.BattleView
	};

	// Token: 0x0400E2B9 RID: 58041
	public EUiViewName MainViewName = EUiViewName.BattleView;

	// Token: 0x0400E2BA RID: 58042
	public readonly HashSet<EUiViewName> CanShowPlotViewWhiteList = new HashSet<EUiViewName>
	{
		EUiViewName.BattleView,
		EUiViewName.CommonGameMainView,
		EUiViewName.DangoAbyssWorldView,
		EUiViewName.PhantomArenaBattleDetailsView,
		EUiViewName.HonamiStoryTechnologyView,
		EUiViewName.LaHaiLuoCollectView,
		EUiViewName.RiLingCollectView,
		EUiViewName.MengZhouCollectView,
		EUiViewName.DrinksSelectRoleView,
		EUiViewName.DrinksGameplayView,
		EUiViewName.DrinksShowView,
		EUiViewName.GuessJokerSelectRoleView,
		EUiViewName.TetrisGameView,
		EUiViewName.VillageInfrWorldBuildView
	};

	// Token: 0x0400E2BB RID: 58043
	public HashSet<EUiViewName> NormalStackBottomWhiteSet = new HashSet<EUiViewName>
	{
		EUiViewName.LoginView,
		EUiViewName.LoginDebugView,
		EUiViewName.CreateCharacterView,
		EUiViewName.MobileSwitchInputView
	};
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000FE5 RID: 4069
[NullableContext(1)]
[Nullable(0)]
public class AchievementMainView : UiViewBase
{
	// Token: 0x060068F3 RID: 26867 RVA: 0x001B5841 File Offset: 0x001B3A41
	public AchievementMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060068F4 RID: 26868 RVA: 0x001B5854 File Offset: 0x001B3A54
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickOneClickReceive));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060068F5 RID: 26869 RVA: 0x001B59C0 File Offset: 0x001B3BC0
	protected override UniTask OnCreateAsync()
	{
		AchievementMainView.<OnCreateAsync>d__10 <OnCreateAsync>d__;
		<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnCreateAsync>d__.<>1__state = -1;
		<OnCreateAsync>d__.<>t__builder.Start<AchievementMainView.<OnCreateAsync>d__10>(ref <OnCreateAsync>d__);
		return <OnCreateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060068F6 RID: 26870 RVA: 0x001B59FC File Offset: 0x001B3BFC
	protected override void OnStart()
	{
		this.CurrentStarNumText = base.GetText(0);
		this.AchievementProgressText = base.GetText(1);
		this.CaptionItem = new PopupCaptionItem(base.GetItem(2));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnClickBackBtn));
		this.AchievementRecentScroller = new LoopScrollView<AchievementSmallItem, AchievementData>(base.GetLoopScrollViewComponent(3), (AUIBaseActor)base.GetItem(5).GetOwner(), new Func<AchievementSmallItem>(this.OnRecentScrollerItemCreate), false);
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(4);
		this.ScrollView = new GenericLayout<AchievementCategoryItem, AchievementCategoryData>(scrollViewWithScrollbar.GetContent().GetComponentByClass(UUILayoutBase.StaticClass()) as UUILayoutBase, new Func<AchievementCategoryItem>(this.UpdateItem), null, false, true);
	}

	// Token: 0x060068F7 RID: 26871 RVA: 0x001B5AB8 File Offset: 0x001B3CB8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnAchievementDataNotify, new Action(this.OnAchievementDataNotify));
	}

	// Token: 0x060068F8 RID: 26872 RVA: 0x001B5AD6 File Offset: 0x001B3CD6
	protected override void OnBeforeShow()
	{
		this.RefreshRecentRewardScroller();
		this.RefreshCategoryScroller();
		this.RefreshStar();
		this.RefreshOneClickBtn();
		this.UpdateProgressText();
	}

	// Token: 0x060068F9 RID: 26873 RVA: 0x001B5AF6 File Offset: 0x001B3CF6
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAchievementDataNotify, new Action(this.OnAchievementDataNotify));
	}

	// Token: 0x060068FA RID: 26874 RVA: 0x001B5B14 File Offset: 0x001B3D14
	protected override void OnBeforeDestroy()
	{
		if (this.CaptionItem != null)
		{
			this.CaptionItem.Destroy(null);
			this.CaptionItem = null;
		}
		if (this.AchievementRecentScroller != null)
		{
			this.AchievementRecentScroller.ClearGridProxies();
			this.AchievementRecentScroller = null;
		}
		if (this.AchievementProgressText != null)
		{
			this.AchievementProgressText = null;
		}
		if (this.CurrentStarNumText != null)
		{
			this.CurrentStarNumText = null;
		}
	}

	// Token: 0x060068FB RID: 26875 RVA: 0x001B5B74 File Offset: 0x001B3D74
	private void RefreshStar()
	{
		int achievementFinishedStar = ModelBase<AchievementModel>.Instance.GetAchievementFinishedStar();
		this.CurrentStarNumText.SetText(achievementFinishedStar.ToString(), true);
	}

	// Token: 0x060068FC RID: 26876 RVA: 0x001B5BA0 File Offset: 0x001B3DA0
	private void RefreshOneClickBtn()
	{
		HashSet<int> hashSet = new HashSet<int>();
		IReadOnlyList<RogueSeason> rogueSeasonConfigList = ConfigBase<RoguelikeConfig>.Instance.GetRogueSeasonConfigList();
		if (rogueSeasonConfigList != null)
		{
			for (int i = 0; i < rogueSeasonConfigList.Count; i++)
			{
				hashSet.Add(rogueSeasonConfigList[i].Achievement);
			}
		}
		AchievementConfig instance = ConfigBase<AchievementConfig>.Instance;
		Dictionary<int, AchievementData> allAchievementData = ModelBase<AchievementModel>.Instance.GetAllAchievementData();
		Dictionary<int, AchievementGroupData> allAchievementGroupData = ModelBase<AchievementModel>.Instance.GetAllAchievementGroupData();
		bool flag = false;
		foreach (AchievementData achievementData in allAchievementData.Values)
		{
			if (achievementData.GetFinishState() == EAchievementStateEnum.CanGetReward)
			{
				int achievementGroupCategory = instance.GetAchievementGroupCategory(achievementData.GetGroupId());
				if (!hashSet.Contains(achievementGroupCategory))
				{
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			allAchievementGroupData.GetEnumerator();
			foreach (AchievementGroupData achievementGroupData in allAchievementGroupData.Values)
			{
				if (achievementGroupData.GetFinishState() == EAchievementStateEnum.CanGetReward)
				{
					int achievementGroupCategory2 = instance.GetAchievementGroupCategory(achievementGroupData.GetId());
					if (!hashSet.Contains(achievementGroupCategory2) && achievementGroupData.GetRewards().Count > 0)
					{
						flag = true;
						break;
					}
				}
			}
		}
		base.GetButton(7).RootUIComp.Get().SetUIActive(flag);
	}

	// Token: 0x060068FD RID: 26877 RVA: 0x001B5D10 File Offset: 0x001B3F10
	private void UpdateProgressText()
	{
		int finishedAchievementNum = ModelBase<AchievementModel>.Instance.GetFinishedAchievementNum();
		UUIText achievementProgressText = this.AchievementProgressText;
		if (achievementProgressText == null)
		{
			return;
		}
		achievementProgressText.SetText(finishedAchievementNum.ToString(), true);
	}

	// Token: 0x060068FE RID: 26878 RVA: 0x001B5D40 File Offset: 0x001B3F40
	private void RefreshRecentRewardScroller()
	{
		AchievementModel instance = ModelBase<AchievementModel>.Instance;
		List<int> recentFinishedAchievementList = ModelBase<AchievementModel>.Instance.GetRecentFinishedAchievementList();
		bool flag = recentFinishedAchievementList.Count > 0;
		List<AchievementData> list = new List<AchievementData>();
		for (int i = 0; i < recentFinishedAchievementList.Count; i++)
		{
			list.Add(instance.GetAchievementData(recentFinishedAchievementList[i]));
		}
		this.AchievementRecentScroller.RefreshByData(list, false, null, true);
		this.AchievementRecentScroller.SetTargetRootComponentActive(flag);
		base.GetItem(6).SetUIActive(!flag);
		List<int> list2 = new List<int>(recentFinishedAchievementList);
		if (flag)
		{
			if (this.IsRecentFinishedListChanged(list2))
			{
				this.CachedFocusGridIndex = 0;
				this.AchievementRecentScroller.ScrollToGridIndex(0, false);
				UUIItem gridByDisplayIndex = this.AchievementRecentScroller.GetGridByDisplayIndex(0);
				if (gridByDisplayIndex != null)
				{
					ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(gridByDisplayIndex, true, false, false);
				}
			}
			else if (this.CachedFocusGridIndex > 0)
			{
				this.AchievementRecentScroller.ScrollToGridIndex(this.CachedFocusGridIndex, false);
				UUIItem grid = this.AchievementRecentScroller.GetGrid(this.CachedFocusGridIndex);
				if (grid != null)
				{
					ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(grid, true, false, false);
				}
			}
		}
		this.CachedRecentFinishedIds = list2;
	}

	// Token: 0x060068FF RID: 26879 RVA: 0x001B5E5C File Offset: 0x001B405C
	private bool IsRecentFinishedListChanged(List<int> currentIds)
	{
		List<int> cachedRecentFinishedIds = this.CachedRecentFinishedIds;
		if (cachedRecentFinishedIds == null)
		{
			return true;
		}
		if (cachedRecentFinishedIds.Count != currentIds.Count)
		{
			return true;
		}
		for (int i = 0; i < cachedRecentFinishedIds.Count; i++)
		{
			if (cachedRecentFinishedIds[i] != currentIds[i])
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06006900 RID: 26880 RVA: 0x001B5EAC File Offset: 0x001B40AC
	private void RefreshCategoryScroller()
	{
		List<AchievementCategoryData> achievementCategoryArray = ModelBase<AchievementModel>.Instance.GetAchievementCategoryArray();
		this.ScrollView.RefreshByData(achievementCategoryArray, null, false);
	}

	// Token: 0x06006901 RID: 26881 RVA: 0x001B5ED2 File Offset: 0x001B40D2
	private AchievementCategoryItem UpdateItem()
	{
		return new AchievementCategoryItem();
	}

	// Token: 0x06006902 RID: 26882 RVA: 0x001B5ED9 File Offset: 0x001B40D9
	private void OnAchievementDataNotify()
	{
		this.RefreshRecentRewardScroller();
		this.RefreshStar();
		this.UpdateProgressText();
		this.RefreshOneClickBtn();
	}

	// Token: 0x06006903 RID: 26883 RVA: 0x001B5EF3 File Offset: 0x001B40F3
	private AchievementSmallItem OnRecentScrollerItemCreate()
	{
		return new AchievementSmallItem
		{
			OnClickButtonCallback = new Action<int>(this.OnClickGrid)
		};
	}

	// Token: 0x06006904 RID: 26884 RVA: 0x001B5F0C File Offset: 0x001B410C
	private void OnClickGrid(int index)
	{
		this.CachedFocusGridIndex = index;
	}

	// Token: 0x06006905 RID: 26885 RVA: 0x001B5F15 File Offset: 0x001B4115
	protected override void OnBeforeHide()
	{
	}

	// Token: 0x06006906 RID: 26886 RVA: 0x001B5F17 File Offset: 0x001B4117
	private void OnClickBackBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x06006907 RID: 26887 RVA: 0x001B5F20 File Offset: 0x001B4120
	private void OnClickOneClickReceive()
	{
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		HashSet<int> hashSet = new HashSet<int>();
		IReadOnlyList<RogueSeason> rogueSeasonConfigList = ConfigBase<RoguelikeConfig>.Instance.GetRogueSeasonConfigList();
		if (rogueSeasonConfigList != null)
		{
			for (int i = 0; i < rogueSeasonConfigList.Count; i++)
			{
				hashSet.Add(rogueSeasonConfigList[i].Achievement);
			}
		}
		Dictionary<int, AchievementData> allAchievementData = ModelBase<AchievementModel>.Instance.GetAllAchievementData();
		AchievementConfig instance = ConfigBase<AchievementConfig>.Instance;
		foreach (KeyValuePair<int, AchievementData> keyValuePair in allAchievementData)
		{
			int key = keyValuePair.Key;
			AchievementData value = keyValuePair.Value;
			int achievementGroupCategory = instance.GetAchievementGroupCategory(value.GetGroupId());
			if (value.GetFinishState() == EAchievementStateEnum.CanGetReward && !hashSet.Contains(achievementGroupCategory))
			{
				list.Add(key);
			}
		}
		foreach (KeyValuePair<int, AchievementGroupData> keyValuePair2 in ModelBase<AchievementModel>.Instance.GetAllAchievementGroupData())
		{
			int key2 = keyValuePair2.Key;
			AchievementGroupData value2 = keyValuePair2.Value;
			int category = value2.GetCategory();
			if (value2.GetFinishState() == EAchievementStateEnum.CanGetReward && !hashSet.Contains(category) && value2.GetRewards().Count > 0)
			{
				list2.Add(key2);
			}
		}
		ControllerBase<AchievementController>.Instance.RequestGetMultiAchievementReward(list.ToArray(), list2.ToArray());
	}

	// Token: 0x040031E8 RID: 12776
	[Nullable(2)]
	private UUIText AchievementProgressText;

	// Token: 0x040031E9 RID: 12777
	[Nullable(2)]
	private UUIText CurrentStarNumText;

	// Token: 0x040031EA RID: 12778
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x040031EB RID: 12779
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<AchievementCategoryItem, AchievementCategoryData> ScrollView;

	// Token: 0x040031EC RID: 12780
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<AchievementSmallItem, AchievementData> AchievementRecentScroller;

	// Token: 0x040031ED RID: 12781
	[Nullable(2)]
	private List<int> CachedRecentFinishedIds;

	// Token: 0x040031EE RID: 12782
	private int CachedFocusGridIndex = -1;

	// Token: 0x020073C2 RID: 29634
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x040280DB RID: 164059
		CurrentStarNumText,
		// Token: 0x040280DC RID: 164060
		AchievementProgressText,
		// Token: 0x040280DD RID: 164061
		CaptionItem,
		// Token: 0x040280DE RID: 164062
		RecentFinishScroller,
		// Token: 0x040280DF RID: 164063
		CategoryScroller,
		// Token: 0x040280E0 RID: 164064
		RecentFinishItem,
		// Token: 0x040280E1 RID: 164065
		EmptyAchievementItem,
		// Token: 0x040280E2 RID: 164066
		BtnOneClickReceive
	}
}

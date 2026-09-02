using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.VillageInfr;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B97 RID: 7063
[NullableContext(1)]
[Nullable(0)]
public class MapExploreDetailView : UiTickViewBase
{
	// Token: 0x0600CD57 RID: 52567 RVA: 0x0036AA0B File Offset: 0x00368C0B
	public MapExploreDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600CD58 RID: 52568 RVA: 0x0036AA2C File Offset: 0x00368C2C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 32;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 7;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnAreaChangeLeftBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnAreaChangeRightBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnStoryBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnAreaBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(15, new Action(this.OnExploreToolTips));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnAreaTaskBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(17, new Action(this.OnExploreProgressBarDetailBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CD59 RID: 52569 RVA: 0x0036AFA0 File Offset: 0x003691A0
	protected override UniTask OnBeforeStartAsync()
	{
		MapExploreDetailView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MapExploreDetailView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600CD5A RID: 52570 RVA: 0x0036AFE4 File Offset: 0x003691E4
	private UniTask CreateStageRewardPanel()
	{
		MapExploreDetailView.<CreateStageRewardPanel>d__14 <CreateStageRewardPanel>d__;
		<CreateStageRewardPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateStageRewardPanel>d__.<>4__this = this;
		<CreateStageRewardPanel>d__.<>1__state = -1;
		<CreateStageRewardPanel>d__.<>t__builder.Start<MapExploreDetailView.<CreateStageRewardPanel>d__14>(ref <CreateStageRewardPanel>d__);
		return <CreateStageRewardPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600CD5B RID: 52571 RVA: 0x0036B028 File Offset: 0x00369228
	private UniTask CreatePlayProgressPanel()
	{
		MapExploreDetailView.<CreatePlayProgressPanel>d__15 <CreatePlayProgressPanel>d__;
		<CreatePlayProgressPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreatePlayProgressPanel>d__.<>4__this = this;
		<CreatePlayProgressPanel>d__.<>1__state = -1;
		<CreatePlayProgressPanel>d__.<>t__builder.Start<MapExploreDetailView.<CreatePlayProgressPanel>d__15>(ref <CreatePlayProgressPanel>d__);
		return <CreatePlayProgressPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600CD5C RID: 52572 RVA: 0x0036B06C File Offset: 0x0036926C
	private UniTask CreateExploreDetailLockItem()
	{
		MapExploreDetailView.<CreateExploreDetailLockItem>d__16 <CreateExploreDetailLockItem>d__;
		<CreateExploreDetailLockItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateExploreDetailLockItem>d__.<>4__this = this;
		<CreateExploreDetailLockItem>d__.<>1__state = -1;
		<CreateExploreDetailLockItem>d__.<>t__builder.Start<MapExploreDetailView.<CreateExploreDetailLockItem>d__16>(ref <CreateExploreDetailLockItem>d__);
		return <CreateExploreDetailLockItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600CD5D RID: 52573 RVA: 0x0036B0B0 File Offset: 0x003692B0
	private UniTask CreateExploreTrackButton()
	{
		MapExploreDetailView.<CreateExploreTrackButton>d__17 <CreateExploreTrackButton>d__;
		<CreateExploreTrackButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateExploreTrackButton>d__.<>4__this = this;
		<CreateExploreTrackButton>d__.<>1__state = -1;
		<CreateExploreTrackButton>d__.<>t__builder.Start<MapExploreDetailView.<CreateExploreTrackButton>d__17>(ref <CreateExploreTrackButton>d__);
		return <CreateExploreTrackButton>d__.<>t__builder.Task;
	}

	// Token: 0x0600CD5E RID: 52574 RVA: 0x0036B0F3 File Offset: 0x003692F3
	protected override void OnStart()
	{
		UUIText text = base.GetText(25);
		if (text == null)
		{
			return;
		}
		text.SetText("0", true);
	}

	// Token: 0x0600CD5F RID: 52575 RVA: 0x0036B110 File Offset: 0x00369310
	private void GetRewardCallback()
	{
		int[] rewardIds = (from data in this.CurAreaData.GetStageRewardDataList()
		where data.State == EDailyActiveState.FinishedAndNotTaken
		select data.Id).ToArray<int>();
		ControllerBase<ExploreProgressController>.Instance.ReceiveAreaStageRewardAsyncRequest(rewardIds);
	}

	// Token: 0x0600CD60 RID: 52576 RVA: 0x0036B184 File Offset: 0x00369384
	private void UpdateStageRewardByArea()
	{
		MapAreaRewardPanel stageRewardPanel = this.StageRewardPanel;
		if (stageRewardPanel == null)
		{
			return;
		}
		stageRewardPanel.ChangeParamData(new MapAreaRewardParam
		{
			InitValue = this.CurAreaData.GetProgress(),
			MaxValue = this.CurAreaData.MaxExploreProgress,
			RewardDataList = this.CurAreaData.GetStageRewardDataList(),
			GetRewardCallback = new Action(this.GetRewardCallback)
		});
	}

	// Token: 0x0600CD61 RID: 52577 RVA: 0x0036B1EC File Offset: 0x003693EC
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.OnReceiveAreaStageRewardResponse, new Action<IReadOnlyList<int>>(this.EventReceiveAreaStageRewardResponse));
		Singleton<EventSystem>.Instance.Add(EEventName.OnAreaExploreProgressUpdate, new Action<int>(this.EventAreaExploreProgressUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.MapExploreDetailItemClick, new Action<ExploreAreaItemData>(this.EventMapExploreDetailItemClick));
		Singleton<EventSystem>.Instance.Add(EEventName.AreaPlayPointUpdate, new Action<int>(this.EventAreaPlayPointUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.AreaStoryProgressSave, new Action(this.EventAreaStoryProgressSave));
		Singleton<EventSystem>.Instance.Add(EEventName.OpenExploreAreaDetailViewFromMap, new <>f__AnonymousDelegate6<int, EExploreType?>(this.EventOpenExploreAreaDetailViewFromMap));
	}

	// Token: 0x0600CD62 RID: 52578 RVA: 0x0036B2A4 File Offset: 0x003694A4
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnReceiveAreaStageRewardResponse, new Action<IReadOnlyList<int>>(this.EventReceiveAreaStageRewardResponse));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAreaExploreProgressUpdate, new Action<int>(this.EventAreaExploreProgressUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.MapExploreDetailItemClick, new Action<ExploreAreaItemData>(this.EventMapExploreDetailItemClick));
		Singleton<EventSystem>.Instance.Remove(EEventName.AreaPlayPointUpdate, new Action<int>(this.EventAreaPlayPointUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.AreaStoryProgressSave, new Action(this.EventAreaStoryProgressSave));
		Singleton<EventSystem>.Instance.Remove(EEventName.OpenExploreAreaDetailViewFromMap, new <>f__AnonymousDelegate6<int, EExploreType?>(this.EventOpenExploreAreaDetailViewFromMap));
	}

	// Token: 0x0600CD63 RID: 52579 RVA: 0x0036B359 File Offset: 0x00369559
	protected override void OnBeforeShow()
	{
		if (!this.UpdateViewByAreaData())
		{
			base.CloseMe(null);
		}
	}

	// Token: 0x0600CD64 RID: 52580 RVA: 0x0036B36A File Offset: 0x0036956A
	protected override void OnBeforeDestroy()
	{
		this.StageRewardPanel = null;
		this.PopupCaption = null;
	}

	// Token: 0x0600CD65 RID: 52581 RVA: 0x0036B37C File Offset: 0x0036957C
	protected void InitExploreScroll()
	{
		UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(3);
		this.ExploreScroll = new LoopScrollView<MapExploreDetailItem, ExploreAreaItemData>(loopScrollViewComponent, base.GetItem(20).GetOwner() as AUIBaseActor, new Func<MapExploreDetailItem>(this.InitHandExploreDetailItem), false);
	}

	// Token: 0x0600CD66 RID: 52582 RVA: 0x0036B3BC File Offset: 0x003695BC
	private void UpdateExploreScrollList()
	{
		LoopScrollView<MapExploreDetailItem, ExploreAreaItemData> exploreScroll = this.ExploreScroll;
		if (exploreScroll == null)
		{
			return;
		}
		exploreScroll.RefreshByData(this.CurAreaData.GetAllExploreAreaItemData(), false, new Action(this.ExploreScrollSelectIndex), true);
	}

	// Token: 0x0600CD67 RID: 52583 RVA: 0x0036B3E8 File Offset: 0x003695E8
	private void ExploreScrollSelectIndex()
	{
		int selectAreaItemIndex = this.GetSelectAreaItemIndex();
		LoopScrollView<MapExploreDetailItem, ExploreAreaItemData> exploreScroll = this.ExploreScroll;
		if (exploreScroll != null)
		{
			exploreScroll.ScrollToGridIndex(selectAreaItemIndex, true);
		}
		LoopScrollView<MapExploreDetailItem, ExploreAreaItemData> exploreScroll2 = this.ExploreScroll;
		if (exploreScroll2 != null)
		{
			exploreScroll2.DeselectCurrentGridProxy(false);
		}
		LoopScrollView<MapExploreDetailItem, ExploreAreaItemData> exploreScroll3 = this.ExploreScroll;
		if (exploreScroll3 != null)
		{
			exploreScroll3.SelectGridProxy(selectAreaItemIndex, false);
		}
		LoopScrollView<MapExploreDetailItem, ExploreAreaItemData> exploreScroll4 = this.ExploreScroll;
		MapExploreDetailItem mapExploreDetailItem = (exploreScroll4 != null) ? exploreScroll4.UnsafeGetGridProxy(selectAreaItemIndex, false) : null;
		if (mapExploreDetailItem != null)
		{
			ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(mapExploreDetailItem.GetBtnRootItem(), true, false, false);
		}
	}

	// Token: 0x0600CD68 RID: 52584 RVA: 0x0036B460 File Offset: 0x00369660
	private int GetSelectAreaItemIndex()
	{
		List<ExploreAreaItemData> allExploreAreaItemData = this.CurAreaData.GetAllExploreAreaItemData();
		int num = 0;
		if (this.CurAreaItemData != null)
		{
			num = allExploreAreaItemData.FindIndex((ExploreAreaItemData data) => data.ExploreType == this.CurAreaItemData.ExploreType);
		}
		if (num == -1)
		{
			num = 0;
			this.CurAreaItemData = allExploreAreaItemData[num];
		}
		return num;
	}

	// Token: 0x0600CD69 RID: 52585 RVA: 0x0036B4AA File Offset: 0x003696AA
	private MapExploreDetailItem InitHandExploreDetailItem()
	{
		return new MapExploreDetailItem();
	}

	// Token: 0x0600CD6A RID: 52586 RVA: 0x0036B4B4 File Offset: 0x003696B4
	private void OnAreaBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MapAreaShowView, new MapAreaShowViewParams
		{
			CountryId = new int?(this.CurAreaData.CountryId),
			AreaId = new int?(this.CurAreaData.AreaId),
			OnClickArea = new Action<int>(this.OnMapAreaShowClickArea)
		}, null);
	}

	// Token: 0x0600CD6B RID: 52587 RVA: 0x0036B514 File Offset: 0x00369714
	private void OnStoryBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MapExploreStoryView, new MapExploreStoryViewParams
		{
			AreaData = this.CurAreaData
		}, new TOpenViewCallBack(this.AddViewToChild));
	}

	// Token: 0x0600CD6C RID: 52588 RVA: 0x0036B544 File Offset: 0x00369744
	private void OnExploreToolTips()
	{
		ExploreAreaItemData curAreaItemData = this.CurAreaItemData;
		int? num = (curAreaItemData != null) ? curAreaItemData.GetPhantomSkillHelpId() : null;
		if (num != null)
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(num.Value);
		}
	}

	// Token: 0x0600CD6D RID: 52589 RVA: 0x0036B586 File Offset: 0x00369786
	private void OnAreaTaskBtn()
	{
		if (this.CurAreaItemData != null)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ExploreMissionView, this.CurAreaItemData.AreaId, new TOpenViewCallBack(this.AddViewToChild));
		}
	}

	// Token: 0x0600CD6E RID: 52590 RVA: 0x0036B5BB File Offset: 0x003697BB
	private void OnExploreProgressBarDetailBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MapPlayPointDetailView, new MapPlayPointDetailViewParams
		{
			ExploreAreaItemData = this.CurAreaItemData
		}, new TOpenViewCallBack(this.AddViewToChild));
	}

	// Token: 0x0600CD6F RID: 52591 RVA: 0x0036B5E9 File Offset: 0x003697E9
	private void AddViewToChild(bool success, int viewId)
	{
		if (success)
		{
			UiViewBase uiViewBase = Singleton<UiModel>.Instance.NormalStack.Peek();
			if (uiViewBase == null)
			{
				return;
			}
			uiViewBase.AddChildViewById(viewId);
		}
	}

	// Token: 0x0600CD70 RID: 52592 RVA: 0x0036B608 File Offset: 0x00369808
	private void OnExploreTrackBtn(int index)
	{
		if (this.CurAreaItemData != null && !this.CurAreaItemData.IsUnlocked())
		{
			SkipTaskManager.RunByConfigId(this.CurAreaItemData.AccessPathId, null);
			return;
		}
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.WorldMapView))
		{
			ExploreAreaItemData curAreaItemData = this.CurAreaItemData;
			if (curAreaItemData != null)
			{
				curAreaItemData.TrackPoint();
			}
		}
		else
		{
			ModelBase<ExploreProgressModel>.Instance.SetTrackExploreAreaItemData(this.CurAreaItemData);
		}
		base.CloseMe(null);
	}

	// Token: 0x0600CD71 RID: 52593 RVA: 0x0036B677 File Offset: 0x00369877
	private void OnCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600CD72 RID: 52594 RVA: 0x0036B680 File Offset: 0x00369880
	private void OnAreaChangeLeftBtn()
	{
		this.ChangeAreaDataByAddIndex(-1);
		base.PlaySequence("SwitchLeft", null, false);
	}

	// Token: 0x0600CD73 RID: 52595 RVA: 0x0036B696 File Offset: 0x00369896
	private void OnAreaChangeRightBtn()
	{
		this.ChangeAreaDataByAddIndex(1);
		base.PlaySequence("SwitchRight", null, false);
	}

	// Token: 0x0600CD74 RID: 52596 RVA: 0x0036B6AC File Offset: 0x003698AC
	private void ChangeAreaDataByAddIndex(int add)
	{
		int count = this.AreaDataList.Count;
		int num = this.CurAreaDataIndex + add;
		num = Singleton<MathUtils>.Instance.Clamp(num, 0, count - 1);
		if (num == this.CurAreaDataIndex)
		{
			return;
		}
		this.CurAreaDataIndex = num;
		this.CurAreaData = this.AreaDataList[num];
		this.UpdateViewByAreaData();
	}

	// Token: 0x0600CD75 RID: 52597 RVA: 0x0036B708 File Offset: 0x00369908
	private bool UpdateViewByAreaData()
	{
		if (this.CurAreaData == null)
		{
			return false;
		}
		UUIButtonComponent button = base.GetButton(1);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(this.CurAreaDataIndex > 0);
		}
		UUIButtonComponent button2 = base.GetButton(2);
		if (button2 != null)
		{
			button2.RootUIComp.Get().SetUIActive(this.CurAreaDataIndex < this.AreaDataList.Count - 1);
		}
		this.CurAreaData.CheckUpdatePlayPointData();
		this.UpdateAreaBase();
		this.UpdateStageRewardByArea();
		this.UpdateExploreScrollList();
		float num = (float)this.CurAreaData.GetProgress();
		UUISprite sprite = base.GetSprite(26);
		if (sprite != null)
		{
			sprite.SetFillAmount(num / 100f);
		}
		this.UpdateChangeAreaRedDot();
		this.UpdateStoryRedDot();
		this.UpdateHighLightTips();
		return true;
	}

	// Token: 0x0600CD76 RID: 52598 RVA: 0x0036B7D4 File Offset: 0x003699D4
	private void UpdateAreaBase()
	{
		UUIText text = base.GetText(5);
		if (text != null)
		{
			text.ShowTextNew(this.CurAreaData.GetNameId());
		}
		float num = (float)this.CurAreaData.GetProgress();
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendFormatted<float>(num);
		defaultInterpolatedStringHandler.AppendLiteral("%");
		string newText = defaultInterpolatedStringHandler.ToStringAndClear();
		UUIText text2 = base.GetText(8);
		if (text2 != null)
		{
			text2.SetText(newText, true);
		}
		UUIText text3 = base.GetText(25);
		if (text3 != null)
		{
			UUIItem uuiitem = text3;
			bool bUseChangeColor = num > 0f;
			FColor? fcolor = new FColor?(text3.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}
	}

	// Token: 0x0600CD77 RID: 52599 RVA: 0x0036B870 File Offset: 0x00369A70
	private void OnMapAreaShowClickArea(int areaId)
	{
		if (base.IsDestroyOrDestroying)
		{
			return;
		}
		Singleton<UiManager>.Instance.CloseView(EUiViewName.MapAreaShowView, null);
		ExploreAreaData curAreaData = this.CurAreaData;
		if (curAreaData != null && curAreaData.AreaId == areaId)
		{
			return;
		}
		if (!this.UpdateAreaDataByAreaId(areaId))
		{
			return;
		}
		if (base.IsShow)
		{
			this.UpdateViewByAreaData();
		}
	}

	// Token: 0x0600CD78 RID: 52600 RVA: 0x0036B8C8 File Offset: 0x00369AC8
	private bool UpdateAreaDataByAreaId(int areaId)
	{
		ExploreAreaData exploreAreaData = ModelBase<ExploreProgressModel>.Instance.GetExploreAreaData(areaId);
		if (exploreAreaData == null)
		{
			ScrollingTipsController instance = ControllerBase<ScrollingTipsController>.Instance;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Area Id Cannot Be Found: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(areaId);
			instance.ShowTipsByText(defaultInterpolatedStringHandler.ToStringAndClear());
			return false;
		}
		this.CurAreaData = exploreAreaData;
		if (this.AreaDataList.Count <= 0)
		{
			this.AreaDataList = ModelBase<ExploreProgressModel>.Instance.GetAllAreaDataListSortCountryState();
			foreach (ExploreAreaData exploreAreaData2 in this.AreaDataList)
			{
				exploreAreaData2.ClearFlagUpdatePlayPointData();
			}
		}
		this.CurAreaDataIndex = this.AreaDataList.FindIndex((ExploreAreaData value) => value.AreaId == this.CurAreaData.AreaId);
		return true;
	}

	// Token: 0x0600CD79 RID: 52601 RVA: 0x0036B99C File Offset: 0x00369B9C
	protected override void OnTick(float delta)
	{
		MapAreaRewardPanel stageRewardPanel = this.StageRewardPanel;
		if (stageRewardPanel == null)
		{
			return;
		}
		stageRewardPanel.OnTickRefresh(delta);
	}

	// Token: 0x0600CD7A RID: 52602 RVA: 0x0036B9AF File Offset: 0x00369BAF
	private void EventReceiveAreaStageRewardResponse(IReadOnlyList<int> rewardIds)
	{
		MapAreaRewardPanel stageRewardPanel = this.StageRewardPanel;
		if (stageRewardPanel == null)
		{
			return;
		}
		stageRewardPanel.UpdateRewardIds(rewardIds);
	}

	// Token: 0x0600CD7B RID: 52603 RVA: 0x0036B9C2 File Offset: 0x00369BC2
	private void EventAreaExploreProgressUpdate(int areaId)
	{
		ExploreAreaData curAreaData = this.CurAreaData;
		if (curAreaData == null || curAreaData.AreaId != areaId)
		{
			return;
		}
		MapAreaRewardPanel stageRewardPanel = this.StageRewardPanel;
		if (stageRewardPanel == null)
		{
			return;
		}
		stageRewardPanel.RefreshProgressBarDynamic(this.CurAreaData.GetProgress());
	}

	// Token: 0x0600CD7C RID: 52604 RVA: 0x0036B9FA File Offset: 0x00369BFA
	private void EventMapExploreDetailItemClick(ExploreAreaItemData areaItemData)
	{
		this.CurAreaItemData = areaItemData;
		this.UpdateExploreDetail();
	}

	// Token: 0x0600CD7D RID: 52605 RVA: 0x0036BA09 File Offset: 0x00369C09
	private void EventAreaPlayPointUpdate(int areaId)
	{
		ExploreAreaData curAreaData = this.CurAreaData;
		if (curAreaData == null || curAreaData.AreaId != areaId)
		{
			return;
		}
		this.UpdateExploreDetail();
	}

	// Token: 0x0600CD7E RID: 52606 RVA: 0x0036BA2C File Offset: 0x00369C2C
	private void EventAreaStoryProgressSave()
	{
		this.UpdateStoryRedDot();
	}

	// Token: 0x0600CD7F RID: 52607 RVA: 0x0036BA34 File Offset: 0x00369C34
	private void EventOpenExploreAreaDetailViewFromMap(int areaId, EExploreType? exploreType = null)
	{
		ExploreAreaData curAreaData = this.CurAreaData;
		if (curAreaData != null && curAreaData.AreaId == areaId)
		{
			this.ForceChangeAreaItem(exploreType, true);
			return;
		}
		this.ForceChangeArea(areaId, exploreType);
	}

	// Token: 0x0600CD80 RID: 52608 RVA: 0x0036BA60 File Offset: 0x00369C60
	private void ForceChangeAreaItem(EExploreType? exploreType, bool isUpdate = true)
	{
		if (exploreType == null)
		{
			return;
		}
		EExploreType value = exploreType.Value;
		ExploreAreaItemData curAreaItemData = this.CurAreaItemData;
		EExploreType? eexploreType = (curAreaItemData != null) ? new EExploreType?(curAreaItemData.ExploreType) : null;
		if (value == eexploreType.GetValueOrDefault() & eexploreType != null)
		{
			return;
		}
		ExploreAreaItemData exploreAreaItemData = this.CurAreaData.GetExploreAreaItemData(exploreType.Value);
		if (exploreAreaItemData == null)
		{
			return;
		}
		this.CurAreaItemData = exploreAreaItemData;
		if (isUpdate)
		{
			this.ExploreScrollSelectIndex();
		}
	}

	// Token: 0x0600CD81 RID: 52609 RVA: 0x0036BAD9 File Offset: 0x00369CD9
	private void ForceChangeArea(int areaId, EExploreType? exploreType = null)
	{
		if (!this.UpdateAreaDataByAreaId(areaId))
		{
			return;
		}
		this.ForceChangeAreaItem(exploreType, false);
		this.UpdateViewByAreaData();
	}

	// Token: 0x0600CD82 RID: 52610 RVA: 0x0036BAF4 File Offset: 0x00369CF4
	private void UpdateExploreDetail()
	{
		ExploreAreaItemData curAreaItemData = this.CurAreaItemData;
		bool flag = curAreaItemData != null && curAreaItemData.IsUnlocked();
		UUIItem item = base.GetItem(21);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		UUIItem item2 = base.GetItem(22);
		if (item2 != null)
		{
			item2.SetUIActive(!flag);
		}
		if (!flag)
		{
			this.UpdateLockState();
			return;
		}
		UUIItem item3 = base.GetItem(29);
		if (item3 != null)
		{
			item3.SetUIActive(true);
		}
		UUIText text = base.GetText(12);
		if (text != null)
		{
			text.SetUIActive(true);
		}
		base.SetTextureByPath(this.CurAreaItemData.DescBg, base.GetTexture(11), null, null);
		UUIText text2 = base.GetText(12);
		if (text2 != null)
		{
			text2.ShowTextNew(this.CurAreaItemData.DescId);
		}
		bool flag2 = this.CurAreaItemData.IsCompleted();
		bool flag3 = this.CurAreaItemData.HasPhantomSkill();
		UUIItem item4 = base.GetItem(24);
		if (item4 != null)
		{
			item4.SetUIActive(flag2);
		}
		UUIItem item5 = base.GetItem(13);
		if (item5 != null)
		{
			item5.SetUIActive(!flag2 && flag3);
		}
		bool flag4 = this.UpdateExploreDetailLockItem();
		this.UpdateExploreProgressBar();
		bool active = this.CurAreaItemData.IsShowTrackBtn && !flag2 && flag4;
		this.ExploreTrackButton.SetActive(active);
		this.ExploreTrackButton.SetLocalTextNew("ExploreButton_1", Array.Empty<object>());
		UUIText text3 = base.GetText(14);
		string text4 = this.CurAreaItemData.GetIsPhantomSkillUnlock() ? this.CurAreaItemData.GetUnlockTextId() : this.CurAreaItemData.GetLockTextId();
		if (!string.IsNullOrEmpty(text4))
		{
			text3.ShowTextNew(text4);
		}
		text3.SetUIActive(!string.IsNullOrEmpty(text4));
		bool uiactive = this.CurAreaItemData.ExploreType == EExploreType.AreaMission;
		base.GetButton(10).RootUIComp.Get().SetUIActive(uiactive);
		this.UpdateHighLightTips();
	}

	// Token: 0x0600CD83 RID: 52611 RVA: 0x0036BCC8 File Offset: 0x00369EC8
	private void UpdateLockState()
	{
		UUIItem item = base.GetItem(22);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		ExploreAreaItemData curAreaItemData = this.CurAreaItemData;
		if (curAreaItemData != null && curAreaItemData.AccessPathId > 0)
		{
			base.GetItem(21).SetUIActive(true);
			base.GetItem(19).SetUIActive(false);
			base.GetItem(29).SetUIActive(false);
			base.GetText(12).SetUIActive(false);
			base.GetItem(24).SetUIActive(false);
			base.GetItem(13).SetUIActive(false);
			ExploreDetailLockItem exploreDetailLockItem = this.ExploreDetailLockItem;
			if (exploreDetailLockItem != null)
			{
				exploreDetailLockItem.Reset(null);
			}
			this.ExploreTrackButton.SetActive(true);
			this.ExploreTrackButton.SetLocalTextNew("ExploreButton_2", Array.Empty<object>());
		}
		ExploreAreaItemData curAreaItemData2 = this.CurAreaItemData;
		string text = (curAreaItemData2 != null) ? curAreaItemData2.GetLockDetailId() : null;
		if (!string.IsNullOrEmpty(text))
		{
			UUIText text2 = base.GetText(23);
			if (text2 == null)
			{
				return;
			}
			text2.ShowTextNew(text);
		}
	}

	// Token: 0x0600CD84 RID: 52612 RVA: 0x0036BDC0 File Offset: 0x00369FC0
	private void UpdateExploreProgressBar()
	{
		ExploreAreaItemData curAreaItemData = this.CurAreaItemData;
		bool flag = curAreaItemData != null && curAreaItemData.IsShowProgressBar;
		UUIItem item = base.GetItem(19);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		if (!flag)
		{
			return;
		}
		MapExplorePlayProgressPanel playProgressPanel = this.PlayProgressPanel;
		if (playProgressPanel != null)
		{
			playProgressPanel.UpdateData(this.CurAreaItemData.GetPlayProgressDataIgnoreHiddenList(), null);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnUpdateExploreProgressBar);
	}

	// Token: 0x0600CD85 RID: 52613 RVA: 0x0036BE28 File Offset: 0x0036A028
	private bool UpdateExploreDetailLockItem()
	{
		ExploreAreaItemData curAreaItemData = this.CurAreaItemData;
		MapMark? mapMark = (curAreaItemData != null) ? curAreaItemData.GetNearTrackMapMark() : null;
		bool result = true;
		ExploreDetailLockItem exploreDetailLockItem = this.ExploreDetailLockItem;
		if (exploreDetailLockItem != null)
		{
			exploreDetailLockItem.Reset(null);
		}
		if (mapMark == null || mapMark.Value.GameplayLockJumpId == 0 || string.IsNullOrEmpty(mapMark.Value.GameplayLockText))
		{
			return result;
		}
		ExploreAreaItemData curAreaItemData2 = this.CurAreaItemData;
		if (curAreaItemData2 == null || !curAreaItemData2.GetPlayIdIsUnlock(mapMark.Value.RelativeId))
		{
			ExploreDetailLockItem exploreDetailLockItem2 = this.ExploreDetailLockItem;
			if (exploreDetailLockItem2 != null)
			{
				exploreDetailLockItem2.RefreshExternalByData(mapMark.Value.MarkId);
			}
			result = false;
		}
		else
		{
			ExploreDetailLockItem exploreDetailLockItem3 = this.ExploreDetailLockItem;
			if (exploreDetailLockItem3 != null)
			{
				exploreDetailLockItem3.Reset(null);
			}
		}
		return result;
	}

	// Token: 0x0600CD86 RID: 52614 RVA: 0x0036BF08 File Offset: 0x0036A108
	private void UpdateChangeAreaRedDot()
	{
		foreach (ExploreAreaData exploreAreaData in this.AreaDataList)
		{
			if (exploreAreaData.AreaId != this.CurAreaData.AreaId && exploreAreaData.HasCanTakeStageReward())
			{
				UUIItem item = base.GetItem(9);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(true);
				return;
			}
		}
		UUIItem item2 = base.GetItem(9);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x0600CD87 RID: 52615 RVA: 0x0036BF98 File Offset: 0x0036A198
	private void UpdateStoryRedDot()
	{
		bool uiactive = this.CurAreaData.HasNewStoryUnlocked();
		UUIItem item = base.GetItem(27);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x17001099 RID: 4249
	// (get) Token: 0x0600CD88 RID: 52616 RVA: 0x0036BFC4 File Offset: 0x0036A1C4
	public bool? IsShowProgressBar
	{
		get
		{
			ExploreAreaItemData curAreaItemData = this.CurAreaItemData;
			if (curAreaItemData == null)
			{
				return null;
			}
			return new bool?(curAreaItemData.IsShowProgressBar);
		}
	}

	// Token: 0x0600CD89 RID: 52617 RVA: 0x0036BFF0 File Offset: 0x0036A1F0
	private void UpdateHighLightTips()
	{
		base.GetItem(30).SetUIActive(false);
		if (this.CurAreaItemData == null)
		{
			return;
		}
		if (!this.ExploreTrackButton.IsShowOrShowing)
		{
			return;
		}
		ExploreProgress? exploreProgressConfigById = ConfigBase<ExploreProgressConfig>.Instance.GetExploreProgressConfigById(this.CurAreaItemData.ConfigId);
		if (exploreProgressConfigById == null)
		{
			return;
		}
		if (exploreProgressConfigById.Value.TagType != 1)
		{
			return;
		}
		InfrV2TreeBuild? treeConfigByAreaId = ConfigBase<VillageInfrConfig>.Instance.GetTreeConfigByAreaId(this.CurAreaItemData.AreaId);
		if (treeConfigByAreaId == null)
		{
			return;
		}
		IVillageInfrTreeData treeData = ModelBase<VillageInfrModel>.Instance.GetTreeData(treeConfigByAreaId.Value.Id);
		if (treeData != null && treeData.Status == InfrV2StatusPb.InfrV2StatusComplete)
		{
			return;
		}
		base.GetItem(30).SetUIActive(true);
	}

	// Token: 0x0400621F RID: 25119
	[Nullable(2)]
	private ExploreAreaData CurAreaData;

	// Token: 0x04006220 RID: 25120
	private List<ExploreAreaData> AreaDataList = new List<ExploreAreaData>();

	// Token: 0x04006221 RID: 25121
	private int CurAreaDataIndex;

	// Token: 0x04006222 RID: 25122
	[Nullable(2)]
	private MapAreaRewardPanel StageRewardPanel;

	// Token: 0x04006223 RID: 25123
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected LoopScrollView<MapExploreDetailItem, ExploreAreaItemData> ExploreScroll;

	// Token: 0x04006224 RID: 25124
	[Nullable(2)]
	private PopupCaptionItem PopupCaption;

	// Token: 0x04006225 RID: 25125
	[Nullable(2)]
	private ExploreAreaItemData CurAreaItemData;

	// Token: 0x04006226 RID: 25126
	[Nullable(2)]
	private MapExplorePlayProgressPanel PlayProgressPanel;

	// Token: 0x04006227 RID: 25127
	[Nullable(2)]
	private ExploreDetailLockItem ExploreDetailLockItem;

	// Token: 0x04006228 RID: 25128
	private readonly ButtonItem ExploreTrackButton = new ButtonItem(null);

	// Token: 0x02007E7B RID: 32379
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402B159 RID: 176473
		ItemCaption,
		// Token: 0x0402B15A RID: 176474
		AreaChangeLeftBtn,
		// Token: 0x0402B15B RID: 176475
		AreaChangeRightBtn,
		// Token: 0x0402B15C RID: 176476
		ExploreScrollView,
		// Token: 0x0402B15D RID: 176477
		StoryBtn,
		// Token: 0x0402B15E RID: 176478
		AreaName,
		// Token: 0x0402B15F RID: 176479
		AreaBtn,
		// Token: 0x0402B160 RID: 176480
		StageReward,
		// Token: 0x0402B161 RID: 176481
		AreaPercent,
		// Token: 0x0402B162 RID: 176482
		AreaRedDot,
		// Token: 0x0402B163 RID: 176483
		AreaTaskBtn,
		// Token: 0x0402B164 RID: 176484
		ExploreItemBg,
		// Token: 0x0402B165 RID: 176485
		ExploreDesc,
		// Token: 0x0402B166 RID: 176486
		ExploreToolItem,
		// Token: 0x0402B167 RID: 176487
		ExploreToolDesc,
		// Token: 0x0402B168 RID: 176488
		ExploreToolTips,
		// Token: 0x0402B169 RID: 176489
		ExploreProgressBar,
		// Token: 0x0402B16A RID: 176490
		ExploreProgressBarDetailBtn,
		// Token: 0x0402B16B RID: 176491
		ExploreTrackBtn,
		// Token: 0x0402B16C RID: 176492
		ExploreProgressBarRoot,
		// Token: 0x0402B16D RID: 176493
		ExploreScrollItem,
		// Token: 0x0402B16E RID: 176494
		ExploreDetailRoot,
		// Token: 0x0402B16F RID: 176495
		ExploreDetailLockedRoot,
		// Token: 0x0402B170 RID: 176496
		ExploreDetailLockedDesc,
		// Token: 0x0402B171 RID: 176497
		ExploreDetailFinishedRoot,
		// Token: 0x0402B172 RID: 176498
		ExploreZero,
		// Token: 0x0402B173 RID: 176499
		StoryProgress,
		// Token: 0x0402B174 RID: 176500
		StoryRedDot,
		// Token: 0x0402B175 RID: 176501
		ExploreDetailLockRoot,
		// Token: 0x0402B176 RID: 176502
		ExploreDetailProgressImageRoot,
		// Token: 0x0402B177 RID: 176503
		PanelHighLightTips,
		// Token: 0x0402B178 RID: 176504
		TextHighLightTips
	}
}

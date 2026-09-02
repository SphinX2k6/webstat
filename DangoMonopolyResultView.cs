using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.NPC.Tuanzi;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012FB RID: 4859
[NullableContext(1)]
[Nullable(0)]
public class DangoMonopolyResultView : DangoMonopolyViewBase
{
	// Token: 0x17000B18 RID: 2840
	// (get) Token: 0x060083D7 RID: 33751 RVA: 0x0022D11D File Offset: 0x0022B31D
	[Nullable(2)]
	public new DangoMonopolyResultViewParams OpenParam
	{
		[NullableContext(2)]
		get
		{
			return this.OpenParam as DangoMonopolyResultViewParams;
		}
	}

	// Token: 0x060083D8 RID: 33752 RVA: 0x0022D12C File Offset: 0x0022B32C
	public DangoMonopolyResultView(UiViewInfo viewInfo) : base(viewInfo)
	{
		this.MoveInTime = (float)ConfigBase<ActivityDangoMonopolyConfig>.Instance.GetDangoMoveInTime();
		this.MoveOutTime = (float)ConfigBase<ActivityDangoMonopolyConfig>.Instance.GetDangoMoveOutTime();
		this.MoveOutDelayTime = (float)ConfigBase<ActivityDangoMonopolyConfig>.Instance.GetDangoMoveOutDelayTime();
		this.MoveChangeCheckTime = (float)ConfigBase<ActivityDangoMonopolyConfig>.Instance.GetDangoChangeCheckTime();
	}

	// Token: 0x060083D9 RID: 33753 RVA: 0x0022D1D8 File Offset: 0x0022B3D8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickClose))
		};
	}

	// Token: 0x060083DA RID: 33754 RVA: 0x0022D31E File Offset: 0x0022B51E
	private void InitDataParam()
	{
	}

	// Token: 0x060083DB RID: 33755 RVA: 0x0022D320 File Offset: 0x0022B520
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.DangoMonopolyEnterNextRound, new Action(this.EventEnterNextRound));
	}

	// Token: 0x060083DC RID: 33756 RVA: 0x0022D33E File Offset: 0x0022B53E
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.DangoMonopolyEnterNextRound, new Action(this.EventEnterNextRound));
	}

	// Token: 0x060083DD RID: 33757 RVA: 0x0022D35C File Offset: 0x0022B55C
	private void EventEnterNextRound()
	{
		this.ActivityData.UpdateBoardGridUiInfoShow(false).Forget();
	}

	// Token: 0x060083DE RID: 33758 RVA: 0x0022D370 File Offset: 0x0022B570
	protected override UniTask OnBeforeStartAsync()
	{
		DangoMonopolyResultView.<OnBeforeStartAsync>d__41 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoMonopolyResultView.<OnBeforeStartAsync>d__41>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060083DF RID: 33759 RVA: 0x0022D3B3 File Offset: 0x0022B5B3
	protected override void OnStart()
	{
		this.UpdateMoveParam();
		this.ActivityData.UpdateBoardGridUiInfoShow(false).Forget();
		this.InitCurve().Forget();
		this.UpdateData();
	}

	// Token: 0x060083E0 RID: 33760 RVA: 0x0022D3DD File Offset: 0x0022B5DD
	protected override void OnBeforeShow()
	{
		DangoMonopolyResultViewParams openParam = this.OpenParam;
		if (((openParam != null) ? openParam.ShowPromise : null) != null && this.OpenParam.ShowPromise.IsPending)
		{
			this.OpenParam.ShowPromise.SetResult();
		}
	}

	// Token: 0x060083E1 RID: 33761 RVA: 0x0022D415 File Offset: 0x0022B615
	protected override void OnAfterShow()
	{
	}

	// Token: 0x060083E2 RID: 33762 RVA: 0x0022D417 File Offset: 0x0022B617
	protected override void OnBeforeDestroy()
	{
		this.ActivityData.UpdateBoardGridUiInfoShow(true).Forget();
		this.DestroyDangoActor().Forget();
		DangoMonopolyResultViewParams openParam = this.OpenParam;
		if (openParam == null)
		{
			return;
		}
		CustomPromise closePromise = openParam.ClosePromise;
		if (closePromise == null)
		{
			return;
		}
		closePromise.SetResult();
	}

	// Token: 0x060083E3 RID: 33763 RVA: 0x0022D44F File Offset: 0x0022B64F
	private void OnClickClose()
	{
		if (this.ActivityData.IsShowRoundWelcome(false))
		{
			base.CloseMe(null);
			return;
		}
		this.ActivityData.OpenViewDangoMonopolyTransition(delegate
		{
			DangoMonopolyResultView.<<OnClickClose>b__46_0>d <<OnClickClose>b__46_0>d;
			<<OnClickClose>b__46_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnClickClose>b__46_0>d.<>4__this = this;
			<<OnClickClose>b__46_0>d.<>1__state = -1;
			<<OnClickClose>b__46_0>d.<>t__builder.Start<DangoMonopolyResultView.<<OnClickClose>b__46_0>d>(ref <<OnClickClose>b__46_0>d);
			return <<OnClickClose>b__46_0>d.<>t__builder.Task;
		});
	}

	// Token: 0x060083E4 RID: 33764 RVA: 0x0022D47E File Offset: 0x0022B67E
	private DangoMonopolyResultRoundItem CreateRoundItem()
	{
		return new DangoMonopolyResultRoundItem
		{
			ClickCallBack = new Action<DangoMonopolyBoardData>(this.OnClickRoundItem)
		};
	}

	// Token: 0x060083E5 RID: 33765 RVA: 0x0022D498 File Offset: 0x0022B698
	private void OnClickRoundItem(DangoMonopolyBoardData data)
	{
		this.LastBoardData = this.ShowBoardData;
		this.ShowBoardData = data;
		bool flag = this.ShowBoardData.IsFinish();
		List<RewardItemData> data2 = flag ? this.ShowBoardData.GetAllGridRewardItemList() : new List<RewardItemData>();
		GenericLayout<RewardSmallItemGrid, RewardItemData> rewardScrollView = this.RewardScrollView;
		if (rewardScrollView != null)
		{
			rewardScrollView.RefreshByData(data2, null, false);
		}
		UUIItem item = base.GetItem(10);
		if (item != null)
		{
			item.SetUIActive(!flag);
		}
		UUIItem item2 = base.GetItem(3);
		if (item2 != null)
		{
			item2.SetUIActive(flag);
		}
		if (flag)
		{
			UUIText text = base.GetText(4);
			string finishTitle = this.ShowBoardData.FinishTitle;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, finishTitle, new <>z__ReadOnlySingleElementList<object>(data.GetPosition()));
			UUIText text2 = base.GetText(5);
			string finishDesc = this.ShowBoardData.FinishDesc;
			List<IDangoMonopolyRoundBuffData> dangoBuffShowList = this.ShowBoardData.GetDangoBuffShowList();
			List<string> list = new List<string>();
			foreach (IDangoMonopolyRoundBuffData dangoMonopolyRoundBuffData in dangoBuffShowList)
			{
				list.Add(dangoMonopolyRoundBuffData.DangoName);
			}
			List<string> list2 = new List<string>();
			foreach (string text3 in list)
			{
				string item3 = ConfigMultiTextLang.GetLocalTextNew(text3, null) ?? text3;
				list2.Add(item3);
			}
			string item4 = this.ShowBoardData.RecordRollDiceTimes.ToString();
			string item5 = this.ShowBoardData.GetRecordTriggerBuffTotalTimes().ToString();
			List<object> list3 = new List<object>();
			foreach (string item6 in list2)
			{
				list3.Add(item6);
			}
			list3.Add(item4);
			list3.Add(item5);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, finishDesc, list3.ToArray());
		}
		else
		{
			UUIText text4 = base.GetText(11);
			if (text4 != null)
			{
				text4.ShowTextNew(this.GetEmptyTipsKey());
			}
		}
		if (this.LastBoardData == this.ShowBoardData)
		{
			this.LoadDangoActorList().Forget();
		}
		else
		{
			this.IsMoveChangeCheck = true;
			this.MoveChangeCheckDelta = 0f;
			this.LogMoveChangeCheck("Reset");
		}
		if (base.IsShow)
		{
			base.PlaySequence("Switch", null, false);
		}
	}

	// Token: 0x060083E6 RID: 33766 RVA: 0x0022D718 File Offset: 0x0022B918
	private string GetEmptyTipsKey()
	{
		DangoMonopolyBoardData showBoardData = this.ShowBoardData;
		if (showBoardData == null || !showBoardData.IsRunning())
		{
			return "DangoMonopoly_title_13";
		}
		DangoMonopolyBoardData showBoardData2 = this.ShowBoardData;
		if (showBoardData2 != null && showBoardData2.IsLock())
		{
			return "DangoMonopoly_title_17";
		}
		return "DangoMonopoly_title_12";
	}

	// Token: 0x060083E7 RID: 33767 RVA: 0x0022D753 File Offset: 0x0022B953
	private RewardSmallItemGrid CreateRewardItem()
	{
		RewardSmallItemGrid rewardSmallItemGrid = new RewardSmallItemGrid();
		rewardSmallItemGrid.BindOnCanExecuteChange((object _1, bool _2, EToggleState _3) => false);
		rewardSmallItemGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClickedRewardItem));
		return rewardSmallItemGrid;
	}

	// Token: 0x060083E8 RID: 33768 RVA: 0x0022D794 File Offset: 0x0022B994
	private void OnClickedRewardItem(MediumItemGridExtendCallback info)
	{
		RewardItemData rewardItemData = info.Data as RewardItemData;
		int itemId = (rewardItemData != null) ? rewardItemData.ConfigId : 0;
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemId, true, null);
	}

	// Token: 0x060083E9 RID: 33769 RVA: 0x0022D7C8 File Offset: 0x0022B9C8
	public void UpdateData()
	{
		DangoMonopolyResultViewParams openParam = this.OpenParam;
		int key = (openParam != null) ? openParam.BoardId : 1;
		DangoMonopolyBoardData showBoardData;
		if (!this.ActivityData.BoardMap.TryGetValue(key, out showBoardData))
		{
			showBoardData = null;
		}
		this.ShowBoardData = showBoardData;
		List<DangoMonopolyBoardData> data = this.ActivityData.BoardList ?? new List<DangoMonopolyBoardData>();
		LoopScrollView<DangoMonopolyResultRoundItem, DangoMonopolyBoardData> roundScrollView = this.RoundScrollView;
		if (roundScrollView != null)
		{
			roundScrollView.RefreshByData(data, false, delegate
			{
				LoopScrollView<DangoMonopolyResultRoundItem, DangoMonopolyBoardData> roundScrollView2 = this.RoundScrollView;
				if (roundScrollView2 != null)
				{
					roundScrollView2.DeselectCurrentGridProxy(false);
				}
				DangoMonopolyBoardData showBoardData2 = this.ShowBoardData;
				int gridIndex = (showBoardData2 != null) ? showBoardData2.Index : 0;
				LoopScrollView<DangoMonopolyResultRoundItem, DangoMonopolyBoardData> roundScrollView3 = this.RoundScrollView;
				if (roundScrollView3 != null)
				{
					roundScrollView3.ScrollToGridIndex(gridIndex, true);
				}
				LoopScrollView<DangoMonopolyResultRoundItem, DangoMonopolyBoardData> roundScrollView4 = this.RoundScrollView;
				if (roundScrollView4 == null)
				{
					return;
				}
				roundScrollView4.SelectGridProxy(gridIndex, false);
			}, false);
		}
		DangoMonopolyResultViewParams openParam2 = this.OpenParam;
		bool uiactive = openParam2 != null && openParam2.ShowType == EDangoMonopolyResultType.Record;
		UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(1);
		if (loopScrollViewComponent == null)
		{
			return;
		}
		loopScrollViewComponent.RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x060083EA RID: 33770 RVA: 0x0022D874 File Offset: 0x0022BA74
	public UniTask LoadDangoActorList()
	{
		DangoMonopolyResultView.<LoadDangoActorList>d__53 <LoadDangoActorList>d__;
		<LoadDangoActorList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadDangoActorList>d__.<>4__this = this;
		<LoadDangoActorList>d__.<>1__state = -1;
		<LoadDangoActorList>d__.<>t__builder.Start<DangoMonopolyResultView.<LoadDangoActorList>d__53>(ref <LoadDangoActorList>d__);
		return <LoadDangoActorList>d__.<>t__builder.Task;
	}

	// Token: 0x060083EB RID: 33771 RVA: 0x0022D8B8 File Offset: 0x0022BAB8
	[NullableContext(0)]
	public UniTask<bool> MoveDangoActorList()
	{
		DangoMonopolyResultView.<MoveDangoActorList>d__54 <MoveDangoActorList>d__;
		<MoveDangoActorList>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<MoveDangoActorList>d__.<>4__this = this;
		<MoveDangoActorList>d__.<>1__state = -1;
		<MoveDangoActorList>d__.<>t__builder.Start<DangoMonopolyResultView.<MoveDangoActorList>d__54>(ref <MoveDangoActorList>d__);
		return <MoveDangoActorList>d__.<>t__builder.Task;
	}

	// Token: 0x060083EC RID: 33772 RVA: 0x0022D8FC File Offset: 0x0022BAFC
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public UniTask<List<TsUiSceneDangoActor>> GetShowDangoActorList()
	{
		DangoMonopolyResultView.<GetShowDangoActorList>d__55 <GetShowDangoActorList>d__;
		<GetShowDangoActorList>d__.<>t__builder = AsyncUniTaskMethodBuilder<List<TsUiSceneDangoActor>>.Create();
		<GetShowDangoActorList>d__.<>4__this = this;
		<GetShowDangoActorList>d__.<>1__state = -1;
		<GetShowDangoActorList>d__.<>t__builder.Start<DangoMonopolyResultView.<GetShowDangoActorList>d__55>(ref <GetShowDangoActorList>d__);
		return <GetShowDangoActorList>d__.<>t__builder.Task;
	}

	// Token: 0x060083ED RID: 33773 RVA: 0x0022D940 File Offset: 0x0022BB40
	public void UpdateShowDangoIdList()
	{
		int dangoId = this.ActivityData.GetDangoId();
		List<int> list = new List<int>();
		if (this.ShowBoardData != null)
		{
			foreach (IDangoMonopolyRoundBuffData dangoMonopolyRoundBuffData in this.ShowBoardData.GetDangoBuffShowList())
			{
				list.Add(dangoMonopolyRoundBuffData.DangoId);
			}
			list.Reverse();
		}
		list.Add(dangoId);
		this.ShowDangoIdList = list.ToArray();
	}

	// Token: 0x060083EE RID: 33774 RVA: 0x0022D9D0 File Offset: 0x0022BBD0
	public void UpdateDangoFadeIn([Nullable(new byte[]
	{
		2,
		1
	})] List<TsUiSceneDangoActor> list = null)
	{
		foreach (TsUiSceneDangoActor roleActor in (list ?? this.ShowDangoActorList))
		{
			Singleton<UiModelUtil>.Instance.DangoFadeOut(roleActor, null, null);
		}
	}

	// Token: 0x060083EF RID: 33775 RVA: 0x0022DA38 File Offset: 0x0022BC38
	public void UpdateDangoFadeOut([Nullable(new byte[]
	{
		2,
		1
	})] List<TsUiSceneDangoActor> list = null)
	{
		foreach (TsUiSceneDangoActor actor in (list ?? this.LastDangoActorList))
		{
			Singleton<UiModelUtil>.Instance.DangoFadeIn(actor, null, null);
		}
	}

	// Token: 0x060083F0 RID: 33776 RVA: 0x0022DAA0 File Offset: 0x0022BCA0
	public UniTask MoveOutLastDangoList()
	{
		DangoMonopolyResultView.<MoveOutLastDangoList>d__59 <MoveOutLastDangoList>d__;
		<MoveOutLastDangoList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<MoveOutLastDangoList>d__.<>4__this = this;
		<MoveOutLastDangoList>d__.<>1__state = -1;
		<MoveOutLastDangoList>d__.<>t__builder.Start<DangoMonopolyResultView.<MoveOutLastDangoList>d__59>(ref <MoveOutLastDangoList>d__);
		return <MoveOutLastDangoList>d__.<>t__builder.Task;
	}

	// Token: 0x060083F1 RID: 33777 RVA: 0x0022DAE4 File Offset: 0x0022BCE4
	public UniTask MoveInShowDangoList()
	{
		DangoMonopolyResultView.<MoveInShowDangoList>d__60 <MoveInShowDangoList>d__;
		<MoveInShowDangoList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<MoveInShowDangoList>d__.<>4__this = this;
		<MoveInShowDangoList>d__.<>1__state = -1;
		<MoveInShowDangoList>d__.<>t__builder.Start<DangoMonopolyResultView.<MoveInShowDangoList>d__60>(ref <MoveInShowDangoList>d__);
		return <MoveInShowDangoList>d__.<>t__builder.Task;
	}

	// Token: 0x060083F2 RID: 33778 RVA: 0x0022DB28 File Offset: 0x0022BD28
	public void UpdateDangoAttach()
	{
		this.TempVec.Set(0.0, 0.0, 0.0);
		for (int i = 1; i < this.ShowDangoActorList.Count; i++)
		{
			TsUiSceneDangoActor tsUiSceneDangoActor = this.ShowDangoActorList[i];
			UiModelBase model = this.ShowDangoActorList[i - 1].Model;
			UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
			USkeletalMeshComponent uskeletalMeshComponent = (uiModelActorComponent != null) ? uiModelActorComponent.MainMeshComponent : null;
			if (uskeletalMeshComponent != null)
			{
				this.TempVec.Z = (double)Singleton<DangoManager>.Instance.GetDangoData(this.ShowDangoIdList[i - 1]).ModelHeight;
				EAttachmentRule eattachmentRule = EAttachmentRule.SnapToTarget;
				FName socketName = new FName("Root");
				tsUiSceneDangoActor.K2_AttachToComponent(uskeletalMeshComponent, socketName, eattachmentRule, eattachmentRule, eattachmentRule, false, true);
				FHitResult fhitResult = new FHitResult();
				tsUiSceneDangoActor.D_K2_AddActorLocalOffset(this.TempVec, true, ref fhitResult, false);
				tsUiSceneDangoActor.SetActorHiddenInGame(false);
			}
		}
		if (this.ShowDangoActorList.Count > 0)
		{
			TsUiSceneDangoActor tsUiSceneDangoActor2 = this.ShowDangoActorList[0];
			int num = 1000;
			this.TempVec.Set((double)num, (double)num, (double)num);
			FHitResult fhitResult2 = new FHitResult();
			tsUiSceneDangoActor2.D_K2_AddActorLocalOffset(this.TempVec, true, ref fhitResult2, false);
			tsUiSceneDangoActor2.SetActorHiddenInGame(false);
		}
	}

	// Token: 0x060083F3 RID: 33779 RVA: 0x0022DC64 File Offset: 0x0022BE64
	public UniTask DestroyDangoActor()
	{
		DangoMonopolyResultView.<DestroyDangoActor>d__62 <DestroyDangoActor>d__;
		<DestroyDangoActor>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<DestroyDangoActor>d__.<>4__this = this;
		<DestroyDangoActor>d__.<>1__state = -1;
		<DestroyDangoActor>d__.<>t__builder.Start<DangoMonopolyResultView.<DestroyDangoActor>d__62>(ref <DestroyDangoActor>d__);
		return <DestroyDangoActor>d__.<>t__builder.Task;
	}

	// Token: 0x060083F4 RID: 33780 RVA: 0x0022DCA8 File Offset: 0x0022BEA8
	public void UpdateMoveParam()
	{
		AActor actorWithTag = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName(this.ShowCase).Value, ECollectActorType.UI);
		if (actorWithTag != null)
		{
			FVectorDouble location = actorWithTag.D_GetTransform().GetLocation();
			this.ShowVec.Set(location.X, location.Y, location.Z);
		}
	}

	// Token: 0x060083F5 RID: 33781 RVA: 0x0022DD00 File Offset: 0x0022BF00
	public UniTask InitCurve()
	{
		DangoMonopolyResultView.<InitCurve>d__64 <InitCurve>d__;
		<InitCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCurve>d__.<>4__this = this;
		<InitCurve>d__.<>1__state = -1;
		<InitCurve>d__.<>t__builder.Start<DangoMonopolyResultView.<InitCurve>d__64>(ref <InitCurve>d__);
		return <InitCurve>d__.<>t__builder.Task;
	}

	// Token: 0x060083F6 RID: 33782 RVA: 0x0022DD44 File Offset: 0x0022BF44
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<UCurveFloat> LoadCurveFloat(string resId)
	{
		DangoMonopolyResultView.<LoadCurveFloat>d__65 <LoadCurveFloat>d__;
		<LoadCurveFloat>d__.<>t__builder = AsyncUniTaskMethodBuilder<UCurveFloat>.Create();
		<LoadCurveFloat>d__.resId = resId;
		<LoadCurveFloat>d__.<>1__state = -1;
		<LoadCurveFloat>d__.<>t__builder.Start<DangoMonopolyResultView.<LoadCurveFloat>d__65>(ref <LoadCurveFloat>d__);
		return <LoadCurveFloat>d__.<>t__builder.Task;
	}

	// Token: 0x060083F7 RID: 33783 RVA: 0x0022DD88 File Offset: 0x0022BF88
	[NullableContext(2)]
	public float GetTotalDistance(UCurveFloat curve)
	{
		if (curve == null)
		{
			return 0f;
		}
		int num = curve.FloatCurve.Keys.Num();
		if (num > 0)
		{
			FRichCurveKey frichCurveKey = curve.FloatCurve.Keys.Get(num - 1);
			return frichCurveKey.Time;
		}
		return 0f;
	}

	// Token: 0x060083F8 RID: 33784 RVA: 0x0022DDD4 File Offset: 0x0022BFD4
	[NullableContext(2)]
	public float GetTotalHeight(UCurveFloat curve)
	{
		if (curve == null)
		{
			return 0f;
		}
		if (curve.FloatCurve.Keys.Num() > 1)
		{
			FRichCurveKey frichCurveKey = curve.FloatCurve.Keys.Get(1);
			return frichCurveKey.Value;
		}
		return 0f;
	}

	// Token: 0x060083F9 RID: 33785 RVA: 0x0022DE1C File Offset: 0x0022C01C
	private void SetDangoMoveProgress(float percent, bool isIn, [Nullable(2)] UCurveFloat curve, List<TsUiSceneDangoActor> list)
	{
		float num = Singleton<MathUtils>.Instance.Clamp(percent, 0f, 1f);
		float totalDistance = this.GetTotalDistance(curve);
		float num2 = isIn ? (1f - num) : num;
		float num3 = totalDistance * num2;
		float num4 = (curve != null) ? curve.GetFloatValue(num3) : 0f;
		float num5 = isIn ? num3 : (-num3);
		if (list.Count > 0)
		{
			TsUiSceneDangoActor tsUiSceneDangoActor = list[0];
			this.TempVec.Set(this.ShowVec.X, (double)num5 + this.ShowVec.Y, (double)num4 + this.ShowVec.Z);
			FHitResult fhitResult = new FHitResult();
			if (tsUiSceneDangoActor != null)
			{
				tsUiSceneDangoActor.D_K2_SetActorLocation(this.TempVec, true, ref fhitResult, false);
			}
		}
		if (this.ShowLog)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Percent: ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(num2);
			string title = defaultInterpolatedStringHandler.ToStringAndClear();
			if (isIn)
			{
				this.LogMoveIn(title);
				return;
			}
			this.LogMoveOut(title);
		}
	}

	// Token: 0x060083FA RID: 33786 RVA: 0x0022DF19 File Offset: 0x0022C119
	public void SetDangoMoveInProgress(float percent)
	{
		this.SetDangoMoveProgress(percent, true, this.MoveInCurve, this.ShowDangoActorList);
	}

	// Token: 0x060083FB RID: 33787 RVA: 0x0022DF2F File Offset: 0x0022C12F
	public void SetDangoMoveOutProgress(float percent)
	{
		this.SetDangoMoveProgress(percent, false, this.MoveOutCurve, this.LastDangoActorList);
	}

	// Token: 0x060083FC RID: 33788 RVA: 0x0022DF45 File Offset: 0x0022C145
	protected override void OnBeforeShowImplementImplement()
	{
		Singleton<UiManager>.Instance.AddTickView(this);
	}

	// Token: 0x060083FD RID: 33789 RVA: 0x0022DF52 File Offset: 0x0022C152
	protected override void OnAfterHideImplementImplement()
	{
		Singleton<UiManager>.Instance.RemoveTickView(this);
		this.MoveInEnd();
		this.MoveOutEnd();
	}

	// Token: 0x060083FE RID: 33790 RVA: 0x0022DF6D File Offset: 0x0022C16D
	protected override void OnTick(float delta)
	{
		this.UpdateMoveInTick(delta);
		this.UpdateMoveOutTick(delta);
		this.UpdateMoveChangeCheckTick(delta);
	}

	// Token: 0x060083FF RID: 33791 RVA: 0x0022DF87 File Offset: 0x0022C187
	protected void OnAfterTick()
	{
	}

	// Token: 0x06008400 RID: 33792 RVA: 0x0022DF8C File Offset: 0x0022C18C
	public bool MoveInStart()
	{
		if (this.IsMovingIn)
		{
			return false;
		}
		this.IsMovingIn = true;
		this.MoveInDelta = 0f;
		this.MoveInPromise = new CustomPromise();
		this.SetActorListHidden(false, this.ShowDangoActorList);
		this.PlayJumpAni(this.ShowDangoActorList, this.MoveInCurve);
		return true;
	}

	// Token: 0x06008401 RID: 33793 RVA: 0x0022DFE0 File Offset: 0x0022C1E0
	public bool MoveOutStart()
	{
		if (this.IsMovingOut)
		{
			return false;
		}
		this.IsMovingOut = true;
		this.MoveOutDelta = 0f;
		this.MoveOutDelayDelta = 0f;
		this.MoveOutPromise = new CustomPromise();
		this.SetDangoMoveOutProgress(0f);
		this.SetActorListHidden(false, this.LastDangoActorList);
		this.PlayJumpAni(this.LastDangoActorList, this.MoveOutCurve);
		return true;
	}

	// Token: 0x06008402 RID: 33794 RVA: 0x0022E04A File Offset: 0x0022C24A
	public bool MoveInEnd()
	{
		if (!this.IsMovingIn)
		{
			return false;
		}
		this.LogMoveIn("MoveInEnd Before");
		this.ResetMoveInRecord();
		this.LogMoveIn("MoveInEnd After");
		return true;
	}

	// Token: 0x06008403 RID: 33795 RVA: 0x0022E074 File Offset: 0x0022C274
	public bool MoveOutEnd()
	{
		if (!this.IsMovingOut)
		{
			return false;
		}
		this.LogMoveOut("MoveOutEnd Before");
		this.ReturnStand(this.LastDangoActorList, "MoveOutEnd");
		this.SetActorListHidden(true, this.LastDangoActorList);
		this.ResetMoveOutRecord();
		this.LogMoveOut("MoveOutEnd After");
		return true;
	}

	// Token: 0x06008404 RID: 33796 RVA: 0x0022E0C8 File Offset: 0x0022C2C8
	public bool UpdateMoveInTick(float delta)
	{
		if (!this.IsMovingIn)
		{
			return false;
		}
		if (this.MoveInDelta >= this.MoveInTime)
		{
			this.MoveInEnd();
			return true;
		}
		this.MoveInDelta += delta;
		float dangoMoveInProgress = this.MoveInDelta / this.MoveInTime;
		this.SetDangoMoveInProgress(dangoMoveInProgress);
		return true;
	}

	// Token: 0x06008405 RID: 33797 RVA: 0x0022E11C File Offset: 0x0022C31C
	public bool UpdateMoveOutTick(float delta)
	{
		if (!this.IsMovingOut)
		{
			return false;
		}
		if (this.UpdateMoveOutDelayTick(delta))
		{
			return true;
		}
		if (this.MoveOutDelta >= this.MoveOutTime)
		{
			this.MoveOutEnd();
			return true;
		}
		this.MoveOutDelta += delta;
		float dangoMoveOutProgress = this.MoveOutDelta / this.MoveOutTime;
		this.SetDangoMoveOutProgress(dangoMoveOutProgress);
		return true;
	}

	// Token: 0x06008406 RID: 33798 RVA: 0x0022E179 File Offset: 0x0022C379
	public bool UpdateMoveOutDelayTick(float delta)
	{
		if (!this.IsMovingOut)
		{
			return false;
		}
		if (this.MoveOutDelayDelta >= this.MoveOutDelayTime)
		{
			return false;
		}
		this.MoveOutDelayDelta += delta;
		return true;
	}

	// Token: 0x06008407 RID: 33799 RVA: 0x0022E1A4 File Offset: 0x0022C3A4
	public void ResetMoveInRecord()
	{
		this.IsMovingIn = false;
		this.MoveInDelta = 0f;
		CustomPromise moveInPromise = this.MoveInPromise;
		if (moveInPromise == null)
		{
			return;
		}
		moveInPromise.SetResult();
	}

	// Token: 0x06008408 RID: 33800 RVA: 0x0022E1C8 File Offset: 0x0022C3C8
	public void ResetMoveOutRecord()
	{
		this.IsMovingOut = false;
		this.MoveOutDelta = 0f;
		this.MoveOutDelayDelta = 0f;
		CustomPromise moveOutPromise = this.MoveOutPromise;
		if (moveOutPromise == null)
		{
			return;
		}
		moveOutPromise.SetResult();
	}

	// Token: 0x06008409 RID: 33801 RVA: 0x0022E1F8 File Offset: 0x0022C3F8
	public void SetActorListHidden(bool hide, List<TsUiSceneDangoActor> list)
	{
		foreach (TsUiSceneDangoActor tsUiSceneDangoActor in list)
		{
			tsUiSceneDangoActor.SetActorHiddenInGame(hide);
		}
	}

	// Token: 0x0600840A RID: 33802 RVA: 0x0022E244 File Offset: 0x0022C444
	public bool UpdateMoveChangeCheckTick(float delta)
	{
		if (!this.IsMoveChangeCheck)
		{
			return false;
		}
		if (this.MoveChangeCheckDelta >= this.MoveChangeCheckTime)
		{
			this.LogMoveChangeCheck("TickEnd");
			this.IsMoveChangeCheck = false;
			this.MoveChangeCheckDelta = 0f;
			this.LoadDangoActorList().Forget();
			return true;
		}
		this.MoveChangeCheckDelta += delta;
		return true;
	}

	// Token: 0x0600840B RID: 33803 RVA: 0x0022E2A4 File Offset: 0x0022C4A4
	public void PlayJumpAni(List<TsUiSceneDangoActor> list, [Nullable(2)] UCurveFloat curve)
	{
		float totalDistance = this.GetTotalDistance(curve);
		float totalHeight = this.GetTotalHeight(curve);
		this.PlayJumpAniParam(list, totalDistance, totalHeight);
	}

	// Token: 0x0600840C RID: 33804 RVA: 0x0022E2CC File Offset: 0x0022C4CC
	public void PlayJumpAniParam(List<TsUiSceneDangoActor> list, float dis = 0f, float height = 0f)
	{
		foreach (TsUiSceneDangoActor tsUiSceneDangoActor in list)
		{
			this.LogDangoAniState(tsUiSceneDangoActor, "Set Jump Before");
			tsUiSceneDangoActor.SetState(EDangoState.MoveJump, dis, height);
			this.LogDangoAniState(tsUiSceneDangoActor, "Set Jump After");
		}
	}

	// Token: 0x0600840D RID: 33805 RVA: 0x0022E334 File Offset: 0x0022C534
	public void ReturnStand(List<TsUiSceneDangoActor> list, string title = "")
	{
		foreach (TsUiSceneDangoActor tsUiSceneDangoActor in list)
		{
			UiDangoStateMachineComponent stateMachine = tsUiSceneDangoActor.GetStateMachine();
			if (stateMachine != null)
			{
				ABP_TuanziNPC_C dangoBp = stateMachine.GetDangoBp();
				if (dangoBp != null)
				{
					dangoBp.ReturnStand();
				}
			}
			this.LogDangoAniState(tsUiSceneDangoActor, title);
		}
	}

	// Token: 0x0600840E RID: 33806 RVA: 0x0022E3A0 File Offset: 0x0022C5A0
	public void LogDangoAniState(TsUiSceneDangoActor actor, string title = "")
	{
		UiDangoStateMachineComponent stateMachine = actor.GetStateMachine();
		if (stateMachine == null)
		{
			return;
		}
		ABP_TuanziNPC_C dangoBp = stateMachine.GetDangoBp();
		if (dangoBp == null)
		{
			return;
		}
		TEnumAsByte<EDangoState> currentState = dangoBp.CurrentState;
	}

	// Token: 0x0600840F RID: 33807 RVA: 0x0022E3BD File Offset: 0x0022C5BD
	public void LogMoveIn(string title)
	{
	}

	// Token: 0x06008410 RID: 33808 RVA: 0x0022E3BF File Offset: 0x0022C5BF
	public void LogMoveOut(string title)
	{
	}

	// Token: 0x06008411 RID: 33809 RVA: 0x0022E3C1 File Offset: 0x0022C5C1
	public void LogMoveChangeCheck(string title)
	{
	}

	// Token: 0x06008412 RID: 33810 RVA: 0x0022E3C4 File Offset: 0x0022C5C4
	public void LogInfo()
	{
		string title = "Sum";
		this.LogMoveIn(title);
		this.LogMoveOut(title);
		this.LogMoveChangeCheck(title);
		this.LogMovingProcessState(title);
	}

	// Token: 0x06008413 RID: 33811 RVA: 0x0022E3F3 File Offset: 0x0022C5F3
	public void LogMovingProcessState(string title)
	{
	}

	// Token: 0x04003E9B RID: 16027
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public LoopScrollView<DangoMonopolyResultRoundItem, DangoMonopolyBoardData> RoundScrollView;

	// Token: 0x04003E9C RID: 16028
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public GenericLayout<RewardSmallItemGrid, RewardItemData> RewardScrollView;

	// Token: 0x04003E9D RID: 16029
	[Nullable(2)]
	public DangoMonopolyBoardData ShowBoardData;

	// Token: 0x04003E9E RID: 16030
	[Nullable(2)]
	public DangoMonopolyBoardData LastBoardData;

	// Token: 0x04003E9F RID: 16031
	public List<TsUiSceneDangoActor> ShowDangoActorList = new List<TsUiSceneDangoActor>();

	// Token: 0x04003EA0 RID: 16032
	public List<TsUiSceneDangoActor> LastDangoActorList = new List<TsUiSceneDangoActor>();

	// Token: 0x04003EA1 RID: 16033
	public Dictionary<int, List<TsUiSceneDangoActor>> DangoActorListMap = new Dictionary<int, List<TsUiSceneDangoActor>>();

	// Token: 0x04003EA2 RID: 16034
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public UniTaskCompletionSource<List<TsUiSceneDangoActor>> DangoActorPromise;

	// Token: 0x04003EA3 RID: 16035
	public int[] ShowDangoIdList;

	// Token: 0x04003EA4 RID: 16036
	[Nullable(2)]
	public CustomPromise MoveDangoPromise;

	// Token: 0x04003EA5 RID: 16037
	public readonly float MoveInTime;

	// Token: 0x04003EA6 RID: 16038
	public readonly float MoveOutTime;

	// Token: 0x04003EA7 RID: 16039
	public readonly float MoveOutDelayTime;

	// Token: 0x04003EA8 RID: 16040
	public readonly float MoveChangeCheckTime;

	// Token: 0x04003EA9 RID: 16041
	[Nullable(2)]
	public UCurveFloat MoveInCurve;

	// Token: 0x04003EAA RID: 16042
	[Nullable(2)]
	public UCurveFloat MoveOutCurve;

	// Token: 0x04003EAB RID: 16043
	public FVectorDouble TempVec = new FVectorDouble(0.0);

	// Token: 0x04003EAC RID: 16044
	public FVectorDouble ShowVec = new FVectorDouble(0.0);

	// Token: 0x04003EAD RID: 16045
	public readonly string ShowCase = "DangoMonopolyCase";

	// Token: 0x04003EAE RID: 16046
	public bool IsMovingIn;

	// Token: 0x04003EAF RID: 16047
	public bool IsMovingOut;

	// Token: 0x04003EB0 RID: 16048
	public bool IsMoveChangeCheck;

	// Token: 0x04003EB1 RID: 16049
	public float MoveInDelta;

	// Token: 0x04003EB2 RID: 16050
	public float MoveOutDelta;

	// Token: 0x04003EB3 RID: 16051
	public float MoveOutDelayDelta;

	// Token: 0x04003EB4 RID: 16052
	public float MoveChangeCheckDelta;

	// Token: 0x04003EB5 RID: 16053
	[Nullable(2)]
	public CustomPromise MoveInPromise;

	// Token: 0x04003EB6 RID: 16054
	[Nullable(2)]
	public CustomPromise MoveOutPromise;

	// Token: 0x04003EB7 RID: 16055
	public bool ShowLog;

	// Token: 0x04003EB8 RID: 16056
	public int LastChangeId;

	// Token: 0x04003EB9 RID: 16057
	public int ShowChangeId;

	// Token: 0x04003EBA RID: 16058
	public bool IsMovingChange;

	// Token: 0x0200768F RID: 30351
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04028D9C RID: 167324
		BtnClose,
		// Token: 0x04028D9D RID: 167325
		LoopScrollRoundList,
		// Token: 0x04028D9E RID: 167326
		ItemRound,
		// Token: 0x04028D9F RID: 167327
		ItemRight,
		// Token: 0x04028DA0 RID: 167328
		TxtTitle,
		// Token: 0x04028DA1 RID: 167329
		TxtDesc,
		// Token: 0x04028DA2 RID: 167330
		GridLayoutRewardList,
		// Token: 0x04028DA3 RID: 167331
		ItemReward,
		// Token: 0x04028DA4 RID: 167332
		TxtTips,
		// Token: 0x04028DA5 RID: 167333
		BtnEmpty,
		// Token: 0x04028DA6 RID: 167334
		ItemRewardEmpty,
		// Token: 0x04028DA7 RID: 167335
		TxtEmptyTips
	}
}

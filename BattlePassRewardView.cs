using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002385 RID: 9093
public class BattlePassRewardView : UiTabViewBase
{
	// Token: 0x060116CE RID: 71374 RVA: 0x004CDB00 File Offset: 0x004CBD00
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickPayBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickWeapon));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060116CF RID: 71375 RVA: 0x004CDC70 File Offset: 0x004CBE70
	private void OnClickPayBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BattlePassPayView, this.ExtraParams, null);
		ModelBase<BattlePassModel>.Instance.PayButtonRedDotState = false;
		OnBattlePassOperationLogEvent onBattlePassOperationLogEvent = new OnBattlePassOperationLogEvent();
		onBattlePassOperationLogEvent.i_operation_type = 1;
		ControllerBase<LogReportController>.Instance.LogReport(onBattlePassOperationLogEvent);
	}

	// Token: 0x060116D0 RID: 71376 RVA: 0x004CDCB8 File Offset: 0x004CBEB8
	private void OnClickWeapon()
	{
		WeaponPreviewViewParam param = new WeaponPreviewViewParam
		{
			WeaponDataList = ModelBase<BattlePassModel>.Instance.GetWeaponDataList().ToArray(),
			SelectedIndex = 0,
			WeaponObservers = (WeaponSkeletalObserverHandles)this.ExtraParams
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponPreviewView, param, null);
	}

	// Token: 0x060116D1 RID: 71377 RVA: 0x004CDD0C File Offset: 0x004CBF0C
	protected override UniTask OnBeforeStartAsync()
	{
		BattlePassRewardView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BattlePassRewardView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060116D2 RID: 71378 RVA: 0x004CDD50 File Offset: 0x004CBF50
	protected override void OnStart()
	{
		this.StartAnime = true;
		base.GetItem(2).SetUIActive(ModelBase<BattlePassModel>.Instance.PayType == BattlePassPayStatus.NoPaid);
		this.LoopScrollView = new LoopScrollView<BattlePassRewardGridItem, BattlePassRewardData>(base.GetLoopScrollViewComponent(3), (AUIBaseActor)base.GetItem(5).GetOwner(), new Func<BattlePassRewardGridItem>(this.CreateLoopItem), false);
		this.LoopScrollView.BindOnScrollValueChanged(new Action<FVector2D>(this.RefreshStageReward));
		this.LoopScrollView.BindLateUpdate(new Action<float>(this.RewardScrollToShowLevel));
	}

	// Token: 0x060116D3 RID: 71379 RVA: 0x004CDDDB File Offset: 0x004CBFDB
	protected override void OnBeforeShow()
	{
		this.RefreshScrollView();
	}

	// Token: 0x060116D4 RID: 71380 RVA: 0x004CDDE4 File Offset: 0x004CBFE4
	protected override void OnAfterShow()
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence != null)
		{
			uiViewSequence.PlaySequence(this.StartAnime ? "Start" : "Switch", false, null);
		}
		this.StartAnime = false;
	}

	// Token: 0x060116D5 RID: 71381 RVA: 0x004CDE27 File Offset: 0x004CC027
	[NullableContext(1)]
	private BattlePassRewardGridItem CreateLoopItem()
	{
		return new BattlePassRewardGridItem();
	}

	// Token: 0x060116D6 RID: 71382 RVA: 0x004CDE30 File Offset: 0x004CC030
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int?>(EEventName.GetBattlePassRewardEvent, new Action<int?>(this.OnGetRewardUpdateView));
		Singleton<EventSystem>.Instance.Add(EEventName.ReceiveBattlePassDataEvent, new Action(this.RefreshScrollView));
		Singleton<EventSystem>.Instance.Add(EEventName.BattlePassFirstUnlockAnime, new Action(this.OnBattlePassFirstUnlockAnime));
	}

	// Token: 0x060116D7 RID: 71383 RVA: 0x004CDE94 File Offset: 0x004CC094
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.GetBattlePassRewardEvent, new Action<int?>(this.OnGetRewardUpdateView));
		Singleton<EventSystem>.Instance.Remove(EEventName.ReceiveBattlePassDataEvent, new Action(this.RefreshScrollView));
		Singleton<EventSystem>.Instance.Remove(EEventName.BattlePassFirstUnlockAnime, new Action(this.OnBattlePassFirstUnlockAnime));
	}

	// Token: 0x060116D8 RID: 71384 RVA: 0x004CDEF5 File Offset: 0x004CC0F5
	private void OnBattlePassFirstUnlockAnime()
	{
		base.GetItem(2).SetUIActive(ModelBase<BattlePassModel>.Instance.PayType == BattlePassPayStatus.NoPaid);
	}

	// Token: 0x060116D9 RID: 71385 RVA: 0x004CDF10 File Offset: 0x004CC110
	private void RewardScrollToShowLevel(float _)
	{
		if (this.NeedLateUpdate)
		{
			this.NeedLateUpdate = false;
			int currentShowLevel = ModelBase<BattlePassModel>.Instance.GetCurrentShowLevel();
			this.LoopScrollView.ScrollToGridIndex(currentShowLevel - 1, true);
		}
	}

	// Token: 0x060116DA RID: 71386 RVA: 0x004CDF48 File Offset: 0x004CC148
	private void OnGetRewardUpdateView(int? gridIndex)
	{
		if (gridIndex == null)
		{
			this.LoopScrollView.RefreshAllGridProxies();
		}
		else
		{
			this.LoopScrollView.RefreshGridProxy(gridIndex.Value);
		}
		this.RefreshStageReward(default(FVector2D));
		this.RefreshStageRewardState();
	}

	// Token: 0x060116DB RID: 71387 RVA: 0x004CDF94 File Offset: 0x004CC194
	private void RefreshScrollView()
	{
		this.NeedLateUpdate = true;
		this.LoopScrollView.RefreshByData(ModelBase<BattlePassModel>.Instance.RewardDataList, false, null, false);
		this.RefreshStageReward(default(FVector2D));
		this.RefreshStageRewardState();
	}

	// Token: 0x060116DC RID: 71388 RVA: 0x004CDFD8 File Offset: 0x004CC1D8
	private void RefreshStageReward(FVector2D _)
	{
		int endGridIndex = this.LoopScrollView.EndGridIndex;
		BattlePassRewardData battlePassRewardData = this.LoopScrollView.TryGetCachedData(endGridIndex);
		if (battlePassRewardData != null)
		{
			int currentLevel = battlePassRewardData.Level.Value - 1;
			int nextStageLevel = ModelBase<BattlePassModel>.Instance.GetNextStageLevel(currentLevel);
			if (nextStageLevel != 0 && this.StageRewardView.GetGirdLevel() != nextStageLevel)
			{
				this.StageRewardView.Refresh(ModelBase<BattlePassModel>.Instance.GetRewardData(nextStageLevel), false, 0);
			}
		}
	}

	// Token: 0x060116DD RID: 71389 RVA: 0x004CE044 File Offset: 0x004CC244
	private void RefreshStageRewardState()
	{
		int girdLevel = this.StageRewardView.GetGirdLevel();
		if (girdLevel > 0)
		{
			this.StageRewardView.Refresh(ModelBase<BattlePassModel>.Instance.GetRewardData(girdLevel), false, 0);
		}
	}

	// Token: 0x060116DE RID: 71390 RVA: 0x004CE079 File Offset: 0x004CC279
	protected override void OnBeforeDestroy()
	{
		if (this.LoopScrollView != null)
		{
			this.LoopScrollView.ClearGridProxies();
			this.LoopScrollView = null;
		}
	}

	// Token: 0x040088C8 RID: 35016
	private bool NeedLateUpdate;

	// Token: 0x040088C9 RID: 35017
	private bool StartAnime;

	// Token: 0x040088CA RID: 35018
	[Nullable(2)]
	private BattlePassBackgroundPanel BackgroundPanel;

	// Token: 0x040088CB RID: 35019
	[Nullable(2)]
	private BattlePassRewardGridItem StageRewardView;

	// Token: 0x040088CC RID: 35020
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<BattlePassRewardGridItem, BattlePassRewardData> LoopScrollView;

	// Token: 0x020086A0 RID: 34464
	private enum EReportOperation
	{
		// Token: 0x0402D892 RID: 186514
		BuyLevelBtn,
		// Token: 0x0402D893 RID: 186515
		BuyPassBtn
	}

	// Token: 0x020086A1 RID: 34465
	private enum EComponents
	{
		// Token: 0x0402D895 RID: 186517
		BattlePassBackground,
		// Token: 0x0402D896 RID: 186518
		BtnPay,
		// Token: 0x0402D897 RID: 186519
		ImgUnlock,
		// Token: 0x0402D898 RID: 186520
		RewardLoopScroll,
		// Token: 0x0402D899 RID: 186521
		StateRewardItem,
		// Token: 0x0402D89A RID: 186522
		RewardItem,
		// Token: 0x0402D89B RID: 186523
		BtnWeapon
	}
}

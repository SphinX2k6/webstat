using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C65 RID: 7269
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchPopupRewardPanel : UiPanelBase
{
	// Token: 0x0600D42B RID: 54315 RVA: 0x003896EC File Offset: 0x003878EC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D42C RID: 54316 RVA: 0x00389758 File Offset: 0x00387958
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchPopupRewardPanel.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchPopupRewardPanel.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D42D RID: 54317 RVA: 0x0038979B File Offset: 0x0038799B
	protected override void OnStart()
	{
		this.TemplateRewardItem = base.GetItem(1);
		this.TemplateRewardItem.SetUIActive(false);
	}

	// Token: 0x0600D42E RID: 54318 RVA: 0x003897B6 File Offset: 0x003879B6
	protected override void OnBeforeShow()
	{
		this.TimerHandle = ModelBase<FloroRanchGamePlayModel>.Instance.FloroRanchTimerSystem.Forever(new TTimerAction(this.OnTick), 20f, 1f, null, null, true);
	}

	// Token: 0x0600D42F RID: 54319 RVA: 0x003897E8 File Offset: 0x003879E8
	private void OnTick(float deltaTime)
	{
		foreach (FloroRanchPopupRewardItem floroRanchPopupRewardItem in this.RewardItemSet)
		{
			floroRanchPopupRewardItem.Tick(deltaTime);
		}
	}

	// Token: 0x0600D430 RID: 54320 RVA: 0x0038983C File Offset: 0x00387A3C
	protected override void OnBeforeHide()
	{
		if (this.TimerHandle != null)
		{
			ModelBase<FloroRanchGamePlayModel>.Instance.FloroRanchTimerSystem.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x0600D431 RID: 54321 RVA: 0x00389864 File Offset: 0x00387A64
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<FloroRanchPopupRewardItem> GetRewardItem()
	{
		FloroRanchPopupRewardPanel.<GetRewardItem>d__15 <GetRewardItem>d__;
		<GetRewardItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<FloroRanchPopupRewardItem>.Create();
		<GetRewardItem>d__.<>4__this = this;
		<GetRewardItem>d__.<>1__state = -1;
		<GetRewardItem>d__.<>t__builder.Start<FloroRanchPopupRewardPanel.<GetRewardItem>d__15>(ref <GetRewardItem>d__);
		return <GetRewardItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D432 RID: 54322 RVA: 0x003898A7 File Offset: 0x00387AA7
	private void RecycleRewardItem(FloroRanchPopupRewardItem item)
	{
		this.RewardItemSet.Remove(item);
		this.RewardItemPool.Add(item);
	}

	// Token: 0x0600D433 RID: 54323 RVA: 0x003898C2 File Offset: 0x00387AC2
	public void BindCoinTargetPos(FVector vector)
	{
		this.CoinTargetPos = Vector.Create((double)vector.X, (double)vector.Y, (double)vector.Z);
	}

	// Token: 0x0600D434 RID: 54324 RVA: 0x003898E4 File Offset: 0x00387AE4
	public void BindCoinChangeCallBack(Action<long> callback)
	{
		this.CoinChangeCallBack = callback;
	}

	// Token: 0x0600D435 RID: 54325 RVA: 0x003898ED File Offset: 0x00387AED
	public void BindDiamondChangeCallBack(Action<long> callback)
	{
		this.DiamondChangeCallBack = callback;
	}

	// Token: 0x0600D436 RID: 54326 RVA: 0x003898F8 File Offset: 0x00387AF8
	public UniTask ShowPopupReward(FloroRanchUiItemBase item, EFloroRanchPopupRewardType rewardType, long count)
	{
		FloroRanchPopupRewardPanel.<ShowPopupReward>d__20 <ShowPopupReward>d__;
		<ShowPopupReward>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowPopupReward>d__.<>4__this = this;
		<ShowPopupReward>d__.item = item;
		<ShowPopupReward>d__.rewardType = rewardType;
		<ShowPopupReward>d__.count = count;
		<ShowPopupReward>d__.<>1__state = -1;
		<ShowPopupReward>d__.<>t__builder.Start<FloroRanchPopupRewardPanel.<ShowPopupReward>d__20>(ref <ShowPopupReward>d__);
		return <ShowPopupReward>d__.<>t__builder.Task;
	}

	// Token: 0x0600D437 RID: 54327 RVA: 0x00389954 File Offset: 0x00387B54
	private UniTask ShowCoinReward(Vector startPoint, FloroRanchPopupRewardItem rewardItem, long count)
	{
		FloroRanchPopupRewardPanel.<ShowCoinReward>d__21 <ShowCoinReward>d__;
		<ShowCoinReward>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowCoinReward>d__.<>4__this = this;
		<ShowCoinReward>d__.startPoint = startPoint;
		<ShowCoinReward>d__.rewardItem = rewardItem;
		<ShowCoinReward>d__.count = count;
		<ShowCoinReward>d__.<>1__state = -1;
		<ShowCoinReward>d__.<>t__builder.Start<FloroRanchPopupRewardPanel.<ShowCoinReward>d__21>(ref <ShowCoinReward>d__);
		return <ShowCoinReward>d__.<>t__builder.Task;
	}

	// Token: 0x0600D438 RID: 54328 RVA: 0x003899B0 File Offset: 0x00387BB0
	private UniTask ShowDiamondReward(Vector startPoint, FloroRanchPopupRewardItem rewardItem, long count)
	{
		FloroRanchPopupRewardPanel.<ShowDiamondReward>d__22 <ShowDiamondReward>d__;
		<ShowDiamondReward>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowDiamondReward>d__.<>4__this = this;
		<ShowDiamondReward>d__.startPoint = startPoint;
		<ShowDiamondReward>d__.rewardItem = rewardItem;
		<ShowDiamondReward>d__.count = count;
		<ShowDiamondReward>d__.<>1__state = -1;
		<ShowDiamondReward>d__.<>t__builder.Start<FloroRanchPopupRewardPanel.<ShowDiamondReward>d__22>(ref <ShowDiamondReward>d__);
		return <ShowDiamondReward>d__.<>t__builder.Task;
	}

	// Token: 0x0600D439 RID: 54329 RVA: 0x00389A0C File Offset: 0x00387C0C
	private UniTask ShowSalaryReward(Vector startPoint, FloroRanchPopupRewardItem rewardItem, long count)
	{
		FloroRanchPopupRewardPanel.<ShowSalaryReward>d__23 <ShowSalaryReward>d__;
		<ShowSalaryReward>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowSalaryReward>d__.<>4__this = this;
		<ShowSalaryReward>d__.startPoint = startPoint;
		<ShowSalaryReward>d__.rewardItem = rewardItem;
		<ShowSalaryReward>d__.count = count;
		<ShowSalaryReward>d__.<>1__state = -1;
		<ShowSalaryReward>d__.<>t__builder.Start<FloroRanchPopupRewardPanel.<ShowSalaryReward>d__23>(ref <ShowSalaryReward>d__);
		return <ShowSalaryReward>d__.<>t__builder.Task;
	}

	// Token: 0x040064F4 RID: 25844
	[Nullable(2)]
	private Vector CoinTargetPos;

	// Token: 0x040064F5 RID: 25845
	private readonly HashSet<FloroRanchPopupRewardItem> RewardItemSet = new HashSet<FloroRanchPopupRewardItem>();

	// Token: 0x040064F6 RID: 25846
	private readonly List<FloroRanchPopupRewardItem> RewardItemPool = new List<FloroRanchPopupRewardItem>();

	// Token: 0x040064F7 RID: 25847
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x040064F8 RID: 25848
	private UCurveFloat LerpCurve;

	// Token: 0x040064F9 RID: 25849
	[Nullable(2)]
	private UUIItem TemplateRewardItem;

	// Token: 0x040064FA RID: 25850
	private Action<long> CoinChangeCallBack;

	// Token: 0x040064FB RID: 25851
	private Action<long> DiamondChangeCallBack;

	// Token: 0x02007F84 RID: 32644
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402B69B RID: 177819
		public const int RewardRoot = 0;

		// Token: 0x0402B69C RID: 177820
		public const int RewardTemplate = 1;
	}
}

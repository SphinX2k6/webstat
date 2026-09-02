using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001CB8 RID: 7352
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class GachaAccumulateController : UiControllerBase<GachaAccumulateController>
{
	// Token: 0x0600D7CB RID: 55243 RVA: 0x0039B305 File Offset: 0x00399505
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0600D7CC RID: 55244 RVA: 0x0039B308 File Offset: 0x00399508
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnOpenGachaChanged, new Action(this.OnOpenGachaChanged));
	}

	// Token: 0x0600D7CD RID: 55245 RVA: 0x0039B326 File Offset: 0x00399526
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnOpenGachaChanged, new Action(this.OnOpenGachaChanged));
	}

	// Token: 0x0600D7CE RID: 55246 RVA: 0x0039B344 File Offset: 0x00399544
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<GachaAccumulateInfoNotify>(ENotifyMessageId.GachaAccumulateInfoNotify, new Action<GachaAccumulateInfoNotify, Net.CallbackStatus>(this.OnGachaAccumulateInfoNotify));
	}

	// Token: 0x0600D7CF RID: 55247 RVA: 0x0039B362 File Offset: 0x00399562
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.GachaAccumulateInfoNotify);
	}

	// Token: 0x0600D7D0 RID: 55248 RVA: 0x0039B374 File Offset: 0x00399574
	private void OnOpenGachaChanged()
	{
		this.OnOpenGachaChangedAsync().Forget();
	}

	// Token: 0x0600D7D1 RID: 55249 RVA: 0x0039B384 File Offset: 0x00399584
	private UniTask OnOpenGachaChangedAsync()
	{
		GachaAccumulateController.<OnOpenGachaChangedAsync>d__6 <OnOpenGachaChangedAsync>d__;
		<OnOpenGachaChangedAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnOpenGachaChangedAsync>d__.<>4__this = this;
		<OnOpenGachaChangedAsync>d__.<>1__state = -1;
		<OnOpenGachaChangedAsync>d__.<>t__builder.Start<GachaAccumulateController.<OnOpenGachaChangedAsync>d__6>(ref <OnOpenGachaChangedAsync>d__);
		return <OnOpenGachaChangedAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D7D2 RID: 55250 RVA: 0x0039B3C8 File Offset: 0x003995C8
	[NullableContext(1)]
	private void OnGachaAccumulateInfoNotify(GachaAccumulateInfoNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		GachaAccumulateInfo gachaAccumulateInfo = message.GachaAccumulateInfo;
		if (gachaAccumulateInfo == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Gacha, ELogAuthor.YZY, "[GachaAccumulateController] Notify 中 GachaAccumulateInfo 为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ModelBase<GachaAccumulateModel>.Instance.UpdateAccumulateInfo(gachaAccumulateInfo);
		Singleton<EventSystem>.Instance.Emit(EEventName.GachaAccumulateRedDot);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.GachaAccumulateDataUpdate, gachaAccumulateInfo.GachaAccumulateId);
	}

	// Token: 0x0600D7D3 RID: 55251 RVA: 0x0039B430 File Offset: 0x00399630
	public UniTask RequestAccumulateInfoAsync(int accumulateId)
	{
		GachaAccumulateController.<RequestAccumulateInfoAsync>d__8 <RequestAccumulateInfoAsync>d__;
		<RequestAccumulateInfoAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestAccumulateInfoAsync>d__.accumulateId = accumulateId;
		<RequestAccumulateInfoAsync>d__.<>1__state = -1;
		<RequestAccumulateInfoAsync>d__.<>t__builder.Start<GachaAccumulateController.<RequestAccumulateInfoAsync>d__8>(ref <RequestAccumulateInfoAsync>d__);
		return <RequestAccumulateInfoAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D7D4 RID: 55252 RVA: 0x0039B474 File Offset: 0x00399674
	public UniTask<bool> ClaimAccumulateRewardAsync(int accumulateId, [Nullable(1)] int[] rewardIds, [Nullable(2)] int[] selectedIds = null)
	{
		GachaAccumulateController.<ClaimAccumulateRewardAsync>d__9 <ClaimAccumulateRewardAsync>d__;
		<ClaimAccumulateRewardAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<ClaimAccumulateRewardAsync>d__.accumulateId = accumulateId;
		<ClaimAccumulateRewardAsync>d__.rewardIds = rewardIds;
		<ClaimAccumulateRewardAsync>d__.selectedIds = selectedIds;
		<ClaimAccumulateRewardAsync>d__.<>1__state = -1;
		<ClaimAccumulateRewardAsync>d__.<>t__builder.Start<GachaAccumulateController.<ClaimAccumulateRewardAsync>d__9>(ref <ClaimAccumulateRewardAsync>d__);
		return <ClaimAccumulateRewardAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D7D5 RID: 55253 RVA: 0x0039B4C8 File Offset: 0x003996C8
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public UniTask<ResonantChainOptionLimitInfo> GetResonantChainOptionLimitInfoAsync()
	{
		GachaAccumulateController.<GetResonantChainOptionLimitInfoAsync>d__10 <GetResonantChainOptionLimitInfoAsync>d__;
		<GetResonantChainOptionLimitInfoAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<ResonantChainOptionLimitInfo>.Create();
		<GetResonantChainOptionLimitInfoAsync>d__.<>1__state = -1;
		<GetResonantChainOptionLimitInfoAsync>d__.<>t__builder.Start<GachaAccumulateController.<GetResonantChainOptionLimitInfoAsync>d__10>(ref <GetResonantChainOptionLimitInfoAsync>d__);
		return <GetResonantChainOptionLimitInfoAsync>d__.<>t__builder.Task;
	}
}

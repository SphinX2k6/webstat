using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BA0 RID: 7072
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class FeedbackRewardController : UiControllerBase<FeedbackRewardController>
{
	// Token: 0x0600CDB7 RID: 52663 RVA: 0x0036CD8A File Offset: 0x0036AF8A
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<GivebackInfoUpdateNotify>(ENotifyMessageId.GivebackInfoUpdateNotify, new Action<GivebackInfoUpdateNotify, Net.CallbackStatus>(this.GivebackInfoUpdateNotify));
	}

	// Token: 0x0600CDB8 RID: 52664 RVA: 0x0036CDA8 File Offset: 0x0036AFA8
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.GivebackInfoUpdateNotify);
	}

	// Token: 0x0600CDB9 RID: 52665 RVA: 0x0036CDBA File Offset: 0x0036AFBA
	protected override void OnAddEvents()
	{
		base.OnAddEvents();
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.WorldDone));
	}

	// Token: 0x0600CDBA RID: 52666 RVA: 0x0036CDFA File Offset: 0x0036AFFA
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.WorldDone));
		base.OnRemoveEvents();
	}

	// Token: 0x0600CDBB RID: 52667 RVA: 0x0036CE3A File Offset: 0x0036B03A
	private void OnLoadingNetDataDone()
	{
		this.GivebackInfoRequest().Forget();
	}

	// Token: 0x0600CDBC RID: 52668 RVA: 0x0036CE47 File Offset: 0x0036B047
	private void WorldDone()
	{
		this.TryPushSplashScreenTask(false);
	}

	// Token: 0x0600CDBD RID: 52669 RVA: 0x0036CE50 File Offset: 0x0036B050
	private void TryPushSplashScreenTask(bool isInstantly = false)
	{
		if (this.HaveShowFeedbackRewardStartView || ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			return;
		}
		List<int> canClaimRewardIds = ModelBase<FeedbackRewardModel>.Instance.GetCanClaimRewardIds();
		if (canClaimRewardIds != null && canClaimRewardIds.Count > 0)
		{
			SplashScreenTask splashScreenTask = new SplashScreenTask(ESplashScreenSourceModuleType.FeedbackReward, ESplashScreenType.Config, delegate()
			{
				this.HaveShowFeedbackRewardStartView = true;
				List<int> canClaimRewardIds2 = ModelBase<FeedbackRewardModel>.Instance.GetCanClaimRewardIds();
				if (canClaimRewardIds2 != null && canClaimRewardIds2.Count > 0)
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.FeedbackRewardStartView, null, null);
				}
			});
			ControllerBase<SplashScreenController>.Instance.PushSplashScreenTask(splashScreenTask, isInstantly);
		}
	}

	// Token: 0x0600CDBE RID: 52670 RVA: 0x0036CEAC File Offset: 0x0036B0AC
	public UniTask GivebackInfoRequest()
	{
		FeedbackRewardController.<GivebackInfoRequest>d__8 <GivebackInfoRequest>d__;
		<GivebackInfoRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<GivebackInfoRequest>d__.<>4__this = this;
		<GivebackInfoRequest>d__.<>1__state = -1;
		<GivebackInfoRequest>d__.<>t__builder.Start<FeedbackRewardController.<GivebackInfoRequest>d__8>(ref <GivebackInfoRequest>d__);
		return <GivebackInfoRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0600CDBF RID: 52671 RVA: 0x0036CEEF File Offset: 0x0036B0EF
	private void GivebackInfoResponse(GivebackInfoResponse response, Net.CallbackStatus _)
	{
	}

	// Token: 0x0600CDC0 RID: 52672 RVA: 0x0036CEF4 File Offset: 0x0036B0F4
	public UniTask GivebackRewardRequest()
	{
		FeedbackRewardController.<GivebackRewardRequest>d__10 <GivebackRewardRequest>d__;
		<GivebackRewardRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<GivebackRewardRequest>d__.<>4__this = this;
		<GivebackRewardRequest>d__.<>1__state = -1;
		<GivebackRewardRequest>d__.<>t__builder.Start<FeedbackRewardController.<GivebackRewardRequest>d__10>(ref <GivebackRewardRequest>d__);
		return <GivebackRewardRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0600CDC1 RID: 52673 RVA: 0x0036CF37 File Offset: 0x0036B137
	private void GivebackRewardResponse(GivebackRewardResponse response, Net.CallbackStatus _)
	{
	}

	// Token: 0x0600CDC2 RID: 52674 RVA: 0x0036CF3C File Offset: 0x0036B13C
	[NullableContext(1)]
	private void GivebackInfoUpdateNotify(GivebackInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		GivebackInfoPb givebackInfo = notify.GivebackInfo;
		if (givebackInfo == null)
		{
			return;
		}
		ModelBase<FeedbackRewardModel>.Instance.CurrentPointCount = givebackInfo.TotalScore;
		ModelBase<FeedbackRewardModel>.Instance.CurrentLoginDayCount = givebackInfo.ActiveDay;
		ModelBase<FeedbackRewardModel>.Instance.RefreshFeedBackRewardMapState(givebackInfo.RewardedIds.ToArray<int>());
		ModelBase<FeedbackRewardModel>.Instance.RefreshFeedBackTask(givebackInfo.Task.ToArray<GivebackTaskPb>());
		Singleton<EventSystem>.Instance.Emit(EEventName.FeedbackRewardRefresh);
		this.TryPushSplashScreenTask(true);
	}

	// Token: 0x04006238 RID: 25144
	private bool HaveShowFeedbackRewardStartView;
}

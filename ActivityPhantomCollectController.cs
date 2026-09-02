using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x0200148E RID: 5262
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityPhantomCollectController : ActivityControllerBase<ActivityPhantomCollectController>
{
	// Token: 0x06009343 RID: 37699 RVA: 0x0026DC70 File Offset: 0x0026BE70
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<PhantomCollectUpdateNotify>(ENotifyMessageId.PhantomCollectUpdateNotify, new Action<PhantomCollectUpdateNotify, Net.CallbackStatus>(this.OnPhantomCollectUpdateNotify));
	}

	// Token: 0x06009344 RID: 37700 RVA: 0x0026DC8E File Offset: 0x0026BE8E
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomCollectUpdateNotify);
	}

	// Token: 0x06009345 RID: 37701 RVA: 0x0026DCA0 File Offset: 0x0026BEA0
	protected void OnPhantomCollectUpdateNotify(PhantomCollectUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		this.ActivityId = notify.ActivityId;
		ActivityPhantomCollectData currentActivityDataById = this.GetCurrentActivityDataById();
		if (currentActivityDataById == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.LPH;
			string message = "声骇收集活动数据更新错误，没有活动数据:";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActivityId:", notify.ActivityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (notify.PhantomCollectReward == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Activity;
			ELogAuthor author2 = ELogAuthor.LPH;
			string message2 = "声骇收集活动数据更新错误:";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ActivityId:", notify.ActivityId);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		currentActivityDataById.UpadatePhantomCollectReward(notify.PhantomCollectReward);
		Singleton<EventSystem>.Instance.Emit<PhantomCollectRewardType>(EEventName.OnPhantomCollectUpdate, notify.PhantomCollectReward.Type);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
	}

	// Token: 0x06009346 RID: 37702 RVA: 0x0026DD72 File Offset: 0x0026BF72
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityPhantomCollect";
	}

	// Token: 0x06009347 RID: 37703 RVA: 0x0026DD79 File Offset: 0x0026BF79
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewPhantomCollect();
	}

	// Token: 0x06009348 RID: 37704 RVA: 0x0026DD80 File Offset: 0x0026BF80
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.ActivityId = data.Id;
		return new ActivityPhantomCollectData();
	}

	// Token: 0x06009349 RID: 37705 RVA: 0x0026DD93 File Offset: 0x0026BF93
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x0600934A RID: 37706 RVA: 0x0026DD95 File Offset: 0x0026BF95
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x0600934B RID: 37707 RVA: 0x0026DD98 File Offset: 0x0026BF98
	public ActivityPhantomCollectData GetCurrentActivityDataById()
	{
		ActivityPhantomCollectData activityPhantomCollectData = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as ActivityPhantomCollectData;
		if (activityPhantomCollectData == null)
		{
			return null;
		}
		return activityPhantomCollectData;
	}

	// Token: 0x0600934C RID: 37708 RVA: 0x0026DDC4 File Offset: 0x0026BFC4
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public UniTask<PhantomCollectReward> PhantomCollectRewardReceiveRequest(int taskType)
	{
		ActivityPhantomCollectController.<PhantomCollectRewardReceiveRequest>d__10 <PhantomCollectRewardReceiveRequest>d__;
		<PhantomCollectRewardReceiveRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<PhantomCollectReward>.Create();
		<PhantomCollectRewardReceiveRequest>d__.<>4__this = this;
		<PhantomCollectRewardReceiveRequest>d__.taskType = taskType;
		<PhantomCollectRewardReceiveRequest>d__.<>1__state = -1;
		<PhantomCollectRewardReceiveRequest>d__.<>t__builder.Start<ActivityPhantomCollectController.<PhantomCollectRewardReceiveRequest>d__10>(ref <PhantomCollectRewardReceiveRequest>d__);
		return <PhantomCollectRewardReceiveRequest>d__.<>t__builder.Task;
	}

	// Token: 0x04004422 RID: 17442
	public int ActivityId;
}

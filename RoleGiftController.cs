using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x0200156B RID: 5483
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class RoleGiftController : ActivityControllerBase<RoleGiftController>
{
	// Token: 0x060099DD RID: 39389 RVA: 0x00284844 File Offset: 0x00282A44
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add<int, IReadOnlyList<int>>(EEventName.OnReceiveActivityData, new Action<int, IReadOnlyList<int>>(this.OnReceiveActivityData));
		Singleton<EventSystem>.Instance.Add(EEventName.ActivityViewRefreshCurrent, new Action<int>(this.OnActivityViewRefreshCurrent));
	}

	// Token: 0x060099DE RID: 39390 RVA: 0x002848A8 File Offset: 0x00282AA8
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove<int, IReadOnlyList<int>>(EEventName.OnReceiveActivityData, new Action<int, IReadOnlyList<int>>(this.OnReceiveActivityData));
		Singleton<EventSystem>.Instance.Remove(EEventName.ActivityViewRefreshCurrent, new Action<int>(this.OnActivityViewRefreshCurrent));
	}

	// Token: 0x060099DF RID: 39391 RVA: 0x00284909 File Offset: 0x00282B09
	protected override void OnRegisterNetEvent()
	{
	}

	// Token: 0x060099E0 RID: 39392 RVA: 0x0028490B File Offset: 0x00282B0B
	protected override void OnUnRegisterNetEvent()
	{
	}

	// Token: 0x060099E1 RID: 39393 RVA: 0x00284910 File Offset: 0x00282B10
	private void OnWorldDone()
	{
		if (Singleton<PublicUtil>.Instance.GetIsSilentLogin())
		{
			RoleGiftUtil.Debug("RoleGift 开屏任务跳过：静默登录", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (ConfigSplashScreenById.GetConfig(9, true) == null)
		{
			RoleGiftUtil.Debug("RoleGift 开屏任务跳过：开屏动画表无 RoleGiftActivity 配置", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		RoleGiftData roleGiftData = this.TryGetSingleActivityData();
		if (roleGiftData == null)
		{
			this.PendingSplashAfterActivitySync = true;
			RoleGiftUtil.Debug("RoleGift 开屏：暂无活动数据，待活动信息更新后重试", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.TryPushRoleGiftSplash(roleGiftData, false);
	}

	// Token: 0x060099E2 RID: 39394 RVA: 0x00284990 File Offset: 0x00282B90
	private void OnReceiveActivityData(int type, IReadOnlyList<int> activityIds)
	{
		if (!this.PendingSplashAfterActivitySync)
		{
			return;
		}
		if (type != 104)
		{
			return;
		}
		string message = "RoleGift 收到 RoleGift 活动数据同步";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityIds", activityIds);
		RoleGiftUtil.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.TryResolvePendingSplashAfterActivitySync();
	}

	// Token: 0x060099E3 RID: 39395 RVA: 0x002849D0 File Offset: 0x00282BD0
	private void TryResolvePendingSplashAfterActivitySync()
	{
		if (!this.PendingSplashAfterActivitySync)
		{
			return;
		}
		if (Singleton<PublicUtil>.Instance.GetIsSilentLogin())
		{
			this.PendingSplashAfterActivitySync = false;
			return;
		}
		if (ConfigSplashScreenById.GetConfig(9, true) == null)
		{
			this.PendingSplashAfterActivitySync = false;
			return;
		}
		RoleGiftData roleGiftData = this.TryGetSingleActivityData();
		if (roleGiftData == null)
		{
			return;
		}
		this.PendingSplashAfterActivitySync = false;
		this.TryPushRoleGiftSplash(roleGiftData, true);
	}

	// Token: 0x060099E4 RID: 39396 RVA: 0x00284A30 File Offset: 0x00282C30
	private void OnActivityViewRefreshCurrent(int activityId)
	{
		RoleGiftData roleGiftData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as RoleGiftData;
		if (roleGiftData == null || roleGiftData.Type != ActivityType.RoleGiftActivity)
		{
			return;
		}
		this.TryPushRoleGiftSplash(roleGiftData, false);
	}

	// Token: 0x060099E5 RID: 39397 RVA: 0x00284A64 File Offset: 0x00282C64
	private void TryPushRoleGiftSplash(RoleGiftData data, bool isInstantly = false)
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			RoleGiftUtil.Debug("RoleGift 开屏任务跳过：多人在线模式", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!data.NeedSplash())
		{
			RoleGiftUtil.Debug("RoleGift 开屏任务跳过：无满足条件的活动", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.HadPushedSplash)
		{
			RoleGiftUtil.Debug("RoleGift 开屏任务跳过：开屏动画已入过队", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int activityId = data.Id;
		SplashScreenTask splashScreenTask = new SplashScreenTask(ESplashScreenSourceModuleType.RoleGiftActivity, ESplashScreenType.Config, delegate()
		{
			this.HadPushedSplash = true;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleGiftSplashView, activityId, null);
		});
		string message = "RoleGift 开屏任务入队";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("activityId", activityId);
		RoleGiftUtil.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ControllerBase<SplashScreenController>.Instance.PushSplashScreenTask(splashScreenTask, isInstantly);
	}

	// Token: 0x060099E6 RID: 39398 RVA: 0x00284B2C File Offset: 0x00282D2C
	[NullableContext(2)]
	public unsafe RoleGiftData TryGetSingleActivityData()
	{
		List<ActivityBaseData> activitiesByType = ModelBase<ActivityModel>.Instance.GetActivitiesByType(104);
		if (activitiesByType == null || activitiesByType.Count <= 0)
		{
			string message = "GetSingleActivityData";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("reason", "empty_list");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("count", (activitiesByType != null) ? activitiesByType.Count : 0);
			RoleGiftUtil.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		if (activitiesByType.Count > 1)
		{
			string message2 = "RoleGift multiple activity data found";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("count", activitiesByType.Count);
			RoleGiftUtil.Error(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		RoleGiftData roleGiftData = activitiesByType[0] as RoleGiftData;
		if (roleGiftData == null)
		{
			return null;
		}
		if (!roleGiftData.CheckIfInOpenTime())
		{
			return null;
		}
		string message3 = "GetSingleActivityData";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("reason", "ok");
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("activityId", roleGiftData.Id);
		RoleGiftUtil.Debug(message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		return roleGiftData;
	}

	// Token: 0x060099E7 RID: 39399 RVA: 0x00284C5A File Offset: 0x00282E5A
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x060099E8 RID: 39400 RVA: 0x00284C5C File Offset: 0x00282E5C
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_PresentMain";
	}

	// Token: 0x060099E9 RID: 39401 RVA: 0x00284C63 File Offset: 0x00282E63
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new RoleGiftView();
	}

	// Token: 0x060099EA RID: 39402 RVA: 0x00284C6A File Offset: 0x00282E6A
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new RoleGiftData();
	}

	// Token: 0x060099EB RID: 39403 RVA: 0x00284C71 File Offset: 0x00282E71
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x060099EC RID: 39404 RVA: 0x00284C74 File Offset: 0x00282E74
	public UniTask RequestRoleGiftReward(int activityId)
	{
		RoleGiftController.<RequestRoleGiftReward>d__17 <RequestRoleGiftReward>d__;
		<RequestRoleGiftReward>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestRoleGiftReward>d__.activityId = activityId;
		<RequestRoleGiftReward>d__.<>1__state = -1;
		<RequestRoleGiftReward>d__.<>t__builder.Start<RoleGiftController.<RequestRoleGiftReward>d__17>(ref <RequestRoleGiftReward>d__);
		return <RequestRoleGiftReward>d__.<>t__builder.Task;
	}

	// Token: 0x04004701 RID: 18177
	private bool PendingSplashAfterActivitySync;

	// Token: 0x04004702 RID: 18178
	private bool HadPushedSplash;
}

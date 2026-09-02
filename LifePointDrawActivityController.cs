using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001345 RID: 4933
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class LifePointDrawActivityController : ActivityControllerBase<LifePointDrawActivityController>
{
	// Token: 0x060086C4 RID: 34500 RVA: 0x00237C5C File Offset: 0x00235E5C
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x060086C5 RID: 34501 RVA: 0x00237C5E File Offset: 0x00235E5E
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityColorfulMain";
	}

	// Token: 0x060086C6 RID: 34502 RVA: 0x00237C65 File Offset: 0x00235E65
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new LifePointSubView();
	}

	// Token: 0x060086C7 RID: 34503 RVA: 0x00237C6C File Offset: 0x00235E6C
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new LifePointDrawActivityData();
	}

	// Token: 0x060086C8 RID: 34504 RVA: 0x00237C73 File Offset: 0x00235E73
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x060086C9 RID: 34505 RVA: 0x00237C76 File Offset: 0x00235E76
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<LifePointChallengeUpdateNotify>(ENotifyMessageId.LifePointChallengeUpdateNotify, new Action<LifePointChallengeUpdateNotify, Net.CallbackStatus>(this.OnLifePointUpdate));
	}

	// Token: 0x060086CA RID: 34506 RVA: 0x00237C94 File Offset: 0x00235E94
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.LifePointChallengeUpdateNotify);
	}

	// Token: 0x060086CB RID: 34507 RVA: 0x00237CA6 File Offset: 0x00235EA6
	[NullableContext(2)]
	private LifePointDrawActivityData GetActivityDataById(int id)
	{
		if (ModelBase<ActivityModel>.Instance.GetActivityById(id) == null)
		{
			return null;
		}
		return ModelBase<ActivityModel>.Instance.GetActivityById(id) as LifePointDrawActivityData;
	}

	// Token: 0x060086CC RID: 34508 RVA: 0x00237CC8 File Offset: 0x00235EC8
	private void OnLifePointUpdate(LifePointChallengeUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		foreach (LifePointChallengeData lifePointChallengeData in notify.Challenges)
		{
			LifePointChallenge value = ConfigBase<LifePointDrawConfig>.Instance.GetLifePointChallengeById(lifePointChallengeData.ChallengeId).Value;
			LifePointDrawActivityData activityDataById = this.GetActivityDataById(value.ActivityId);
			if (activityDataById != null)
			{
				activityDataById.OnLifePointChallengeDataUpdate(lifePointChallengeData);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshLifePointDrawChallengeRedDot, lifePointChallengeData.ChallengeId);
			}
			if (!list2.Contains(value.GroupId))
			{
				list2.Add(value.GroupId);
			}
			if (!list.Contains(value.ActivityId))
			{
				list.Add(value.ActivityId);
			}
		}
		foreach (int p in list)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, p);
		}
		foreach (int p2 in list2)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshLifePointDrawGroupRedDot, p2);
		}
	}

	// Token: 0x060086CD RID: 34509 RVA: 0x00237E38 File Offset: 0x00236038
	public void RequestStartChallenge(int activityId, int challengeId)
	{
		LifePointChallengeStartRequest lifePointChallengeStartRequest = LifePointChallengeStartRequest.Create();
		lifePointChallengeStartRequest.Id = challengeId;
		ModelBase<LifePointDrawModel>.Instance.CurrentChallengeFinishState = ModelBase<LifePointDrawModel>.Instance.GetChallengeFinishState(activityId, challengeId);
		Singleton<Net>.Instance.Call<LifePointChallengeStartResponse>(ERequestMessageId.LifePointChallengeStartRequest, lifePointChallengeStartRequest, delegate(LifePointChallengeStartResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27334, null, true, true);
			}
		}, 0);
	}

	// Token: 0x060086CE RID: 34510 RVA: 0x00237E98 File Offset: 0x00236098
	[NullableContext(0)]
	public UniTask<bool> OpenLifePointDrawActivityView()
	{
		LifePointDrawActivityController.<OpenLifePointDrawActivityView>d__10 <OpenLifePointDrawActivityView>d__;
		<OpenLifePointDrawActivityView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenLifePointDrawActivityView>d__.<>1__state = -1;
		<OpenLifePointDrawActivityView>d__.<>t__builder.Start<LifePointDrawActivityController.<OpenLifePointDrawActivityView>d__10>(ref <OpenLifePointDrawActivityView>d__);
		return <OpenLifePointDrawActivityView>d__.<>t__builder.Task;
	}
}

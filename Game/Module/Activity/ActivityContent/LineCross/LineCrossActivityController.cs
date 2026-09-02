using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.LineCross
{
	// Token: 0x0200675F RID: 26463
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class LineCrossActivityController : ActivityControllerBase<LineCrossActivityController>
	{
		// Token: 0x06041F78 RID: 270200 RVA: 0x010ED069 File Offset: 0x010EB269
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06041F79 RID: 270201 RVA: 0x010ED06B File Offset: 0x010EB26B
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_ActivityCrossline";
		}

		// Token: 0x06041F7A RID: 270202 RVA: 0x010ED072 File Offset: 0x010EB272
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new LineCrossSubView();
		}

		// Token: 0x06041F7B RID: 270203 RVA: 0x010ED079 File Offset: 0x010EB279
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			return new LineCrossActivityData();
		}

		// Token: 0x06041F7C RID: 270204 RVA: 0x010ED080 File Offset: 0x010EB280
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x06041F7D RID: 270205 RVA: 0x010ED083 File Offset: 0x010EB283
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<LineCrossActivityUpdateNotify>(ENotifyMessageId.LineCrossActivityUpdateNotify, new Action<LineCrossActivityUpdateNotify, Net.CallbackStatus>(this.OnLineCrossUpdate));
		}

		// Token: 0x06041F7E RID: 270206 RVA: 0x010ED0A1 File Offset: 0x010EB2A1
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.LineCrossActivityUpdateNotify);
		}

		// Token: 0x06041F7F RID: 270207 RVA: 0x010ED0B3 File Offset: 0x010EB2B3
		[NullableContext(2)]
		private LineCrossActivityData GetActivityDataById(int id)
		{
			if (ModelBase<ActivityModel>.Instance.GetActivityById(id) == null)
			{
				return null;
			}
			return ModelBase<ActivityModel>.Instance.GetActivityById(id) as LineCrossActivityData;
		}

		// Token: 0x06041F80 RID: 270208 RVA: 0x010ED0D4 File Offset: 0x010EB2D4
		private void OnLineCrossUpdate(LineCrossActivityUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			foreach (LineCrossChallengeData lineCrossChallengeData in notify.Challenges)
			{
				LineCrossChallenge value = ConfigBase<LineCrossConfig>.Instance.GetLineCrossChallengeById(lineCrossChallengeData.ChallengeId).Value;
				LineCrossActivityData activityDataById = this.GetActivityDataById(value.ActivityId);
				if (activityDataById != null)
				{
					activityDataById.OnChallengeDataUpdate(lineCrossChallengeData);
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshLineCrossChallengeRedDot, lineCrossChallengeData.ChallengeId);
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
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshLineCrossGroupRedDot, p2);
			}
		}

		// Token: 0x06041F81 RID: 270209 RVA: 0x010ED244 File Offset: 0x010EB444
		public void RequestStartChallenge(int activityId, int challengeId)
		{
			LineCrossChallengeStartRequest lineCrossChallengeStartRequest = LineCrossChallengeStartRequest.Create();
			lineCrossChallengeStartRequest.Id = challengeId;
			ModelBase<LineCrossModel>.Instance.CurrentChallengeFinishState = ModelBase<LineCrossModel>.Instance.GetChallengeFinishState(activityId, challengeId);
			Singleton<Net>.Instance.Call<LineCrossChallengeStartResponse>(ERequestMessageId.LineCrossChallengeStartRequest, lineCrossChallengeStartRequest, delegate(LineCrossChallengeStartResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 23760, null, true, true);
				}
			}, 0);
		}

		// Token: 0x06041F82 RID: 270210 RVA: 0x010ED2A4 File Offset: 0x010EB4A4
		[NullableContext(0)]
		public UniTask<bool> OpenLineCrossActivityView()
		{
			LineCrossActivityController.<OpenLineCrossActivityView>d__10 <OpenLineCrossActivityView>d__;
			<OpenLineCrossActivityView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenLineCrossActivityView>d__.<>1__state = -1;
			<OpenLineCrossActivityView>d__.<>t__builder.Start<LineCrossActivityController.<OpenLineCrossActivityView>d__10>(ref <OpenLineCrossActivityView>d__);
			return <OpenLineCrossActivityView>d__.<>t__builder.Task;
		}

		// Token: 0x06041F83 RID: 270211 RVA: 0x010ED2E0 File Offset: 0x010EB4E0
		[NullableContext(0)]
		protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
		{
			LineCrossActivityController.<OnOpenSubView>d__11 <OnOpenSubView>d__;
			<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnOpenSubView>d__.<>4__this = this;
			<OnOpenSubView>d__.viewName = viewName;
			<OnOpenSubView>d__.<>1__state = -1;
			<OnOpenSubView>d__.<>t__builder.Start<LineCrossActivityController.<OnOpenSubView>d__11>(ref <OnOpenSubView>d__);
			return <OnOpenSubView>d__.<>t__builder.Task;
		}
	}
}

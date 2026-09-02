using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x0200696C RID: 26988
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class CyberPunkController : ActivityControllerBase<CyberPunkController>
	{
		// Token: 0x06042F73 RID: 274291 RVA: 0x01131259 File Offset: 0x0112F459
		static CyberPunkController()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(ControllerBase<CyberPunkController>.CreateStaticDefaultValue), new Action(ControllerBase<CyberPunkController>.ResetStaticDefaultValue));
		}

		// Token: 0x06042F74 RID: 274292 RVA: 0x01131278 File Offset: 0x0112F478
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06042F75 RID: 274293 RVA: 0x0113127A File Offset: 0x0112F47A
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x06042F76 RID: 274294 RVA: 0x0113127D File Offset: 0x0112F47D
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_ActivityGuideCyberpunk";
		}

		// Token: 0x06042F77 RID: 274295 RVA: 0x01131284 File Offset: 0x0112F484
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new CyberPunkSubView();
		}

		// Token: 0x06042F78 RID: 274296 RVA: 0x0113128B File Offset: 0x0112F48B
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.CurrentActivityId = data.Id;
			return new CyberPunkData();
		}

		// Token: 0x06042F79 RID: 274297 RVA: 0x0113129E File Offset: 0x0112F49E
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<EdgeRunnerUpdateNotify>(ENotifyMessageId.EdgeRunnerUpdateNotify, new Action<EdgeRunnerUpdateNotify, Net.CallbackStatus>(this.OnEdgeRunnerUpdate));
			Singleton<Net>.Instance.Register<EdgeRunnerPreUnlockAvailableNotify>(ENotifyMessageId.EdgeRunnerPreUnlockAvailableNotify, new Action<EdgeRunnerPreUnlockAvailableNotify, Net.CallbackStatus>(this.OnEdgeRunnerFunctionPreUnlock));
		}

		// Token: 0x06042F7A RID: 274298 RVA: 0x011312D8 File Offset: 0x0112F4D8
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.EdgeRunnerUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.EdgeRunnerPreUnlockAvailableNotify);
		}

		// Token: 0x06042F7B RID: 274299 RVA: 0x011312FC File Offset: 0x0112F4FC
		private void OnEdgeRunnerUpdate(EdgeRunnerUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			CyberPunkData currentActivityDataStatic = this.GetCurrentActivityDataStatic();
			if (currentActivityDataStatic == null)
			{
				return;
			}
			if (notify.HasFunctionId)
			{
				currentActivityDataStatic.AddUnlockedFunctionId(notify.FunctionId);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnCyberPunkItemUnLock);
			}
			if (notify.Task != null)
			{
				currentActivityDataStatic.RefreshSingleTaskData(notify.Task);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnCyberPunkTaskRefresh);
		}

		// Token: 0x06042F7C RID: 274300 RVA: 0x0113135C File Offset: 0x0112F55C
		private void OnEdgeRunnerFunctionPreUnlock(EdgeRunnerPreUnlockAvailableNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			CyberPunkData currentActivityDataStatic = this.GetCurrentActivityDataStatic();
			if (currentActivityDataStatic == null)
			{
				return;
			}
			currentActivityDataStatic.AddPreUnlockedQuestIds(notify);
		}

		// Token: 0x06042F7D RID: 274301 RVA: 0x0113137C File Offset: 0x0112F57C
		[NullableContext(2)]
		public CyberPunkData GetCurrentActivityDataStatic()
		{
			List<ActivityBaseData> currentActivitiesByType = ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.EdgeRunnerActivity);
			if (currentActivitiesByType == null || currentActivitiesByType.Count == 0)
			{
				return null;
			}
			return currentActivitiesByType[0] as CyberPunkData;
		}

		// Token: 0x06042F7E RID: 274302 RVA: 0x011313B0 File Offset: 0x0112F5B0
		[NullableContext(2)]
		public void RequestScoreReward(int scoreId, Action callback = null)
		{
			EdgeRunnerScoreRewardRequest edgeRunnerScoreRewardRequest = EdgeRunnerScoreRewardRequest.Create();
			edgeRunnerScoreRewardRequest.ScoreId = scoreId;
			Singleton<Net>.Instance.Call<EdgeRunnerScoreRewardResponse>(ERequestMessageId.EdgeRunnerScoreRewardRequest, edgeRunnerScoreRewardRequest, delegate(EdgeRunnerScoreRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 26651, null, true, true);
					return;
				}
				CyberPunkData currentActivityDataStatic = this.GetCurrentActivityDataStatic();
				if (currentActivityDataStatic != null)
				{
					currentActivityDataStatic.UpdateRewardScoreId(scoreId);
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, currentActivityDataStatic.Id);
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, currentActivityDataStatic.Id);
					Singleton<EventSystem>.Instance.Emit(EEventName.OnCyberPunkTaskRefresh);
				}
				List<int> list = ((currentActivityDataStatic != null) ? currentActivityDataStatic.GetClaimableTaskIds() : null) ?? new List<int>();
				if (list.Count > 0)
				{
					this.RequestTaskReward(list.ToArray(), null);
				}
				Action callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2();
			}, 0);
		}

		// Token: 0x06042F7F RID: 274303 RVA: 0x01131408 File Offset: 0x0112F608
		public void RequestTaskReward(int[] taskIds, [Nullable(2)] Action callback = null)
		{
			EdgeRunnerTaskRewardRequest edgeRunnerTaskRewardRequest = EdgeRunnerTaskRewardRequest.Create();
			edgeRunnerTaskRewardRequest.TaskIds.AddRange(taskIds);
			CyberPunkData currentActivityDataStatic = this.GetCurrentActivityDataStatic();
			if (currentActivityDataStatic != null)
			{
				edgeRunnerTaskRewardRequest.ActivityId = currentActivityDataStatic.Id;
			}
			Singleton<Net>.Instance.Call<EdgeRunnerTaskRewardResponse>(ERequestMessageId.EdgeRunnerTaskRewardRequest, edgeRunnerTaskRewardRequest, delegate(EdgeRunnerTaskRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 29983, null, true, true);
					return;
				}
				CyberPunkData currentActivityDataStatic2 = this.GetCurrentActivityDataStatic();
				if (currentActivityDataStatic2 != null)
				{
					foreach (int taskId in taskIds)
					{
						currentActivityDataStatic2.MarkTaskAsClaimed(taskId);
					}
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, currentActivityDataStatic2.Id);
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, currentActivityDataStatic2.Id);
					Singleton<EventSystem>.Instance.Emit(EEventName.OnCyberPunkTaskRefresh);
				}
				Action callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2();
			}, 0);
		}

		// Token: 0x06042F80 RID: 274304 RVA: 0x0113147C File Offset: 0x0112F67C
		[NullableContext(2)]
		public void PreOpenStoryFunction(int functionId, Action callback = null)
		{
			EdgeRunnerFunctionPreUnlockRequest edgeRunnerFunctionPreUnlockRequest = EdgeRunnerFunctionPreUnlockRequest.Create();
			edgeRunnerFunctionPreUnlockRequest.FuncId = functionId;
			Singleton<Net>.Instance.Call<EdgeRunnerFunctionPreUnlockResponse>(ERequestMessageId.EdgeRunnerFunctionPreUnlockRequest, edgeRunnerFunctionPreUnlockRequest, delegate(EdgeRunnerFunctionPreUnlockResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 21680, null, true, true);
					return;
				}
				Action callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2();
			}, 0);
		}

		// Token: 0x06042F81 RID: 274305 RVA: 0x011314C0 File Offset: 0x0112F6C0
		[NullableContext(2)]
		public CyberPunkData GetCurrentActivityData()
		{
			List<ActivityBaseData> currentActivitiesByType = ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.EdgeRunnerActivity);
			CyberPunkData result = null;
			if (currentActivitiesByType.Count > 0)
			{
				result = (currentActivitiesByType.GetValueOrDefault(0) as CyberPunkData);
			}
			return result;
		}

		// Token: 0x06042F82 RID: 274306 RVA: 0x011314F4 File Offset: 0x0112F6F4
		public string GetTimeVisibleAndRemainTimeText()
		{
			CyberPunkData currentActivityData = this.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				return "";
			}
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(currentActivityData, null);
			bool item = timeVisibleAndRemainTime.Item1;
			string item2 = timeVisibleAndRemainTime.Item2;
			if (!item)
			{
				return "";
			}
			return item2;
		}

		// Token: 0x040254D4 RID: 152788
		public int CurrentActivityId;
	}
}

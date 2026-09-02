using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066CB RID: 26315
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class MotorFightController : ActivityControllerBase<MotorFightController>
	{
		// Token: 0x06041B88 RID: 269192 RVA: 0x010DA5DC File Offset: 0x010D87DC
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<MotorFightLevelUpdateNotify>(ENotifyMessageId.MotorFightLevelUpdateNotify, new Action<MotorFightLevelUpdateNotify, Net.CallbackStatus>(this.UpdateMotorFightLevel));
			Singleton<Net>.Instance.Register<MotorFightItemUpdateNotify>(ENotifyMessageId.MotorFightItemUpdateNotify, new Action<MotorFightItemUpdateNotify, Net.CallbackStatus>(this.UpdateMotorFightItem));
			Singleton<Net>.Instance.Register<MotorFightRoleUpdateNotify>(ENotifyMessageId.MotorFightRoleUpdateNotify, new Action<MotorFightRoleUpdateNotify, Net.CallbackStatus>(this.UpdateMotorFightRole));
			Singleton<Net>.Instance.Register<MotorFightTaskUpdateNotify>(ENotifyMessageId.MotorFightTaskUpdateNotify, new Action<MotorFightTaskUpdateNotify, Net.CallbackStatus>(this.UpdateMotorFightTask));
			Singleton<Net>.Instance.Register<MotorFightTalentTreeUpdateNotify>(ENotifyMessageId.MotorFightTalentTreeUpdateNotify, new Action<MotorFightTalentTreeUpdateNotify, Net.CallbackStatus>(this.UpdateMotorFightTalentTree));
			Singleton<Net>.Instance.Register<MotorFightGameOverNotify>(ENotifyMessageId.MotorFightGameOverNotify, new Action<MotorFightGameOverNotify, Net.CallbackStatus>(this.OnMotorFightGameOver));
		}

		// Token: 0x06041B89 RID: 269193 RVA: 0x010DA694 File Offset: 0x010D8894
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MotorFightLevelUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MotorFightItemUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MotorFightRoleUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MotorFightTaskUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MotorFightTalentTreeUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MotorFightGameOverNotify);
		}

		// Token: 0x06041B8A RID: 269194 RVA: 0x010DA701 File Offset: 0x010D8901
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x06041B8B RID: 269195 RVA: 0x010DA73B File Offset: 0x010D893B
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x06041B8C RID: 269196 RVA: 0x010DA775 File Offset: 0x010D8975
		protected override void OnOpenView(ActivityBaseData data)
		{
			throw new Exception("Method not implemented.");
		}

		// Token: 0x06041B8D RID: 269197 RVA: 0x010DA781 File Offset: 0x010D8981
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_MotorcycleBattleMain";
		}

		// Token: 0x06041B8E RID: 269198 RVA: 0x010DA788 File Offset: 0x010D8988
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new MotorFightActivitySubView();
		}

		// Token: 0x06041B8F RID: 269199 RVA: 0x010DA790 File Offset: 0x010D8990
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			MotorFightActivityData motorFightActivityData = new MotorFightActivityData();
			this.MotorFightActivityData = motorFightActivityData;
			return motorFightActivityData;
		}

		// Token: 0x06041B90 RID: 269200 RVA: 0x010DA7AC File Offset: 0x010D89AC
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			foreach (EUiViewName viewName in new List<EUiViewName>
			{
				EUiViewName.MotorFightMainView,
				EUiViewName.MotorFightLevelDetailView,
				EUiViewName.MotorFightRoleSelectView,
				EUiViewName.MotorFightTalentTreeView,
				EUiViewName.MotorFightHandBookView,
				EUiViewName.MotorFightRankView,
				EUiViewName.MotorFightRewardView
			})
			{
				if (Singleton<UiManager>.Instance.IsViewOpen(viewName))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06041B91 RID: 269201 RVA: 0x010DA858 File Offset: 0x010D8A58
		[NullableContext(2)]
		public MotorFightActivityData GetMotorFightActivityData()
		{
			if (this.MotorFightActivityData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.MotorFightActivity, ELogAuthor.CXJ, "摩托战斗活动数据不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return this.MotorFightActivityData;
		}

		// Token: 0x06041B92 RID: 269202 RVA: 0x010DA894 File Offset: 0x010D8A94
		[NullableContext(0)]
		protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
		{
			MotorFightController.<OnOpenSubView>d__15 <OnOpenSubView>d__;
			<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnOpenSubView>d__.<>4__this = this;
			<OnOpenSubView>d__.viewName = viewName;
			<OnOpenSubView>d__.<>1__state = -1;
			<OnOpenSubView>d__.<>t__builder.Start<MotorFightController.<OnOpenSubView>d__15>(ref <OnOpenSubView>d__);
			return <OnOpenSubView>d__.<>t__builder.Task;
		}

		// Token: 0x06041B93 RID: 269203 RVA: 0x010DA8DF File Offset: 0x010D8ADF
		private void UpdateMotorFightLevel(MotorFightLevelUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			MotorFightActivityData motorFightActivityData = this.GetMotorFightActivityData();
			if (motorFightActivityData == null)
			{
				return;
			}
			motorFightActivityData.UpdateLevelDataList(notify.MotorFightLevelPb, true);
		}

		// Token: 0x06041B94 RID: 269204 RVA: 0x010DA8F8 File Offset: 0x010D8AF8
		private void UpdateMotorFightItem(MotorFightItemUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			MotorFightActivityData motorFightActivityData = this.GetMotorFightActivityData();
			if (motorFightActivityData == null)
			{
				return;
			}
			motorFightActivityData.UpdateMotorFightItemDataList(notify.UnlockedItem, true);
		}

		// Token: 0x06041B95 RID: 269205 RVA: 0x010DA911 File Offset: 0x010D8B11
		private void UpdateMotorFightRole(MotorFightRoleUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			MotorFightActivityData motorFightActivityData = this.GetMotorFightActivityData();
			if (motorFightActivityData == null)
			{
				return;
			}
			motorFightActivityData.UpdateRoleData(notify.UnlockedRole, true);
		}

		// Token: 0x06041B96 RID: 269206 RVA: 0x010DA92A File Offset: 0x010D8B2A
		private void UpdateMotorFightTask(MotorFightTaskUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			MotorFightActivityData motorFightActivityData = this.GetMotorFightActivityData();
			if (motorFightActivityData == null)
			{
				return;
			}
			motorFightActivityData.UpdateTaskData(notify.Task, true);
		}

		// Token: 0x06041B97 RID: 269207 RVA: 0x010DA943 File Offset: 0x010D8B43
		private void UpdateMotorFightTalentTree(MotorFightTalentTreeUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			MotorFightActivityData motorFightActivityData = this.GetMotorFightActivityData();
			if (motorFightActivityData == null)
			{
				return;
			}
			motorFightActivityData.UpdateMotorFightTalentDataList(notify.Talent, true);
		}

		// Token: 0x06041B98 RID: 269208 RVA: 0x010DA95C File Offset: 0x010D8B5C
		private void OnMotorFightGameOver(MotorFightGameOverNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MotorFightActivity;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "摩托战斗结算通知";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("isWin", notify.Win);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<EventSystem>.Instance.Emit(EEventName.MotorArrowGameOver);
			if (notify.Win)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightSuccessView, notify.Result, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightFailView, null, null);
		}

		// Token: 0x06041B99 RID: 269209 RVA: 0x010DA9E0 File Offset: 0x010D8BE0
		public void RequestUnlockTalentNode(int talentId, Action callback)
		{
			MotorFightTalentUpRequest motorFightTalentUpRequest = MotorFightTalentUpRequest.Create();
			motorFightTalentUpRequest.TalentId = talentId;
			Singleton<Net>.Instance.Call<MotorFightTalentUpResponse>(ERequestMessageId.MotorFightTalentUpRequest, motorFightTalentUpRequest, delegate(MotorFightTalentUpResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18153, null, true, true);
					return;
				}
				MotorFightActivityData motorFightActivityData = this.GetMotorFightActivityData();
				if (motorFightActivityData != null)
				{
					motorFightActivityData.UpdateMotorFightTalentData(talentId);
				}
				callback();
			}, 0);
		}

		// Token: 0x06041B9A RID: 269210 RVA: 0x010DAA38 File Offset: 0x010D8C38
		public void RequestTaskReward(List<int> taskIds)
		{
			MotorFightOneKeyRewardRequest motorFightOneKeyRewardRequest = MotorFightOneKeyRewardRequest.Create();
			motorFightOneKeyRewardRequest.TaskIds.AddRange(taskIds);
			Singleton<Net>.Instance.Call<MotorFightOneKeyRewardResponse>(ERequestMessageId.MotorFightOneKeyRewardRequest, motorFightOneKeyRewardRequest, delegate(MotorFightOneKeyRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25405, null, true, true);
					return;
				}
				MotorFightActivityData motorFightActivityData = this.GetMotorFightActivityData();
				if (motorFightActivityData == null)
				{
					return;
				}
				motorFightActivityData.GetTaskReward(taskIds);
			}, 0);
		}

		// Token: 0x06041B9B RID: 269211 RVA: 0x010DAA90 File Offset: 0x010D8C90
		public UniTask RequestRankDataList()
		{
			MotorFightController.<RequestRankDataList>d__24 <RequestRankDataList>d__;
			<RequestRankDataList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestRankDataList>d__.<>4__this = this;
			<RequestRankDataList>d__.<>1__state = -1;
			<RequestRankDataList>d__.<>t__builder.Start<MotorFightController.<RequestRankDataList>d__24>(ref <RequestRankDataList>d__);
			return <RequestRankDataList>d__.<>t__builder.Task;
		}

		// Token: 0x06041B9C RID: 269212 RVA: 0x010DAAD4 File Offset: 0x010D8CD4
		public UniTask RequestMyRankData()
		{
			MotorFightController.<RequestMyRankData>d__25 <RequestMyRankData>d__;
			<RequestMyRankData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestMyRankData>d__.<>4__this = this;
			<RequestMyRankData>d__.<>1__state = -1;
			<RequestMyRankData>d__.<>t__builder.Start<MotorFightController.<RequestMyRankData>d__25>(ref <RequestMyRankData>d__);
			return <RequestMyRankData>d__.<>t__builder.Task;
		}

		// Token: 0x06041B9D RID: 269213 RVA: 0x010DAB18 File Offset: 0x010D8D18
		[NullableContext(2)]
		public void RequestSettlement(bool isShowSettleView, Action callback = null)
		{
			MotorFightSettleRequest message = MotorFightSettleRequest.Create();
			Singleton<Net>.Instance.Call<MotorFightSettleResponse>(ERequestMessageId.MotorFightSettleRequest, message, delegate(MotorFightSettleResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 28415, null, true, true);
					return;
				}
				Action callback2 = callback;
				if (callback2 != null)
				{
					callback2();
				}
				this.GetMotorFightActivityData().SetLastSavedLevelData(null);
				if (!isShowSettleView)
				{
					return;
				}
				int levelId = response.Result.ResultCommon.LevelId;
				int totalScore = response.Result.ResultCommon.TotalScore;
				MotorFightLevelData levelDataById = this.GetMotorFightActivityData().GetLevelDataById(levelId);
				if (levelDataById != null && levelDataById.Type == EMotorFightLevelType.Endless && totalScore == 0)
				{
					this.LeaveInstanceDungeon();
					return;
				}
				if (response.Win)
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightSuccessView, response.Result, null);
				}
				else
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightFailView, null, null);
				}
				Singleton<EventSystem>.Instance.Emit(EEventName.MotorArrowGameOver);
			}, 0);
		}

		// Token: 0x06041B9E RID: 269214 RVA: 0x010DAB64 File Offset: 0x010D8D64
		public UniTask RequestLastSavedLevelData()
		{
			MotorFightController.<RequestLastSavedLevelData>d__27 <RequestLastSavedLevelData>d__;
			<RequestLastSavedLevelData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestLastSavedLevelData>d__.<>4__this = this;
			<RequestLastSavedLevelData>d__.<>1__state = -1;
			<RequestLastSavedLevelData>d__.<>t__builder.Start<MotorFightController.<RequestLastSavedLevelData>d__27>(ref <RequestLastSavedLevelData>d__);
			return <RequestLastSavedLevelData>d__.<>t__builder.Task;
		}

		// Token: 0x06041B9F RID: 269215 RVA: 0x010DABA8 File Offset: 0x010D8DA8
		public void EnterMotorFightDungeonDirectly(int levelId, int roleId, bool isContinue = false)
		{
			this.LastLevelId = levelId;
			this.LastMotorFightRoleId = roleId;
			MotorFightCtx motorFightCtx = MotorFightCtx.Create();
			motorFightCtx.LevelId = levelId;
			motorFightCtx.RoleId = roleId;
			motorFightCtx.Continue = isContinue;
			MotorFightRoleData motorFightRoleData = this.GetMotorFightActivityData().GetMotorFightRoleData(roleId);
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(motorFightRoleData.TrialRoleId, true);
			ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.MotorFightCtx = motorFightCtx;
			this.LastRealRoleId = roleDataById.GetDataId();
			ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(0, new List<int>
			{
				this.LastRealRoleId
			}, 0, 0, null, null);
		}

		// Token: 0x06041BA0 RID: 269216 RVA: 0x010DAC3C File Offset: 0x010D8E3C
		public void ReChallengeMotorFightDungeon()
		{
			MotorFightCtx motorFightCtx = MotorFightCtx.Create();
			motorFightCtx.LevelId = this.LastLevelId;
			motorFightCtx.RoleId = this.LastMotorFightRoleId;
			motorFightCtx.Continue = false;
			ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.MotorFightCtx = motorFightCtx;
			ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(0, new List<int>
			{
				this.LastRealRoleId
			}, 0, 0, null, null);
		}

		// Token: 0x06041BA1 RID: 269217 RVA: 0x010DAC9F File Offset: 0x010D8E9F
		private void OnWorldDone()
		{
			if (this.IsNeedShowMotorFightMainView)
			{
				this.AddMainViewSplashTask();
			}
		}

		// Token: 0x06041BA2 RID: 269218 RVA: 0x010DACAF File Offset: 0x010D8EAF
		public void LeaveInstanceDungeon()
		{
			if (this.MotorFightActivityData != null && !this.MotorFightActivityData.CheckIfClose())
			{
				this.IsNeedShowMotorFightMainView = true;
			}
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Default);
		}

		// Token: 0x06041BA3 RID: 269219 RVA: 0x010DACDC File Offset: 0x010D8EDC
		private void AddMainViewSplashTask()
		{
			MotorFightActivityData activityData = this.GetMotorFightActivityData();
			if (activityData == null)
			{
				return;
			}
			SplashScreenTask splashScreenTask = new SplashScreenTask(ESplashScreenSourceModuleType.None, ESplashScreenType.Other, delegate()
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightMainView, activityData, null);
			});
			ControllerBase<SplashScreenController>.Instance.PushSplashScreenTask(splashScreenTask, false);
		}

		// Token: 0x06041BA4 RID: 269220 RVA: 0x010DAD24 File Offset: 0x010D8F24
		private void OnActivityClose(IReadOnlySet<int> closeActivities)
		{
			if (this.MotorFightActivityData == null)
			{
				return;
			}
			if (closeActivities.Contains(this.MotorFightActivityData.Id) && this.CheckInMotorFightDungeon())
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.MotorFightActivityEnd);
				confirmBoxDataNew.FunctionMap.Add(1, new Action(this.LeaveInstanceDungeon));
				confirmBoxDataNew.FunctionMap.Add(0, new Action(this.LeaveInstanceDungeon));
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			}
		}

		// Token: 0x06041BA5 RID: 269221 RVA: 0x010DAD9C File Offset: 0x010D8F9C
		public bool CheckInMotorFightDungeon()
		{
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
				InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
				return config != null && config.GetValueOrDefault().InstSubType == 44;
			}
			return false;
		}

		// Token: 0x04024AC2 RID: 150210
		[Nullable(2)]
		private MotorFightActivityData MotorFightActivityData;

		// Token: 0x04024AC3 RID: 150211
		public bool IsNeedShowMotorFightMainView;

		// Token: 0x04024AC4 RID: 150212
		private int LastLevelId;

		// Token: 0x04024AC5 RID: 150213
		private int LastMotorFightRoleId;

		// Token: 0x04024AC6 RID: 150214
		private int LastRealRoleId;
	}
}

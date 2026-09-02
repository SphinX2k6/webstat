using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Render.RuntimeBP.Interaction;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001321 RID: 4897
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class FightPhotoController : ActivityControllerBase<FightPhotoController>
{
	// Token: 0x06008590 RID: 34192 RVA: 0x0023283B File Offset: 0x00230A3B
	[NullableContext(2)]
	public BP_CameraShot_C GetCameraShotActor()
	{
		return this.CameraShotActor;
	}

	// Token: 0x06008591 RID: 34193 RVA: 0x00232843 File Offset: 0x00230A43
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<PhotoFightResultNotify>(ENotifyMessageId.PhotoFightResultNotify, new Action<PhotoFightResultNotify, Net.CallbackStatus>(this.OnTaskInfoUpdate));
		Singleton<Net>.Instance.Register<PhotoFightLevelInfoNotify>(ENotifyMessageId.PhotoFightLevelInfoNotify, new Action<PhotoFightLevelInfoNotify, Net.CallbackStatus>(this.OnLevelInfoUpdate));
	}

	// Token: 0x06008592 RID: 34194 RVA: 0x0023287D File Offset: 0x00230A7D
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhotoFightResultNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhotoFightLevelInfoNotify);
	}

	// Token: 0x06008593 RID: 34195 RVA: 0x002328A0 File Offset: 0x00230AA0
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add(EEventName.ActiveBattleView, new Action(this.OnActiveBattleView));
		Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
	}

	// Token: 0x06008594 RID: 34196 RVA: 0x00232904 File Offset: 0x00230B04
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.ActiveBattleView, new Action(this.OnActiveBattleView));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
	}

	// Token: 0x06008595 RID: 34197 RVA: 0x00232965 File Offset: 0x00230B65
	protected override void OnOpenView(ActivityBaseData data)
	{
		throw new Exception("Method not implemented.");
	}

	// Token: 0x06008596 RID: 34198 RVA: 0x00232971 File Offset: 0x00230B71
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityBattlePhoto";
	}

	// Token: 0x06008597 RID: 34199 RVA: 0x00232978 File Offset: 0x00230B78
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new FightPhotoActivitySubView();
	}

	// Token: 0x06008598 RID: 34200 RVA: 0x00232980 File Offset: 0x00230B80
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		FightPhotoActivityData fightPhotoActivityData = new FightPhotoActivityData();
		this.FightPhotoActivityData = fightPhotoActivityData;
		return fightPhotoActivityData;
	}

	// Token: 0x06008599 RID: 34201 RVA: 0x0023299C File Offset: 0x00230B9C
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		foreach (EUiViewName viewName in new EUiViewName[]
		{
			EUiViewName.FightPhotoMainView,
			EUiViewName.FightPhotoRewardView
		})
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(viewName))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600859A RID: 34202 RVA: 0x002329EE File Offset: 0x00230BEE
	public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FightPhotoUnlockTipView, null, null);
	}

	// Token: 0x0600859B RID: 34203 RVA: 0x00232A04 File Offset: 0x00230C04
	[NullableContext(0)]
	protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
	{
		FightPhotoController.<OnOpenSubView>d__18 <OnOpenSubView>d__;
		<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OnOpenSubView>d__.<>4__this = this;
		<OnOpenSubView>d__.viewName = viewName;
		<OnOpenSubView>d__.<>1__state = -1;
		<OnOpenSubView>d__.<>t__builder.Start<FightPhotoController.<OnOpenSubView>d__18>(ref <OnOpenSubView>d__);
		return <OnOpenSubView>d__.<>t__builder.Task;
	}

	// Token: 0x0600859C RID: 34204 RVA: 0x00232A50 File Offset: 0x00230C50
	[NullableContext(2)]
	public FightPhotoActivityData GetActivityData()
	{
		if (this.FightPhotoActivityData == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FightPhotograph, ELogAuthor.CXJ, "战斗拍照活动数据为空", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		return this.FightPhotoActivityData;
	}

	// Token: 0x0600859D RID: 34205 RVA: 0x00232A8A File Offset: 0x00230C8A
	private void OnTaskInfoUpdate(PhotoFightResultNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		this.FightPhotoActivityData.UpdateTaskData(notify.Targets);
	}

	// Token: 0x0600859E RID: 34206 RVA: 0x00232A9D File Offset: 0x00230C9D
	private void OnLevelInfoUpdate(PhotoFightLevelInfoNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		this.FightPhotoActivityData.UpdateLevelData(notify.PhotoFightLevelInfos, false);
	}

	// Token: 0x0600859F RID: 34207 RVA: 0x00232AB4 File Offset: 0x00230CB4
	public UniTask EnterFightPhotoDungeonDirectly(int activityId, int levelId, int instanceId, int[] roleIds)
	{
		FightPhotoController.<EnterFightPhotoDungeonDirectly>d__22 <EnterFightPhotoDungeonDirectly>d__;
		<EnterFightPhotoDungeonDirectly>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<EnterFightPhotoDungeonDirectly>d__.<>4__this = this;
		<EnterFightPhotoDungeonDirectly>d__.activityId = activityId;
		<EnterFightPhotoDungeonDirectly>d__.levelId = levelId;
		<EnterFightPhotoDungeonDirectly>d__.instanceId = instanceId;
		<EnterFightPhotoDungeonDirectly>d__.roleIds = roleIds;
		<EnterFightPhotoDungeonDirectly>d__.<>1__state = -1;
		<EnterFightPhotoDungeonDirectly>d__.<>t__builder.Start<FightPhotoController.<EnterFightPhotoDungeonDirectly>d__22>(ref <EnterFightPhotoDungeonDirectly>d__);
		return <EnterFightPhotoDungeonDirectly>d__.<>t__builder.Task;
	}

	// Token: 0x060085A0 RID: 34208 RVA: 0x00232B18 File Offset: 0x00230D18
	public void RequestTaskReward(int[] taskIds)
	{
		FightPhotoActivityData activityData = this.GetActivityData();
		PhotoFightTaskRewardRequest photoFightTaskRewardRequest = PhotoFightTaskRewardRequest.Create();
		photoFightTaskRewardRequest.TargetIds.AddRange(taskIds);
		photoFightTaskRewardRequest.ActivityId = activityData.Id;
		Singleton<Net>.Instance.Call<PhotoFightTaskRewardResponse>(ERequestMessageId.PhotoFightTaskRewardRequest, photoFightTaskRewardRequest, delegate(PhotoFightTaskRewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26115, null, true, true);
				return;
			}
			activityData.UpdateTaskRewardStatus(response.Targets);
		}, 0);
	}

	// Token: 0x060085A1 RID: 34209 RVA: 0x00232B78 File Offset: 0x00230D78
	public void RequestInstanceSettle()
	{
		PhotoFightSettleRequest message = PhotoFightSettleRequest.Create();
		Singleton<Net>.Instance.Call<PhotoFightSettleResponse>(ERequestMessageId.PhotoFightSettleRequest, message, delegate(PhotoFightSettleResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18908, null, true, true);
			}
		}, 0);
	}

	// Token: 0x060085A2 RID: 34210 RVA: 0x00232BBC File Offset: 0x00230DBC
	public bool CheckInFightPhotoDungeon()
	{
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			return config != null && config.GetValueOrDefault().InstSubType == 42;
		}
		return false;
	}

	// Token: 0x060085A3 RID: 34211 RVA: 0x00232C0C File Offset: 0x00230E0C
	private void OnActiveBattleView()
	{
		if (this.FightPhotoActivityData == null)
		{
			return;
		}
		if (this.CheckInFightPhotoDungeon())
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FightPhotoFocusView, null, null);
			int currentStepCount = this.GetCurrentStepCount();
			if (currentStepCount < 3 && this.StepCount < currentStepCount)
			{
				this.StepCount = currentStepCount;
				this.ShowFightPhotoTips(this.StepTextIdList[currentStepCount]);
			}
		}
	}

	// Token: 0x060085A4 RID: 34212 RVA: 0x00232C64 File Offset: 0x00230E64
	public void LeaveInstanceDungeon(bool needRequestLeave = true)
	{
		if (this.CheckInFightPhotoDungeon())
		{
			if (this.EnterDungeonTimestampMs > 0L)
			{
				this.ReportFightPhotoDuration();
				this.EnterDungeonTimestampMs = 0L;
			}
			ModelBase<PhotographModel>.Instance.SetPhotographTimeDilation(1f);
			Singleton<AudioSystem>.Instance.SetState("game_sys_fightphoto", "none", true);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.ForceNoPerBoneMotionBlur 0", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "fx.Niagara.FixScaleZeroProblem 0", null);
			ControllerBase<PhotographController>.Instance.ClearAllSavedFightPhotos();
			if (this.CameraShotActor != null)
			{
				Singleton<ActorSystem>.Instance.Put("FightPhotoController.LeaveInstanceDungeon", this.CameraShotActor, null);
				this.CameraShotActor = null;
			}
			if (needRequestLeave)
			{
				if (this.FightPhotoActivityData != null && !this.FightPhotoActivityData.CheckIfClose())
				{
					this.FightPhotoActivityData.IsNeedShowFightPhotoMainView = true;
				}
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Default);
			}
			this.StepCount = 0;
		}
	}

	// Token: 0x060085A5 RID: 34213 RVA: 0x00232D3F File Offset: 0x00230F3F
	public void AddColorAdjustDuration(long time)
	{
		if (time > 0L)
		{
			this.ColorAdjustDurationMs += time;
		}
	}

	// Token: 0x060085A6 RID: 34214 RVA: 0x00232D54 File Offset: 0x00230F54
	private void ReportFightPhotoDuration()
	{
		FightPhotoActivityData activityData = this.GetActivityData();
		FightPhotoLevelData fightPhotoLevelData = (activityData != null) ? activityData.GetCurrentLevelData(true) : null;
		if (fightPhotoLevelData == null)
		{
			return;
		}
		FightPhotoDurationLogEvent fightPhotoDurationLogEvent = new FightPhotoDurationLogEvent();
		fightPhotoDurationLogEvent.i_total_duration = (int)Math.Floor((double)(DateTimeOffset.Now.ToUnixTimeMilliseconds() - this.EnterDungeonTimestampMs) / 1000.0);
		fightPhotoDurationLogEvent.i_add_time = (int)Math.Floor((double)this.ColorAdjustDurationMs / 1000.0);
		List<int> roleIdList = fightPhotoLevelData.GetRoleIdList();
		fightPhotoDurationLogEvent.o_team_character = new List<int>(roleIdList);
		Span<int> trialRoleList = fightPhotoLevelData.TrialRoleList;
		List<FightPhotoTeamSkinData> list = new List<FightPhotoTeamSkinData>();
		foreach (int num in roleIdList)
		{
			list.Add(new FightPhotoTeamSkinData
			{
				skin_id = ModelBase<RoleSkinModel>.Instance.GetRoleSkinIdByRoleId(num),
				is_trial = ((trialRoleList.Contains(num) > false) ? 1 : 0)
			});
		}
		fightPhotoDurationLogEvent.o_team_suit = list;
		fightPhotoDurationLogEvent.i_result = ControllerBase<PhotographController>.Instance.GetSavedFightPhotos().Count;
		fightPhotoDurationLogEvent.i_inst_id = fightPhotoLevelData.InstanceId;
		fightPhotoDurationLogEvent.i_inst_diff = ((fightPhotoLevelData.IsDifficulty > false) ? 1 : 0);
		fightPhotoDurationLogEvent.s_trace_id = ModelBase<CreatureModel>.Instance.GetSceneTraceId().ToString();
		ControllerBase<LogReportController>.Instance.LogReport(fightPhotoDurationLogEvent);
	}

	// Token: 0x060085A7 RID: 34215 RVA: 0x00232EBC File Offset: 0x002310BC
	private void OnWorldDone()
	{
		if (this.FightPhotoActivityData != null && this.FightPhotoActivityData.IsNeedShowFightPhotoMainView)
		{
			this.AddMainViewSplashTask();
		}
		if (this.CheckInFightPhotoDungeon())
		{
			this.EnterDungeonTimestampMs = DateTimeOffset.Now.ToUnixTimeMilliseconds();
			this.ColorAdjustDurationMs = 0L;
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.ForceNoPerBoneMotionBlur 1", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "fx.Niagara.FixScaleZeroProblem 1", null);
			ModelBase<FightPhotoModel>.Instance.InitDefaultSetupOption();
			if (this.CameraShotActor != null)
			{
				Singleton<ActorSystem>.Instance.Put("FightPhotoController.OnWorldDone", this.CameraShotActor, null);
				this.CameraShotActor = null;
			}
			this.CameraShotActor = (Singleton<ActorSystem>.Instance.Get(BP_CameraShot_C.StaticClass(), new FTransformDouble(), null, true) as BP_CameraShot_C);
		}
	}

	// Token: 0x060085A8 RID: 34216 RVA: 0x00232F7C File Offset: 0x0023117C
	private void AddMainViewSplashTask()
	{
		SplashScreenTask splashScreenTask = new SplashScreenTask(ESplashScreenSourceModuleType.None, ESplashScreenType.Other, delegate()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FightPhotoMainView, this.FightPhotoActivityData, null);
		});
		ControllerBase<SplashScreenController>.Instance.PushSplashScreenTask(splashScreenTask, false);
	}

	// Token: 0x060085A9 RID: 34217 RVA: 0x00232FA9 File Offset: 0x002311A9
	private int GetCurrentStepCount()
	{
		return ControllerBase<PhotographController>.Instance.GetSavedFightPhotos().Count;
	}

	// Token: 0x060085AA RID: 34218 RVA: 0x00232FBC File Offset: 0x002311BC
	public void ShowFightPhotoTips(string textId)
	{
		if (Array.IndexOf<string>(this.StepTextIdList, textId) >= 0 && !Singleton<UiManager>.Instance.IsViewShow(EUiViewName.BattleView))
		{
			return;
		}
		TableTextArgNew mainTextObj = new TableTextArgNew(textId, Array.Empty<object>());
		ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType<object>(EPromptSubViewType.FightPhotoEventTip, mainTextObj, null, null, null, null, null, null, null, false, null);
	}

	// Token: 0x060085AB RID: 34219 RVA: 0x0023301C File Offset: 0x0023121C
	private void OnActivityClose(IReadOnlySet<int> closeActivities)
	{
		if (this.FightPhotoActivityData == null)
		{
			return;
		}
		if (closeActivities.Contains(this.FightPhotoActivityData.Id) && this.CheckInFightPhotoDungeon())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.FightPhotoActivityEnd);
			confirmBoxDataNew.FunctionMap[1] = new Action(this.<OnActivityClose>g__confirmCallback|34_0);
			confirmBoxDataNew.FunctionMap[0] = new Action(this.<OnActivityClose>g__confirmCallback|34_0);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}
	}

	// Token: 0x060085AE RID: 34222 RVA: 0x002330D8 File Offset: 0x002312D8
	[CompilerGenerated]
	private void <OnActivityClose>g__confirmCallback|34_0()
	{
		this.LeaveInstanceDungeon(true);
	}

	// Token: 0x04003F2E RID: 16174
	public readonly string[] StepTextIdList = new string[]
	{
		"PhotographicTipMainText_01",
		"PhotographicTipMainText_02",
		"PhotographicTipMainText_03"
	};

	// Token: 0x04003F2F RID: 16175
	private const int MAX_STEP_NUM = 3;

	// Token: 0x04003F30 RID: 16176
	[Nullable(2)]
	private FightPhotoActivityData FightPhotoActivityData;

	// Token: 0x04003F31 RID: 16177
	private int StepCount;

	// Token: 0x04003F32 RID: 16178
	private long EnterDungeonTimestampMs;

	// Token: 0x04003F33 RID: 16179
	private long ColorAdjustDurationMs;

	// Token: 0x04003F34 RID: 16180
	[Nullable(2)]
	private BP_CameraShot_C CameraShotActor;
}

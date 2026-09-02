using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B89 RID: 11145
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class SurvivorsRogueController : UiControllerBase<SurvivorsRogueController>
{
	// Token: 0x06016323 RID: 90915 RVA: 0x00628488 File Offset: 0x00626688
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<SurvivorsInstGlobalDataNotify>(ENotifyMessageId.SurvivorsInstGlobalDataNotify, new Action<SurvivorsInstGlobalDataNotify, Net.CallbackStatus>(this.OnSurvivorsInstGlobalDataNotify));
		Singleton<Net>.Instance.Register<SurvivorsGainDataUpdateNotify>(ENotifyMessageId.SurvivorsGainDataUpdateNotify, new Action<SurvivorsGainDataUpdateNotify, Net.CallbackStatus>(this.OnSurvivorsGainDataUpdateNotify));
		Singleton<Net>.Instance.Register<SurvivorsOpDataUpdateNotify>(ENotifyMessageId.SurvivorsOpDataUpdateNotify, new Action<SurvivorsOpDataUpdateNotify, Net.CallbackStatus>(this.OnSurvivorsOpDataUpdateNotify));
		Singleton<Net>.Instance.Register<SurvivorsOpDataForceChangeNotify>(ENotifyMessageId.SurvivorsOpDataForceChangeNotify, new Action<SurvivorsOpDataForceChangeNotify, Net.CallbackStatus>(this.OnSurvivorsOpDataForceChangeNotify));
		Singleton<Net>.Instance.Register<SurvivorsStepUpdateNotify>(ENotifyMessageId.SurvivorsStepUpdateNotify, new Action<SurvivorsStepUpdateNotify, Net.CallbackStatus>(this.OnSurvivorsStepUpdateNotify));
		Singleton<Net>.Instance.Register<SurvivorsVarRecordNotify>(ENotifyMessageId.SurvivorsVarRecordNotify, new Action<SurvivorsVarRecordNotify, Net.CallbackStatus>(this.OnSurvivorsVarRecordNotify));
		Singleton<Net>.Instance.Register<SurvivorsComboParamUpdateNotify>(ENotifyMessageId.SurvivorsComboParamUpdateNotify, new Action<SurvivorsComboParamUpdateNotify, Net.CallbackStatus>(this.OnSurvivorsComboParamUpdateNotify));
	}

	// Token: 0x06016324 RID: 90916 RVA: 0x0062855C File Offset: 0x0062675C
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SurvivorsInstGlobalDataNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SurvivorsGainDataUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SurvivorsOpDataUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SurvivorsOpDataForceChangeNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SurvivorsStepUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SurvivorsVarRecordNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SurvivorsComboParamUpdateNotify);
	}

	// Token: 0x06016325 RID: 90917 RVA: 0x006285D9 File Offset: 0x006267D9
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnInstanceChange, new Action<int, int>(this.OnInstanceChange));
	}

	// Token: 0x06016326 RID: 90918 RVA: 0x00628613 File Offset: 0x00626813
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnInstanceChange, new Action<int, int>(this.OnInstanceChange));
	}

	// Token: 0x06016327 RID: 90919 RVA: 0x0062864D File Offset: 0x0062684D
	protected override void OnAddOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.SurvivorsTabMainView, new Func<EUiViewName, object, bool>(this.CanOpenSurvivorsTabMainView), "SurvivorsRogueController.CanOpenSurvivorsTabMainView");
	}

	// Token: 0x06016328 RID: 90920 RVA: 0x0062866F File Offset: 0x0062686F
	protected override void OnRemoveOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.SurvivorsTabMainView, new Func<EUiViewName, object, bool>(this.CanOpenSurvivorsTabMainView));
	}

	// Token: 0x06016329 RID: 90921 RVA: 0x0062868C File Offset: 0x0062688C
	[NullableContext(2)]
	private bool CanOpenSurvivorsTabMainView(EUiViewName viewName, object param)
	{
		KscSubModelBase curSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel;
		AKSC_Entity aksc_Entity = (curSubModel != null) ? curSubModel.KscPlayerEntity : null;
		if (aksc_Entity == null)
		{
			return false;
		}
		UKSC_SkillComp skillComp = aksc_Entity.GetSkillComp();
		bool result;
		if (skillComp == null)
		{
			result = (null != null);
		}
		else
		{
			UKSC_AttrSet attrSet_ = skillComp.AttrSet_;
			result = (((attrSet_ != null) ? attrSet_.Attrs_ : null) != null);
		}
		return result;
	}

	// Token: 0x0601632A RID: 90922 RVA: 0x006286D8 File Offset: 0x006268D8
	private void OnSurvivorsInstGlobalDataNotify(SurvivorsInstGlobalDataNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<SurvivorsRogueModel>.Instance.CurLevelId = notify.LevelId;
		ModelBase<SurvivorsRogueModel>.Instance.InitComboEnhanceCfg(notify.ComboParamInfos);
		ModelBase<SurvivorsRogueModel>.Instance.GainData.InitGain(notify.SurvivorsGainDatas, notify.WeaponMaxCount, notify.UnlockWeaponWave);
		ModelBase<SurvivorsRogueModel>.Instance.InitCommandQueue();
		SurvivorsRogueCommandQueue commandQueue = ModelBase<SurvivorsRogueModel>.Instance.CommandQueue;
		commandQueue.SetForegroundIncId(notify.ForceIncId);
		commandQueue.InitCommands(notify.SurvivorsOpDatas);
	}

	// Token: 0x0601632B RID: 90923 RVA: 0x00628751 File Offset: 0x00626951
	private void OnSurvivorsVarRecordNotify(SurvivorsVarRecordNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<SurvivorsRogueModel>.Instance.BattleData.SetBehaviorTreeVar(notify.VariableKeyNames.ToDictionary<string, string>());
	}

	// Token: 0x0601632C RID: 90924 RVA: 0x00628770 File Offset: 0x00626970
	private void OnSurvivorsGainDataUpdateNotify(SurvivorsGainDataUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		SurvivorsRogueGainData gainData = ModelBase<SurvivorsRogueModel>.Instance.GainData;
		for (int i = 0; i < notify.Adds.Count; i++)
		{
			gainData.AddGain(notify.Adds[i]);
		}
		for (int j = 0; j < notify.Updates.Count; j++)
		{
			gainData.UpdateGain(notify.Updates[j]);
		}
		for (int k = 0; k < notify.Removes.Count; k++)
		{
			gainData.RemoveGain(notify.Removes[k]);
		}
	}

	// Token: 0x0601632D RID: 90925 RVA: 0x00628800 File Offset: 0x00626A00
	private void OnSurvivorsOpDataUpdateNotify(SurvivorsOpDataUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		SurvivorsRogueCommandQueue commandQueue = ModelBase<SurvivorsRogueModel>.Instance.CommandQueue;
		if (commandQueue == null)
		{
			return;
		}
		commandQueue.SetForegroundIncId(notify.ForceIncId);
		for (int i = 0; i < notify.Adds.Count; i++)
		{
			commandQueue.AddCommand(notify.Adds[i]);
		}
		for (int j = 0; j < notify.Updates.Count; j++)
		{
			commandQueue.UpdateCommand(notify.Updates[j]);
		}
		for (int k = 0; k < notify.Removes.Count; k++)
		{
			commandQueue.RemoveCommand(notify.Removes[k]);
		}
		commandQueue.StartForegroundCommand();
	}

	// Token: 0x0601632E RID: 90926 RVA: 0x006288A8 File Offset: 0x00626AA8
	private void OnSurvivorsOpDataForceChangeNotify(SurvivorsOpDataForceChangeNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		SurvivorsRogueCommandQueue commandQueue = ModelBase<SurvivorsRogueModel>.Instance.CommandQueue;
		if (commandQueue == null)
		{
			return;
		}
		commandQueue.SetForegroundIncId(notify.ForceIncId);
		commandQueue.StartForegroundCommand();
	}

	// Token: 0x0601632F RID: 90927 RVA: 0x006288D6 File Offset: 0x00626AD6
	private void OnSurvivorsStepUpdateNotify(SurvivorsStepUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		if (notify.PrepareStepPbData != null)
		{
			ModelBase<SurvivorsRogueModel>.Instance.WaveTipsState = SurvivorsRogueModel.EWaveTipsState.PopWaveTips;
			return;
		}
		if (notify.CombatStepPbData != null)
		{
			ModelBase<SurvivorsRogueModel>.Instance.WaveTipsState = SurvivorsRogueModel.EWaveTipsState.ResidentWaveTips;
			return;
		}
		if (notify.EndStepPbData != null)
		{
			ModelBase<SurvivorsRogueModel>.Instance.WaveTipsState = SurvivorsRogueModel.EWaveTipsState.WaveCompleteTips;
		}
	}

	// Token: 0x06016330 RID: 90928 RVA: 0x00628913 File Offset: 0x00626B13
	private void OnSurvivorsComboParamUpdateNotify(SurvivorsComboParamUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<SurvivorsRogueModel>.Instance.InitComboEnhanceCfg(notify.ComboParamInfos);
	}

	// Token: 0x06016331 RID: 90929 RVA: 0x00628928 File Offset: 0x00626B28
	private void OnWorldDone()
	{
		if (ModelBase<SurvivorsRogueModel>.Instance.NeedOpenActivityMainView)
		{
			this.AddMainViewSplashTask();
		}
		if (!this.CheckInSurvivorsRogueInstance())
		{
			return;
		}
		SurvivorsRogueCommandQueue commandQueue = ModelBase<SurvivorsRogueModel>.Instance.CommandQueue;
		if (commandQueue == null)
		{
			return;
		}
		commandQueue.StartForegroundCommand();
	}

	// Token: 0x06016332 RID: 90930 RVA: 0x00628968 File Offset: 0x00626B68
	private void OnInstanceChange(int lastInstanceId, int newInstanceId)
	{
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(newInstanceId);
		if (config != null && config.Value.InstSubType == 41)
		{
			ControllerBase<SkillButtonUiController>.Instance.AddEventInterface(ModelBase<SurvivorsRogueModel>.Instance.BattleData);
			return;
		}
		ControllerBase<SkillButtonUiController>.Instance.RemoveEventInterface(ModelBase<SurvivorsRogueModel>.Instance.BattleData);
	}

	// Token: 0x06016333 RID: 90931 RVA: 0x006289C8 File Offset: 0x00626BC8
	private void AddMainViewSplashTask()
	{
		SplashScreenTask splashScreenTask = new SplashScreenTask(ESplashScreenSourceModuleType.None, ESplashScreenType.Other, delegate()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsRogueMainView, null, null);
		});
		ControllerBase<SplashScreenController>.Instance.PushSplashScreenTask(splashScreenTask, false);
	}

	// Token: 0x06016334 RID: 90932 RVA: 0x00628A08 File Offset: 0x00626C08
	public void RequestEnterStep(ESurvivorsStepType stepType)
	{
		SurvivorsStepAdvanceRequest survivorsStepAdvanceRequest = SurvivorsStepAdvanceRequest.Create();
		if (stepType == ESurvivorsStepType.Prepare)
		{
			survivorsStepAdvanceRequest.PrepareStepPbData = SurvivorsPrepareStepPbData.Create();
		}
		else if (stepType == ESurvivorsStepType.End)
		{
			survivorsStepAdvanceRequest.EndStepPbData = SurvivorsEndStepPbData.Create();
		}
		Singleton<Net>.Instance.Call<SurvivorsStepAdvanceResponse>(ERequestMessageId.SurvivorsStepAdvanceRequest, survivorsStepAdvanceRequest, delegate(SurvivorsStepAdvanceResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 18797, null, true, true);
			}
		}, 0);
	}

	// Token: 0x06016335 RID: 90933 RVA: 0x00628A6C File Offset: 0x00626C6C
	public void RequestCommandOperation(int commandIncId, List<int> operationIds, [Nullable(2)] Action<bool> callback = null)
	{
		SurvivorsOpDoneRequest survivorsOpDoneRequest = SurvivorsOpDoneRequest.Create();
		survivorsOpDoneRequest.IncId = commandIncId;
		survivorsOpDoneRequest.ClientSelectIds.AddRange(operationIds);
		Singleton<Net>.Instance.Call<SurvivorsOpDoneResponse>(ERequestMessageId.SurvivorsOpDoneRequest, survivorsOpDoneRequest, delegate(SurvivorsOpDoneResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(false);
				return;
			}
			else if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 25842, null, true, true);
				Action<bool> callback3 = callback;
				if (callback3 == null)
				{
					return;
				}
				callback3(false);
				return;
			}
			else
			{
				Action<bool> callback4 = callback;
				if (callback4 == null)
				{
					return;
				}
				callback4(true);
				return;
			}
		}, 0);
	}

	// Token: 0x06016336 RID: 90934 RVA: 0x00628ABC File Offset: 0x00626CBC
	[NullableContext(2)]
	public void RequestDataLock(int commandIncId, int dataIncId, bool isLock, Action<bool> callback = null)
	{
		SurvivorsLockRequest survivorsLockRequest = SurvivorsLockRequest.Create();
		survivorsLockRequest.IncId = commandIncId;
		survivorsLockRequest.IsLock = isLock;
		survivorsLockRequest.ClientSelectId = dataIncId;
		Singleton<Net>.Instance.Call<SurvivorsLockResponse>(ERequestMessageId.SurvivorsLockRequest, survivorsLockRequest, delegate(SurvivorsLockResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(false);
				return;
			}
			else if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 15234, null, true, true);
				Action<bool> callback3 = callback;
				if (callback3 == null)
				{
					return;
				}
				callback3(false);
				return;
			}
			else
			{
				Action<bool> callback4 = callback;
				if (callback4 == null)
				{
					return;
				}
				callback4(true);
				return;
			}
		}, 0);
	}

	// Token: 0x06016337 RID: 90935 RVA: 0x00628B10 File Offset: 0x00626D10
	public void RequestEnterInst(int levelId, int survivorRoleId, int weaponId, bool isInfinite, bool isContinue)
	{
		SurvivorsLevel? survivorsLevel = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsLevel(levelId);
		if (survivorsLevel == null)
		{
			return;
		}
		Aki.Config.SurvivorsRole? survivorsRole = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRole(survivorRoleId);
		if (survivorsRole == null)
		{
			return;
		}
		SurvivorsCtx survivorsCtx = SurvivorsCtx.Create();
		survivorsCtx.Continue = isContinue;
		survivorsCtx.LevelId = levelId;
		survivorsCtx.InfiniteMode = isInfinite;
		survivorsCtx.WeaponId = weaponId;
		survivorsCtx.RoleId = survivorRoleId;
		ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.SurvivorsCtx = survivorsCtx;
		ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(survivorsLevel.Value.InstId, new List<int>
		{
			survivorsRole.Value.TrialRoleId
		}, 0, 0, null, null);
	}

	// Token: 0x06016338 RID: 90936 RVA: 0x00628BC0 File Offset: 0x00626DC0
	public void RequestInstSettle(bool openSettleView)
	{
		SurvivorsResultRequest message = SurvivorsResultRequest.Create();
		Singleton<Net>.Instance.Call<SurvivorsResultResponse>(ERequestMessageId.SurvivorsResultRequest, message, delegate(SurvivorsResultResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.SurvivorsInstSettle, false);
				return;
			}
			if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 21090, null, true, true);
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.SurvivorsInstSettle, false);
				return;
			}
			if (openSettleView && response.ResultView != null)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsRogueSettleExternalView, response.ResultView, null);
				ModelBase<SurvivorsRogueModel>.Instance.SelectLevelInfo = null;
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.SurvivorsInstSettle, true);
		}, 0);
	}

	// Token: 0x06016339 RID: 90937 RVA: 0x00628C00 File Offset: 0x00626E00
	public UniTask RequestWeaponInfoUpdate()
	{
		SurvivorsRogueController.<RequestWeaponInfoUpdate>d__22 <RequestWeaponInfoUpdate>d__;
		<RequestWeaponInfoUpdate>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestWeaponInfoUpdate>d__.<>1__state = -1;
		<RequestWeaponInfoUpdate>d__.<>t__builder.Start<SurvivorsRogueController.<RequestWeaponInfoUpdate>d__22>(ref <RequestWeaponInfoUpdate>d__);
		return <RequestWeaponInfoUpdate>d__.<>t__builder.Task;
	}

	// Token: 0x0601633A RID: 90938 RVA: 0x00628C3C File Offset: 0x00626E3C
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public UniTask<SurvivorsActivityDefine.SurvivorsLevelInfo> RequestLastFile()
	{
		SurvivorsRogueController.<RequestLastFile>d__23 <RequestLastFile>d__;
		<RequestLastFile>d__.<>t__builder = AsyncUniTaskMethodBuilder<SurvivorsActivityDefine.SurvivorsLevelInfo>.Create();
		<RequestLastFile>d__.<>1__state = -1;
		<RequestLastFile>d__.<>t__builder.Start<SurvivorsRogueController.<RequestLastFile>d__23>(ref <RequestLastFile>d__);
		return <RequestLastFile>d__.<>t__builder.Task;
	}

	// Token: 0x0601633B RID: 90939 RVA: 0x00628C78 File Offset: 0x00626E78
	public void RequestEnterInstByLevelInfo()
	{
		SurvivorsActivityDefine.SurvivorsLevelInfo selectLevelInfo = ModelBase<SurvivorsRogueModel>.Instance.SelectLevelInfo;
		if (selectLevelInfo == null)
		{
			return;
		}
		Aki.Config.SurvivorsRole? survivorsRole = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRole(selectLevelInfo.RoleId);
		if (survivorsRole == null)
		{
			return;
		}
		this.RequestEnterInst(selectLevelInfo.LevelId, selectLevelInfo.RoleId, survivorsRole.Value.InitWeapon, selectLevelInfo.IsEndless, selectLevelInfo.IsSaveFile);
	}

	// Token: 0x0601633C RID: 90940 RVA: 0x00628CDC File Offset: 0x00626EDC
	public bool CheckInSurvivorsRogueInstance()
	{
		if (!ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			return false;
		}
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
		return config != null && config.Value.InstSubType == 41;
	}

	// Token: 0x0601633D RID: 90941 RVA: 0x00628D30 File Offset: 0x00626F30
	public void OpenLeaveInstanceView()
	{
		int batch = ModelBase<SurvivorsRogueModel>.Instance.BattleData.GetBatch();
		int maxBatch = ModelBase<SurvivorsRogueModel>.Instance.BattleData.GetMaxBatch();
		SurvivorsExitViewParams param = new SurvivorsExitViewParams
		{
			IsExternal = false,
			Batch = batch,
			MaxBatch = maxBatch
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsRogueExitView, param, null);
	}

	// Token: 0x0601633E RID: 90942 RVA: 0x00628D89 File Offset: 0x00626F89
	public void LeaveRogueInstance()
	{
		ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Default).ContinueWith(delegate(bool success)
		{
			if (success)
			{
				ModelBase<SurvivorsRogueModel>.Instance.ClearGlobal();
			}
		});
	}

	// Token: 0x0601633F RID: 90943 RVA: 0x00628DBC File Offset: 0x00626FBC
	public void OpenRogueHelp()
	{
		SurvivorsActivityConfig? survivorsActivityConfig;
		int? num = (ModelBase<SurvivorsRogueModel>.Instance.GetRogueActivityConfig() != null) ? new int?(survivorsActivityConfig.GetValueOrDefault().HelpId) : null;
		if (num == null)
		{
			return;
		}
		ControllerBase<HelpController>.Instance.OpenHelpById(num.Value);
	}

	// Token: 0x06016340 RID: 90944 RVA: 0x00628E18 File Offset: 0x00627018
	public void OpenEnterInstConfirm()
	{
		if (ModelBase<SurvivorsRogueModel>.Instance.ActivityData.NotTipsEnterInst)
		{
			this.RequestEnterInstByLevelInfo();
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.SurvivorsEnterInstConfirm);
		confirmBoxDataNew.FunctionMap[1] = delegate()
		{
		};
		confirmBoxDataNew.FunctionMap[2] = new Action(this.RequestEnterInstByLevelInfo);
		confirmBoxDataNew.HasToggle = true;
		confirmBoxDataNew.ToggleTextKey = "SurvivorsRoleConfirmationDialog_PrompText";
		confirmBoxDataNew.SetToggleFunction(delegate(bool isSelectOn)
		{
			ModelBase<SurvivorsRogueModel>.Instance.ActivityData.NotTipsEnterInst = isSelectOn;
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06016341 RID: 90945 RVA: 0x00628ED0 File Offset: 0x006270D0
	[NullableContext(0)]
	public UniTask<bool> TryOpenWeaponUnlockView()
	{
		SurvivorsRogueController.<TryOpenWeaponUnlockView>d__30 <TryOpenWeaponUnlockView>d__;
		<TryOpenWeaponUnlockView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<TryOpenWeaponUnlockView>d__.<>1__state = -1;
		<TryOpenWeaponUnlockView>d__.<>t__builder.Start<SurvivorsRogueController.<TryOpenWeaponUnlockView>d__30>(ref <TryOpenWeaponUnlockView>d__);
		return <TryOpenWeaponUnlockView>d__.<>t__builder.Task;
	}
}

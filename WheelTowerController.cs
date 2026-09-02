using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.View.Season;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001709 RID: 5897
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class WheelTowerController : ActivityControllerBase<WheelTowerController>
{
	// Token: 0x17000D91 RID: 3473
	// (get) Token: 0x0600A371 RID: 41841 RVA: 0x002B2B08 File Offset: 0x002B0D08
	// (set) Token: 0x0600A372 RID: 41842 RVA: 0x002B2B10 File Offset: 0x002B0D10
	public bool IsShowOldView { get; set; }

	// Token: 0x0600A373 RID: 41843 RVA: 0x002B2B19 File Offset: 0x002B0D19
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x0600A374 RID: 41844 RVA: 0x002B2B1B File Offset: 0x002B0D1B
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		if (!this.IsShowOldView)
		{
			return "UiView_MowingTowerActivityMain32";
		}
		return "UiItem_WheelTowerActivity";
	}

	// Token: 0x0600A375 RID: 41845 RVA: 0x002B2B30 File Offset: 0x002B0D30
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		if (!this.IsShowOldView)
		{
			return new WheelTowerNewSubView();
		}
		return new WheelTowerSubView();
	}

	// Token: 0x0600A376 RID: 41846 RVA: 0x002B2B45 File Offset: 0x002B0D45
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new WheelTowerData();
	}

	// Token: 0x0600A377 RID: 41847 RVA: 0x002B2B4C File Offset: 0x002B0D4C
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x0600A378 RID: 41848 RVA: 0x002B2B50 File Offset: 0x002B0D50
	[NullableContext(0)]
	protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
	{
		WheelTowerController.<OnOpenSubView>d__11 <OnOpenSubView>d__;
		<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OnOpenSubView>d__.viewName = viewName;
		<OnOpenSubView>d__.<>1__state = -1;
		<OnOpenSubView>d__.<>t__builder.Start<WheelTowerController.<OnOpenSubView>d__11>(ref <OnOpenSubView>d__);
		return <OnOpenSubView>d__.<>t__builder.Task;
	}

	// Token: 0x0600A379 RID: 41849 RVA: 0x002B2B93 File Offset: 0x002B0D93
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add(EEventName.WheelTowerCycleChange, new Action(this.OnWheelTowerCycleChange));
	}

	// Token: 0x0600A37A RID: 41850 RVA: 0x002B2BCD File Offset: 0x002B0DCD
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.WheelTowerCycleChange, new Action(this.OnWheelTowerCycleChange));
	}

	// Token: 0x0600A37B RID: 41851 RVA: 0x002B2C08 File Offset: 0x002B0E08
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<NewTowerResultNotify>(ENotifyMessageId.NewTowerResultNotify, new Action<NewTowerResultNotify, Net.CallbackStatus>(this.OnNewTowerResultNotify));
		Singleton<Net>.Instance.Register<NewTowerLevelUnlockNotify>(ENotifyMessageId.NewTowerLevelUnlockNotify, new Action<NewTowerLevelUnlockNotify, Net.CallbackStatus>(this.OnNewTowerLevelUnlockNotify));
		Singleton<Net>.Instance.Register<NewTowerTaskDataUpdateNotify>(ENotifyMessageId.NewTowerTaskDataUpdateNotify, new Action<NewTowerTaskDataUpdateNotify, Net.CallbackStatus>(this.OnNewTowerTaskDataUpdateNotify));
		Singleton<Net>.Instance.Register<NewTowerUpdateRecordNotify>(ENotifyMessageId.NewTowerUpdateRecordNotify, new Action<NewTowerUpdateRecordNotify, Net.CallbackStatus>(this.OnNewTowerUpdateRecordNotify));
		Singleton<Net>.Instance.Register<NewTowerRoundUpdateNotify>(ENotifyMessageId.NewTowerRoundUpdateNotify, new Action<NewTowerRoundUpdateNotify, Net.CallbackStatus>(this.OnNewTowerRoundUpdateNotify));
		Singleton<Net>.Instance.Register<NewTowerSeasonTaskDataUpdateNotify>(ENotifyMessageId.NewTowerSeasonTaskDataUpdateNotify, new Action<NewTowerSeasonTaskDataUpdateNotify, Net.CallbackStatus>(this.OnNewTowerSeasonTaskDataUpdateNotify));
	}

	// Token: 0x0600A37C RID: 41852 RVA: 0x002B2CC0 File Offset: 0x002B0EC0
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NewTowerResultNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NewTowerLevelUnlockNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NewTowerTaskDataUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NewTowerUpdateRecordNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NewTowerRoundUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NewTowerSeasonTaskDataUpdateNotify);
	}

	// Token: 0x0600A37D RID: 41853 RVA: 0x002B2D30 File Offset: 0x002B0F30
	private void OnWheelTowerCycleChange()
	{
		if (ModelBase<WheelTowerModel>.Instance.CheckInInstanceDungeon())
		{
			this.ShowWheelTowerCycleChangeConfirmBox(delegate
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Default);
			});
			return;
		}
		foreach (EUiViewName viewName in WheelTowerController.WheelTowerViewNameList)
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(viewName))
			{
				this.ShowWheelTowerCycleChangeConfirmBox(delegate
				{
					Singleton<UiManager>.Instance.ResetToBattleView(null);
				});
				return;
			}
		}
	}

	// Token: 0x0600A37E RID: 41854 RVA: 0x002B2DC0 File Offset: 0x002B0FC0
	public void ShowWheelTowerCycleChangeConfirmBox(Action confirmCallback)
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ActivityEnd);
		confirmBoxDataNew.FunctionMap[1] = confirmCallback;
		confirmBoxDataNew.FunctionMap[0] = confirmCallback;
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600A37F RID: 41855 RVA: 0x002B2DFB File Offset: 0x002B0FFB
	private void OnWorldDone()
	{
		if (ModelBase<WheelTowerModel>.Instance.CheckInInstanceDungeon())
		{
			this.SetBanTimeStop(true);
		}
	}

	// Token: 0x0600A380 RID: 41856 RVA: 0x002B2E10 File Offset: 0x002B1010
	public void SetBanTimeStop(bool ban)
	{
		WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
		if (instance.IsTimeStopBanned == ban)
		{
			return;
		}
		instance.IsTimeStopBanned = ban;
		if (ban)
		{
			Singleton<UiTimeDilation>.Instance.AddWaitSetTimeDilationTag("WheelTower");
			return;
		}
		Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("WheelTower");
	}

	// Token: 0x0600A381 RID: 41857 RVA: 0x002B2E58 File Offset: 0x002B1058
	private void OnNewTowerSeasonTaskDataUpdateNotify(NewTowerSeasonTaskDataUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
		if (activityData != null)
		{
			activityData.UpdateSeasonTaskList(notify.SeasonTasks.ToList<ActivityTask>());
		}
		if (activityData != null)
		{
			activityData.UpdateSeasonTaskList(notify.Adds.ToList<ActivityTask>());
		}
		if (activityData != null)
		{
			activityData.RemoveSeasonTaskList(notify.Removes.ToList<int>());
		}
		if (activityData != null)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityData.Id);
		}
	}

	// Token: 0x0600A382 RID: 41858 RVA: 0x002B2EC8 File Offset: 0x002B10C8
	private void OnNewTowerRoundUpdateNotify(NewTowerRoundUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
		if (!instance.EndlessMode)
		{
			return;
		}
		if (instance.CachedRoundInProgress == notify.Round)
		{
			return;
		}
		instance.CachedRoundInProgress = notify.Round;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerRoundTipsView, notify.Round, null);
	}

	// Token: 0x0600A383 RID: 41859 RVA: 0x002B2F1A File Offset: 0x002B111A
	private void OnNewTowerTaskDataUpdateNotify(NewTowerTaskDataUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
		if (activityData == null)
		{
			return;
		}
		activityData.OnTaskUpdateNotify(notify.ActivityTasks.ToList<ActivityTask>());
	}

	// Token: 0x0600A384 RID: 41860 RVA: 0x002B2F3B File Offset: 0x002B113B
	private void OnNewTowerUpdateRecordNotify(NewTowerUpdateRecordNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		if (notify.Record != null)
		{
			WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return;
			}
			activityData.OnLevelRecordUpdateNotify(notify.Record);
		}
	}

	// Token: 0x0600A385 RID: 41861 RVA: 0x002B2F60 File Offset: 0x002B1160
	private void OnNewTowerLevelUnlockNotify(NewTowerLevelUnlockNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		if (notify.Record == null)
		{
			return;
		}
		NewTowerLevel? levelConfigById = ConfigBase<WheelTowerConfig>.Instance.GetLevelConfigById(notify.Record.LevelId);
		if (levelConfigById == null || levelConfigById.Value.Diff <= 0)
		{
			return;
		}
		if (ModelBase<WheelTowerModel>.Instance.BlockEndlessUnlockTips)
		{
			ModelBase<WheelTowerModel>.Instance.SetIsEndlessUnlockedInInstance(true);
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("WheelTower_EndlessModeUnlockTips", Array.Empty<object>());
	}

	// Token: 0x0600A386 RID: 41862 RVA: 0x002B2FD4 File Offset: 0x002B11D4
	private void OnNewTowerResultNotify(NewTowerResultNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		WheelTowerModel model = ModelBase<WheelTowerModel>.Instance;
		int selectedRound = model.SelectedRound;
		bool flag = model.IsRoundChallenged(selectedRound, new bool?(model.EndlessMode));
		int count = model.GetRoundBossInfo(selectedRound, new bool?(model.EndlessMode)).Count;
		bool isEndlessUnlockedInInstance = model.GetIsEndlessUnlockedInInstance();
		if (!isEndlessUnlockedInInstance)
		{
			if (!flag)
			{
				WheelTowerData activityData = model.ActivityData;
				if (activityData != null)
				{
					activityData.OnAddNewRecord(notify);
				}
			}
			else
			{
				int bossRound = 0;
				int num = 0;
				MonsterInfoPreview bossInfoByRound = model.GetBossInfoByRound(selectedRound, new bool?(model.EndlessMode));
				if (bossInfoByRound != null)
				{
					bossRound = bossInfoByRound.Round;
					NewTowerWave? waveConfigById = ConfigBase<WheelTowerConfig>.Instance.GetWaveConfigById(bossInfoByRound.WaveConfigId);
					if (waveConfigById != null)
					{
						num = waveConfigById.Value.Wave;
					}
				}
				int num2 = num % count;
				num = ((num2 != 0) ? num2 : count);
				int bossRound2 = 0;
				int num3 = 0;
				foreach (MonsterInfoPreview monsterInfoPreview in notify.MonsterInfoPreviews)
				{
					bossRound2 = monsterInfoPreview.Round;
					NewTowerWave? waveConfigById2 = ConfigBase<WheelTowerConfig>.Instance.GetWaveConfigById(monsterInfoPreview.WaveConfigId);
					if (waveConfigById2 != null)
					{
						num3 = waveConfigById2.Value.Wave;
					}
				}
				num2 = num3 % count;
				num3 = ((num2 != 0) ? num2 : count);
				TeamChallengeInfo teamChallengeInfo = notify.TeamChallengeInfo;
				if (teamChallengeInfo != null)
				{
					List<int> list = new List<int>();
					foreach (RoleSaveInfo roleSaveInfo in teamChallengeInfo.RoleSaveInfos)
					{
						list.Add(roleSaveInfo.RoleId);
					}
					List<int> roundSelectBuffList = model.GetRoundSelectBuffList(selectedRound);
					int buffId = (roundSelectBuffList.Count > 0) ? roundSelectBuffList[0] : 0;
					int buffId2 = (teamChallengeInfo.BuffIds.Count > 0) ? teamChallengeInfo.BuffIds[0] : 0;
					WheelTowerCoverRecordViewData recordPopupData = new WheelTowerCoverRecordViewData
					{
						BeforeData = new WheelTowerCoverRecordData
						{
							TotalScore = model.GetRoundTotalScore(selectedRound),
							TeamScore = notify.BeforeTeamScore,
							BossRound = bossRound,
							BossWave = num,
							NeedChallengeBossWaveNum = count,
							AddTeamScore = 0,
							TeamRoleIdList = model.GetRoundSelectRoleIdList(selectedRound),
							BuffId = buffId
						},
						AfterData = new WheelTowerCoverRecordData
						{
							TotalScore = notify.AfterLevelScore,
							TeamScore = notify.AfterTeamScore,
							BossRound = bossRound2,
							BossWave = num3,
							NeedChallengeBossWaveNum = count,
							AddTeamScore = notify.AfterTeamScore - notify.BeforeTeamScore,
							TeamRoleIdList = list,
							BuffId = buffId2
						},
						IsEndless = model.EndlessMode,
						TeamNum = selectedRound + 1
					};
					model.SetRecordPopupData(recordPopupData);
				}
			}
		}
		List<IBossItemData> list2 = new List<IBossItemData>();
		for (int i = 0; i < notify.MonsterInfoPreviews.Count; i++)
		{
			MonsterInfoPreview monsterInfoPreview2 = notify.MonsterInfoPreviews[i];
			NewTowerWave? waveConfigById3 = ConfigBase<WheelTowerConfig>.Instance.GetWaveConfigById(monsterInfoPreview2.WaveConfigId);
			if (waveConfigById3 != null && waveConfigById3.Value.IsShowInView)
			{
				float value = (list2.Count == 0) ? ((float)model.GetRecordPrevBossHpPercentage(selectedRound - 1, monsterInfoPreview2.WaveConfigId, monsterInfoPreview2.Round)) : 100f;
				list2.Add(new BossItemData
				{
					BossInfo = new BossInfo
					{
						WaveConfigId = monsterInfoPreview2.WaveConfigId,
						Round = monsterInfoPreview2.Round,
						HpPercentage = model.GetBossHpPercentage(monsterInfoPreview2)
					},
					StartPercent = new float?(value),
					ShowBossRound = new bool?(model.EndlessMode)
				});
			}
		}
		TeamChallengeInfo teamChallengeInfo2 = notify.TeamChallengeInfo;
		if (teamChallengeInfo2 == null)
		{
			this.SetBanTimeStop(false);
			model.CachedRoundInProgress = -1;
			return;
		}
		List<RoleDataWithBranch> list3 = new List<RoleDataWithBranch>();
		foreach (RoleSaveInfo roleSaveInfo2 in teamChallengeInfo2.RoleSaveInfos)
		{
			list3.Add(new RoleDataWithBranch(roleSaveInfo2.RoleId, roleSaveInfo2.SkillBranchId));
		}
		List<int> list4 = new List<int>();
		foreach (int item in notify.CompletedSeasonTaskIds)
		{
			list4.Add(item);
		}
		WheelTowerSettlementViewData param = new WheelTowerSettlementViewData
		{
			EndlessMode = model.EndlessMode,
			TotalRound = model.GetLastChallengeRound(null) + 1,
			CurrentRound = model.SelectedRound + 1,
			CurrentScore = notify.AfterTeamScore,
			TotalScore = notify.AfterLevelScore,
			BossInfoList = list2,
			MaxBossWaveNum = count,
			RoleList = list3,
			FinishedSeasonTaskIds = list4
		};
		WheelTowerSettlementViewData param2 = param;
		WheelTowerSettlementViewButtonData wheelTowerSettlementViewButtonData = new WheelTowerSettlementViewButtonData();
		wheelTowerSettlementViewButtonData.Name = "WheelTower_Result_Back";
		wheelTowerSettlementViewButtonData.OnClick = delegate()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerPrepareView, null, null);
		};
		param2.LeftButtonData = wheelTowerSettlementViewButtonData;
		WheelTowerSettlementViewButtonData wheelTowerSettlementViewButtonData2 = new WheelTowerSettlementViewButtonData
		{
			Name = "WheelTower_Result_Retry",
			OnClick = new Action(this.RequestSelectedRoundChallenge),
			ConfirmBoxId = new EConfirmBoxConfigId?(EConfirmBoxConfigId.WheelTowerInstanceRetryConfirm)
		};
		WheelTowerSettlementViewButtonData rightButtonData = new WheelTowerSettlementViewButtonData
		{
			Name = "WheelTower_Result_Next",
			OnClick = delegate
			{
				int round = model.SelectedRound + 1;
				model.UpdateSelectRound(round, false);
				Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerPrepareView, null, null);
			}
		};
		WheelTowerSettlementViewButtonData rightButtonData2 = new WheelTowerSettlementViewButtonData
		{
			Name = "WheelTower_Result_Endless",
			OnClick = delegate
			{
				model.SetEndlessMode(true);
				Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerModeDetailView, null, null);
			}
		};
		if (model.EndlessMode)
		{
			param.CenterButtonData = wheelTowerSettlementViewButtonData2;
			param.RightButtonData = rightButtonData;
		}
		else if (isEndlessUnlockedInInstance)
		{
			param.CenterButtonData = wheelTowerSettlementViewButtonData2;
			param.RightButtonData = rightButtonData2;
			param.ShowEndlessUnlockTips = new bool?(true);
		}
		else
		{
			MonsterInfoPreview lastMonsterInfoPreview = teamChallengeInfo2.LastMonsterInfoPreview;
			if (lastMonsterInfoPreview != null && (model.GetBossHpPercentage(lastMonsterInfoPreview) <= 0.0 || model.IsLastRoundCheckLimit(notify.LevelId, selectedRound)))
			{
				param.RightButtonData = wheelTowerSettlementViewButtonData2;
			}
			else
			{
				param.CenterButtonData = wheelTowerSettlementViewButtonData2;
				param.RightButtonData = rightButtonData;
			}
		}
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerSettlementView, param, null);
			this.SetBanTimeStop(false);
		}, 0.5f * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, null, null, true, 1f);
		model.CachedRoundInProgress = -1;
		this.RequestMedalInfo().Forget();
	}

	// Token: 0x0600A387 RID: 41863 RVA: 0x002B3718 File Offset: 0x002B1918
	[NullableContext(2)]
	public void TryOpenOverridePopupView(Action confirmCallback = null)
	{
		IWheelTowerCoverRecordViewData recordPopupData = ModelBase<WheelTowerModel>.Instance.GetRecordPopupData();
		if (recordPopupData == null)
		{
			return;
		}
		ModelBase<WheelTowerModel>.Instance.DeleteRecordPopupData();
		Action <>9__1;
		recordPopupData.OnClickConfirm = delegate()
		{
			WheelTowerController <>4__this = this;
			Action finishCallback;
			if ((finishCallback = <>9__1) == null)
			{
				finishCallback = (<>9__1 = delegate()
				{
					Action confirmCallback2 = confirmCallback;
					if (confirmCallback2 == null)
					{
						return;
					}
					confirmCallback2();
				});
			}
			<>4__this.TryOverrideLevelRecord(finishCallback).Forget();
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerCoverRecordPopupView, recordPopupData, null);
	}

	// Token: 0x0600A388 RID: 41864 RVA: 0x002B3778 File Offset: 0x002B1978
	public UniTask TryOverrideLevelRecord(Action finishCallback)
	{
		WheelTowerController.<TryOverrideLevelRecord>d__27 <TryOverrideLevelRecord>d__;
		<TryOverrideLevelRecord>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<TryOverrideLevelRecord>d__.finishCallback = finishCallback;
		<TryOverrideLevelRecord>d__.<>1__state = -1;
		<TryOverrideLevelRecord>d__.<>t__builder.Start<WheelTowerController.<TryOverrideLevelRecord>d__27>(ref <TryOverrideLevelRecord>d__);
		return <TryOverrideLevelRecord>d__.<>t__builder.Task;
	}

	// Token: 0x0600A389 RID: 41865 RVA: 0x002B37BC File Offset: 0x002B19BC
	public void RequestSelectedRoundChallenge()
	{
		NewTowerClimbingLevelRecord currentLevelRecord = ModelBase<WheelTowerModel>.Instance.GetCurrentLevelRecord(null);
		this.RequestChallenge(currentLevelRecord.LevelId, ModelBase<WheelTowerModel>.Instance.SelectedRound, new List<int>
		{
			ModelBase<WheelTowerModel>.Instance.SelectedBuff
		}, ModelBase<WheelTowerModel>.Instance.SelectedRoleList.ToList<int>());
	}

	// Token: 0x0600A38A RID: 41866 RVA: 0x002B3818 File Offset: 0x002B1A18
	public void RequestChallenge(int levelId, int round, IList<int> buffIdList, IList<int> roleIdList)
	{
		NewTowerCycleStartParam newTowerCycleStartParam = new NewTowerCycleStartParam
		{
			LevelId = levelId,
			Index = round
		};
		newTowerCycleStartParam.BuffIds.Add(buffIdList);
		WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
		foreach (int roleId in roleIdList)
		{
			RoleSaveInfo roleSaveInfo = new RoleSaveInfo();
			if (instance.IsTemplateRole(roleId))
			{
				roleSaveInfo.RoleId = roleId;
				roleSaveInfo.SkillBranchId = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIdInGamePlay(roleId, ESkillBranchCacheType.WheeTowerLoading);
			}
			else
			{
				IRoleInfo roleInfo = instance.GetRoleInfo(roleId);
				roleSaveInfo.RoleId = roleId;
				roleSaveInfo.WeaponIncId = roleInfo.Weapon;
				roleSaveInfo.PhantomIncId.Add(roleInfo.Phantom);
				roleSaveInfo.SkillBranchId = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIdInGamePlay(roleId, ESkillBranchCacheType.WheeTowerLoading);
			}
			newTowerCycleStartParam.RoleSaveInfos.Add(roleSaveInfo);
		}
		NewTowerClimbingCtx newTowerClimbingCtx = new NewTowerClimbingCtx
		{
			Param = newTowerCycleStartParam
		};
		ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.NewTowerClimbingCtx = newTowerClimbingCtx;
		NewTowerLevel? levelConfigById = ConfigBase<WheelTowerConfig>.Instance.GetLevelConfigById(levelId);
		if (levelConfigById != null)
		{
			ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(levelConfigById.Value.InstId, roleIdList.ToList<int>(), 0, 0, null, null);
		}
		ModelBase<WheelTowerModel>.Instance.BlockEndlessUnlockTips = true;
		ModelBase<WheelTowerModel>.Instance.DeleteRecordPopupData();
	}

	// Token: 0x0600A38B RID: 41867 RVA: 0x002B3980 File Offset: 0x002B1B80
	public UniTask RequestRoleEnergyUpdate()
	{
		WheelTowerController.<RequestRoleEnergyUpdate>d__30 <RequestRoleEnergyUpdate>d__;
		<RequestRoleEnergyUpdate>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestRoleEnergyUpdate>d__.<>1__state = -1;
		<RequestRoleEnergyUpdate>d__.<>t__builder.Start<WheelTowerController.<RequestRoleEnergyUpdate>d__30>(ref <RequestRoleEnergyUpdate>d__);
		return <RequestRoleEnergyUpdate>d__.<>t__builder.Task;
	}

	// Token: 0x0600A38C RID: 41868 RVA: 0x002B39BC File Offset: 0x002B1BBC
	public UniTask RequestTaskReceive(bool isEndless)
	{
		WheelTowerController.<RequestTaskReceive>d__31 <RequestTaskReceive>d__;
		<RequestTaskReceive>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestTaskReceive>d__.isEndless = isEndless;
		<RequestTaskReceive>d__.<>1__state = -1;
		<RequestTaskReceive>d__.<>t__builder.Start<WheelTowerController.<RequestTaskReceive>d__31>(ref <RequestTaskReceive>d__);
		return <RequestTaskReceive>d__.<>t__builder.Task;
	}

	// Token: 0x0600A38D RID: 41869 RVA: 0x002B3A00 File Offset: 0x002B1C00
	public UniTask RequestSeasonTaskReceive()
	{
		WheelTowerController.<RequestSeasonTaskReceive>d__32 <RequestSeasonTaskReceive>d__;
		<RequestSeasonTaskReceive>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestSeasonTaskReceive>d__.<>1__state = -1;
		<RequestSeasonTaskReceive>d__.<>t__builder.Start<WheelTowerController.<RequestSeasonTaskReceive>d__32>(ref <RequestSeasonTaskReceive>d__);
		return <RequestSeasonTaskReceive>d__.<>t__builder.Task;
	}

	// Token: 0x0600A38E RID: 41870 RVA: 0x002B3A3C File Offset: 0x002B1C3C
	public UniTask RequestSeasonTaskProgress()
	{
		WheelTowerController.<RequestSeasonTaskProgress>d__33 <RequestSeasonTaskProgress>d__;
		<RequestSeasonTaskProgress>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestSeasonTaskProgress>d__.<>1__state = -1;
		<RequestSeasonTaskProgress>d__.<>t__builder.Start<WheelTowerController.<RequestSeasonTaskProgress>d__33>(ref <RequestSeasonTaskProgress>d__);
		return <RequestSeasonTaskProgress>d__.<>t__builder.Task;
	}

	// Token: 0x0600A38F RID: 41871 RVA: 0x002B3A78 File Offset: 0x002B1C78
	public UniTask RequestMedalInfo()
	{
		WheelTowerController.<RequestMedalInfo>d__34 <RequestMedalInfo>d__;
		<RequestMedalInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestMedalInfo>d__.<>1__state = -1;
		<RequestMedalInfo>d__.<>t__builder.Start<WheelTowerController.<RequestMedalInfo>d__34>(ref <RequestMedalInfo>d__);
		return <RequestMedalInfo>d__.<>t__builder.Task;
	}

	// Token: 0x0600A390 RID: 41872 RVA: 0x002B3AB4 File Offset: 0x002B1CB4
	public UniTask RequestSeasonScoreReceive()
	{
		WheelTowerController.<RequestSeasonScoreReceive>d__35 <RequestSeasonScoreReceive>d__;
		<RequestSeasonScoreReceive>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestSeasonScoreReceive>d__.<>1__state = -1;
		<RequestSeasonScoreReceive>d__.<>t__builder.Start<WheelTowerController.<RequestSeasonScoreReceive>d__35>(ref <RequestSeasonScoreReceive>d__);
		return <RequestSeasonScoreReceive>d__.<>t__builder.Task;
	}

	// Token: 0x0600A391 RID: 41873 RVA: 0x002B3AF0 File Offset: 0x002B1CF0
	public UniTask RequestResetLevelRecord(int levelId)
	{
		WheelTowerController.<RequestResetLevelRecord>d__36 <RequestResetLevelRecord>d__;
		<RequestResetLevelRecord>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestResetLevelRecord>d__.levelId = levelId;
		<RequestResetLevelRecord>d__.<>1__state = -1;
		<RequestResetLevelRecord>d__.<>t__builder.Start<WheelTowerController.<RequestResetLevelRecord>d__36>(ref <RequestResetLevelRecord>d__);
		return <RequestResetLevelRecord>d__.<>t__builder.Task;
	}

	// Token: 0x0600A392 RID: 41874 RVA: 0x002B3B34 File Offset: 0x002B1D34
	public UniTask RequestRecommendInfo()
	{
		WheelTowerController.<RequestRecommendInfo>d__37 <RequestRecommendInfo>d__;
		<RequestRecommendInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestRecommendInfo>d__.<>1__state = -1;
		<RequestRecommendInfo>d__.<>t__builder.Start<WheelTowerController.<RequestRecommendInfo>d__37>(ref <RequestRecommendInfo>d__);
		return <RequestRecommendInfo>d__.<>t__builder.Task;
	}

	// Token: 0x0600A393 RID: 41875 RVA: 0x002B3B70 File Offset: 0x002B1D70
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public UniTask<NewTowerCycleRecordPb> RequestLastCycleReviewInfo()
	{
		WheelTowerController.<RequestLastCycleReviewInfo>d__38 <RequestLastCycleReviewInfo>d__;
		<RequestLastCycleReviewInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder<NewTowerCycleRecordPb>.Create();
		<RequestLastCycleReviewInfo>d__.<>1__state = -1;
		<RequestLastCycleReviewInfo>d__.<>t__builder.Start<WheelTowerController.<RequestLastCycleReviewInfo>d__38>(ref <RequestLastCycleReviewInfo>d__);
		return <RequestLastCycleReviewInfo>d__.<>t__builder.Task;
	}

	// Token: 0x0600A394 RID: 41876 RVA: 0x002B3BAC File Offset: 0x002B1DAC
	public void RequestEndChallenge(Action callback)
	{
		Singleton<Net>.Instance.Call<NewTowerCycleStartResponse>(ERequestMessageId.NewTowerCycleStartRequest, new NewTowerCycleStartRequest(), delegate(NewTowerCycleStartResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.NewTowerCycleStartResponse, null, true, true);
				return;
			}
			callback();
		}, 0);
	}

	// Token: 0x0600A395 RID: 41877 RVA: 0x002B3BE8 File Offset: 0x002B1DE8
	public void OpenSeasonMedalView(int seasonId = 0, bool autoShare = false)
	{
		bool hideAllSeasonBtn = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.WheelTowerSeasonMedalView) != null;
		int num;
		if (seasonId == 0)
		{
			WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
			num = ((activityData != null) ? activityData.SeasonId : 0);
		}
		else
		{
			num = seasonId;
		}
		int seasonId2 = num;
		WheelTowerSeasonMedalViewData param = new WheelTowerSeasonMedalViewData
		{
			SeasonId = seasonId2,
			HideAllSeasonBtn = hideAllSeasonBtn,
			AutoShare = autoShare
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerSeasonMedalView, param, null);
	}

	// Token: 0x04004DC1 RID: 19905
	private const string TAG_WAIT = "WheelTower";

	// Token: 0x04004DC2 RID: 19906
	[StaticVariableRuleIgnore]
	private static readonly EUiViewName[] WheelTowerViewNameList = new EUiViewName[]
	{
		EUiViewName.WheelTowerModeSelectView,
		EUiViewName.WheelTowerRoundSelectView,
		EUiViewName.WheelTowerBuffSelectView,
		EUiViewName.WheelTowerMainView,
		EUiViewName.WheelTowerModeDetailView,
		EUiViewName.WheelTowerPrepareView,
		EUiViewName.WheelTowerEnhanceRoleView,
		EUiViewName.WheelTowerRecordView,
		EUiViewName.WheelTowerScoreLevelRuleView,
		EUiViewName.WheelTowerRecommendView,
		EUiViewName.WheelTowerBossBuffTip,
		EUiViewName.WheelTowerSettlementView,
		EUiViewName.WheelTowerBossHandBookView,
		EUiViewName.WheelTowerLimitRewardView,
		EUiViewName.WheelTowerSeasonRewardView,
		EUiViewName.WheelTowerCoverRecordPopupView,
		EUiViewName.WheelTowerMedalDetailView,
		EUiViewName.WheelTowerSeasonMedalView,
		EUiViewName.WheelTowerSeasonOverviewView,
		EUiViewName.WheelTowerSeasonReviewView
	};
}

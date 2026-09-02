using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.TrainingDegree;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;
using UnrealEngine;

// Token: 0x020011DD RID: 4573
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class BabelTowerController : ActivityControllerBase<BabelTowerController>
{
	// Token: 0x060078C2 RID: 30914 RVA: 0x001FA206 File Offset: 0x001F8406
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x060078C3 RID: 30915 RVA: 0x001FA208 File Offset: 0x001F8408
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityBabel";
	}

	// Token: 0x060078C4 RID: 30916 RVA: 0x001FA20F File Offset: 0x001F840F
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new BabelTowerSubView();
	}

	// Token: 0x060078C5 RID: 30917 RVA: 0x001FA216 File Offset: 0x001F8416
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.ActivityId = data.Id;
		return new BabelTowerData();
	}

	// Token: 0x060078C6 RID: 30918 RVA: 0x001FA229 File Offset: 0x001F8429
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x060078C7 RID: 30919 RVA: 0x001FA22C File Offset: 0x001F842C
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<BabelActivityLevelInfoNotify>(ENotifyMessageId.BabelActivityLevelInfoNotify, new Action<BabelActivityLevelInfoNotify, Net.CallbackStatus>(this.BabelActivityLevelInfoNotify));
		Singleton<Net>.Instance.Register<BabelActivityDeTermInfoNotify>(ENotifyMessageId.BabelActivityDeTermInfoNotify, new Action<BabelActivityDeTermInfoNotify, Net.CallbackStatus>(this.BabelActivityDeTermInfoNotify));
		Singleton<Net>.Instance.Register<BabelActivityBuffInfoNotify>(ENotifyMessageId.BabelActivityBuffInfoNotify, new Action<BabelActivityBuffInfoNotify, Net.CallbackStatus>(this.BabelActivityBuffInfoNotify));
		Singleton<Net>.Instance.Register<BabelActivityTaskInfoNotify>(ENotifyMessageId.BabelActivityTaskInfoNotify, new Action<BabelActivityTaskInfoNotify, Net.CallbackStatus>(this.BabelActivityTaskInfoNotify));
		Singleton<Net>.Instance.Register<BabelActivityDailyTaskInfoNotify>(ENotifyMessageId.BabelActivityDailyTaskInfoNotify, new Action<BabelActivityDailyTaskInfoNotify, Net.CallbackStatus>(this.BabelActivityDailyTaskInfoNotify));
		Singleton<Net>.Instance.Register<BabelActivitySettleInfoNotify>(ENotifyMessageId.BabelActivitySettleInfoNotify, new Action<BabelActivitySettleInfoNotify, Net.CallbackStatus>(this.BabelActivitySettleInfoNotify));
		Singleton<Net>.Instance.Register<BabelActivityInstInfoNotify>(ENotifyMessageId.BabelActivityInstInfoNotify, new Action<BabelActivityInstInfoNotify, Net.CallbackStatus>(this.BabelActivityInstInfoNotify));
		Singleton<Net>.Instance.Register<BabelActivityItemNumUpdateNotify>(ENotifyMessageId.BabelActivityItemNumUpdateNotify, new Action<BabelActivityItemNumUpdateNotify, Net.CallbackStatus>(this.BabelActivityItemNumUpdateNotify));
	}

	// Token: 0x060078C8 RID: 30920 RVA: 0x001FA31C File Offset: 0x001F851C
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BabelActivityLevelInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BabelActivityDeTermInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BabelActivityBuffInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BabelActivityTaskInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BabelActivityDailyTaskInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BabelActivitySettleInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BabelActivityInstInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BabelActivityItemNumUpdateNotify);
	}

	// Token: 0x060078C9 RID: 30921 RVA: 0x001FA3A9 File Offset: 0x001F85A9
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
	}

	// Token: 0x060078CA RID: 30922 RVA: 0x001FA3C7 File Offset: 0x001F85C7
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
	}

	// Token: 0x060078CB RID: 30923 RVA: 0x001FA3E5 File Offset: 0x001F85E5
	private void OnRoleChangeEnd()
	{
		if (this.ActivityId <= 0)
		{
			return;
		}
		BabelTowerData babelTowerData = this.GetBabelTowerData();
		if (babelTowerData == null)
		{
			return;
		}
		babelTowerData.UpdateAllLevelRoleIds();
	}

	// Token: 0x060078CC RID: 30924 RVA: 0x001FA401 File Offset: 0x001F8601
	private void BabelActivityLevelInfoNotify(BabelActivityLevelInfoNotify response, [Nullable(2)] Net.CallbackStatus status)
	{
		this.GetBabelTowerData().UpdateLevelInfosAndNotify(response.BabelActivityLevelInfos);
		Singleton<EventSystem>.Instance.Emit(EEventName.BabelTowerRefreshLevelInfo);
	}

	// Token: 0x060078CD RID: 30925 RVA: 0x001FA424 File Offset: 0x001F8624
	private void BabelActivityDeTermInfoNotify(BabelActivityDeTermInfoNotify response, [Nullable(2)] Net.CallbackStatus status)
	{
		BabelTowerData babelTowerData = this.GetBabelTowerData();
		foreach (BabelActivityDeTermInfo babelActivityDeTermInfo in response.BabelActivityDeTermInfos)
		{
			babelTowerData.DeTermUnlock[babelActivityDeTermInfo.DeTermId] = babelActivityDeTermInfo.DifficultUnlock;
		}
	}

	// Token: 0x060078CE RID: 30926 RVA: 0x001FA488 File Offset: 0x001F8688
	private void BabelActivityBuffInfoNotify(BabelActivityBuffInfoNotify response, [Nullable(2)] Net.CallbackStatus status)
	{
		BabelTowerData babelTowerData = this.GetBabelTowerData();
		foreach (BabelActivityBuffInfo babelActivityBuffInfo in response.BabelActivityBuffInfos)
		{
			babelTowerData.BuffUnlock[babelActivityBuffInfo.BabelBuffId] = babelActivityBuffInfo.DifficultUnlock;
		}
	}

	// Token: 0x060078CF RID: 30927 RVA: 0x001FA4EC File Offset: 0x001F86EC
	private void BabelActivityTaskInfoNotify(BabelActivityTaskInfoNotify response, [Nullable(2)] Net.CallbackStatus status)
	{
		BabelTowerData babelTowerData = this.GetBabelTowerData();
		foreach (ActivityTask activityTask in response.ActivityTasks)
		{
			babelTowerData.NormalQuest[activityTask.Id] = activityTask;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.BabelTowerRefreshQuestState);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, babelTowerData.Id);
	}

	// Token: 0x060078D0 RID: 30928 RVA: 0x001FA574 File Offset: 0x001F8774
	private void BabelActivityDailyTaskInfoNotify(BabelActivityDailyTaskInfoNotify response, [Nullable(2)] Net.CallbackStatus status)
	{
		BabelTowerData babelTowerData = this.GetBabelTowerData();
		foreach (ActivityTask activityTask in response.ActivityTasks)
		{
			babelTowerData.DailyQuest[activityTask.Id] = activityTask;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.BabelTowerRefreshQuestState);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, babelTowerData.Id);
	}

	// Token: 0x060078D1 RID: 30929 RVA: 0x001FA5FC File Offset: 0x001F87FC
	private void BabelActivitySettleInfoNotify(BabelActivitySettleInfoNotify response, [Nullable(2)] Net.CallbackStatus status)
	{
		BabelTowerController.<>c__DisplayClass16_0 CS$<>8__locals1 = new BabelTowerController.<>c__DisplayClass16_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.instData = ModelBase<BabelTowerModel>.Instance.CurrentChallengeInstData;
		if (CS$<>8__locals1.instData == null)
		{
			return;
		}
		CS$<>8__locals1.levelId = CS$<>8__locals1.instData.LevelId;
		int curStarNum = CS$<>8__locals1.instData.CurStarNum;
		CS$<>8__locals1.levelConfig = ConfigBabelTowerLevelById.GetConfig(CS$<>8__locals1.levelId, true).Value;
		CS$<>8__locals1.instId = CS$<>8__locals1.levelConfig.InstId;
		int passStar = CS$<>8__locals1.levelConfig.PassStar;
		bool flag = curStarNum >= passStar;
		bool isPass = response.IsPass;
		CS$<>8__locals1.isDifficult = CS$<>8__locals1.levelConfig.IsDifficult;
		if (isPass && flag)
		{
			this.UpdateLocalLevelDataOnPass(CS$<>8__locals1.levelId, CS$<>8__locals1.isDifficult, curStarNum, response);
		}
		if (isPass & CS$<>8__locals1.isDifficult)
		{
			this.HandleHardLevelPassSettle(CS$<>8__locals1.levelId, curStarNum, passStar, CS$<>8__locals1.instId, CS$<>8__locals1.instData, response).Forget();
			return;
		}
		int configId = isPass ? 3025 : 3026;
		IExploreRewardViewData exploreRewardViewData;
		if (isPass)
		{
			string textKey = flag ? "Text_BabelResultOverStarNum_Text" : "Text_BabelResultUnderStarNum_Text";
			string tipTextId = flag ? "Text_BabelResultOverStarTip_Text1" : "Text_BabelResultUnderStarTip_Text";
			BabelTowerSuccessData babelTowerSuccessData = new BabelTowerSuccessData
			{
				NewBabelBuffIds = new List<int>(response.NewBabelBuffIds),
				NewBabelDeTermIds = new List<int>(response.NewBabelDeTermId),
				StarTextParam = new TableTextArgNew(textKey, new <>z__ReadOnlyArray<object>(new object[]
				{
					curStarNum,
					passStar
				})),
				TipTextId = tipTextId
			};
			exploreRewardViewData = new ExploreRewardViewData
			{
				ConfigId = configId,
				IsSuccess = true,
				BabelTowerSuccessData = babelTowerSuccessData
			};
		}
		else
		{
			List<IRewardExploreBar> list = new List<IRewardExploreBar>();
			IReadOnlyList<TrainingData> trainingDataList = ModelBase<TrainingDegreeModel>.Instance.GetTrainingDataList();
			if (trainingDataList != null)
			{
				foreach (TrainingData trainingData in trainingDataList)
				{
					list.Add(new RewardExploreBar
					{
						TrainingData = trainingData
					});
				}
			}
			exploreRewardViewData = new ExploreRewardViewData
			{
				ConfigId = configId,
				IsSuccess = false,
				ExploreBarDataList = list
			};
		}
		List<IRewardExploreConfirmButton> list2 = new List<IRewardExploreConfirmButton>();
		RewardExploreConfirmButtonData item = new RewardExploreConfirmButtonData
		{
			ButtonTextId = "Text_ButtonTextExit_Text",
			DescriptionTextId = null,
			IsTimeDownCloseView = false,
			IsClickedCloseView = false,
			OnClickedCallback = new Action<int>(CS$<>8__locals1.<BabelActivitySettleInfoNotify>g__ExitCallBack|0)
		};
		list2.Add(item);
		if (!response.IsPass || !flag)
		{
			RewardExploreConfirmButtonData item2 = new RewardExploreConfirmButtonData
			{
				ButtonTextId = "Text_ChallengeAgain_Text",
				DescriptionTextId = null,
				IsTimeDownCloseView = false,
				IsClickedCloseView = false,
				OnClickedCallback = delegate(int _)
				{
					EToggleState? bottomToggleState = (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.ExploreRewardView) as ExploreRewardView).GetBottomToggleState();
					if (bottomToggleState != null)
					{
						EToggleState? etoggleState = bottomToggleState;
						EToggleState etoggleState2 = EToggleState.ETT_Checked;
						if (etoggleState.GetValueOrDefault() == etoggleState2 & etoggleState != null)
						{
							int num = 0;
							List<int> deTermIdList = CS$<>8__locals1.instData.DeTermIdList;
							if (deTermIdList != null)
							{
								foreach (int id in deTermIdList)
								{
									num += ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDeTerm(id).Star;
								}
							}
							BabelTowerLevelInfo babelTowerLevelInfo = new BabelTowerLevelInfo();
							babelTowerLevelInfo.BabelTowerLevelId = CS$<>8__locals1.levelId;
							babelTowerLevelInfo.InstanceId = CS$<>8__locals1.instId;
							babelTowerLevelInfo.RoleList = CS$<>8__locals1.<>4__this.GetTeamRoleConfigIdListWithFill();
							List<int> buffList;
							if ((buffList = CS$<>8__locals1.instData.BuffSelection) == null)
							{
								List<int> list3 = new List<int>();
								list3.Add(-1);
								buffList = list3;
								list3.Add(-1);
							}
							babelTowerLevelInfo.BuffList = buffList;
							babelTowerLevelInfo.BuffCount = CS$<>8__locals1.levelConfig.OptionalBabelBuffNum;
							babelTowerLevelInfo.StarNumber = num;
							BabelTowerLevelInfo param = babelTowerLevelInfo;
							Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerHardLevelInfoViewNew, param, null);
							return;
						}
					}
					CS$<>8__locals1.<>4__this.ReChallengeBabelTower();
				}
			};
			list2.Add(item2);
			RewardExploreToggleData stateToggle = new RewardExploreToggleData
			{
				DescriptionTextId = "Text_ChangeFormation_Text"
			};
			((ExploreRewardViewData)exploreRewardViewData).StateToggle = stateToggle;
		}
		((ExploreRewardViewData)exploreRewardViewData).ButtonInfoList = list2;
		ControllerBase<ItemRewardController>.Instance.OpenExploreRewardViewNew(exploreRewardViewData);
	}

	// Token: 0x060078D2 RID: 30930 RVA: 0x001FA908 File Offset: 0x001F8B08
	private void BabelActivityInstInfoNotify(BabelActivityInstInfoNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<BabelTowerModel>.Instance.UpdateCurrentChallengeInstDataByNotify(notify);
	}

	// Token: 0x060078D3 RID: 30931 RVA: 0x001FA915 File Offset: 0x001F8B15
	private void BabelActivityItemNumUpdateNotify(BabelActivityItemNumUpdateNotify response, [Nullable(2)] Net.CallbackStatus status)
	{
		this.GetBabelTowerData().CurrentItemCount = response.ActivityItemNum;
	}

	// Token: 0x060078D4 RID: 30932 RVA: 0x001FA928 File Offset: 0x001F8B28
	[NullableContext(0)]
	public UniTask<bool> SelectBabelActivityDeTermRequest(int levelId, [Nullable(1)] List<int> deTermList)
	{
		BabelTowerController.<SelectBabelActivityDeTermRequest>d__19 <SelectBabelActivityDeTermRequest>d__;
		<SelectBabelActivityDeTermRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<SelectBabelActivityDeTermRequest>d__.levelId = levelId;
		<SelectBabelActivityDeTermRequest>d__.deTermList = deTermList;
		<SelectBabelActivityDeTermRequest>d__.<>1__state = -1;
		<SelectBabelActivityDeTermRequest>d__.<>t__builder.Start<BabelTowerController.<SelectBabelActivityDeTermRequest>d__19>(ref <SelectBabelActivityDeTermRequest>d__);
		return <SelectBabelActivityDeTermRequest>d__.<>t__builder.Task;
	}

	// Token: 0x060078D5 RID: 30933 RVA: 0x001FA974 File Offset: 0x001F8B74
	public UniTask SubmitDeTermSelectionAndJump(int levelId, List<int> deTermList, int currentStar, bool jumpToPreBattle = true, int quickId = -1)
	{
		BabelTowerController.<SubmitDeTermSelectionAndJump>d__20 <SubmitDeTermSelectionAndJump>d__;
		<SubmitDeTermSelectionAndJump>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SubmitDeTermSelectionAndJump>d__.<>4__this = this;
		<SubmitDeTermSelectionAndJump>d__.levelId = levelId;
		<SubmitDeTermSelectionAndJump>d__.deTermList = deTermList;
		<SubmitDeTermSelectionAndJump>d__.currentStar = currentStar;
		<SubmitDeTermSelectionAndJump>d__.jumpToPreBattle = jumpToPreBattle;
		<SubmitDeTermSelectionAndJump>d__.<>1__state = -1;
		<SubmitDeTermSelectionAndJump>d__.<>t__builder.Start<BabelTowerController.<SubmitDeTermSelectionAndJump>d__20>(ref <SubmitDeTermSelectionAndJump>d__);
		return <SubmitDeTermSelectionAndJump>d__.<>t__builder.Task;
	}

	// Token: 0x060078D6 RID: 30934 RVA: 0x001FA9D8 File Offset: 0x001F8BD8
	public void OpenPreBattleView(int levelId, int currentStar)
	{
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(levelId);
		BabelTowerData babelTowerData = this.GetBabelTowerData();
		BabelActivityLevelInfo babelActivityLevelInfo = null;
		if (babelTowerLevelConfig.IsDifficult)
		{
			babelTowerData.HardLevelDataMap.TryGetValue(levelId, out babelActivityLevelInfo);
		}
		else
		{
			babelTowerData.NormalLevelDataMap.TryGetValue(levelId, out babelActivityLevelInfo);
		}
		List<int> list = new List<int>();
		int? num;
		if (babelActivityLevelInfo == null)
		{
			num = null;
		}
		else
		{
			RepeatedField<int> maxPassRoleSelection = babelActivityLevelInfo.MaxPassRoleSelection;
			num = ((maxPassRoleSelection != null) ? new int?(maxPassRoleSelection.Count) : null);
		}
		int? num2 = num;
		RepeatedField<int> repeatedField = (num2.GetValueOrDefault() > 0) ? babelActivityLevelInfo.MaxPassRoleSelection : ((babelActivityLevelInfo != null) ? babelActivityLevelInfo.RoleSelection : null);
		if (repeatedField != null)
		{
			foreach (int num3 in repeatedField)
			{
				if (num3 > 0)
				{
					list.Add(num3);
				}
			}
		}
		this.RemoveOutdatedMainRoleTrialIds(list);
		BabelTowerLevelInfo babelTowerLevelInfo = new BabelTowerLevelInfo();
		babelTowerLevelInfo.BabelTowerLevelId = levelId;
		babelTowerLevelInfo.InstanceId = babelTowerLevelConfig.InstId;
		babelTowerLevelInfo.RoleList = list;
		List<int> buffList;
		if (((babelActivityLevelInfo != null) ? babelActivityLevelInfo.MaxPassBuffSelection : null) == null)
		{
			List<int> list2 = new List<int>();
			list2.Add(-1);
			buffList = list2;
			list2.Add(-1);
		}
		else
		{
			buffList = new List<int>(babelActivityLevelInfo.MaxPassBuffSelection);
		}
		babelTowerLevelInfo.BuffList = buffList;
		babelTowerLevelInfo.BuffCount = babelTowerLevelConfig.OptionalBabelBuffNum;
		babelTowerLevelInfo.StarNumber = currentStar;
		BabelTowerLevelInfo param = babelTowerLevelInfo;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerHardLevelInfoViewNew, param, null);
	}

	// Token: 0x060078D7 RID: 30935 RVA: 0x001FAB4C File Offset: 0x001F8D4C
	public void RemoveOutdatedMainRoleTrialIds(List<int> roleList)
	{
		if (roleList == null || roleList.Count == 0)
		{
			return;
		}
		EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
		RoleModel instance = ModelBase<RoleModel>.Instance;
		for (int i = 0; i < roleList.Count; i++)
		{
			int num = roleList[i];
			if (num > 0)
			{
				if (num < 100000)
				{
					RoleDataBase roleDataById = instance.GetRoleDataById(num, true);
					int num2 = (roleDataById != null) ? roleDataById.GetRoleId() : 0;
					if (instance.IsMainRole(num2) && instance.GetRoleInstanceById(num2) == null)
					{
						roleList[i] = 0;
					}
				}
				else
				{
					TrialRoleInfo? trialRoleConfig = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(num);
					if (trialRoleConfig != null)
					{
						RoleDataBase roleDataById2 = instance.GetRoleDataById(num, true);
						int roleId = (roleDataById2 != null) ? roleDataById2.GetRoleId() : 0;
						if (instance.IsMainRole(roleId) && trialRoleConfig.Value.Gender != (int)playerGender)
						{
							roleList[i] = 0;
						}
					}
				}
			}
		}
	}

	// Token: 0x060078D8 RID: 30936 RVA: 0x001FAC2C File Offset: 0x001F8E2C
	public void BabelTowerTaskRewardRequest(int taskId)
	{
		BabelTowerTaskRewardRequest babelTowerTaskRewardRequest = Aki.Protocol.BabelTowerTaskRewardRequest.Create();
		babelTowerTaskRewardRequest.TaskId = taskId;
		Singleton<Net>.Instance.Call<BabelTowerTaskRewardResponse>(ERequestMessageId.BabelTowerTaskRewardRequest, babelTowerTaskRewardRequest, delegate(BabelTowerTaskRewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15469, null, true, true);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
		}, 0);
	}

	// Token: 0x060078D9 RID: 30937 RVA: 0x001FAC64 File Offset: 0x001F8E64
	public void BabelTowerMultiTaskRewardRequest(List<int> taskIds)
	{
		if (taskIds.Count == 0)
		{
			return;
		}
		BabelTowerTaskRewardRequest babelTowerTaskRewardRequest = Aki.Protocol.BabelTowerTaskRewardRequest.Create();
		babelTowerTaskRewardRequest.TaskIds.Add(taskIds);
		babelTowerTaskRewardRequest.ActivityId = this.ActivityId;
		Singleton<Net>.Instance.Call<BabelTowerTaskRewardResponse>(ERequestMessageId.BabelTowerTaskRewardRequest, babelTowerTaskRewardRequest, delegate(BabelTowerTaskRewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15469, null, true, true);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
		}, 0);
	}

	// Token: 0x060078DA RID: 30938 RVA: 0x001FACB8 File Offset: 0x001F8EB8
	public void BabelTowerDailyTaskRewardRequest(int taskId)
	{
		BabelTowerDailyTaskRewardRequest babelTowerDailyTaskRewardRequest = Aki.Protocol.BabelTowerDailyTaskRewardRequest.Create();
		babelTowerDailyTaskRewardRequest.TaskId = taskId;
		Singleton<Net>.Instance.Call<BabelTowerDailyTaskRewardResponse>(ERequestMessageId.BabelTowerDailyTaskRewardRequest, babelTowerDailyTaskRewardRequest, delegate(BabelTowerDailyTaskRewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20057, null, true, true);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
		}, 0);
	}

	// Token: 0x060078DB RID: 30939 RVA: 0x001FACF0 File Offset: 0x001F8EF0
	public void ResetBabelTowerLevelRequest(int levelId)
	{
		ResetBabelTowerLevelRequest resetBabelTowerLevelRequest = Aki.Protocol.ResetBabelTowerLevelRequest.Create();
		resetBabelTowerLevelRequest.BabelTowerLevelId = levelId;
		Singleton<Net>.Instance.Call<ResetBabelTowerLevelResponse>(ERequestMessageId.ResetBabelTowerLevelRequest, resetBabelTowerLevelRequest, delegate(ResetBabelTowerLevelResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19379, null, true, true);
				return;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BabelTowerResetLevelTips", Array.Empty<object>());
			this.GetBabelTowerData().ClearMyRankData();
		}, 0);
	}

	// Token: 0x060078DC RID: 30940 RVA: 0x001FAD28 File Offset: 0x001F8F28
	public void BabelTowerSettlementRequest()
	{
		BabelTowerSettlementRequest message = Aki.Protocol.BabelTowerSettlementRequest.Create();
		Singleton<Net>.Instance.Call<BabelTowerSettlementResponse>(ERequestMessageId.BabelTowerSettlementRequest, message, delegate(BabelTowerSettlementResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25756, null, true, true);
			}
		}, 0);
	}

	// Token: 0x060078DD RID: 30941 RVA: 0x001FAD6C File Offset: 0x001F8F6C
	public void ReChallengeBabelTower()
	{
		BabelTowerInstanceData currentChallengeInstData = ModelBase<BabelTowerModel>.Instance.CurrentChallengeInstData;
		int levelId = currentChallengeInstData.LevelId;
		int instId = ConfigBabelTowerLevelById.GetConfig(levelId, true).Value.InstId;
		List<int> teamRoleConfigIdListWithFill = this.GetTeamRoleConfigIdListWithFill();
		this.BabelTowerStartRequest(instId, teamRoleConfigIdListWithFill, levelId, currentChallengeInstData.BuffSelection ?? new List<int>(), this.BuildSkillBranchListFromRoleList(teamRoleConfigIdListWithFill));
	}

	// Token: 0x060078DE RID: 30942 RVA: 0x001FADD0 File Offset: 0x001F8FD0
	public List<int> GetTeamRoleConfigIdListWithFill()
	{
		List<int> list = new List<int>(ModelBase<SceneTeamModel>.Instance.GetTeamRoleConfigIdList(false, false));
		for (int i = list.Count; i < 3; i++)
		{
			list.Add(0);
		}
		return list;
	}

	// Token: 0x060078DF RID: 30943 RVA: 0x001FAE08 File Offset: 0x001F9008
	public List<int> BuildSkillBranchListFromRoleList(List<int> roleList)
	{
		RoleModel roleModel = ModelBase<RoleModel>.Instance;
		return roleList.Select(delegate(int roleConfigId)
		{
			if (roleConfigId <= 0)
			{
				return 0;
			}
			return roleModel.GetRoleSkillBranchIdInGamePlay(roleConfigId, ESkillBranchCacheType.BabelTower);
		}).ToList<int>();
	}

	// Token: 0x060078E0 RID: 30944 RVA: 0x001FAE40 File Offset: 0x001F9040
	public void BabelTowerStartRequest(int instanceId, List<int> roleList, int levelId, List<int> buffList, List<int> skillBranchList)
	{
		BabelTowerData babelTowerData = this.GetBabelTowerData();
		this.RequestRankDataList(babelTowerData, true).Forget();
		BabelTowerCtx babelTowerCtx = new BabelTowerCtx();
		babelTowerCtx.LevelsId = levelId;
		babelTowerCtx.SelectBuff.Add(buffList);
		babelTowerCtx.SkillBranchId.Add(skillBranchList);
		ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.BabelTowerCtx = babelTowerCtx;
		int valueOrDefault = ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault();
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(valueOrDefault);
		defaultInterpolatedStringHandler.AppendLiteral("_");
		defaultInterpolatedStringHandler.AppendFormatted<long>((long)Singleton<Time>.Instance.ServerTimeStamp);
		string traceId = defaultInterpolatedStringHandler.ToStringAndClear();
		ModelBase<BabelTowerModel>.Instance.SetTraceId(traceId);
		ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(instanceId, roleList, 0, 0, null, null).ContinueWith(delegate(bool success)
		{
			if (success)
			{
				ModelBase<BabelTowerModel>.Instance.CurrentSelectLevel = 0;
				BabelTowerController <>4__this = this;
				BabelTowerInstanceData currentChallengeInstData = ModelBase<BabelTowerModel>.Instance.CurrentChallengeInstData;
				<>4__this.ReportBabelTowerEnterSelection(((currentChallengeInstData != null) ? currentChallengeInstData.TraceId : null) ?? "", levelId, buffList);
			}
			return UniTask.CompletedTask;
		}).Forget();
	}

	// Token: 0x060078E1 RID: 30945 RVA: 0x001FAF3B File Offset: 0x001F913B
	public BabelTowerData GetBabelTowerData()
	{
		return (BabelTowerData)ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId);
	}

	// Token: 0x060078E2 RID: 30946 RVA: 0x001FAF54 File Offset: 0x001F9154
	public void OnClickInstanceDungeonExitButton()
	{
		int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
		if (ModelBase<SceneTeamModel>.Instance.GetCurrentGroupLivingState(playerId) == ETeamLivingState.Dead)
		{
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BabelTowerInstanceDungeonLeave);
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		confirmBoxDataNew.FunctionMap[1] = new Action(BabelTowerController.<OnClickInstanceDungeonExitButton>g__LeaveCallBack|33_0);
		confirmBoxDataNew.FunctionMap[2] = new Action(this.<OnClickInstanceDungeonExitButton>g__ReChallengeCallBack|33_1);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x060078E3 RID: 30947 RVA: 0x001FAFCC File Offset: 0x001F91CC
	public void SaveNewLevelData(int levelId)
	{
		Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.BabelTowerNewLevel, null) ?? new Dictionary<int, bool>();
		dictionary[levelId] = true;
		LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.BabelTowerNewLevel, dictionary);
	}

	// Token: 0x060078E4 RID: 30948 RVA: 0x001FAFFC File Offset: 0x001F91FC
	public void SaveNewLevelClickData(int levelId, EBabelTowerDifficulty difficulty)
	{
		Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.BabelTowerNewLevelHasClick, null) ?? new Dictionary<int, bool>();
		dictionary[levelId] = true;
		LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.BabelTowerNewLevelHasClick, dictionary);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.BabelTowerLevelClick, levelId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.BabelTowerDifficultyLevelClick, (int)difficulty);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
	}

	// Token: 0x060078E5 RID: 30949 RVA: 0x001FB064 File Offset: 0x001F9264
	private void UpdateLocalLevelDataOnPass(int levelId, bool isDifficult, int curStarNum, BabelActivitySettleInfoNotify response)
	{
		BabelTowerData babelTowerData = this.GetBabelTowerData();
		BabelActivityLevelInfo babelActivityLevelInfo;
		if (!(isDifficult ? babelTowerData.HardLevelDataMap : babelTowerData.NormalLevelDataMap).TryGetValue(levelId, out babelActivityLevelInfo))
		{
			return;
		}
		int passStar = babelActivityLevelInfo.PassStar;
		int maxPassUseTime = babelActivityLevelInfo.MaxPassUseTime;
		int useTime = response.UseTime;
		babelActivityLevelInfo.IsFinished = true;
		bool flag = curStarNum > passStar;
		bool flag2 = curStarNum == passStar;
		bool flag3 = maxPassUseTime == 0 || (flag2 && useTime > 0 && useTime < maxPassUseTime);
		bool flag4 = flag || flag3;
		if (flag)
		{
			babelActivityLevelInfo.PassStar = curStarNum;
		}
		if (flag3)
		{
			babelActivityLevelInfo.MaxPassUseTime = useTime;
		}
		if (flag4)
		{
			List<int> teamRoleConfigIdList = ModelBase<SceneTeamModel>.Instance.GetTeamRoleConfigIdList(false, false);
			if (teamRoleConfigIdList != null && teamRoleConfigIdList.Count > 0)
			{
				babelActivityLevelInfo.MaxPassRoleSelection.Clear();
				babelActivityLevelInfo.MaxPassRoleSelection.Add(teamRoleConfigIdList);
			}
			RepeatedField<int> newBabelBuffIds = response.NewBabelBuffIds;
			if (newBabelBuffIds.Count > 0)
			{
				babelActivityLevelInfo.MaxPassBuffSelection.Clear();
				babelActivityLevelInfo.MaxPassBuffSelection.Add(newBabelBuffIds);
			}
		}
	}

	// Token: 0x060078E6 RID: 30950 RVA: 0x001FB154 File Offset: 0x001F9354
	private UniTask HandleHardLevelPassSettle(int levelId, int curStarNum, int targetStarNum, int instId, BabelTowerInstanceData instData, BabelActivitySettleInfoNotify response)
	{
		BabelTowerController.<HandleHardLevelPassSettle>d__37 <HandleHardLevelPassSettle>d__;
		<HandleHardLevelPassSettle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<HandleHardLevelPassSettle>d__.<>4__this = this;
		<HandleHardLevelPassSettle>d__.levelId = levelId;
		<HandleHardLevelPassSettle>d__.curStarNum = curStarNum;
		<HandleHardLevelPassSettle>d__.targetStarNum = targetStarNum;
		<HandleHardLevelPassSettle>d__.instId = instId;
		<HandleHardLevelPassSettle>d__.instData = instData;
		<HandleHardLevelPassSettle>d__.response = response;
		<HandleHardLevelPassSettle>d__.<>1__state = -1;
		<HandleHardLevelPassSettle>d__.<>t__builder.Start<BabelTowerController.<HandleHardLevelPassSettle>d__37>(ref <HandleHardLevelPassSettle>d__);
		return <HandleHardLevelPassSettle>d__.<>t__builder.Task;
	}

	// Token: 0x060078E7 RID: 30951 RVA: 0x001FB1CC File Offset: 0x001F93CC
	public UniTask RequestRankDataList(BabelTowerData data, bool cacheMyRank = false)
	{
		BabelTowerController.<RequestRankDataList>d__38 <RequestRankDataList>d__;
		<RequestRankDataList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestRankDataList>d__.data = data;
		<RequestRankDataList>d__.cacheMyRank = cacheMyRank;
		<RequestRankDataList>d__.<>1__state = -1;
		<RequestRankDataList>d__.<>t__builder.Start<BabelTowerController.<RequestRankDataList>d__38>(ref <RequestRankDataList>d__);
		return <RequestRankDataList>d__.<>t__builder.Task;
	}

	// Token: 0x060078E8 RID: 30952 RVA: 0x001FB218 File Offset: 0x001F9418
	public bool ConvertProtoToRankData(PublicBabelTowerInfo protoData, BabelTowerRankItemData rankItemData, int levelId)
	{
		RepeatedField<PublicBabelTowerChallengeInfo> challengeInfo = protoData.ChallengeInfo;
		if (challengeInfo.Count == 0)
		{
			return false;
		}
		bool flag = levelId == -1;
		List<PublicBabelTowerChallengeInfo> list = flag ? challengeInfo.ToList<PublicBabelTowerChallengeInfo>() : (from c in challengeInfo
		where c.ChallengeId == levelId && c.UseTime > 0
		select c).ToList<PublicBabelTowerChallengeInfo>();
		if (list.Count == 0)
		{
			return false;
		}
		int num = 0;
		int num2 = 0;
		List<int> list2 = new List<int>();
		List<int> list3 = new List<int>();
		foreach (PublicBabelTowerChallengeInfo publicBabelTowerChallengeInfo in list)
		{
			num += publicBabelTowerChallengeInfo.Star;
			num2 += publicBabelTowerChallengeInfo.UseTime;
			foreach (BabelPassRoleInfo babelPassRoleInfo in publicBabelTowerChallengeInfo.BabelPassRoleInfos)
			{
				list2.Add(babelPassRoleInfo.RoleId);
				list3.Add(babelPassRoleInfo.RoleLevel);
			}
		}
		if (num2 <= 0)
		{
			return false;
		}
		rankItemData.Name = protoData.Name;
		rankItemData.ShowName = protoData.ShowName;
		rankItemData.HeadId = protoData.HeadId;
		rankItemData.TowerLevel = list[0].ChallengeId;
		rankItemData.PassStar = num;
		rankItemData.PassTime = num2;
		rankItemData.RoleIdList = list2;
		rankItemData.RoleLevelList = list3;
		rankItemData.HasData = true;
		rankItemData.TitleId = protoData.TitleId;
		rankItemData.TitleStarLevel = protoData.TitleExtraParam;
		rankItemData.PlayerId = protoData.PlayerId;
		rankItemData.ShowRoleList = !flag;
		return true;
	}

	// Token: 0x060078E9 RID: 30953 RVA: 0x001FB3D0 File Offset: 0x001F95D0
	public UniTask SetShowNameRequestAsync(int activityId, bool showName)
	{
		BabelTowerController.<SetShowNameRequestAsync>d__40 <SetShowNameRequestAsync>d__;
		<SetShowNameRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetShowNameRequestAsync>d__.<>4__this = this;
		<SetShowNameRequestAsync>d__.activityId = activityId;
		<SetShowNameRequestAsync>d__.showName = showName;
		<SetShowNameRequestAsync>d__.<>1__state = -1;
		<SetShowNameRequestAsync>d__.<>t__builder.Start<BabelTowerController.<SetShowNameRequestAsync>d__40>(ref <SetShowNameRequestAsync>d__);
		return <SetShowNameRequestAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060078EA RID: 30954 RVA: 0x001FB424 File Offset: 0x001F9624
	private void ReportBabelTowerRankChange(int levelId, int currentStar, int targetStar, int dungeonId, string traceId, int oldLevelRank, int newLevelRank, int oldTotalRank, int newTotalRank)
	{
		PublicBabelTowerInfo rawSelfData = this.GetBabelTowerData().GetRawSelfData();
		int i_best_star = currentStar;
		if (((rawSelfData != null) ? rawSelfData.ChallengeInfo : null) != null)
		{
			PublicBabelTowerChallengeInfo publicBabelTowerChallengeInfo = rawSelfData.ChallengeInfo.FirstOrDefault((PublicBabelTowerChallengeInfo c) => c.ChallengeId == levelId);
			if (publicBabelTowerChallengeInfo != null)
			{
				i_best_star = publicBabelTowerChallengeInfo.Star;
			}
		}
		BabelTowerRankChangeEvent babelTowerRankChangeEvent = new BabelTowerRankChangeEvent();
		babelTowerRankChangeEvent.i_best_star = i_best_star;
		babelTowerRankChangeEvent.i_current_star = currentStar;
		babelTowerRankChangeEvent.i_target_star = targetStar;
		babelTowerRankChangeEvent.i_dungeon_id = dungeonId;
		babelTowerRankChangeEvent.s_trace_id = traceId;
		babelTowerRankChangeEvent.s_battle_id = traceId;
		babelTowerRankChangeEvent.i_old_exp = oldLevelRank;
		babelTowerRankChangeEvent.i_new_exp = newLevelRank;
		babelTowerRankChangeEvent.i_old_level = oldTotalRank;
		babelTowerRankChangeEvent.i_new_level = newTotalRank;
		ControllerBase<LogReportController>.Instance.LogReport(babelTowerRankChangeEvent);
	}

	// Token: 0x060078EB RID: 30955 RVA: 0x001FB4E0 File Offset: 0x001F96E0
	private static bool IsSameDeTermSet(List<int> a, int[] b)
	{
		if (a == null || b == null)
		{
			return false;
		}
		if (a.Count != b.Length)
		{
			return false;
		}
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (int key in a)
		{
			int num;
			if (dictionary.TryGetValue(key, out num))
			{
				dictionary[key] = num + 1;
			}
			else
			{
				dictionary[key] = 1;
			}
		}
		foreach (int key2 in b)
		{
			int num2;
			if (!dictionary.TryGetValue(key2, out num2) || num2 <= 0)
			{
				return false;
			}
			dictionary[key2] = num2 - 1;
		}
		return true;
	}

	// Token: 0x060078EC RID: 30956 RVA: 0x001FB5A0 File Offset: 0x001F97A0
	private void ReportBabelTowerEnterSelection(string traceId, int levelId, List<int> buffList)
	{
		BabelTowerEnterSelectionLogEvent babelTowerEnterSelectionLogEvent = new BabelTowerEnterSelectionLogEvent();
		List<int> list = (from buffId in buffList
		where buffId > 0
		select buffId).ToList<int>();
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(levelId);
		int[] recommendBuffs = babelTowerLevelConfig.GetRecommendBuffArray() ?? Array.Empty<int>();
		bool s_buff_selection = list.Count > 0 && list.All((int buffId) => recommendBuffs.Contains(buffId));
		babelTowerEnterSelectionLogEvent.s_buff_selection = s_buff_selection;
		babelTowerEnterSelectionLogEvent.o_buff_selection = (from buffId in list
		select new BuffSelectionData
		{
			i_buff_id = buffId
		}).ToList<BuffSelectionData>();
		List<int> allActiveDeTermList = ModelBase<BabelTowerModel>.Instance.GetAllActiveDeTermList();
		HashSet<int> hashSet = new HashSet<int>();
		foreach (KeyValuePair<int, IBabelTowerSelectInfo> keyValuePair in ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo)
		{
			int key = keyValuePair.Key;
			IBabelTowerSelectInfo value = keyValuePair.Value;
			if (key != 0 && (value.State == EBabelTowerDeTermState.Select || value.State == EBabelTowerDeTermState.StaticSelect))
			{
				hashSet.Add(key);
			}
		}
		babelTowerEnterSelectionLogEvent.o_debuff_selection = (from deTermId in hashSet
		select new DeBuffSelectionData
		{
			i_debuff_id = deTermId
		}).ToList<DeBuffSelectionData>();
		int currentQuickIndex = ModelBase<BabelTowerModel>.Instance.CurrentQuickIndex;
		string s_debuff_selection = "非预设";
		if (currentQuickIndex >= 0)
		{
			IReadOnlyList<BabelTowerQuick> babelTowerQuickByInstId = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerQuickByInstId(babelTowerLevelConfig.InstId);
			if (babelTowerQuickByInstId != null && currentQuickIndex < babelTowerQuickByInstId.Count)
			{
				BabelTowerQuick babelTowerQuick = babelTowerQuickByInstId[currentQuickIndex];
				if (BabelTowerController.IsSameDeTermSet(allActiveDeTermList, babelTowerQuick.GetBuffGroupArray()))
				{
					s_debuff_selection = babelTowerQuick.DifficultyTextKey;
				}
			}
		}
		babelTowerEnterSelectionLogEvent.s_debuff_selection = s_debuff_selection;
		babelTowerEnterSelectionLogEvent.s_trace_id = traceId;
		babelTowerEnterSelectionLogEvent.s_battle_id = traceId;
		ControllerBase<LogReportController>.Instance.LogReport(babelTowerEnterSelectionLogEvent);
	}

	// Token: 0x060078F2 RID: 30962 RVA: 0x001FB8B0 File Offset: 0x001F9AB0
	[CompilerGenerated]
	internal static void <OnClickInstanceDungeonExitButton>g__LeaveCallBack|33_0()
	{
		BabelTowerMainViewData param = new BabelTowerMainViewData
		{
			IfLeaveInstanceDungeonWhenClose = true
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerMainView, param, null);
	}

	// Token: 0x060078F3 RID: 30963 RVA: 0x001FB8DB File Offset: 0x001F9ADB
	[CompilerGenerated]
	private void <OnClickInstanceDungeonExitButton>g__ReChallengeCallBack|33_1()
	{
		this.ReChallengeBabelTower();
	}

	// Token: 0x04003A41 RID: 14913
	public int ActivityId;
}
